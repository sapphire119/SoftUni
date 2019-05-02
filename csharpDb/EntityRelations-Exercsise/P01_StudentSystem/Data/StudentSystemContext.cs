namespace P01_StudentSystem.Data
{
    using P01_StudentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }

        public StudentSystemContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConfigurationString);
            }
        }

        protected override void OnModelCreating(ModelBuilder mbuilder)
        {
            mbuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("CHAR(10)")
                    .IsUnicode(false)
                    .IsRequired(false);

                entity.Property(e => e.RegisteredOn)
                    .HasColumnType("DATE")
                    .IsRequired();

                entity.Property(e => e.Birthday)
                    .HasColumnType("DATE")
                    .IsRequired(false);
            });

            mbuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(80);

                entity.Property(e => e.Description)
                    .IsRequired(false)
                    .IsUnicode();

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.EndDate)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.Price)
                    .IsRequired();
                
            });

            mbuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(e => e.CourseId);
            });

            mbuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);

                entity.Property(e => e.Content)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.SubmissionTime)
                    .HasColumnType("DATETIME2")
                    .IsRequired();

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(e => e.CourseId);
            });

            mbuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CourseId });

                entity.HasOne(e => e.Student)
                    .WithMany(s => s.CourseEnrollments)
                    .HasForeignKey(e => e.StudentId);

                entity.HasOne(e => e.Course)
                    .WithMany(c => c.StudentsEnrolled)
                    .HasForeignKey(e => e.CourseId);
            });
        }
    }
}
