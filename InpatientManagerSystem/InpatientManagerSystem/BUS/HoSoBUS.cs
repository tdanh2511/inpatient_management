using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.BUS
{
    public class HoSoBUS
    {
        private HoSoDAO hoSoDAO = new HoSoDAO();

        // Lấy tất cả hồ sơ
        public List<HoSo> LayDanhSachHoSo()
        {
            return hoSoDAO.GetAll();
        }

        // Thêm hồ sơ
        public bool ThemHoSo(HoSo hoSo)
        {
            // Validate dữ liệu
            ValidateHoSo(hoSo);

            return hoSoDAO.Insert(hoSo);
        }

        // Cập nhật hồ sơ
        public bool CapNhatHoSo(HoSo hoSo)
        {
            // Validate dữ liệu
            ValidateHoSo(hoSo);

            if (string.IsNullOrEmpty(hoSo.MaHoSo))
            {
                throw new ArgumentException("Mã hồ sơ không được để trống!");
            }

            return hoSoDAO.Update(hoSo);
        }

        // Xóa hồ sơ
        public bool XoaHoSo(string maHoSo)
        {
            if (string.IsNullOrEmpty(maHoSo))
            {
                throw new ArgumentException("Mã hồ sơ không được để trống!");
            }

            return hoSoDAO.Delete(maHoSo);
        }

        // Tìm kiếm hồ sơ
        public List<HoSo> TimKiemHoSo(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return LayDanhSachHoSo();
            }

            return hoSoDAO.Search(keyword);
        }

        // Lấy hồ sơ theo mã
        public HoSo LayHoSoTheoMa(string maHoSo)
        {
            if (string.IsNullOrEmpty(maHoSo))
            {
                throw new ArgumentException("Mã hồ sơ không được để trống!");
            }

            return hoSoDAO.GetByMa(maHoSo);
        }

        // Lấy danh sách bác sĩ
        public List<BacSi> LayDanhSachBacSi()
        {
            return hoSoDAO.GetAllBacSi();
        }

        // Lấy danh sách bệnh nhân (có tham số để lọc khi sửa)
        public List<BenhNhan> LayDanhSachBenhNhan(string maBenhNhanDangChon = null)
        {
            return hoSoDAO.GetAllBenhNhan(maBenhNhanDangChon);
        }

        // Validate dữ liệu hồ sơ
        private void ValidateHoSo(HoSo hoSo)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(hoSo.MaBenhNhan))
            {
                throw new ArgumentException("Vui lòng chọn bệnh nhân!");
            }

            if (string.IsNullOrWhiteSpace(hoSo.TrangThai))
            {
                throw new ArgumentException("Vui lòng chọn trạng thái!");
            }

            // Validate ngày nhập viện
            if (hoSo.NgayNhapVien > DateTime.Now)
            {
                throw new ArgumentException("Ngày nhập viện không thể là ngày trong tương lai!");
            }

            // Validate trạng thái
            if (hoSo.TrangThai != "Đang điều trị" &&
                      hoSo.TrangThai != "Xuất viện" &&
               hoSo.TrangThai != "Tử vong")
            {
                throw new ArgumentException("Trạng thái không hợp lệ!");
            }
        }
    }
}
