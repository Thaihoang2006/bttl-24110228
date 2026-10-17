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
    /// Yêu cầu: Ném về ngoại lệ (Exception) khi có lỗi để tầng View xử lý.
    /// </summary>
    public class SinhVienBUL
    {
        private readonly SinhVienDAO _sinhVienDAO = new SinhVienDAO();
        private readonly LopHocDAO _lopHocDAO = new LopHocDAO();

        public List<SinhVien> LayDanhSachSinhVien()
        {
            try
            {
                return _sinhVienDAO.GetAllSinhVien();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tải danh sách sinh viên: " + ex.Message, ex);
            }
        }

        public List<SinhVien> LaySinhVienTheoLop(string maHoacTenLop)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maHoacTenLop) || maHoacTenLop == "Tất cả lớp" || maHoacTenLop == "ALL")
                {
                    return LayDanhSachSinhVien();
                }
                return _sinhVienDAO.GetSinhViensByMaLop(maHoacTenLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tải sinh viên theo lớp: " + ex.Message, ex);
            }
        }

        public SinhVien? TimSinhVienTheoMa(string maSV)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maSV)) return null;
                return _sinhVienDAO.GetSinhVienByMaSV(maSV);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tìm sinh viên: " + ex.Message, ex);
            }
        }

        public bool KiemTraTonTai(string maSV)
        {
            try
            {
                return _sinhVienDAO.GetSinhVienByMaSV(maSV) != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Phương thức thêm sinh viên:
        /// Kiểm tra tính hợp lệ, ném ngoại lệ nếu vi phạm để tầng View bắt và xử lý.
        /// </summary>
        public void AddSinhVien(SinhVien sv)
        {
            if (sv == null)
            {
                throw new ArgumentNullException(nameof(sv), "Dữ liệu sinh viên không được rỗng!");
            }

            var errors = sv.IsInValid();
            if (errors.Count > 0)
            {
                throw new ValidationException(string.Join("\n", errors.Select(e => "• " + e.ErrorMessage)));
            }

            if (KiemTraTonTai(sv.MaSV))
            {
                throw new InvalidOperationException($"Mã sinh viên '{sv.MaSV}' đã tồn tại trong hệ thống! Vui lòng chọn mã khác.");
            }

            // Đồng bộ thông tin lớp học
            var lop = _lopHocDAO.GetLopHocByMa(sv.MaLop) ?? _lopHocDAO.GetLopHocByTen(sv.TenLop);
            if (lop != null)
            {
                sv.MaLop = lop.MaLop;
                sv.TenLop = lop.TenLop;
            }

            _sinhVienDAO.AddSinhVien(sv);
        }

        /// <summary>
        /// Phương thức cập nhật sinh viên:
        /// Ném ngoại lệ nếu dữ liệu không hợp lệ hoặc sinh viên không tồn tại.
        /// </summary>
        public void UpdateSinhVien(SinhVien sv)
        {
            if (sv == null)
            {
                throw new ArgumentNullException(nameof(sv), "Dữ liệu sinh viên không được rỗng!");
            }

            var errors = sv.IsInValid();
            if (errors.Count > 0)
            {
                throw new ValidationException(string.Join("\n", errors.Select(e => "• " + e.ErrorMessage)));
            }

            if (!KiemTraTonTai(sv.MaSV))
            {
                throw new KeyNotFoundException($"Không tìm thấy sinh viên có mã '{sv.MaSV}' để cập nhật!");
            }

            var lop = _lopHocDAO.GetLopHocByMa(sv.MaLop) ?? _lopHocDAO.GetLopHocByTen(sv.TenLop);
            if (lop != null)
            {
                sv.MaLop = lop.MaLop;
                sv.TenLop = lop.TenLop;
            }

            _sinhVienDAO.UpdateSinhVien(sv);
        }

        /// <summary>
        /// Phương thức xóa sinh viên:
        /// Ném ngoại lệ nếu mã trống hoặc thao tác CSDL gặp sự cố.
        /// </summary>
        public void DeleteSinhVien(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
            {
                throw new ArgumentException("Mã sinh viên không được để trống!", nameof(maSV));
            }

            if (!KiemTraTonTai(maSV))
            {
                throw new KeyNotFoundException($"Không tìm thấy sinh viên có mã '{maSV}' để xóa!");
            }

            _sinhVienDAO.DeleteSinhVien(maSV);
        }

        // Tương thích với các phương thức kiểu bool cũ
        public bool ThemSinhVien(SinhVien sv, out string thongBaoLoi)
        {
            try
            {
                AddSinhVien(sv);
                thongBaoLoi = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                thongBaoLoi = ex.Message;
                return false;
            }
        }

        public bool SuaSinhVien(SinhVien svMoi, out string thongBaoLoi)
        {
            try
            {
                UpdateSinhVien(svMoi);
                thongBaoLoi = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                thongBaoLoi = ex.Message;
                return false;
            }
        }

        public bool XoaSinhVien(string maSV, out string thongBaoLoi)
        {
            try
            {
                DeleteSinhVien(maSV);
                thongBaoLoi = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                thongBaoLoi = ex.Message;
                return false;
            }
        }

        public List<SinhVien> TimKiemVaLoc(string tuKhoa, string? maHoacTenLop, double diemTu)
        {
            var query = LayDanhSachSinhVien().AsEnumerable();

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

            if (!string.IsNullOrWhiteSpace(maHoacTenLop) && maHoacTenLop != "Tất cả lớp" && maHoacTenLop != "ALL")
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
