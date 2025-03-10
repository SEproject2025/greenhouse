﻿// This class and its inherited interface are used to directly 
// interact with the Plants table in the MySQL database
// -----------------------------------------------------------
using greenhouse.Data;
using greenhouse.Entities;
using Microsoft .EntityFrameworkCore;

namespace greenhouse.Services
{
	public class PlantService : IPlantService
	{
        // The Db Context
        private readonly ApplicationDbContext _context;

        // ******************************************************************************
        // Constructor - Fetches the Db context
        // ******************************************************************************
        public PlantService(ApplicationDbContext context)
		{
			_context = context;
		}

        // ******************************************************************************
        // Adds a plant to the page and the database
        // ******************************************************************************
        public async Task<Plants> AddPlants(Plants plants)
        {
            _context.Plant.Add(plants);
			await _context.SaveChangesAsync();

			return plants;
        }

        // ******************************************************************************
        // Deletes a plant from the page and the database
        // ******************************************************************************
        public async Task<bool> DeletePlant(int PLANT_ID)
		{
			var dbPlant = await _context.Plant.FindAsync(PLANT_ID);
			if (dbPlant != null)
			{
				_context.Remove(dbPlant);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

        // ******************************************************************************
        // Gets all plants currently in database
        // ******************************************************************************
        public async Task<List<Plants>> GetAllPlants()
		{
			return await _context.Plant.ToListAsync();
		}

        // ******************************************************************************
        // Gets all public plants not created by the user
        // ******************************************************************************
        public async Task<List<Plants>> GetAllPublicPlants()
		{
            return await _context.Plant
                      .Where(plant => plant.IS_PRIVATE == "N")
                      .ToListAsync();
		}

        // ******************************************************************************
        // Gets all tasks for every plant a user is growing
        // ******************************************************************************
        public async Task<List<PlantTask>> GetAllUserTasks(string uuid)
        {
            var user_plants = await GetUserPlants(uuid);
            var user_tasks = new List<PlantTask>();
            var indi_p_tasks = new List<PlantTask>();
            

            foreach (var p in user_plants)
            {
                var plant_id = p.PLANT_ID;
                indi_p_tasks = await _context.PlantTasks
                    .Where(task => task.PLANT_ID == plant_id && task.FREQ != 0)
                    .ToListAsync();
                user_tasks.AddRange(indi_p_tasks);
            }

            return user_tasks;

        }

        // ******************************************************************************
        // Gets a plant from the database by ID
        // ******************************************************************************
        public async Task<Plants> GetPlantByID(int PLANT_ID)
		{
			return await _context.Plant.FindAsync(PLANT_ID);
		}

        // ******************************************************************************
        // Gets the current user's plants
        // ******************************************************************************
        public async Task<List<Plants>> GetUserPlants(string user_id)
		{
			return await _context.Plant
                      .Where(plant => plant.USER_ID == user_id)
                      .ToListAsync(); ;
        }

        // ******************************************************************************
        // Retrieves a list of PlantTask records associated with a specific plant ID.
        // ******************************************************************************
        public async Task<List<PlantTask>> GetTasksForPlant(int PLANT_ID)
        {
            return await _context.PlantTasks
                .Where(task => task.PLANT_ID == PLANT_ID)   // Filters tasks based on the provided plant ID
                .Select(task => new PlantTask               // Selects the relevant fields, ensuring null values default to 0
                {
                    TASK_ID = task.TASK_ID,                 // Assigns the task's unique ID
                    PLANT_ID = task.PLANT_ID,               // Assigns the associated plant ID
                    TASK_NAME = task.TASK_NAME,             // Assigns the task name (e.g., Watering, Pruning)
                    FREQ = task.FREQ ?? 0,                  // Ensures frequency is never null (defaults to 0)
                    DAYS_UNTIL = task.DAYS_UNTIL ?? 0,      // Ensures days until next task is never null
                    IS_COMPLETED = task.IS_COMPLETED,       // Tracks if the task has been completed
                    DONE_DATE = task.DONE_DATE,             // Stores the date the task was completed
                    OVERDUE = task.OVERDUE ?? 0             // Ensures overdue count is never null (defaults to 0)    
                })
                .ToListAsync();                             // Converts the query results into a list asynchronously
        }

        // ******************************************************************************
        // Adds a new task to the PlantTasks table
        // ******************************************************************************
        public async Task<bool> AddTask(PlantTask task)
        {
            _context.PlantTasks.Add(task);                  // Adds the new task record to the database context     
            await _context.SaveChangesAsync();              // Saves changes asynchronously to persist the new task
            return true;                                    // Returns true to indicate successful insertion
        }


        // ******************************************************************************
        // Updates a task in the PlantTask table  
        // ******************************************************************************
        /*public async Task<bool> UpdateTask(PlantTask task)
        {
            var dbTask = await _context.PlantTasks.FindAsync(task.TASK_ID);
            if (dbTask != null)
            {
                _context.Entry(dbTask).CurrentValues.SetValues(task);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;*/
            
            
        // ******************************************************************************
        // Updates an existing plant's details in the database.
        // ******************************************************************************
        public async Task<bool> UpdatePlant(Plants plant)
        {
            _context.Plant.Update(plant);
            await _context.SaveChangesAsync();
            return true;
        }

        // ******************************************************************************
        // Updates an existing plant task's details in the database.
        // ******************************************************************************
        public async Task<bool> UpdateTask(PlantTask task)
        {
            _context.PlantTasks.Update(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
