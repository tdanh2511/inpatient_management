using System;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormPopupChiTietThuoc : Form
    {
        public string SelectedMaThuoc { get; set; }
        public string SelectedTenThuoc { get; set; }
        public string SelectedDonVi { get; set; }
        public decimal SelectedDonGia { get; set; }
        public FormPopupChiTietThuoc()
        {
            InitializeComponent();
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
                SelectedMaThuoc = dgvThuoc.CurrentRow.Cells["MaThuoc"].Value.ToString();
                SelectedTenThuoc = dgvThuoc.CurrentRow.Cells["TenThuoc"].Value.ToString();
                SelectedDonVi = dgvThuoc.CurrentRow.Cells["DonVi"].Value.ToString();
                SelectedDonGia = Convert.ToDecimal(dgvThuoc.CurrentRow.Cells["DonGia"].Value);

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
            this.Close();
        }
    }
}
