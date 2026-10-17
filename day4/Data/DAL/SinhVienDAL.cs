using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Data.DAL
{
    /// <summary>
    /// Tầng Data Access Layer (DAL) cho thực thể Sinh viên:
    /// Áp dụng DataHelper và ADO.NET (Slide 17, 18, 19).
    /// </summary>
    public class SinhVienDAL
    {
        // Khai báo đối tượng DataHelper tĩnh theo đúng Slide 19
        public static DataHelper dh;

        // Nguồn dữ liệu bộ nhớ dự phòng (đảm bảo ứng dụng chạy mượt mà khi CSDL chưa khởi tạo)
        private static readonly List<SinhVien> _danhSachSinhVienMemory = new List<SinhVien>();

        static SinhVienDAL()
        {
            // B2 (Slide 18): Đọc chuỗi kết nối từ tệp App.config
            string strcon = "";
            try
            {
                strcon = ConfigurationManager.ConnectionStrings["studentDataBase"]?.ConnectionString ?? "";
            }
            catch
            {
            }

            if (string.IsNullOrEmpty(strcon))
            {
                strcon = "Data Source=.;Initial Catalog=StudentManagementDB;Integrated Security=True;TrustServerCertificate=True";
            }

            dh = new DataHelper(strcon);

            // Nạp dữ liệu mẫu ban đầu trong bộ nhớ
            _danhSachSinhVienMemory.Add(new SinhVien(
                "SV000123", "Nguyễn Văn An", new DateTime(2006, 8, 15),
                "Nam", "an.nv@vju.ac.vn", "0912345678", 8.5,
                "KTPM01", "Kỹ thuật phần mềm 01", "Đang học"
            ));

            _danhSachSinhVienMemory.Add(new SinhVien(
                "SV000124", "Trần Minh Anh", new DateTime(2006, 1, 22),
                "Nữ", "anh.tm@vju.ac.vn", "0987654321", 9.0,
                "TTNT01", "Trí tuệ nhân tạo 01", "Đang học"
            ));

            _danhSachSinhVienMemory.Add(new SinhVien(
                "SV000125", "Lê Hoàng Bình", new DateTime(2006, 5, 9),
                "Nam", "binh.lh@vju.ac.vn", "0355556677", 7.4,
                "KTPM01", "Kỹ thuật phần mềm 01", "Đang học"
            ));

            _danhSachSinhVienMemory.Add(new SinhVien(
                "SV000126", "Đỗ Thị Hồng", new DateTime(2006, 11, 30),
                "Nữ", "hong.dt@vju.ac.vn", "0777888999", 8.1,
                "KHDL01", "Khoa học dữ liệu 01", "Đang học"
            ));
        }

        public SinhVienDAL()
        {
        }

        public SinhVienDAL(string stcon)
        {
            dh = new DataHelper(stcon);
        }

        // Lấy về toàn bộ danh sách sinh viên
        public List<SinhVien> LayTatCa()
        {
            try
            {
                string sql = "SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.Email, sv.SoDienThoai, sv.Diem, sv.MaLop, ISNULL(l.TenLop, sv.TenLop) AS TenLop, sv.TrangThai FROM SinhVien sv LEFT JOIN LopHoc l ON sv.MaLop = l.MaLop";
                SqlDataReader? dr = dh.ExcuteReader(sql);
                if (dr != null)
                {
                    var list = new List<SinhVien>();
                    while (dr.Read())
                    {
                        var sv = DocSinhVienTuDataReader(dr);
                        list.Add(sv);
                    }
                    dh.DongKetNoi();
                    if (list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            catch
            {
                dh.DongKetNoi();
            }

            return _danhSachSinhVienMemory.ToList();
        }

        // Lấy về sinh viên theo mã sinh viên
        public SinhVien? LayTheoMa(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return null;

            try
            {
                string sql = $"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.Email, sv.SoDienThoai, sv.Diem, sv.MaLop, ISNULL(l.TenLop, sv.TenLop) AS TenLop, sv.TrangThai FROM SinhVien sv LEFT JOIN LopHoc l ON sv.MaLop = l.MaLop WHERE sv.MaSV = '{maSV.Trim()}'";
                SqlDataReader? dr = dh.ExcuteReader(sql);
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        var sv = DocSinhVienTuDataReader(dr);
                        dh.DongKetNoi();
                        return sv;
                    }
                    dh.DongKetNoi();
                }
            }
            catch
            {
                dh.DongKetNoi();
            }

            return _danhSachSinhVienMemory.FirstOrDefault(s => s.MaSV.Equals(maSV.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        // Lấy về danh sách sinh viên theo mã lớp hoặc tên lớp
        public List<SinhVien> LayTheoLop(string maHoacTenLop)
        {
            if (string.IsNullOrWhiteSpace(maHoacTenLop) || maHoacTenLop == "Tất cả lớp" || maHoacTenLop == "ALL")
            {
                return LayTatCa();
            }

            try
            {
                string sql = $"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.Email, sv.SoDienThoai, sv.Diem, sv.MaLop, ISNULL(l.TenLop, sv.TenLop) AS TenLop, sv.TrangThai FROM SinhVien sv LEFT JOIN LopHoc l ON sv.MaLop = l.MaLop WHERE sv.MaLop = '{maHoacTenLop.Trim()}' OR l.TenLop = N'{maHoacTenLop.Trim()}'";
                SqlDataReader? dr = dh.ExcuteReader(sql);
                if (dr != null)
                {
                    var list = new List<SinhVien>();
                    while (dr.Read())
                    {
                        var sv = DocSinhVienTuDataReader(dr);
                        list.Add(sv);
                    }
                    dh.DongKetNoi();
                    if (list.Count > 0)
                    {
                        return list;
                    }
                }
            }
            catch
            {
                dh.DongKetNoi();
            }

            return _danhSachSinhVienMemory
                .Where(s => s.MaLop.Equals(maHoacTenLop.Trim(), StringComparison.OrdinalIgnoreCase) ||
                            s.TenLop.Equals(maHoacTenLop.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Thêm sinh viên vào nguồn dữ liệu
        public bool Them(SinhVien sv)
        {
            if (sv == null) return false;

            try
            {
                string diemStr = sv.Diem.ToString(CultureInfo.InvariantCulture);
                string ngaySinhStr = sv.NgaySinh.ToString("yyyy-MM-dd");
                string sql = $"INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, Email, SoDienThoai, Diem, MaLop, TenLop, TrangThai) VALUES ('{sv.MaSV}', N'{sv.HoTen}', '{ngaySinhStr}', N'{sv.GioiTinh}', '{sv.Email}', '{sv.SoDienThoai}', {diemStr}, '{sv.MaLop}', N'{sv.TenLop}', N'{sv.TrangThai}')";
                dh.ExcuteNonQuery(sql);
            }
            catch
            {
            }

            if (!_danhSachSinhVienMemory.Exists(s => s.MaSV.Equals(sv.MaSV, StringComparison.OrdinalIgnoreCase)))
            {
                _danhSachSinhVienMemory.Add(sv);
            }
            return true;
        }

        // Sửa thông tin sinh viên trong nguồn dữ liệu
        public bool Sua(SinhVien svMoi)
        {
            if (svMoi == null) return false;

            try
            {
                string diemStr = svMoi.Diem.ToString(CultureInfo.InvariantCulture);
                string ngaySinhStr = svMoi.NgaySinh.ToString("yyyy-MM-dd");
                string sql = $"UPDATE SinhVien SET HoTen = N'{svMoi.HoTen}', NgaySinh = '{ngaySinhStr}', GioiTinh = N'{svMoi.GioiTinh}', Email = '{svMoi.Email}', SoDienThoai = '{svMoi.SoDienThoai}', Diem = {diemStr}, MaLop = '{svMoi.MaLop}', TenLop = N'{svMoi.TenLop}', TrangThai = N'{svMoi.TrangThai}' WHERE MaSV = '{svMoi.MaSV}'";
                dh.ExcuteNonQuery(sql);
            }
            catch
            {
            }

            var svCu = _danhSachSinhVienMemory.FirstOrDefault(s => s.MaSV.Equals(svMoi.MaSV, StringComparison.OrdinalIgnoreCase));
            if (svCu != null)
            {
                svCu.HoTen = svMoi.HoTen;
                svCu.NgaySinh = svMoi.NgaySinh;
                svCu.GioiTinh = svMoi.GioiTinh;
                svCu.Email = svMoi.Email;
                svCu.DienThoai = svMoi.DienThoai;
                svCu.Diem = svMoi.Diem;
                svCu.MaLop = svMoi.MaLop;
                svCu.TenLop = svMoi.TenLop;
                svCu.TrangThai = svMoi.TrangThai;
            }
            return true;
        }

        // Xóa sinh viên khỏi nguồn dữ liệu
        public bool Xoa(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV)) return false;

            try
            {
                string sql = $"DELETE FROM SinhVien WHERE MaSV = '{maSV.Trim()}'";
                dh.ExcuteNonQuery(sql);
            }
            catch
            {
            }

            var sv = _danhSachSinhVienMemory.FirstOrDefault(s => s.MaSV.Equals(maSV.Trim(), StringComparison.OrdinalIgnoreCase));
            if (sv != null)
            {
                _danhSachSinhVienMemory.Remove(sv);
            }
            return true;
        }

        // Hàm trợ giúp đọc đối tượng SinhVien từ SqlDataReader (Slide 19)
        private static SinhVien DocSinhVienTuDataReader(SqlDataReader dr)
        {
            var sv = new SinhVien();
            sv.MaSV = dr["MaSV"]?.ToString() ?? "";
            sv.HoTen = dr["HoTen"]?.ToString() ?? "";
            if (dr["NgaySinh"] != DBNull.Value)
            {
                sv.NgaySinh = Convert.ToDateTime(dr["NgaySinh"]);
            }
            sv.GioiTinh = dr["GioiTinh"]?.ToString() ?? "Nam";
            sv.Email = dr["Email"]?.ToString() ?? "";
            sv.SoDienThoai = dr["SoDienThoai"]?.ToString() ?? "";
            if (dr["Diem"] != DBNull.Value)
            {
                sv.Diem = Convert.ToDouble(dr["Diem"]);
            }
            sv.MaLop = dr["MaLop"]?.ToString() ?? "";
            sv.TenLop = dr["TenLop"]?.ToString() ?? "";
            sv.TrangThai = dr["TrangThai"]?.ToString() ?? "Đang học";
            return sv;
        }
    }
}
