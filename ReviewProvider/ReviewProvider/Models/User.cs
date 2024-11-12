using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReviewProvider.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
