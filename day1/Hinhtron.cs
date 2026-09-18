using System;

namespace ExampleCAdvance.Hinh
{
    public class HinhTron
    {
        private double banKinh;

        public double BanKinh
        {
            get { return banKinh; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Ban kinh phai lon hon 0");
                }

                banKinh = value;
            }
        }

        public HinhTron()
        {
        }

        public HinhTron(double banKinh)
        {
            BanKinh = banKinh;
        }

        public double TinhChuVi()
        {
            return 2 * Math.PI * BanKinh;
        }

        public double TinhDienTich()
        {
            return Math.PI * BanKinh * BanKinh;
        }

        public void HienThi()
        {
            Console.WriteLine($"Ban kinh: {BanKinh}");
            Console.WriteLine($"Chu vi: {TinhChuVi():F2}");
            Console.WriteLine($"Dien tich: {TinhDienTich():F2}");
        }
    }
}