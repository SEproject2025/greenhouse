// This interface and its derived class are used to directly 
// interact with the Users table in the MySQL database
// ---------------------------------------------------------
using Microsoft.AspNetCore.Components.Authorization;
using greenhouse.Data;

namespace greenhouse.Services
{
    public interface IUserServices
	{
        // Gets the current user's UUID or returns a null-representing value
		    Task<string> GetUserID(AuthenticationState authState);

        // Gets the current user's relative current day
        Task<DateTime> GetRelativeCurrentDay(string uuid);

        // Updates the current user's relative current day
        Task<bool> UpdateUserCurrentDate(string uuid, DateTime new_date);
    }
}