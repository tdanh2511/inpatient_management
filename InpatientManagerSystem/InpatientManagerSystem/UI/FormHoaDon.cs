using System;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormHoadon : Form
    {
        public FormHoadon()
        {
            InitializeComponent();
        }

        // Event Handlers cho Hóa Đơn
        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            // TODO: Khi chọn hóa đơn, hiển thị chi tiết tương ứng
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thêm hóa đơn mới (logic demo).");
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sửa hóa đơn (logic demo).");
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xóa hóa đơn (logic demo).");
        }

        // Event Handlers cho Chi Tiết Hóa Đơn
        private void btnThemCT_Click(object sender, EventArgs e)
        {
            var popup = new FormPopupChiTietHoaDon();
            popup.ShowDialog();
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            var popup = new FormPopupChiTietHoaDon();
            popup.ShowDialog();
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xóa chi tiết hóa đơn (logic demo).");
        }
    }
}
