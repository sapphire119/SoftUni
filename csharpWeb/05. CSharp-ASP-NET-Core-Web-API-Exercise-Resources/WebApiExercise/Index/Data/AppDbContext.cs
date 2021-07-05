using Index.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Index.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedData(builder);
            base.OnModelCreating(builder);
        }

        private static void SeedData(ModelBuilder builder)
        {
            builder.Entity<Message>().HasData(
                new Message("hey Pesho", "gosho'"),
                new Message("hey Gosho", "pesho'"),
                new Message("What's up?", "gosho'"),
                new Message("Nothing", "pesho'"),
                new Message("How are you?", "gosho'")
                );
        }
    }
}
