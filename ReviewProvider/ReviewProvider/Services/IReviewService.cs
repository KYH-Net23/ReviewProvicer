using Microsoft.EntityFrameworkCore;
using ReviewProvider.DTO;
using ReviewProvider.Models;

namespace ReviewProvider.Services
{
    public interface IReviewService
    {
        // DELETE
        Task<IEnumerable<Review>> DeleteReviewsByUserIdAsync(int userId);
        Task<IEnumerable<Review>> DeleteReviewsByProductIdAsync(int productId);

        // POST
        Task<Review?> AddReviewAsync(ReviewDTO reviewDTO);
        Task<Review?> AuthorizeReviewAsync(int reviewId);

        // GET
        Task<IEnumerable<Review>> GetAllReviews();
        Task<IEnumerable<Review>> GetApprovedReviewsAsync();
        Task<IEnumerable<Review>> GetPendingReviewsAsync();
        Task<IEnumerable<Review>> GetAllReviewsByUserIdAsync(int userId);
        Task<Review?> GetReviewByReviewIdAsync(int reviewId);
        Task<IEnumerable<Review>> GetAllReviewsByProductIdAsync(int productId);
    }
}
