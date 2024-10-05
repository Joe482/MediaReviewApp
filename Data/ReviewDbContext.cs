using Microsoft.EntityFrameworkCore;
using MediaReviewApp.Models;

namespace MediaReviewApp.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options) : base(options) { }

        public DbSet<Review> Reviews { get; set; }
    }
}
