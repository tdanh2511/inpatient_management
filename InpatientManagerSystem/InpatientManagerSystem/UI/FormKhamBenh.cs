using InpatientManagerSystem.BUS;
using InpatientManagerSystem.DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem.UI
{
    public partial class FormKhamBenh : Form
    {
        private KhamBenhBUS khamBenhBUS = new KhamBenhBUS();
        private string selectedMaKhamBenh = null;

        public FormKhamBenh()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += FormKhamBenh_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
            // Thêm sự kiện khi chọn hồ sơ
            cboMaHoSo.SelectedIndexChanged += CboMaHoSo_SelectedIndexChanged;
        }

        private void FormKhamBenh_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDanhSach();
            LoadComboBoxes();
            ClearForm();

            // Thiết lập các trường ReadOnly
            txtMaKB.ReadOnly = true;
            txtMaKB.BackColor = Color.LightGray;
            
            txtBenhNhan.ReadOnly = true;
            txtBenhNhan.BackColor = Color.LightGray;
            
            txtBacSi.ReadOnly = true;
            txtBacSi.BackColor = Color.LightGray;

            // Thiết lập ComboBox
            cboMaHoSo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Sự kiện khi chọn hồ sơ
        private void CboMaHoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedHoSo = cboMaHoSo.SelectedItem as HoSo;
                if (selectedHoSo != null && !string.IsNullOrEmpty(selectedHoSo.MaHoSo))
                {
                    // Tự động hiển thị tên bệnh nhân và bác sĩ từ hồ sơ
                    txtBenhNhan.Text = selectedHoSo.TenBenhNhan ?? "";
                    txtBacSi.Text = selectedHoSo.TenBacSi ?? "";
                }
                else
                {
                    // Xóa text khi không chọn hồ sơ
                    txtBenhNhan.Clear();
                    txtBacSi.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn hồ sơ: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load ComboBox Hồ sơ
        private void LoadComboBoxes(string maHoSoDangChon = null)
        {
            try
            {
                // Load ComboBox Hồ sơ - Chỉ hiển thị hồ sơ chưa được sử dụng
                var danhSachHoSo = khamBenhBUS.LayDanhSachHoSo(maHoSoDangChon);
                cboMaHoSo.DataSource = null;
                cboMaHoSo.Items.Clear();

                // Tạo item mặc định
                var emptyItem = new HoSo
                {
                    MaHoSo = "",
                    TenBenhNhan = "-- Chọn hồ sơ (Tùy chọn) --",
                    MaBenhNhan = "",
                    MaBacSi = "",
                    TenBacSi = ""
                };
                cboMaHoSo.Items.Add(emptyItem);

                foreach (var hs in danhSachHoSo)
                {
                    cboMaHoSo.Items.Add(hs);
                }

                // Custom hiển thị: Mã hồ sơ - Tên bệnh nhân - Trạng thái
                cboMaHoSo.DisplayMember = "DisplayText";
                cboMaHoSo.ValueMember = "MaHoSo";
                cboMaHoSo.SelectedIndex = 0;

                // Tự động chọn hồ sơ nếu đang sửa
                if (!string.IsNullOrEmpty(maHoSoDangChon))
                {
                    for (int i = 0; i < cboMaHoSo.Items.Count; i++)
                    {
                        var item = cboMaHoSo.Items[i] as HoSo;
                        if (item != null && item.MaHoSo == maHoSoDangChon)
                        {
                            cboMaHoSo.SelectedIndex = i;
                            break;
                        }
                    }
                }
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
                DataPropertyName = "MaKhamBenh",
                HeaderText = "Mã khám bệnh",
                Name = "MaKhamBenh",
                Width = 130
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
                DataPropertyName = "NgayKham",
                HeaderText = "Ngày khám",
                Name = "NgayKham",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ChuanDoan",
                HeaderText = "Chuẩn đoán",
                Name = "ChuanDoan",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaHoSo",
                HeaderText = "Mã hồ sơ",
                Name = "MaHoSo",
                Width = 100
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

        // Tải danh sách khám bệnh
        private void LoadDanhSach()
        {
            try
            {
                var danhSach = khamBenhBUS.LayDanhSachKhamBenh();
                dataGridView1.DataSource = danhSach;

                if (dataGridView1.Columns.Contains("STT"))
                    dataGridView1.Columns["STT"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khám bệnh: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm khám bệnh
        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedMaKhamBenh))
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

                var selectedHoSo = cboMaHoSo.SelectedItem as HoSo;

                KhamBenh kb = new KhamBenh
                {
                    MaHoSo = selectedHoSo?.MaHoSo ?? "",
                    MaBenhNhan = selectedHoSo?.MaBenhNhan ?? "",
                    MaBacSi = selectedHoSo?.MaBacSi ?? "",
                    NgayKham = dtpNgayKham.Value,
                    ChuanDoan = txtChuanDoan.Text.Trim()
                };

                if (khamBenhBUS.ThemKhamBenh(kb))
                {
                    MessageBox.Show("Thêm khám bệnh thành công!",
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

        // Sửa khám bệnh
        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaKhamBenh))
                {
                    MessageBox.Show("Vui lòng chọn khám bệnh cần sửa!",
                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedHoSo = cboMaHoSo.SelectedItem as HoSo;

                KhamBenh kb = new KhamBenh
                {
                    MaKhamBenh = selectedMaKhamBenh,
                    MaHoSo = selectedHoSo?.MaHoSo ?? "",
                    MaBenhNhan = selectedHoSo?.MaBenhNhan ?? "",
                    MaBacSi = selectedHoSo?.MaBacSi ?? "",
                    NgayKham = dtpNgayKham.Value,
                    ChuanDoan = txtChuanDoan.Text.Trim()
                };

                if (khamBenhBUS.CapNhatKhamBenh(kb))
                {
                    MessageBox.Show("Cập nhật khám bệnh thành công!",
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

        // Xóa khám bệnh
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaKhamBenh))
                {
                    MessageBox.Show("Vui lòng chọn khám bệnh cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                     "Bạn có chắc chắn muốn xóa khám bệnh này?",
                      "Xác nhận xóa",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (khamBenhBUS.XoaKhamBenh(selectedMaKhamBenh))
                    {
                        MessageBox.Show("Xóa khám bệnh thành công!",
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
                var ketQua = khamBenhBUS.TimKiemKhamBenh(keyword);
                dataGridView1.DataSource = ketQua;

                if (dataGridView1.Columns.Contains("STT"))
                    dataGridView1.Columns["STT"].Visible = false;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khám bệnh nào!",
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
        }

        // Chọn khám bệnh từ DataGridView
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    selectedMaKhamBenh = row.Cells["MaKhamBenh"].Value?.ToString() ?? "";
                    txtMaKB.Text = selectedMaKhamBenh;
                    txtChuanDoan.Text = row.Cells["ChuanDoan"].Value?.ToString() ?? "";

                    if (row.Cells["NgayKham"].Value != null && row.Cells["NgayKham"].Value != DBNull.Value)
                    {
                        dtpNgayKham.Value = Convert.ToDateTime(row.Cells["NgayKham"].Value);
                    }
                    else
                    {
                        dtpNgayKham.Value = DateTime.Now;
                    }

                    // Lấy mã hồ sơ đang được chọn
                    string maHoSo = row.Cells["MaHoSo"].Value?.ToString() ?? "";
                    
       // Load lại ComboBox hồ sơ (bao gồm hồ sơ đang được chọn)
   LoadComboBoxes(maHoSo);
       

                    // Đổi màu nút
                    btnSua.BackColor = Color.FromArgb(241, 196, 15);
                    btnThem.BackColor = Color.FromArgb(46, 204, 113);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn khám bệnh: " + ex.Message,
          "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa form
        private void ClearForm()
        {
            selectedMaKhamBenh = null;
            txtMaKB.Clear();
            txtChuanDoan.Clear();
            txtBenhNhan.Clear();
            txtBacSi.Clear();
            dtpNgayKham.Value = DateTime.Now;
            txtTimKiem.Clear();

            if (cboMaHoSo.Items.Count > 0)
                cboMaHoSo.SelectedIndex = 0;

            // Reset màu nút
            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.BackColor = Color.FromArgb(46, 204, 113);

            cboMaHoSo.Focus();
        }
    }
}
