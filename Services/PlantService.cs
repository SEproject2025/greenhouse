// This class and its inherited interface are used to directly 
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
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        // ******************************************************************************
        // Constructor - Fetches the Db context
        // ******************************************************************************
        public PlantService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        // ******************************************************************************
        // Adds a plant to the page and the database
        // ******************************************************************************
        public async Task<Plants> AddPlants(Plants plants)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Plant.Add(plants);
            await dbContext.SaveChangesAsync();
            return plants;
        }

        // ******************************************************************************
        // Deletes a plant from the page and the database
        // ******************************************************************************
        public async Task<bool> DeletePlant(int PLANT_ID)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            var dbPlant = await dbContext.Plant.FindAsync(PLANT_ID);
            if (dbPlant != null)
            {
                dbContext.Remove(dbPlant);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // ******************************************************************************
        // Gets all plants currently in database
        // ******************************************************************************
        public async Task<List<Plants>> GetAllPlants()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.Plant.ToListAsync();
        }

        // ******************************************************************************
        // Gets all public plants not created by the user
        // ******************************************************************************
        public async Task<List<Plants>> GetAllPublicPlants()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.Plant
                .Where(plant => plant.IS_PRIVATE == "N")
                .ToListAsync();
        }

        // ******************************************************************************
        // Gets all tasks for every plant a user is growing
        // ******************************************************************************
        public async Task<List<PlantTask>> GetAllUserTasks(string uuid)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.PlantTasks
                .Where(task => dbContext.Plant
                    .Where(plant => plant.USER_ID == uuid)
                    .Select(plant => plant.PLANT_ID)
                    .Contains(task.PLANT_ID) && task.FREQ != 0)
                .ToListAsync();
        }


        // ******************************************************************************
        // Gets a plant from the database by ID
        // ******************************************************************************
        public async Task<Plants> GetPlantByID(int PLANT_ID)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.Plant.FindAsync(PLANT_ID);
        }

        // ******************************************************************************
        // Gets the current user's plants
        // ******************************************************************************
        public async Task<List<Plants>> GetUserPlants(string user_id)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.Plant
                      .Where(plant => plant.USER_ID == user_id)
                      .ToListAsync();
        }


        // ******************************************************************************
        // Retrieves a list of PlantTask records associated with a specific plant ID.
        // ******************************************************************************
        public async Task<List<PlantTask>> GetTasksForPlant(int PLANT_ID)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.PlantTasks
                .Where(task => task.PLANT_ID == PLANT_ID)
                .Select(task => new PlantTask
                {
                    TASK_ID = task.TASK_ID,
                    PLANT_ID = task.PLANT_ID,
                    TASK_NAME = task.TASK_NAME,
                    FREQ = task.FREQ ?? 0,
                    DAYS_UNTIL = task.DAYS_UNTIL ?? 0,
                    IS_COMPLETED = task.IS_COMPLETED,
                    DONE_DATE = task.DONE_DATE,
                    OVERDUE = task.OVERDUE ?? 0
                })
                .ToListAsync();
        }

        // ******************************************************************************
        // Adds a new task to the PlantTasks table
        // ******************************************************************************
        public async Task<bool> AddTask(PlantTask task)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.PlantTasks.Add(task);
            await dbContext.SaveChangesAsync();
            return true;
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
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.Plant.Update(plant);
            await dbContext.SaveChangesAsync();
            return true;
        }

        // ******************************************************************************
        // Updates an existing plant task's details in the database.
        // ******************************************************************************
        public async Task<bool> UpdateTask(PlantTask task)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            dbContext.PlantTasks.Update(task);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
