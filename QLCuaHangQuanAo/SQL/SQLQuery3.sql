
create database QLCuaHangQuanAo2;
use master;

-- Tạo cơ sở dữ liệu
drop database QuanLyCuaHangQuanAo
CREATE DATABASE QuanLyCuaHangQuanAo2;
GO
USE QuanLyCuaHangQuanAo2;
GO
-- Bảng KhachHang
CREATE TABLE KhachHang (
    MaKhachHang  INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE,
    SoDienThoai NVARCHAR(15),
	GioiTinh NVARCHAR(5),
	NgaySinh Date,
    DiaChi NVARCHAR(255)
);
GO

-- Bảng NhanVien
CREATE TABLE NhanVien (
    MaNhanVien  INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
	GioiTinh NVARCHAR(5),
    Email NVARCHAR(100) UNIQUE	NOT NULL,
	DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(15),
    ChucVu NVARCHAR(50),
    NgayVaoLam DATE,
	TrangThaiLamViec NVARCHAR(50),
    Luong DECIMAL(18, 2)
);
GO

-- Bảng LoaiSanPham
CREATE TABLE LoaiSanPham (
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(100) NOT NULL
);
GO


-- Bảng SanPham
CREATE TABLE SanPham (
    MaSanPham INT PRIMARY KEY IDENTITY(1,1),
    TenSanPham NVARCHAR(100) NOT NULL,
    MaLoai INT,
	MoTa NVARCHAR(255),
	Size NVARCHAR(50) NOT NULL,
    MauSac NVARCHAR(50) NOT NULL,
	HinhAnh VARCHAR(100),
    Gia DECIMAL(18, 2) NOT NULL,
    SoLuongTonKho INT NOT NULL,
    FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai)
);
GO


-- Bảng HoaDan
CREATE TABLE HoaDon (
    MaHoaDon INT PRIMARY KEY IDENTITY(1,1),
    MaKhachHang  int not null,
	MaNhanVien int not null,
    NgayMuaHang DATE NOT NULL,
    TongTien DECIMAL(18, 2) NOT NULL,
    
	TrangThaiThanhToan NVARCHAR(20),
	FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);
GO

-- Bảng ChiTietDonHang
CREATE TABLE ChiTietHoaDon (
    MaChiTietHoaDon INT PRIMARY KEY IDENTITY(1,1),
    MaHoaDon INT,
    MaSanPham INT,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18, 2) NOT NULL,
	ChietKhau DECIMAL(18, 2) DEFAULT 0,  -- Phan tram (10 -> 10%)
    GiaSauChietKhau AS (DonGia * (1 - ChietKhau / 100)), 
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
GO

-- Bảng NhaCungCap
CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY IDENTITY(1,1),
    TenNhaCungCap NVARCHAR(100) NOT NULL,
    NguoiLienHe NVARCHAR(100),
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(15)
);


-- Bảng PhieuNhapHang
CREATE TABLE PhieuNhapHang (
    MaPhieuNhap INT PRIMARY KEY IDENTITY(1,1),
    MaNhaCungCap INT,
    NgayNhapHang DATE NOT NULL,
    TongTien DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);
GO

