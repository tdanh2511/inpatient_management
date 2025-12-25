using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.BUS
{
    internal class ChiTietDonThuocBUS
    {
        private ChiTietDonThuocDAO chiTietDonThuocDAO = new ChiTietDonThuocDAO();

        public List<ChiTietDonThuocDTO> LayDanhSachChiTiet()
        {
            return chiTietDonThuocDAO.GetAll();
        }

        public List<ChiTietDonThuocDTO> LayChiTietTheoMaDonThuoc(string maDonThuoc)
        {
            if (string.IsNullOrEmpty(maDonThuoc))
            {
                throw new ArgumentException("Mã đơn thuốc không được để trống!");
            }
            return chiTietDonThuocDAO.GetByMaDonThuoc(maDonThuoc);
        }

        public ChiTietDonThuocDTO LayChiTietTheoMa(string maChiTietDonThuoc)
        {
            if (string.IsNullOrEmpty(maChiTietDonThuoc))
            {
                throw new ArgumentException("Mã chi tiết đơn thuốc không được để trống!");
            }
            return chiTietDonThuocDAO.GetByMa(maChiTietDonThuoc);
        }

        public bool ThemChiTiet(ChiTietDonThuocDTO chiTiet)
        {
            ValidateChiTiet(chiTiet);
            return chiTietDonThuocDAO.Insert(chiTiet);
        }

        public bool CapNhatChiTiet(ChiTietDonThuocDTO chiTiet)
        {
            if (string.IsNullOrEmpty(chiTiet.maChiTietDonThuoc))
            {
                throw new ArgumentException("Mã chi tiết đơn thuốc không được để trống!");
            }
            ValidateChiTiet(chiTiet);
            return chiTietDonThuocDAO.Update(chiTiet);
        }

        public bool XoaChiTiet(string maChiTietDonThuoc)
        {
            if (string.IsNullOrEmpty(maChiTietDonThuoc))
            {
                throw new ArgumentException("Mã chi tiết đơn thuốc không được để trống!");
            }
            return chiTietDonThuocDAO.Delete(maChiTietDonThuoc);
        }

        public bool XoaChiTietTheoMaDonThuoc(string maDonThuoc)
        {
            if (string.IsNullOrEmpty(maDonThuoc))
            {
                throw new ArgumentException("Mã đơn thuốc không được để trống!");
            }
            return chiTietDonThuocDAO.DeleteByMaDonThuoc(maDonThuoc);
        }

        private void ValidateChiTiet(ChiTietDonThuocDTO chiTiet)
        {
            if (string.IsNullOrEmpty(chiTiet.maDonThuoc))
            {
                throw new ArgumentException("Mã đơn thuốc không được để trống!");
            }

            if (string.IsNullOrEmpty(chiTiet.maThuoc))
            {
                throw new ArgumentException("Mã thuốc không được để trống!");
            }

            if (chiTiet.soLuong <= 0)
            {
                throw new ArgumentException("Số lượng phải lớn hơn 0!");
            }
        }
    }
}
