using System;

namespace InpatientManagerSystem.DTO
{
    public class HoSo
    {
        public int STT { get; set; }
        public string MaHoSo { get; set; }
        public string MaBacSi { get; set; }
        public string MaBenhNhan { get; set; }
        public DateTime NgayNhapVien { get; set; }
        public string LyDo { get; set; }
        public string TrangThai { get; set; }

        // Thông tin bổ sung để hiển thị
        public string TenBenhNhan { get; set; }
        public string TenBacSi { get; set; }

        // Property để hiển thị trong ComboBox
        public string DisplayText
        {
            get
            {
                if (string.IsNullOrEmpty(MaHoSo))
                {
                    return TenBenhNhan ?? "-- Chọn hồ sơ --";
                }
                return $"{MaHoSo} - {TenBenhNhan} - {TrangThai}";
            }
        }

        public HoSo()
        {
            NgayNhapVien = DateTime.Now;
            TrangThai = "Đang điều trị";
        }
    }
}
