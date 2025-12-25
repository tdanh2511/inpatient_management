using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InpatientManagerSystem.BUS
{
    public class DichVuBUS
    {
        private DichVuDAO dichVuDAO = new DichVuDAO();

 // Lấy tất cả dịch vụ
        public List<DichVu> LayDanhSachDichVu()
        {
     return dichVuDAO.GetAll();
        }

        // Thêm dịch vụ
        public bool ThemDichVu(DichVu dichVu)
  {
       // Validate dữ liệu
            ValidateDichVu(dichVu);

     // Kiểm tra mã dịch vụ đã tồn tại
       if (dichVuDAO.CheckMaDichVuExists(dichVu.MaDichVu))
    {
         throw new Exception("Mã dịch vụ đã tồn tại trong hệ thống!");
        }

    return dichVuDAO.Insert(dichVu);
   }

        // Cập nhật dịch vụ
 public bool CapNhatDichVu(DichVu dichVu)
        {
   // Validate dữ liệu
        ValidateDichVu(dichVu);

return dichVuDAO.Update(dichVu);
      }

        // Xóa dịch vụ
        public bool XoaDichVu(string maDichVu)
 {
   if (string.IsNullOrEmpty(maDichVu))
 {
      throw new ArgumentException("Mã dịch vụ không được để trống!");
            }

      return dichVuDAO.Delete(maDichVu);
    }

        // Tìm kiếm dịch vụ
   public List<DichVu> TimKiemDichVu(string keyword)
        {
      if (string.IsNullOrEmpty(keyword))
       {
   return LayDanhSachDichVu();
      }

 return dichVuDAO.Search(keyword);
      }

 // Lấy dịch vụ theo mã
        public DichVu LayDichVuTheoMa(string maDichVu)
   {
   if (string.IsNullOrEmpty(maDichVu))
         {
      throw new ArgumentException("Mã dịch vụ không được để trống!");
     }

 return dichVuDAO.GetByMa(maDichVu);
        }

        // Lấy mã dịch vụ tiếp theo
   public string LayMaDichVuTiepTheo()
        {
  return dichVuDAO.GetNextMaDichVu();
 }

 // Validate dữ liệu dịch vụ
        private void ValidateDichVu(DichVu dichVu)
     {
       // Kiểm tra các trường bắt buộc
      if (string.IsNullOrWhiteSpace(dichVu.MaDichVu))
            {
           throw new ArgumentException("Mã dịch vụ không được để trống!");
     }

  if (string.IsNullOrWhiteSpace(dichVu.TenDichVu))
        {
           throw new ArgumentException("Tên dịch vụ không được để trống!");
       }

       if (string.IsNullOrWhiteSpace(dichVu.LoaiDichVu))
 {
        throw new ArgumentException("Loại dịch vụ không được để trống!");
            }

    // Validate định dạng mã dịch vụ (DV + số)
   if (!System.Text.RegularExpressions.Regex.IsMatch(dichVu.MaDichVu, @"^DV\d+$"))
            {
  throw new ArgumentException("Mã dịch vụ phải có định dạng DV theo sau bởi số (VD: DV001)!");
            }

    // Validate đơn giá
  if (dichVu.DonGia < 0)
 {
   throw new ArgumentException("Đơn giá không được âm!");
     }

     if (dichVu.DonGia > 999999999)
    {
    throw new ArgumentException("Đơn giá quá lớn!");
  }
        }
    }
}
