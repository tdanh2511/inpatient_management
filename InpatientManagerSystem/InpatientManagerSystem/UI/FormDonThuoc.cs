using InpatientManagerSystem.BUS;
using InpatientManagerSystem.DTO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    public partial class FormDonThuoc : Form
    {
        private DonThuocBUS donThuocBUS = new DonThuocBUS();
        private ChiTietDonThuocBUS chiTietDonThuocBUS = new ChiTietDonThuocBUS();
        private ThuocBUS thuocBUS = new ThuocBUS();

        public FormDonThuoc()
        {
            InitializeComponent();
            LoadDanhSachDonThuoc();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            // Setup dgvChiTietDonThuoc columns
            dgvChiTietDonThuoc.Columns.Clear();
            dgvChiTietDonThuoc.Columns.Add("MaThuoc", "Mã thuốc");
            dgvChiTietDonThuoc.Columns.Add("TenThuoc", "Tên thuốc");
            dgvChiTietDonThuoc.Columns.Add("DonVi", "Đơn vị");
            dgvChiTietDonThuoc.Columns.Add("DonGia", "Đơn giá");
            dgvChiTietDonThuoc.Columns.Add("SoLuong", "Số lượng");
            dgvChiTietDonThuoc.Columns.Add("LieuLuong", "Liều lượng");
            dgvChiTietDonThuoc.Columns.Add("GhiChu", "Ghi chú");

            // Setup event cho dgvDonThuoc
            dgvDonThuoc.SelectionChanged += dgvDonThuoc_SelectionChanged;
        }

        private void LoadDanhSachDonThuoc()
        {
            try
            {
                var list = donThuocBUS.LayDanhSachDonThuoc();
                dgvDonThuoc.DataSource = list;

                // Format columns
                if (dgvDonThuoc.Columns["maDonThuoc"] != null)
                    dgvDonThuoc.Columns["maDonThuoc"].HeaderText = "Mã đơn thuốc";
                if (dgvDonThuoc.Columns["maKhamBenh"] != null)
                    dgvDonThuoc.Columns["maKhamBenh"].HeaderText = "Mã khám bệnh";
                if (dgvDonThuoc.Columns["ngayKe"] != null)
                    dgvDonThuoc.Columns["ngayKe"].HeaderText = "Ngày kê";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đơn thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChiTietDonThuoc(string maDonThuoc)
        {
            try
            {
                dgvChiTietDonThuoc.Rows.Clear();
                var listChiTiet = chiTietDonThuocBUS.LayChiTietTheoMaDonThuoc(maDonThuoc);

                foreach (var ct in listChiTiet)
                {
                    // Lấy thông tin thuốc
                    var thuoc = thuocBUS.LayThuocTheoMa(ct.maThuoc);
                    string tenThuoc = thuoc?.tenThuoc ?? "";
                    string donVi = thuoc?.donViTinh ?? "";
                    decimal donGia = thuoc?.donGia ?? 0;

                    dgvChiTietDonThuoc.Rows.Add(
                        ct.maThuoc,
                        tenThuoc,
                        donVi,
                        donGia,
                        ct.soLuong,
                        ct.lieuLuong,
                        ct.ghiChu
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết đơn thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDonThuoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDonThuoc.CurrentRow != null && dgvDonThuoc.CurrentRow.Index >= 0)
            {
                try
                {
                    txtMaDonThuoc.Text = dgvDonThuoc.CurrentRow.Cells["maDonThuoc"].Value?.ToString() ?? "";
                    txtMaKhamBenh.Text = dgvDonThuoc.CurrentRow.Cells["maKhamBenh"].Value?.ToString() ?? "";

                    if (dgvDonThuoc.CurrentRow.Cells["ngayKe"].Value != null)
                    {
                        dtpNgayKe.Value = Convert.ToDateTime(dgvDonThuoc.CurrentRow.Cells["ngayKe"].Value);
                    }

                    // Load chi tiết đơn thuốc
                    if (!string.IsNullOrEmpty(txtMaDonThuoc.Text))
                    {
                        LoadChiTietDonThuoc(txtMaDonThuoc.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            var popup = new FormPopupChiTietDonThuoc();
            popup.ThuocSaved += (ma, ten, donVi, donGia, soLuong, ghiChu) =>
            {
                dgvChiTietDonThuoc.Rows.Add(ma, ten, donVi, donGia, soLuong, "", ghiChu);
            };
            popup.ShowDialog();
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            if (dgvChiTietDonThuoc.CurrentRow == null || dgvChiTietDonThuoc.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn chi tiết cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvChiTietDonThuoc.CurrentRow;
            var popup = new FormPopupChiTietDonThuoc();
            popup.LoadChiTiet(
                row.Cells["MaThuoc"].Value?.ToString() ?? "",
                row.Cells["TenThuoc"].Value?.ToString() ?? "",
                row.Cells["DonVi"].Value?.ToString() ?? "",
                Convert.ToDecimal(row.Cells["DonGia"].Value ?? 0),
                Convert.ToInt32(row.Cells["SoLuong"].Value ?? 0),
                row.Cells["LieuLuong"].Value?.ToString() ?? "",
                row.Cells["GhiChu"].Value?.ToString() ?? ""
            );

            popup.ThuocSaved += (ma, ten, donVi, donGia, soLuong, ghiChu) =>
            {
                row.Cells["MaThuoc"].Value = ma;
                row.Cells["TenThuoc"].Value = ten;
                row.Cells["DonVi"].Value = donVi;
                row.Cells["DonGia"].Value = donGia;
                row.Cells["SoLuong"].Value = soLuong;
                row.Cells["GhiChu"].Value = ghiChu;
            };

            popup.ShowDialog();
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (dgvChiTietDonThuoc.CurrentRow == null || dgvChiTietDonThuoc.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn chi tiết cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa chi tiết này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvChiTietDonThuoc.Rows.Remove(dgvChiTietDonThuoc.CurrentRow);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKhamBenh.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã khám bệnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvChiTietDonThuoc.Rows.Count == 0 ||
                    (dgvChiTietDonThuoc.Rows.Count == 1 && dgvChiTietDonThuoc.Rows[0].IsNewRow))
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một chi tiết đơn thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var donThuoc = new DonThuocDTO
                {
                    maKhamBenh = txtMaKhamBenh.Text,
                    ngayKe = dtpNgayKe.Value
                };

                // Lấy danh sách chi tiết từ DataGridView
                var danhSachChiTiet = new List<ChiTietDonThuocDTO>();
                foreach (DataGridViewRow row in dgvChiTietDonThuoc.Rows)
                {
                    if (!row.IsNewRow && row.Cells["MaThuoc"].Value != null)
                    {
                        danhSachChiTiet.Add(new ChiTietDonThuocDTO
                        {
                            maThuoc = row.Cells["MaThuoc"].Value.ToString(),
                            soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value ?? 0),
                            lieuLuong = row.Cells["LieuLuong"].Value?.ToString() ?? "",
                            ghiChu = row.Cells["GhiChu"].Value?.ToString() ?? ""
                        });
                    }
                }

                if (donThuocBUS.ThemDonThuocVoiChiTiet(donThuoc, danhSachChiTiet))
                {
                    MessageBox.Show("Thêm đơn thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDonThuoc();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm đơn thuốc thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaDonThuoc.Text))
                {
                    MessageBox.Show("Vui lòng chọn đơn thuốc cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMaKhamBenh.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã khám bệnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var donThuoc = new DonThuocDTO
                {
                    maDonThuoc = txtMaDonThuoc.Text,
                    maKhamBenh = txtMaKhamBenh.Text,
                    ngayKe = dtpNgayKe.Value
                };

                if (donThuocBUS.CapNhatDonThuoc(donThuoc))
                {
                    // Xóa chi tiết cũ và thêm chi tiết mới
                    chiTietDonThuocBUS.XoaChiTietTheoMaDonThuoc(donThuoc.maDonThuoc);

                    foreach (DataGridViewRow row in dgvChiTietDonThuoc.Rows)
                    {
                        if (!row.IsNewRow && row.Cells["MaThuoc"].Value != null)
                        {
                            var chiTiet = new ChiTietDonThuocDTO
                            {
                                maDonThuoc = donThuoc.maDonThuoc,
                                maThuoc = row.Cells["MaThuoc"].Value.ToString(),
                                soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value ?? 0),
                                lieuLuong = row.Cells["LieuLuong"].Value?.ToString() ?? "",
                                ghiChu = row.Cells["GhiChu"].Value?.ToString() ?? ""
                            };
                            chiTietDonThuocBUS.ThemChiTiet(chiTiet);
                        }
                    }

                    MessageBox.Show("Cập nhật đơn thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachDonThuoc();
                }
                else
                {
                    MessageBox.Show("Cập nhật đơn thuốc thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaDonThuoc.Text))
                {
                    MessageBox.Show("Vui lòng chọn đơn thuốc cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa đơn thuốc này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (donThuocBUS.XoaDonThuoc(txtMaDonThuoc.Text))
                    {
                        MessageBox.Show("Xóa đơn thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachDonThuoc();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đơn thuốc thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachDonThuoc();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text;
                var list = donThuocBUS.TimKiemDonThuoc(keyword);
                dgvDonThuoc.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtMaDonThuoc.Text = "";
            txtMaKhamBenh.Text = "";
            dtpNgayKe.Value = DateTime.Now;
            txtTimKiem.Text = "";
            dgvChiTietDonThuoc.Rows.Clear();
        }

        private void txtMaDonThuoc_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgvChiTietDonThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
