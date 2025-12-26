using System;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormPopupChiTietDonThuoc : Form
    {
        public FormPopupChiTietDonThuoc()
        {
            InitializeComponent();
        }

        // Event để trả dữ liệu về FormDonThuoc
        public event Action<string, string, string, decimal, int, string> ThuocSaved;

        private void FormPopupChiTietDonThuoc_Load(object sender, EventArgs e)
        {
            txtSoLuong.Text = "1";
        }

        private void btnChonThuoc_Click(object sender, EventArgs e)
        {
            var popup = new FormPopupChiTietThuoc();
            if (popup.ShowDialog() == DialogResult.OK)
            {
                txtMaThuoc.Text = popup.SelectedMaThuoc;
                txtTenThuoc.Text = popup.SelectedTenThuoc;
                txtDonVi.Text = popup.SelectedDonVi;
                txtDonGia.Text = popup.SelectedDonGia.ToString("N0");
                TinhThanhTien();
            }
        }

        public void LoadChiTiet(string maThuoc, string tenThuoc, string donVi, decimal donGia, int soLuong, string lieuLuong, string ghiChu)
        {
            txtMaThuoc.Text = maThuoc;
            txtTenThuoc.Text = tenThuoc;
            txtDonVi.Text = donVi;
            txtDonGia.Text = donGia.ToString("N0");
            txtSoLuong.Text = soLuong.ToString();
            txtLieuLuong.Text = lieuLuong;
            txtGhiChu.Text = ghiChu;
            TinhThanhTien();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaThuoc.Text))
            {
                MessageBox.Show("Vui lòng chọn thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Replace(",", "").Replace(".", ""), out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ghiChu = txtGhiChu.Text;

            // Gọi event để gửi dữ liệu trở lại FormDonThuoc
            ThuocSaved?.Invoke(
                txtMaThuoc.Text,
                txtTenThuoc.Text,
                txtDonVi.Text,
                donGia,
                soLuong,
                ghiChu
            );

            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void TinhThanhTien()
        {
            if (decimal.TryParse(txtDonGia.Text.Replace(",", "").Replace(".", ""), out decimal donGia) &&
                int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                decimal thanhTien = donGia * soLuong;
                // txtThanhTien.Text = thanhTien.ToString("N0");
            }
        }

        private void txtMaThuoc_TextChanged(object sender, EventArgs e)
        {
            // Auto-search thuốc theo mã nếu cần
        }

        private void txtTenThuoc_TextChanged(object sender, EventArgs e)
        {
            // Xử lý khi tên thuốc thay đổi nếu cần
        }
    }
}
