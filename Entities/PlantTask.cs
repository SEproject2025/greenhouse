using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace greenhouse.Entities
{
    public class PlantTask
    {
        [Key]
        public int TASK_ID { get; set; } // Primary Key

        [ForeignKey("Plants")]
        public int PLANT_ID { get; set; } // Foreign Key - Links to Plant
        public required string TASK_NAME { get; set; } // Task Type (Water, Weed, etc.)
        public int FREQ { get; set; } // Number of days between tasks

        // Future fields (not used yet but required for the new model)
        public int DAYS_UNTIL { get; set; } = 0;
        public bool IS_COMPLETED { get; set; } = false;
        public DateTime? DONE_DATE { get; set; }
        public int OVERDUE { get; set; } = 0;

        // Navigation Property
        public Plants? Plant { get; set; }
    }
}
