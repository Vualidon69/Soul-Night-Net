------


-- Tạo database
CREATE DATABASE QuanLyQuanNet3;
GO

USE QuanLyQuanNet;
GO

-- Bảng Menu - Danh sách món ăn, đồ uống, phụ kiện
CREATE TABLE Menu (
    MaMon VARCHAR(10) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    Gia INT NOT NULL -- VND
);

-- Bảng May - Thông tin các máy tính
CREATE TABLE May (
    SoMay VARCHAR(10) PRIMARY KEY,
    LoaiMay NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL
);

-- Bảng Khach - Thông tin khách hàng thành viên
CREATE TABLE Khach (
    MaKhachHang VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15),
    Email VARCHAR(100),
    SoDiem INT DEFAULT 0
);

-- Bảng NhanVien - Quản lý thông tin nhân viên
CREATE TABLE NhanVien (
    ID VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50),
    LoaiNhanVien NVARCHAR(50),
    DiaChi NVARCHAR(200),
    SDT VARCHAR(15),
    NgaySinh DATE,
    NgayVaoLam DATE
);

-- Bảng HoaDon - Lưu thông tin sử dụng máy & hóa đơn
CREATE TABLE HoaDon (
    SoHD VARCHAR(10) PRIMARY KEY,
    MaKH VARCHAR(10) NOT NULL,
    MaNV VARCHAR(10) NOT NULL,
    May VARCHAR(10) NOT NULL,
    SoGio INT NOT NULL,
    ThanhTien INT NOT NULL,
    NgayHoaDon DATE NOT NULL,
    HinhThucTra NVARCHAR(50),

    FOREIGN KEY (MaKH) REFERENCES Khach(MaKhachHang),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(ID),
    FOREIGN KEY (May) REFERENCES May(SoMay)
);

-- Bảng CTHD - Chi tiết hóa đơn (gọi món)
CREATE TABLE CTHD (
    SoHD VARCHAR(10) NOT NULL,
    MaMon VARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL,

    PRIMARY KEY (SoHD, MaMon),
    FOREIGN KEY (SoHD) REFERENCES HoaDon(SoHD),
    FOREIGN KEY (MaMon) REFERENCES Menu(MaMon)
);

INSERT INTO Menu VALUES
('M001', N'Coca Cola', 12000),
('M002', N'Pepsi', 12000),
('M003', N'Trà Đào', 15000),
('M004', N'Nước Suối', 8000),
('M005', N'Mì Ly', 15000),
('M006', N'Bánh Snack', 10000),
('M007', N'Cafe Sữa', 18000),
('M008', N'Cafe Đen', 15000),
('M009', N'Sting Dâu', 12000),
('M010', N'Bò Húc', 25000),
('M011', N'Trà Sữa Trân Châu', 25000),
('M012', N'Trà Tắc', 10000),
('M013', N'Trà Chanh', 10000),
('M014', N'Mì Cay', 30000),
('M015', N'Chuột Logitech G102', 450000);


INSERT INTO May VALUES
('M01', N'Phòng Thường', N'Đang hoạt động'),
('M02', N'Phòng Thường', N'Đang hoạt động'),
('M03', N'Phòng VIP', N'Tạm nghỉ'),
('M04', N'Phòng Thường', N'Đang hoạt động'),
('M05', N'Phòng Thường', N'Tạm nghỉ'),
('M06', N'Phòng VIP', N'Đang hoạt động'),
('M07', N'Phòng Thường', N'Bảo trì'),
('M08', N'Phòng Thường', N'Đang hoạt động'),
('M09', N'Phòng VIP', N'Đang hoạt động'),
('M10', N'Phòng Thường', N'Tạm nghỉ'),
('M11', N'Phòng Thường', N'Đang hoạt động'),
('M12', N'Phòng VIP', N'Đang hoạt động'),
('M13', N'Phòng Thường', N'Bảo trì'),
('M14', N'Phòng Thường', N'Tạm nghỉ'),
('M15', N'Phòng VIP', N'Đang hoạt động');


INSERT INTO Khach VALUES
('KH001', N'Nguyễn Văn A', '0909123456', 'a@gmail.com', 50),
('KH002', N'Trần Thị B', '0912345678', 'b@yahoo.com', 120),
('KH003', N'Lê Văn C', NULL, NULL, 0),
('KH004', N'Phạm Thị D', '0987654321', 'd@hotmail.com', 30),
('KH005', N'Hồ Văn E', '0911111111', 'e@gmail.com', 80),
('KH006', N'Đỗ Thị F', NULL, NULL, 10),
('KH007', N'Võ Văn G', '0933333333', NULL, 60),
('KH008', N'Tăng Thị H', '0922222222', 'h@mail.com', 25),
('KH009', N'Bùi Văn I', NULL, NULL, 0),
('KH010', N'Đinh Thị K', '0900000000', 'k@outlook.com', 70),
('KH011', N'Lý Văn L', NULL, NULL, 5),
('KH012', N'Ngô Thị M', '0988777666', 'm@gmail.com', 15),
('KH013', N'Trịnh Văn N', NULL, NULL, 0),
('KH014', N'Tống Thị O', '0977665544', NULL, 35),
('KH015', N'Cao Văn P', '0939393939', 'p@zing.vn', 90);

