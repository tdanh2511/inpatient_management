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
    public partial class FormDichVu : Form
    {
        private DichVuBUS dichVuBUS = new DichVuBUS();
        private string selectedMaDichVu = null;

        public FormDichVu()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += FormDichVu_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
        }

        private void FormDichVu_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            ConfigureDataGridView();
            ClearForm();
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
                DataPropertyName = "MaDichVu",
                HeaderText = "Mã dịch vụ",
                Name = "MaDichVu",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenDichVu",
                HeaderText = "Tên dịch vụ",
                Name = "TenDichVu",
                Width = 250
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoaiDichVu",
                HeaderText = "Loại dịch vụ",
                Name = "LoaiDichVu",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonGia",
                HeaderText = "Đơn giá",
                Name = "DonGia",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DonViTinh",
                HeaderText = "Đơn vị tính",
                Name = "DonViTinh",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MoTa",
                HeaderText = "Mô tả",
                Name = "MoTa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Name = "TrangThai",
                Width = 120
            });
        }

        // Tải danh sách dịch vụ
        private void LoadDanhSach()
        {
            try
            {
                var danhSach = dichVuBUS.LayDanhSachDichVu();

                // Chuyển đổi TrangThai từ bool sang text
                var displayList = danhSach.Select(dv => new
                {
                    dv.MaDichVu,
                    dv.TenDichVu,
                    dv.LoaiDichVu,
                    dv.DonGia,
                    dv.DonViTinh,
                    dv.MoTa,
                    TrangThai = dv.TrangThai ? "Hoạt động" : "Không hoạt động"
                }).ToList();

                dataGridView1.DataSource = displayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách dịch vụ: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm dịch vụ
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra trường hợp đang sửa
                if (!string.IsNullOrEmpty(selectedMaDichVu))
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

                // Lấy mã dịch vụ tiếp theo
                string maDV = dichVuBUS.LayMaDichVuTiepTheo();
                txtMaDV.Text = maDV;

                decimal donGia;
                if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!",
                        "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DichVu dv = new DichVu
                {
                    MaDichVu = maDV,
                    TenDichVu = txtTenDichVu.Text.Trim(),
                    LoaiDichVu = txtLoaiDichVu.Text.Trim(),
                    DonGia = donGia,
                    DonViTinh = txtDonViTinh.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    TrangThai = cboTrangThai.SelectedItem?.ToString() == "Hoạt động"
                };

                if (dichVuBUS.ThemDichVu(dv))
                {
                    MessageBox.Show("Thêm dịch vụ thành công!",
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

        // Sửa dịch vụ
        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaDichVu))
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần sửa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal donGia;
                if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!",
                        "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DichVu dv = new DichVu
                {
                    MaDichVu = selectedMaDichVu,
                    TenDichVu = txtTenDichVu.Text.Trim(),
                    LoaiDichVu = txtLoaiDichVu.Text.Trim(),
                    DonGia = donGia,
                    DonViTinh = txtDonViTinh.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim(),
                    TrangThai = cboTrangThai.SelectedItem?.ToString() == "Hoạt động"
                };

                if (dichVuBUS.CapNhatDichVu(dv))
                {
                    MessageBox.Show("Cập nhật dịch vụ thành công!",
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

        // Xóa dịch vụ
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaDichVu))
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa dịch vụ này?\n\n" +
                    "LƯU Ý: Dịch vụ đang được sử dụng trong hóa đơn sẽ không thể xóa!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (dichVuBUS.XoaDichVu(selectedMaDichVu))
                    {
                        MessageBox.Show("Xóa dịch vụ thành công!",
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

        // Tìm kiếm dịch vụ
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
                var ketQua = dichVuBUS.TimKiemDichVu(keyword);

                // Chuyển đổi TrangThai từ bool sang text
                var displayList = ketQua.Select(dv => new
                {
                    dv.MaDichVu,
                    dv.TenDichVu,
                    dv.LoaiDichVu,
                    dv.DonGia,
                    dv.DonViTinh,
                    dv.MoTa,
                    TrangThai = dv.TrangThai ? "Hoạt động" : "Không hoạt động"
                }).ToList();

                dataGridView1.DataSource = displayList;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dịch vụ nào!",
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

        // Chọn dịch vụ từ DataGridView
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    selectedMaDichVu = row.Cells["MaDichVu"].Value?.ToString() ?? "";
                    txtMaDV.Text = selectedMaDichVu;
                    txtTenDichVu.Text = row.Cells["TenDichVu"].Value?.ToString() ?? "";
                    txtLoaiDichVu.Text = row.Cells["LoaiDichVu"].Value?.ToString() ?? "";
                    txtDonGia.Text = row.Cells["DonGia"].Value?.ToString() ?? "0";
                    txtDonViTinh.Text = row.Cells["DonViTinh"].Value?.ToString() ?? "";
                    txtMoTa.Text = row.Cells["MoTa"].Value?.ToString() ?? "";

                    string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
                    cboTrangThai.SelectedItem = trangThai;

                    // Đổi màu nút Sửa để người dùng biết đang ở chế độ sửa
                    btnSua.BackColor = Color.FromArgb(241, 196, 15);
                    btnThem.BackColor = Color.FromArgb(46, 204, 113);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn dịch vụ: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa form
        private void ClearForm()
        {
            selectedMaDichVu = null;
            txtMaDV.Clear();
            txtTenDichVu.Clear();
            txtLoaiDichVu.Clear();
            txtDonGia.Clear();
            txtDonViTinh.Clear();
            txtMoTa.Clear();
            cboTrangThai.SelectedIndex = 0; // Mặc định là "Hoạt động"
            txtTimKiem.Clear();


            // Reset màu nút
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.BackColor = Color.FromArgb(46, 204, 113);

            // Focus vào textbox đầu tiên
            txtTenDichVu.Focus();
        }

        private void txtTenDichVu_TextChanged(object sender, EventArgs e)
        {
            // Event handler đã có sẵn
        }

        private void FormDichVu_Load_1(object sender, EventArgs e)
        {

        }
    }
}
