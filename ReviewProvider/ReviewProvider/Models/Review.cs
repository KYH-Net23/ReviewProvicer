using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewProvider.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string? ReviewDescription { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public DateTime DateReviewed { get; set; } = DateTime.UtcNow;

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        [Required]
        public string? Status { get; set; }
    }
}
