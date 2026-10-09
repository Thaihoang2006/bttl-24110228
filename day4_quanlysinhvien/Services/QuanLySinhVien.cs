using System;
using System.Collections.Generic;
using System.Linq;
using day4_quanlysinhvien.Models;

namespace day4_quanlysinhvien.Services
{
    public class QuanLySinhVien
    {
        public List<LopHoc> DanhSachLop { get; set; } = new List<LopHoc>();

        public QuanLySinhVien()
        {
            KhoiTaoDuLieuBanDau();
        }

        private void KhoiTaoDuLieuBanDau()
        {
            var lopKtpm = new LopHoc("KTPM01", "Kỹ thuật phần mềm 01");
            var lopTtnt = new LopHoc("TTNT01", "Trí tuệ nhân tạo 01");
            var lopKhdl = new LopHoc("KHDL01", "Khoa học dữ liệu 01");

            lopKtpm.ThemSinhVien(new SinhVien(
                "SV000123", "Nguyễn Văn An", new DateTime(2006, 8, 15),
                "Nam", "an.nv@vju.ac.vn", "0912345678", 8.5,
                lopKtpm.MaLop, lopKtpm.TenLop, "Đang học"
            ));

            lopTtnt.ThemSinhVien(new SinhVien(
                "SV000124", "Trần Minh Anh", new DateTime(2006, 1, 22),
                "Nữ", "anh.tm@vju.ac.vn", "0987654321", 9.0,
                lopTtnt.MaLop, lopTtnt.TenLop, "Đang học"
            ));

            lopKtpm.ThemSinhVien(new SinhVien(
                "SV000125", "Lê Hoàng Bình", new DateTime(2006, 5, 9),
                "Nam", "binh.lh@vju.ac.vn", "0355556677", 7.4,
                lopKtpm.MaLop, lopKtpm.TenLop, "Đang học"
            ));

            lopKhdl.ThemSinhVien(new SinhVien(
                "SV000126", "Đỗ Thị Hồng", new DateTime(2006, 11, 30),
                "Nữ", "hong.dt@vju.ac.vn", "0777888999", 8.1,
                lopKhdl.MaLop, lopKhdl.TenLop, "Đang học"
            ));

            DanhSachLop.Add(lopKtpm);
            DanhSachLop.Add(lopTtnt);
            DanhSachLop.Add(lopKhdl);
        }

        public List<SinhVien> LayTatCaSinhVien()
        {
            return DanhSachLop.SelectMany(l => l.DanhSachSinhVien).OrderBy(s => s.MaSV).ToList();
        }

        public SinhVien? TimSinhVienTheoMa(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return null;
            return DanhSachLop.SelectMany(l => l.DanhSachSinhVien)
                .FirstOrDefault(s => s.MaSV.Equals(maSV.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public bool KiemTraTonTai(string maSV)
        {
            return TimSinhVienTheoMa(maSV) != null;
        }

        public bool ThemSinhVien(SinhVien sv)
        {
            if (sv == null || KiemTraTonTai(sv.MaSV)) return false;

            var lop = DanhSachLop.FirstOrDefault(l => l.TenLop == sv.TenLop || l.MaLop == sv.MaLop);
            if (lop == null)
            {
                lop = new LopHoc($"LOP{DanhSachLop.Count + 1}", sv.TenLop);
                DanhSachLop.Add(lop);
            }

            sv.MaLop = lop.MaLop;
            sv.TenLop = lop.TenLop;
            lop.ThemSinhVien(sv);
            return true;
        }

        public bool SuaSinhVien(SinhVien svMoi)
        {
            if (svMoi == null) return false;

            SinhVien? svHienTai = null;
            LopHoc? lopCu = null;

            foreach (var l in DanhSachLop)
            {
                var s = l.DanhSachSinhVien.FirstOrDefault(st => st.MaSV.Equals(svMoi.MaSV, StringComparison.OrdinalIgnoreCase));
                if (s != null)
                {
                    svHienTai = s;
                    lopCu = l;
                    break;
                }
            }

            if (svHienTai == null || lopCu == null) return false;

            // Cập nhật thông tin
            svHienTai.HoTen = svMoi.HoTen;
            svHienTai.NgaySinh = svMoi.NgaySinh;
            svHienTai.GioiTinh = svMoi.GioiTinh;
            svHienTai.Email = svMoi.Email;
            svHienTai.DienThoai = svMoi.DienThoai;
            svHienTai.Diem = svMoi.Diem;
            svHienTai.TrangThai = svMoi.TrangThai;

            // Nếu thay đổi lớp học
            if (lopCu.TenLop != svMoi.TenLop)
            {
                lopCu.XoaSinhVien(svHienTai.MaSV);

                var lopMoi = DanhSachLop.FirstOrDefault(l => l.TenLop == svMoi.TenLop || l.MaLop == svMoi.MaLop);
                if (lopMoi == null)
                {
                    lopMoi = new LopHoc($"LOP{DanhSachLop.Count + 1}", svMoi.TenLop);
                    DanhSachLop.Add(lopMoi);
                }

                svHienTai.MaLop = lopMoi.MaLop;
                svHienTai.TenLop = lopMoi.TenLop;
                lopMoi.ThemSinhVien(svHienTai);
            }

            return true;
        }

        public bool XoaSinhVien(string maSV)
        {
            foreach (var lop in DanhSachLop)
            {
                if (lop.XoaSinhVien(maSV))
                {
                    return true;
                }
            }
            return false;
        }

        public List<SinhVien> TimKiem(string tuKhoa, string? tenLop, double diemTu)
        {
            var query = LayTatCaSinhVien().AsEnumerable();

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
                query = query.Where(s => s.TenLop == tenLop);
            }

            if (diemTu > 0)
            {
                query = query.Where(s => s.Diem >= diemTu);
            }

            return query.ToList();
        }
    }
}
