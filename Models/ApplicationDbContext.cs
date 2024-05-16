using Microsoft.EntityFrameworkCore;

namespace jwt_authentication.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
            modelBuilder.Entity<User>().HasKey(x => x.UserId);

        }
    }
}
