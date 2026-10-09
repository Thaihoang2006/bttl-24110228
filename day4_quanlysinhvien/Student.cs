namespace day4_quanlysinhvien
{
    public class Student
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public double Diem { get; set; }
        public string LopHoc { get; set; }
        public string TrangThai { get; set; }

        public Student()
        {
        }

        public Student(
            string maSV,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            string email,
            string dienThoai,
            double diem,
            string lopHoc,
            string trangThai)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            Email = email;
            DienThoai = dienThoai;
            Diem = diem;
            LopHoc = lopHoc;
            TrangThai = trangThai;
        }
    }
}