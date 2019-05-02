using Microsoft.EntityFrameworkCore;
using P01_Initial.Data.Models;

namespace P01_Initial.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext() { }

        public ProductsDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<WereHouse> WereHouses { get; set; }

        public DbSet<ProductWerehouse> ProductWerehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=./SqlExpress;Database=Products;Integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.HasOne(e => e.Manufacturer)
                    .WithMany(m => m.Products)
                    .HasForeignKey(e => e.ManufacturerId);
            });

            builder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<WereHouse>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            builder.Entity<ProductWerehouse>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.WereHouseId });

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.ProductWerehouses)
                    .HasForeignKey(e => e.ProductId);

                entity.HasOne(e => e.WereHouse)
                    .WithMany(w => w.ProductWerehouses)
                    .HasForeignKey(e => e.WereHouseId);
            });
        }

    }
}
