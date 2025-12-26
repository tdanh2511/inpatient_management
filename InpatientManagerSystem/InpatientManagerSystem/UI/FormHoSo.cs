using InpatientManagerSystem.BUS;
using InpatientManagerSystem.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem.UI
{
    public partial class FormHoSo : Form
    {
        private HoSoBUS hoSoBUS = new HoSoBUS();
        private string selectedMaHoSo = null;

        public FormHoSo()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += FormHoSo_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
        }

        private void FormHoSo_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDanhSach();
            LoadComboBoxes();
            ClearForm();

            // Thiết lập các trường ReadOnly
            txtMaHoSo.ReadOnly = true;
            txtMaHoSo.BackColor = Color.LightGray;

            // Thiết lập ComboBox
            cboMaBenhNhan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Load ComboBox Bác sĩ, Bệnh nhân và Trạng thái
        private void LoadComboBoxes(string maBenhNhanDangChon = null)
        {
            try
            {
                // Load ComboBox Bệnh nhân - CHỈ hiển thị bệnh nhân chưa có hồ sơ
                var danhSachBenhNhan = hoSoBUS.LayDanhSachBenhNhan(maBenhNhanDangChon);
                cboMaBenhNhan.DataSource = null;
                cboMaBenhNhan.Items.Clear();
                cboMaBenhNhan.Items.Add(new BenhNhan { MaBenhNhan = "", HoTen = "-- Chọn bệnh nhân --" });
                foreach (var bn in danhSachBenhNhan)
                {
                    cboMaBenhNhan.Items.Add(bn);
                }
                cboMaBenhNhan.DisplayMember = "HoTen";
                cboMaBenhNhan.ValueMember = "MaBenhNhan";
                cboMaBenhNhan.SelectedIndex = 0;

                // Tự động chọn bệnh nhân nếu đang sửa
                if (!string.IsNullOrEmpty(maBenhNhanDangChon))
                {
                    for (int i = 0; i < cboMaBenhNhan.Items.Count; i++)
                    {
                        var item = cboMaBenhNhan.Items[i] as BenhNhan;
                        if (item != null && item.MaBenhNhan == maBenhNhanDangChon)
                        {
                            cboMaBenhNhan.SelectedIndex = i;
                            break;
                        }
                    }
                }

                // Load ComboBox Bác sĩ
                var danhSachBacSi = hoSoBUS.LayDanhSachBacSi();
                cboMaBacSi.DataSource = null;
                cboMaBacSi.Items.Clear();
                cboMaBacSi.Items.Add(new BacSi { MaBacSi = "", HoTen = "-- Chọn bác sĩ (Tùy chọn) --" });
                foreach (var bs in danhSachBacSi)
                {
                    cboMaBacSi.Items.Add(bs);
                }
                cboMaBacSi.DisplayMember = "HoTen";
                cboMaBacSi.ValueMember = "MaBacSi";
                cboMaBacSi.SelectedIndex = 0;

                // Set trạng thái mặc định
                if (cboTrangThai.Items.Count > 0)
                    cboTrangThai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách: " + ex.Message,
                 "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cấu hình DataGridView
        private void ConfigureDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaHoSo",
                HeaderText = "Mã hồ sơ",
                Name = "MaHoSo",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenBenhNhan",
                HeaderText = "Bệnh nhân",
                Name = "TenBenhNhan",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenBacSi",
                HeaderText = "Bác sĩ",
                Name = "TenBacSi",
                Width = 180
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayNhapVien",
                HeaderText = "Ngày nhập viện",
                Name = "NgayNhapVien",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LyDo",
                HeaderText = "Lý do",
                Name = "LyDo",
                Width = 180
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Name = "TrangThai",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Ẩn các cột phụ
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaBenhNhan",
                Name = "MaBenhNhan",
                Visible = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaBacSi",
                Name = "MaBacSi",
                Visible = false
            });
        }

        // Tải danh sách hồ sơ
        private void LoadDanhSach()
        {
            try
            {
                var danhSach = hoSoBUS.LayDanhSachHoSo();
                dataGridView1.DataSource = danhSach;

                if (dataGridView1.Columns.Contains("STT"))
                    dataGridView1.Columns["STT"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hồ sơ: " + ex.Message,
                  "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm hồ sơ
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedMaHoSo))
                {
                    var result = MessageBox.Show(
                        "Bạn đang ở chế độ sửa. Bạn có muốn chuyển sang thêm mới không?",
                    "Xác nhận",
                           MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ClearForm();
                        LoadComboBoxes(); // Load lại ComboBox
                    }
                    else
                    {
                        return;
                    }
                }

                var selectedBenhNhan = cboMaBenhNhan.SelectedItem as BenhNhan;
                var selectedBacSi = cboMaBacSi.SelectedItem as BacSi;

                HoSo hs = new HoSo
                {
                    MaBacSi = selectedBacSi?.MaBacSi ?? "",
                    MaBenhNhan = selectedBenhNhan?.MaBenhNhan ?? "",
                    NgayNhapVien = dtpNgayNhapVien.Value,
                    LyDo = txtLyDo.Text.Trim(),
                    TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang điều trị"
                };

                if (hoSoBUS.ThemHoSo(hs))
                {
                    MessageBox.Show("Thêm hồ sơ thành công!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach();
                    ClearForm();
                    LoadComboBoxes(); // Load lại ComboBox
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

        // Sửa hồ sơ
        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaHoSo))
                {
                    MessageBox.Show("Vui lòng chọn hồ sơ cần sửa!",
           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedBenhNhan = cboMaBenhNhan.SelectedItem as BenhNhan;
                var selectedBacSi = cboMaBacSi.SelectedItem as BacSi;

                HoSo hs = new HoSo
                {
                    MaHoSo = selectedMaHoSo,
                    MaBacSi = selectedBacSi?.MaBacSi ?? "",
                    MaBenhNhan = selectedBenhNhan?.MaBenhNhan ?? "",
                    NgayNhapVien = dtpNgayNhapVien.Value,
                    LyDo = txtLyDo.Text.Trim(),
                    TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Đang điều trị"
                };

                if (hoSoBUS.CapNhatHoSo(hs))
                {
                    MessageBox.Show("Cập nhật hồ sơ thành công!",
               "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSach();
                    ClearForm();
                    LoadComboBoxes(); // Load lại ComboBox
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

        // Xóa hồ sơ
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaHoSo))
                {
                    MessageBox.Show("Vui lòng chọn hồ sơ cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa hồ sơ này?\n\nLƯU Ý: Tất cả dữ liệu liên quan sẽ bị xóa!",
                  "Xác nhận xóa",
                  MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (hoSoBUS.XoaHoSo(selectedMaHoSo))
                    {
                        MessageBox.Show("Xóa hồ sơ thành công!",
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

        // Tìm kiếm
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
                var ketQua = hoSoBUS.TimKiemHoSo(keyword);
                dataGridView1.DataSource = ketQua;

                if (dataGridView1.Columns.Contains("STT"))
                    dataGridView1.Columns["STT"].Visible = false;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy hồ sơ nào!",
                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message,
               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Làm mới
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
            ClearForm();
            LoadComboBoxes(); // Load lại ComboBox (chỉ hiển thị bệnh nhân chưa có hồ sơ)
        }

        // Chọn hồ sơ từ DataGridView
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    selectedMaHoSo = row.Cells["MaHoSo"].Value?.ToString() ?? "";
                    txtMaHoSo.Text = selectedMaHoSo;
                    txtLyDo.Text = row.Cells["LyDo"].Value?.ToString() ?? "";

                    if (row.Cells["NgayNhapVien"].Value != null && row.Cells["NgayNhapVien"].Value != DBNull.Value)
                    {
                        dtpNgayNhapVien.Value = Convert.ToDateTime(row.Cells["NgayNhapVien"].Value);
                    }
                    else
                    {
                        dtpNgayNhapVien.Value = DateTime.Now;
                    }

                    // Lấy mã bệnh nhân đang được chọn
                    string maBenhNhan = row.Cells["MaBenhNhan"].Value?.ToString() ?? "";
       
                    // Load lại ComboBox bệnh nhân (bao gồm bệnh nhân đang được chọn)
                    LoadComboBoxes(maBenhNhan);

                    // Chọn bác sĩ
                    string maBacSi = row.Cells["MaBacSi"].Value?.ToString() ?? "";
                    for (int i = 0; i < cboMaBacSi.Items.Count; i++)
                    {
                        var item = cboMaBacSi.Items[i] as BacSi;
                        if (item != null && item.MaBacSi == maBacSi)
                        {
                            cboMaBacSi.SelectedIndex = i;
                            break;
                        }
                    }

                    // Chọn trạng thái
                    string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
                    for (int i = 0; i < cboTrangThai.Items.Count; i++)
                    {
                        if (cboTrangThai.Items[i].ToString() == trangThai)
                        {
                            cboTrangThai.SelectedIndex = i;
                            break;
                        }
                    }

                    // Đổi màu nút
                    btnSua.BackColor = Color.FromArgb(241, 196, 15);
                    btnThem.BackColor = Color.FromArgb(46, 204, 113);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn hồ sơ: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa form
        private void ClearForm()
        {
            selectedMaHoSo = null;
            txtMaHoSo.Clear();
            txtLyDo.Clear();
            dtpNgayNhapVien.Value = DateTime.Now;
            txtTimKiem.Clear();

            if (cboMaBenhNhan.Items.Count > 0)
                cboMaBenhNhan.SelectedIndex = 0;

            if (cboMaBacSi.Items.Count > 0)
                cboMaBacSi.SelectedIndex = 0;

            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            // Reset màu nút
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.BackColor = Color.FromArgb(46, 204, 113);

            cboMaBenhNhan.Focus();
        }

        private void FormHoSo_Load_1(object sender, EventArgs e)
        {

        }
    }
}
