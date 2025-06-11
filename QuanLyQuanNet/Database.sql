-- Tạo Database
CREATE DATABASE QuanLyQuanNet;
GO

USE QuanLyQuanNet;
GO

-- Bảng Khach - Thông tin khách hàng thành viên
CREATE TABLE Khach (
    MaKhachHang VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    SDT VARCHAR(15),
    Email VARCHAR(50),
    SoDuTaiKhoan INT DEFAULT 0
        CONSTRAINT CHK_Khach_SoDuTaiKhoan CHECK (SoDuTaiKhoan >= 0)
);

-- Bảng NhanVien - Quản lý thông tin nhân viên
CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    ChucVu NVARCHAR(25) NOT NULL,
    LoaiNhanVien NVARCHAR(25) NOT NULL,
    DiaChi NVARCHAR(100),
    SDT VARCHAR(15) UNIQUE,
    NgaySinh DATE,
    NgayVaoLam DATE DEFAULT GETDATE()
);

-- Bảng TaiKhoan - Quản lý các tài khoản đăng nhập trong hệ thống (đã thêm Trạng Thái)
CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(100) NOT NULL,
    VaiTro NVARCHAR(10) NOT NULL
        CONSTRAINT CHK_TaiKhoan_VaiTro CHECK (VaiTro IN ('Admin', 'NhanVien', 'Khach')),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Hoạt động'
        CONSTRAINT CHK_TaiKhoan_TrangThai CHECK (TrangThai IN (N'Hoạt động', N'Khóa')),
    MaNhanVien VARCHAR(10),
    MaKhachHang VARCHAR(10),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKhachHang) REFERENCES Khach(MaKhachHang)
);

-- Bảng Menu - Danh sách món ăn, đồ uống, dịch vụ (đã bao gồm số lượng tồn)
CREATE TABLE Menu (
    MaMon VARCHAR(10) PRIMARY KEY,
    TenMon NVARCHAR(50) NOT NULL UNIQUE,
    Gia INT NOT NULL
        CONSTRAINT CHK_Menu_Gia CHECK (Gia >= 0),
    SoLuongTon INT NOT NULL
        CONSTRAINT CHK_Menu_SoLuongTon CHECK (SoLuongTon >= 0)
);

-- Bảng May - Thông tin các máy tính
CREATE TABLE May (
    SoMay VARCHAR(10) PRIMARY KEY,
    LoaiMay NVARCHAR(20) NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL
        CONSTRAINT CHK_May_TrangThai CHECK (TrangThai IN (N'Sẵn sàng', N'Đang sử dụng', N'Bảo trì')),
    DonGiaGio INT NOT NULL
        CONSTRAINT CHK_May_DonGiaGio CHECK (DonGiaGio > 0)
);

-- Bảng khuyến mãi - Lưu thông tin khuyến mãi
CREATE TABLE KhuyenMai (
    MaKM VARCHAR(10) PRIMARY KEY,
    TenKM NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(200),
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    PhanTramGiam INT CHECK (PhanTramGiam BETWEEN 0 AND 100),
    CONSTRAINT CHK_KhuyenMai_Ngay CHECK (NgayKetThuc >= NgayBatDau)
);

-- Bảng HoaDon - Lưu thông tin sử dụng máy & hóa đơn
CREATE TABLE HoaDon (
    SoHD VARCHAR(10) PRIMARY KEY,
    MaKM VARCHAR(10),
    MaKH VARCHAR(10),
    MaNV VARCHAR(10) NOT NULL,
    SoMay VARCHAR(10) NOT NULL,
    ThoiGianBatDau DATETIME NOT NULL,
    ThoiGianKetThuc DATETIME,
    DonGiaLuuTru INT NOT NULL,
    TienGio INT DEFAULT 0,
    TienDichVu INT DEFAULT 0,
    TongTien INT DEFAULT 0,
    GiamGia INT DEFAULT 0,
    ThanhTien INT DEFAULT 0,
    NgayHoaDon DATETIME DEFAULT GETDATE(),
    HinhThucThanhToan NVARCHAR(20),
    TrangThai NVARCHAR(20) DEFAULT N'Chưa thanh toán'
        CONSTRAINT CHK_HoaDon_TrangThai CHECK (TrangThai IN (N'Đã thanh toán', N'Chưa thanh toán')),
    FOREIGN KEY (MaKM) REFERENCES KhuyenMai(MaKM),
    FOREIGN KEY (MaKH) REFERENCES Khach(MaKhachHang) ON DELETE SET NULL,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (SoMay) REFERENCES May(SoMay)
);

