using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InpatientManagerSystem.DAO;
using InpatientManagerSystem.DTO;

namespace InpatientManagerSystem.BUS
{
    internal class ThuocBUS
    {
        private ThuocDAO thuocDAO = new ThuocDAO();

        public List<ThuocDTO> LayDanhSachThuoc()
        {
            return thuocDAO.GetAll();
        }

        public bool ThemThuoc(ThuocDTO thuoc)
        {
            ValidateThuoc(thuoc);
            return thuocDAO.Insert(thuoc);
        }

        public bool CapNhatThuoc(ThuocDTO thuoc)
        {
            ValidateThuoc(thuoc);

            if (string.IsNullOrEmpty(thuoc.maThuoc))
            {
                throw new ArgumentException("Mã thuốc không được để trống!");
            }

            return thuocDAO.Update(thuoc);
        }

        public bool XoaThuoc(string maThuoc)
        {
            if (string.IsNullOrEmpty(maThuoc))
            {
                throw new ArgumentException("Mã thuốc không được để trống!");
            }

            return thuocDAO.Delete(maThuoc);
        }

        public List<ThuocDTO> TimKiemThuoc(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return LayDanhSachThuoc();
            }

            return thuocDAO.Search(keyword);
        }

        public ThuocDTO LayThuocTheoMa(string maThuoc)
        {
            if (string.IsNullOrEmpty(maThuoc))
            {
                throw new ArgumentException("Mã thuốc không được để trống!");
            }

            return thuocDAO.GetByMa(maThuoc);
        }

        public List<ThuocDTO> LayDanhSachThuocHetHan()
        {
            return thuocDAO.GetExpiredMedicines();
        }

        public List<ThuocDTO> LayDanhSachThuocSapHetHan(int soNgay)
        {
            if (soNgay <= 0)
            {
                throw new ArgumentException("Số ngày phải lớn hơn 0!");
            }

            return thuocDAO.GetExpiringSoonMedicines(soNgay);
        }

        public bool KiemTraThuocHetHan(string maThuoc)
        {
            if (string.IsNullOrEmpty(maThuoc))
            {
                throw new ArgumentException("Mã thuốc không được để trống!");
            }

            return thuocDAO.CheckMedicineExpired(maThuoc);
        }

        public List<ThuocDTO> LayDanhSachThuocSapHet(int nguongToiThieu)
        {
            if (nguongToiThieu < 0)
            {
                throw new ArgumentException("Ngưỡng tối thiểu không được âm!");
            }

            return thuocDAO.GetLowStockMedicines(nguongToiThieu);
        }

        public bool CapNhatTonKho(string maThuoc, int soLuongThayDoi)
        {
            if (string.IsNullOrEmpty(maThuoc))
            {
                throw new ArgumentException("Mã thuốc không được để trống!");
            }

            ThuocDTO thuoc = thuocDAO.GetByMa(maThuoc);
            if (thuoc == null)
            {
                throw new Exception("Không tìm thấy thuốc!");
            }

            if (thuoc.soLuongTon + soLuongThayDoi < 0)
            {
                throw new ArgumentException("Số lượng tồn không được âm!");
            }

            return thuocDAO.UpdateStock(maThuoc, soLuongThayDoi);
        }

        private void ValidateThuoc(ThuocDTO thuoc)
        {
            if (string.IsNullOrWhiteSpace(thuoc.tenThuoc))
            {
                throw new ArgumentException("Tên thuốc không được để trống!");
            }

            if (string.IsNullOrWhiteSpace(thuoc.donViTinh))
            {
                throw new ArgumentException("Đơn vị tính không được để trống!");
            }

            if (thuoc.donGia < 0)
            {
                throw new ArgumentException("Đơn giá không được âm!");
            }

            if (thuoc.donGia > 999999999)
            {
                throw new ArgumentException("Đơn giá quá lớn!");
            }

            if (thuoc.soLuongTon < 0)
            {
                throw new ArgumentException("Số lượng tồn không được âm!");
            }

            if (thuoc.ngayHetHan != DateTime.MinValue && thuoc.ngayHetHan < DateTime.Now.Date)
            {
                throw new ArgumentException("Ngày hết hạn phải lớn hơn hoặc bằng ngày hiện tại!");
            }
        }
    }
}
