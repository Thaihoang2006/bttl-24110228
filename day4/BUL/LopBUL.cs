using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QuanLySinhVien.Data.DAL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.BUL
{
    /// <summary>
    /// Tầng Business (BUL) cho Lớp học:
    /// Xử lý các quy tắc nghiệp vụ, kiểm tra tính hợp lệ trước khi gọi xuống tầng DAL.
    /// Yêu cầu: Ném ngoại lệ khi có lỗi để tầng View xử lý.
    /// </summary>
    public class LopBUL
    {
        private readonly LopHocDAO _lopHocDAO = new LopHocDAO();

        public List<LopHoc> LayDanhSachLop()
        {
            try
            {
                return _lopHocDAO.GetAllLopHoc();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tải danh sách lớp học: " + ex.Message, ex);
            }
        }

        public LopHoc? LayTheoMa(string maLop)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maLop)) return null;
                return _lopHocDAO.GetLopHocByMa(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tìm lớp học: " + ex.Message, ex);
            }
        }

        public LopHoc? LayTheoTen(string tenLop)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tenLop)) return null;
                return _lopHocDAO.GetLopHocByTen(tenLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nghiệp vụ khi tìm tên lớp học: " + ex.Message, ex);
            }
        }

        public void ThemLop(LopHoc lop)
        {
            if (lop == null)
            {
                throw new ArgumentNullException(nameof(lop), "Dữ liệu lớp học không được rỗng!");
            }

            if (!lop.KiemTraHopLe(out List<ValidationResult> ketQua))
            {
                throw new ValidationException(string.Join("\n", ketQua.Select(k => "• " + k.ErrorMessage)));
            }

            if (LayTheoMa(lop.MaLop) != null)
            {
                throw new InvalidOperationException($"Mã lớp '{lop.MaLop}' đã tồn tại trong hệ thống!");
            }

            _lopHocDAO.AddLopHoc(lop);
        }

        public bool ThemLop(LopHoc lop, out string thongBaoLoi)
        {
            try
            {
                ThemLop(lop);
                thongBaoLoi = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                thongBaoLoi = ex.Message;
                return false;
            }
        }
    }
}
