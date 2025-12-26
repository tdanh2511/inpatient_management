using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.BUS
{
    public class KhamBenhBUS
    {
        private KhamBenhDAO khamBenhDAO = new KhamBenhDAO();

        // Lấy tất cả khám bệnh
        public List<KhamBenh> LayDanhSachKhamBenh()
        {
            return khamBenhDAO.GetAll();
        }

        // Thêm khám bệnh
        public bool ThemKhamBenh(KhamBenh khamBenh)
        {
            // Validate dữ liệu
            ValidateKhamBenh(khamBenh);

            return khamBenhDAO.Insert(khamBenh);
        }

        // Cập nhật khám bệnh
        public bool CapNhatKhamBenh(KhamBenh khamBenh)
        {
            // Validate dữ liệu
            ValidateKhamBenh(khamBenh);

            if (string.IsNullOrEmpty(khamBenh.MaKhamBenh))
            {
                throw new ArgumentException("Mã khám bệnh không được để trống!");
            }

            return khamBenhDAO.Update(khamBenh);
        }

        // Xóa khám bệnh
        public bool XoaKhamBenh(string maKhamBenh)
        {
            if (string.IsNullOrEmpty(maKhamBenh))
            {
                throw new ArgumentException("Mã khám bệnh không được để trống!");
            }

            return khamBenhDAO.Delete(maKhamBenh);
        }

        // Tìm kiếm khám bệnh
        public List<KhamBenh> TimKiemKhamBenh(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return LayDanhSachKhamBenh();
            }

            return khamBenhDAO.Search(keyword);
        }

        // Lấy khám bệnh theo mã
        public KhamBenh LayKhamBenhTheoMa(string maKhamBenh)
        {
            if (string.IsNullOrEmpty(maKhamBenh))
            {
                throw new ArgumentException("Mã khám bệnh không được để trống!");
            }

            return khamBenhDAO.GetByMa(maKhamBenh);
        }

        // Lấy danh sách bác sĩ
        public List<BacSi> LayDanhSachBacSi()
        {
            return khamBenhDAO.GetAllBacSi();
        }

        // Lấy danh sách bệnh nhân
        public List<BenhNhan> LayDanhSachBenhNhan()
        {
            return khamBenhDAO.GetAllBenhNhan();
        }

        // Lấy danh sách hồ sơ
        public List<HoSo> LayDanhSachHoSo(string maHoSoDangChon = null)
        {
            return khamBenhDAO.GetAllHoSo(maHoSoDangChon);
        }

        // Validate dữ liệu khám bệnh
        private void ValidateKhamBenh(KhamBenh khamBenh)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(khamBenh.MaBenhNhan))
            {
                throw new ArgumentException("Vui lòng chọn bệnh nhân!");
            }

            if (string.IsNullOrWhiteSpace(khamBenh.MaBacSi))
            {
                throw new ArgumentException("Vui lòng chọn bác sĩ!");
            }

            if (string.IsNullOrWhiteSpace(khamBenh.ChuanDoan))
            {
                throw new ArgumentException("Chuẩn đoán không được để trống!");
            }

            // Validate ngày khám (không được là tương lai)
            if (khamBenh.NgayKham.Date > DateTime.Now.Date)
            {
                throw new ArgumentException("Ngày khám không thể là ngày trong tương lai!");
            }
        }
    }
}
