using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InpatientManagerSystem.DTO
{
    public class BacSi
    {
        public int Stt { get; set; }
        public string MaBacSi { get; set; }
        public int MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string Cccd { get; set; }
        public string DiaChi { get; set; }
        public int KinhNghiem { get; set; }
        public string ChuyenKhoa { get; set; }
    }
}