-- Bảng ChiTietPhieuNhap
CREATE TABLE ChiTietPhieuNhap (

    MaPhieuNhap INT not null,
    MaSanPham INT not null,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhapHang(MaPhieuNhap),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
GO




CREATE TABLE tbl_User(
    TaiKhoan VARCHAR(30) PRIMARY KEY,
    MaNhanVien int NOT NULL,  -- Now only related to employees
    PasswordHash VARCHAR(255),
    PasswordSalt VARCHAR(255),
    Quyen INT, -- 1: Quản lý, 2: Nhân viên
    Status NVARCHAR(20) DEFAULT 'Active', -- 'Active', 'Locked', 'Suspended'
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);



---------------------
INSERT INTO KhachHang ( HoTen, Email, SoDienThoai, GioiTinh, NgaySinh, DiaChi)
VALUES 
( N'Nguyễn Văn A', 'a.nguyen@gmail.com', '0912345678', N'Nam', '1990-01-15', N'123 Đường A, Hà Nội'),
( N'Phạm Thị B', 'b.pham@yahoo.com', '0987654321', N'Nữ', '1985-05-20', N'456 Đường B, TP.HCM'),
( N'Lê Văn C', 'c.le@gmail.com', '0903456789', N'Nam', '1992-03-10', N'789 Đường C, Đà Nẵng');
INSERT INTO KhachHang ( HoTen, Email, SoDienThoai, GioiTinh, NgaySinh, DiaChi)
VALUES 
( N'Trần Thị H', 'h.tran@gmail.com', '0932123456', N'Nữ', '1994-08-22', N'10 Đường H, Hải Phòng'),
( N'Nguyễn Văn K', 'k.nguyen@yahoo.com', '0917654321', N'Nam', '1990-12-15', N'23 Đường K, Huế');
INSERT INTO KhachHang ( HoTen, Email, SoDienThoai, GioiTinh, NgaySinh, DiaChi)
VALUES 
(N'Hoàng Văn L', 'l.hoang@gmail.com', '0901234567', N'Nam', '1995-07-01', N'32 Đường L, Bình Dương'),
(N'Lê Thị M', 'm.le@yahoo.com', '0987654322', N'Nữ', '1988-11-12', N'50 Đường M, Cần Thơ');

SET IDENTITY_INSERT KhachHang ON;
SET IDENTITY_INSERT KhachHang OFF;
INSERT INTO KhachHang(MaKhachHang, HoTen) values (-1, 'Khách hàng tự do')

INSERT INTO NhanVien ( HoTen, GioiTinh, Email, DiaChi, SoDienThoai, ChucVu, NgayVaoLam, TrangThaiLamViec, Luong)
VALUES 
( N'Trần Thị D', N'Nữ', 'd.tran@company.com', N'12 Đường D, Hà Nội', '0912341234', N'Quản lý', '2020-07-01', N'Đang làm việc', 15000000),
(N'Ngô Văn E', N'Nam', 'e.ngo@company.com', N'34 Đường E, TP.HCM', '0934567890', N'Nhân viên', '2021-05-10', N'Đang làm việc', 8000000),
(N'Hoàng Thị F', N'Nữ', 'f.hoang@company.com', N'56 Đường F, Đà Nẵng', '0945678901', N'Nhân viên', '2022-02-25', N'Đang làm việc', 7500000);
INSERT INTO NhanVien ( HoTen, GioiTinh, Email, DiaChi, SoDienThoai, ChucVu, NgayVaoLam, TrangThaiLamViec, Luong)
VALUES 
( N'Phạm Văn G', N'Nam', 'g.pham@company.com', N'78 Đường G, Đà Nẵng', '0921345678', N'Nhân viên', '2023-03-01', N'Đang làm việc', 7000000),
( N'Vũ Thị I', N'Nữ', 'i.vu@company.com', N'90 Đường I, TP.HCM', '0919876543', N'Nhân viên', '2022-09-12', N'Đang làm việc', 7200000);
INSERT INTO NhanVien ( HoTen, GioiTinh, Email, DiaChi, SoDienThoai, ChucVu, NgayVaoLam, TrangThaiLamViec, Luong)
VALUES 
( N'Nguyễn Thị N', N'Nữ', 'n.nguyen@company.com', N'20 Đường N, Nha Trang', '0923456789', N'Nhân viên', '2023-07-15', N'Đang làm việc', 7800000),
(N'Phan Văn O', N'Nam', 'o.phan@company.com', N'40 Đường O, Vũng Tàu', '0912345678', N'Nhân viên', '2023-08-01', N'Đang làm việc', 7500000);


INSERT INTO LoaiSanPham (TenLoai)
VALUES 
(N'Áo'),
(N'Quần '),
(N'Đầm'),
(N'Áo khoác')


-- Sample for category 'Áo'
INSERT INTO SanPham (TenSanPham, MaLoai, MoTa, Size, MauSac, HinhAnh, Gia, SoLuongTonKho)
VALUES 
(N'Áo thun họa tiết', 1, N'Áo thun họa tiết đẹp', 'M', N'Xanh lá', 'aothun_hoatiet.jpg', 250000, 20),
(N'Áo cardigan', 1, N'Áo cardigan nhẹ nhàng', 'L', N'Be', 'ao_cardigan.jpg', 400000, 15),
(N'Áo khoác bomber', 4, N'Áo khoác thời trang', 'M', N'Đen', 'aokhoac_bomber.jpg', 600000, 10),
(N'Áo phông nữ', 1, N'Áo phông nữ, năng động', 'S', N'Trắng', 'aophong_nu.jpg', 180000, 25);

-- Sample for category 'Quần'
INSERT INTO SanPham (TenSanPham, MaLoai, MoTa, Size, MauSac, HinhAnh, Gia, SoLuongTonKho)
VALUES 
(N'Quần short thể thao', 2, N'Quần ngắn, thoải mái', 'M', N'Đen', 'quanshort_thethao.jpg', 200000, 30),
(N'Quần tây công sở', 2, N'Quần tây lịch sự', 'L', N'Xám', 'quantay_congso.jpg', 450000, 20),
(N'Quần lưng cao', 2, N'Quần lưng cao thời trang', 'S', N'Xanh', 'quanlungcao.jpg', 350000, 15),
(N'Quần baggy', 2, N'Quần baggy thoải mái', 'M', N'Trắng', 'quan_baggy.jpg', 300000, 18);

-- Sample for category 'Đầm'
INSERT INTO SanPham (TenSanPham, MaLoai, MoTa, Size, MauSac, HinhAnh, Gia, SoLuongTonKho)
VALUES 
(N'Đầm Xòe', 3, N'Thiết kế đầm xòe cách điệu với cổ sen phối nơ vô cùng nữ tính', 'M', N'Đỏ', 'dam_xoe.jpg', 700000, 5),
(N'Đầm xòe nữ tính', 3, N'Đầm xòe, điệu đà', 'L', N'Hồng', 'dam_xoe.jpg', 600000, 8),
(N'Đầm dạo phố', 3, N'Đầm dạo phố, thoải mái', 'S', N'Xanh dương', 'dam_daophong.jpg', 550000, 12),
(N'Đầm maxi hoa', 3, N'Đầm maxi hoa đẹp', 'M', N'Hồng', 'dam_maxi_hoa.jpg', 750000, 10);

---Sample for áo khoác
INSERT INTO SanPham (TenSanPham, MaLoai, MoTa, Size, MauSac, HinhAnh, Gia, SoLuongTonKho)
VALUES 
(N'Áo khoác gió', 4, N'Áo khoác gió, nhẹ nhàng và thoáng mát', 'M', N'Xám', 'aokhoac_gio.jpg', 550000, 20),
(N'Áo khoác lông', 4, N'Áo khoác lông ấm áp cho mùa đông', 'L', N'Nâu', 'aokhoac_long.jpg', 900000, 10),
(N'Áo khoác chần bông', 4, N'Áo khoác chần bông dày dạn', 'XL', N'Đen', 'aokhoac_chanbong.jpg', 1000000, 5),
(N'Áo khoác jean', 4, N'Áo khoác jean phong cách', 'M', N'Xanh', 'aokhoac_jean.jpg', 700000, 15);

delete HoaDon
INSERT INTO HoaDon VALUES 
(1, 2, '2023-09-10', 1500000, N'Đã thanh toán'),
(2, 3, '2023-09-12', 750000,  N'Đã thanh toán'),
(4, 4, '2023-09-20', 1250000,  N'Đã thanh toán'),
(5, 5, '2023-09-25', 950000,  N'Đã thanh toán'),
(6, 6, '2023-09-30', 1100000,  N'Đã thanh toán'),
(7, 7, '2023-09-29', 850000, N'Đã thanh toánn'),
(6, 6, '2023-10-30', 2100000,  N'Đã thanh toán'),
(7, 7, '2023-09-30', 150000,  N'Đã thanh toán'),
(7, 7, '2023-10-02', 250000, N'Đã thanh toán'),
(7, 7, '2023-10-15', 550000,  N'Đã thanh toán'),
(7, 7, '2023-09-02', 1000000, N'Đã thanh toán');

DBCC CHECKIDENT ('HoaDon', RESEED, 0);
delete ChiTietHoaDon
DBCC CHECKIDENT ('ChiTietHoaDon', RESEED, 0);
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia)
VALUES 
( 1, 3,1, 200000 ),
(2, 1,2, 500000),
( 3, 4,3, 800000);
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia)
VALUES 
( 1, 1,1, 250000),
(2, 6,1, 600000),
(3, 6,1, 600000);
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia)
VALUES 
( 4, 6,1, 600000),
( 5, 12,1, 500000),
( 6, 5,1, 200000);



