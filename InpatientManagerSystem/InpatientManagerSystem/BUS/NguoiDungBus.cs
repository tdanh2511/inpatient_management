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
    public class NguoiDungBUS
    {
        private NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();

        // Lấy tất cả người dùng
        public List<NguoiDung> LayDanhSachNguoiDung()
        {
            return nguoiDungDAO.GetAll();
        }

        // Thêm người dùng
        public bool ThemNguoiDung(NguoiDung nguoiDung)
        {
            // Validate dữ liệu
            ValidateNguoiDung(nguoiDung);

            // Kiểm tra tên đăng nhập đã tồn tại
            if (nguoiDungDAO.CheckTenDangNhapExists(nguoiDung.TenDangNhap))
            {
                throw new Exception("Tên đăng nhập đã tồn tại trong hệ thống!");
            }

            return nguoiDungDAO.Insert(nguoiDung);
        }

        // Cập nhật người dùng
        public bool CapNhatNguoiDung(NguoiDung nguoiDung)
        {
            // Validate dữ liệu
            ValidateNguoiDung(nguoiDung);

            // Kiểm tra tên đăng nhập đã tồn tại (trừ người dùng hiện tại)
            if (nguoiDungDAO.CheckTenDangNhapExists(nguoiDung.TenDangNhap, nguoiDung.MaNguoiDung))
            {
                throw new Exception("Tên đăng nhập đã tồn tại trong hệ thống!");
            }

            return nguoiDungDAO.Update(nguoiDung);
        }

        // Xóa người dùng
        public bool XoaNguoiDung(int maNguoiDung)
        {
            if (maNguoiDung <= 0)
            {
                throw new ArgumentException("Mã người dùng không hợp lệ!");
            }

            return nguoiDungDAO.Delete(maNguoiDung);
        }

        // Tìm kiếm người dùng
        public List<NguoiDung> TimKiemNguoiDung(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return LayDanhSachNguoiDung();
            }

            return nguoiDungDAO.Search(keyword);
        }

        // Lấy người dùng theo mã
        public NguoiDung LayNguoiDungTheoMa(int maNguoiDung)
        {
            if (maNguoiDung <= 0)
            {
                throw new ArgumentException("Mã người dùng không hợp lệ!");
            }

            return nguoiDungDAO.GetByMa(maNguoiDung);
        }

        // Validate dữ liệu người dùng
        private void ValidateNguoiDung(NguoiDung nguoiDung)
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(nguoiDung.TenDangNhap))
            {
                throw new ArgumentException("Tên đăng nhập không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(nguoiDung.MatKhau))
            {
                throw new ArgumentException("Mật khẩu không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(nguoiDung.HoTen))
            {
                throw new ArgumentException("Họ tên không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(nguoiDung.VaiTro))
            {
                throw new ArgumentException("Vai trò không được để trống!");
            }

            // Validate độ dài tên đăng nhập
            if (nguoiDung.TenDangNhap.Length < 3 || nguoiDung.TenDangNhap.Length > 50)
            {
                throw new ArgumentException("Tên đăng nhập phải từ 3-50 ký tự!");
            }

            // Validate độ dài mật khẩu
            if (nguoiDung.MatKhau.Length < 6)
            {
                throw new ArgumentException("Mật khẩu phải có ít nhất 6 ký tự!");
            }

            // Validate email nếu có
            if (!string.IsNullOrWhiteSpace(nguoiDung.Email))
            {
                if (!Regex.IsMatch(nguoiDung.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new ArgumentException("Email không hợp lệ!");
                }
            }

            // Validate số điện thoại nếu có
            if (!string.IsNullOrWhiteSpace(nguoiDung.SoDienThoai))
            {
                if (!Regex.IsMatch(nguoiDung.SoDienThoai, @"^[0-9]{10,11}$"))
                {
                    throw new ArgumentException("Số điện thoại phải là 10-11 chữ số!");
                }
            }

            // Validate vai trò
            if (nguoiDung.VaiTro != "Admin" && nguoiDung.VaiTro != "BacSi" && nguoiDung.VaiTro != "LeTan")
            {
                throw new ArgumentException("Vai trò chỉ có thể là Admin, BacSi hoặc LeTan!");
            }
        }
    }
}
