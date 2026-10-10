using System;
using System.Collections.Generic;
using System.Linq;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Data.DAL
{
    /// <summary>
    /// Tầng Data Access Layer (DAL) cho thực thể Sinh viên:
    /// Thực hiện các thao tác trực tiếp với nguồn dữ liệu: Lấy về, Thêm, Sửa, Xóa.
    /// </summary>
    public class SinhVienDAL
    {
        private static readonly List<SinhVien> _danhSachSinhVien = new List<SinhVien>();

        static SinhVienDAL()
        {
            // Nạp dữ liệu mẫu ban đầu khớp 100% với giao diện trong bài tập
            _danhSachSinhVien.Add(new SinhVien(
                "SV000123", "Nguyễn Văn An", new DateTime(2006, 8, 15),
                "Nam", "an.nv@vju.ac.vn", "0912345678", 8.5,
                "KTPM01", "Kỹ thuật phần mềm 01", "Đang học"
            ));

            _danhSachSinhVien.Add(new SinhVien(
                "SV000124", "Trần Minh Anh", new DateTime(2006, 1, 22),
                "Nữ", "anh.tm@vju.ac.vn", "0987654321", 9.0,
                "TTNT01", "Trí tuệ nhân tạo 01", "Đang học"
            ));

            _danhSachSinhVien.Add(new SinhVien(
                "SV000125", "Lê Hoàng Bình", new DateTime(2006, 5, 9),
                "Nam", "binh.lh@vju.ac.vn", "0355556677", 7.4,
                "KTPM01", "Kỹ thuật phần mềm 01", "Đang học"
            ));

            _danhSachSinhVien.Add(new SinhVien(
                "SV000126", "Đỗ Thị Hồng", new DateTime(2006, 11, 30),
                "Nữ", "hong.dt@vju.ac.vn", "0777888999", 8.1,
                "KHDL01", "Khoa học dữ liệu 01", "Đang học"
            ));
        }

        // Lấy về toàn bộ danh sách sinh viên
        public List<SinhVien> LayTatCa()
        {
            return _danhSachSinhVien.ToList();
        }

        // Lấy về sinh viên theo mã sinh viên
        public SinhVien? LayTheoMa(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return null;
            return _danhSachSinhVien.FirstOrDefault(s => s.MaSV.Equals(maSV.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // Lấy về danh sách sinh viên theo mã lớp hoặc tên lớp (tìm kiếm phía nguồn dữ liệu)
        public List<SinhVien> LayTheoLop(string maHoacTenLop)
        {
            if (string.IsNullOrWhiteSpace(maHoacTenLop) || maHoacTenLop == "Tất cả lớp")
            {
                return LayTatCa();
            }
            return _danhSachSinhVien
                .Where(s => s.MaLop.Equals(maHoacTenLop.Trim(), StringComparison.OrdinalIgnoreCase) ||
                            s.TenLop.Equals(maHoacTenLop.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Thêm sinh viên vào nguồn dữ liệu
        public bool Them(SinhVien sv)
        {
            if (sv == null || LayTheoMa(sv.MaSV) != null) return false;
            _danhSachSinhVien.Add(sv);
            return true;
        }

        // Sửa thông tin sinh viên trong nguồn dữ liệu
        public bool Sua(SinhVien svMoi)
        {
            if (svMoi == null) return false;
            var svCu = LayTheoMa(svMoi.MaSV);
            if (svCu == null) return false;

            svCu.HoTen = svMoi.HoTen;
            svCu.NgaySinh = svMoi.NgaySinh;
            svCu.GioiTinh = svMoi.GioiTinh;
            svCu.Email = svMoi.Email;
            svCu.DienThoai = svMoi.DienThoai;
            svCu.Diem = svMoi.Diem;
            svCu.MaLop = svMoi.MaLop;
            svCu.TenLop = svMoi.TenLop;
            svCu.TrangThai = svMoi.TrangThai;

            return true;
        }

        // Xóa sinh viên khỏi nguồn dữ liệu
        public bool Xoa(string maSV)
        {
            var sv = LayTheoMa(maSV);
            if (sv != null)
            {
                return _danhSachSinhVien.Remove(sv);
            }
            return false;
        }
    }
}
