using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InpatientManagerSystem.BUS
{
    public class NguoiDungBUS
    {
        private NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();
        
        // Lấy tất cả người dùng
        public List<NguoiDung> LayDanhSachNguoiDung()
        {
            return nguoiDungDAO.GetAll();
        }

        public bool Insert(NguoiDung nguoiDung)
        {
            if (string.IsNullOrEmpty(nguoiDung.TenDangNhap) ||
                string.IsNullOrEmpty(nguoiDung.MatKhau) ||
                string.IsNullOrEmpty(nguoiDung.HoTen) ||
                string.IsNullOrEmpty(nguoiDung.VaiTro))
            {
                throw new ArgumentException("Các trường bắt buộc không được để trống.");
            }
            return nguoiDungDAO.Insert(nguoiDung);
        }
    }
}
