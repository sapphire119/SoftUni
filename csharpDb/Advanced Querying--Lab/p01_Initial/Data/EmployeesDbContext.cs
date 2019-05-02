using p01_Initial.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace p01_Initial.Data
{
    public class EmployeesDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=DESKTOP-03A7982\SQLEXPRESS;Database=Employees;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Salary)
                .IsConcurrencyToken();
            });
        }
    }
}
