using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace greenhouse.Entities
{
    public class PlantTask
    {
        [Key]
        public int       TASK_ID { get; set; } // Primary Key

        [ForeignKey("Plant")]
        public int       PLANT_ID { get; set; } 
        public required string TASK_NAME { get; set; } 
        public int?      FREQ { get; set; } 
        public int?      DAYS_UNTIL { get; set; } = 0;
        public bool      IS_COMPLETED { get; set; } = false;
        public DateTime? DONE_DATE { get; set; }
        public int?      OVERDUE { get; set; } = 0;

        // Navigation Property
        public Plants? Plant { get; set; }
    }
}
