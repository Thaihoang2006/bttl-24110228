namespace day4_quanlysinhvien
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            groupInfo = new GroupBox();
            label1 = new Label();
            lblMaSV = new Label();
            lblHoTen = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblNgaySinh = new Label();
            groupInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(60, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(379, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += label1_Click;
            // 
            // groupInfo
            // 
            groupInfo.Controls.Add(lblNgaySinh);
            groupInfo.Controls.Add(dtpNgaySinh);
            groupInfo.Controls.Add(lblHoTen);
            groupInfo.Controls.Add(lblMaSV);
            groupInfo.Controls.Add(label1);
            groupInfo.Font = new Font("Segoe UI", 15F);
            groupInfo.Location = new Point(60, 138);
            groupInfo.Name = "groupInfo";
            groupInfo.Size = new Size(1346, 332);
            groupInfo.TabIndex = 1;
            groupInfo.TabStop = false;
            groupInfo.Text = "Thông tin sinh viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 43);
            label1.Name = "label1";
            label1.Size = new Size(97, 41);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.FlatStyle = FlatStyle.System;
            lblMaSV.Font = new Font("Segoe UI", 13F);
            lblMaSV.Location = new Point(11, 48);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(165, 36);
            lblMaSV.TabIndex = 1;
            lblMaSV.Text = "Mã sinh viên:";
            lblMaSV.Click += label2_Click;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 13F);
            lblHoTen.Location = new Point(407, 47);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(131, 36);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ và tên:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(161, 109);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(300, 47);
            dtpNgaySinh.TabIndex = 3;
            dtpNgaySinh.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Font = new Font("Segoe UI", 13F);
            lblNgaySinh.Location = new Point(11, 120);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(129, 36);
            lblNgaySinh.TabIndex = 4;
            lblNgaySinh.Text = "Ngày sinh";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1622, 1013);
            Controls.Add(groupInfo);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            groupInfo.ResumeLayout(false);
            groupInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox groupInfo;
        private Label lblMaSV;
        private Label label1;
        private Label lblHoTen;
        private DateTimePicker dtpNgaySinh;
        private Label lblNgaySinh;
    }
}
