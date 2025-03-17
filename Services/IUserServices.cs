// This interface and its derived class are used to directly 
// interact with the Users table in the MySQL database
// ---------------------------------------------------------
using Microsoft.AspNetCore.Components.Authorization;

namespace greenhouse.Services
{
    public interface IUserServices
	{
        // Gets the current user's UUID or returns a null-representing value
		Task<string> GetUserID(AuthenticationState authState);
    }
}