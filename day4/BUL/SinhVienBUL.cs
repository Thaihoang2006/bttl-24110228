using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QuanLySinhVien.Data.DAL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.BUL
{
    /// <summary>
    /// Tầng Business (BUL) cho Sinh viên:
    /// Xử lý các quy tắc nghiệp vụ, kiểm tra tính hợp lệ bằng Data Annotation trước khi gọi xuống tầng DAL.
    /// </summary>
    public class SinhVienBUL
    {
        private readonly SinhVienDAL _sinhVienDAL = new SinhVienDAL();
        private readonly LopDAL _lopDAL = new LopDAL();

        public List<SinhVien> LayDanhSachSinhVien()
        {
            return _sinhVienDAL.LayTatCa();
        }

        public List<SinhVien> LaySinhVienTheoLop(string maHoacTenLop)
        {
            return _sinhVienDAL.LayTheoLop(maHoacTenLop);
        }

        public SinhVien? TimSinhVienTheoMa(string maSV)
        {
            return _sinhVienDAL.LayTheoMa(maSV);
        }

        public bool KiemTraTonTai(string maSV)
        {
            return _sinhVienDAL.LayTheoMa(maSV) != null;
        }

        /// <summary>
        /// Phương thức thêm sinh viên theo đúng chữ ký svb.AddSinhVien(sv) trong code cô giáo
        /// </summary>
        public bool AddSinhVien(SinhVien sv)
        {
            if (sv == null) return false;

            // Đồng bộ tên lớp hoặc mã lớp
            var lop = _lopDAL.LayTheoMa(sv.MaLop) ?? _lopDAL.LayTheoTen(sv.TenLop);
            if (lop != null)
            {
                sv.MaLop = lop.MaLop;
                sv.TenLop = lop.TenLop;
            }

            return _sinhVienDAL.Them(sv);
        }

        public bool UpdateSinhVien(SinhVien sv)
        {
            if (sv == null) return false;
            var lop = _lopDAL.LayTheoMa(sv.MaLop) ?? _lopDAL.LayTheoTen(sv.TenLop);
            if (lop != null)
            {
                sv.MaLop = lop.MaLop;
                sv.TenLop = lop.TenLop;
            }
            return _sinhVienDAL.Sua(sv);
        }

        public bool DeleteSinhVien(string maSV)
        {
            return _sinhVienDAL.Xoa(maSV);
        }

        public bool ThemSinhVien(SinhVien sv, out string thongBaoLoi)
        {
            if (sv == null)
            {
                thongBaoLoi = "Dữ liệu sinh viên không được rỗng!";
                return false;
            }

            if (_sinhVienDAL.LayTheoMa(sv.MaSV) != null)
            {
                thongBaoLoi = $"Mã sinh viên '{sv.MaSV}' đã tồn tại trong hệ thống! Vui lòng chọn mã khác.";
                return false;
            }

            var lop = _lopDAL.LayTheoMa(sv.MaLop) ?? _lopDAL.LayTheoTen(sv.TenLop);
            if (lop != null)
            {
                sv.MaLop = lop.MaLop;
                sv.TenLop = lop.TenLop;
            }

            var errors = sv.IsInValid();
            if (errors.Count > 0)
            {
                thongBaoLoi = string.Join("\n", errors.Select(k => "• " + k.ErrorMessage));
                return false;
            }

            thongBaoLoi = string.Empty;
            return _sinhVienDAL.Them(sv);
        }

        public bool SuaSinhVien(SinhVien svMoi, out string thongBaoLoi)
        {
            if (svMoi == null)
            {
                thongBaoLoi = "Dữ liệu sinh viên không được rỗng!";
                return false;
            }

            if (_sinhVienDAL.LayTheoMa(svMoi.MaSV) == null)
            {
                thongBaoLoi = $"Không tìm thấy sinh viên có mã '{svMoi.MaSV}' để cập nhật!";
                return false;
            }

            var lop = _lopDAL.LayTheoMa(svMoi.MaLop) ?? _lopDAL.LayTheoTen(svMoi.TenLop);
            if (lop != null)
            {
                svMoi.MaLop = lop.MaLop;
                svMoi.TenLop = lop.TenLop;
            }

            var errors = svMoi.IsInValid();
            if (errors.Count > 0)
            {
                thongBaoLoi = string.Join("\n", errors.Select(k => "• " + k.ErrorMessage));
                return false;
            }

            thongBaoLoi = string.Empty;
            return _sinhVienDAL.Sua(svMoi);
        }

        public bool XoaSinhVien(string maSV, out string thongBaoLoi)
        {
            if (string.IsNullOrWhiteSpace(maSV))
            {
                thongBaoLoi = "Mã sinh viên không được để trống!";
                return false;
            }

            if (_sinhVienDAL.LayTheoMa(maSV) == null)
            {
                thongBaoLoi = $"Không tìm thấy sinh viên có mã '{maSV}' để xóa!";
                return false;
            }

            thongBaoLoi = string.Empty;
            return _sinhVienDAL.Xoa(maSV);
        }

        public List<SinhVien> TimKiemVaLoc(string tuKhoa, string? maHoacTenLop, double diemTu)
        {
            var query = _sinhVienDAL.LayTatCa().AsEnumerable();

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = tuKhoa.Trim().ToLowerInvariant();
                query = query.Where(s =>
                    s.MaSV.ToLowerInvariant().Contains(tuKhoa) ||
                    s.HoTen.ToLowerInvariant().Contains(tuKhoa) ||
                    s.Email.ToLowerInvariant().Contains(tuKhoa) ||
                    s.SoDienThoai.ToLowerInvariant().Contains(tuKhoa)
                );
            }

            if (!string.IsNullOrWhiteSpace(maHoacTenLop) && maHoacTenLop != "Tất cả lớp")
            {
                query = query.Where(s =>
                    s.MaLop.Equals(maHoacTenLop, StringComparison.OrdinalIgnoreCase) ||
                    s.TenLop.Equals(maHoacTenLop, StringComparison.OrdinalIgnoreCase));
            }

            if (diemTu > 0)
            {
                query = query.Where(s => s.Diem >= diemTu);
            }

            return query.OrderBy(s => s.MaSV).ToList();
        }
    }
}