INSERT INTO NhaCungCap (TenNhaCungCap, NguoiLienHe, DiaChi, SoDienThoai)
VALUES 
(N'Công ty TNHH Thời Trang A', N'Nguyễn Văn B', N'123 Đường H, Hà Nội', '0911234567'),
(N'Công ty CP May Mặc B', N'Phạm Thị C', N'456 Đường I, TP.HCM', '0987654321');

INSERT INTO PhieuNhapHang (MaNhaCungCap, NgayNhapHang, TongTien)
VALUES 
(1, '2023-09-01', 3000000),
(2, '2023-09-05', 5000000);
INSERT INTO PhieuNhapHang (MaNhaCungCap, NgayNhapHang, TongTien)
VALUES 
(1, '2023-09-18', 3500000),
(2, '2023-09-21', 4800000);
INSERT INTO PhieuNhapHang (MaNhaCungCap, NgayNhapHang, TongTien)
VALUES 
(1, '2023-09-30', 4000000),
(2, '2023-09-29', 3200000);



INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, SoLuong, DonGia)
VALUES 
(1, 5, 50, 100000),
(2, 6, 30, 150000);
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, SoLuong, DonGia)
VALUES 
(3, 7, 40, 300000),
(4, 8, 60, 400000);
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSanPham, SoLuong, DonGia)
VALUES 
(5, 7, 40, 300000),
(5, 8, 60, 400000);

INSERT INTO tbl_User (TaiKhoan,MaNhanVien, PasswordHash, PasswordSalt, Quyen, Status)
VALUES 
('tranthid01',1, 'hs', 'salt1', 1, 'Active'),
('ngovane22',2, 'hs', 'salt2', 2, 'Active'),
('hoangthif31',3, 'hs', 'salt3', 2, 'Active');
INSERT INTO tbl_User (TaiKhoan, MaNhanVien, PasswordHash, PasswordSalt, Quyen, Status)
VALUES 
('phamvang04', 4, 'hs', 'salt4', 2, 'Active'),
('vuthiI05', 5, 'hs', 'salt5', 2, 'Active');
INSERT INTO tbl_User (TaiKhoan, MaNhanVien, PasswordHash, PasswordSalt, Quyen, Status)
VALUES 
('nguyenthN06', 6, 'hs', 'salt6', 2, 'Active'),
('phanvanO07', 7, 'hs', 'salt7', 2, 'Active');




--trang chu form
go
CREATE OR ALTER PROCEDURE GetBestSellers
AS
BEGIN
    SELECT TOP 7 SanPham.TenSanPham, SUM(SoLuong) AS SoLuongBan
    FROM ChiTietHoaDon
	JOIN SanPham ON SanPham.MaSanPham = ChiTietHoaDon.MaSanPham
    GROUP BY SanPham.TenSanPham
    ORDER BY SoLuongBan DESC
END
go
CREATE PROCEDURE GetSalesData
AS
BEGIN
    SELECT MaSanPham AS ID, SUM(SoLuong) AS SoLuongBan
    FROM ChiTietHoaDon
    GROUP BY MaSanPham
    ORDER BY SoLuongBan DESC
END
go
CREATE PROCEDURE GetTodayOrdersCount
AS
BEGIN
    SELECT COUNT(*) 
    FROM HoaDon 
    WHERE NgayMuaHang = CAST(GETDATE() AS DATE)
END
go
CREATE PROCEDURE GetTodayTotalRevenue
AS
BEGIN
    SELECT ISNULL(SUM(TongTien), 0) 
    FROM HoaDon 
    WHERE NgayMuaHang = CAST(GETDATE() AS DATE)
