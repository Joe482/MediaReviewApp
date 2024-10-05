using MediaReviewApp.Data;
using MediaReviewApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MediaReviewApp.Pages.Reviews
{
    public class EditModel : PageModel
    {
        private readonly ReviewDbContext _context;

        public EditModel(ReviewDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Reviews.FindAsync(id);

            if (Review == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Load the existing review from the database using the ReviewID
            var reviewToUpdate = await _context.Reviews.FindAsync(Review.ReviewID);

            if (reviewToUpdate == null)
            {
                return NotFound();
            }

            // Update the properties of the reviewToUpdate object with the new values from the form
            reviewToUpdate.Title = Review.Title;
            reviewToUpdate.Category = Review.Category;
            reviewToUpdate.ReviewText = Review.ReviewText;
            reviewToUpdate.Rating = Review.Rating;
            reviewToUpdate.DateReviewed = Review.DateReviewed;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewID == id);
        }
    }
}
