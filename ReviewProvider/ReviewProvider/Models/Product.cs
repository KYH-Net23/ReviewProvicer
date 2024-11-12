using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReviewProvider.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string Brand { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        public string? Description { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be lower than 0.")]
        [Required]
        public decimal Price { get; set; }
        public string? Category { get; set; }
        [Required]
        public string Image { get; set; } = null!;
        [Required]
        public int Stock { get; set; }
        public string? Size { get; set; }
        public DateOnly AddedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
