using System;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormThanhToan : Form
    {
        public FormThanhToan()
        {
            InitializeComponent();
        }

        private void btnThemTT_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string maHoaDon = txtMaHoaDon.Text;
            decimal soTien;
            if (!decimal.TryParse(txtSoTien.Text, out soTien))
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!");
                return;
            }
            string phuongThuc = cbPhuongThuc.Text;
            string ghiChu = txtGhiChu.Text;

            // Thêm vào DataGridView (demo logic)
            dgvThanhToan.Rows.Add(maHoaDon, soTien, phuongThuc, ghiChu, DateTime.Now);

            // Cập nhật nhãn tổng tiền, đã thanh toán (demo logic)
            lblTongTien.Text = $"Tổng Thanh Toán: {TinhTongThanhToan()}";
        }

        private void btnSuaTT_Click(object sender, EventArgs e)
        {
            if (dgvThanhToan.CurrentRow != null)
            {
                dgvThanhToan.CurrentRow.Cells[1].Value = txtSoTien.Text;
                dgvThanhToan.CurrentRow.Cells[2].Value = cbPhuongThuc.Text;
                dgvThanhToan.CurrentRow.Cells[3].Value = txtGhiChu.Text;
                lblTongTien.Text = $"Tổng Thanh Toán: {TinhTongThanhToan()}";
            }
        }

        private void btnXoaTT_Click(object sender, EventArgs e)
        {
            if (dgvThanhToan.CurrentRow != null)
            {
                dgvThanhToan.Rows.Remove(dgvThanhToan.CurrentRow);
                lblTongTien.Text = $"Tổng Thanh Toán: {TinhTongThanhToan()}";
            }
        }

        private decimal TinhTongThanhToan()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvThanhToan.Rows)
            {
                if (row.Cells[1].Value != null)
                    tong += Convert.ToDecimal(row.Cells[1].Value);
            }
            return tong;
        }

        private void dgvThanhToan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvThanhToan.CurrentRow != null)
            {
                txtMaHoaDon.Text = dgvThanhToan.CurrentRow.Cells[0].Value?.ToString();
                txtSoTien.Text = dgvThanhToan.CurrentRow.Cells[1].Value?.ToString();
                cbPhuongThuc.Text = dgvThanhToan.CurrentRow.Cells[2].Value?.ToString();
                txtGhiChu.Text = dgvThanhToan.CurrentRow.Cells[3].Value?.ToString();
            }
        }

        private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
