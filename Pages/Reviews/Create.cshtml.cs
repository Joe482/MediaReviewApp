using MediaReviewApp.Data;
using MediaReviewApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaReviewApp.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly ReviewDbContext _context;

        public CreateModel(ReviewDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        // List of categories to choose from
        public List<string> Categories { get; set; } = new List<string>
        {
            "Movie", "Book", "Game", "Music", "TV Show", "Podcast"
        };

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ensure the DateReviewed is stored in UTC
            if (Review.DateReviewed != null)
            {
                Review.DateReviewed = DateTime.SpecifyKind(Review.DateReviewed, DateTimeKind.Utc);
            }

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}
