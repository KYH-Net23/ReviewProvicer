using Microsoft.AspNetCore.Mvc;
using ReviewProvider.DTO;
using ReviewProvider.Models;
using ReviewProvider.Services;
using System.Linq;

namespace ReviewProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // DELETE: api/review/delete/user/{userId}
        [HttpDelete("delete/user/{userId}")]
        public async Task<IActionResult> DeleteReviewsByUserId(int userId)
        {
            var deletedReviews = await _reviewService.DeleteReviewsByUserIdAsync(userId);
            if (!deletedReviews.Any())
                return NotFound("No reviews found for this user to delete.");

            return Ok(new { message = $"{deletedReviews.Count()} reviews deleted successfully for user {userId}." });
        }

        // DELETE: api/review/delete/product/{productId}
        [HttpDelete("delete/product/{productId}")]
        public async Task<IActionResult> DeleteReviewsByProductId(int productId)
        {
            var deletedReviews = await _reviewService.DeleteReviewsByProductIdAsync(productId);
            if (!deletedReviews.Any())
                return NotFound("No reviews found for this product.");

            return Ok(new { message = "All reviews for this product have been deleted." });
        }

        // POST: api/review/add
        [HttpPost("add")]
        public async Task<IActionResult> AddReview([FromBody] ReviewDTO reviewDTO)
        {
            if (reviewDTO == null)
                return BadRequest("Review data is required.");

            var newReview = await _reviewService.AddReviewAsync(reviewDTO);
            if (newReview == null)
                return BadRequest("Failed to add review.");

            return Ok(new { message = "Review added successfully.", review = newReview });
        }

        // POST: api/review/authorize/{reviewId}
        [HttpPost("authorize/{reviewId}")]
        public async Task<IActionResult> AuthorizeReview(int reviewId)
        {
            var authorizedReview = await _reviewService.AuthorizeReviewAsync(reviewId);
            if (authorizedReview == null)
                return NotFound("Review not found.");

            return Ok(new { message = "Review authorized successfully." });
        }

        // GET: api/review/allreviews
        [HttpGet("allreviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            var allReviews = await _reviewService.GetAllReviews();
            return Ok(allReviews.Select(r => new ReviewDTO
            {
                ReviewID = r.ReviewId,
                ReviewDescription = r.ReviewDescription,
                Rating = r.Rating,
                Status = r.Status
            }));
        }

        // GET: api/review/approved/{productId}
        [HttpGet("approved")]
        public async Task<IActionResult> GetApprovedReviews()
        {
            var approvedReviews = await _reviewService.GetApprovedReviewsAsync();
            return Ok(approvedReviews.Select(r => new ReviewDTO
            {
                ReviewID = r.ReviewId,
                ReviewDescription = r.ReviewDescription,
                Rating = r.Rating,
                Status = r.Status
            }));
        }

        // GET: api/review/pending
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingReviews()
        {
            var pendingReviews = await _reviewService.GetPendingReviewsAsync();
            return Ok(pendingReviews.Select(r => new ReviewDTO
            {
                ReviewID = r.ReviewId,
                ReviewDescription = r.ReviewDescription,
                Rating = r.Rating,
                Status = r.Status
            }));
        }

        // GET: api/review/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReviewsByUser(int userId)
        {
            var reviews = await _reviewService.GetAllReviewsByUserIdAsync(userId);
            if (reviews == null || !reviews.Any())
                return NotFound("No reviews found for this user.");

            return Ok(reviews.Select(r => new ReviewDTO
            {
                ReviewID = r.ReviewId,
                ReviewDescription = r.ReviewDescription,
                Rating = r.Rating,
                Status = r.Status
            }));
        }

        // GET: api/review/product/{productId}
        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetReviewsByProductId(int productId)
        {
            var reviews = await _reviewService.GetAllReviewsByProductIdAsync(productId);
            if (reviews == null || !reviews.Any())
                return NotFound("No reviews found for this product.");

            return Ok(reviews.Select(r => new ReviewDTO
            {
                ReviewID = r.ReviewId,
                ReviewDescription = r.ReviewDescription,
                Rating = r.Rating,
                Status = r.Status
            }));
        }

        // GET: api/review/review/{reviewId}
        [HttpGet("review/{reviewId}")]
        public async Task<IActionResult> GetReviewByReviewId(int reviewId)
        {
            var review = await _reviewService.GetReviewByReviewIdAsync(reviewId);
            if (review == null)
                return NotFound("Review not found.");

            return Ok(new ReviewDTO
            {
                ReviewID = review.ReviewId,
                ReviewDescription = review.ReviewDescription,
                Rating = review.Rating,
                Status = review.Status
            });
        }
    }
}
