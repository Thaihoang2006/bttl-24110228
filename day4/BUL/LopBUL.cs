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
    /// </summary>
    public class LopBUL
    {
        private readonly LopDAL _lopDAL = new LopDAL();

        public List<LopHoc> LayDanhSachLop()
        {
            return _lopDAL.LayTatCa();
        }

        public LopHoc? LayTheoMa(string maLop)
        {
            return _lopDAL.LayTheoMa(maLop);
        }

        public LopHoc? LayTheoTen(string tenLop)
        {
            return _lopDAL.LayTheoTen(tenLop);
        }

        public bool ThemLop(LopHoc lop, out string thongBaoLoi)
        {
            if (lop == null)
            {
                thongBaoLoi = "Dữ liệu lớp học không được rỗng!";
                return false;
            }

            // Kiểm tra Data Annotation
            if (!lop.KiemTraHopLe(out List<ValidationResult> ketQua))
            {
                thongBaoLoi = string.Join("\n", ketQua.Select(k => "• " + k.ErrorMessage));
                return false;
            }

            // Kiểm tra nghiệp vụ: trùng mã lớp
            if (_lopDAL.LayTheoMa(lop.MaLop) != null)
            {
                thongBaoLoi = $"Mã lớp '{lop.MaLop}' đã tồn tại trong hệ thống!";
                return false;
            }

            thongBaoLoi = string.Empty;
            return _lopDAL.Them(lop);
        }
    }
}
