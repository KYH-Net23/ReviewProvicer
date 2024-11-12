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
            if (_dbContext.Database.CanConnect())
            {
                _dbContext.Database.EnsureDeleted();
                _dbContext.Database.EnsureCreated();
            }
            else
            {
                _dbContext.Database.Migrate();
            }
            SeedProducts();
            SeedUsers();
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

    }

}