END
go
CREATE or alter PROCEDURE GetSalesRevenueData
AS
BEGIN
    SELECT NgayMuaHang, TongTien
    FROM HoaDon
    WHERE NgayMuaHang IS NOT NULL
    AND NgayMuaHang >= DATEADD(MONTH, -1, GETDATE())  -- Lọc dữ liệu trong 1 tháng qua
    ORDER BY NgayMuaHang
END
go

CREATE or alter PROCEDURE LayDoanhThuMoiThangNamHienTai
AS
BEGIN
    -- Tạo bảng tạm thời chứa tất cả các tháng trong năm
    DECLARE @ThangNam TABLE
    (
        Thang INT
    );

    -- Chèn các tháng vào bảng tạm thời
    INSERT INTO @ThangNam (Thang)
    VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9), (10), (11), (12);

    -- Truy vấn doanh thu từng tháng
    SELECT 
        tn.Thang, 
        ISNULL(SUM(hd.TongTien), 0) AS DoanhThu
    FROM 
        @ThangNam tn
    LEFT JOIN 
        HoaDon hd ON tn.Thang = MONTH(hd.NgayMuaHang) AND YEAR(hd.NgayMuaHang) = YEAR(GETDATE())
    GROUP BY 
        tn.Thang
    ORDER BY 
        tn.Thang;
END

exec LayDoanhThuMoiThangNamHienTai;
go

CREATE  PROCEDURE LayTongTienNhapHangHangThangTrongNamHienTai
AS
BEGIN
    -- Tạo bảng tạm thời chứa tất cả các tháng trong năm
    DECLARE @ThangNam TABLE
    (
        Thang INT
    );

    -- Chèn các tháng vào bảng tạm thời
    INSERT INTO @ThangNam (Thang)
    VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9), (10), (11), (12);

    -- Truy vấn tổng số tiền nhập hàng từng tháng
    SELECT 
        tn.Thang, 
        ISNULL(SUM(pn.TongTien), 0) AS TongTienNhapHang
    FROM 
        @ThangNam tn
    LEFT JOIN 
        PhieuNhapHang pn ON tn.Thang = MONTH(pn.NgayNhapHang) AND YEAR(pn.NgayNhapHang) = YEAR(GETDATE())
    GROUP BY 
        tn.Thang
    ORDER BY 
        tn.Thang;
END
go
CREATE PROCEDURE LayTop3NhanVienBanHang
AS
BEGIN
    SELECT TOP 3 
        nv.HoTen, 
        SUM(hd.TongTien) AS DoanhSo
    FROM 
        HoaDon hd
    JOIN 
        NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
	Where nv.TrangThaiLamViec = N'Đang làm việc'
    GROUP BY 
        nv.HoTen
    ORDER BY 
        DoanhSo DESC
END
go
LayTop3NhanVienBanHang
go
SELECT 
    sp.TenSanPham, 
    SUM(cthd.SoLuong) AS TongSoLuong
	FROM ChiTietHoaDon cthd
	JOIN SanPham sp ON cthd.MaSanPham = sp.MaSanPham
	GROUP BY sp.TenSanPham
	ORDER BY TongSoLuong DESC;

--Số lượng tồn kho theo loại sản phẩm
GO
create proc SO_LUONG_TON_KHO_LOAI_SP
AS
BEGIN
	SELECT 
    lsp.TenLoai, 
    SUM(sp.SoLuongTonKho) AS TongSoLuongTon
	FROM SanPham sp
	JOIN LoaiSanPham lsp ON sp.MaLoai = lsp.MaLoai
	GROUP BY lsp.TenLoai;
END
GO

select * from ChiTietHoaDon
select * from SanPham
select * from NhanVien
exec GetBestSellers
exec GetSalesData
exec GetTodayOrdersCount
exec GetSalesRevenueData
exec GetTodayTotalRevenue

--dang nhap form
go
CREATE or alter PROCEDURE ValidateUser
    @TaiKhoan NVARCHAR(50),
    @Password NVARCHAR(256)
AS
BEGIN
    select nv.MaNhanVien,nv.HoTen, us.Quyen
	from tbl_User us
	join NhanVien nv on nv.MaNhanVien = us.MaNhanVien
    WHERE TaiKhoan = @TaiKhoan AND PasswordSalt + PasswordHash = @Password
END
go


exec ValidateUser @TaiKhoan = tranthid01, @Password = 'salt1hs'

go
CREATE PROCEDURE LayTenChucVu
	@MaNhanVien int
as
begin
	select ChucVu from NhanVien where MaNhanVien = 1
end


--ban hang form
select * from LoaiSanPham
go
CREATE PROCEDURE ThemLoaiSanPham
	@TEN_LOAI_SP NVARCHAR(50)
AS
BEGIN
	insert into LoaiSanPham values (@TEN_LOAI_SP);
END
go
BEGIN
	INSERT LoaiSanPham
END
CREATE PROCEDURE GetLoaiSanPham
AS
BEGIN
    SELECT DISTINCT MaLoai, TenLoai
    FROM LoaiSanPham
END
go
CREATE PROCEDURE GetSizeSanPham
AS
BEGIN
    SELECT DISTINCT Size
    FROM SanPham
END
go
CREATE PROCEDURE GetMauSacSanPham
AS
BEGIN
    SELECT DISTINCT MauSac
    FROM SanPham
END
go
CREATE PROCEDURE GetSanPhamList
AS
BEGIN
    SELECT *
    FROM SanPham
