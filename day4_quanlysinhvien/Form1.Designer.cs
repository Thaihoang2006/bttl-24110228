namespace day4_quanlysinhvien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblAppTitle = new Label();
            lblAppIcon = new Label();
            lblMainTitle = new Label();
            lblSubtitle = new Label();
            pnlStudentInfo = new Panel();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            cboTrangThai = new ComboBox();
            lblTrangThai = new Label();
            numDiem = new NumericUpDown();
            lblDiem = new Label();
            cboLop = new ComboBox();
            lblLop = new Label();
            txtDienThoai = new TextBox();
            lblDienThoai = new Label();
            pnlGioiTinh = new Panel();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            lblGioiTinh = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblNgaySinh = new Label();
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
            lblFooterRight = new Label();
            lblFooterLeft = new Label();
            pnlHeader.SuspendLayout();
            pnlStudentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiem).BeginInit();
            pnlGioiTinh.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiemTu).BeginInit();
            pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(12, 43, 78);
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Controls.Add(lblAppIcon);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1062, 38);
            pnlHeader.TabIndex = 99;
            pnlHeader.TabStop = false;
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(48, 8);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(207, 23);
            lblAppTitle.TabIndex = 1;
            lblAppTitle.Text = "Ứng dụng quản lý sinh viên";
            // 
            // lblAppIcon
            // 
            lblAppIcon.BackColor = Color.FromArgb(243, 108, 33);
            lblAppIcon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAppIcon.ForeColor = Color.White;
            lblAppIcon.Location = new Point(14, 6);
            lblAppIcon.Name = "lblAppIcon";
            lblAppIcon.Size = new Size(26, 26);
            lblAppIcon.TabIndex = 0;
            lblAppIcon.Text = "S";
            lblAppIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMainTitle
            // 
            lblMainTitle.AutoSize = true;
            lblMainTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(12, 43, 78);
            lblMainTitle.Location = new Point(20, 50);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(295, 37);
            lblMainTitle.TabIndex = 98;
            lblMainTitle.Text = "QUẢN LÝ SINH VIÊN";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblSubtitle.Location = new Point(695, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(346, 20);
            lblSubtitle.TabIndex = 97;
            lblSubtitle.Text = "Bài tập Windows Forms • Quan hệ SchoolClass 1 — n Student";
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
            pnlStudentInfo.Controls.Add(numDiem);
            pnlStudentInfo.Controls.Add(lblDiem);
            pnlStudentInfo.Controls.Add(cboLop);
            pnlStudentInfo.Controls.Add(lblLop);
            pnlStudentInfo.Controls.Add(txtDienThoai);
            pnlStudentInfo.Controls.Add(lblDienThoai);
            pnlStudentInfo.Controls.Add(pnlGioiTinh);
            pnlStudentInfo.Controls.Add(lblGioiTinh);
            pnlStudentInfo.Controls.Add(txtHoTen);
            pnlStudentInfo.Controls.Add(lblHoTen);
            pnlStudentInfo.Controls.Add(txtEmail);
            pnlStudentInfo.Controls.Add(lblEmail);
            pnlStudentInfo.Controls.Add(dtpNgaySinh);
            pnlStudentInfo.Controls.Add(lblNgaySinh);
            pnlStudentInfo.Controls.Add(txtMaSV);
            pnlStudentInfo.Controls.Add(lblMaSV);
            pnlStudentInfo.Controls.Add(lblGroupTitle);
            pnlStudentInfo.Controls.Add(pnlAccent);
            pnlStudentInfo.Location = new Point(20, 92);
            pnlStudentInfo.Name = "pnlStudentInfo";
            pnlStudentInfo.Size = new Size(1022, 192);
            pnlStudentInfo.TabIndex = 0;
            pnlStudentInfo.TabStop = false;
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(116, 33);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(190, 27);
            txtMaSV.TabIndex = 0;
            txtMaSV.TextChanged += txtMaSV_TextChanged;
            txtMaSV.Leave += txtMaSV_Leave;
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.Location = new Point(14, 36);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(101, 20);
            lblMaSV.TabIndex = 96;
            lblMaSV.Text = "Mã sinh viên *";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(116, 72);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(190, 27);
            dtpNgaySinh.TabIndex = 1;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(14, 75);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(74, 20);
            lblNgaySinh.TabIndex = 95;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(116, 111);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(190, 27);
            txtEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(14, 115);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(56, 20);
            lblEmail.TabIndex = 94;
            lblEmail.Text = "Email *";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(415, 33);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(230, 27);
            txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(328, 36);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(83, 20);
            lblHoTen.TabIndex = 93;
            lblHoTen.Text = "Họ và tên *";
            // 
            // pnlGioiTinh
            // 
            pnlGioiTinh.Controls.Add(rdoNu);
            pnlGioiTinh.Controls.Add(rdoNam);
            pnlGioiTinh.Location = new Point(415, 71);
            pnlGioiTinh.Name = "pnlGioiTinh";
            pnlGioiTinh.Size = new Size(230, 29);
            pnlGioiTinh.TabIndex = 4;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Checked = true;
            rdoNam.Location = new Point(3, 3);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(62, 24);
            rdoNam.TabIndex = 0;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(102, 3);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(50, 24);
            rdoNu.TabIndex = 1;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(328, 75);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(65, 20);
            lblGioiTinh.TabIndex = 92;
            lblGioiTinh.Text = "Giới tính";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(415, 111);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(230, 27);
            txtDienThoai.TabIndex = 5;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Location = new Point(328, 115);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(87, 20);
            lblDienThoai.TabIndex = 91;
            lblDienThoai.Text = "Điện thoại *";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(748, 33);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(259, 28);
            cboLop.TabIndex = 6;
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(668, 36);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(73, 20);
            lblLop.TabIndex = 90;
            lblLop.Text = "Lớp học *";
            // 
            // numDiem
            // 
            numDiem.DecimalPlaces = 1;
            numDiem.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numDiem.Location = new Point(748, 72);
            numDiem.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numDiem.Name = "numDiem";
            numDiem.Size = new Size(259, 27);
            numDiem.TabIndex = 7;
            numDiem.Value = new decimal(new int[] { 85, 0, 0, 65536 });
            // 
            // lblDiem
            // 
            lblDiem.AutoSize = true;
            lblDiem.Location = new Point(668, 75);
            lblDiem.Name = "lblDiem";
            lblDiem.Size = new Size(54, 20);
            lblDiem.TabIndex = 89;
            lblDiem.Text = "Điểm *";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Location = new Point(748, 111);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(259, 28);
            cboTrangThai.TabIndex = 8;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(668, 115);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(75, 20);
            lblTrangThai.TabIndex = 88;
            lblTrangThai.Text = "Trạng thái";
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThem.BackColor = Color.FromArgb(25, 135, 84);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(671, 150);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(76, 32);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSua.BackColor = Color.FromArgb(13, 110, 253);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(753, 150);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(76, 32);
            btnSua.TabIndex = 10;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(835, 150);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(76, 32);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(108, 117, 125);
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(917, 150);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 32);
            btnLamMoi.TabIndex = 12;
            btnLamMoi.Text = "↻ Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // lblGroupTitle
            // 
            lblGroupTitle.AutoSize = true;
            lblGroupTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblGroupTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblGroupTitle.Location = new Point(18, 5);
            lblGroupTitle.Name = "lblGroupTitle";
            lblGroupTitle.Size = new Size(183, 25);
            lblGroupTitle.TabIndex = 87;
            lblGroupTitle.Text = "Thông tin sinh viên";
            // 
            // pnlAccent
            // 
            pnlAccent.BackColor = Color.FromArgb(230, 81, 0);
            pnlAccent.Location = new Point(8, 7);
            pnlAccent.Name = "pnlAccent";
            pnlAccent.Size = new Size(5, 20);
            pnlAccent.TabIndex = 86;
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
            pnlFilter.Location = new Point(20, 292);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1022, 42);
            pnlFilter.TabIndex = 1;
            pnlFilter.TabStop = false;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(72, 6);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Mã, họ tên, email hoặc điện thoại";
            txtTimKiem.Size = new Size(285, 27);
            txtTimKiem.TabIndex = 13;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Location = new Point(8, 10);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(62, 20);
            lblTimKiem.TabIndex = 85;
            lblTimKiem.Text = "Từ khóa";
            // 
            // cboLocLop
            // 
            cboLocLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLop.FormattingEnabled = true;
            cboLocLop.Location = new Point(415, 6);
            cboLocLop.Name = "cboLocLop";
            cboLocLop.Size = new Size(200, 28);
            cboLocLop.TabIndex = 14;
            // 
            // lblLocLop
            // 
            lblLocLop.AutoSize = true;
            lblLocLop.Location = new Point(375, 10);
            lblLocLop.Name = "lblLocLop";
            lblLocLop.Size = new Size(34, 20);
            lblLocLop.TabIndex = 84;
            lblLocLop.Text = "Lớp";
            // 
            // numDiemTu
            // 
            numDiemTu.DecimalPlaces = 1;
            numDiemTu.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numDiemTu.Location = new Point(700, 6);
            numDiemTu.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numDiemTu.Name = "numDiemTu";
            numDiemTu.Size = new Size(68, 27);
            numDiemTu.TabIndex = 15;
            // 
            // lblDiemTu
            // 
            lblDiemTu.AutoSize = true;
            lblDiemTu.Location = new Point(632, 10);
            lblDiemTu.Name = "lblDiemTu";
            lblDiemTu.Size = new Size(63, 20);
            lblDiemTu.TabIndex = 83;
            lblDiemTu.Text = "Điểm từ";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(13, 110, 253);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(782, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 32);
            btnTimKiem.TabIndex = 16;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnHienThiTatCa
            // 
            btnHienThiTatCa.BackColor = Color.FromArgb(248, 249, 250);
            btnHienThiTatCa.FlatStyle = FlatStyle.System;
            btnHienThiTatCa.Font = new Font("Segoe UI", 9F);
            btnHienThiTatCa.Location = new Point(888, 4);
            btnHienThiTatCa.Name = "btnHienThiTatCa";
            btnHienThiTatCa.Size = new Size(119, 32);
            btnHienThiTatCa.TabIndex = 17;
            btnHienThiTatCa.Text = "Hiển thị tất cả";
            btnHienThiTatCa.UseVisualStyleBackColor = false;
            btnHienThiTatCa.Click += btnHienThiTatCa_Click;
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
            pnlList.Location = new Point(20, 342);
            pnlList.Name = "pnlList";
            pnlList.Size = new Size(1022, 290);
            pnlList.TabIndex = 2;
            pnlList.TabStop = false;
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 251);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(235, 243, 251);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSinhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSinhVien.ColumnHeadersHeight = 35;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { colMaSV, colHoTen, colNgaySinh, colGioiTinh, colEmail, colDienThoai, colDiem, colLop, colTrangThai });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(222, 237, 251);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSinhVien.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSinhVien.EnableHeadersVisualStyles = false;
            dgvSinhVien.GridColor = Color.FromArgb(230, 230, 230);
            dgvSinhVien.Location = new Point(8, 35);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.RowTemplate.Height = 32;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(1004, 218);
            dgvSinhVien.TabIndex = 18;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            dgvSinhVien.CellPainting += dgvSinhVien_CellPainting;
            // 
            // colMaSV
            // 
            colMaSV.DataPropertyName = "MaSV";
            colMaSV.HeaderText = "Mã SV";
            colMaSV.MinimumWidth = 90;
            colMaSV.Name = "colMaSV";
            colMaSV.ReadOnly = true;
            colMaSV.Width = 90;
            // 
            // colHoTen
            // 
            colHoTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 120F;
            colHoTen.HeaderText = "Họ và tên";
            colHoTen.MinimumWidth = 120;
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            // 
            // colNgaySinh
            // 
            colNgaySinh.DataPropertyName = "NgaySinh";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            colNgaySinh.DefaultCellStyle = dataGridViewCellStyle3;
            colNgaySinh.HeaderText = "Ngày sinh";
            colNgaySinh.MinimumWidth = 95;
            colNgaySinh.Name = "colNgaySinh";
            colNgaySinh.ReadOnly = true;
            colNgaySinh.Width = 95;
            // 
            // colGioiTinh
            // 
            colGioiTinh.DataPropertyName = "GioiTinh";
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
            colDienThoai.DataPropertyName = "DienThoai";
            colDienThoai.HeaderText = "Điện thoại";
            colDienThoai.MinimumWidth = 100;
            colDienThoai.Name = "colDienThoai";
            colDienThoai.ReadOnly = true;
            colDienThoai.Width = 100;
            // 
            // colDiem
            // 
            colDiem.DataPropertyName = "Diem";
            colDiem.HeaderText = "Điểm";
            colDiem.MinimumWidth = 60;
            colDiem.Name = "colDiem";
            colDiem.ReadOnly = true;
            colDiem.Width = 60;
            // 
            // colLop
            // 
            colLop.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLop.DataPropertyName = "TenLop";
            colLop.FillWeight = 130F;
            colLop.HeaderText = "Lớp";
            colLop.MinimumWidth = 130;
            colLop.Name = "colLop";
            colLop.ReadOnly = true;
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
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
            lblTongSo.Location = new Point(865, 8);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(150, 21);
            lblTongSo.TabIndex = 82;
            lblTongSo.Text = "Tổng số: 4 sinh viên";
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblListTitle.Location = new Point(8, 8);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(183, 25);
            lblListTitle.TabIndex = 81;
            lblListTitle.Text = "Danh sách sinh viên";
            // 
            // lblBatBuoc
            // 
            lblBatBuoc.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblBatBuoc.AutoSize = true;
            lblBatBuoc.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblBatBuoc.ForeColor = Color.FromArgb(108, 117, 125);
            lblBatBuoc.Location = new Point(845, 262);
            lblBatBuoc.Name = "lblBatBuoc";
            lblBatBuoc.Size = new Size(167, 20);
            lblBatBuoc.TabIndex = 80;
            lblBatBuoc.Text = "Các trường có dấu * là bắt buộc.";
            // 
            // lblHuongDan
            // 
            lblHuongDan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblHuongDan.AutoSize = true;
            lblHuongDan.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblHuongDan.ForeColor = Color.FromArgb(108, 117, 125);
            lblHuongDan.Location = new Point(8, 262);
            lblHuongDan.Name = "lblHuongDan";
            lblHuongDan.Size = new Size(295, 20);
            lblHuongDan.TabIndex = 79;
            lblHuongDan.Text = "Chọn một dòng để xem, sửa hoặc xóa thông tin sinh viên.";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(248, 249, 250);
            pnlFooter.BorderStyle = BorderStyle.FixedSingle;
            pnlFooter.Controls.Add(lblFooterRight);
            pnlFooter.Controls.Add(lblFooterLeft);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 642);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1062, 30);
            pnlFooter.TabIndex = 95;
            pnlFooter.TabStop = false;
            // 
            // lblFooterRight
            // 
            lblFooterRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblFooterRight.AutoSize = true;
            lblFooterRight.Font = new Font("Segoe UI", 8.5F);
            lblFooterRight.ForeColor = Color.FromArgb(108, 117, 125);
            lblFooterRight.Location = new Point(782, 4);
            lblFooterRight.Name = "lblFooterRight";
            lblFooterRight.Size = new Size(270, 19);
            lblFooterRight.TabIndex = 1;
            lblFooterRight.Text = "Thêm • Sửa • Xóa • Tìm kiếm • Lọc theo lớp";
            // 
            // lblFooterLeft
            // 
            lblFooterLeft.AutoSize = true;
            lblFooterLeft.Font = new Font("Segoe UI", 8.5F);
            lblFooterLeft.ForeColor = Color.FromArgb(108, 117, 125);
            lblFooterLeft.Location = new Point(10, 4);
            lblFooterLeft.Name = "lblFooterLeft";
            lblFooterLeft.Size = new Size(335, 19);
            lblFooterLeft.TabIndex = 0;
            lblFooterLeft.Text = "Bài tập: xây dựng Windows Forms quản lý sinh viên theo lớp";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(1062, 672);
            Controls.Add(pnlFooter);
            Controls.Add(pnlList);
            Controls.Add(pnlFilter);
            Controls.Add(pnlStudentInfo);
            Controls.Add(lblSubtitle);
            Controls.Add(lblMainTitle);
            Controls.Add(pnlHeader);
            MinimumSize = new Size(950, 600);
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
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel pnlHeader;
        private Label lblAppTitle;
        private Label lblAppIcon;
        private Label lblMainTitle;
        private Label lblSubtitle;
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
        private Label lblFooterLeft;
        private Label lblFooterRight;
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
