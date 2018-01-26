namespace ProductShop.Data
{
    using ProductShop.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class ProductShopDbContext : DbContext
    {
        public ProductShopDbContext() { }

        public ProductShopDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appConfig.json")
                    .Build();

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(config.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.LastName)
                    .IsRequired();

                entity.Property(e => e.Age)
                    .IsRequired(false);
            });

            builder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Price)
                    .IsRequired();

                entity.Property(e => e.BuyerId)
                    .IsRequired(false);

                entity.Property(e => e.SellerId)
                    .IsRequired();

                entity.HasOne(e => e.Buyer)
                    .WithMany(b => b.BoughtProducts)
                    .HasForeignKey(e => e.BuyerId);

                entity.HasOne(e => e.Seller)
                    .WithMany(s => s.SoldProducts)
                    .HasForeignKey(e => e.SellerId);
            });

            builder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId });

                entity.HasOne(e => e.Category)
                    .WithMany(cp => cp.CategoryProducts)
                    .HasForeignKey(e => e.CategoryId);

                entity.HasOne(e => e.Product)
                    .WithMany(cp => cp.CategoryProducts)
                    .HasForeignKey(e => e.ProductId);
            });
        }
    }
}
