using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InpatientManagerSystem.DTO
{
    internal class ThuocDTO
    {
        public string maThuoc { set; get; }

        public string tenThuoc { set; get; }
        public string donViTinh { set; get; }
        public decimal donGia { set; get; }
        public int soLuongTon { set; get; }
        public string hangSanXuat { set; get; }
        public string congDung { set; get; }
        public bool trangThai { set; get; }
        public DateTime ngayHetHan { set; get; }
    }
}
