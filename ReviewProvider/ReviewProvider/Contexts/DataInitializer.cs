using Microsoft.EntityFrameworkCore;
using ReviewProvider.Models;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace ReviewProvider.Contexts
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void MigrateData()
        {
            SeedProducts();
            SeedUsers();
            SeedReviews();
            _dbContext.SaveChanges();
        }

        private void SeedProducts()
        {
            if (!_dbContext.Products.Any())
            {
                _dbContext.AddRange(
                new Product
                {
                    Brand = "Apple",
                    Model = "iPhone 15",
                    Description = "The latest iPhone with advanced features and a sleek design.",
                    Price = 999.99m,
                    Category = "Smartphone",
                    Image = "https://example.com/images/iphone15.png",
                    Stock = 50,
                    Size = "128GB",
                    AddedDate = DateOnly.FromDateTime(DateTime.Now)
                },
                new Product
                {
                    Brand = "Samsung",
                    Model = "Galaxy S23",
                    Description = "High-performance Samsung smartphone with an amazing display.",
                    Price = 899.99m,
                    Category = "Smartphone",
                    Image = "https://example.com/images/galaxy-s23.png",
                    Stock = 75,
                    Size = "256GB",
                    AddedDate = DateOnly.FromDateTime(DateTime.Now)
                },
                new Product
                {
                    Brand = "Google",
                    Model = "Pixel 8",
                    Description = "Google's flagship phone with the best Android experience.",
                    Price = 799.99m,
                    Category = "Smartphone",
                    Image = "https://example.com/images/pixel8.png",
                    Stock = 30,
                    Size = "128GB",
                    AddedDate = DateOnly.FromDateTime(DateTime.Now)
                },
                new Product
                {
                    Brand = "OnePlus",
                    Model = "OnePlus 12",
                    Description = "A powerful phone with fast charging and premium design.",
                    Price = 649.99m,
                    Category = "Smartphone",
                    Image = "https://example.com/images/oneplus12.png",
                    Stock = 40,
                    Size = "256GB",
                    AddedDate = DateOnly.FromDateTime(DateTime.Now)
                }
                );
            }
        }

        private void SeedUsers()
        {
            if (!_dbContext.Users.Any())
            {
                _dbContext.AddRange(
                new User
                {
                    FirstName = "Johan",
                    LastName = "Andersson",
                    Email = "Johan@hotmail.com",
                    DateCreated = DateTime.Now,
                },
                new User
                {
                    FirstName = "Anton",
                    LastName = "Johansson",
                    Email = "Anton@hotmail.com",
                    DateCreated = DateTime.Now,
                },
                new User
                {
                    FirstName = "Johan",
                    LastName = "Robinson",
                    Email = "Johan@hotmail.com",
                    DateCreated = DateTime.Now,
                }
                );
            }
        }
        private void SeedReviews()
        {
            if (!_dbContext.Reviews.Any())
            {
                _dbContext.AddRange(
                new Review
                {
                    ReviewDescription = "Great product! Highly recommend.",
                    Rating = 5,
                    DateReviewed = DateTime.UtcNow,
                    UserID = 10,
                    ProductID = 13,
                    Status = "Approved"
                },
                new Review
                {
                    ReviewDescription = "Decent quality, could be better.",
                    Rating = 3,
                    DateReviewed = DateTime.UtcNow,
                    UserID = 11,
                    ProductID = 14,
                    Status = "Pending"
                },
                new Review
                {
                    ReviewDescription = "Decent quality, could be better.",
                    Rating = 3,
                    DateReviewed = DateTime.UtcNow,
                    UserID = 11,
                    ProductID = 14,
                    Status = "Approved"
                },
                new Review
                {
                    ReviewDescription = "Decent quality, could be better.",
                    Rating = 5,
                    DateReviewed = DateTime.UtcNow,
                    UserID = 12,
                    ProductID = 16,
                    Status = "Pending"
                },
                new Review
                {
                    ReviewDescription = "This product sucks.",
                    Rating = 1,
                    DateReviewed = DateTime.UtcNow,
                    UserID = 12,
                    ProductID = 15,
                    Status = "Approved"
                },
                new Review
                {
                    ReviewDescription = "Decent quality, could be better.",
                    Rating = 3,
                    DateReviewed = DateTime.UtcNow,
                    UserID = 10,
                    ProductID = 14,
                    Status = "Pending"
                },
                new Review
                {
                    ReviewDescription = "Nah quality, could not be better.",
                    Rating = 4,
                    DateReviewed = DateTime.UtcNow,
                    UserID = 11,
                    ProductID = 13,
                    Status = "Pending"
                }
                );
            }
        }

    }

}