using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Entities
{
    public class Routes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Description { get; set; }
        public int Driver_Id { get; set; }
        [ForeignKey("Driver_Id")]
        public virtual Drivers? Drive { get; set; }
        public bool Active { get; set; }
        public int Vehicle_Id { get; set; }
        [ForeignKey("Vehicle_Id")]
        public virtual Vehicles? Vehicle { get; set; }

    }
}
