using System;
using System.ComponentModel.DataAnnotations;

namespace MediaReviewApp.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public DateTime DateReviewed { get; set; } // Ensure this is a DateTime
    }
}
