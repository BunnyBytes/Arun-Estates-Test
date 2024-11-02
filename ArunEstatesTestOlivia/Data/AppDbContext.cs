using ArunEstatesTestOlivia.Models;
using Microsoft.EntityFrameworkCore;

namespace ArunEstatesTestOlivia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets for your entities
        public DbSet<User> Users { get; set; }
    }
}
