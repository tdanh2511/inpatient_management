using InpatientManagerSystem.BUS;
using InpatientManagerSystem.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormThuoc : Form
    {
        private ThuocBUS thuocBUS = new ThuocBUS();
        private string selectedMaThuoc = null;

        public FormThuoc()
        {
            InitializeComponent();

            this.Load += FormThuoc_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            labelTimKiem.Click += LabelTimKiem_Click;
            txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void FormThuoc_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadDanhSach();
            ClearForm();

            txtMaThuoc.ReadOnly = true;
            txtMaThuoc.BackColor = Color.LightGray;
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaThuoc",
                HeaderText = "Mã thuốc",
                Name = "MaThuoc",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenThuoc",
                HeaderText = "Tên thuốc",
                Name = "TenThuoc",
                Width = 200
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
                DataPropertyName = "DonGia",
                HeaderText = "Đơn giá",
                Name = "DonGia",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongTon",
                HeaderText = "Số lượng tồn",
                Name = "SoLuongTon",
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HangSanXuat",
                HeaderText = "Hãng sản xuất",
                Name = "HangSanXuat",
                Width = 150
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CongDung",
                HeaderText = "Công dụng",
                Name = "CongDung",
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayHetHan",
                HeaderText = "Ngày hết hạn",
                Name = "NgayHetHan",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Name = "TrangThai",
                Width = 120
            });
        }

        private void LoadDanhSach()
        {
            try
            {
                var danhSach = thuocBUS.LayDanhSachThuoc();

                var displayList = danhSach.Select(t => new
                {
                    MaThuoc = t.maThuoc,
                    TenThuoc = t.tenThuoc,
                    DonViTinh = t.donViTinh,
                    DonGia = t.donGia,
                    SoLuongTon = t.soLuongTon,
                    HangSanXuat = t.hangSanXuat ?? "",
                    CongDung = t.congDung ?? "",
                    NgayHetHan = t.ngayHetHan != DateTime.MinValue ? (DateTime?)t.ngayHetHan : null,
                    TrangThai = t.trangThai ? "Còn sử dụng" : "Ngừng sử dụng"
                }).ToList();

                dataGridView1.DataSource = displayList;
                HighlightExpiredMedicines();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách thuốc: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightExpiredMedicines()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["NgayHetHan"].Value != null &&
                    row.Cells["NgayHetHan"].Value != DBNull.Value)
                {
                    DateTime ngayHetHan = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);

                    if (ngayHetHan < DateTime.Now.Date)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (ngayHetHan <= DateTime.Now.Date.AddDays(30))
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                }

                if (row.Cells["SoLuongTon"].Value != null)
                {
                    int soLuongTon = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                    if (soLuongTon <= 10 && soLuongTon > 0)
                    {
                        row.Cells["SoLuongTon"].Style.ForeColor = Color.Red;
                        row.Cells["SoLuongTon"].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    }
                    else if (soLuongTon == 0)
                    {
                        row.Cells["SoLuongTon"].Style.BackColor = Color.Red;
                        row.Cells["SoLuongTon"].Style.ForeColor = Color.White;
                        row.Cells["SoLuongTon"].Style.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                    }
                }
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(selectedMaThuoc))
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

                if (string.IsNullOrWhiteSpace(txtTenThuoc.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên thuốc!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenThuoc.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDonViTinh.Text))
                {
                    MessageBox.Show("Vui lòng nhập đơn vị tính!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDonViTinh.Focus();
                    return;
                }

                if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!",
                        "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDonGia.Focus();
                    return;
                }

                if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong))
                {
                    MessageBox.Show("Số lượng không hợp lệ!",
                        "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Focus();
                    return;
                }

                ThuocDTO thuoc = new ThuocDTO
                {
                    tenThuoc = txtTenThuoc.Text.Trim(),
                    donViTinh = txtDonViTinh.Text.Trim(),
                    donGia = donGia,
                    soLuongTon = soLuong,
                    hangSanXuat = txtHang.Text.Trim(),
                    congDung = txtCongDung.Text.Trim(),
                    ngayHetHan = dtpNgayHetHan.Value.Date,
                    trangThai = chkTrangThai.Checked
                };

                if (thuocBUS.ThemThuoc(thuoc))
                {
                    MessageBox.Show("Thêm thuốc thành công!",
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

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaThuoc))
                {
                    MessageBox.Show("Vui lòng chọn thuốc cần sửa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTenThuoc.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên thuốc!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenThuoc.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDonViTinh.Text))
                {
                    MessageBox.Show("Vui lòng nhập đơn vị tính!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDonViTinh.Focus();
                    return;
                }

                if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!",
                        "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDonGia.Focus();
                    return;
                }

                if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong))
                {
                    MessageBox.Show("Số lượng không hợp lệ!",
                        "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Focus();
                    return;
                }

                ThuocDTO thuoc = new ThuocDTO
                {
                    maThuoc = selectedMaThuoc,
                    tenThuoc = txtTenThuoc.Text.Trim(),
                    donViTinh = txtDonViTinh.Text.Trim(),
                    donGia = donGia,
                    soLuongTon = soLuong,
                    hangSanXuat = txtHang.Text.Trim(),
                    congDung = txtCongDung.Text.Trim(),
                    ngayHetHan = dtpNgayHetHan.Value.Date,
                    trangThai = chkTrangThai.Checked
                };

                if (thuocBUS.CapNhatThuoc(thuoc))
                {
                    MessageBox.Show("Cập nhật thuốc thành công!",
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

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedMaThuoc))
                {
                    MessageBox.Show("Vui lòng chọn thuốc cần xóa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa thuốc '{txtTenThuoc.Text}' không?\n\n" +
                    "LƯU Ý: Thuốc đang được sử dụng trong đơn thuốc sẽ không thể xóa!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (thuocBUS.XoaThuoc(selectedMaThuoc))
                    {
                        MessageBox.Show("Xóa thuốc thành công!",
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

        private void LabelTimKiem_Click(object sender, EventArgs e)
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
                var ketQua = thuocBUS.TimKiemThuoc(keyword);

                var displayList = ketQua.Select(t => new
                {
                    MaThuoc = t.maThuoc,
                    TenThuoc = t.tenThuoc,
                    DonViTinh = t.donViTinh,
                    DonGia = t.donGia,
                    SoLuongTon = t.soLuongTon,
                    HangSanXuat = t.hangSanXuat ?? "",
                    CongDung = t.congDung ?? "",
                    NgayHetHan = t.ngayHetHan != DateTime.MinValue ? (DateTime?)t.ngayHetHan : null,
                    TrangThai = t.trangThai ? "Còn sử dụng" : "Ngừng sử dụng"
                }).ToList();

                dataGridView1.DataSource = displayList;
                HighlightExpiredMedicines();

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thuốc nào!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
            ClearForm();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    selectedMaThuoc = row.Cells["MaThuoc"].Value?.ToString() ?? "";
                    txtMaThuoc.Text = selectedMaThuoc;
                    txtTenThuoc.Text = row.Cells["TenThuoc"].Value?.ToString() ?? "";
                    txtDonViTinh.Text = row.Cells["DonViTinh"].Value?.ToString() ?? "";
                    txtDonGia.Text = row.Cells["DonGia"].Value?.ToString() ?? "0";
                    txtSoLuong.Text = row.Cells["SoLuongTon"].Value?.ToString() ?? "0";
                    txtHang.Text = row.Cells["HangSanXuat"].Value?.ToString() ?? "";
                    txtCongDung.Text = row.Cells["CongDung"].Value?.ToString() ?? "";

                    if (row.Cells["NgayHetHan"].Value != null &&
                        row.Cells["NgayHetHan"].Value != DBNull.Value)
                    {
                        dtpNgayHetHan.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                    }
                    else
                    {
                        dtpNgayHetHan.Value = DateTime.Now.AddYears(1);
                    }

                    string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
                    chkTrangThai.Checked = trangThai == "Còn sử dụng";

                    btnSua.BackColor = Color.FromArgb(241, 196, 15);
                    btnThem.BackColor = Color.FromArgb(46, 204, 113);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi chọn thuốc: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearForm()
        {
            selectedMaThuoc = null;
            txtMaThuoc.Clear();
            txtTenThuoc.Clear();
            txtDonViTinh.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtHang.Clear();
            txtCongDung.Clear();
            txtTimKiem.Clear();
            dtpNgayHetHan.Value = DateTime.Now.AddYears(1);
            chkTrangThai.Checked = true;

            btnSua.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.BackColor = Color.FromArgb(46, 204, 113);

            dataGridView1.ClearSelection();
            txtTenThuoc.Focus();
        }

        private void chkTrangThai_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtMaThuoc_TextChanged(object sender, EventArgs e)
        {

        }

<<<<<<< HEAD
        private void labelTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
=======
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
>>>>>>> 5287656672f5601a13aa16b125e0bee07ab4997c
        {

        }
    }
}
