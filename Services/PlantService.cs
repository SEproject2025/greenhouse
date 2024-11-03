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

        public async Task<Plants> AddPlants(Plants plants)
        {
            _context.Plant.Add(plants);
			await _context.SaveChangesAsync();

			return plants;
        }

        public async Task<List<Plants>> GetAllPlants()
		{
			var plant = await _context.Plant.ToListAsync();
			return plant;
		}
	}
}
