// This file defines the Plants class, which represents the structure of 
// a plant entry in your database.  It acts as a blueprint for a table in the database,
//  specifying what information about each plant is stored.
//--------------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace greenhouse.Entities
{
	public class Plants
	{
		[Key]
		public int PlantId { get; set; }
		public required string PlantName { get; set; }

	}
}
