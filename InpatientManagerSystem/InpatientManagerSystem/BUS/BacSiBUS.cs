using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace InpatientManagerSystem.BUS
{
    public class BacSiBUS
    {
        private readonly BacSiDAO bacSiDAO = new BacSiDAO();

        // Lấy tất cả bác sĩ
        public List<BacSi> LayDanhSachBacSi()
        {
            return bacSiDAO.GetAll();
        }

        // Thêm bác sĩ
        public bool ThemBacSi(BacSi bacSi)
        {
            ValidateBacSi(bacSi);

            // Kiểm tra CCCD đã tồn tại
            if (bacSiDAO.CheckCCCDExists(bacSi.Cccd))
            {
                throw new Exception("CCCD đã tồn tại trong hệ thống!");
            }

            return bacSiDAO.Insert(bacSi);
        }

        // Cập nhật bác sĩ
        public bool CapNhatBacSi(BacSi bacSi)
        {
            ValidateBacSi(bacSi);

            if (string.IsNullOrWhiteSpace(bacSi.MaBacSi))
            {
                throw new ArgumentException("Mã bác sĩ không được để trống!");
            }

            // Kiểm tra CCCD đã tồn tại (trừ bác sĩ hiện tại)
            if (bacSiDAO.CheckCCCDExists(bacSi.Cccd, bacSi.MaBacSi))
            {
                throw new Exception("CCCD đã tồn tại trong hệ thống!");
            }

            return bacSiDAO.Update(bacSi);
        }

        // Xóa bác sĩ
        public bool XoaBacSi(string maBacSi)
        {
            if (string.IsNullOrWhiteSpace(maBacSi))
            {
                throw new ArgumentException("Mã bác sĩ không được để trống!");
            }

            return bacSiDAO.Delete(maBacSi);
        }

        // Tìm kiếm bác sĩ
        public List<BacSi> TimKiemBacSi(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return LayDanhSachBacSi();
            }

            return bacSiDAO.Search(keyword);
        }

        // Lấy bác sĩ theo mã
        public BacSi LayBacSiTheoMa(string maBacSi)
        {
            if (string.IsNullOrWhiteSpace(maBacSi))
            {
                throw new ArgumentException("Mã bác sĩ không được để trống!");
            }

            return bacSiDAO.GetByMa(maBacSi);
        }

        // Validate dữ liệu bác sĩ
        private void ValidateBacSi(BacSi bacSi)
        {
            if (bacSi == null)
                throw new ArgumentNullException(nameof(bacSi), "Dữ liệu bác sĩ không hợp lệ!");

            // Các trường bắt buộc
            if (bacSi.MaNguoiDung <= 0)
                throw new ArgumentException("Mã người dùng không hợp lệ!");

            if (string.IsNullOrWhiteSpace(bacSi.HoTen))
                throw new ArgumentException("Họ tên không được để trống!");

            if (string.IsNullOrWhiteSpace(bacSi.GioiTinh))
                throw new ArgumentException("Giới tính không được để trống!");

            if (string.IsNullOrWhiteSpace(bacSi.Cccd))
                throw new ArgumentException("CCCD không được để trống!");

            if (string.IsNullOrWhiteSpace(bacSi.DiaChi))
                throw new ArgumentException("Địa chỉ không được để trống!");

            if (string.IsNullOrWhiteSpace(bacSi.ChuyenKhoa))
                throw new ArgumentException("Chuyên khoa không được để trống!");

            if (bacSi.KinhNghiem < 0 || bacSi.KinhNghiem > 60)
                throw new ArgumentException("Kinh nghiệm không hợp lệ (0 - 60 năm)!");

            // Validate CCCD (12 số)
            if (!Regex.IsMatch(bacSi.Cccd, @"^[0-9]{12}$"))
                throw new ArgumentException("CCCD phải gồm đúng 12 chữ số!");

            // Validate giới tính
            if (bacSi.GioiTinh != "Nam" && bacSi.GioiTinh != "Nữ")
                throw new ArgumentException("Giới tính chỉ có thể là 'Nam' hoặc 'Nữ'!");

            // Validate ngày sinh
            if (bacSi.NgaySinh > DateTime.Now)
                throw new ArgumentException("Ngày sinh không thể là ngày trong tương lai!");

            // Validate tuổi (ít nhất 18 tuổi, tối đa 80 tuổi)
            int tuoi = DateTime.Now.Year - bacSi.NgaySinh.Year;
            if (bacSi.NgaySinh.Date > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 18 || tuoi > 80)
                throw new ArgumentException("Tuổi bác sĩ không hợp lệ (18 - 80)!");
        }
    }
}
