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
		public int			   PLANT_ID	  { get; set; }
		public required string PLANT_NAME { get; set; }
		public string?		   IS_PRIVATE { get; set; } = "Y"; // Default value set to "Y" testststststs
		public string?		   USER_ID	  { get; set; }
        public byte[]?		   IMAGE_DATA { get; set; } // Property to store image data
        public int WATER_FREQ { get; set; } = 7;
    }
}
