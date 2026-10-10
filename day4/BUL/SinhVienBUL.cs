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

        public SinhVien? TimSinhVienTheoMa(string maSV)
        {
            return _sinhVienDAL.LayTheoMa(maSV);
        }

        public bool KiemTraTonTai(string maSV)
        {
            return _sinhVienDAL.LayTheoMa(maSV) != null;
        }

        /// <summary>
        /// Nghiệp vụ Thêm sinh viên:
        /// - Kiểm tra tính hợp lệ của thuộc tính bằng Data Annotation
        /// - Kiểm tra nghiệp vụ: trùng mã sinh viên
        /// - Đồng bộ mã lớp từ tên lớp
        /// </summary>
        public bool ThemSinhVien(SinhVien sv, out string thongBaoLoi)
        {
            if (sv == null)
            {
                thongBaoLoi = "Dữ liệu sinh viên không được rỗng!";
                return false;
            }

            // 1. Kiểm tra nghiệp vụ: Mã sinh viên đã tồn tại
            if (_sinhVienDAL.LayTheoMa(sv.MaSV) != null)
            {
                thongBaoLoi = $"Mã sinh viên '{sv.MaSV}' đã tồn tại trong hệ thống! Vui lòng chọn mã khác.";
                return false;
            }

            // 2. Tự động đồng bộ mã lớp nếu có
            var lop = _lopDAL.LayTheoTen(sv.TenLop);
            if (lop != null)
            {
                sv.MaLop = lop.MaLop;
            }

            // 3. Kiểm tra tính hợp lệ của thuộc tính bằng Data Annotation
            if (!sv.KiemTraHopLe(out List<ValidationResult> ketQua))
            {
                thongBaoLoi = string.Join("\n", ketQua.Select(k => "• " + k.ErrorMessage));
                return false;
            }

            thongBaoLoi = string.Empty;
            return _sinhVienDAL.Them(sv);
        }

        /// <summary>
        /// Nghiệp vụ Sửa thông tin sinh viên:
        /// - Kiểm tra sinh viên có tồn tại trong hệ thống
        /// - Kiểm tra tính hợp lệ của thuộc tính bằng Data Annotation
        /// </summary>
        public bool SuaSinhVien(SinhVien svMoi, out string thongBaoLoi)
        {
            if (svMoi == null)
            {
                thongBaoLoi = "Dữ liệu sinh viên không được rỗng!";
                return false;
            }

            // 1. Kiểm tra nghiệp vụ: Sinh viên phải tồn tại
            if (_sinhVienDAL.LayTheoMa(svMoi.MaSV) == null)
            {
                thongBaoLoi = $"Không tìm thấy sinh viên có mã '{svMoi.MaSV}' để cập nhật!";
                return false;
            }

            // 2. Đồng bộ mã lớp
            var lop = _lopDAL.LayTheoTen(svMoi.TenLop);
            if (lop != null)
            {
                svMoi.MaLop = lop.MaLop;
            }

            // 3. Kiểm tra tính hợp lệ bằng Data Annotation
            if (!svMoi.KiemTraHopLe(out List<ValidationResult> ketQua))
            {
                thongBaoLoi = string.Join("\n", ketQua.Select(k => "• " + k.ErrorMessage));
                return false;
            }

            thongBaoLoi = string.Empty;
            return _sinhVienDAL.Sua(svMoi);
        }

        /// <summary>
        /// Nghiệp vụ Xóa sinh viên:
        /// - Kiểm tra sinh viên có tồn tại trong hệ thống trước khi xóa
        /// </summary>
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

        /// <summary>
        /// Nghiệp vụ Tìm kiếm và Lọc sinh viên theo từ khóa, lớp, điểm sàn
        /// </summary>
        public List<SinhVien> TimKiemVaLoc(string tuKhoa, string? tenLop, double diemTu)
        {
            var query = _sinhVienDAL.LayTatCa().AsEnumerable();

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                tuKhoa = tuKhoa.Trim().ToLowerInvariant();
                query = query.Where(s =>
                    s.MaSV.ToLowerInvariant().Contains(tuKhoa) ||
                    s.HoTen.ToLowerInvariant().Contains(tuKhoa) ||
                    s.Email.ToLowerInvariant().Contains(tuKhoa) ||
                    s.DienThoai.ToLowerInvariant().Contains(tuKhoa)
                );
            }

            if (!string.IsNullOrWhiteSpace(tenLop) && tenLop != "Tất cả lớp")
            {
                query = query.Where(s => s.TenLop.Equals(tenLop, StringComparison.OrdinalIgnoreCase));
            }

            if (diemTu > 0)
            {
                query = query.Where(s => s.Diem >= diemTu);
            }

            return query.OrderBy(s => s.MaSV).ToList();
        }
    }
}
