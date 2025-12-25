using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InpatientManagerSystem.BUS
{
    public class PhongBUS
    {
    private PhongDAO phongDAO = new PhongDAO();

        // Lấy tất cả phòng
        public List<Phong> LayDanhSachPhong()
   {
       return phongDAO.GetAll();
        }

   // Thêm phòng
  public bool ThemPhong(Phong phong)
     {
  // Validate dữ liệu
    ValidatePhong(phong);

  // Kiểm tra tên phòng đã tồn tại
  if (phongDAO.CheckTenPhongExists(phong.TenPhong))
  {
 throw new Exception("Tên phòng đã tồn tại trong hệ thống!");
            }

    return phongDAO.Insert(phong);
   }

   // Cập nhật phòng
     public bool CapNhatPhong(Phong phong)
        {
 // Validate dữ liệu
       ValidatePhong(phong);

      // Kiểm tra tên phòng đã tồn tại (trừ phòng hiện tại)
if (phongDAO.CheckTenPhongExists(phong.TenPhong, phong.MaPhong))
       {
       throw new Exception("Tên phòng đã tồn tại trong hệ thống!");
      }

  return phongDAO.Update(phong);
        }

        // Xóa phòng
        public bool XoaPhong(string maPhong)
     {
if (string.IsNullOrEmpty(maPhong))
        {
    throw new ArgumentException("Mã phòng không được để trống!");
     }

   return phongDAO.Delete(maPhong);
 }

      // Tìm kiếm phòng
   public List<Phong> TimKiemPhong(string keyword)
        {
     if (string.IsNullOrEmpty(keyword))
   {
    return LayDanhSachPhong();
}

         return phongDAO.Search(keyword);
   }

        // Lấy phòng theo mã
  public Phong LayPhongTheoMa(string maPhong)
        {
      if (string.IsNullOrEmpty(maPhong))
   {
     throw new ArgumentException("Mã phòng không được để trống!");
  }

   return phongDAO.GetByMa(maPhong);
        }

// Validate dữ liệu phòng
 private void ValidatePhong(Phong phong)
 {
 // Kiểm tra các trường bắt buộc
  if (string.IsNullOrWhiteSpace(phong.TenPhong))
{
        throw new ArgumentException("Tên phòng không được để trống!");
        }

   if (string.IsNullOrWhiteSpace(phong.LoaiPhong))
    {
 throw new ArgumentException("Loại phòng không được để trống!");
    }

    // Validate độ dài tên phòng (tối đa 3 ký tự theo database)
if (phong.TenPhong.Length > 3)
      {
     throw new ArgumentException("Tên phòng không được quá 3 ký tự!");
      }

// Validate loại phòng
  if (phong.LoaiPhong != "Thường" && phong.LoaiPhong != "Dịch vụ")
  {
    throw new ArgumentException("Loại phòng chỉ có thể là 'Thường' hoặc 'Dịch vụ'!");
    }
        }
    }
}
