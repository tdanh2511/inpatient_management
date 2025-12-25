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
    public partial class FormPhong : Form
    {
        private PhongBUS phongBUS = new PhongBUS();
        private string selectedMaPhong = null;

        public FormPhong()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += FormPhong_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
        }

        private void FormPhong_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            ConfigureDataGridView();
            ClearForm();

            // Thiết lập các trường ReadOnly
            txtMaPhong.ReadOnly = true;  // Mã phòng tự động, không cho sửa
            txtMaPhong.BackColor = Color.LightGray;  // Đổi màu nền để dễ nhận biết

            // Thiết lập ComboBox chỉ cho phép CHỌN, không cho nhập tự do
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
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
                DataPropertyName = "MaPhong",
                HeaderText = "Mã phòng",
                Name = "MaPhong",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenPhong",
                HeaderText = "Tên phòng",
                Name = "TenPhong",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LoaiPhong",
                HeaderText = "Loại phòng",
                Name = "LoaiPhong",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        // Tải danh sách phòng
        private void LoadDanhSach()
        {
            try
            {
                var danhSach = phongBUS.LayDanhSachPhong();
                dataGridView1.DataSource = danhSach;

                // Ẩn cột STT
                if (dataGridView1.Columns.Contains("STT"))
                    dataGridView1.Columns["STT"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message,
            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm phòng
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra trường hợp đang sửa
                if (!string.IsNullOrEmpty(selectedMaPhong))
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

                Phong p = new Phong
                {
                    TenPhong = txtTenPhong.Text.Trim(),
                    LoaiPhong = cboLoaiPhong.SelectedItem?.ToString() ?? ""
                };

                if (phongBUS.ThemPhong(p))
                {
                    MessageBox.Show("Thêm phòng thành công!",
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

        // Sửa phòng
        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaPhong))
                {
                    MessageBox.Show("Vui lòng chọn phòng cần sửa!",
                         "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Phong p = new Phong
                {
                    MaPhong = selectedMaPhong,
                    TenPhong = txtTenPhong.Text.Trim(),
                    LoaiPhong = cboLoaiPhong.SelectedItem?.ToString() ?? ""
                };

                if (phongBUS.CapNhatPhong(p))
                {
                    MessageBox.Show("Cập nhật phòng thành công!",
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

        // Xóa phòng
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaPhong))
                {
                    MessageBox.Show("Vui lòng chọn phòng cần xóa!",
        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
              "Bạn có chắc chắn muốn xóa phòng này?\n\n" +
                   "LƯU Ý: Tất cả giường trong phòng sẽ bị xóa theo!",
              "Xác nhận xóa",
              MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (phongBUS.XoaPhong(selectedMaPhong))
                    {
                        MessageBox.Show("Xóa phòng thành công!",
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

        // Tìm kiếm phòng
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
                var ketQua = phongBUS.TimKiemPhong(keyword);
                dataGridView1.DataSource = ketQua;

                // Ẩn cột STT
                if (dataGridView1.Columns.Contains("STT"))
                    dataGridView1.Columns["STT"].Visible = false;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phòng nào!",
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

        // Chọn phòng từ DataGridView
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    selectedMaPhong = row.Cells["MaPhong"].Value?.ToString() ?? "";
                    txtMaPhong.Text = selectedMaPhong;
                    txtTenPhong.Text = row.Cells["TenPhong"].Value?.ToString() ?? "";

                    string loaiPhong = row.Cells["LoaiPhong"].Value?.ToString() ?? "";
                    cboLoaiPhong.SelectedItem = loaiPhong;

                    // Đổi màu nút Sửa để người dùng biết đang ở chế độ sửa
                    btnSua.BackColor = Color.FromArgb(241, 196, 15);
                    btnThem.BackColor = Color.FromArgb(46, 204, 113);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn phòng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa form
        private void ClearForm()
        {
            selectedMaPhong = null;
            txtMaPhong.Clear();
            txtTenPhong.Clear();
            cboLoaiPhong.SelectedIndex = 0; // Mặc định là "Thường"
            txtTimKiem.Clear();

            // Reset màu nút
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.BackColor = Color.FromArgb(46, 204, 113);

            // Focus vào textbox đầu tiên
            txtTenPhong.Focus();
        }

        private void txtTenPhong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
