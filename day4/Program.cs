using System;
using System.Windows.Forms;
using QuanLySinhVien.Views;

namespace QuanLySinhVien
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmQLSinhVien());
        }
    }
}
