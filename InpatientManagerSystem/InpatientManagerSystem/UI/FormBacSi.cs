using InpatientManagerSystem.BUS;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InpatientManagerSystem.UI
{
    public partial class FormBacSi : Form
    {
        private readonly NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        private readonly BacSiBUS bacSiBUS = new BacSiBUS();
        private List<NguoiDung> dsNguoiDungBacSi;

        

        public FormBacSi()
        {
            InitializeComponent();
        }

        private void FormBacSi_Load(object sender, EventArgs e)
        {
            LoadComboNguoiDungBacSi();
            LoadDanhSach();
            cboMaND.SelectedIndexChanged += CboMaND_SelectedIndexChanged;

        }

        private void CboMaND_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        // Load danh sách
        private void LoadDanhSach()
        {
            try
            {
                List<BacSi> danhSach = bacSiBUS.LayDanhSachBacSi();
                dgvBacSi.DataSource = null;
                dgvBacSi.DataSource = danhSach;

                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomizeDataGridView()
        {
            if (dgvBacSi.Columns.Count > 0)
            {
                dgvBacSi.Columns["Stt"].HeaderText = "STT";
                dgvBacSi.Columns["Stt"].Width = 60;

                dgvBacSi.Columns["MaBacSi"].HeaderText = "Mã BS";
                dgvBacSi.Columns["MaBacSi"].Width = 80;

                dgvBacSi.Columns["MaNguoiDung"].HeaderText = "Mã ND";
                dgvBacSi.Columns["MaNguoiDung"].Width = 80;

                dgvBacSi.Columns["HoTen"].HeaderText = "Họ tên";
                dgvBacSi.Columns["HoTen"].Width = 150;

                dgvBacSi.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dgvBacSi.Columns["NgaySinh"].Width = 100;
                dgvBacSi.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvBacSi.Columns["GioiTinh"].HeaderText = "Giới tính";
                dgvBacSi.Columns["GioiTinh"].Width = 80;

                dgvBacSi.Columns["Cccd"].HeaderText = "CCCD";
                dgvBacSi.Columns["Cccd"].Width = 120;

                dgvBacSi.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvBacSi.Columns["DiaChi"].Width = 200;

                dgvBacSi.Columns["KinhNghiem"].HeaderText = "Kinh nghiệm";
                dgvBacSi.Columns["KinhNghiem"].Width = 100;

                dgvBacSi.Columns["ChuyenKhoa"].HeaderText = "Chuyên khoa";
                dgvBacSi.Columns["ChuyenKhoa"].Width = 120;
            }
        }

        private void LoadComboNguoiDungBacSi()
        {
            dsNguoiDungBacSi = nguoiDungBUS.LayNguoiDungRoleBacSi();

            cboMaND.DataSource = dsNguoiDungBacSi;
            cboMaND.DisplayMember = "MaNguoiDung";   // hiện mã người dùng
            cboMaND.ValueMember = "MaNguoiDung";     // giá trị thực
            cboMaND.SelectedIndex = -1;              // chưa chọn gì
        }
    }
}
