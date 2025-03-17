// This class and its inherited interface are used to directly 
// interact with the Users table in the MySQL database
// -----------------------------------------------------------
using greenhouse.Data;
using greenhouse.Entities;
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

        // Gets the current user's relative current day
        public async Task<DateTime> GetRelativeCurrentDay(string uuid)
		{
            var user = await _context.Users.FindAsync(uuid);
            return user.UserCurrentDay;
        }

        // Updates the current user's relative current day
        public async Task<bool> UpdateUserCurrentDate(string uuid, DateTime new_date)
        {
            var user = await _context.Users.FindAsync(uuid);
            user.UserCurrentDay = new_date;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
