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
    public class BenhNhanBUS
    {
        private BenhNhanDAO benhNhanDAO = new BenhNhanDAO();

        // Lấy tất cả bệnh nhân
        public List<BenhNhan> LayDanhSachBenhNhan()
        {
            return benhNhanDAO.GetAll();
        }

        // Thêm bệnh nhân
        public bool ThemBenhNhan(BenhNhan benhNhan)
        {
            // Validate dữ liệu
            ValidateBenhNhan(benhNhan);

            // Kiểm tra CCCD đã tồn tại
            if (benhNhanDAO.CheckCCCDExists(benhNhan.CCCD))
            {
                throw new Exception("CCCD đã tồn tại trong hệ thống!");
            }

            // Kiểm tra số điện thoại đã tồn tại
            if (benhNhanDAO.CheckPhoneExists(benhNhan.SoDienThoai))
            {
                throw new Exception("Số điện thoại đã tồn tại trong hệ thống!");
            }

            return benhNhanDAO.Insert(benhNhan);
        }

        // Cập nhật bệnh nhân
        public bool CapNhatBenhNhan(BenhNhan benhNhan)
        {
            // Validate dữ liệu
            ValidateBenhNhan(benhNhan);

            // Kiểm tra CCCD đã tồn tại (trừ bệnh nhân hiện tại)
            if (benhNhanDAO.CheckCCCDExists(benhNhan.CCCD, benhNhan.MaBenhNhan))
            {
                throw new Exception("CCCD đã tồn tại trong hệ thống!");
            }

            // Kiểm tra số điện thoại đã tồn tại (trừ bệnh nhân hiện tại)
            if (benhNhanDAO.CheckPhoneExists(benhNhan.SoDienThoai, benhNhan.MaBenhNhan))
            {
                throw new Exception("Số điện thoại đã tồn tại trong hệ thống!");
            }

            return benhNhanDAO.Update(benhNhan);
        }

        // Xóa bệnh nhân
        public bool XoaBenhNhan(string maBenhNhan)
        {
            if (string.IsNullOrEmpty(maBenhNhan))
            {
                throw new ArgumentException("Mã bệnh nhân không được để trống!");
            }

            return benhNhanDAO.Delete(maBenhNhan);
        }

        // Tìm kiếm bệnh nhân
        public List<BenhNhan> TimKiemBenhNhan(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return LayDanhSachBenhNhan();
            }

            return benhNhanDAO.Search(keyword);
        }

        // Lấy bệnh nhân theo mã
        public BenhNhan LayBenhNhanTheoMa(string maBenhNhan)
        {
            if (string.IsNullOrEmpty(maBenhNhan))
            {
                throw new ArgumentException("Mã bệnh nhân không được để trống!");
            }

            return benhNhanDAO.GetByMa(maBenhNhan);
        }

        // Validate dữ liệu bệnh nhân
        private void ValidateBenhNhan(BenhNhan benhNhan)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(benhNhan.CCCD))
            {
                throw new ArgumentException("CCCD không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(benhNhan.HoTen))
            {
                throw new ArgumentException("Họ tên không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(benhNhan.GioiTinh))
            {
                throw new ArgumentException("Giới tính không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(benhNhan.SoDienThoai))
            {
                throw new ArgumentException("Số điện thoại không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(benhNhan.BHYT))
            {
                throw new ArgumentException("Số BHYT không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(benhNhan.DiaChi))
            {
                throw new ArgumentException("Địa chỉ không được để trống!");
            }

            // Validate định dạng CCCD (12 số)
            if (!Regex.IsMatch(benhNhan.CCCD, @"^[0-9]{12}$"))
            {
                throw new ArgumentException("CCCD phải là 12 chữ số!");
            }

            // Validate định dạng số điện thoại (10-11 số)
            if (!Regex.IsMatch(benhNhan.SoDienThoai, @"^[0-9]{10,11}$"))
            {
                throw new ArgumentException("Số điện thoại phải là 10-11 chữ số!");
            }

            // Validate giới tính
            if (benhNhan.GioiTinh != "Nam" && benhNhan.GioiTinh != "Nữ")
            {
                throw new ArgumentException("Giới tính chỉ có thể là 'Nam' hoặc 'Nữ'!");
            }

            // Validate ngày sinh (không thể là tương lai)
            if (benhNhan.NgaySinh > DateTime.Now)
            {
                throw new ArgumentException("Ngày sinh không thể là ngày trong tương lai!");
            }

            // Validate tuổi (ít nhất 0 tuổi, không quá 150 tuổi)
            int tuoi = DateTime.Now.Year - benhNhan.NgaySinh.Year;
            if (benhNhan.NgaySinh.Date > DateTime.Now.AddYears(-tuoi)) tuoi--;

            if (tuoi < 0 || tuoi > 150)
            {
                throw new ArgumentException("Tuổi không hợp lệ!");
            }
        }
    }
}
