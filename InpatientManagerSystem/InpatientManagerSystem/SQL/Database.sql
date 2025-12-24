-- =========================
-- TẠO DATABASE
-- =========================
CREATE DATABASE IF NOT EXISTS hospitaldb
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE hospitaldb;

-- =========================
-- BẢNG NGƯỜI DÙNG
-- =========================
DROP TABLE IF EXISTS nguoidung;
CREATE TABLE nguoidung (
    MaNguoiDung INT AUTO_INCREMENT PRIMARY KEY,
    TenDangNhap VARCHAR(50) UNIQUE NOT NULL,
    MaThuocKhau VARCHAR(255) NOT NULL,
    HoTen VARCHAR(100) NOT NULL,
    VaiTro ENUM('Admin','BacSi','LeTan') NOT NULL,
    Email VARCHAR(100),
    SoDienThoai VARCHAR(20) CHECK (SoDienThoai REGEXP '^[0-9]{10,11}$'),
    TrangThai BOOLEAN DEFAULT TRUE,
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- =========================
-- BẢNG BÁC SĨ
-- =========================
DROP TABLE IF EXISTS bacsi;
CREATE TABLE bacsi (
    MaBacSi VARCHAR(10) PRIMARY KEY,
    CHECK (MaBacSi REGEXP '^BS[0-9]+$'),
    MaNguoiDung INT NOT NULL UNIQUE,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh ENUM('Nam','Nữ') NOT NULL,
    CCCD VARCHAR(20) CHECK (CCCD REGEXP '^[0-9]{12}$'),
    DiaChi VARCHAR(255),
    KinhNghiem INT,
    ChuyenKhoa VARCHAR(150),
    CONSTRAINT FK_BS_ND FOREIGN KEY (MaNguoiDung)
        REFERENCES nguoidung(MaNguoiDung)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- BẢNG BỆNH NHÂN
-- =========================
DROP TABLE IF EXISTS benhnhan;
CREATE TABLE benhnhan (
    MaBenhNhan VARCHAR(10) PRIMARY KEY,
    CHECK (MaBenhNhan REGEXP '^BN[0-9]+$'),
    CCCD VARCHAR(20) UNIQUE NOT NULL CHECK (CCCD REGEXP '^[0-9]{12}$'),
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh ENUM('Nam','Nữ') NOT NULL,
    SoDienThoai VARCHAR(20) UNIQUE CHECK (SoDienThoai REGEXP '^[0-9]{10,11}$'),
    BHYT VARCHAR(20) NOT NULL,
    DiaChi TEXT NOT NULL,
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- =========================
-- BẢNG HỒ SƠ BỆNH
-- =========================
DROP TABLE IF EXISTS hoso;
CREATE TABLE hoso (
    MaHoSo VARCHAR(10) PRIMARY KEY,
    CHECK (MaHoSo REGEXP '^HS[0-9]+$'),
    MaBacSi VARCHAR(10),
    MaBenhNhan VARCHAR(10),
    NgayNhapVien DATE NOT NULL,
    LyDo VARCHAR(100),
    TrangThai ENUM('Đang điều trị','Xuất viện','Tử vong'),
    CONSTRAINT FK_HS_BS FOREIGN KEY (MaBacSi)
        REFERENCES bacsi(MaBacSi)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_HS_BN FOREIGN KEY (MaBenhNhan)
        REFERENCES benhnhan(MaBenhNhan)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- BẢNG PHÒNG
-- =========================
DROP TABLE IF EXISTS phong;
CREATE TABLE phong (
    MaPhong VARCHAR(10) PRIMARY KEY,
    CHECK (MaPhong REGEXP '^P[0-9]+$'),
    TenPhong VARCHAR(3) NOT NULL,
    LoaiPhong ENUM('Thường','Dịch vụ') DEFAULT 'Thường'
) ENGINE=InnoDB;

-- =========================
-- BẢNG GIƯỜNG
-- =========================
DROP TABLE IF EXISTS giuong;
CREATE TABLE giuong (
    MaGiuong VARCHAR(10) PRIMARY KEY,
    CHECK (MaGiuong REGEXP '^G[0-9]+$'),
    MaBacSi VARCHAR(10),
    MaPhong VARCHAR(10),
    TrangThai ENUM('Trống','Đầy'),
    CONSTRAINT FK_G_BS FOREIGN KEY (MaBacSi)
        REFERENCES bacsi(MaBacSi)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_G_P FOREIGN KEY (MaPhong)
        REFERENCES phong(MaPhong)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- BẢNG THUỐC
-- =========================
DROP TABLE IF EXISTS thuoc;
CREATE TABLE thuoc (
    MaThuoc VARCHAR(10) PRIMARY KEY,
    CHECK (MaThuoc REGEXP '^T[0-9]+$'),
    TenThuoc VARCHAR(200) NOT NULL,
    DonViTinh VARCHAR(50) NOT NULL,
    DonGia DECIMAL(18,2) DEFAULT 0 CHECK (DonGia >= 0),
    SoLuongTon INT DEFAULT 0 CHECK (SoLuongTon >= 0),
    HangSanXuat VARCHAR(200),
    CongDung VARCHAR(500),
    NgayHetHan DATE,
    TrangThai BOOLEAN DEFAULT TRUE
) ENGINE=InnoDB;

-- =========================
-- BẢNG PHÂN GIƯỜNG
-- =========================
DROP TABLE IF EXISTS phangiuong;
CREATE TABLE phangiuong (
    MaPhanGiuong VARCHAR(10) PRIMARY KEY,
    CHECK (MaPhanGiuong REGEXP '^PG[0-9]+$'),
    MaHoSo VARCHAR(10),
    MaGiuong VARCHAR(10),
    TuNgay DATE,
    DenNgay DATE,
    CONSTRAINT FK_PG_HS FOREIGN KEY (MaHoSo)
        REFERENCES hoso(MaHoSo)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_PG_G FOREIGN KEY (MaGiuong)
        REFERENCES giuong(MaGiuong)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- BẢNG KHÁM BỆNH
-- =========================
DROP TABLE IF EXISTS khambenh;
CREATE TABLE khambenh (
    MaKhamBenh VARCHAR(10) PRIMARY KEY,
    CHECK (MaKhamBenh REGEXP '^KB[0-9]+$'),
    MaHoSo VARCHAR(10),
    MaBenhNhan VARCHAR(10),
    MaBacSi VARCHAR(10),
    NgayKham DATE DEFAULT (CURRENT_DATE),
    ChuanDoan VARCHAR(50) NOT NULL,
    CONSTRAINT FK_KB_HS FOREIGN KEY (MaHoSo)
        REFERENCES hoso(MaHoSo)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_KB_BN FOREIGN KEY (MaBenhNhan)
        REFERENCES benhnhan(MaBenhNhan)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_KB_BS FOREIGN KEY (MaBacSi)
        REFERENCES bacsi(MaBacSi)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- BẢNG ĐƠN THUỐC
-- =========================
DROP TABLE IF EXISTS donthuoc;
CREATE TABLE donthuoc (
    MaDonThuoc VARCHAR(10) PRIMARY KEY,
    CHECK (MaDonThuoc REGEXP '^DT[0-9]+$'),
    MaKhamBenh VARCHAR(10),
    NgayKe DATE DEFAULT (CURRENT_DATE),
    CONSTRAINT FK_DT_KB FOREIGN KEY (MaKhamBenh)
        REFERENCES khambenh(MaKhamBenh)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- BẢNG CHI TIẾT ĐƠN THUỐC
-- =========================
DROP TABLE IF EXISTS chitietdonthuoc;
CREATE TABLE chitietdonthuoc (
    MaChiTietDonThuoc VARCHAR(10) PRIMARY KEY,
    CHECK (MaChiTietDonThuoc REGEXP '^CTDT[0-9]+$'),
    MaDonThuoc VARCHAR(10),
    MaThuoc VARCHAR(10),
    SoLuong INT DEFAULT 1,
    LieuLuong VARCHAR(30),
    GhiChu VARCHAR(255),
    CONSTRAINT FK_CTDT_DT FOREIGN KEY (MaDonThuoc)
        REFERENCES donthuoc(MaDonThuoc)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_CTDT_T FOREIGN KEY (MaThuoc)
        REFERENCES thuoc(MaThuoc)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- BẢNG HÓA ĐƠN
-- =========================
DROP TABLE IF EXISTS hoadon;
CREATE TABLE hoadon (
    MaHoaDon VARCHAR(10) PRIMARY KEY,
    CHECK (MaHoaDon REGEXP '^HD[0-9]+$'),
    MaHoSo VARCHAR(10) NOT NULL,
    MaNguoiDung VARCHAR(10),
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    TongTien DECIMAL(18,2) NOT NULL CHECK (TongTien >= 0),
    DaThanhToan DECIMAL(18,2) NOT NULL DEFAULT 0,
    TinhTrang ENUM('Chưa thanh toán','Thanh toán một phần','Đã thanh toán') DEFAULT 'Chưa thanh toán',
    GhiChu VARCHAR(255),
    CONSTRAINT FK_HD_HS FOREIGN KEY (MaHoSo)
        REFERENCES hoso(MaHoSo)
        ON DELETE CASCADE ON UPDATE CASCADE,

    CONSTRAINT FK_HD_ND FOREIGN KEY (MaNguoiDung)
        REFERENCES nguoidung(MaNguoiDung)
        ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB;


-- =========================
-- BẢNG XUẤT VIỆN
-- =========================
DROP TABLE IF EXISTS xuatvien;
CREATE TABLE xuatvien (
    MaXuatVien VARCHAR(10) PRIMARY KEY,
    CHECK (MaXuatVien REGEXP '^XV[0-9]+$'),
    MaHoSo VARCHAR(10),
    MaHoaDon VARCHAR(10),
    NgayXuatVien DATE DEFAULT (CURRENT_DATE),
    TinhTrang ENUM('Đã khỏi','Chuyển viện','Tử vong'),
    CONSTRAINT FK_XV_HS FOREIGN KEY (MaHoSo)
        REFERENCES hoso(MaHoSo)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_XV_HD FOREIGN KEY (MaHoaDon)
        REFERENCES hoadon(MaHoaDon)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- BẢNG DỊCH VỤ
-- =========================
DROP TABLE IF EXISTS dichvu;
CREATE TABLE dichvu (
    MaDichVu VARCHAR(10) PRIMARY KEY,
    CHECK (MaDichVu REGEXP '^DV[0-9]+$'),
    TenDichVu VARCHAR(200) NOT NULL,
    LoaiDichVu VARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) DEFAULT 0 CHECK (DonGia >= 0),
    DonViTinh VARCHAR(50),
    MoTa VARCHAR(500),
    TrangThai BOOLEAN DEFAULT TRUE,
    INDEX idx_tendichvu (TenDichVu)
) ENGINE=InnoDB;


-- =========================
-- BẢNG THANH TOÁN
-- =========================
DROP TABLE IF EXISTS thanhtoan;
CREATE TABLE thanhtoan (
    MaThanhToan VARCHAR(10) PRIMARY KEY,
    CHECK (MaThanhToan REGEXP '^TT[0-9]+$'),
    MaHoaDon VARCHAR(10) NOT NULL,
    NgayThanhToan DATETIME DEFAULT CURRENT_TIMESTAMP,
    SoTien DECIMAL(18,2) NOT NULL CHECK (SoTien > 0),
    PhuongThuc ENUM('Tiền mặt','Chuyển khoản'),
    GhiChu VARCHAR(255),
    CONSTRAINT FK_TT_HD FOREIGN KEY (MaHoaDon)
        REFERENCES hoadon(MaHoaDon)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- KIỂM TRA
-- =========================
SELECT * FROM hoso;
SELECT * FROM benhnhan;
