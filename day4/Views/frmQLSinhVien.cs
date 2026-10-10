using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using QuanLySinhVien.BUL;
using QuanLySinhVien.Data.Entity;

namespace QuanLySinhVien.Views
{
    /// <summary>
    /// Tầng Presentation (Views):
    /// Chỉ đảm nhận xử lý về giao diện (UI/UX), bắt sự kiện người dùng và gọi tầng Business (BUL).
    /// </summary>
    public partial class frmQLSinhVien : Form
    {
        private readonly SinhVienBUL _sinhVienBUL = new SinhVienBUL();
        private readonly LopBUL _lopBUL = new LopBUL();
        private bool _isUpdatingFromCode = false;

        public frmQLSinhVien()
        {
            InitializeComponent();
        }

        private void frmQLSinhVien_Load(object sender, EventArgs e)
        {
            // 1. Cài đặt danh sách trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Đang học", "Bảo lưu", "Đã tốt nghiệp" });
            cboTrangThai.SelectedIndex = 0;

            // 2. Lấy về danh sách lớp học hiển thị combobox (thông qua tầng BUL)
            NapDanhSachLopHoc();

            // 3. Lấy về danh sách sinh viên hiển thị DataGridView (thông qua tầng BUL)
            HienThiDanhSachSinhVien(_sinhVienBUL.LayDanhSachSinhVien());

            // 4. Thiết lập cho các button có giá trị enable phù hợp
            ThietLapTrangThaiButton(choPhepNhap: true, choPhepSua: false, choPhepXoa: false);

            // 5. Con trỏ thiết lập mặc định ở txtMaSV
            this.ActiveControl = txtMaSV;
            txtMaSV.Focus();
        }

        /// <summary>
        /// Nạp danh sách lớp học hiển thị lên ComboBox lớp học và ComboBox lọc lớp
        /// </summary>
        private void NapDanhSachLopHoc()
        {
            var danhSachLop = _lopBUL.LayDanhSachLop();

            // Combobox lớp học nhập liệu
            cboLop.Items.Clear();
            foreach (var lop in danhSachLop)
            {
                cboLop.Items.Add(lop.TenLop);
            }
            if (cboLop.Items.Count > 0)
            {
                cboLop.SelectedIndex = 0;
            }

            // Combobox lọc lớp khi tìm kiếm
            cboLocLop.Items.Clear();
            cboLocLop.Items.Add("Tất cả lớp");
            foreach (var lop in danhSachLop)
            {
                cboLocLop.Items.Add(lop.TenLop);
            }
            cboLocLop.SelectedIndex = 0;
        }

        /// <summary>
        /// Hiển thị danh sách sinh viên lên DataGridView và cập nhật tổng số
        /// </summary>
        private void HienThiDanhSachSinhVien(List<SinhVien> danhSach)
        {
            _isUpdatingFromCode = true;
            dgvSinhVien.DataSource = null;
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.DataSource = danhSach.ToList();
            _isUpdatingFromCode = false;

            lblTongSo.Text = $"Tổng số: {danhSach.Count} sinh viên";
        }

        /// <summary>
        /// Thiết lập trạng thái Enable/Disable cho các Button
        /// </summary>
        private void ThietLapTrangThaiButton(bool choPhepNhap, bool choPhepSua, bool choPhepXoa)
        {
            btnThem.Enabled = choPhepNhap;
            btnSua.Enabled = choPhepSua;
            btnXoa.Enabled = choPhepXoa;
            btnLamMoi.Enabled = true;
        }

        /// <summary>
        /// Khi người dùng nhập mã sinh viên:
        /// - nếu mã sinh viên tồn tại: lấy thông tin của sinh viên hiển thị tương ứng lên các điều khiển còn lại, disable chức năng nhập, enable chức năng sửa, xóa
        /// - chưa tồn tại: xóa giá trị các điều khiển textbox, enable chức năng nhập, disable chức năng sửa, xóa
        /// </summary>
        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            if (_isUpdatingFromCode) return;

            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(maSV))
            {
                XoaGiaTriCacTextBoxKhac();
                ThietLapTrangThaiButton(choPhepNhap: true, choPhepSua: false, choPhepXoa: false);
                dgvSinhVien.ClearSelection();
                return;
            }

