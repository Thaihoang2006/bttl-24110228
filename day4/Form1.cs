using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using day4.Models;
using day4.Services;

namespace day4
{
    public partial class Form1 : Form
    {
        private readonly StudentManager _manager = new StudentManager();
        private bool _isBinding = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cài đặt danh sách trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Đang học", "Bảo lưu", "Đã tốt nghiệp" });
            cboTrangThai.SelectedIndex = 0;

            // Nạp danh sách lớp vào ComboBox nhập liệu và ComboBox tìm kiếm
            LoadClassComboBoxes();

            // Nạp dữ liệu lên DataGridView
            LoadStudentGrid(_manager.GetAllStudents());

            // Chọn sinh viên đầu tiên để hiển thị lên form như ảnh mẫu
            if (dgvSinhVien.Rows.Count > 0)
            {
                dgvSinhVien.Rows[0].Selected = true;
                DisplayStudentInfo(dgvSinhVien.Rows[0].DataBoundItem as Student);
            }
        }

        private void LoadClassComboBoxes()
        {
            var classNames = _manager.Classes.Select(c => c.ClassName).ToList();

            // ComboBox chọn lớp khi thêm/sửa
            cboLop.Items.Clear();
            foreach (var name in classNames)
            {
                cboLop.Items.Add(name);
            }
            if (cboLop.Items.Count > 0)
            {
                cboLop.SelectedIndex = 0;
            }

            // ComboBox lọc lớp khi tìm kiếm
            cboLocLop.Items.Clear();
            cboLocLop.Items.Add("Tất cả lớp");
            foreach (var name in classNames)
            {
                cboLocLop.Items.Add(name);
            }
            cboLocLop.SelectedIndex = 0;
        }

        private void LoadStudentGrid(List<Student> students)
        {
            _isBinding = true;
            dgvSinhVien.DataSource = null;
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.DataSource = students;
            _isBinding = false;

            lblTongSo.Text = $"Tổng số: {students.Count} sinh viên";
        }

        private void DisplayStudentInfo(Student? student)
        {
            if (student == null) return;

            txtMaSV.Text = student.StudentId;
            txtMaSV.ReadOnly = true; // Khóa mã SV khi xem/sửa dòng có sẵn
            txtHoTen.Text = student.FullName;
            dtpNgaySinh.Value = student.DateOfBirth;

            if (student.Gender.Equals("Nữ", StringComparison.OrdinalIgnoreCase))
            {
                rdoNu.Checked = true;
            }
            else
            {
                rdoNam.Checked = true;
            }

            txtEmail.Text = student.Email;
            txtDienThoai.Text = student.Phone;
            numDiem.Value = (decimal)Math.Clamp(student.Score, 0.0, 10.0);

            // Chọn lớp
            int classIdx = cboLop.FindStringExact(student.ClassName);
            if (classIdx >= 0)
            {
                cboLop.SelectedIndex = classIdx;
            }

            // Chọn trạng thái
            int statusIdx = cboTrangThai.FindStringExact(student.Status);
            if (statusIdx >= 0)
            {
                cboTrangThai.SelectedIndex = statusIdx;
            }
            else
            {
                cboTrangThai.SelectedIndex = 0;
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isBinding || e.RowIndex < 0 || e.RowIndex >= dgvSinhVien.Rows.Count) return;

            var student = dgvSinhVien.Rows[e.RowIndex].DataBoundItem as Student;
            DisplayStudentInfo(student);
        }

        private bool ValidateInputs(bool isAdding)
        {
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return false;
            }

