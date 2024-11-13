using ReviewProvider.Models;
using ReviewProvider.DTO;
using ReviewProvider.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ReviewProvider.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region DELETE

        // Delete all reviews made by a specific userId
        public async Task<IEnumerable<Review>> DeleteReviewsByUserIdAsync(int userId)
        {
            var reviews = await _context.Reviews.Where(r => r.UserID == userId).ToListAsync();
            if (!reviews.Any()) return new List<Review>();

            _context.Reviews.RemoveRange(reviews);
            await _context.SaveChangesAsync();
            return reviews;
        }

        // Delete all reviews made for a specific productId
        public async Task<IEnumerable<Review>> DeleteReviewsByProductIdAsync(int productId)
        {
            var reviews = await _context.Reviews.Where(r => r.ProductID == productId).ToListAsync();
            if (!reviews.Any()) return new List<Review>();

            _context.Reviews.RemoveRange(reviews);
            await _context.SaveChangesAsync();
            return reviews;
        }

        #endregion

        #region POST

        // Add a new review
        public async Task<Review?> AddReviewAsync(ReviewDTO reviewDTO)
        {
            if (reviewDTO == null) return null;

            var review = new Review
            {
                ReviewDescription = reviewDTO.ReviewDescription,
                Rating = reviewDTO.Rating,
                Status = "Pending",  // New reviews are initially marked as "Pending"
                UserID = reviewDTO.UserID,
                ProductID = reviewDTO.ProductID,
                DateReviewed = DateTime.UtcNow
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        // Approve a pending review
        public async Task<Review?> AuthorizeReviewAsync(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null) return null;

            review.Status = "Approved";
            await _context.SaveChangesAsync();
            return review;
        }

        #endregion

        #region GET

        // Show all reviews
        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        // Show all approved reviews for a specific product
        public async Task<IEnumerable<Review>> GetApprovedReviewsAsync()
        {
            return await _context.Reviews.Where(r => r.Status == "Approved").ToListAsync();
        }

        // Show all pending reviews
        public async Task<IEnumerable<Review>> GetPendingReviewsAsync()
        {
            return await _context.Reviews.Where(r => r.Status == "Pending").ToListAsync();
        }

        // Show all reviews made by a specific userId
        public async Task<IEnumerable<Review>> GetAllReviewsByUserIdAsync(int userId)
        {
            return await _context.Reviews.Where(r => r.UserID == userId).ToListAsync();
        }

        // Show a review for a specific reviewId
        public async Task<Review?> GetReviewByReviewIdAsync(int reviewId)
        {
            return await _context.Reviews.FindAsync(reviewId);
        }

        // Show all reviews made for a specific productId
        public async Task<IEnumerable<Review>> GetAllReviewsByProductIdAsync(int productId)
        {
            return await _context.Reviews.Where(r => r.ProductID == productId).ToListAsync();
        }

        #endregion
    }
}