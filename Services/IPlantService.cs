// This is an interface that defines what actions can be performed (EX: GetAllplants),
// but it doesn’t contain any actual code. It’s like a menu that lists available options.
// --------------------------------------------------------------------------------------
using greenhouse.Entities;

namespace greenhouse.Services
{
	public interface IPlantService
	{
		Task<List<Plants>> GetAllPlants();
	}
}
