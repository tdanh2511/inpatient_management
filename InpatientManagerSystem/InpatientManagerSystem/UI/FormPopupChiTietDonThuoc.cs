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

        private void btnChonThuoc_Click(object sender, EventArgs e)
        {
            var popup = new FormPopupChiTietThuoc();
            if (popup.ShowDialog() == DialogResult.OK)
            {
                txtMaThuoc.Text = popup.SelectedMaThuoc;
                txtTenThuoc.Text = popup.SelectedTenThuoc;
                txtDonVi.Text = popup.SelectedDonVi;
                txtDonGia.Text = popup.SelectedDonGia.ToString();
            }
        }
        public void LoadChiTiet(string maThuoc, string tenThuoc, string donVi, decimal donGia, int soLuong, string lieuLuong, string ghiChu)
        {
            txtMaThuoc.Text = maThuoc;
            txtTenThuoc.Text = tenThuoc;
            txtDonVi.Text = donVi;
            txtDonGia.Text = donGia.ToString();
            txtSoLuong.Text = soLuong.ToString();
            txtLieuLuong.Text = lieuLuong;
            txtGhiChu.Text = ghiChu;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Gọi event để gửi dữ liệu trở lại FormDonThuoc
            int soLuong = int.TryParse(txtSoLuong.Text, out int sl) ? sl : 0;
            string ghiChu = txtGhiChu.Text;

            ThuocSaved?.Invoke(
                txtMaThuoc.Text,
                txtTenThuoc.Text,
                txtDonVi.Text,
                decimal.Parse(txtDonGia.Text),
                soLuong,
                ghiChu
            );

            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