            var sv = _sinhVienBUL.TimSinhVienTheoMa(maSV);
            if (sv != null)
            {
                // Mã sinh viên tồn tại:
                // Lấy thông tin sinh viên hiển thị tương ứng lên các điều khiển còn lại
                HienThiThongTinSinhVien(sv, capNhatMaSV: false);

                // Disable chức năng nhập, enable chức năng sửa, xóa
                ThietLapTrangThaiButton(choPhepNhap: false, choPhepSua: true, choPhepXoa: true);

                // Đồng bộ chọn dòng tương ứng trên DataGridView
                DongBoChonDongTrenGrid(sv.MaSV);
            }
            else
            {
                // Chưa tồn tại:
                // Xóa giá trị các điều khiển textbox
                XoaGiaTriCacTextBoxKhac();

                // Enable chức năng nhập, disable chức năng sửa, xóa
                ThietLapTrangThaiButton(choPhepNhap: true, choPhepSua: false, choPhepXoa: false);

                dgvSinhVien.ClearSelection();
            }
        }

        private void txtMaSV_Leave(object sender, EventArgs e)
        {
            txtMaSV_TextChanged(sender, e);
        }

        /// <summary>
        /// Xóa giá trị các TextBox (Họ tên, Email, Điện thoại) mà giữ nguyên mã sinh viên đang gõ
        /// </summary>
        private void XoaGiaTriCacTextBoxKhac()
        {
            _isUpdatingFromCode = true;
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();
            dtpNgaySinh.Value = new DateTime(2006, 1, 1);
            rdoNam.Checked = true;
            numDiem.Value = 0.0m;
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            _isUpdatingFromCode = false;
        }

        /// <summary>
        /// Hiển thị thông tin sinh viên lên các điều khiển
        /// </summary>
        private void HienThiThongTinSinhVien(SinhVien sv, bool capNhatMaSV = true)
        {
            _isUpdatingFromCode = true;

            if (capNhatMaSV)
            {
                txtMaSV.Text = sv.MaSV;
            }

            txtHoTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;

            if (sv.GioiTinh.Equals("Nữ", StringComparison.OrdinalIgnoreCase))
            {
                rdoNu.Checked = true;
            }
            else
            {
                rdoNam.Checked = true;
            }

            txtEmail.Text = sv.Email;
            txtDienThoai.Text = sv.DienThoai;
            numDiem.Value = (decimal)Math.Clamp(sv.Diem, 0.0, 10.0);

            int classIdx = cboLop.FindStringExact(sv.TenLop);
            if (classIdx >= 0)
            {
                cboLop.SelectedIndex = classIdx;
            }

            int statusIdx = cboTrangThai.FindStringExact(sv.TrangThai);
            if (statusIdx >= 0)
            {
                cboTrangThai.SelectedIndex = statusIdx;
            }

            _isUpdatingFromCode = false;
        }

        /// <summary>
        /// Chọn dòng trong DataGridView
        /// </summary>
        private void DongBoChonDongTrenGrid(string maSV)
        {
            _isUpdatingFromCode = true;
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (row.DataBoundItem is SinhVien s && s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvSinhVien.CurrentCell = row.Cells[0];
                    break;
                }
            }
            _isUpdatingFromCode = false;
        }

        /// <summary>
        /// Khi click một dòng trên DataGridView -> nạp mã SV vào txtMaSV
        /// </summary>
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isUpdatingFromCode || e.RowIndex < 0 || e.RowIndex >= dgvSinhVien.Rows.Count) return;

            var sv = dgvSinhVien.Rows[e.RowIndex].DataBoundItem as SinhVien;
            if (sv != null)
            {
                txtMaSV.Text = sv.MaSV;
                txtMaSV.Focus();
                txtMaSV.SelectAll();
            }
        }

        /// <summary>
        /// Chức năng THÊM (Nhập):
        /// - Gọi tầng BUL để thực hiện nghiệp vụ và kiểm tra Data Annotation
        /// </summary>
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();

            // Khởi tạo đối tượng SinhVien từ giao diện
            var sv = new SinhVien
            {
                MaSV = maSV,
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = rdoNu.Checked ? "Nữ" : "Nam",
                Email = txtEmail.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                Diem = (double)numDiem.Value,
                TenLop = cboLop.SelectedItem?.ToString() ?? string.Empty,
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang học"
            };

            // Gọi tầng BUL để xử lý nghiệp vụ
            if (!_sinhVienBUL.ThemSinhVien(sv, out string thongBaoLoi))
            {
                MessageBox.Show(thongBaoLoi,
                                "Thông báo lỗi (Kiểm tra dữ liệu)",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật lại giao diện
            HienThiDanhSachSinhVien(_sinhVienBUL.LayDanhSachSinhVien());
            DongBoChonDongTrenGrid(sv.MaSV);
            ThietLapTrangThaiButton(choPhepNhap: false, choPhepSua: true, choPhepXoa: true);

            MessageBox.Show($"Thêm thành công sinh viên '{sv.HoTen}' (Mã: {sv.MaSV})!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        /// <summary>
        /// Chức năng SỬA:
        /// - Chức năng quan trọng -> xác thực trước khi thực hiện
        /// - Gọi tầng BUL để cập nhật
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(maSV) || !_sinhVienBUL.KiemTraTonTai(maSV))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã sinh viên đã tồn tại để sửa!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            // Xác thực trước khi thực hiện chức năng nguy hiểm / thay đổi dữ liệu
            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc chắn muốn cập nhật thông tin sinh viên có mã '{maSV}' không?",
                "Xác nhận cập nhật",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes) return;

            var svMoi = new SinhVien
            {
                MaSV = maSV,
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                GioiTinh = rdoNu.Checked ? "Nữ" : "Nam",
                Email = txtEmail.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                Diem = (double)numDiem.Value,
                TenLop = cboLop.SelectedItem?.ToString() ?? string.Empty,
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang học"
            };

            // Gọi tầng BUL để xử lý
            if (!_sinhVienBUL.SuaSinhVien(svMoi, out string thongBaoLoi))
            {
                MessageBox.Show(thongBaoLoi,
                                "Thông báo lỗi (Kiểm tra dữ liệu)",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật lại giao diện
            HienThiDanhSachSinhVien(_sinhVienBUL.LayDanhSachSinhVien());
            DongBoChonDongTrenGrid(svMoi.MaSV);
            MessageBox.Show($"Cập nhật thành công thông tin sinh viên '{svMoi.HoTen}'!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        /// <summary>
        /// Chức năng XÓA:
        /// - Chức năng NGUY HIỂM: Yêu cầu xác thực trước khi thực hiện
        /// - Gọi tầng BUL để thực hiện
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(maSV) || !_sinhVienBUL.KiemTraTonTai(maSV))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã sinh viên hợp lệ để xóa!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            // Xác thực thao tác nguy hiểm (Xóa dữ liệu vĩnh viễn)
            DialogResult xacNhan = MessageBox.Show(
                $"CẢNH BÁO NGUY HIỂM: Bạn có chắc chắn muốn xóa sinh viên '{txtHoTen.Text.Trim()}' (Mã: {maSV}) khỏi hệ thống không?\n\nThao tác này sẽ xóa vĩnh viễn dữ liệu và không thể hoàn tác!",
                "Xác thực thao tác nguy hiểm (Xác nhận xóa)",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (xacNhan != DialogResult.Yes) return;

            // Gọi tầng BUL
            if (_sinhVienBUL.XoaSinhVien(maSV, out string thongBaoLoi))
            {
                HienThiDanhSachSinhVien(_sinhVienBUL.LayDanhSachSinhVien());
                btnLamMoi_Click(sender, e);
                MessageBox.Show($"Đã xóa sinh viên có mã '{maSV}' thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(thongBaoLoi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Khi người dùng nhấn Button Làm mới:
        /// - Xóa trống các thuộc tính trên form
        /// - Enable button Nhập, Disable button sửa xóa
        /// - Chuyển tiêu điểm về điều khiển txtMaSV
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _isUpdatingFromCode = true;

            txtMaSV.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();
            dtpNgaySinh.Value = new DateTime(2006, 1, 1);
            rdoNam.Checked = true;
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

            _isUpdatingFromCode = false;

            // Enable button Nhập, Disable button sửa xóa
            ThietLapTrangThaiButton(choPhepNhap: true, choPhepSua: false, choPhepXoa: false);

            // Chuyển tiêu điểm về điều khiển txtMaSV
            this.ActiveControl = txtMaSV;
            txtMaSV.Focus();
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo từ khóa, lớp, điểm sàn
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            string? lopChon = cboLocLop.SelectedItem?.ToString();
            double diemTu = (double)numDiemTu.Value;

            var ketQua = _sinhVienBUL.TimKiemVaLoc(tuKhoa, lopChon, diemTu);
            HienThiDanhSachSinhVien(ketQua);

            if (ketQua.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên nào phù hợp với điều kiện tìm kiếm!",
                                "Kết quả tìm kiếm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                DongBoChonDongTrenGrid(ketQua[0].MaSV);
                HienThiThongTinSinhVien(ketQua[0], capNhatMaSV: true);
                ThietLapTrangThaiButton(choPhepNhap: false, choPhepSua: true, choPhepXoa: true);
            }
        }

        /// <summary>
        /// Hiển thị tất cả sinh viên và xóa bộ lọc
        /// </summary>
        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocLop.SelectedIndex = 0;
            numDiemTu.Value = 0.0m;

            var tatCa = _sinhVienBUL.LayDanhSachSinhVien();
            HienThiDanhSachSinhVien(tatCa);

            btnLamMoi_Click(sender, e);
        }

        /// <summary>
        /// Vẽ badge màu xanh bo tròn cho cột Trạng thái giống 100% trong ảnh
        /// </summary>
        private void dgvSinhVien_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colTrangThai.Index && e.Value != null)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);

                string text = e.Value.ToString() ?? "";
                if (!string.IsNullOrEmpty(text))
                {
                    Color badgeBg = Color.FromArgb(209, 231, 221);
                    Color badgeText = Color.FromArgb(15, 81, 50);

                    if (text == "Bảo lưu")
                    {
                        badgeBg = Color.FromArgb(255, 243, 205);
                        badgeText = Color.FromArgb(102, 77, 3);
                    }
                    else if (text == "Đã tốt nghiệp")
                    {
                        badgeBg = Color.FromArgb(226, 227, 229);
                        badgeText = Color.FromArgb(65, 70, 75);
                    }

                    int badgeWidth = 84;
                    int badgeHeight = 22;
                    int x = e.CellBounds.X + (e.CellBounds.Width - badgeWidth) / 2;
                    int y = e.CellBounds.Y + (e.CellBounds.Height - badgeHeight) / 2;
                    var rect = new Rectangle(x, y, badgeWidth, badgeHeight);

                    if (e.Graphics != null)
                    {
                        using (var brush = new SolidBrush(badgeBg))
                        using (var path = CreateRoundedRectangle(rect, 10))
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.FillPath(brush, path);
                        }

                        using (var font = new Font("Segoe UI", 8.5f, FontStyle.Bold))
                        using (var brush = new SolidBrush(badgeText))
                        {
                            var sf = new StringFormat
                            {
                                Alignment = StringAlignment.Center,
                                LineAlignment = StringAlignment.Center
                            };
                            e.Graphics.DrawString(text, font, brush, rect, sf);
                        }
                    }
                }

                e.Handled = true;
            }
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