            if (isAdding && _manager.Exists(maSV))
            {
                MessageBox.Show($"Mã sinh viên '{maSV}' đã tồn tại! Vui lòng chọn mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (cboLop.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Định dạng Email không hợp lệ (ví dụ: an.nv@vju.ac.vn)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(dienThoai))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(isAdding: true)) return;

            var student = new Student
            {
                StudentId = txtMaSV.Text.Trim(),
                FullName = txtHoTen.Text.Trim(),
                DateOfBirth = dtpNgaySinh.Value,
                Gender = rdoNu.Checked ? "Nữ" : "Nam",
                Email = txtEmail.Text.Trim(),
                Phone = txtDienThoai.Text.Trim(),
                Score = (double)numDiem.Value,
                ClassName = cboLop.SelectedItem?.ToString() ?? string.Empty,
                Status = cboTrangThai.SelectedItem?.ToString() ?? "Đang học"
            };

            bool success = _manager.AddStudent(student);
            if (success)
            {
                LoadStudentGrid(_manager.GetAllStudents());
                SelectStudentInGrid(student.StudentId);
                MessageBox.Show($"Thêm sinh viên '{student.FullName}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể thêm sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV) || !_manager.Exists(maSV))
            {
                MessageBox.Show("Vui lòng chọn một sinh viên từ danh sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs(isAdding: false)) return;

            var updatedStudent = new Student
            {
                StudentId = maSV,
                FullName = txtHoTen.Text.Trim(),
                DateOfBirth = dtpNgaySinh.Value,
                Gender = rdoNu.Checked ? "Nữ" : "Nam",
                Email = txtEmail.Text.Trim(),
                Phone = txtDienThoai.Text.Trim(),
                Score = (double)numDiem.Value,
                ClassName = cboLop.SelectedItem?.ToString() ?? string.Empty,
                Status = cboTrangThai.SelectedItem?.ToString() ?? "Đang học"
            };

            bool success = _manager.UpdateStudent(updatedStudent);
            if (success)
            {
                LoadStudentGrid(_manager.GetAllStudents());
                SelectStudentInGrid(updatedStudent.StudentId);
                MessageBox.Show($"Cập nhật sinh viên '{updatedStudent.FullName}' thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể cập nhật sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maSV) || !_manager.Exists(maSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên '{txtHoTen.Text.Trim()}' (Mã: {maSV})?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool success = _manager.DeleteStudent(maSV);
                if (success)
                {
                    LoadStudentGrid(_manager.GetAllStudents());
                    btnLamMoi_Click(sender, e);
                    MessageBox.Show("Đã xóa sinh viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa sinh viên không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSV.Clear();
            txtMaSV.ReadOnly = false;
            txtHoTen.Clear();
            dtpNgaySinh.Value = new DateTime(2006, 1, 1);
            rdoNam.Checked = true;
            txtEmail.Clear();
            txtDienThoai.Clear();
            numDiem.Value = 0.0m;

            if (cboLop.Items.Count > 0)
            {
                cboLop.SelectedIndex = 0;
            }

            if (cboTrangThai.Items.Count > 0)
            {
                cboTrangThai.SelectedIndex = 0;
            }

            dgvSinhVien.ClearSelection();
            txtMaSV.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string? selectedClass = cboLocLop.SelectedItem?.ToString();
            double minScore = (double)numDiemTu.Value;

            var results = _manager.Search(keyword, selectedClass, minScore);
            LoadStudentGrid(results);

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên nào phù hợp với điều kiện tìm kiếm!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvSinhVien.Rows[0].Selected = true;
                DisplayStudentInfo(dgvSinhVien.Rows[0].DataBoundItem as Student);
            }
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocLop.SelectedIndex = 0;
            numDiemTu.Value = 0.0m;

            LoadStudentGrid(_manager.GetAllStudents());

            if (dgvSinhVien.Rows.Count > 0)
            {
                dgvSinhVien.Rows[0].Selected = true;
                DisplayStudentInfo(dgvSinhVien.Rows[0].DataBoundItem as Student);
            }
        }

        private void SelectStudentInGrid(string studentId)
        {
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.DataBoundItem is Student s && s.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvSinhVien.CurrentCell = row.Cells[0];
                    DisplayStudentInfo(s);
                    break;
                }
            }
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
