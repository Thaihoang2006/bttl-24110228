using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace QuanLySinhVien.Data.Entity
{
    public class SinhVien
    {
        [Required(ErrorMessage = "Mã sinh viên không được để trống!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Mã sinh viên phải từ 3 đến 20 ký tự!")]
        public string MaSV { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ và tên không được để trống!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ và tên phải từ 2 đến 100 ký tự!")]
        public string HoTen { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ngày sinh không được để trống!")]
        public DateTime NgaySinh { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Giới tính không được để trống!")]
        public string GioiTinh { get; set; } = "Nam";

        [Required(ErrorMessage = "Email không được để trống!")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ (ví dụ: an.nv@vju.ac.vn)!")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!")]
        public string DienThoai { get; set; } = string.Empty;

        [Required(ErrorMessage = "Điểm không được để trống!")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0!")]
        public double Diem { get; set; } = 0.0;

        [Required(ErrorMessage = "Lớp học không được để trống!")]
        public string MaLop { get; set; } = string.Empty;

        public string TenLop { get; set; } = string.Empty;

        public string TrangThai { get; set; } = "Đang học";

        public SinhVien()
        {
        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh,
                        string email, string dienThoai, double diem, string maLop,
                        string tenLop, string trangThai)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Email = email;
            DienThoai = dienThoai;
            Diem = diem;
            MaLop = maLop;
            TenLop = tenLop;
            TrangThai = trangThai;
        }

        // Phương thức kiểm tra xem các thuộc tính của đối tượng có hợp lệ hay không dùng Data Annotation
        public bool KiemTraHopLe(out List<ValidationResult> ketQua)
        {
            var context = new ValidationContext(this);
            ketQua = new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, ketQua, validateAllProperties: true);
        }

        // Phương thức tiện ích trả về chuỗi thông báo lỗi tổng hợp
        public bool KiemTraHopLe(out string thongBaoLoi)
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, validateAllProperties: true);
            if (!isValid)
            {
                thongBaoLoi = string.Join("\n", results.Select(r => "• " + r.ErrorMessage));
                return false;
            }
            thongBaoLoi = string.Empty;
            return true;
        }
    }
}
