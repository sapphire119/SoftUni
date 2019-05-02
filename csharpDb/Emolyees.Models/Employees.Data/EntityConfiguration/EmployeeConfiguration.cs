namespace Employees.Data.EntityConfiguration
{
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                    .IsRequired();

            builder.Property(e => e.LastName)
                    .IsRequired();

            builder.Property(e => e.Salary)
                    .IsRequired();

            builder.Property(e => e.Birthday)
                    .HasColumnType("DATE")
                    .IsRequired(false);

            builder.Property(e => e.ManagerId)
                    .IsRequired(false);
        }
    }
}