END
go
CREATE TRIGGER trg_TruSoLuongTonKho
ON ChiTietHoaDon
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Trừ số lượng tồn kho trong bảng SanPham
    UPDATE SanPham
    SET SoLuongTonKho = SoLuongTonKho - i.SoLuong
    FROM SanPham
    INNER JOIN inserted i ON SanPham.MaSanPham = i.MaSanPham;
END;
GO
select * from SanPham
--ban hang - search
go
CREATE OR ALTER PROCEDURE SearchSanPham
	@TenSP NVARCHAR(50) = NULL,
    @MaLoai INT = NULL,
    @Size NVARCHAR(50) = NULL,
    @MauSac NVARCHAR(50) = NULL
AS
BEGIN
    SELECT sp.TenSanPham, sp.HinhAnh, sp.Gia, sp.Size, sp.MauSac, sp.SoLuongTonKho
    FROM SanPham sp
    WHERE (@MaLoai IS NULL OR sp.MaLoai = @MaLoai)
      AND (@Size IS NULL OR sp.Size = @Size)
      AND (@MauSac IS NULL OR sp.MauSac = @MauSac)
	  AND (@TenSP IS NULL OR sp.TenSanPham LIKE '%' + @TenSP + '%')
END
--ban hang - hoa don
GO
CREATE OR ALTER PROCEDURE InsertHoaDon
	@MaKhachHang int,
	@MaNhanVien int,
	@NgayMuaHang date,
	@TongTien decimal(18,2),
	@TrangThaiThanhToan nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
    INSERT INTO HoaDon VALUES 
	(@MaKhachHang, @MaNhanVien, @NgayMuaHang, @TongTien, @TrangThaiThanhToan);

	SELECT SCOPE_IDENTITY() AS MaHoaDon; -- Trả về ID mới được chèn

END
EXEC InsertHoaDon @MaKhachHang = 1, @MaNhanVien = 1, @NgayMuaHang = '2024-12-12', @TongTien = 1000000, @TrangThaiThanhToan =N'Đã thanh toán';
GO
CREATE or alter PROCEDURE InsertChiTietHoaDon
	@MaHoaDon int,
	@MaSanPham int,
	@DonGia decimal(18,2),
	@SoLuong int,
	@ChietKhau decimal(18,2)
	--@GiaSauChietKhau decimal(18,2)
AS
BEGIN
	INSERT INTO ChiTietHoaDon VALUES
	(@MaHoaDon, @MaSanPham,@SoLuong, @DonGia, @ChietKhau);
END
exec InsertChiTietHoaDon @MaHoaDon = 22, @MaSanPham = 1, @DonGia = 1, @SoLuong = 1, @ChietKhau = 0;

GO
CREATE PROCEDURE GetChiTietHoaDon
    @MaHoaDon INT
AS
BEGIN
    SELECT ct.MaHoaDon,sp.TenSanPham, sp.Size,  sp.MauSac, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
    FROM ChiTietHoaDon ct
    JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
    WHERE ct.MaHoaDon = @MaHoaDon
END

exec GetChiTietHoaDon @MaHoaDon = 1

GO
SELECT MaHoaDon, NgayMuaHang, TongTien, TrangThaiThanhToan FROM HoaDon WHERE MaHoaDon = 20

--quan ly kho form
go
CREATE or alter PROCEDURE AddSanPham
    @TenSanPham NVARCHAR(50),
	@MaLoai INT,
	@MoTa NVARCHAR(100),
	@Size NVARCHAR(10),
    @MauSac NVARCHAR(20),
	@HinhAnh NVARCHAR(200),
    @Gia DECIMAL,
    @SoLuongTonKho INT

AS
BEGIN
    INSERT INTO SanPham (TenSanPham,MaLoai,MoTa,Size, MauSac,HinhAnh, Gia, SoLuongTonKho)
    VALUES (@TenSanPham, @MaLoai,@MoTa, @Size, @MauSac, @HinhAnh, @Gia, @SoLuongTonKho);
END;
go
CREATE PROCEDURE GetSanPhamById
    @MaSanPham INT
AS
BEGIN
    SELECT MaSanPham, TenSanPham,MaLoai,MoTa,Size, MauSac,HinhAnh, Gia, SoLuongTonKho
    FROM SanPham
    WHERE MaSanPham = @MaSanPham;
END;
go
CREATE PROCEDURE DeleteSanPhamByID
    @MaSanPham INT
AS
BEGIN
    DELETE FROM SanPham WHERE MaSanPham = @MaSanPham;
END;
GO
exec DeleteSanPhamByID @MaSanPham = 17
go
CREATE PROCEDURE UpdateSanPham
    @MaSanPham INT,
    @TenSanPham NVARCHAR(50),
	@MaLoai INT,
	@MoTa NVARCHAR(100),
	@Size NVARCHAR(10),
    @MauSac NVARCHAR(20),
	@HinhAnh NVARCHAR(200),
    @Gia DECIMAL,
    @SoLuongTonKho INT
AS
BEGIN
    UPDATE SanPham
    SET 
        TenSanPham = @TenSanPham,
        MauSac = @MauSac,
        Gia = @Gia,
        MaLoai = @MaLoai,
        SoLuongTonKho = @SoLuongTonKho,
        MoTa = @MoTa,
        Size = @Size,
        HinhAnh = @HinhAnh
    WHERE MaSanPham = @MaSanPham;
END;
go
CREATE PROC SearchSanPhamByName
	@TenSanPham Nvarchar(50)
