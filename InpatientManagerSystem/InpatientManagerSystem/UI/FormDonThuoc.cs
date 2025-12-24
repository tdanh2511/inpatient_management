using System;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormDonThuoc : Form
    {
        public FormDonThuoc()
        {
            InitializeComponent();
        }

        private void btnThemCT_Click(object sender, System.EventArgs e)
        {
            var popup = new FormPopupChiTietDonThuoc();
            popup.ThuocSaved += (ma, ten, donVi, donGia, soLuong, ghiChu) =>
            {
                // Thêm vào DataGridView chi tiết đơn thuốc
                dgvChiTietDonThuoc.Rows.Add(ma, ten, donVi, donGia, soLuong, ghiChu);
            };
            popup.ShowDialog();
        }

        private void btnSuaCT_Click(object sender, System.EventArgs e)
        {
            if (dgvChiTietDonThuoc.CurrentRow != null)
            {
                var row = dgvChiTietDonThuoc.CurrentRow;
                var popup = new FormPopupChiTietDonThuoc();
                popup.LoadChiTiet(
                    row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(),
                    row.Cells[2].Value.ToString(),
                    Convert.ToDecimal(row.Cells[3].Value),
                    Convert.ToInt32(row.Cells[4].Value),
                    row.Cells[5].Value.ToString(), // Liều lượng
                    row.Cells[6].Value?.ToString() // Ghi chú nếu có
                );

                popup.ThuocSaved += (ma, ten, donVi, donGia, soLuong, ghiChu) =>
                {
                    row.Cells[0].Value = ma;
                    row.Cells[1].Value = ten;
                    row.Cells[2].Value = donVi;
                    row.Cells[3].Value = donGia;
                    row.Cells[4].Value = soLuong;
                    // Giữ nguyên giá trị liều lượng hiện tại
                    row.Cells[6].Value = ghiChu;
                };

                popup.ShowDialog();
            }
        }
    }
}
