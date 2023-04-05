using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string? UserLogin { get; set; }
        [Required]
        [StringLength(30)]
        public string? Names { get; set; }
        [Required]
        [MaxLength(255)]
        public string? Password { get; set; }
        [Required]
        [StringLength(25)]
        public string? Rol { get; set; }
         public bool Active { get; set; }
    }
}
