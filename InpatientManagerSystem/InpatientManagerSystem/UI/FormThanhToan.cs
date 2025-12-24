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
            decimal soTien;
            if (!decimal.TryParse(txtSoTien.Text, out soTien))
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!");
                return;
            }
            string phuongThuc = cbPhuongThuc.Text;
            string ghiChu = txtGhiChu.Text;

            // Thêm vào DataGridView (demo logic)
            dgvChiTiet.Rows.Add(soTien, phuongThuc, ghiChu, DateTime.Now);

            // Cập nhật nhãn tổng tiền, đã thanh toán (demo logic)
            lblTongTien.Text = $"Tổng Thanh Toán: {TinhTongThanhToan()}";
        }

        private void btnSuaTT_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                dgvChiTiet.CurrentRow.Cells[0].Value = txtSoTien.Text;
                dgvChiTiet.CurrentRow.Cells[1].Value = cbPhuongThuc.Text;
                dgvChiTiet.CurrentRow.Cells[2].Value = txtGhiChu.Text;
                lblTongTien.Text = $"Tổng Thanh Toán: {TinhTongThanhToan()}";
            }
        }

        private void btnXoaTT_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                dgvChiTiet.Rows.Remove(dgvChiTiet.CurrentRow);
                lblTongTien.Text = $"Tổng Thanh Toán: {TinhTongThanhToan()}";
            }
        }

        private decimal TinhTongThanhToan()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dgvChiTiet.Rows)
            {
                if (row.Cells[0].Value != null)
                    tong += Convert.ToDecimal(row.Cells[0].Value);
            }
            return tong;
        }

        private void dgvChiTiet_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                txtSoTien.Text = dgvChiTiet.CurrentRow.Cells[0].Value?.ToString();
                cbPhuongThuc.Text = dgvChiTiet.CurrentRow.Cells[1].Value?.ToString();
                txtGhiChu.Text = dgvChiTiet.CurrentRow.Cells[2].Value?.ToString();
            }
        }
    }
}
