using System;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormPopupChiTietHoaDon : Form
    {
        public string SelectedMaDichVu { get; set; }
        public string SelectedTenDichVu { get; set; }
        public decimal SelectedDonGia { get; set; }

        public FormPopupChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void btnChonDichVu_Click(object sender, EventArgs e)
        {
            var popup = new FormDanhSachDichVu(); // Giả lập danh sách dịch vụ
            if (popup.ShowDialog() == DialogResult.OK)
            {
                txtMaDichVu.Text = popup.SelectedMaDichVu;
                txtTenDichVu.Text = popup.SelectedTenDichVu;
                txtDonGia.Text = popup.SelectedDonGia.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Chỉ demo logic
            MessageBox.Show($"Đã thêm dịch vụ: {txtMaDichVu.Text}, {txtTenDichVu.Text}, Số lượng: {txtSoLuong.Text}, Ghi chú: {txtGhiChu.Text}");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