INSERT INTO NhanVien VALUES
('NV001', N'Nguyễn Thị Mai', N'Lễ tân', N'Thời vụ', N'123 Trần Hưng Đạo', '0909123456', '1995-01-01', '2024-05-01'),
('NV002', N'Trần Văn Long', N'Quản lý', N'Trưởng ca', N'234 Lê Lợi', '0912345678', '1990-05-20', '2023-12-01'),
('NV003', N'Lê Minh Tuấn', N'Kỹ thuật', N'Toàn thời gian', N'345 Nguyễn Trãi', '0922334455', '1992-08-15', '2024-01-10'),
('NV004', N'Phạm Thị Lan', N'Thu ngân', N'Thời vụ', N'456 Hai Bà Trưng', '0933445566', '1997-03-22', '2024-04-05'),
('NV005', N'Hồ Anh Dũng', N'Bảo vệ', N'Thời vụ', N'567 Trường Chinh', '0944556677', '1985-10-10', '2024-02-20'),
('NV006', N'Đỗ Thị Hương', N'Lễ tân', N'Thời vụ', N'678 Lý Thường Kiệt', '0955667788', '1994-07-07', '2024-03-01'),
('NV007', N'Võ Văn Kiệt', N'Kỹ thuật', N'Toàn thời gian', N'789 Lê Văn Sỹ', '0966778899', '1991-06-30', '2023-11-15'),
('NV008', N'Tăng Minh Đức', N'Quản lý', N'Trưởng ca', N'890 Điện Biên Phủ', '0977889900', '1988-12-25', '2023-10-01'),
('NV009', N'Bùi Thị Nhung', N'Thu ngân', N'Thời vụ', N'901 Cách Mạng Tháng 8', '0988999000', '1996-09-09', '2024-05-05'),
('NV010', N'Đinh Văn Hòa', N'Bảo vệ', N'Thời vụ', N'123 Phan Đình Phùng', '0999000111', '1980-02-02', '2024-01-25'),
('NV011', N'Lý Thị Tuyết', N'Lễ tân', N'Thời vụ', N'321 Nguyễn Thái Học', '0900111222', '1993-11-11', '2024-03-15'),
('NV012', N'Ngô Văn Bình', N'Kỹ thuật', N'Toàn thời gian', N'654 Tô Hiến Thành', '0911222333', '1992-06-06', '2024-04-10'),
('NV013', N'Trịnh Minh Sơn', N'Bảo vệ', N'Thời vụ', N'987 Pasteur', '0922333444', '1987-08-08', '2024-02-15'),
('NV014', N'Tống Thị Thu', N'Thu ngân', N'Thời vụ', N'159 Nguyễn Tri Phương', '0933444555', '1995-09-30', '2024-04-20'),
('NV015', N'Cao Văn Nam', N'Quản lý', N'Trưởng ca', N'753 Nguyễn Văn Cừ', '0944555666', '1989-04-04', '2023-09-01');


INSERT INTO HoaDon VALUES
('HD001', 'KH001', 'NV001', 'M01', 2, 20000, '2025-06-01', N'Tiền mặt'),
('HD002', 'KH002', 'NV002', 'M02', 1, 10000, '2025-06-01', N'Momo'),
('HD003', 'KH003', 'NV003', 'M03', 3, 30000, '2025-06-01', N'Thẻ'),
('HD004', 'KH004', 'NV004', 'M04', 2, 20000, '2025-06-01', N'Tiền mặt'),
('HD005', 'KH005', 'NV005', 'M05', 4, 40000, '2025-06-01', N'Momo'),
('HD006', 'KH006', 'NV006', 'M06', 1, 10000, '2025-06-01', N'Thẻ'),
('HD007', 'KH007', 'NV007', 'M07', 5, 50000, '2025-06-01', N'Tiền mặt'),
('HD008', 'KH008', 'NV008', 'M08', 2, 20000, '2025-06-01', N'Thẻ'),
('HD009', 'KH009', 'NV009', 'M09', 3, 30000, '2025-06-01', N'Momo'),
('HD010', 'KH010', 'NV010', 'M10', 6, 60000, '2025-06-01', N'Tiền mặt'),
('HD011', 'KH011', 'NV011', 'M11', 1, 10000, '2025-06-01', N'Momo'),
('HD012', 'KH012', 'NV012', 'M12', 2, 20000, '2025-06-01', N'Thẻ'),
('HD013', 'KH013', 'NV013', 'M13', 3, 30000, '2025-06-01', N'Tiền mặt'),
('HD014', 'KH014', 'NV014', 'M14', 4, 40000, '2025-06-01', N'Momo'),
('HD015', 'KH015', 'NV015', 'M15', 2, 20000, '2025-06-01', N'Thẻ');

INSERT INTO CTHD VALUES
('HD001', 'M001', 2),
('HD001', 'M005', 1),
('HD002', 'M002', 1),
('HD003', 'M004', 3),
('HD004', 'M007', 1),
('HD005', 'M010', 2),
('HD006', 'M008', 1),
('HD007', 'M006', 4),
('HD008', 'M009', 2),
('HD009', 'M003', 1),
('HD010', 'M011', 2),
('HD011', 'M012', 1),
('HD012', 'M014', 1),
('HD013', 'M013', 3),
('HD014', 'M015', 1);


select * from CTHD;
SELECT * FROM HoaDon;
SELECT * FROM NhanVien;
SELECT * FROM Khach;
SELECT * FROM May;
SELECT * FROM Menu;
