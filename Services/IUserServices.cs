// This interface and its derived class are used to directly 
// interact with the Users table in the MySQL database
// ---------------------------------------------------------
namespace greenhouse.Services
{
    public interface IUserServices
	{
        // Gets the current user's UUID
		Task<string> GetUserID(string email);
    }
}