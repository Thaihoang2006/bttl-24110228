namespace day4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblAppTitle = new Label();
            lblMainTitle = new Label();
            pnlStudentInfo = new Panel();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            cboTrangThai = new ComboBox();
            lblTrangThai = new Label();
            txtDienThoai = new TextBox();
            lblDienThoai = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            numDiem = new NumericUpDown();
            lblDiem = new Label();
            pnlGioiTinh = new Panel();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            lblGioiTinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblNgaySinh = new Label();
            cboLop = new ComboBox();
            lblLop = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtMaSV = new TextBox();
            lblMaSV = new Label();
            lblGroupTitle = new Label();
            pnlAccent = new Panel();
            pnlFilter = new Panel();
            btnHienThiTatCa = new Button();
            btnTimKiem = new Button();
            numDiemTu = new NumericUpDown();
            lblDiemTu = new Label();
            cboLocLop = new ComboBox();
            lblLocLop = new Label();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            pnlList = new Panel();
            lblBatBuoc = new Label();
            lblHuongDan = new Label();
            dgvSinhVien = new DataGridView();
            colMaSV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colNgaySinh = new DataGridViewTextBoxColumn();
            colGioiTinh = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDienThoai = new DataGridViewTextBoxColumn();
            colDiem = new DataGridViewTextBoxColumn();
            colLop = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            lblTongSo = new Label();
            lblListTitle = new Label();
            pnlFooter = new Panel();
            pnlHeader.SuspendLayout();
            pnlStudentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiem).BeginInit();
            pnlGioiTinh.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiemTu).BeginInit();
            pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.DarkBlue;
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4, 4, 4, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1328, 48);
            pnlHeader.TabIndex = 0;
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(60, 10);
            lblAppTitle.Margin = new Padding(4, 0, 4, 0);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(273, 28);
            lblAppTitle.TabIndex = 1;
            lblAppTitle.Text = "Ứng dụng quản lý sinh viên";
            // 
            // lblMainTitle
            // 
            lblMainTitle.AutoSize = true;
            lblMainTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(12, 43, 78);
            lblMainTitle.Location = new Point(25, 62);
            lblMainTitle.Margin = new Padding(4, 0, 4, 0);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(326, 45);
            lblMainTitle.TabIndex = 1;
            lblMainTitle.Text = "QUẢN LÝ SINH VIÊN";
            // 
            // pnlStudentInfo
            // 
            pnlStudentInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStudentInfo.BackColor = Color.White;
            pnlStudentInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlStudentInfo.Controls.Add(btnLamMoi);
            pnlStudentInfo.Controls.Add(btnXoa);
            pnlStudentInfo.Controls.Add(btnSua);
            pnlStudentInfo.Controls.Add(btnThem);
            pnlStudentInfo.Controls.Add(cboTrangThai);
            pnlStudentInfo.Controls.Add(lblTrangThai);
            pnlStudentInfo.Controls.Add(txtDienThoai);
            pnlStudentInfo.Controls.Add(lblDienThoai);
            pnlStudentInfo.Controls.Add(txtEmail);
            pnlStudentInfo.Controls.Add(lblEmail);
            pnlStudentInfo.Controls.Add(numDiem);
            pnlStudentInfo.Controls.Add(lblDiem);
            pnlStudentInfo.Controls.Add(pnlGioiTinh);
            pnlStudentInfo.Controls.Add(lblGioiTinh);
            pnlStudentInfo.Controls.Add(dtpNgaySinh);
            pnlStudentInfo.Controls.Add(lblNgaySinh);
            pnlStudentInfo.Controls.Add(cboLop);
            pnlStudentInfo.Controls.Add(lblLop);
            pnlStudentInfo.Controls.Add(txtHoTen);
            pnlStudentInfo.Controls.Add(lblHoTen);
            pnlStudentInfo.Controls.Add(txtMaSV);
            pnlStudentInfo.Controls.Add(lblMaSV);
            pnlStudentInfo.Controls.Add(lblGroupTitle);
            pnlStudentInfo.Controls.Add(pnlAccent);
            pnlStudentInfo.Location = new Point(25, 115);
            pnlStudentInfo.Margin = new Padding(4, 4, 4, 4);
            pnlStudentInfo.Name = "pnlStudentInfo";
            pnlStudentInfo.Size = new Size(1277, 240);
            pnlStudentInfo.TabIndex = 3;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(108, 117, 125);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(1146, 188);
            btnLamMoi.Margin = new Padding(4, 4, 4, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(112, 40);
            btnLamMoi.TabIndex = 23;
            btnLamMoi.Text = "↻ Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(1044, 188);
            btnXoa.Margin = new Padding(4, 4, 4, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(95, 40);
            btnXoa.TabIndex = 22;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSua.BackColor = Color.FromArgb(13, 110, 253);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(941, 188);
            btnSua.Margin = new Padding(4, 4, 4, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(95, 40);
            btnSua.TabIndex = 21;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThem.BackColor = Color.FromArgb(25, 135, 84);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(839, 188);
            btnThem.Margin = new Padding(4, 4, 4, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 40);
            btnThem.TabIndex = 20;
            btnThem.Text = "+ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(935, 139);
            cboTrangThai.Margin = new Padding(4, 4, 4, 4);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(323, 33);
            cboTrangThai.TabIndex = 19;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(835, 144);
            lblTrangThai.Margin = new Padding(4, 0, 4, 0);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(89, 25);
            lblTrangThai.TabIndex = 18;
            lblTrangThai.Text = "Trạng thái";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(519, 139);
            txtDienThoai.Margin = new Padding(4, 4, 4, 4);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(286, 31);
            txtDienThoai.TabIndex = 17;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Location = new Point(410, 144);
            lblDienThoai.Margin = new Padding(4, 0, 4, 0);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(106, 25);
            lblDienThoai.TabIndex = 16;
            lblDienThoai.Text = "Điện thoại *";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(145, 139);
            txtEmail.Margin = new Padding(4, 4, 4, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(236, 31);
            txtEmail.TabIndex = 15;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(18, 144);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(67, 25);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "Email *";
            // 
            // numDiem
            // 
            numDiem.DecimalPlaces = 1;
            numDiem.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numDiem.Location = new Point(935, 90);
            numDiem.Margin = new Padding(4, 4, 4, 4);
            numDiem.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numDiem.Name = "numDiem";
            numDiem.Size = new Size(324, 31);
            numDiem.TabIndex = 13;
            numDiem.Value = new decimal(new int[] { 85, 0, 0, 65536 });
            // 
            // lblDiem
            // 
            lblDiem.AutoSize = true;
            lblDiem.Location = new Point(835, 94);
            lblDiem.Margin = new Padding(4, 0, 4, 0);
            lblDiem.Name = "lblDiem";
            lblDiem.Size = new Size(67, 25);
            lblDiem.TabIndex = 12;
            lblDiem.Text = "Điểm *";
            // 
            // pnlGioiTinh
            // 
            pnlGioiTinh.Controls.Add(rdoNu);
            pnlGioiTinh.Controls.Add(rdoNam);
            pnlGioiTinh.Location = new Point(519, 89);
            pnlGioiTinh.Margin = new Padding(4, 4, 4, 4);
            pnlGioiTinh.Name = "pnlGioiTinh";
            pnlGioiTinh.Size = new Size(288, 36);
            pnlGioiTinh.TabIndex = 11;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(128, 4);
            rdoNu.Margin = new Padding(4, 4, 4, 4);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(61, 29);
            rdoNu.TabIndex = 1;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Checked = true;
            rdoNam.Location = new Point(4, 4);
            rdoNam.Margin = new Padding(4, 4, 4, 4);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(75, 29);
            rdoNam.TabIndex = 0;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(410, 94);
            lblGioiTinh.Margin = new Padding(4, 0, 4, 0);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(78, 25);
            lblGioiTinh.TabIndex = 10;
            lblGioiTinh.Text = "Giới tính";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(145, 90);
            dtpNgaySinh.Margin = new Padding(4, 4, 4, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(236, 31);
            dtpNgaySinh.TabIndex = 9;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(18, 94);
            lblNgaySinh.Margin = new Padding(4, 0, 4, 0);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(91, 25);
            lblNgaySinh.TabIndex = 8;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(935, 41);
            cboLop.Margin = new Padding(4, 4, 4, 4);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(323, 33);
            cboLop.TabIndex = 7;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(835, 45);
            lblLop.Margin = new Padding(4, 0, 4, 0);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(89, 25);
            lblLop.TabIndex = 6;
            lblLop.Text = "Lớp học *";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(519, 41);
            txtHoTen.Margin = new Padding(4, 4, 4, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(286, 31);
            txtHoTen.TabIndex = 5;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(410, 45);
            lblHoTen.Margin = new Padding(4, 0, 4, 0);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(102, 25);
            lblHoTen.TabIndex = 4;
            lblHoTen.Text = "Họ và tên *";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(145, 41);
            txtMaSV.Margin = new Padding(4, 4, 4, 4);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(236, 31);
            txtMaSV.TabIndex = 3;
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.Location = new Point(18, 45);
            lblMaSV.Margin = new Padding(4, 0, 4, 0);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(124, 25);
            lblMaSV.TabIndex = 2;
            lblMaSV.Text = "Mã sinh viên *";
            // 
            // lblGroupTitle
            // 
            lblGroupTitle.AutoSize = true;
            lblGroupTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblGroupTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblGroupTitle.Location = new Point(22, 6);
            lblGroupTitle.Margin = new Padding(4, 0, 4, 0);
            lblGroupTitle.Name = "lblGroupTitle";
            lblGroupTitle.Size = new Size(204, 30);
            lblGroupTitle.TabIndex = 1;
            lblGroupTitle.Text = "Thông tin sinh viên";
            // 
            // pnlAccent
            // 
            pnlAccent.BackColor = Color.FromArgb(230, 81, 0);
            pnlAccent.Location = new Point(10, 9);
            pnlAccent.Margin = new Padding(4, 4, 4, 4);
            pnlAccent.Name = "pnlAccent";
            pnlAccent.Size = new Size(6, 25);
            pnlAccent.TabIndex = 0;
            // 
            // pnlFilter
            // 
            pnlFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilter.BackColor = Color.White;
            pnlFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlFilter.Controls.Add(btnHienThiTatCa);
            pnlFilter.Controls.Add(btnTimKiem);
            pnlFilter.Controls.Add(numDiemTu);
            pnlFilter.Controls.Add(lblDiemTu);
            pnlFilter.Controls.Add(cboLocLop);
            pnlFilter.Controls.Add(lblLocLop);
            pnlFilter.Controls.Add(txtTimKiem);
            pnlFilter.Controls.Add(lblTimKiem);
            pnlFilter.Location = new Point(25, 365);
            pnlFilter.Margin = new Padding(4, 4, 4, 4);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1277, 52);
            pnlFilter.TabIndex = 4;
            // 
            // btnHienThiTatCa
            // 
            btnHienThiTatCa.BackColor = Color.FromArgb(248, 249, 250);
            btnHienThiTatCa.FlatStyle = FlatStyle.System;
            btnHienThiTatCa.Font = new Font("Segoe UI", 9F);
            btnHienThiTatCa.Location = new Point(1110, 5);
            btnHienThiTatCa.Margin = new Padding(4, 4, 4, 4);
            btnHienThiTatCa.Name = "btnHienThiTatCa";
            btnHienThiTatCa.Size = new Size(149, 40);
            btnHienThiTatCa.TabIndex = 7;
            btnHienThiTatCa.Text = "Hiển thị tất cả";
            btnHienThiTatCa.UseVisualStyleBackColor = false;
            btnHienThiTatCa.Click += btnHienThiTatCa_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(13, 110, 253);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(978, 5);
            btnTimKiem.Margin = new Padding(4, 4, 4, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(125, 40);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // numDiemTu
            // 
            numDiemTu.DecimalPlaces = 1;
            numDiemTu.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numDiemTu.Location = new Point(875, 8);
            numDiemTu.Margin = new Padding(4, 4, 4, 4);
            numDiemTu.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numDiemTu.Name = "numDiemTu";
            numDiemTu.Size = new Size(85, 31);
            numDiemTu.TabIndex = 5;
            // 
            // lblDiemTu
            // 
            lblDiemTu.AutoSize = true;
            lblDiemTu.Location = new Point(790, 12);
            lblDiemTu.Margin = new Padding(4, 0, 4, 0);
            lblDiemTu.Name = "lblDiemTu";
            lblDiemTu.Size = new Size(76, 25);
            lblDiemTu.TabIndex = 4;
            lblDiemTu.Text = "Điểm từ";
            // 
            // cboLocLop
            // 
            cboLocLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLop.FormattingEnabled = true;
            cboLocLop.Location = new Point(519, 8);
            cboLocLop.Margin = new Padding(4, 4, 4, 4);
            cboLocLop.Name = "cboLocLop";
            cboLocLop.Size = new Size(249, 33);
            cboLocLop.TabIndex = 3;
            // 
            // lblLocLop
            // 
            lblLocLop.AutoSize = true;
            lblLocLop.Location = new Point(469, 12);
            lblLocLop.Margin = new Padding(4, 0, 4, 0);
            lblLocLop.Name = "lblLocLop";
            lblLocLop.Size = new Size(42, 25);
            lblLocLop.TabIndex = 2;
            lblLocLop.Text = "Lớp";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(90, 8);
            txtTimKiem.Margin = new Padding(4, 4, 4, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Mã, họ tên, email hoặc điện thoại";
            txtTimKiem.Size = new Size(355, 31);
            txtTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(10, 12);
            lblTimKiem.Margin = new Padding(4, 0, 4, 0);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(76, 25);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Từ khóa";
            // 
            // pnlList
            // 
            pnlList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlList.BackColor = Color.White;
            pnlList.BorderStyle = BorderStyle.FixedSingle;
            pnlList.Controls.Add(lblBatBuoc);
            pnlList.Controls.Add(lblHuongDan);
            pnlList.Controls.Add(dgvSinhVien);
            pnlList.Controls.Add(lblTongSo);
            pnlList.Controls.Add(lblListTitle);
            pnlList.Location = new Point(25, 428);
            pnlList.Margin = new Padding(4, 4, 4, 4);
            pnlList.Name = "pnlList";
            pnlList.Size = new Size(1277, 362);
            pnlList.TabIndex = 5;
            // 
            // lblBatBuoc
            // 
            lblBatBuoc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblBatBuoc.AutoSize = true;
            lblBatBuoc.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblBatBuoc.ForeColor = Color.FromArgb(108, 117, 125);
            lblBatBuoc.Location = new Point(1056, 328);
            lblBatBuoc.Margin = new Padding(4, 0, 4, 0);
            lblBatBuoc.Name = "lblBatBuoc";
            lblBatBuoc.Size = new Size(268, 25);
            lblBatBuoc.TabIndex = 4;
            lblBatBuoc.Text = "Các trường có dấu * là bắt buộc.";
            // 
            // lblHuongDan
            // 
            lblHuongDan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHuongDan.AutoSize = true;
            lblHuongDan.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblHuongDan.ForeColor = Color.FromArgb(108, 117, 125);
            lblHuongDan.Location = new Point(10, 328);
            lblHuongDan.Margin = new Padding(4, 0, 4, 0);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(464, 25);
            lblHuongDan.TabIndex = 3;
            lblHuongDan.Text = "Chọn một dòng để xem, sửa hoặc xóa thông tin sinh viên.";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AllowUserToResizeRows = false;
            dgvSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSinhVien.BackgroundColor = Color.White;
            dgvSinhVien.BorderStyle = BorderStyle.None;
            dgvSinhVien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(235, 243, 251);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(235, 243, 251);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvSinhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvSinhVien.ColumnHeadersHeight = 35;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { colMaSV, colHoTen, colNgaySinh, colGioiTinh, colEmail, colDienThoai, colDiem, colLop, colTrangThai });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(222, 237, 251);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvSinhVien.DefaultCellStyle = dataGridViewCellStyle6;
            dgvSinhVien.EnableHeadersVisualStyles = false;
            dgvSinhVien.GridColor = Color.FromArgb(230, 230, 230);
            dgvSinhVien.Location = new Point(10, 44);
            dgvSinhVien.Margin = new Padding(4, 4, 4, 4);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.RowTemplate.Height = 32;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(1255, 272);
            dgvSinhVien.TabIndex = 2;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            dgvSinhVien.CellContentClick += dgvSinhVien_CellContentClick;
            // 
            // colMaSV
            // 
            colMaSV.DataPropertyName = "StudentId";
            colMaSV.HeaderText = "Mã SV";
            colMaSV.MinimumWidth = 90;
            colMaSV.Name = "colMaSV";
            colMaSV.ReadOnly = true;
            colMaSV.Width = 90;
            // 
            // colHoTen
            // 
            colHoTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHoTen.DataPropertyName = "FullName";
            colHoTen.FillWeight = 120F;
            colHoTen.HeaderText = "Họ và tên";
            colHoTen.MinimumWidth = 120;
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            // 
            // colNgaySinh
            // 
            colNgaySinh.DataPropertyName = "DateOfBirth";
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.MinimumWidth = 95;
            colNgaySinh.Name = "colNgaySinh";
            colNgaySinh.ReadOnly = true;
            colNgaySinh.Width = 95;
            // 
            // colGioiTinh
            // 
            colGioiTinh.DataPropertyName = "Gender";
            colGioiTinh.HeaderText = "Giới tính";
            colGioiTinh.MinimumWidth = 75;
            colGioiTinh.Name = "colGioiTinh";
            colGioiTinh.ReadOnly = true;
            colGioiTinh.Width = 75;
            // 
            // colEmail
            // 
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 120F;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 120;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colDienThoai
            // 
            colDienThoai.DataPropertyName = "Phone";
            colDienThoai.HeaderText = "Điện thoại";
            colDienThoai.MinimumWidth = 100;
            colDienThoai.Name = "colDienThoai";
            colDienThoai.ReadOnly = true;
            // 
            // colDiem
            // 
            colDiem.DataPropertyName = "Score";
            colDiem.HeaderText = "Điểm";
            colDiem.MinimumWidth = 60;
            colDiem.Name = "colDiem";
            colDiem.ReadOnly = true;
            colDiem.Width = 60;
            // 
            // colLop
            // 
            colLop.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLop.DataPropertyName = "ClassName";
            colLop.FillWeight = 130F;
            colLop.HeaderText = "Lớp";
            colLop.MinimumWidth = 130;
            colLop.Name = "colLop";
            colLop.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "Status";
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 95;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            colTrangThai.Width = 95;
            // 
            // lblTongSo
            // 
            lblTongSo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTongSo.ForeColor = Color.FromArgb(12, 43, 78);
            lblTongSo.Location = new Point(1081, 10);
            lblTongSo.Margin = new Padding(4, 0, 4, 0);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(188, 25);
            lblTongSo.TabIndex = 1;
            lblTongSo.Text = "Tổng số: 4 sinh viên";
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblListTitle.Location = new Point(10, 10);
            lblListTitle.Margin = new Padding(4, 0, 4, 0);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(208, 30);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "Danh sách sinh viên";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(248, 249, 250);
            pnlFooter.BorderStyle = BorderStyle.FixedSingle;
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 803);
            pnlFooter.Margin = new Padding(4, 4, 4, 4);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1328, 37);
            pnlFooter.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(1328, 840);
            Controls.Add(pnlFooter);
            Controls.Add(pnlList);
            Controls.Add(pnlFilter);
            Controls.Add(pnlStudentInfo);
            Controls.Add(lblMainTitle);
            Controls.Add(pnlHeader);
            Margin = new Padding(4, 4, 4, 4);
            MinimumSize = new Size(1182, 736);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng dụng quản lý sinh viên";
            Load += Form1_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlStudentInfo.ResumeLayout(false);
            pnlStudentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiem).EndInit();
            pnlGioiTinh.ResumeLayout(false);
            pnlGioiTinh.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiemTu).EndInit();
            pnlList.ResumeLayout(false);
            pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblAppTitle;
        private Label lblMainTitle;
        private Panel pnlStudentInfo;
        private Panel pnlAccent;
        private Label lblGroupTitle;
        private Label lblMaSV;
        private TextBox txtMaSV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblLop;
        private ComboBox cboLop;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private Panel pnlGioiTinh;
        private RadioButton rdoNam;
        private RadioButton rdoNu;
        private Label lblDiem;
        private NumericUpDown numDiem;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblDienThoai;
        private TextBox txtDienThoai;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Panel pnlFilter;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Label lblLocLop;
        private ComboBox cboLocLop;
        private Label lblDiemTu;
        private NumericUpDown numDiemTu;
        private Button btnTimKiem;
        private Button btnHienThiTatCa;
        private Panel pnlList;
        private Label lblListTitle;
        private Label lblTongSo;
        private DataGridView dgvSinhVien;
        private Label lblHuongDan;
        private Label lblBatBuoc;
        private Panel pnlFooter;
        private DataGridViewTextBoxColumn colMaSV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colNgaySinh;
        private DataGridViewTextBoxColumn colGioiTinh;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDienThoai;
        private DataGridViewTextBoxColumn colDiem;
        private DataGridViewTextBoxColumn colLop;
        private DataGridViewTextBoxColumn colTrangThai;
    }
}
