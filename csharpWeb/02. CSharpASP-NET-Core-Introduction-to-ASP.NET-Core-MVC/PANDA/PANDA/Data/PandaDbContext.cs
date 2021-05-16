using Microsoft.EntityFrameworkCore;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Data
{
    public class PandaDbContext : DbContext
    {
        public PandaDbContext() { }

        public PandaDbContext(DbContextOptions options)
            : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>(package =>
            {
                package.Property(e => e.Weight).HasPrecision(19, 4);

                package.HasOne(e => e.Recipient)
                    .WithMany(r => r.Packages)
                    .OnDelete(DeleteBehavior.Restrict);

                package.HasOne(e => e.Receipt)
                    .WithOne(r => r.Package)
                    .HasForeignKey<Receipt>(e => e.PackageId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Receipt>(receipt =>
            {
                receipt.Property(e => e.Fee)
                    .HasPrecision(19, 4);
            });
        }
    }
}
