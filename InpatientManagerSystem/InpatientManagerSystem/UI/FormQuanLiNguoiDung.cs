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
using InpatientManagerSystem.BUS;
using InpatientManagerSystem.DTO;

namespace InpatientManagerSystem.UI
{
    public partial class FormQuanLiNguoiDung : Form
    {
        private NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
<<<<<<< HEAD
        private int selectedMaNguoiDung = 0;

=======
>>>>>>> bf18f79f7e8c99d674adda1632c430a8751d12b9
        public FormQuanLiNguoiDung()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += QuanLiNguoiDung_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvNguoiDung.CellClick += DataGridView1_CellClick;
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
        }

<<<<<<< HEAD
        private void QuanLiNguoiDung_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            ConfigureDataGridView();
            ClearForm();
            txtMaND.Enabled = false;
            dgvNguoiDung.ReadOnly = true;
            dgvNguoiDung.AllowUserToAddRows = false;
            dgvNguoiDung.AllowUserToDeleteRows = false;
            txtMaND.BackColor = Color.LightGray;
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Cấu hình DataGridView
        private void ConfigureDataGridView()
        {
            dgvNguoiDung.Columns.Clear();
            dgvNguoiDung.AutoGenerateColumns = false;

            // Khóa chỉnh sửa trực tiếp trong DataGridView
            dgvNguoiDung.ReadOnly = true;
            dgvNguoiDung.AllowUserToAddRows = false;
            dgvNguoiDung.AllowUserToDeleteRows = false;
            dgvNguoiDung.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNguoiDung",
                HeaderText = "Mã ND",
                Name = "MaNguoiDung",
                Width = 80
            });

            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenDangNhap",
                HeaderText = "Tên đăng nhập",
                Name = "TenDangNhap",
                Width = 150
            });

            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTen",
                HeaderText = "Họ tên",
                Name = "HoTen",
                Width = 200
            });

            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VaiTro",
                HeaderText = "Vai trò",
                Name = "VaiTro",
                Width = 100
            });

            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email",
                Width = 200
            });

            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoDienThoai",
                HeaderText = "Số điện thoại",
                Name = "SoDienThoai",
                Width = 120
            });

            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Name = "TrangThai",
                Width = 120
            });

            dgvNguoiDung.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayTao",
                HeaderText = "Ngày tạo",
                Name = "NgayTao",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
        }

        // Tải danh sách người dùng
        private void LoadDanhSach()
        {
            try
            {
                var danhSach = nguoiDungBUS.LayDanhSachNguoiDung();

                // Chuyển đổi TrangThai từ bool sang text
                var displayList = danhSach.Select(nd => new
                {
                    nd.MaNguoiDung,
                    nd.TenDangNhap,
                    nd.HoTen,
                    nd.VaiTro,
                    nd.Email,
                    nd.SoDienThoai,
                    TrangThai = nd.TrangThai ? "Hoạt động" : "Không hoạt động",
                    nd.NgayTao
                }).ToList();

                dgvNguoiDung.DataSource = displayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách người dùng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm người dùng
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra trường hợp đang sửa
                if (selectedMaNguoiDung > 0)
                {
                    var result = MessageBox.Show(
                "Bạn đang ở chế độ sửa. Bạn có muốn chuyển sang thêm mới không?",
            "Xác nhận",
                    MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ClearForm();
                    }
                    else
                    {
                        return;
                    }
                }

                NguoiDung nd = new NguoiDung
                {
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    VaiTro = cboVaiTro.SelectedItem?.ToString() ?? "",
                    Email = txtEmail.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    TrangThai = cboTrangThai.SelectedItem?.ToString() == "Hoạt động",
                    NgayTao = DateTime.Now
                };

                if (nguoiDungBUS.ThemNguoiDung(nd))
                {
                    MessageBox.Show("Thêm người dùng thành công!",
                          "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach();
                    ClearForm();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa người dùng
        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMaNguoiDung <= 0)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần sửa!",
   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NguoiDung nd = new NguoiDung
                {
                    MaNguoiDung = selectedMaNguoiDung,
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    HoTen = txtHoTen.Text.Trim(),
                    VaiTro = cboVaiTro.SelectedItem?.ToString() ?? "",
                    Email = txtEmail.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    TrangThai = cboTrangThai.SelectedItem?.ToString() == "Hoạt động"
                };

                if (nguoiDungBUS.CapNhatNguoiDung(nd))
                {
                    MessageBox.Show("Cập nhật người dùng thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach();
                    ClearForm();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập liệu",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa người dùng
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMaNguoiDung <= 0)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần xóa!",
                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                 "Bạn có chắc chắn muốn xóa người dùng này?",
              "Xác nhận xóa",
                 MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (nguoiDungBUS.XoaNguoiDung(selectedMaNguoiDung))
                    {
                        MessageBox.Show("Xóa người dùng thành công!",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSach();
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tìm kiếm người dùng
        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TxtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TimKiem();
                e.Handled = true;
            }
        }

        private void TimKiem()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                var ketQua = nguoiDungBUS.TimKiemNguoiDung(keyword);

                // Chuyển đổi TrangThai từ bool sang text
                var displayList = ketQua.Select(nd => new
                {
                    nd.MaNguoiDung,
                    nd.TenDangNhap,
                    nd.HoTen,
                    nd.VaiTro,
                    nd.Email,
                    nd.SoDienThoai,
                    TrangThai = nd.TrangThai ? "Hoạt động" : "Không hoạt động",
                    nd.NgayTao
                }).ToList();

                dgvNguoiDung.DataSource = displayList;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy người dùng nào!",
              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
            ClearForm();
        }

        // Chọn người dùng từ DataGridView
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvNguoiDung.Rows[e.RowIndex];

                    selectedMaNguoiDung = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);
                    txtMaND.Text = selectedMaNguoiDung.ToString();
                    txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString() ?? "";
                    txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";

                    string vaiTro = row.Cells["VaiTro"].Value?.ToString() ?? "";
                    cboVaiTro.SelectedItem = vaiTro;

                    txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                    txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";

                    string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
                    cboTrangThai.SelectedItem = trangThai;

                    // Lấy mật khẩu từ database
                    var nguoiDung = nguoiDungBUS.LayNguoiDungTheoMa(selectedMaNguoiDung);
                    if (nguoiDung != null)
                    {
                        txtMatKhau.Text = nguoiDung.MatKhau;
                    }

                    // Đổi màu nút Sửa để người dùng biết đang ở chế độ sửa
                    btnSua.BackColor = Color.FromArgb(241, 196, 15);
                    btnThem.BackColor = Color.FromArgb(46, 204, 113);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn người dùng: " + ex.Message,
            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa form
        private void ClearForm()
        {
            selectedMaNguoiDung = 0;
            txtMaND.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtHoTen.Clear();
            cboVaiTro.SelectedIndex = -1;
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            cboTrangThai.SelectedIndex = 0; // Mặc định là "Hoạt động"
            txtTimKiem.Clear();

            // Reset màu nút
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.BackColor = Color.FromArgb(46, 204, 113);

            // Focus vào textbox đầu tiên
            txtTenDangNhap.Focus();
        }

        private void txtMaND_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {

        }

        private void FormQuanLiNguoiDung_Load(object sender, EventArgs e)
=======
        private void FormQuanLiNguoiDung_Load(object sender, EventArgs e)
        {
            cboVaiTro.Items.AddRange(new object[] { "Admin", "Bác sĩ", "Lễ tân" });
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "Hoạt động", "Không hoạt động" });
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            txtMaND.Enabled = false;
            dgvNguoiDung.ReadOnly = true;                 
            dgvNguoiDung.AllowUserToAddRows = false;      
            dgvNguoiDung.AllowUserToDeleteRows = false;
            LoadDanhSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
>>>>>>> bf18f79f7e8c99d674adda1632c430a8751d12b9
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
                    LoadDanhSach();
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

                dgvNguoiDung.Columns["MatKhau"].Visible = false; // Ẩn mật khẩu

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