-- Bảng CTHD - Chi tiết hóa đơn (gọi món)
CREATE TABLE CTHD (
    SoHD VARCHAR(10) NOT NULL,
    MaMon VARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL
        CONSTRAINT CHK_CTHD_SoLuong CHECK (SoLuong > 0),
    DonGiaLuuTru INT NOT NULL,
    ThanhTien INT NOT NULL,
    PRIMARY KEY (SoHD, MaMon),
    FOREIGN KEY (SoHD) REFERENCES HoaDon(SoHD) ON DELETE CASCADE,
    FOREIGN KEY (MaMon) REFERENCES Menu(MaMon)
);

-- Bảng PhieuKiemKho - Ghi nhận phiếu kiểm kê cuối ngày
CREATE TABLE PhieuKiemKho (
    MaPhieu VARCHAR(10) PRIMARY KEY,
    NgayKiem DATE NOT NULL DEFAULT GETDATE(),
    MaNhanVienKiem VARCHAR(10) NOT NULL,
    GhiChu NVARCHAR(MAX),
    TrangThai NVARCHAR(20) DEFAULT N'Chờ xác nhận'
        CONSTRAINT CHK_PhieuKiemKho_TrangThai CHECK (TrangThai IN (N'Chờ xác nhận', N'Đã xác nhận', N'Đã hủy')),
    FOREIGN KEY (MaNhanVienKiem) REFERENCES NhanVien(MaNhanVien)
);

-- Bảng ChiTietKiemKho - Chi tiết kiểm kê từng món
CREATE TABLE ChiTietKiemKho (
    MaPhieu VARCHAR(10),
    MaMon VARCHAR(10),
    SoLuongTonHeThong INT NOT NULL,
    SoLuongThucTe INT NOT NULL,
    ChenhLech INT NOT NULL,
    GhiChu NVARCHAR(MAX),
    PRIMARY KEY (MaPhieu, MaMon),
    FOREIGN KEY (MaPhieu) REFERENCES PhieuKiemKho(MaPhieu) ON DELETE CASCADE,
    FOREIGN KEY (MaMon) REFERENCES Menu(MaMon)
);
GO

-- Thêm dữ liệu vào các bảng
-- Bảng Menu - Danh sách món ăn, đồ uống, dịch vụ
INSERT INTO Menu (MaMon, TenMon, Gia, SoLuongTon) VALUES
('M001', N'Coca Cola', 12000, 100),
('M002', N'Pepsi', 12000, 100),
('M003', N'Trà Đào', 15000, 50),
('M004', N'Nước Suối', 8000, 200),
('M005', N'Mì Ly', 15000, 80),
('M006', N'Bánh Snack', 10000, 150),
('M007', N'Cafe Sữa', 18000, 40),
('M008', N'Cafe Đen', 15000, 40),
('M009', N'Sting Dâu', 12000, 100),
('M010', N'Bò Húc', 25000, 70),
('M011', N'Trà Sữa Trân Châu', 25000, 50),
('M012', N'Trà Tắc', 10000, 60),
('M013', N'Trà Chanh', 10000, 60),
('M014', N'Mì Cay', 30000, 30),
('M015', N'Chuột Logitech G102', 450000, 10);

