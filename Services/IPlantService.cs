// This interface and its derived class are used to directly 
// interact with the Plant table in the MySQL database
// ---------------------------------------------------------
using greenhouse.Entities;

namespace greenhouse.Services
{
	public interface IPlantService
	{
        // Adds a plant to the page and the database
        Task<Plants>      AddPlants(Plants plants);

        // Deletes a plant from the page and the database
        Task<bool>         DeletePlant(int PLANT_ID);

        // Gets all plants currently in database
        Task<List<Plants>> GetAllPlants();

        // Gets all public plants not created by the user
        Task<List<Plants>> GetAllPublicPlants();

        // Gets all tasks for every plant a user is growing
        Task<List<PlantTask>> GetAllUserTasks(string uuid);

        // Gets a plant from the database by ID
        Task<Plants>       GetPlantByID(int PLANT_ID);

		// Gets the current user's plants
		Task<List<Plants>> GetUserPlants(string user_id);

        // Retrieves a list of PlantTask records associated with a specific plant ID.
        Task<List<PlantTask>> GetTasksForPlant(int PLANT_ID);

        // Adds a new task to the PlantTasks table
        Task<bool> AddTask(PlantTask task);

        // Update an existing plant's details in the database
        Task<bool> UpdatePlant(Plants plant);

        // Update an existing task's details in the database
        Task<bool> UpdateTask(PlantTask task);

    }
}
