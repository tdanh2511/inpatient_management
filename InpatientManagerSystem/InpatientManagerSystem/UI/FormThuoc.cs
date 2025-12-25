using System;
using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormThuoc : Form
    {
        public FormThuoc()
        {
            InitializeComponent(); // phải gọi đầu tiên

            // khởi tạo mặc định
            chkTrangThai.Checked = true;
            dtpNgayHetHan.Value = DateTime.Now;

            // Thiết lập các trường ReadOnly
            txtMaThuoc.ReadOnly = true;  // Mã thuốc tự động, không cho sửa
            txtMaThuoc.BackColor = Color.LightGray;  // Đổi màu nền để dễ nhận biết

            // gắn sự kiện
            dataGridView1.CellClick += DataGridView1_CellClick;
            btnLamMoi.Click += BtnLamMoi_Click;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];

                txtMaThuoc.Text = row.Cells["MaThuoc"]?.Value?.ToString() ?? "";
                txtTenThuoc.Text = row.Cells["TenThuoc"]?.Value?.ToString() ?? "";
                txtDonViTinh.Text = row.Cells["DonViTinh"]?.Value?.ToString() ?? "";
                txtDonGia.Text = row.Cells["DonGia"]?.Value?.ToString() ?? "";
                txtSoLuong.Text = row.Cells["SoLuongTon"]?.Value?.ToString() ?? "";
                txtHang.Text = row.Cells["HangSanXuat"]?.Value?.ToString() ?? "";
                txtCongDung.Text = row.Cells["CongDung"]?.Value?.ToString() ?? "";

                if (DateTime.TryParse(row.Cells["NgayHetHan"]?.Value?.ToString(), out DateTime ngay))
                    dtpNgayHetHan.Value = ngay;
                else
                    dtpNgayHetHan.Value = DateTime.Now;

                chkTrangThai.Checked = row.Cells["TrangThai"]?.Value != null && (bool)row.Cells["TrangThai"].Value;
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaThuoc.Text = "";
            txtTenThuoc.Text = "";
            txtDonViTinh.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtHang.Text = "";
            txtCongDung.Text = "";
            txtTimKiem.Text = "";
            dtpNgayHetHan.Value = DateTime.Now;
            chkTrangThai.Checked = true;

            dataGridView1.ClearSelection();
        }

        private void chkTrangThai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtMaThuoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
