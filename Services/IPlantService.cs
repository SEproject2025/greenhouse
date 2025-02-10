// This interface and its derived class are used to directly 
// interact with the Plant table in the MySQL database
// ---------------------------------------------------------
using greenhouse.Entities;

namespace greenhouse.Services
{
	public interface IPlantService
	{
        // Add a plant to the page and the database
        Task<Plants>      AddPlants(Plants plants);

        // Delete a plant from the page and the database
        Task<bool>         DeletePlant(int PLANT_ID);

        // Gets all plants currently in database
        Task<List<Plants>> GetAllPlants();

        // Get all public plants not created by the user
        Task<List<Plants>> GetAllPublicPlants();

        // Retrieves frequency-related fields for a specific plant by its ID
        Task<Dictionary<String, int>> 
                           GetFrequencyFields(int plantID);

        // Get a plant from the database by ID
        Task<Plants>       GetPlantByID(int PLANT_ID);

		// Get the current user's plants
		Task<List<Plants>> GetUserPlants(string user_id);
    }
}
