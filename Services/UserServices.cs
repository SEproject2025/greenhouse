// This is the implementation of IPlantService.
// It contains the actual code for each method listed in IPlantService
// --------------------------------------------------------------------
using greenhouse.Data;
using greenhouse.Entities;
using Microsoft.EntityFrameworkCore;

namespace greenhouse.Services
{
	public class UserServices : IUserServices
	{
		private readonly ApplicationDbContext _context;

		public UserServices(ApplicationDbContext context)
		{
			_context = context;
		}

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
