namespace Employees.Data
{
    using Employees.Models;
    using Employees.Data.EntityConfiguration;

    using Microsoft.EntityFrameworkCore;

    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() { }

        public EmployeeDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConfigurationString);
            }
        }

        protected override void OnModelCreating(ModelBuilder mBuilder)
        {
            mBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

    }
}
