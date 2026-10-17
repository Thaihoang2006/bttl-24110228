using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Data.DAL
{
    public class LopHocDAO
    {
        protected DataHelper dataHelper = new DataHelper();
        protected List<LopHoc> lopHocs = new List<LopHoc>();

        public LopHocDAO()
        {
            // Dữ liệu mẫu dự phòng
            lopHocs.Add(new LopHoc("KTPM01", "Kỹ thuật phần mềm 01"));
            lopHocs.Add(new LopHoc("TTNT01", "Trí tuệ nhân tạo 01"));
            lopHocs.Add(new LopHoc("KHDL01", "Khoa học dữ liệu 01"));
        }

        public List<LopHoc> GetAllLopHoc()
        {
            try
            {
                List<LopHoc> list = new List<LopHoc>();
                DataTable dt = dataHelper.GetDataTable("Select * from LopHoc");
                foreach (DataRow dr in dt.Rows)
                {
                    LopHoc lop = new LopHoc();
                    lop.MaLop = dr["MaLop"]?.ToString() ?? "";
                    lop.TenLop = dr["TenLop"]?.ToString() ?? "";
                    list.Add(lop);
                }
                lopHocs = list;
                return list;
            }
            catch (Exception exx)
            {
                if (lopHocs.Count > 0)
                {
                    return lopHocs.ToList();
                }
                throw new Exception("Lỗi truy xuất CSDL LopHoc: " + exx.Message, exx);
            }
        }

        public LopHoc? GetLopHocByMa(string maLop)
        {
            try
            {
                DataTable dt = dataHelper.GetDataTable($"Select * from LopHoc where MaLop='{maLop}'");
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return new LopHoc
                    {
                        MaLop = dr["MaLop"]?.ToString() ?? "",
                        TenLop = dr["TenLop"]?.ToString() ?? ""
                    };
                }
            }
            catch
            {
            }

            return lopHocs.FirstOrDefault(l => l.MaLop.Equals(maLop, StringComparison.OrdinalIgnoreCase));
        }

        public LopHoc? GetLopHocByTen(string tenLop)
        {
            try
            {
                DataTable dt = dataHelper.GetDataTable($"Select * from LopHoc where TenLop=N'{tenLop}'");
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return new LopHoc
                    {
                        MaLop = dr["MaLop"]?.ToString() ?? "",
                        TenLop = dr["TenLop"]?.ToString() ?? ""
                    };
                }
            }
            catch
            {
            }

            return lopHocs.FirstOrDefault(l => l.TenLop.Equals(tenLop, StringComparison.OrdinalIgnoreCase));
        }

        public void AddLopHoc(LopHoc lop)
        {
            try
            {
                string sql = $"insert into LopHoc (MaLop, TenLop) values('{lop.MaLop}', N'{lop.TenLop}')";
                dataHelper.ExecuteNonQuery(sql);

                if (!lopHocs.Exists(l => l.MaLop == lop.MaLop))
                {
                    lopHocs.Add(lop);
                }
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi thêm lớp học vào CSDL: " + exx.Message, exx);
            }
        }

        public void UpdateLopHoc(LopHoc lop)
        {
            try
            {
                string sql = $"update LopHoc set TenLop=N'{lop.TenLop}' where MaLop='{lop.MaLop}'";
                dataHelper.ExecuteNonQuery(sql);

                var lopCu = lopHocs.FirstOrDefault(l => l.MaLop == lop.MaLop);
                if (lopCu != null)
                {
                    lopCu.TenLop = lop.TenLop;
                }
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi cập nhật lớp học trong CSDL: " + exx.Message, exx);
            }
        }

        public void DeleteLopHoc(string maLop)
        {
            try
            {
                string sql = $"delete from LopHoc where MaLop='{maLop}'";
                dataHelper.ExecuteNonQuery(sql);

                var lop = lopHocs.FirstOrDefault(l => l.MaLop == maLop);
                if (lop != null)
                {
                    lopHocs.Remove(lop);
                }
            }
            catch (Exception exx)
            {
                throw new Exception("Lỗi khi xóa lớp học trong CSDL: " + exx.Message, exx);
            }
        }

        // Tương thích với các phương thức cũ
        public List<LopHoc> LayTatCa() => GetAllLopHoc();
        public LopHoc? LayTheoMa(string maLop) => GetLopHocByMa(maLop);
        public LopHoc? LayTheoTen(string tenLop) => GetLopHocByTen(tenLop);
        public bool Them(LopHoc lop) { AddLopHoc(lop); return true; }
        public bool Sua(LopHoc lop) { UpdateLopHoc(lop); return true; }
        public bool Xoa(string maLop) { DeleteLopHoc(maLop); return true; }
    }
}
