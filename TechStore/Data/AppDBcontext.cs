using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData( new Category[]
                {
                    new Category { Id = 1, Name = "Smartphones", Icon = "smartphone" },
                    new Category { Id = 2, Name = "Laptops", Icon = "laptop" },
                    new Category { Id = 3, Name = "Tablets", Icon = "tablet" },
                });

            modelBuilder.Entity<Brand>()
                .HasData(new Brand[]
                {
                    // add brands here
                    new Brand { Id = 1, Name = "Apple", Icon = "apple" },
                    new Brand { Id = 2, Name = "Samsung", Icon = "samsung" },
                    new Brand { Id = 4, Name = "Dell", Icon = "dell" },
                }
                );
        }
    }
}
