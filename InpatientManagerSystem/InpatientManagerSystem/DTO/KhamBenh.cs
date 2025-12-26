using System;

namespace InpatientManagerSystem.DTO
{
    public class KhamBenh
    {
        public int STT { get; set; }
        public string MaKhamBenh { get; set; }
        public string MaHoSo { get; set; }
        public string MaBenhNhan { get; set; }
        public string MaBacSi { get; set; }
        public DateTime NgayKham { get; set; }
        public string ChuanDoan { get; set; }

        // Thông tin bổ sung để hiển thị
        public string TenBenhNhan { get; set; }
        public string TenBacSi { get; set; }

        public KhamBenh()
        {
            NgayKham = DateTime.Now;
        }
    }
}
