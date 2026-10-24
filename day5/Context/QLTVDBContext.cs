using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using day5.Entities;

namespace day5.Context
{
    /// <summary>
    /// Lớp QLTVDBContext quản lý cơ sở dữ liệu Quản Lý Thư Viện (LibraryDB)
    /// </summary>
    public class QLTVDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }

        public QLTVDBContext()
        {
        }

        public QLTVDBContext(DbContextOptions<QLTVDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conStr = "";
                try
                {
                    conStr = ConfigurationManager.ConnectionStrings["QLTV"]?.ConnectionString
                             ?? ConfigurationManager.ConnectionStrings["LibraryDB"]?.ConnectionString
                             ?? ConfigurationManager.ConnectionStrings["studentDataBase"]?.ConnectionString
                             ?? "";
                }
                catch
                {
                    conStr = "";
                }

                if (string.IsNullOrWhiteSpace(conStr))
                {
                    conStr = @"Server=.;Database=QLTV;Integrated Security=True;TrustServerCertificate=True";
                }

                optionsBuilder.UseSqlServer(conStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình mối quan hệ 1 - N giữa Category và Book
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