-- Bảng May - Thông tin các máy tính
INSERT INTO May (SoMay, LoaiMay, TrangThai, DonGiaGio) VALUES
('M01', N'Phòng Thường', N'Đang sử dụng', 10000),
('M02', N'Phòng Thường', N'Đang sử dụng', 10000),
('M03', N'Phòng VIP', N'Sẵn sàng', 15000),
('M04', N'Phòng Thường', N'Đang sử dụng', 10000),
('M05', N'Phòng Thường', N'Sẵn sàng', 10000),
('M06', N'Phòng VIP', N'Đang sử dụng', 15000),
('M07', N'Phòng Thường', N'Bảo trì', 10000),
('M08', N'Phòng Thường', N'Đang sử dụng', 10000),
('M09', N'Phòng VIP', N'Đang sử dụng', 15000),
('M10', N'Phòng Thường', N'Sẵn sàng', 10000),
('M11', N'Phòng Thường', N'Đang sử dụng', 10000),
('M12', N'Phòng VIP', N'Đang sử dụng', 15000),
('M13', N'Phòng Thường', N'Bảo trì', 10000),
('M14', N'Phòng Thường', N'Sẵn sàng', 10000),
('M15', N'Phòng VIP', N'Đang sử dụng', 15000);

-- Bảng khuyến mãi lưu thông tin khuyến mãi
INSERT INTO KhuyenMai (MaKM, TenKM, PhanTramGiam, NgayBatDau, NgayKetThuc) VALUES 
('KM01', N'Giảm 10%', 10, '2025-05-01', '2025-06-30'),
('KM02', N'Giảm 20%', 20, '2025-06-01', '2025-06-15'),
('KM03', N'Khuyến mãi giờ vàng', 15, '2025-06-01', '2025-06-10');

-- Bảng Khach - Thông tin khách hàng thành viên 
INSERT INTO Khach (MaKhachHang, HoTen, SDT, Email, SoDuTaiKhoan) VALUES
('KH001', N'Nguyễn Văn A', '0909123456', 'a@gmail.com', 50000),
('KH002', N'Trần Thị B', '0912345678', 'b@yahoo.com', 120000),
('KH003', N'Lê Văn C', NULL, NULL, 0),
('KH004', N'Phạm Thị D', '0987654321', 'd@hotmail.com', 30000),
('KH005', N'Hồ Văn E', '0911111111', 'e@gmail.com', 80000),
('KH006', N'Đỗ Thị F', NULL, NULL, 10000),
('KH007', N'Võ Văn G', '0933333333', NULL, 60000),
('KH008', N'Tăng Thị H', '0922222222', 'h@mail.com', 25000),
('KH009', N'Bùi Văn I', NULL, NULL, 0),
('KH010', N'Đinh Thị K', '0900000000', 'k@outlook.com', 70000),
('KH011', N'Lý Văn L', NULL, NULL, 5000),
('KH012', N'Ngô Thị M', '0988777666', 'm@gmail.com', 15000),
('KH013', N'Trịnh Văn N', NULL, NULL, 0),
('KH014', N'Tống Thị O', '0977665544', NULL, 35000),
('KH015', N'Cao Văn P', '0939393939', 'p@zing.vn', 90000);

