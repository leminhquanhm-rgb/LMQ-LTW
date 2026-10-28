using LmqLesson11Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace LmqLesson11Lab4.Data
{
    public class LmqSchoolContext : DbContext
    {
        public LmqSchoolContext(DbContextOptions<LmqSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LmqCourse> Courses { get; set; }

        public virtual DbSet<LmqLearner> Learners { get; set; }

        public virtual DbSet<LmqEnrollment> Enrollments { get; set; }

        public virtual DbSet<LmqMajor> Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Khai báo khóa chính
            modelBuilder.Entity<LmqMajor>()
                .HasKey(m => m.MajorID);

            modelBuilder.Entity<LmqLearner>()
                .HasKey(l => l.LearnerID);

            modelBuilder.Entity<LmqCourse>()
                .HasKey(c => c.CourseID);

            modelBuilder.Entity<LmqEnrollment>()
                .HasKey(e => e.EnrollmentID);

            // Ánh xạ tên bảng trong SQL Server
            modelBuilder.Entity<LmqMajor>().ToTable("Major");

            modelBuilder.Entity<LmqCourse>().ToTable("Course");

            modelBuilder.Entity<LmqLearner>().ToTable("Learner");

            modelBuilder.Entity<LmqEnrollment>().ToTable("Enrollment");
        }
    }
}