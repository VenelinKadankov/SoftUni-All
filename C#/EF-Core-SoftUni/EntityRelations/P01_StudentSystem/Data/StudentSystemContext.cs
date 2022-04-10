using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = .; Integrated Security = true; Database = StudentSystem");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Student>()
            //    .Property(x => x.Name)
            //    .HasColumnType("NVARCHAR");

            //modelBuilder.Entity<Student>()
            //    .Property(x => x.PhoneNumber)
            //    .HasColumnType("VARCHAR");

            //modelBuilder.Entity<Student>()
            //    .Property(x => x.RegisteredOn)
            //    .HasColumnType("DATE");

            //modelBuilder.Entity<Student>()
            //    .Property(x => x.Birthday)
            //    .HasColumnType("DATE");

            modelBuilder.Entity<StudentCourse>()
                .HasKey(x => new { x.StudentId, x.CourseId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