-- Bảng NhanVien - Quản lý thông tin nhân viên
INSERT INTO NhanVien (MaNhanVien, HoTen, ChucVu, LoaiNhanVien, DiaChi, SDT, NgaySinh, NgayVaoLam) VALUES
('NV001', N'Nguyễn Thị Mai', N'Lễ tân', N'Thời vụ', N'123 Trần Hưng Đạo', '0901112223', '1995-01-01', '2024-05-01'),
('NV002', N'Trần Văn Long', N'Quản lý', N'Trưởng ca', N'234 Lê Lợi', '0912223334', '1990-05-20', '2023-12-01'),
('NV003', N'Lê Minh Tuấn', N'Thu ngân', N'Toàn thời gian', N'345 Nguyễn Trãi', '0922334455', '1992-08-15', '2024-01-10'),
('NV004', N'Phạm Thị Lan', N'Thu ngân', N'Thời vụ', N'456 Hai Bà Trưng', '0933445566', '1997-03-22', '2024-04-05'),
('NV005', N'Hồ Anh Dũng', N'Lễ tân', N'Thời vụ', N'567 Trường Chinh', '0944556677', '1985-10-10', '2024-02-20'),
('NV006', N'Đỗ Thị Hương', N'Lễ tân', N'Thời vụ', N'678 Lý Thường Kiệt', '0955667788', '1994-07-07', '2024-03-01'),
('NV007', N'Võ Văn Kiệt', N'Thu ngân', N'Toàn thời gian', N'789 Lê Văn Sỹ', '0966778899', '1991-06-30', '2023-11-15'),
('NV008', N'Tăng Minh Đức', N'Quản lý', N'Trưởng ca', N'890 Điện Biên Phủ', '0977889900', '1988-12-25', '2023-10-01'),
('NV009', N'Bùi Thị Nhung', N'Thu ngân', N'Thời vụ', N'901 Cách Mạng Tháng 8', '0988999000', '1996-09-09', '2024-05-05'),
('NV010', N'Đinh Văn Hòa', N'Lễ tân', N'Thời vụ', N'123 Phan Đình Phùng', '0999000111', '1980-02-02', '2024-01-25'),
('NV011', N'Lý Thị Tuyết', N'Lễ tân', N'Thời vụ', N'321 Nguyễn Thái Học', '0900111222', '1993-11-11', '2024-03-15'),
('NV012', N'Ngô Văn Bình', N'Thu ngân', N'Toàn thời gian', N'654 Tô Hiến Thành', '0911222333', '1992-06-06', '2024-04-10'),
('NV013', N'Trịnh Minh Sơn', N'Lễ tân', N'Thời vụ', N'987 Pasteur', '0922333444', '1987-08-08', '2024-02-15'),
('NV014', N'Tống Thị Thu', N'Thu ngân', N'Thời vụ', N'159 Nguyễn Tri Phương', '0933444555', '1995-09-30', '2024-04-20'),
('NV015', N'Cao Văn Nam', N'Quản lý', N'Trưởng ca', N'753 Nguyễn Văn Cừ', '0944555666', '1989-04-04', '2023-09-01');

-- Bảng TaiKhoan - Quản lý các tài khoản đăng nhập trong hệ thống (đã cập nhật dữ liệu)
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, TrangThai, MaNhanVien, MaKhachHang) VALUES
('admin', 'admin@123', 'Admin', N'Hoạt động', NULL, NULL),
('longtv', 'long@123', 'NhanVien', N'Hoạt động', 'NV002', NULL),
('anv', 'khach@123', 'Khach', N'Hoạt động', NULL, 'KH001'),
('lanpt', 'lan@123', 'NhanVien', N'Hoạt động', 'NV004', NULL);

