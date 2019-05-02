namespace BookShop.Data
{
    using BookShop.Models;

    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConfigurationString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.Property(e => e.FirstName)
                    .IsUnicode()
                    .IsRequired(false)
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(1000);

                entity.Property(e => e.ReleaseDate)
                    .IsRequired(false);

                entity.HasOne(e => e.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(e => e.AuthorId);
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.CategoryId });

                entity.HasOne(e => e.Book)
                    .WithMany(b => b.BookCategories)
                    .HasForeignKey(e => e.BookId);

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.CategoryBooks)
                    .HasForeignKey(e => e.CategoryId);
            });
        }
    }
}