AS
BEGIN
	SELECT * FROM SanPham WHERE TenSanPham LIKE '%'+ @TenSanPham + '%';
END
EXEC SearchSanPhamByName @TenSanPham = 'áo';
--ql nhan vien form
go
CREATE or alter PROCEDURE InsertNhanVien
    @HoTen NVARCHAR(50),
    @GioiTinh NVARCHAR(10),
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(100),
    @SoDienThoai NVARCHAR(15),
    @ChucVu NVARCHAR(50),
    @NgayVaoLam DATETIME,
    @Luong DECIMAL(18, 2),
    @TrangThaiLamViec NVARCHAR(20)
AS
BEGIN
    INSERT INTO NhanVien (HoTen, GioiTinh, Email, DiaChi, SoDienThoai, ChucVu, NgayVaoLam, Luong, TrangThaiLamViec)
    VALUES (@HoTen, @GioiTinh, @Email, @DiaChi, @SoDienThoai, @ChucVu, @NgayVaoLam, @Luong, @TrangThaiLamViec);

	SELECT SCOPE_IDENTITY() AS MaNhanVienMoi;
END;

EXEC InsertNhanVien 
    @HoTen = N'Nguyen Van A', 
    @GioiTinh = N'Male', 
    @Email = N'nguyenvana@example.com', 
    @DiaChi = N'123 Đường ABC, Quận 1, TP.HCM', 
    @SoDienThoai = N'0901234567', 
    @ChucVu = N'Nhân viên', 
    @NgayVaoLam = '2024-12-10', 
    @Luong = 10000000.00, 
    @TrangThaiLamViec = N'Đang làm việc';

	

go
CREATE PROCEDURE UpdateNhanVien
    @MaNhanVien INT,
    @HoTen NVARCHAR(50),
    @GioiTinh NVARCHAR(10),
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(100),
    @SoDienThoai NVARCHAR(15),
    @ChucVu NVARCHAR(50),
    @NgayVaoLam DATETIME,
    @Luong DECIMAL(18, 2),
    @TrangThaiLamViec NVARCHAR(20)
AS
BEGIN
    UPDATE NhanVien
    SET HoTen = @HoTen,
        GioiTinh = @GioiTinh,
        Email = @Email,
        DiaChi = @DiaChi,
        SoDienThoai = @SoDienThoai,
        ChucVu = @ChucVu,
        NgayVaoLam = @NgayVaoLam,
        Luong = @Luong,
        TrangThaiLamViec = @TrangThaiLamViec
    WHERE MaNhanVien = @MaNhanVien;
END;
go
CREATE or alter PROCEDURE DeleteNhanVien
    @MaNhanVien INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM HoaDon WHERE MaNhanVien = @MaNhanVien)
    BEGIN
        -- Employee exists in HoaDon; cannot delete
        RETURN -1;
    END
    ELSE
    BEGIN
        DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien;
        RETURN 0; -- Indicate success
    END
END

exec DeleteNhanVien @MaNhanVien = 38

--khach hang
go
CREATE PROCEDURE InsertKhachHang
    @HoTen NVARCHAR(50),
    @Email NVARCHAR(50),
    @SoDienThoai NVARCHAR(20),
    @GioiTinh NVARCHAR(10),
    @NgaySinh DATETIME,
    @DiaChi NVARCHAR(100)
AS
BEGIN
    INSERT INTO KhachHang (HoTen, Email, SoDienThoai, GioiTinh, NgaySinh, DiaChi)
    VALUES (@HoTen, @Email, @SoDienThoai, @GioiTinh, @NgaySinh, @DiaChi)
END
go
CREATE PROCEDURE UpdateKhachHang
    @MaKhachHang INT,
    @HoTen NVARCHAR(50),
    @Email NVARCHAR(50),
    @SoDienThoai NVARCHAR(20),
    @GioiTinh NVARCHAR(10),
    @NgaySinh DATETIME,
    @DiaChi NVARCHAR(100)
AS
BEGIN
    UPDATE KhachHang
    SET HoTen = @HoTen, Email = @Email, SoDienThoai = @SoDienThoai, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, DiaChi = @DiaChi
    WHERE MaKhachHang = @MaKhachHang
END
go
CREATE or alter PROCEDURE DeleteKhachHang
    @MaKhachHang INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM HoaDon WHERE MaKhachHang = @MaKhachHang)
    BEGIN
        RETURN -1;
    END
    ELSE
    BEGIN
        DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang;
        RETURN 0; 
    END
END
go
CREATE PROCEDURE SearchKhachHang
    @SearchTerm NVARCHAR(50)
AS
BEGIN
    SELECT * FROM KhachHang
    WHERE HoTen LIKE '%' + @SearchTerm + '%'
       OR MaKhachHang = TRY_CAST(@SearchTerm AS INT)
END
select * from KhachHang
--hoa don
go
CREATE OR ALTER PROCEDURE GetHoaDonKHNV
AS
BEGIN
	select hd.MaHoaDon, kh.HoTen AS KhachHang, nv.HoTen AS NhanVien, hd.NgayMuaHang, hd.TongTien, hd.TrangThaiThanhToan
	from HoaDon hd
	join KhachHang kh on kh.MaKhachHang = hd.MaKhachHang
	join NhanVien nv on nv.MaNhanVien = hd.MaNhanVien
	order by hd.MaHoaDon desc
END
go
CREATE or alter PROCEDURE GetChiTietHoaDonByMaHoaDon
    @MaHoaDon INT
