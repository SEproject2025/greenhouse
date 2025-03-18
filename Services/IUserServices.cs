// This interface and its derived class are used to directly 
// interact with the Users table in the MySQL database
// ---------------------------------------------------------
using greenhouse.Data;

namespace greenhouse.Services
{
    public interface IUserServices
	{
        // Gets the current user's UUID
		Task<string> GetUserID(string email);

        // Gets the current user's relative current day
        Task<DateTime> GetRelativeCurrentDay(string uuid);

        // Updates the current user's relative current day
        Task<bool> UpdateUserCurrentDate(string uuid, DateTime new_date);
    }
}