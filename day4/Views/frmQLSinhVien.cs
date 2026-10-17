using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Yêu cầu: Tầng View phải xử lý ngoại lệ (try-catch) được ném về từ tầng Business và DataAccess Layer.
    /// </summary>
    public partial class frmQLSinhVien : Form
    {
        // Khởi tạo đối tượng tầng Business theo biến 'svb' của cô giáo
        private readonly SinhVienBUL svb = new SinhVienBUL();
        private readonly LopBUL _lopBUL = new LopBUL();
        private bool _isUpdatingFromCode = false;

        public frmQLSinhVien()
        {
            InitializeComponent();
        }

        private void frmQLSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Cài đặt danh sách trạng thái
                cboTrangThai.Items.Clear();
                cboTrangThai.Items.AddRange(new object[] { "Đang học", "Bảo lưu", "Đã tốt nghiệp" });
                cboTrangThai.SelectedIndex = 0;

                // 2. Lấy về danh sách lớp học hiển thị lên combobox (thông qua tầng BUL)
                NapDanhSachLopHoc();

                // 3. Lấy về danh sách sinh viên hiển thị DataGridView (thông qua tầng BUL)
                HienThiDanhSachSinhVien(svb.LayDanhSachSinhVien());

                // 4. Thiết lập cho các button có giá trị enable phù hợp
                ThietLapTrangThaiButton(choPhepNhap: true, choPhepSua: false, choPhepXoa: false);

                // 5. Con trỏ thiết lập mặc định ở txtMaSV
                this.ActiveControl = txtMaSV;
                txtMaSV.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu khởi động: " + ex.Message,
                                "Thông báo lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nạp danh sách lớp học hiển thị lên ComboBox lớp học và ComboBox lọc lớp
        /// </summary>
        private void NapDanhSachLopHoc()
        {
            try
            {
                var danhSachLop = _lopBUL.LayDanhSachLop();

                // Combobox lớp học nhập liệu
                cboLop.DataSource = danhSachLop.ToList();
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                if (cboLop.Items.Count > 0)
                {
                    cboLop.SelectedIndex = 0;
                }

                // Combobox lọc lớp khi tìm kiếm
                var danhSachLoc = new List<LopHoc>
                {
                    new LopHoc("ALL", "Tất cả lớp")
                };
                danhSachLoc.AddRange(danhSachLop);
                cboLocLop.DataSource = danhSachLoc;
                cboLocLop.DisplayMember = "TenLop";
                cboLocLop.ValueMember = "MaLop";
                cboLocLop.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi nạp danh sách lớp học: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Khi chọn lớp nào trong combobox thì hiển thị sinh viên của lớp đấy trên giao diện
        /// </summary>
        private void cboLocLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isUpdatingFromCode) return;

            try
            {
                string? maLop = cboLocLop.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maLop) || maLop == "ALL")
                {
                    HienThiDanhSachSinhVien(svb.LayDanhSachSinhVien());
                }
                else
                {
                    HienThiDanhSachSinhVien(svb.LaySinhVienTheoLop(maLop));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc sinh viên theo lớp: " + ex.Message,
                                "Thông báo lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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
        /// Xóa toàn bộ biểu tượng báo lỗi của ErrorProvider trên giao diện
        /// </summary>
        private void XoaBaoLoi()
        {
            errPMaSV.Clear();
            erpHoten.Clear();
            erpEmail.Clear();
            erpDienThoai.Clear();
        }

        /// <summary>
        /// Khi nhập mã Sinh viên vào txtMa:
        /// - Nếu mã tồn tại: hiển thị thông tin sinh viên, disable nhập, enable sửa/xóa
        /// - Nếu không tồn tại: xóa trống các ô còn lại, enable nhập, disable sửa/xóa
        /// </summary>
        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            if (_isUpdatingFromCode) return;

            try
            {
                errPMaSV.Clear();
                string maSV = txtMaSV.Text.Trim();
                if (string.IsNullOrEmpty(maSV))
                {
                    XoaGiaTriCacTextBoxKhac();
                    ThietLapTrangThaiButton(choPhepNhap: true, choPhepSua: false, choPhepXoa: false);
                    dgvSinhVien.ClearSelection();
                    return;
                }

                var sv = svb.TimSinhVienTheoMa(maSV);
                if (sv != null)
                {
                    HienThiThongTinSinhVien(sv, capNhatMaSV: false);
                    ThietLapTrangThaiButton(choPhepNhap: false, choPhepSua: true, choPhepXoa: true);
                    DongBoChonDongTrenGrid(sv.MaSV);
                }
                else
                {
                    XoaGiaTriCacTextBoxKhac();
                    ThietLapTrangThaiButton(choPhepNhap: true, choPhepSua: false, choPhepXoa: false);
                    dgvSinhVien.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu thông tin sinh viên: " + ex.Message,
                                "Thông báo lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void txtMaSV_Leave(object sender, EventArgs e)
        {
            txtMaSV_TextChanged(sender, e);
        }

        /// <summary>
        /// Xóa giá trị các TextBox thông tin khác khi mã SV chưa tồn tại
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
            txtDienThoai.Text = sv.SoDienThoai;
            numDiem.Value = (decimal)Math.Clamp(sv.Diem, 0.0, 10.0);

            if (!string.IsNullOrEmpty(sv.MaLop))
            {
                cboLop.SelectedValue = sv.MaLop;
            }
            else
            {
                int classIdx = cboLop.FindStringExact(sv.TenLop);
                if (classIdx >= 0) cboLop.SelectedIndex = classIdx;
            }

            int statusIdx = cboTrangThai.FindStringExact(sv.TrangThai);
            if (statusIdx >= 0)
            {
                cboTrangThai.SelectedIndex = statusIdx;
            }

            _isUpdatingFromCode = false;
        }

        /// <summary>
        /// Đồng bộ chọn dòng trong DataGridView
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            butThem_Click(sender, e);
        }

        /// <summary>
        /// Sự kiện Thêm sinh viên:
        /// Gọi tầng BUL, bắt và xử lý ngoại lệ ném về từ tầng BUL và DAO.
        /// </summary>
        private void butThem_Click(object sender, EventArgs e)
        {
            try
            {
                XoaBaoLoi();

                SinhVien sv = new SinhVien();
                sv.MaSV = txtMaSV.Text.Trim();
                sv.NgaySinh = dtpNgaySinh.Value;
                sv.HoTen = txtHoTen.Text.Trim();
                sv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                sv.Email = txtEmail.Text.Trim();
                sv.SoDienThoai = txtDienThoai.Text.Trim();
                sv.MaLop = cboLop.SelectedValue?.ToString() ?? string.Empty;
                sv.Diem = (double)numDiem.Value;
                sv.TenLop = cboLop.Text;
                sv.TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang học";

                List<ValidationResult> errors = sv.IsInValid();
                if (errors.Count == 0)
                {
                    // Tầng BUL sẽ ném ngoại lệ nếu trùng mã hoặc lỗi CSDL
                    svb.AddSinhVien(sv);

                    // Cập nhật lại giao diện sau khi thêm thành công
                    HienThiDanhSachSinhVien(svb.LayDanhSachSinhVien());
                    DongBoChonDongTrenGrid(sv.MaSV);
                    ThietLapTrangThaiButton(choPhepNhap: false, choPhepSua: true, choPhepXoa: true);

                    MessageBox.Show($"Thêm thành công sinh viên '{sv.HoTen}' (Mã: {sv.MaSV})!",
                                    "Thành công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    // Hiển thị thông báo lỗi tương ứng với từng trường trên ErrorProvider
                    foreach (var error in errors)
                    {
                        if (error.MemberNames != null && error.MemberNames.Any())
                        {
                            string fieldName = error.MemberNames.First();
                            switch (fieldName)
                            {
                                case "MaSV":
                                    errPMaSV.SetError(txtMaSV, error.ErrorMessage);
                                    txtMaSV.Focus();
                                    break;
                                case "HoTen":
                                    erpHoten.SetError(txtHoTen, error.ErrorMessage);
                                    txtHoTen.Focus();
                                    break;
                                case "Email":
                                    erpEmail.SetError(txtEmail, error.ErrorMessage);
                                    txtEmail.Focus();
                                    break;
                                case "SoDienThoai":
                                case "DienThoai":
                                    erpDienThoai.SetError(txtDienThoai, error.ErrorMessage);
                                    txtDienThoai.Focus();
                                    break;
                                default:
                                    MessageBox.Show(error.ErrorMessage, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }
                        }
                    }
                    string errorMessage = string.Join("\n", errors.Select(err => err.ErrorMessage));
                    MessageBox.Show(errorMessage, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ theo đúng yêu cầu
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chức năng SỬA: Xử lý ngoại lệ ném về từ tầng BUL và DAO
        /// </summary>
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                XoaBaoLoi();

                string maSV = txtMaSV.Text.Trim();
                if (string.IsNullOrEmpty(maSV))
                {
                    errPMaSV.SetError(txtMaSV, "Vui lòng chọn hoặc nhập mã sinh viên hợp lệ để sửa!");
                    txtMaSV.Focus();
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã sinh viên đã tồn tại để sửa!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận trước khi cập nhật
                DialogResult xacNhan = MessageBox.Show(
                    $"Bạn có chắc chắn muốn cập nhật thông tin sinh viên có mã '{maSV}' không?",
                    "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (xacNhan != DialogResult.Yes) return;

                SinhVien sv = new SinhVien();
                sv.MaSV = txtMaSV.Text.Trim();
                sv.NgaySinh = dtpNgaySinh.Value;
                sv.HoTen = txtHoTen.Text.Trim();
                sv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                sv.Email = txtEmail.Text.Trim();
                sv.SoDienThoai = txtDienThoai.Text.Trim();
                sv.MaLop = cboLop.SelectedValue?.ToString() ?? string.Empty;
                sv.Diem = (double)numDiem.Value;
                sv.TenLop = cboLop.Text;
                sv.TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang học";

                List<ValidationResult> errors = sv.IsInValid();
                if (errors.Count == 0)
                {
                    svb.UpdateSinhVien(sv);
                    HienThiDanhSachSinhVien(svb.LayDanhSachSinhVien());
                    DongBoChonDongTrenGrid(sv.MaSV);

                    MessageBox.Show($"Cập nhật thành công thông tin sinh viên '{sv.HoTen}'!",
                                    "Thành công",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    foreach (var error in errors)
                    {
                        if (error.MemberNames != null && error.MemberNames.Any())
                        {
                            string fieldName = error.MemberNames.First();
                            switch (fieldName)
                            {
                                case "MaSV":
                                    errPMaSV.SetError(txtMaSV, error.ErrorMessage);
                                    txtMaSV.Focus();
                                    break;
                                case "HoTen":
                                    erpHoten.SetError(txtHoTen, error.ErrorMessage);
                                    txtHoTen.Focus();
                                    break;
                                case "Email":
                                    erpEmail.SetError(txtEmail, error.ErrorMessage);
                                    txtEmail.Focus();
                                    break;
                                case "SoDienThoai":
                                case "DienThoai":
                                    erpDienThoai.SetError(txtDienThoai, error.ErrorMessage);
                                    txtDienThoai.Focus();
                                    break;
                                default:
                                    MessageBox.Show(error.ErrorMessage, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                            }
                        }
                    }
                    string errorMessage = string.Join("\n", errors.Select(err => err.ErrorMessage));
                    MessageBox.Show(errorMessage, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Tầng View bắt ngoại lệ
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chức năng XÓA: Xử lý ngoại lệ ném về từ tầng BUL và DAO
        /// </summary>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                XoaBaoLoi();

                string maSV = txtMaSV.Text.Trim();
                if (string.IsNullOrEmpty(maSV))
                {
                    errPMaSV.SetError(txtMaSV, "Vui lòng chọn hoặc nhập mã sinh viên hợp lệ để xóa!");
                    MessageBox.Show("Vui lòng chọn hoặc nhập mã sinh viên hợp lệ để xóa!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    txtMaSV.Focus();
                    return;
                }

                DialogResult xacNhan = MessageBox.Show(
                    $"CẢNH BÁO NGUY HIỂM: Bạn có chắc chắn muốn xóa sinh viên '{txtHoTen.Text.Trim()}' (Mã: {maSV}) khỏi hệ thống không?\n\nThao tác này sẽ xóa vĩnh viễn dữ liệu và không thể hoàn tác!",
                    "Xác thực thao tác nguy hiểm (Xác nhận xóa)",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (xacNhan != DialogResult.Yes) return;

                svb.DeleteSinhVien(maSV);
                HienThiDanhSachSinhVien(svb.LayDanhSachSinhVien());
                btnLamMoi_Click(sender, e);
                MessageBox.Show($"Đã xóa sinh viên có mã '{maSV}' thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Tầng View xử lý ngoại lệ
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Làm mới giao diện
        /// </summary>
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaBaoLoi();
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

            ThietLapTrangThaiButton(choPhepNhap: true, choPhepSua: false, choPhepXoa: false);

            this.ActiveControl = txtMaSV;
            txtMaSV.Focus();
        }

        /// <summary>
        /// Tìm kiếm sinh viên
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                string? lopChon = cboLocLop.SelectedValue?.ToString();
                if (lopChon == "ALL") lopChon = null;
                double diemTu = (double)numDiemTu.Value;

                var ketQua = svb.TimKiemVaLoc(tuKhoa, lopChon, diemTu);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sinh viên: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị tất cả sinh viên và xóa bộ lọc
        /// </summary>
        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                txtTimKiem.Clear();
                cboLocLop.SelectedIndex = 0;
                numDiemTu.Value = 0.0m;

                var tatCa = svb.LayDanhSachSinhVien();
                HienThiDanhSachSinhVien(tatCa);

                btnLamMoi_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị tất cả sinh viên: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Vẽ badge màu bo tròn cho cột Trạng thái
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
