using Microsoft.EntityFrameworkCore;

namespace jwt_authentication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // The base constructor handles initializing the DbContext with the provided options.
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   UserId = 1, // Explicitly set a unique UserId, HasData requires all properties
                   FirstName = "Ahmed",
                   LastName = "Khan",
                   Username = "Ahmed",
                   Password = "qwerty12345",
                   isActive = true,
               }
           );

        }
    }
}
