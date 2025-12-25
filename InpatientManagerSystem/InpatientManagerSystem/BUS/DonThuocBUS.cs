using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.BUS
{
    internal class DonThuocBUS
    {
        private DonThuocDAO donThuocDAO = new DonThuocDAO();
        private ChiTietDonThuocDAO chiTietDonThuocDAO = new ChiTietDonThuocDAO();

        public List<DonThuocDTO> LayDanhSachDonThuoc()
        {
            return donThuocDAO.GetAll();
        }

        public bool ThemDonThuoc(DonThuocDTO donThuoc)
        {
            ValidateDonThuoc(donThuoc);
            return donThuocDAO.Insert(donThuoc);
        }

        public bool CapNhatDonThuoc(DonThuocDTO donThuoc)
        {
            if (string.IsNullOrEmpty(donThuoc.maDonThuoc))
            {
                throw new ArgumentException("Mã đơn thuốc không được để trống!");
            }
            ValidateDonThuoc(donThuoc);
            return donThuocDAO.Update(donThuoc);
        }

        public bool XoaDonThuoc(string maDonThuoc)
        {
            if (string.IsNullOrEmpty(maDonThuoc))
            {
                throw new ArgumentException("Mã đơn thuốc không được để trống!");
            }

            // Xóa chi tiết đơn thuốc trước
            chiTietDonThuocDAO.DeleteByMaDonThuoc(maDonThuoc);

            return donThuocDAO.Delete(maDonThuoc);
        }

        public List<DonThuocDTO> TimKiemDonThuoc(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return LayDanhSachDonThuoc();
            }
            return donThuocDAO.Search(keyword);
        }

        public bool ThemDonThuocVoiChiTiet(DonThuocDTO donThuoc, List<ChiTietDonThuocDTO> danhSachChiTiet)
        {
            ValidateDonThuoc(donThuoc);

            if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
            {
                throw new ArgumentException("Đơn thuốc phải có ít nhất một chi tiết!");
            }

            // Thêm đơn thuốc
            if (!donThuocDAO.Insert(donThuoc))
            {
                return false;
            }

            // Thêm chi tiết đơn thuốc
            foreach (var chiTiet in danhSachChiTiet)
            {
                chiTiet.maDonThuoc = donThuoc.maDonThuoc;
                if (!chiTietDonThuocDAO.Insert(chiTiet))
                {
                    // Rollback nếu thất bại
                    donThuocDAO.Delete(donThuoc.maDonThuoc);
                    return false;
                }
            }

            return true;
        }

        private void ValidateDonThuoc(DonThuocDTO donThuoc)
        {
            if (string.IsNullOrEmpty(donThuoc.maKhamBenh))
            {
                throw new ArgumentException("Mã khám bệnh không được để trống!");
            }

            if (donThuoc.ngayKe == DateTime.MinValue)
            {
                throw new ArgumentException("Ngày kê đơn không hợp lệ!");
            }
        }
    }
}
