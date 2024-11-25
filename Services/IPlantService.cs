// This is an interface that defines what actions can be performed (EX: GetAllplants),
// but it doesn’t contain any actual code. It’s like a menu that lists available options.
// --------------------------------------------------------------------------------------
using greenhouse.Entities;

namespace greenhouse.Services
{
	public interface IPlantService
	{
		Task<List<Plant>> GetAllPlants();
		Task<List<Plant>> GetAllPublicPlants();
		Task<Plant> GetPlantByID(int PLANT_ID);
		Task<Plant> AddPlants(Plant plants);
		Task<bool> DeletePlant(int PLANT_ID);

	}
}
