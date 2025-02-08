// This is an interface that defines what actions can be performed (EX: GetAllplants),
// but it doesn’t contain any actual code. It’s like a menu that lists available options.
// --------------------------------------------------------------------------------------
using greenhouse.Entities;

namespace greenhouse.Services
{
	public interface IPlantService
	{
		Task<List<Plants>> GetAllPlants();
		Task<List<Plants>> GetAllPublicPlants();
		Task<Plants>       GetPlantByID(int PLANT_ID);
		Task<List<Plants>> GetUserPlants(string user_id);
		Task<Plants>       AddPlants(Plants plants);
		Task<bool>         DeletePlant(int PLANT_ID);
		Task<Dictionary<String, int>> GetFrequencyFields(int plantID);

    }
}
