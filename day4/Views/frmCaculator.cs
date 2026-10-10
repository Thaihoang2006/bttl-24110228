using System;
using System.Windows.Forms;

namespace QuanLySinhVien.Views
{
    public partial class frmCaculator : Form
    {
        public frmCaculator()
        {
            InitializeComponent();
        }

        private void Cong_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(A.Text);
                double b = double.Parse(B.Text);

                KQ.Text = (a + b).ToString();
            }
            catch
            {
                KQ.Text = "Lỗi";
            }
        }

        private void Tru_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(A.Text);
                double b = double.Parse(B.Text);

                KQ.Text = (a - b).ToString();
            }
            catch
            {
                KQ.Text = "Lỗi";
            }
        }

        private void Nhan_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(A.Text);
                double b = double.Parse(B.Text);

                KQ.Text = (a * b).ToString();
            }
            catch
            {
                KQ.Text = "Lỗi";
            }
        }

        private void Chia_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(A.Text);
                double b = double.Parse(B.Text);

                if (b == 0)
                {
                    KQ.Text = "Không thể chia cho 0";
                }
                else
                {
                    KQ.Text = (a / b).ToString();
                }
            }
            catch
            {
                KQ.Text = "Lỗi";
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
