using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Data.DAL
{
    /// <summary>
    /// Tầng Data Access Layer (DAL) cho thực thể Lớp học:
    /// Thực hiện các thao tác trực tiếp với nguồn dữ liệu: Lấy về, Thêm, Sửa, Xóa.
    /// </summary>
    public class LopDAL
    {
        private static readonly List<LopHoc> _danhSachLop = new List<LopHoc>();

        static LopDAL()
        {
            // Khởi tạo nguồn dữ liệu lớp học ban đầu
            _danhSachLop.Add(new LopHoc("KTPM01", "Kỹ thuật phần mềm 01"));
            _danhSachLop.Add(new LopHoc("TTNT01", "Trí tuệ nhân tạo 01"));
            _danhSachLop.Add(new LopHoc("KHDL01", "Khoa học dữ liệu 01"));
        }

        // Lấy về tất cả các lớp học
        public List<LopHoc> LayTatCa()
        {
            return _danhSachLop.ToList();
        }

        // Lấy về lớp học theo mã lớp
        public LopHoc? LayTheoMa(string maLop)
        {
            if (string.IsNullOrWhiteSpace(maLop)) return null;
            return _danhSachLop.FirstOrDefault(l => l.MaLop.Equals(maLop.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // Lấy về lớp học theo tên lớp
        public LopHoc? LayTheoTen(string tenLop)
        {
            if (string.IsNullOrWhiteSpace(tenLop)) return null;
            return _danhSachLop.FirstOrDefault(l => l.TenLop.Equals(tenLop.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // Thêm lớp học vào nguồn dữ liệu
        public bool Them(LopHoc lop)
        {
            if (lop == null || LayTheoMa(lop.MaLop) != null) return false;
            _danhSachLop.Add(lop);
            return true;
        }

        // Sửa thông tin lớp học
        public bool Sua(LopHoc lopMoi)
        {
            if (lopMoi == null) return false;
            var lopCu = LayTheoMa(lopMoi.MaLop);
            if (lopCu == null) return false;

            lopCu.TenLop = lopMoi.TenLop;
            return true;
        }

        // Xóa lớp học khỏi nguồn dữ liệu
        public bool Xoa(string maLop)
        {
            var lop = LayTheoMa(maLop);
            if (lop != null)
            {
                return _danhSachLop.Remove(lop);
            }
            return false;
        }
    }
}
