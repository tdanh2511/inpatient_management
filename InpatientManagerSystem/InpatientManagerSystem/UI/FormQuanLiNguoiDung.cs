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
        private int selectedMaNguoiDung = 0;

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
            dataGridView1.CellClick += DataGridView1_CellClick;
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
        }

        private void QuanLiNguoiDung_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            ConfigureDataGridView();
            ClearForm();

            // Thiết lập các trường ReadOnly
            txtMaND.ReadOnly = true;  // Mã người dùng tự động, không cho sửa
            txtMaND.BackColor = Color.LightGray;  // Đổi màu nền để dễ nhận biết

            // Thiết lập ComboBox chỉ cho phép CHỌN, không cho nhập tự do
            cboVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Cấu hình DataGridView
        private void ConfigureDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // Khóa chỉnh sửa trực tiếp trong DataGridView
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaNguoiDung",
                HeaderText = "Mã ND",
                Name = "MaNguoiDung",
                Width = 80
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenDangNhap",
                HeaderText = "Tên đăng nhập",
                Name = "TenDangNhap",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTen",
                HeaderText = "Họ tên",
                Name = "HoTen",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VaiTro",
                HeaderText = "Vai trò",
                Name = "VaiTro",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoDienThoai",
                HeaderText = "Số điện thoại",
                Name = "SoDienThoai",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Name = "TrangThai",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
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

                dataGridView1.DataSource = displayList;
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
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                dataGridView1.DataSource = displayList;

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
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

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
    }
}
