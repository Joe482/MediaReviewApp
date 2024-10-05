using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaReviewApp.Data;
using MediaReviewApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaReviewApp.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly ReviewDbContext _context;

        public IndexModel(ReviewDbContext context)
        {
            _context = context;
        }

        public IList<Review> Reviews { get; set; }

        // Pagination properties
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 5; // Number of reviews per page

        // Filter and sort properties
        public string CurrentCategory { get; set; }
        public string CurrentSort { get; set; }

        // Available sort options
        public List<string> SortOptions { get; } = new List<string> { "RatingAsc", "RatingDesc", "CategoryAsc", "CategoryDesc" };

        public async Task OnGetAsync(string categoryFilter, string sortOrder, int? pageNumber)
        {
            // Set current page
            CurrentPage = pageNumber ?? 1;

            // Store current category and sort values to use in the view
            CurrentCategory = categoryFilter;
            CurrentSort = sortOrder;

            // Start by selecting all reviews
            var reviewsQuery = from r in _context.Reviews
                               select r;

            // Filtering by category
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                reviewsQuery = reviewsQuery.Where(r => r.Category == categoryFilter);
            }

            // Sorting logic
            switch (sortOrder)
            {
                case "RatingAsc":
                    reviewsQuery = reviewsQuery.OrderBy(r => r.Rating);
                    break;
                case "RatingDesc":
                    reviewsQuery = reviewsQuery.OrderByDescending(r => r.Rating);
                    break;
                case "CategoryAsc":
                    reviewsQuery = reviewsQuery.OrderBy(r => r.Category);
                    break;
                case "CategoryDesc":
                    reviewsQuery = reviewsQuery.OrderByDescending(r => r.Category);
                    break;
                default:
                    reviewsQuery = reviewsQuery.OrderBy(r => r.Title);
                    break;
            }

            // Get the total count of reviews for pagination
            int totalReviews = await reviewsQuery.CountAsync();

            // Calculate the total number of pages
            TotalPages = (int)Math.Ceiling(totalReviews / (double)PageSize);

            // Apply pagination using Skip and Take
            Reviews = await reviewsQuery
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
