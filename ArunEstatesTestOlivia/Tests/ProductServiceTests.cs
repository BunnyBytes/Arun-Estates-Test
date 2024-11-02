using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using ArunEstatesTestOlivia.Data;
using ArunEstatesTestOlivia.Models;
using ArunEstatesTestOlivia.Services;

namespace ArunEstatesTestOlivia.Tests
{
    public class ProductServiceTests
    {
        private async Task<AppDbContext> GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Consistent database name for all tests
                .Options;

            var context = new AppDbContext(options);

            // Seed some test data if the database is empty
            if (!await context.Products.AnyAsync())
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product { Id = 1, Name = "Product A", Description = "Description for Product A", Price = 10.99m, StockQuantity = 100 },
                    new Product { Id = 2, Name = "Product B", Description = "Description for Product B", Price = 20.99m, StockQuantity = 50 },
                    new Product { Id = 3, Name = "Another Product", Description = "Different product description", Price = 15.50m, StockQuantity = 0 },
                });
                await context.SaveChangesAsync();
            }

            return context;
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnAllProducts()
        {
            // Arrange
            var context = await GetInMemoryDbContext();
            var productService = new ProductService(context);

            // Act
            var result = await productService.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task GetProductById_ValidId_ShouldReturnProduct()
        {
            // Arrange
            var context = await GetInMemoryDbContext();
            var productService = new ProductService(context);

            // Act
            var result = await productService.GetProductByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Product A", result?.Name);
        }

        [Fact]
        public async Task GetProductById_InvalidId_ShouldReturnNull()
        {
            // Arrange
            var context = await GetInMemoryDbContext();
            var productService = new ProductService(context);

            // Act
            var result = await productService.GetProductByIdAsync(999); // Non-existing ID

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task SearchProducts_ValidSearchTerm_ShouldReturnMatchingProducts()
        {
            // Arrange
            var context = await GetInMemoryDbContext();
            var productService = new ProductService(context);

            // Act
            var result = await productService.SearchProductsAsync("Product");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task SearchProducts_NoMatches_ShouldReturnEmptyList()
        {
            // Arrange
            var context = await GetInMemoryDbContext();
            var productService = new ProductService(context);

            // Act
            var result = await productService.SearchProductsAsync("Non-existing product");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result); // Should return an empty list
        }
    }

}
