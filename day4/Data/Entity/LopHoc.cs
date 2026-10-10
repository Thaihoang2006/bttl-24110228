using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLySinhVien.Data.Entity
{
    public class LopHoc
    {
        [Required(ErrorMessage = "Mã lớp không được để trống!")]
        [StringLength(20, ErrorMessage = "Mã lớp tối đa 20 ký tự!")]
        public string MaLop { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên lớp không được để trống!")]
        [StringLength(100, ErrorMessage = "Tên lớp tối đa 100 ký tự!")]
        public string TenLop { get; set; } = string.Empty;

        // Quan hệ 1 - n: Một lớp học có nhiều sinh viên
        public List<SinhVien> DanhSachSinhVien { get; set; } = new List<SinhVien>();

        public LopHoc()
        {
        }

        public LopHoc(string maLop, string tenLop)
        {
            MaLop = maLop;
            TenLop = tenLop;
        }

        public void ThemSinhVien(SinhVien sv)
        {
            if (sv != null && !DanhSachSinhVien.Exists(s => s.MaSV.Equals(sv.MaSV, StringComparison.OrdinalIgnoreCase)))
            {
                sv.MaLop = this.MaLop;
                sv.TenLop = this.TenLop;
                DanhSachSinhVien.Add(sv);
            }
        }

        public bool XoaSinhVien(string maSV)
        {
            var sv = DanhSachSinhVien.Find(s => s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase));
            if (sv != null)
            {
                return DanhSachSinhVien.Remove(sv);
            }
            return false;
        }

        // Phương thức kiểm tra các thuộc tính có hợp lệ hay không dùng Data Annotation
        public bool KiemTraHopLe(out List<ValidationResult> ketQua)
        {
            var context = new ValidationContext(this);
            ketQua = new List<ValidationResult>();
            return Validator.TryValidateObject(this, context, ketQua, validateAllProperties: true);
        }

        public override string ToString()
        {
            return TenLop;
        }
    }
}