AS
BEGIN
    SELECT cthd.MaChiTietHoaDon, cthd.MaHoaDon, sp.TenSanPham, SoLuong, DonGia, ChietKhau, GiaSauChietKhau
	FROM ChiTietHoaDon cthd
	join SanPham sp on sp.MaSanPham = cthd.MaSanPham 
    WHERE MaHoaDon = @MaHoaDon
	order by cthd.MaChiTietHoaDon desc
END
-- tai khoan
GO
CREATE PROCEDURE GetUsersWithName
AS
BEGIN
	select ac.TaiKhoan, ac.MaNhanVien, nv.HoTen, ac.PasswordHash, ac.PasswordSalt, Quyen, ac.Status
	from tbl_User ac
	join NhanVien nv on nv.MaNhanVien = ac.MaNhanVien
END
go

GO
CREATE PROCEDURE GetMaVaTenKhongCoTKCuaNV
AS
BEGIN
	SELECT nv.MaNhanVien, HoTen
	FROM NhanVien nv
	LEFT JOIN tbl_User u ON nv.MaNhanVien = u.MaNhanVien
	WHERE u.MaNhanVien IS NULL;
END
go
CREATE PROCEDURE InsertUser
    @TaiKhoan NVARCHAR(50),
    @PasswordHash NVARCHAR(50),
    @PasswordSalt NVARCHAR(50),
    @Status NVARCHAR(50),
    @Quyen INT,
    @MaNhanVien INT
AS
BEGIN
    INSERT INTO tbl_User (TaiKhoan,MaNhanVien, PasswordHash, PasswordSalt,Quyen, Status)
    VALUES (@TaiKhoan, @MaNhanVien, @PasswordHash, @PasswordSalt,@Quyen, @Status)
END

select * from tbl_User


go
CREATE PROCEDURE DeleteUser
    @TaiKhoan NVARCHAR(50)
AS
BEGIN
    DELETE FROM tbl_User WHERE TaiKhoan = @TaiKhoan
END
go
CREATE or alter PROCEDURE UpdateUser
    @TaiKhoan NVARCHAR(50),
    @PasswordHash NVARCHAR(50),
    @PasswordSalt NVARCHAR(50),
    @Status NVARCHAR(50),
    @Quyen INT,
    @MaNhanVien INT
AS
BEGIN
    UPDATE tbl_User
    SET PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, Status = @Status, Quyen = @Quyen, MaNhanVien = @MaNhanVien
    WHERE TaiKhoan = @TaiKhoan
END
go
-- tim kiem dua tren ten tai khoan hoac ten nhan vien
select ac.TaiKhoan, ac.MaNhanVien, nv.HoTen, ac.PasswordHash, ac.PasswordSalt, Quyen, ac.Status
from tbl_User ac
join NhanVien nv on nv.MaNhanVien = ac.MaNhanVien
where ac.TaiKhoan LIKE '%' + 'z' + '%' or
	nv.HoTen LIKE '%' + 'Hoang' + '%'
go
CREATE or alter PROCEDURE TimKiemTKByTKVaHoTen
	@Search NVARCHAR(50)
as
begin
	select ac.TaiKhoan, ac.MaNhanVien, nv.HoTen, ac.PasswordHash, ac.PasswordSalt, Quyen, ac.Status
	from tbl_User ac
	join NhanVien nv on nv.MaNhanVien = ac.MaNhanVien
	where ac.TaiKhoan LIKE '%' + @Search + '%' or
		nv.HoTen LIKE '%' +@Search + '%'
end
--nhap hang
go
CREATE or alter PROCEDURE ThemPhieuNhapHang
	@MaNhaCungCap int,
	@NgayNhapHang date,
	@TongTien decimal
as
begin
	insert into PhieuNhapHang values (@MaNhaCungCap, @NgayNhapHang, @TongTien);
	SELECT SCOPE_IDENTITY() AS PhieuNhapHang; -- Trả về ID mới được chèn
end
exec ThemPhieuNhapHang @MaNhaCungCap = 1, @NgayNhapHang = '11/12/2024', @TongTien = 100000
go
create procedure ThemChiTietPhieuNhapHang
	@MaPhieuNhap int,
	@MaSanPham int,
	@SoLuong int,
	@DonGia decimal
as
begin
	insert into ChiTietPhieuNhap values (@MaPhieuNhap, @MaSanPham, @SoLuong, @DonGia);
end
go
CREATE TRIGGER trg_UpdateSoLuongTonKhoNhapHang
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    -- Cập nhật số lượng tồn kho trong bảng SanPham
    UPDATE SanPham
    SET SoLuongTonKho = SoLuongTonKho + i.SoLuong
    FROM SanPham
    INNER JOIN inserted i ON SanPham.MaSanPham = i.MaSanPham;
END;
GO
create proc themNhaCungCap
	@Ten nvarchar(50),
	@NguoiLH nvarchar(50),
	@DiaChi nvarchar(50),
	@SDT nvarchar(11)
as
begin
	insert into NhaCungCap values (@Ten, @NguoiLH, @DiaChi, @SDT);
end
--phieu nhap hang
go

create or alter proc layPhieuNhapHang
as
begin
	select pnh.MaPhieuNhap, ncc.TenNhaCungCap, NgayNhapHang, TongTien, sp.TenSanPham, ctpn.SoLuong, ctpn.Dongia
	from PhieuNhapHang pnh
	join NhaCungCap ncc on ncc.MaNhaCungCap = pnh.MaNhaCungCap
	join ChiTietPhieuNhap ctpn on ctpn.MaPhieuNhap = pnh.MaPhieuNhap
	join SanPham sp on sp.MaSanPham = ctpn.MaSanPham
