using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InpatientManagerSystem.BUS
{
    public class BacSiBUS
    {
        private BacSiDAO bacSiDAO = new BacSiDAO();

        // Lấy tất cả bác sĩ
        public List<BacSi> LayDanhSachBacSi()
        {
            return bacSiDAO.GetAll();
        }

        // Thêm bác sĩ
        public bool ThemBacSi(BacSi bacSi)
        {
            // Validate dữ liệu
            ValidateBacSi(bacSi);

            // Kiểm tra CCCD đã tồn tại
            if (!string.IsNullOrEmpty(bacSi.CCCD) && bacSiDAO.CheckCCCDExists(bacSi.CCCD))
            {
                throw new Exception("CCCD đã tồn tại trong hệ thống!");
            }

            // Kiểm tra MaNguoiDung đã được sử dụng
            if (bacSiDAO.CheckMaNguoiDungExists(bacSi.MaNguoiDung))
            {
                throw new Exception("Người dùng này đã được gán cho bác sĩ khác!");
            }

            return bacSiDAO.Insert(bacSi);
        }

        // Cập nhật bác sĩ
        public bool CapNhatBacSi(BacSi bacSi)
        {
            // Validate dữ liệu
            ValidateBacSi(bacSi);

            // Kiểm tra CCCD đã tồn tại (trừ bác sĩ hiện tại)
            if (!string.IsNullOrEmpty(bacSi.CCCD) && bacSiDAO.CheckCCCDExists(bacSi.CCCD, bacSi.MaBacSi))
            {
                throw new Exception("CCCD đã tồn tại trong hệ thống!");
            }

            // Kiểm tra MaNguoiDung đã được sử dụng (trừ bác sĩ hiện tại)
            if (bacSiDAO.CheckMaNguoiDungExists(bacSi.MaNguoiDung, bacSi.MaBacSi))
            {
                throw new Exception("Người dùng này đã được gán cho bác sĩ khác!");
            }

            return bacSiDAO.Update(bacSi);
        }

        // Xóa bác sĩ
        public bool XoaBacSi(string maBacSi)
        {
            if (string.IsNullOrEmpty(maBacSi))
            {
                throw new ArgumentException("Mã bác sĩ không được để trống!");
            }

            return bacSiDAO.Delete(maBacSi);
        }

        // Tìm kiếm bác sĩ
        public List<BacSi> TimKiemBacSi(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return LayDanhSachBacSi();
            }

            return bacSiDAO.Search(keyword);
        }

        // Lấy bác sĩ theo mã
        public BacSi LayBacSiTheoMa(string maBacSi)
        {
            if (string.IsNullOrEmpty(maBacSi))
            {
                throw new ArgumentException("Mã bác sĩ không được để trống!");
            }

            return bacSiDAO.GetByMa(maBacSi);
        }

        // Lấy danh sách người dùng chưa được gán cho bác sĩ
        public List<NguoiDung> LayDanhSachNguoiDungChuaGan()
        {
            return bacSiDAO.GetAvailableNguoiDungBacSi();
        }

        // Lấy tất cả người dùng vai trò bác sĩ
        public List<NguoiDung> LayTatCaNguoiDungBacSi()
        {
            return bacSiDAO.GetAllNguoiDungBacSi();
        }

        // Validate dữ liệu bác sĩ
        private void ValidateBacSi(BacSi bacSi)
        {
            // Kiểm tra các trường bắt buộc
            if (bacSi.MaNguoiDung <= 0)
            {
                throw new ArgumentException("Vui lòng chọn người dùng!");
            }

            if (string.IsNullOrWhiteSpace(bacSi.HoTen))
            {
                throw new ArgumentException("Họ tên không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(bacSi.GioiTinh))
            {
                throw new ArgumentException("Giới tính không được để trống!");
            }

            // Validate định dạng CCCD (12 số) nếu có
            if (!string.IsNullOrWhiteSpace(bacSi.CCCD))
            {
                if (!Regex.IsMatch(bacSi.CCCD, @"^[0-9]{12}$"))
                {
                    throw new ArgumentException("CCCD phải là 12 chữ số!");
                }
            }

            // Validate giới tính
            if (bacSi.GioiTinh != "Nam" && bacSi.GioiTinh != "Nữ")
            {
                throw new ArgumentException("Giới tính chỉ có thể là 'Nam' hoặc 'Nữ'!");
            }

            // Validate ngày sinh (không thể là tương lai)
            if (bacSi.NgaySinh.HasValue && bacSi.NgaySinh.Value > DateTime.Now)
            {
                throw new ArgumentException("Ngày sinh không thể là ngày trong tương lai!");
            }

            // Validate kinh nghiệm (phải >= 0)
            if (bacSi.KinhNghiem.HasValue && bacSi.KinhNghiem.Value < 0)
            {
                throw new ArgumentException("Số năm kinh nghiệm không được âm!");
            }

            // Validate kinh nghiệm hợp lý (không quá 70 năm)
            if (bacSi.KinhNghiem.HasValue && bacSi.KinhNghiem.Value > 70)
            {
                throw new ArgumentException("Số năm kinh nghiệm không hợp lệ!");
            }
        }
    }
}
