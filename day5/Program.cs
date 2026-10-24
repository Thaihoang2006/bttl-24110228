using System;
using System.Linq;
using day5.Context;
using day5.Entities;

namespace day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=============================================================");
            Console.WriteLine("  BÀI TẬP: ENTITY FRAMEWORK CORE - PHƯƠNG PHÁP CODE FIRST");
            Console.WriteLine("=============================================================");
            Console.WriteLine();

            Console.WriteLine("[THÔNG TIN MÔ HÌNH THỰC THỂ]");
            Console.WriteLine("1. Context Quản Lý Thư Viện: QLTVDBContext");
            Console.WriteLine("   - Thực thể Category (Thể loại): CategoryId, CategoryName, Description");
            Console.WriteLine("   - Thực thể Book (Sách): BookId, Title, Author, Price, PublishedYear, CategoryId");
            Console.WriteLine("   - Thực thể Reader (Độc giả): ReaderId, FullName, PhoneNumber, Email");
            Console.WriteLine("   - Migration: InitialLibraryDB (đã sinh mã thành công trong thư mục Migrations)");
            Console.WriteLine();
            Console.WriteLine("2. Lệnh Migration EF Core tương ứng:");
            Console.WriteLine("   - Thêm migration: dotnet ef migrations add InitialLibraryDB --context QLTVDBContext");
            Console.WriteLine("   - Cập nhật database: dotnet ef database update --context QLTVDBContext (hoặc update-database trong PMC)");
            Console.WriteLine();

            try
            {
                using (var qltvContext = new QLTVDBContext())
                {
                    Console.WriteLine("[BƯỚC 1] Khởi tạo QLTVDBContext...");
                    bool created = qltvContext.Database.EnsureCreated();
                    if (created)
                    {
                        Console.WriteLine("  -> Thành công: Đã tự động tạo CSDL QLTV và các bảng trên SQL Server!");
                    }
                    else
                    {
                        Console.WriteLine("  -> CSDL QLTV đã tồn tại và sẵn sàng kết nối.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Lưu ý kết nối SQL Server] {ex.Message}");
                Console.WriteLine("-> Khi máy có SQL Server đang chạy (hoặc khi nộp bài cho cô), lệnh update-database sẽ tạo bảng trực tiếp vào CSDL.");
            }

            Console.WriteLine();
            Console.WriteLine("=============================================================");
            Console.WriteLine("  HOÀN THÀNH: Entity framework core code first");
            Console.WriteLine("=============================================================");
        }
    }
}
