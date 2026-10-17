-- ========================================================
-- KỊCH BẢN TẠO CƠ SỞ DỮ LIỆU: StudentManagementDB
-- Phục vụ bài học ADO.NET - GV: Chu Thị Minh Huệ
-- ========================================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'StudentManagementDB')
BEGIN
    CREATE DATABASE StudentManagementDB;
END
GO

USE StudentManagementDB;
GO

-- 1. Bảng LopHoc (Danh mục lớp học)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LopHoc')
BEGIN
    CREATE TABLE LopHoc (
        MaLop NVARCHAR(20) PRIMARY KEY,
        TenLop NVARCHAR(100) NOT NULL
    );
END
GO

-- 2. Bảng SinhVien (Thông tin sinh viên)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SinhVien')
BEGIN
    CREATE TABLE SinhVien (
        MaSV NVARCHAR(20) PRIMARY KEY,
        HoTen NVARCHAR(100) NOT NULL,
        NgaySinh DATE NOT NULL,
        GioiTinh NVARCHAR(10) NOT NULL,
        Email NVARCHAR(100) NOT NULL,
        SoDienThoai NVARCHAR(20) NOT NULL,
        Diem FLOAT NOT NULL DEFAULT 0.0,
        MaLop NVARCHAR(20) NOT NULL,
        TenLop NVARCHAR(100) NULL,
        TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang học',
        CONSTRAINT FK_SinhVien_LopHoc FOREIGN KEY (MaLop) REFERENCES LopHoc(MaLop) ON UPDATE CASCADE ON DELETE NO ACTION
    );
END
GO

-- 3. Nạp dữ liệu mẫu ban đầu
MERGE INTO LopHoc AS target
USING (VALUES 
    (N'KTPM01', N'Kỹ thuật phần mềm 01'),
    (N'TTNT01', N'Trí tuệ nhân tạo 01'),
    (N'KHDL01', N'Khoa học dữ liệu 01')
) AS source (MaLop, TenLop)
ON target.MaLop = source.MaLop
WHEN NOT MATCHED THEN
    INSERT (MaLop, TenLop) VALUES (source.MaLop, source.TenLop);
GO

MERGE INTO SinhVien AS target
USING (VALUES 
    (N'SV000123', N'Nguyễn Văn An', '2006-08-15', N'Nam', N'an.nv@vju.ac.vn', N'0912345678', 8.5, N'KTPM01', N'Kỹ thuật phần mềm 01', N'Đang học'),
    (N'SV000124', N'Trần Minh Anh', '2006-01-22', N'Nữ', N'anh.tm@vju.ac.vn', N'0987654321', 9.0, N'TTNT01', N'Trí tuệ nhân tạo 01', N'Đang học'),
    (N'SV000125', N'Lê Hoàng Bình', '2006-05-09', N'Nam', N'binh.lh@vju.ac.vn', N'0355556677', 7.4, N'KTPM01', N'Kỹ thuật phần mềm 01', N'Đang học'),
    (N'SV000126', N'Đỗ Thị Hồng', '2006-11-30', N'Nữ', N'hong.dt@vju.ac.vn', N'0777888999', 8.1, N'KHDL01', N'Khoa học dữ liệu 01', N'Đang học')
) AS source (MaSV, HoTen, NgaySinh, GioiTinh, Email, SoDienThoai, Diem, MaLop, TenLop, TrangThai)
ON target.MaSV = source.MaSV
WHEN NOT MATCHED THEN
    INSERT (MaSV, HoTen, NgaySinh, GioiTinh, Email, SoDienThoai, Diem, MaLop, TenLop, TrangThai)
    VALUES (source.MaSV, source.HoTen, source.NgaySinh, source.GioiTinh, source.Email, source.SoDienThoai, source.Diem, source.MaLop, source.TenLop, source.TrangThai);
GO
