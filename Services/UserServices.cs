// This class and its inherited interface are used to directly 
// interact with the Users table in the MySQL database
// -----------------------------------------------------------
using greenhouse.Data;
using Microsoft .EntityFrameworkCore;

namespace greenhouse.Services
{
    public class UserServices : IUserServices
	{
		// The Db Context
		private readonly ApplicationDbContext _context;

		// Constructor - Fetches the Db context
		public UserServices(ApplicationDbContext context)
		{
			_context = context;
		}

        // Gets the current user's UUID
        public async Task<string> GetUserID(string email)
		{
			var user_list = await _context.Users
				.Where(user => user.UserName == email)
				.ToListAsync();
			var user = user_list.FirstOrDefault();

            return user.Id;
		}
    }
}
