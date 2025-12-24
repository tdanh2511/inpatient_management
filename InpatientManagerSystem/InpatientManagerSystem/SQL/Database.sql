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
    STT INT AUTO_INCREMENT UNIQUE,
    MaBacSi VARCHAR(10) PRIMARY KEY,
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

DELIMITER $$
CREATE TRIGGER trg_bacsi_ma
BEFORE INSERT ON bacsi
FOR EACH ROW
BEGIN
    SET NEW.MaBacSi = CONCAT('BS', LPAD(NEW.STT,3,'0'));
END$$
DELIMITER ;

-- =========================
-- BẢNG BỆNH NHÂN
-- =========================
DROP TABLE IF EXISTS benhnhan;
CREATE TABLE benhnhan (
    STT INT AUTO_INCREMENT UNIQUE,
    MaBenhNhan VARCHAR(10) PRIMARY KEY,
    CCCD VARCHAR(20) UNIQUE NOT NULL CHECK (CCCD REGEXP '^[0-9]{12}$'),
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh ENUM('Nam','Nữ') NOT NULL,
    SoDienThoai VARCHAR(20) UNIQUE CHECK (SoDienThoai REGEXP '^[0-9]{10,11}$'),
    BHYT VARCHAR(20) NOT NULL,
    DiaChi TEXT NOT NULL,
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

DELIMITER $$
CREATE TRIGGER trg_benhnhan_ma
BEFORE INSERT ON benhnhan
FOR EACH ROW
BEGIN
    SET NEW.MaBenhNhan = CONCAT('BN', LPAD(NEW.STT,6,'0'));
END$$
DELIMITER ;

-- =========================
-- BẢNG HỒ SƠ BỆNH
-- =========================
DROP TABLE IF EXISTS hoso;
CREATE TABLE hoso (
    STT INT AUTO_INCREMENT UNIQUE,
    MaHoSo VARCHAR(10) PRIMARY KEY,
    MaBacSi VARCHAR(10),
    MaBenhNhan VARCHAR(10),
    NgayNhapVien DATE NOT NULL,
    LyDo VARCHAR(100),
    TrangThai ENUM('Đang điều trị','Xuất viện','Tử vong') DEFAULT 'Đang điều trị',
    CONSTRAINT FK_HS_BS FOREIGN KEY (MaBacSi)
        REFERENCES bacsi(MaBacSi)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_HS_BN FOREIGN KEY (MaBenhNhan)
        REFERENCES benhnhan(MaBenhNhan)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

DELIMITER $$
CREATE TRIGGER trg_hoso_ma
BEFORE INSERT ON hoso
FOR EACH ROW
BEGIN
    SET NEW.MaHoSo = CONCAT('HS', LPAD(NEW.STT,4,'0'));
END$$
DELIMITER ;

-- =========================
-- BẢNG PHÒNG
-- =========================
DROP TABLE IF EXISTS phong;
CREATE TABLE phong (
    STT INT AUTO_INCREMENT UNIQUE,
    MaPhong VARCHAR(10) PRIMARY KEY,
    TenPhong VARCHAR(3) NOT NULL,
    LoaiPhong ENUM('Thường','Dịch vụ') DEFAULT 'Thường'
) ENGINE=InnoDB;

DELIMITER $$
CREATE TRIGGER trg_phong_ma
BEFORE INSERT ON phong
FOR EACH ROW
BEGIN
    SET NEW.MaPhong = CONCAT('P', LPAD(NEW.STT,2,'0'));
END$$
DELIMITER ;

-- =========================
-- BẢNG GIƯỜNG
-- =========================
DROP TABLE IF EXISTS giuong;
CREATE TABLE giuong (
    STT INT AUTO_INCREMENT UNIQUE,
    MaGiuong VARCHAR(10) PRIMARY KEY,
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

DELIMITER $$
CREATE TRIGGER trg_giuong_ma
BEFORE INSERT ON giuong
FOR EACH ROW
BEGIN
    SET NEW.MaGiuong = CONCAT('G', LPAD(NEW.STT,2,'0'));
END$$
DELIMITER ;

-- =========================
-- BẢNG THUỐC
-- =========================
DROP TABLE IF EXISTS thuoc;
CREATE TABLE thuoc (
    STT INT AUTO_INCREMENT UNIQUE,
    MaThuoc VARCHAR(10) PRIMARY KEY,
    TenThuoc VARCHAR(200) NOT NULL,
    DonViTinh VARCHAR(50) NOT NULL,
    DonGia DECIMAL(18,2) DEFAULT 0 CHECK (DonGia >= 0),
    SoLuongTon INT DEFAULT 0 CHECK (SoLuongTon >= 0),
    HangSanXuat VARCHAR(200),
    CongDung VARCHAR(500),
    NgayHetHan DATE,
    TrangThai BOOLEAN DEFAULT TRUE
) ENGINE=InnoDB;

DELIMITER $$
CREATE TRIGGER trg_thuoc_ma
BEFORE INSERT ON thuoc
FOR EACH ROW
BEGIN
    SET NEW.MaThuoc = CONCAT('T', LPAD(NEW.STT,3,'0'));
END$$
DELIMITER ;

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
    STT INT AUTO_INCREMENT UNIQUE,
    MaKhamBenh VARCHAR(10) PRIMARY KEY,
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

DELIMITER $$
CREATE TRIGGER trg_khambenh_ma
BEFORE INSERT ON khambenh
FOR EACH ROW
BEGIN
    SET NEW.MaKhamBenh = CONCAT('KB', LPAD(NEW.STT,3,'0'));
END$$
DELIMITER ;

-- =========================
-- BẢNG ĐƠN THUỐC
-- =========================
DROP TABLE IF EXISTS donthuoc;
CREATE TABLE donthuoc (
    STT INT AUTO_INCREMENT UNIQUE,
    MaDonThuoc VARCHAR(10) PRIMARY KEY,
    MaKhamBenh VARCHAR(10),
    NgayKe DATE DEFAULT (CURRENT_DATE),
    CONSTRAINT FK_DT_KB FOREIGN KEY (MaKhamBenh)
        REFERENCES khambenh(MaKhamBenh)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

DELIMITER $$
CREATE TRIGGER trg_donthuoc_ma
BEFORE INSERT ON donthuoc
FOR EACH ROW
BEGIN
    SET NEW.MaDonThuoc = CONCAT('DT', LPAD(NEW.STT,3,'0'));
END$$
DELIMITER ;

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
-- BẢNG HÓA ĐƠN
-- =========================
DROP TABLE IF EXISTS hoadon;
CREATE TABLE hoadon (
    STT INT AUTO_INCREMENT UNIQUE,
    MaHoaDon VARCHAR(10) PRIMARY KEY,
    MaHoSo VARCHAR(10) NOT NULL,
    MaNguoiDung INT,
    NgayTao DATETIME DEFAULT CURRENT_TIMESTAMP,
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TongTien >= 0),
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

DELIMITER $$
CREATE TRIGGER trg_hoadon_ma
BEFORE INSERT ON hoadon
FOR EACH ROW
BEGIN
    SET NEW.MaHoaDon = CONCAT('HD', LPAD(NEW.STT,3,'0'));
END$$
DELIMITER ;

-- =========================
-- BẢNG CHI TIẾT HÓA ĐƠN
-- =========================
DROP TABLE IF EXISTS chitiethoadon;
CREATE TABLE chitiethoadon (
    MaChiTietHoaDon VARCHAR(10) PRIMARY KEY,
    CHECK (MaChiTietHoaDon REGEXP '^CTHD[0-9]+$'),
    MaHoaDon VARCHAR(10) NOT NULL,
    MaDichVu VARCHAR(10) NOT NULL,
    SoLuong INT NOT NULL DEFAULT 1 CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    ThanhTien DECIMAL(18,2) GENERATED ALWAYS AS (SoLuong * DonGia) STORED,
    CONSTRAINT FK_CTHD_HD FOREIGN KEY (MaHoaDon)
        REFERENCES hoadon(MaHoaDon)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_CTHD_DV FOREIGN KEY (MaDichVu)
        REFERENCES dichvu(MaDichVu)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- =========================
-- TRIGGER TÍNH TỔNG TIỀN
-- =========================
DELIMITER $$

CREATE TRIGGER trg_tinh_tong_tien
AFTER INSERT ON chitiethoadon
FOR EACH ROW
BEGIN
    UPDATE hoadon
    SET TongTien = (SELECT SUM(ThanhTien) FROM chitiethoadon WHERE MaHoaDon = NEW.MaHoaDon)
    WHERE MaHoaDon = NEW.MaHoaDon;
END$$

CREATE TRIGGER trg_update_tong_tien_after_update
AFTER UPDATE ON chitiethoadon
FOR EACH ROW
BEGIN
    UPDATE hoadon
    SET TongTien = (SELECT IFNULL(SUM(ThanhTien),0) FROM chitiethoadon WHERE MaHoaDon = NEW.MaHoaDon)
    WHERE MaHoaDon = NEW.MaHoaDon;
END$$

CREATE TRIGGER trg_update_tong_tien_after_delete
AFTER DELETE ON chitiethoadon
FOR EACH ROW
BEGIN
    UPDATE hoadon
    SET TongTien = (SELECT IFNULL(SUM(ThanhTien),0) FROM chitiethoadon WHERE MaHoaDon = OLD.MaHoaDon)
    WHERE MaHoaDon = OLD.MaHoaDon;
END$$

DELIMITER ;

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
    MaNguoiDung INT,
    GhiChu VARCHAR(255),
    CONSTRAINT FK_TT_HD FOREIGN KEY (MaHoaDon)
        REFERENCES hoadon(MaHoaDon)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_TT_ND FOREIGN KEY (MaNguoiDung)
        REFERENCES nguoidung(MaNguoiDung)
        ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB;

DELIMITER $$

CREATE TRIGGER trg_cong_tien_thanh_toan
AFTER INSERT ON thanhtoan
FOR EACH ROW
BEGIN
    UPDATE hoadon
    SET 
        DaThanhToan = DaThanhToan + NEW.SoTien,
        TinhTrang = CASE
            WHEN DaThanhToan + NEW.SoTien >= TongTien THEN 'Đã thanh toán'
            WHEN DaThanhToan + NEW.SoTien > 0 THEN 'Thanh toán một phần'
            ELSE 'Chưa thanh toán'
        END
    WHERE MaHoaDon = NEW.MaHoaDon;
END$$

CREATE TRIGGER trg_tru_tien_thanh_toan
AFTER DELETE ON thanhtoan
FOR EACH ROW
BEGIN
    UPDATE hoadon
    SET 
        DaThanhToan = DaThanhToan - OLD.SoTien,
        TinhTrang = CASE
            WHEN DaThanhToan - OLD.SoTien >= TongTien THEN 'Đã thanh toán'
            WHEN DaThanhToan - OLD.SoTien > 0 THEN 'Thanh toán một phần'
            ELSE 'Chưa thanh toán'
        END
    WHERE MaHoaDon = OLD.MaHoaDon;
END$$

DELIMITER ;

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

-- RESET thu Tu
ALTER TABLE bacsi AUTO_INCREMENT = 1;
ALTER TABLE benhnhan AUTO_INCREMENT = 1;
ALTER TABLE hoso AUTO_INCREMENT = 1;
ALTER TABLE phong AUTO_INCREMENT = 1;
ALTER TABLE giuong AUTO_INCREMENT = 1;
ALTER TABLE thuoc AUTO_INCREMENT = 1;
ALTER TABLE khambenh AUTO_INCREMENT = 1;
ALTER TABLE donthuoc AUTO_INCREMENT = 1;
ALTER TABLE hoadon AUTO_INCREMENT = 1;
