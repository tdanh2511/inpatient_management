using InpatientManagerSystem.BUS;
using System;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormPopupChiTietThuoc : Form
    {
        private ThuocBUS thuocBUS = new ThuocBUS();

        public string SelectedMaThuoc { get; set; }
        public string SelectedTenThuoc { get; set; }
        public string SelectedDonVi { get; set; }
        public decimal SelectedDonGia { get; set; }

        public FormPopupChiTietThuoc()
        {
            InitializeComponent();
            this.Load += FormPopupChiTietThuoc_Load;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            dgvThuoc.CellDoubleClick += dgvThuoc_CellDoubleClick;
        }

        private void FormPopupChiTietThuoc_Load(object sender, EventArgs e)
        {
            LoadDanhSachThuoc();
        }

        private void LoadDanhSachThuoc()
        {
            try
            {
                var list = thuocBUS.LayDanhSachThuoc();
                dgvThuoc.DataSource = list;

                // Format columns
                if (dgvThuoc.Columns["maThuoc"] != null)
                    dgvThuoc.Columns["maThuoc"].HeaderText = "Mã thuốc";
                if (dgvThuoc.Columns["tenThuoc"] != null)
                    dgvThuoc.Columns["tenThuoc"].HeaderText = "Tên thuốc";
                if (dgvThuoc.Columns["donViTinh"] != null)
                    dgvThuoc.Columns["donViTinh"].HeaderText = "Đơn vị";
                if (dgvThuoc.Columns["donGia"] != null)
                    dgvThuoc.Columns["donGia"].HeaderText = "Đơn giá";
                if (dgvThuoc.Columns["soLuongTon"] != null)
                    dgvThuoc.Columns["soLuongTon"].HeaderText = "Số lượng tồn";

                // Ẩn các cột không cần thiết
                if (dgvThuoc.Columns["hangSanXuat"] != null)
                    dgvThuoc.Columns["hangSanXuat"].Visible = false;
                if (dgvThuoc.Columns["congDung"] != null)
                    dgvThuoc.Columns["congDung"].Visible = false;
                if (dgvThuoc.Columns["ngayHetHan"] != null)
                    dgvThuoc.Columns["ngayHetHan"].Visible = false;
                if (dgvThuoc.Columns["trangThai"] != null)
                    dgvThuoc.Columns["trangThai"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                var list = thuocBUS.TimKiemThuoc(keyword);
                dgvThuoc.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvThuoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectCurrentRow();
            }
        }

        private void SelectCurrentRow()
        {
            if (dgvThuoc.CurrentRow != null)
            {
                SelectedMaThuoc = dgvThuoc.CurrentRow.Cells["maThuoc"].Value?.ToString() ?? "";
                SelectedTenThuoc = dgvThuoc.CurrentRow.Cells["tenThuoc"].Value?.ToString() ?? "";
                SelectedDonVi = dgvThuoc.CurrentRow.Cells["donViTinh"].Value?.ToString() ?? "";
                SelectedDonGia = Convert.ToDecimal(dgvThuoc.CurrentRow.Cells["donGia"].Value ?? 0);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnChon_Click_1(object sender, EventArgs e)
        {
            SelectCurrentRow();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
