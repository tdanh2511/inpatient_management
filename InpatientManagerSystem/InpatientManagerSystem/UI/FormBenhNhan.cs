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
    public partial class FormBenhNhan : Form
    {
        private BenhNhanBUS benhNhanBUS = new BenhNhanBUS();
        private string selectedMaBenhNhan = null;

        public FormBenhNhan()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += FormBenhNhan_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
        }

        private void FormBenhNhan_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            ConfigureDataGridView();
            ClearForm();

            // Thiết lập các trường ReadOnly
            txtMaBN.ReadOnly = true;  // Mã bệnh nhân tự động, không cho sửa
            txtMaBN.BackColor = Color.LightGray;  // Đổi màu nền để dễ nhận biết

            // Thiết lập ComboBox chỉ cho phép CHỌN, không cho nhập tự do
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
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
                DataPropertyName = "MaBenhNhan",
                HeaderText = "Mã BN",
                Name = "MaBenhNhan",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoTen",
                HeaderText = "Họ và tên",
                Name = "HoTen",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CCCD",
                HeaderText = "CCCD",
                Name = "CCCD",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgaySinh",
                HeaderText = "Ngày sinh",
                Name = "NgaySinh",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GioiTinh",
                HeaderText = "Giới tính",
                Name = "GioiTinh",
                Width = 80
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
                DataPropertyName = "BHYT",
                HeaderText = "BHYT",
                Name = "BHYT",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiaChi",
                HeaderText = "Địa chỉ",
                Name = "DiaChi",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        // Tải danh sách bệnh nhân
        private void LoadDanhSach()
        {
            try
            {
                var danhSach = benhNhanBUS.LayDanhSachBenhNhan();
                dataGridView1.DataSource = danhSach;

                // Ẩn cột STT và NgayTao
                if (dataGridView1.Columns.Contains("STT"))
                    dataGridView1.Columns["STT"].Visible = false;
                if (dataGridView1.Columns.Contains("NgayTao"))
                    dataGridView1.Columns["NgayTao"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bệnh nhân: " + ex.Message,
                 "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm bệnh nhân
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra trường hợp đang sửa
                if (!string.IsNullOrEmpty(selectedMaBenhNhan))
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

                BenhNhan bn = new BenhNhan
                {
                    HoTen = txtHoTen.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "",
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    BHYT = txtBHYT.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim()
                };

                if (benhNhanBUS.ThemBenhNhan(bn))
                {
                    MessageBox.Show("Thêm bệnh nhân thành công!",
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

        // Sửa bệnh nhân
        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaBenhNhan))
                {
                    MessageBox.Show("Vui lòng chọn bệnh nhân cần sửa!",
                     "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BenhNhan bn = new BenhNhan
                {
                    MaBenhNhan = selectedMaBenhNhan,
                    HoTen = txtHoTen.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "",
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    BHYT = txtBHYT.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim()
                };

                if (benhNhanBUS.CapNhatBenhNhan(bn))
                {
                    MessageBox.Show("Cập nhật bệnh nhân thành công!",
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

        // Xóa bệnh nhân
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaBenhNhan))
                {
                    MessageBox.Show("Vui lòng chọn bệnh nhân cần xóa!",
                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                       "Bạn có chắc chắn muốn xóa bệnh nhân này?\n\n" +
               "LƯU Ý: Tất cả dữ liệu liên quan (hồ sơ, khám bệnh, v.v.) sẽ bị xóa!",
             "Xác nhận xóa",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (benhNhanBUS.XoaBenhNhan(selectedMaBenhNhan))
                    {
                        MessageBox.Show("Xóa bệnh nhân thành công!",
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

        // Tìm kiếm bệnh nhân
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
                var ketQua = benhNhanBUS.TimKiemBenhNhan(keyword);
                dataGridView1.DataSource = ketQua;

                // Ẩn cột STT và NgayTao
                if (dataGridView1.Columns.Contains("STT"))
                    dataGridView1.Columns["STT"].Visible = false;
                if (dataGridView1.Columns.Contains("NgayTao"))
                    dataGridView1.Columns["NgayTao"].Visible = false;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy bệnh nhân nào!",
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
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
            ClearForm();
        }

        // Chọn bệnh nhân từ DataGridView
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    selectedMaBenhNhan = row.Cells["MaBenhNhan"].Value?.ToString() ?? "";
                    txtMaBN.Text = selectedMaBenhNhan;
                    txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                    txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";

                    if (row.Cells["NgaySinh"].Value != null)
                    {
                        dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                    }

                    string gioiTinh = row.Cells["GioiTinh"].Value?.ToString() ?? "";
                    cboGioiTinh.SelectedItem = gioiTinh;

                    txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString() ?? "";
                    txtBHYT.Text = row.Cells["BHYT"].Value?.ToString() ?? "";
                    txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";

                    // Đổi màu nút Sửa để người dùng biết đang ở chế độ sửa
                    btnSua.BackColor = Color.FromArgb(241, 196, 15);
                    btnThem.BackColor = Color.FromArgb(46, 204, 113);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn bệnh nhân: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa form
        private void ClearForm()
        {
            selectedMaBenhNhan = null;
            txtMaBN.Clear();
            txtHoTen.Clear();
            txtCCCD.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = -1;
            txtSoDienThoai.Clear();
            txtBHYT.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();

            // Reset màu nút
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.BackColor = Color.FromArgb(46, 204, 113);

            // Focus vào textbox đầu tiên
            txtHoTen.Focus();
        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event handler đã có sẵn
        }

        private void FormBenhNhan_Load_1(object sender, EventArgs e)
        {

        }
    }
}
