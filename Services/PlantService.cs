// This is the implementation of IPlantService.
// It contains the actual code for each method listed in IPlantService
// --------------------------------------------------------------------
using greenhouse.Data;
using greenhouse.Entities;
using Microsoft.EntityFrameworkCore;

namespace greenhouse.Services
{
	public class PlantService : IPlantService
	{
		private readonly DataContext _context;

		public PlantService(DataContext context)
		{
			_context = context;
		}

        public async Task<Plant> AddPlants(Plant plants)
        {
            _context.Plants.Add(plants);
			await _context.SaveChangesAsync();

			return plants;
        }

		public async Task<bool> DeletePlant(int PLANT_ID)
		{
			var dbPlant = await _context.Plants.FindAsync(PLANT_ID);
			if (dbPlant != null)
			{
				_context.Remove(dbPlant);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<List<Plant>> GetAllPlants()
		{
			var plant = await _context.Plants.ToListAsync();
			return plant;
		}
		public async Task<List<Plant>> GetAllPublicPlants()
		{

			var PublicPlants = await _context.Plants
				.Where(plant => plant.IS_PRIVATE == "N")
				.ToListAsync();

			return PublicPlants;
		}

		public async Task<Plant> GetPlantByID(int PLANT_ID)
		{
			return await _context.Plants.FindAsync(PLANT_ID);
		}
	}
}
