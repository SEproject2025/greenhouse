// This file defines the DataContext class, which is how your app communicates with the database.
// DataContext manages the connection and data retrieval from the database, acting as a bridge 
// between your code and the database.
//--------------------------------------------------------------------------------------

using greenhouse.Entities;
using Microsoft.EntityFrameworkCore;

namespace greenhouse.Data
{ 
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) 
		   : base(options)
		{ }

		public DbSet<Plants> Plant { get; set; }
	}
	
}
