using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InpatientManagerSystem.DTO
{
    public class DichVu
    {
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string LoaiDichVu { get; set; }
        public decimal DonGia { get; set; }
   public string DonViTinh { get; set; }
   public string MoTa { get; set; }
        public bool TrangThai { get; set; }
    }
}