-- Bảng HoaDon - Lưu thông tin sử dụng máy & hóa đơn
INSERT INTO HoaDon (SoHD, MaKM, MaKH, MaNV, SoMay, ThoiGianBatDau, ThoiGianKetThuc, DonGiaLuuTru, TienGio, TienDichVu, GiamGia, ThanhTien, TrangThai, HinhThucThanhToan) VALUES
('HD001', NULL, 'KH001', 'NV001', 'M01', '2025-06-01 10:00:00', '2025-06-01 12:00:00', 10000, 20000, 39000, 0, 59000, N'Đã thanh toán', N'Tiền mặt'),
('HD002', 'KM01', 'KH002', 'NV002', 'M02', '2025-06-01 11:00:00', '2025-06-01 12:00:00', 10000, 10000, 12000, 2200, 19800, N'Đã thanh toán', N'Momo'),
('HD003', NULL, 'KH003', 'NV003', 'M03', '2025-06-01 13:00:00', '2025-06-01 16:00:00', 15000, 45000, 24000, 0, 69000, N'Đã thanh toán', N'Thẻ'),
('HD004', 'KM02', 'KH004', 'NV004', 'M04', '2025-06-01 14:00:00', '2025-06-01 16:00:00', 10000, 20000, 18000, 7600, 30400, N'Đã thanh toán', N'Tiền mặt'),
('HD005', NULL, 'KH005', 'NV005', 'M05', '2025-06-02 09:00:00', '2025-06-02 13:00:00', 10000, 40000, 50000, 0, 90000, N'Đã thanh toán', N'Momo'),
('HD006', 'KM01', 'KH006', 'NV006', 'M06', '2025-06-02 10:00:00', '2025-06-02 11:00:00', 15000, 15000, 15000, 3000, 27000, N'Đã thanh toán', N'Thẻ'),
('HD007', NULL, 'KH007', 'NV007', 'M07', '2025-06-02 11:00:00', '2025-06-02 16:00:00', 10000, 50000, 40000, 0, 90000, N'Đã thanh toán', N'Tiền mặt'),
('HD008', 'KM03', 'KH008', 'NV008', 'M08', '2025-06-03 19:00:00', '2025-06-03 21:00:00', 10000, 20000, 24000, 6600, 37400, N'Đã thanh toán', N'Thẻ'),
('HD009', NULL, 'KH009', 'NV009', 'M09', '2025-06-03 20:00:00', '2025-06-03 23:00:00', 15000, 45000, 15000, 0, 60000, N'Đã thanh toán', N'Momo'),
('HD010', 'KM01', 'KH010', 'NV010', 'M10', '2025-06-04 08:00:00', '2025-06-04 14:00:00', 10000, 60000, 50000, 11000, 99000, N'Đã thanh toán', N'Tiền mặt'),
('HD011', NULL, 'KH011', 'NV011', 'M11', '2025-06-04 09:30:00', '2025-06-04 10:30:00', 10000, 10000, 10000, 0, 20000, N'Đã thanh toán', N'Momo'),
('HD012', 'KM03', 'KH012', 'NV012', 'M12', '2025-06-05 18:00:00', '2025-06-05 20:00:00', 15000, 30000, 30000, 9000, 51000, N'Đã thanh toán', N'Thẻ'),
('HD013', NULL, 'KH013', 'NV013', 'M13', '2025-06-05 19:00:00', '2025-06-05 22:00:00', 10000, 30000, 30000, 0, 60000, N'Đã thanh toán', N'Tiền mặt'),
('HD014', 'KM02', 'KH014', 'NV014', 'M14', '2025-06-06 07:00:00', '2025-06-06 11:00:00', 10000, 40000, 450000, 98000, 392000, N'Đã thanh toán', N'Momo'),
('HD015', NULL, 'KH015', 'NV015', 'M15', '2025-06-07 21:00:00', '2025-06-07 23:00:00', 15000, 30000, 0, 0, 30000, N'Đã thanh toán', N'Thẻ');

-- Bảng CTHD - Chi tiết hóa đơn (gọi món)
INSERT INTO CTHD (SoHD, MaMon, SoLuong, DonGiaLuuTru, ThanhTien) VALUES
('HD001', 'M001', 2, 12000, 24000),
('HD001', 'M005', 1, 15000, 15000),
('HD002', 'M002', 1, 12000, 12000),
('HD003', 'M004', 3, 8000, 24000),
('HD004', 'M007', 1, 18000, 18000),
('HD005', 'M010', 2, 25000, 50000),
('HD006', 'M008', 1, 15000, 15000),
('HD007', 'M006', 4, 10000, 40000),
('HD008', 'M009', 2, 12000, 24000),
('HD009', 'M003', 1, 15000, 15000),
('HD010', 'M011', 2, 25000, 50000),
('HD011', 'M012', 1, 10000, 10000),
('HD012', 'M014', 1, 30000, 30000),
('HD013', 'M013', 3, 10000, 30000),
('HD014', 'M015', 1, 450000, 450000);
GO

SELECT * FROM TaiKhoan;
SELECT * FROM CTHD;
SELECT * FROM HoaDon;
SELECT * FROM NhanVien;
SELECT * FROM Khach;
SELECT * FROM May;
SELECT * FROM Menu;

