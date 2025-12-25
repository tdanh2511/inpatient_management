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
public partial class FormBacSi : Form
    {
        private BacSiBUS bacSiBUS = new BacSiBUS();
        private string selectedMaBacSi = null;

   public FormBacSi()
        {
 InitializeComponent();

            // Đăng ký các sự kiện
    this.Load += FormBacSi_Load;
    btnThem.Click += BtnThem_Click;
 btnSua.Click += BtnSua_Click;
     btnXoa.Click += BtnXoa_Click;
 btnTimKiem.Click += BtnTimKiem_Click;
  btnLamMoi.Click += BtnLamMoi_Click;
        dataGridView1.CellClick += DataGridView1_CellClick;
   txtTimKiem.KeyPress += TxtTimKiem_KeyPress;
            cboMaNguoiDung.SelectedIndexChanged += CboMaNguoiDung_SelectedIndexChanged;
     }

  private void FormBacSi_Load(object sender, EventArgs e)
   {
      ConfigureDataGridView();
   LoadDanhSach();
      LoadNguoiDungComboBox();
     ClearForm();

// Thiết lập các trường ReadOnly
   txtMaBS.ReadOnly = true;
            txtMaBS.BackColor = Color.LightGray;

      // Thiết lập ComboBox
     cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
  cboMaNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Sự kiện khi chọn người dùng từ ComboBox - tự động điền họ tên
    private void CboMaNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
      {
 try
       {
  var selectedNguoiDung = cboMaNguoiDung.SelectedItem as NguoiDung;

    if (selectedNguoiDung != null && selectedNguoiDung.MaNguoiDung > 0)
          {
    // Chỉ tự động điền khi đang ở chế độ thêm mới
       if (string.IsNullOrEmpty(selectedMaBacSi))
   {
       txtHoTen.Text = selectedNguoiDung.HoTen ?? "";
    }
        }
     else
            {
   if (string.IsNullOrEmpty(selectedMaBacSi))
      {
        txtHoTen.Clear();
      }
  }
         }
   catch (Exception)
  {
  // Bỏ qua lỗi khi đang load form
     }
        }

        // Load danh sách người dùng có vai trò BacSi vào ComboBox
  private void LoadNguoiDungComboBox(int? selectedMaNguoiDung = null)
        {
  try
 {
    List<NguoiDung> danhSachNguoiDung;

    if (selectedMaNguoiDung.HasValue)
  {
      danhSachNguoiDung = bacSiBUS.LayTatCaNguoiDungBacSi();
     }
 else
            {
 danhSachNguoiDung = bacSiBUS.LayDanhSachNguoiDungChuaGan();
    }

   cboMaNguoiDung.DataSource = null;
         cboMaNguoiDung.Items.Clear();

     // Thêm item mặc định
     cboMaNguoiDung.Items.Add(new NguoiDung 
        { 
   MaNguoiDung = 0, 
          TenDangNhap = "-- Chọn người dùng --", 
 HoTen = "" 
  });

  foreach (var nd in danhSachNguoiDung)
      {
  cboMaNguoiDung.Items.Add(nd);
      }

  cboMaNguoiDung.DisplayMember = "TenDangNhap";
 cboMaNguoiDung.ValueMember = "MaNguoiDung";
     cboMaNguoiDung.SelectedIndex = 0;

        // Chọn người dùng nếu có
    if (selectedMaNguoiDung.HasValue && selectedMaNguoiDung.Value > 0)
  {
  for (int i = 0; i < cboMaNguoiDung.Items.Count; i++)
   {
   var item = cboMaNguoiDung.Items[i] as NguoiDung;
  if (item != null && item.MaNguoiDung == selectedMaNguoiDung.Value)
       {
         cboMaNguoiDung.SelectedIndex = i;
   break;
      }
        }
          }
    }
          catch (Exception ex)
   {
           MessageBox.Show("Lỗi load danh sách người dùng: " + ex.Message,
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
    DataPropertyName = "MaBacSi",
      HeaderText = "Mã BS",
    Name = "MaBacSi",
     Width = 80
       });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
     {
      DataPropertyName = "TenNguoiDung",
    HeaderText = "Tài khoản",
         Name = "TenNguoiDung",
    Width = 100
     });

   dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
        {
     DataPropertyName = "HoTen",
   HeaderText = "Họ và tên",
     Name = "HoTen",
     Width = 180
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
     DataPropertyName = "CCCD",
    HeaderText = "CCCD",
              Name = "CCCD",
         Width = 120
    });

      dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
  {
 DataPropertyName = "DiaChi",
     HeaderText = "Địa chỉ",
               Name = "DiaChi",
       Width = 200
            });

          dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
    DataPropertyName = "KinhNghiem",
  HeaderText = "Kinh nghiệm (năm)",
   Name = "KinhNghiem",
      Width = 120
    });

       dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
      {
   DataPropertyName = "ChuyenKhoa",
      HeaderText = "Chuyên khoa",
     Name = "ChuyenKhoa",
   AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
 });

          dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
      {
  DataPropertyName = "MaNguoiDung",
      HeaderText = "MaNguoiDung",
     Name = "MaNguoiDung",
   Visible = false
         });
        }

        // Tải danh sách bác sĩ
    private void LoadDanhSach()
        {
            try
   {
          var danhSach = bacSiBUS.LayDanhSachBacSi();
   dataGridView1.DataSource = danhSach;

 if (dataGridView1.Columns.Contains("STT"))
     dataGridView1.Columns["STT"].Visible = false;
}
        catch (Exception ex)
 {
   MessageBox.Show("Lỗi tải danh sách bác sĩ: " + ex.Message,
      "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      // Thêm bác sĩ
  private void BtnThem_Click(object sender, EventArgs e)
        {
      try
  {
     if (!string.IsNullOrEmpty(selectedMaBacSi))
  {
        var result = MessageBox.Show(
         "Bạn đang ở chế độ sửa. Bạn có muốn chuyển sang thêm mới không?",
   "Xác nhận",
     MessageBoxButtons.YesNo,
   MessageBoxIcon.Question);

     if (result == DialogResult.Yes)
     {
  ClearForm();
  LoadNguoiDungComboBox();
    }
        else
       {
            return;
 }
      }

   var selectedNguoiDung = cboMaNguoiDung.SelectedItem as NguoiDung;
           int maNguoiDung = selectedNguoiDung?.MaNguoiDung ?? 0;

   int? kinhNghiem = null;
     if (!string.IsNullOrWhiteSpace(txtKinhNghiem.Text))
      {
   if (int.TryParse(txtKinhNghiem.Text.Trim(), out int kn))
   {
    kinhNghiem = kn;
     }
       else
   {
          MessageBox.Show("Kinh nghiệm phải là số nguyên!",
     "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      txtKinhNghiem.Focus();
       return;
        }
      }

   BacSi bs = new BacSi
        {
    MaNguoiDung = maNguoiDung,
     HoTen = txtHoTen.Text.Trim(),
     NgaySinh = dtpNgaySinh.Value,
    GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "",
       CCCD = txtCCCD.Text.Trim(),
  DiaChi = txtDiaChi.Text.Trim(),
            KinhNghiem = kinhNghiem,
       ChuyenKhoa = txtChuyenKhoa.Text.Trim()
       };

    if (bacSiBUS.ThemBacSi(bs))
    {
   MessageBox.Show("Thêm bác sĩ thành công!",
           "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
   LoadDanhSach();
      ClearForm();
      LoadNguoiDungComboBox();
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

        // Sửa bác sĩ
        private void BtnSua_Click(object sender, EventArgs e)
        {
  try
    {
                if (string.IsNullOrEmpty(selectedMaBacSi))
    {
      MessageBox.Show("Vui lòng chọn bác sĩ cần sửa!",
"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      return;
      }

            var selectedNguoiDung = cboMaNguoiDung.SelectedItem as NguoiDung;
   int maNguoiDung = selectedNguoiDung?.MaNguoiDung ?? 0;

      int? kinhNghiem = null;
       if (!string.IsNullOrWhiteSpace(txtKinhNghiem.Text))
   {
      if (int.TryParse(txtKinhNghiem.Text.Trim(), out int kn))
 {
 kinhNghiem = kn;
     }
            else
           {
      MessageBox.Show("Kinh nghiệm phải là số nguyên!",
          "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    txtKinhNghiem.Focus();
   return;
      }
         }

BacSi bs = new BacSi
    {
    MaBacSi = selectedMaBacSi,
      MaNguoiDung = maNguoiDung,
  HoTen = txtHoTen.Text.Trim(),
       NgaySinh = dtpNgaySinh.Value,
  GioiTinh = cboGioiTinh.SelectedItem?.ToString() ?? "",
       CCCD = txtCCCD.Text.Trim(),
        DiaChi = txtDiaChi.Text.Trim(),
      KinhNghiem = kinhNghiem,
        ChuyenKhoa = txtChuyenKhoa.Text.Trim()
    };

    if (bacSiBUS.CapNhatBacSi(bs))
    {
              MessageBox.Show("Cập nhật bác sĩ thành công!",
   "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
      LoadDanhSach();
   ClearForm();
             LoadNguoiDungComboBox();
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

    // Xóa bác sĩ
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
     {
       if (string.IsNullOrEmpty(selectedMaBacSi))
    {
           MessageBox.Show("Vui lòng chọn bác sĩ cần xóa!",
    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
            }

 DialogResult result = MessageBox.Show(
       "Bạn có chắc chắn muốn xóa bác sĩ này?\n\n" +
  "LƯU Ý: Tất cả dữ liệu liên quan sẽ bị xóa!",
    "Xác nhận xóa",
          MessageBoxButtons.YesNo,
         MessageBoxIcon.Warning);

         if (result == DialogResult.Yes)
       {
          if (bacSiBUS.XoaBacSi(selectedMaBacSi))
             {
     MessageBox.Show("Xóa bác sĩ thành công!",
      "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
  LoadDanhSach();
         ClearForm();
          LoadNguoiDungComboBox();
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
    var ketQua = bacSiBUS.TimKiemBacSi(keyword);
       dataGridView1.DataSource = ketQua;

     if (dataGridView1.Columns.Contains("STT"))
   dataGridView1.Columns["STT"].Visible = false;

      if (ketQua.Count == 0)
        {
     MessageBox.Show("Không tìm thấy bác sĩ nào!",
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
          LoadNguoiDungComboBox();
        }

   // Chọn bác sĩ từ DataGridView
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
 {
        if (e.RowIndex >= 0)
        {
      try
         {
      DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

     selectedMaBacSi = row.Cells["MaBacSi"].Value?.ToString() ?? "";
     txtMaBS.Text = selectedMaBacSi;
  txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
        txtCCCD.Text = row.Cells["CCCD"].Value?.ToString() ?? "";

       if (row.Cells["NgaySinh"].Value != null && row.Cells["NgaySinh"].Value != DBNull.Value)
      {
  dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
    }
         else
           {
         dtpNgaySinh.Value = DateTime.Now;
    }

      string gioiTinh = row.Cells["GioiTinh"].Value?.ToString() ?? "";
    cboGioiTinh.SelectedItem = gioiTinh;

        txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";

     if (row.Cells["KinhNghiem"].Value != null && row.Cells["KinhNghiem"].Value != DBNull.Value)
        {
         txtKinhNghiem.Text = row.Cells["KinhNghiem"].Value.ToString();
    }
        else
              {
          txtKinhNghiem.Text = "";
               }

 txtChuyenKhoa.Text = row.Cells["ChuyenKhoa"].Value?.ToString() ?? "";

       int maNguoiDung = 0;
          if (row.Cells["MaNguoiDung"].Value != null && row.Cells["MaNguoiDung"].Value != DBNull.Value)
            {
    maNguoiDung = Convert.ToInt32(row.Cells["MaNguoiDung"].Value);
       }

      LoadNguoiDungComboBox(maNguoiDung);

 btnSua.BackColor = Color.FromArgb(241, 196, 15);
            btnThem.BackColor = Color.FromArgb(46, 204, 113);
              }
     catch (Exception ex)
        {
    MessageBox.Show("Lỗi khi chọn bác sĩ: " + ex.Message,
   "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa form
        private void ClearForm()
    {
            selectedMaBacSi = null;
            txtMaBS.Clear();
       txtHoTen.Clear();
    txtCCCD.Clear();
            dtpNgaySinh.Value = DateTime.Now;
      cboGioiTinh.SelectedIndex = -1;
            txtDiaChi.Clear();
            txtKinhNghiem.Clear();
    txtChuyenKhoa.Clear();
            txtTimKiem.Clear();

            if (cboMaNguoiDung.Items.Count > 0)
       {
      cboMaNguoiDung.SelectedIndex = 0;
       }

        btnSua.BackColor = Color.FromArgb(52, 152, 219);
         btnThem.BackColor = Color.FromArgb(46, 204, 113);

         cboMaNguoiDung.Focus();
    }
    }
}