end
go
create or alter proc timKiemPhieuNhapHang
	@MaPhieuNhap int
as
begin
	select pnh.MaPhieuNhap, ncc.TenNhaCungCap, NgayNhapHang, TongTien, sp.TenSanPham, ctpn.SoLuong, ctpn.Dongia
	from PhieuNhapHang pnh
	join NhaCungCap ncc on ncc.MaNhaCungCap = pnh.MaNhaCungCap
	join ChiTietPhieuNhap ctpn on ctpn.MaPhieuNhap = pnh.MaPhieuNhap
	join SanPham sp on sp.MaSanPham = ctpn.MaSanPham
	where pnh.MaPhieuNhap = @MaPhieuNhap
end

select * from ChiTietPhieuNhap

select ctpn.MaPhieuNhap, sp.TenSanPham, SoLuong, DonGia
from ChiTietPhieuNhap ctpn
join SanPham sp on sp.MaSanPham = ctpn.MaSanPham

--backup
go
create or alter procedure layDanhSachBackup
as
begin
	SELECT 
    database_name, 
    backup_finish_date, 
    CASE 
        WHEN type = 'D' THEN 'Full' 
        WHEN type = 'I' THEN 'Differential' 
        WHEN type = 'L' THEN 'Log' 
        ELSE 'Unknown' 
    END AS BackupType, 
    backup_size / 1024 / 1024 AS BackupSizeMB
	FROM 
		msdb.dbo.backupset
	WHERE 
		database_name = 'QuanLyCuaHangQuanAo2'
	ORDER BY 
		backup_finish_date DESC;
end
--dang ky
go
CREATE PROCEDURE CheckUsernameExists
    @TaiKhoan NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(*) 
    FROM tbl_User 
    WHERE TaiKhoan = @TaiKhoan
END
go
-- Procedure to insert a new tbl_User
CREATE or alter PROCEDURE ThemUser
    @TaiKhoan NVARCHAR(50),
	@MaNhanVien int,
    @PasswordHash NVARCHAR(50),
    @PasswordSalt NVARCHAR(50),
    @Quyen INT,
    @Status NVARCHAR(50)
AS
BEGIN
    INSERT INTO tbl_User (TaiKhoan, MaNhanVien, PasswordHash, PasswordSalt, Quyen, Status)
    VALUES (@TaiKhoan, @MaNhanVien, @PasswordHash, @PasswordSalt, @Quyen, @Status)
END
GO
CREATE  or alter PROCEDURE ThemNhanVien
    @HoTen NVARCHAR(50),
    @ChucVu NVARCHAR(50),
    @NgayVaoLam DATETIME,
    @Email NVARCHAR(50),
    @SoDienThoai NVARCHAR(20),
    @GioiTinh NVARCHAR(10)
AS
BEGIN
    INSERT INTO NhanVien (HoTen, ChucVu, NgayVaoLam, Email, SoDienThoai, GioiTinh)
    VALUES (@HoTen, @ChucVu, @NgayVaoLam, @Email, @SoDienThoai, @GioiTinh)

    SELECT SCOPE_IDENTITY() AS MaNhanVien
END


select * from tbl_User
select * from NhanVien

select * from PhieuNhapHang;
Select * from ChiTietPhieuNhap;
select distinct MaNhaCungCap, TenNhaCungCap from NhaCungCap;
select * from SanPham;
sel
go
select * from NhaCungCap

SELECT 
    name AS TriggerName,
    parent_id AS TableId,
    OBJECT_NAME(parent_id) AS TableName,
    type_desc AS TriggerType,
    create_date AS CreateDate,
    modify_date AS ModifyDate,
    is_disabled AS IsDisabled
FROM sys.triggers;

select * from NhanVien
select * from tbl_User

select MaNhanVien
from NhanVien
where MaNhanVien not in ( select MaNhanVien from tbl_User);
select * from ChiTietHoaDon

SELECT 1 FROM HoaDon WHERE MaKhachHang = 7
SELECT 1 FROM HoaDon WHERE MaNhanVien = 38
select * from NhanVien;
select HoTen from KhachHang where MaKhachHang = 1;
select * from HoaDon;
select * from ChiTietHoaDon;
SELECT * FROM SanPham;
select * from LoaiSanPham;
select * from SanPham

SELECT DISTINCT MaLoai, TenLoai FROM LoaiSanPham
exec SearchSanPham @TenSP = "ca", @MaLoai = 2


use QuanLyCuaHangQuanAo2;

exec GetLoaiSanPham
exec GetSizeSanPham
exec GetMauSacSanPham
exec GetSanPhamList


SELECT MaKhachHang, HoTen FROM KhachHang

select * from KhachHang
update KhachHang set HoTen = N'Khách hàng tự do' where MaKhachHang = -1;
select * from HoaDon
select * from ChiTietHoaDon
select * from PhieuNhapHang
select * from ChiTietPhieuNhap
select * from SanPham
select * from LoaiSanPham
select * from NhanVien
select * from tbl_User

select nv.HoTen
from tbl_User us
join NhanVien nv on nv.MaNhanVien = us.MaNhanVien
where TaiKhoan = 'tranthid01' AND PasswordHash = 'hs'

update tbl_User set TaiKhoan = 'z', PasswordHash = '1', PasswordSalt = '1' where MaNhanVien = 3;