using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Drivers
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Last_Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? First_Name { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string? Ssn { get; set; }
        public DateTime? DoB { get; set; }
        [MaxLength(int.MaxValue)]
        public string? Address { get; set;}
        [MaxLength(150)]
        public string? City { get; set; }
        [MaxLength(25)]
        public string? Phone { get; set; }
        [MaxLength(10)]
        public string? Zip { get; set; }
        public bool Active { get; set; } = true;


    }
}
