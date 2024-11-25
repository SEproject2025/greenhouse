// This file defines the DataContext class, which is how your app communicates with the database.
// DataContext manages the connection and data retrieval from the database, acting as a bridge 
// between your code and the database.
//--------------------------------------------------------------------------------------

using greenhouse.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace greenhouse.Data
{ 
	public class DataContext : IdentityDbContext<ApplicationUser>
	{
		public DataContext(DbContextOptions<DataContext> options) 
		   : base(options)
		{ }

		public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

			builder.Entity<Plant>(entity => {
				entity.HasOne(d => d.Owner)
					.WithMany(p => p.Plants);
			});
        }
    }
	
}
