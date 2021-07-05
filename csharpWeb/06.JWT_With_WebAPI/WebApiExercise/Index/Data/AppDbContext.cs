using Index.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Index.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
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

        private void SeedData(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<string>();

            var firstUsername = "gosho";
            var secondUsername = "pesho";

            var firstUser = new AppUser
            {
                UserName = firstUsername,
                PasswordHash = hasher.HashPassword(firstUsername, "123")
            };

            var secondUser = new AppUser
            {
                UserName = secondUsername,
                PasswordHash = hasher.HashPassword(secondUsername, "123")
            };

            builder.Entity<AppUser>().HasData(
                firstUser,
                secondUser
                );

            builder.Entity<Message>().HasData(
                new Message("hey Pesho", firstUser.Id),
                new Message("hey Gosho", secondUser.Id),
                new Message("What's up?", firstUser.Id),
                new Message("Nothing", secondUser.Id),
                new Message("How are you?", firstUser.Id)
                );

        }
    }
}
