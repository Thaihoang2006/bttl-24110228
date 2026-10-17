using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Data.DAL
{
    public class SinhVienDAO
    {
        protected DataHelper dataHelper = new DataHelper();
        protected List<SinhVien> sinhViens = new List<SinhVien>();

        public SinhVienDAO()
        {
            // Nạp dữ liệu mẫu vào danh sách bộ nhớ làm dự phòng
            sinhViens.Add(new SinhVien(
                "SV000123", "Nguyễn Văn An", new DateTime(2006, 8, 15),
                "Nam", "an.nv@vju.ac.vn", "0912345678", 8.5,
                "KTPM01", "Kỹ thuật phần mềm 01", "Đang học"
            ));

            sinhViens.Add(new SinhVien(
                "SV000124", "Trần Minh Anh", new DateTime(2006, 1, 22),
                "Nữ", "anh.tm@vju.ac.vn", "0987654321", 9.0,
                "TTNT01", "Trí tuệ nhân tạo 01", "Đang học"
            ));

            sinhViens.Add(new SinhVien(
                "SV000125", "Lê Hoàng Bình", new DateTime(2006, 5, 9),
                "Nam", "binh.lh@vju.ac.vn", "0355556677", 7.4,
                "KTPM01", "Kỹ thuật phần mềm 01", "Đang học"
            ));

            sinhViens.Add(new SinhVien(
                "SV000126", "Đỗ Thị Hồng", new DateTime(2006, 11, 30),
                "Nữ", "hong.dt@vju.ac.vn", "0777888999", 8.1,
                "KHDL01", "Khoa học dữ liệu 01", "Đang học"
            ));
        }

        public List<SinhVien> getAllSinhVien1()
        {
            try
            {
                List<SinhVien> lv = new List<SinhVien>();
                SqlDataReader dr = dataHelper.ExcuteReader("Select * from SinhVien");
                while (dr.Read())
                {
                    SinhVien sv = new SinhVien();
                    sv.MaSV = dr["MaSV"]?.ToString() ?? "";
                    sv.HoTen = dr["HoTen"]?.ToString() ?? "";
                    sv.GioiTinh = dr["gioitinh"]?.ToString() ?? "Nam";
                    if (DateTime.TryParse(dr["NgaySinh"]?.ToString(), out DateTime ns))
                    {
                        sv.NgaySinh = ns;
                    }
                    sv.SoDienThoai = dr["SoDienThoai"]?.ToString() ?? "";
                    sv.MaLop = dr["MaLop"]?.ToString() ?? "";
                    if (dr["Diem"] != DBNull.Value && double.TryParse(dr["Diem"]?.ToString(), out double d))
                    {
                        sv.Diem = d;
                    }
                    sv.Email = dr["email"]?.ToString() ?? "";
                    lv.Add(sv);
                }
                dataHelper.CloseConnection();
                return lv;
            }
            catch (Exception exx)
            {
                dataHelper.CloseConnection();
                throw new Exception("Lỗi truy xuất dữ liệu SinhVien: " + exx.Message, exx);
            }
        }

        public List<SinhVien> GetAllSinhVien()
        {
            try
            {
                List<SinhVien> list = new List<SinhVien>();
                DataTable dt = dataHelper.GetDataTable("Select * from SinhVien");
                foreach (DataRow dr in dt.Rows)
                {
                    SinhVien sv = new SinhVien();
                    sv.MaSV = dr["MaSV"]?.ToString() ?? "";
                    sv.HoTen = dr["HoTen"]?.ToString() ?? "";
                    sv.GioiTinh = dr["gioitinh"]?.ToString() ?? "Nam";
                    if (DateTime.TryParse(dr["NgaySinh"]?.ToString(), out DateTime ns))
                    {
                        sv.NgaySinh = ns;
                    }
                    sv.SoDienThoai = dr["SoDienThoai"]?.ToString() ?? "";
                    sv.MaLop = dr["MaLop"]?.ToString() ?? "";
                    if (dr["Diem"] != DBNull.Value && double.TryParse(dr["Diem"]?.ToString(), out double d))
                    {
                        sv.Diem = d;
                    }
                    sv.Email = dr["email"]?.ToString() ?? "";
                    list.Add(sv);
                }
                sinhViens = list;
                return list;
            }
            catch (Exception exx)
            {
                if (sinhViens.Count > 0)
                {
                    return sinhViens.ToList();
                }
                throw new Exception("Lỗi truy xuất CSDL SinhVien: " + exx.Message, exx);
            }
        }

        public List<SinhVien> GetAllSinhVien1()
        {
            return getAllSinhVien1();
        }

        public List<SinhVien> GetSinhViensByMaLop(string maLop)
        {
            try
            {
                List<SinhVien> lv = new List<SinhVien>();
                DataTable dt = dataHelper.GetDataTable($"Select * from SinhVien where Malop='{maLop}'");
                foreach (DataRow r in dt.Rows)
                {
                    SinhVien sv = new SinhVien();
                    sv.MaSV = r["MaSV"]?.ToString() ?? "";
                    sv.HoTen = r["HoTen"]?.ToString() ?? "";
                    sv.GioiTinh = r["gioitinh"]?.ToString() ?? "Nam";
                    if (DateTime.TryParse(r["NgaySinh"]?.ToString(), out DateTime ns))
                    {
                        sv.NgaySinh = ns;
                    }
                    sv.SoDienThoai = r["SoDienThoai"]?.ToString() ?? "";
                    sv.MaLop = r["MaLop"]?.ToString() ?? "";
                    if (r["Diem"] != DBNull.Value && double.TryParse(r["Diem"]?.ToString(), out double d))
                    {
                        sv.Diem = d;
                    }
                    sv.Email = r["email"]?.ToString() ?? "";
                    lv.Add(sv);
                }
                return lv;
            }
            catch (Exception)
            {
                // Fallback theo bộ nhớ nếu không kết nối được CSDL
                return sinhViens.Where(s => s.MaLop.Equals(maLop, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public void AddSinhVien(SinhVien sv)
        {
            try
            {
                string ngaySinhStr = sv.NgaySinh.ToString("yyyy-MM-dd");
                string sql = $"insert into SinhVien (MaSV, Malop, Hoten, GioiTinh, NgaySinh, Diem, SoDienThoai, Email) " +
                             $"values('{sv.MaSV}', '{sv.MaLop}', N'{sv.HoTen}', N'{sv.GioiTinh}', '{ngaySinhStr}', " +
                             $"{sv.Diem.ToString(System.Globalization.CultureInfo.InvariantCulture)}, '{sv.SoDienThoai}', '{sv.Email}')";
                dataHelper.ExecuteNonQuery(sql);

                // Cập nhật bộ nhớ
                if (!sinhViens.Exists(s => s.MaSV == sv.MaSV))
                {
                    sinhViens.Add(sv);
                }
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi thêm sinh viên vào CSDL: " + exx.Message, exx);
            }
        }

        public void UpdateSinhVien(SinhVien sv)
        {
            try
            {
                string ngaySinhStr = sv.NgaySinh.ToString("yyyy-MM-dd");
                string sql = $"Update SinhVien set Hoten=N'{sv.HoTen}', MaLop='{sv.MaLop}', " +
                             $"GioiTinh=N'{sv.GioiTinh}', NgaySinh='{ngaySinhStr}', " +
                             $"Diem={sv.Diem.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                             $"SoDienThoai='{sv.SoDienThoai}', Email='{sv.Email}' " +
                             $"where MaSV='{sv.MaSV}'";
                dataHelper.ExecuteNonQuery(sql);

                // Cập nhật bộ nhớ
                var svCu = sinhViens.FirstOrDefault(s => s.MaSV == sv.MaSV);
                if (svCu != null)
                {
                    svCu.HoTen = sv.HoTen;
                    svCu.NgaySinh = sv.NgaySinh;
                    svCu.GioiTinh = sv.GioiTinh;
                    svCu.Email = sv.Email;
                    svCu.SoDienThoai = sv.SoDienThoai;
                    svCu.Diem = sv.Diem;
                    svCu.MaLop = sv.MaLop;
                }
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi cập nhật sinh viên trong CSDL: " + exx.Message, exx);
            }
        }

        public void DeleteSinhVien(string maSV)
        {
            try
            {
                string sql = $"delete from SinhVien where MaSV='{maSV}'";
                dataHelper.ExecuteNonQuery(sql);

                SinhVien? sv = sinhViens.FirstOrDefault(s => s.MaSV == maSV);
                if (sv != null)
                {
                    sinhViens.Remove(sv);
                }
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi xóa sinh viên trong CSDL: " + exx.Message, exx);
            }
        }

        public SinhVien? GetSinhVienByMaSV(string maSV)
        {
            try
            {
                DataTable dt = dataHelper.GetDataTable($"Select * from SinhVien where MaSV='{maSV}'");
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    SinhVien sv = new SinhVien();
                    sv.MaSV = dr["MaSV"]?.ToString() ?? "";
                    sv.HoTen = dr["HoTen"]?.ToString() ?? "";
                    sv.GioiTinh = dr["gioitinh"]?.ToString() ?? "Nam";
                    if (DateTime.TryParse(dr["NgaySinh"]?.ToString(), out DateTime ns))
                    {
                        sv.NgaySinh = ns;
                    }
                    sv.SoDienThoai = dr["SoDienThoai"]?.ToString() ?? "";
                    sv.MaLop = dr["MaLop"]?.ToString() ?? "";
                    if (dr["Diem"] != DBNull.Value && double.TryParse(dr["Diem"]?.ToString(), out double d))
                    {
                        sv.Diem = d;
                    }
                    sv.Email = dr["email"]?.ToString() ?? "";
                    return sv;
                }
            }
            catch
            {
            }

            return sinhViens.FirstOrDefault(s => s.MaSV == maSV);
        }

        public SinhVien? GetSinhVienById(string maSV)
        {
            return GetSinhVienByMaSV(maSV);
        }

        // Các phương thức tương thích với chữ ký cũ
        public List<SinhVien> LayTatCa() => GetAllSinhVien();
        public SinhVien? LayTheoMa(string maSV) => GetSinhVienByMaSV(maSV);
        public List<SinhVien> LayTheoLop(string maLop) => GetSinhViensByMaLop(maLop);
        public bool Them(SinhVien sv) { AddSinhVien(sv); return true; }
        public bool Sua(SinhVien sv) { UpdateSinhVien(sv); return true; }
        public bool Xoa(string maSV) { DeleteSinhVien(maSV); return true; }
    }
}
