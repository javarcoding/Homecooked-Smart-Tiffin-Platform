
using Homecooked.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Homecooked.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets will be added later

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Convert Role enum to string in DB
            modelBuilder
                .Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>();

            // Register all Fluent API configurations
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
