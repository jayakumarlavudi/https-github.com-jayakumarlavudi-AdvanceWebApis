using Microsoft.EntityFrameworkCore;

namespace SampleWebAPI.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);
             
            //Seed() - > Method from ModelBuilderExtentions
            modelBuilder.Seed();
        }

        public DbSet<Product> products { get; set; }

        public DbSet<Category> categories { get; set; }
    }

   


     

}
