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
        private readonly ApplicationDbContext _context;

        // Constructor - Fetches the Db context
        public PlantService(ApplicationDbContext context)
		{
			_context = context;
		}

		// Add a plant to the page and the database
        public async Task<Plants> AddPlants(Plants plants)
        {
            _context.Plant.Add(plants);
			await _context.SaveChangesAsync();

			return plants;
        }

		// Delete a plant from the page and the database
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

        // Gets all plants currently in database
        public async Task<List<Plants>> GetAllPlants()
		{
			return await _context.Plant.ToListAsync();
		}

		// Get all public plants not created by the user
		public async Task<List<Plants>> GetAllPublicPlants()
		{
			return await _context.Plant
                      .Where(plant => plant.IS_PRIVATE == "N")
                      .ToListAsync(); ;
		}

        // Retrieves frequency-related fields for a specific plant by its ID
        public async Task<Dictionary<string, int>> GetFrequencyFields(int plantId)
        {
            var plant = await _context.Plant.FindAsync(plantId);    // Find the plant by its ID
            var frequencyFields = new Dictionary<string, int>();    // Dictionary to store field names & frequencies

            if (plant == null)
            {
                return new Dictionary<string, int>();
            }

            if (plant.WATER_FREQ > 0)
            {
                frequencyFields.Add("Water", plant.WATER_FREQ);
            }

            return frequencyFields;
        }

        // Get a plant from the database by ID
        public async Task<Plants> GetPlantByID(int PLANT_ID)
		{
			return await _context.Plant.FindAsync(PLANT_ID);
		}

        // Get the current user's plants
        public async Task<List<Plants>> GetUserPlants(string user_id)
		{
			return await _context.Plant
                      .Where(plant => plant.USER_ID == user_id)
                      .ToListAsync(); ;
        }
    }
}
