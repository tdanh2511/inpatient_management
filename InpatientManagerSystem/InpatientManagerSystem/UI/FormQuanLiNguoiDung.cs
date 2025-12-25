using InpatientManagerSystem.BUS;
using InpatientManagerSystem.DAO;
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
    public partial class FormQuanLiNguoiDung : Form
    {
        private NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        public FormQuanLiNguoiDung()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
            txtTimKiem.Clear();
        }

        private void QuanLiNguoiDung_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiDung nd = new NguoiDung
                {
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    VaiTro = cboVaiTro.Text,
                    Email = txtEmail.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    TrangThai = cboTrangThai.Text == "Hoạt động"
                };

                bool result = nguoiDungBUS.Insert(nd);

                if (result)
                {
                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm người dùng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load danh sách
        private void LoadDanhSach()
        {
            try
            {
                List<NguoiDung> danhSach = nguoiDungBUS.LayDanhSachNguoiDung();
                dgvNguoiDung.DataSource = null;
                dgvNguoiDung.DataSource = danhSach;

                CustomizeDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tùy chỉnh DataGridView
        private void CustomizeDataGridView()
        {
            if (dgvNguoiDung.Columns.Count > 0)
            {
                dgvNguoiDung.Columns["MaNguoiDung"].HeaderText = "Mã ND";
                dgvNguoiDung.Columns["MaNguoiDung"].Width = 80;

                dgvNguoiDung.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
                dgvNguoiDung.Columns["TenDangNhap"].Width = 120;

                dgvNguoiDung.Columns["MatKhau"].Visible = false;

                dgvNguoiDung.Columns["HoTen"].HeaderText = "Họ và tên";
                dgvNguoiDung.Columns["HoTen"].Width = 150;

                dgvNguoiDung.Columns["VaiTro"].HeaderText = "Vai trò";
                dgvNguoiDung.Columns["VaiTro"].Width = 100;

                dgvNguoiDung.Columns["Email"].HeaderText = "Email";
                dgvNguoiDung.Columns["Email"].Width = 150;

                dgvNguoiDung.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                dgvNguoiDung.Columns["SoDienThoai"].Width = 100;

                dgvNguoiDung.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvNguoiDung.Columns["TrangThai"].Width = 80;

                dgvNguoiDung.Columns["NgayTao"].HeaderText = "Ngày tạo";
                dgvNguoiDung.Columns["NgayTao"].Width = 100;
                dgvNguoiDung.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
    }
}
