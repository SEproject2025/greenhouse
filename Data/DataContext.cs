// This file defines the DataContext class, which is how your app communicates with the database.
// DataContext manages the connection and data retrieval from the database, acting as a bridge 
// between your code and the database.
//--------------------------------------------------------------------------------------

using greenhouse.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace greenhouse.Data
{ 
	public class DataContext : IdentityDbContext<ApplicationUser>
	{
		public DataContext(DbContextOptions<DataContext> options) 
		   : base(options)
		{ }

		public DbSet<Plants> Plant { get; set; }
	}

    public class ApplicationUser : IdentityUser
    {
		public string CustomTag {  get; set; }
    }
}
