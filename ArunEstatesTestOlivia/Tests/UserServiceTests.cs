using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using ArunEstatesTestOlivia.Data;
using ArunEstatesTestOlivia.Models;
using ArunEstatesTestOlivia.Services;

namespace ArunEstatesTestOlivia.Tests
{
    public class UserServiceTests
    {
        private async Task<AppDbContext> GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var context = new AppDbContext(options);

            // Seed some test data
            if (!await context.Users.AnyAsync())
            {
                context.Users.Add(new User { UserName = "testuser", Password = "password123" });
                context.Users.Add(new User { UserName = "admin", Password = "adminpassword" });
                await context.SaveChangesAsync();
            }

            return context;
        }

        [Fact]
        public async Task AuthenticateUser_ReturnsUser_WhenCredentialsAreValid()
        {
            // Arrange
            var context = await GetInMemoryDbContext();
            var userService = new UserService(context);

            // Act
            var result = await userService.AuthenticateUser("testuser", "password123");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.UserName);
        }

        [Fact]
        public async Task AuthenticateUser_ReturnsNull_WhenCredentialsAreInvalid()
        {
            // Arrange
            var context = await GetInMemoryDbContext();
            var userService = new UserService(context);

            // Act
            var result = await userService.AuthenticateUser("testuser", "wrongpassword");

            // Assert
            Assert.Null(result);
        }
    }
}
