using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using day5.Entities;

namespace day5.Context
{
    /// <summary>
    /// Lớp DbContext quản lý phiên kết nối và ánh xạ Code-First sang Database (Slide 17, 18 & 22)
    /// </summary>
    public class StudentContext : DbContext
    {
        public string conStr { get; set; }

        public StudentContext()
        {
            try
            {
                conStr = ConfigurationManager.ConnectionStrings["studentDataBase"]?.ConnectionString ?? "";
            }
            catch
            {
                conStr = "";
            }

            if (string.IsNullOrEmpty(conStr))
            {
                conStr = @"Server=.; Database=QLSV_CodeFirst; Integrated Security=True; TrustServerCertificate=True";
            }
        }

        public StudentContext(string connectionString)
        {
            conStr = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Cấu hình bảng trung gian StudentSubject (quan hệ n - n, Slide 18)
            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(su => su.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            // 2. Cấu hình quan hệ 1 - n giữa Grade và Student (Slide 20 & 22)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        // Định nghĩa các tập thực thể ánh xạ thành các bảng tương ứng trong CSDL (Slide 18 & 22)
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
    }
}
