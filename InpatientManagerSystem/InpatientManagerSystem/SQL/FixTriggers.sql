-- =========================
-- FIX TRIGGER TỰ ĐỘNG TẠO MÃ
-- =========================

USE hospitaldb;

-- Xóa các trigger cũ
DROP TRIGGER IF EXISTS trg_bacsi_ma;
DROP TRIGGER IF EXISTS trg_benhnhan_ma;
DROP TRIGGER IF EXISTS trg_hoso_ma;
DROP TRIGGER IF EXISTS trg_phong_ma;
DROP TRIGGER IF EXISTS trg_giuong_ma;
DROP TRIGGER IF EXISTS trg_thuoc_ma;
DROP TRIGGER IF EXISTS trg_khambenh_ma;
DROP TRIGGER IF EXISTS trg_donthuoc_ma;
DROP TRIGGER IF EXISTS trg_hoadon_ma;

-- =========================
-- TẠO LẠI TRIGGER BÁC SĨ
-- =========================
DELIMITER $$
CREATE TRIGGER trg_bacsi_ma
BEFORE INSERT ON bacsi
FOR EACH ROW
BEGIN
    DECLARE next_id INT;
    
    -- Lấy STT tiếp theo
    SELECT IFNULL(MAX(STT), 0) + 1 INTO next_id FROM bacsi;
    
    -- Gán STT
    SET NEW.STT = next_id;
    
    -- Tạo mã bác sĩ
    SET NEW.MaBacSi = CONCAT('BS', LPAD(next_id, 3, '0'));
END$$
DELIMITER ;

-- =========================
-- TẠO LẠI TRIGGER BỆNH NHÂN
-- =========================
DELIMITER $$
CREATE TRIGGER trg_benhnhan_ma
BEFORE INSERT ON benhnhan
FOR EACH ROW
BEGIN
    DECLARE next_id INT;
    
    -- Lấy STT tiếp theo
    SELECT IFNULL(MAX(STT), 0) + 1 INTO next_id FROM benhnhan;
    
    -- Gán STT
    SET NEW.STT = next_id;
    
    -- Tạo mã bệnh nhân
    SET NEW.MaBenhNhan = CONCAT('BN', LPAD(next_id, 6, '0'));
END$$
DELIMITER ;

-- =========================
-- TẠO LẠI TRIGGER HỒ SƠ
-- =========================
DELIMITER $$
CREATE TRIGGER trg_hoso_ma
BEFORE INSERT ON hoso
FOR EACH ROW
BEGIN
    DECLARE next_id INT;
    
    -- Lấy STT tiếp theo
    SELECT IFNULL(MAX(STT), 0) + 1 INTO next_id FROM hoso;
    
    -- Gán STT
    SET NEW.STT = next_id;
    
    -- Tạo mã hồ sơ
    SET NEW.MaHoSo = CONCAT('HS', LPAD(next_id, 4, '0'));
END$$
DELIMITER ;

-- =========================
-- TẠO LẠI TRIGGER PHÒNG
-- =========================
DELIMITER $$
CREATE TRIGGER trg_phong_ma
BEFORE INSERT ON phong
FOR EACH ROW
BEGIN
    DECLARE next_id INT;
    
    -- Lấy STT tiếp theo
    SELECT IFNULL(MAX(STT), 0) + 1 INTO next_id FROM phong;
    
    -- Gán STT
    SET NEW.STT = next_id;
    
    -- Tạo mã phòng
    SET NEW.MaPhong = CONCAT('P', LPAD(next_id, 2, '0'));
END$$
DELIMITER ;

-- =========================
-- TẠO LẠI TRIGGER GIƯỜNG
-- =========================
DELIMITER $$
CREATE TRIGGER trg_giuong_ma
BEFORE INSERT ON giuong
FOR EACH ROW
BEGIN
    DECLARE next_id INT;
    
    -- Lấy STT tiếp theo
    SELECT IFNULL(MAX(STT), 0) + 1 INTO next_id FROM giuong;
    
 -- Gán STT
    SET NEW.STT = next_id;
    
-- Tạo mã giường
 SET NEW.MaGiuong = CONCAT('G', LPAD(next_id, 2, '0'));
END$$
DELIMITER ;

-- =========================
-- TẠO LẠI TRIGGER THUỐC
-- =========================
DELIMITER $$
CREATE TRIGGER trg_thuoc_ma
BEFORE INSERT ON thuoc
FOR EACH ROW
BEGIN
    DECLARE next_id INT;
  
    -- Lấy STT tiếp theo
    SELECT IFNULL(MAX(STT), 0) + 1 INTO next_id FROM thuoc;
    
    -- Gán STT
  SET NEW.STT = next_id;
    
    -- Tạo mã thuốc
    SET NEW.MaThuoc = CONCAT('T', LPAD(next_id, 3, '0'));
END$$
DELIMITER ;

-- =========================
-- TẠO LẠI TRIGGER KHÁM BỆNH
-- =========================
DELIMITER $$
CREATE TRIGGER trg_khambenh_ma
BEFORE INSERT ON khambenh
FOR EACH ROW
BEGIN
    DECLARE next_id INT;
    
    -- Lấy STT tiếp theo
    SELECT IFNULL(MAX(STT), 0) + 1 INTO next_id FROM khambenh;
    
    -- Gán STT
    SET NEW.STT = next_id;
    
    -- Tạo mã khám bệnh
    SET NEW.MaKhamBenh = CONCAT('KB', LPAD(next_id, 3, '0'));
END$$
DELIMITER ;

-- =========================
-- TẠO LẠI TRIGGER ĐƠN THUỐC
-- =========================
DELIMITER $$
CREATE TRIGGER trg_donthuoc_ma
BEFORE INSERT ON donthuoc
FOR EACH ROW
BEGIN
    DECLARE next_id INT;
    
 -- Lấy STT tiếp theo
    SELECT IFNULL(MAX(STT), 0) + 1 INTO next_id FROM donthuoc;
  
    -- Gán STT
    SET NEW.STT = next_id;
    
    -- Tạo mã đơn thuốc
    SET NEW.MaDonThuoc = CONCAT('DT', LPAD(next_id, 3, '0'));
END$$
DELIMITER ;

-- =========================
-- TẠO LẠI TRIGGER HÓA ĐƠN
-- =========================
DELIMITER $$
CREATE TRIGGER trg_hoadon_ma
BEFORE INSERT ON hoadon
FOR EACH ROW
BEGIN
    DECLARE next_id INT;
 
    -- Lấy STT tiếp theo
    SELECT IFNULL(MAX(STT), 0) + 1 INTO next_id FROM hoadon;
    
    -- Gán STT
    SET NEW.STT = next_id;
    
    -- Tạo mã hóa đơn
    SET NEW.MaHoaDon = CONCAT('HD', LPAD(next_id, 3, '0'));
END$$
DELIMITER ;

-- Kiểm tra kết quả
SELECT 'Triggers đã được tạo lại thành công!' AS Status;
