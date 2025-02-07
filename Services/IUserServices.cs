// This is an interface that defines what actions can be performed (EX: GetAllplants),
// but it doesn’t contain any actual code. It’s like a menu that lists available options.
// --------------------------------------------------------------------------------------
using greenhouse.Data;

namespace greenhouse.Services
{
	public interface IUserServices
	{
		Task<string> GetUserID(string email);
    }
}
