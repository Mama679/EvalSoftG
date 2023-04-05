using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Schedules
    {
        [Key]
        public int Id { get;set; }
        [Required]
        public int Week_Num { get; set; }
        [Required]
        public DateTime Start { get; set; }
        public DateTime Ends { get; set; }
        public bool Active { get; set; }
        public int Route_Id { get; set;}
        [ForeignKey("Route_Id")]
        public virtual Routes? Route { get; set; }

    }
}
