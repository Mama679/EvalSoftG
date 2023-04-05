using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Vehicles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Description { get; set; }
        public int Year { get; set; }   
        public int Make { get; set; }   
        public int Capacity { get; set; } 
        public bool Active { get; set; }
    }
}
