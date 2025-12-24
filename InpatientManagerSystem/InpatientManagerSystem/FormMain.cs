using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InpatientManagerSystem.UI;

namespace InpatientManagerSystem
{
    public partial class FormMain : Form
    {
        private Button activeButton = null;
        private Color activeColor = Color.FromArgb(41, 128, 185);
        private Color defaultColor = Color.FromArgb(52, 73, 94);

        public FormMain()
        {
            InitializeComponent();
            // Load welcome panel on startup
            LoadForm(new FormWelcomePanel());
        }

        private void LoadForm(Form childForm)
        {
            // Clear existing controls
            panelContent.Controls.Clear();
  
            // Set child form properties
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
          
            // Add to panel and show
            panelContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void ActivateButton(Button sender)
        {
            // Reset previous active button
            if (activeButton != null)
            {
                activeButton.BackColor = defaultColor;
                activeButton.ForeColor = Color.White;
            }

            // Set new active button
            sender.BackColor = activeColor;
            sender.ForeColor = Color.White;
            activeButton = sender;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Quản lý người dùng
            ActivateButton((Button)sender);
            LoadForm(new FormQuanLiNguoiDung());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bác sĩ
            ActivateButton((Button)sender);
            LoadForm(new FormBacSi());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Bệnh nhân
            ActivateButton((Button)sender);
            LoadForm(new FormBenhNhan());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Khám bệnh
            ActivateButton((Button)sender);
            LoadForm(new FormKhamBenh());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Dịch vụ
            ActivateButton((Button)sender);
            LoadForm(new FormDichVu());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Hồ sơ
            ActivateButton((Button)sender);
            LoadForm(new FormHoSo());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Phòng
            ActivateButton((Button)sender);
            LoadForm(new FormPhong());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Giường
            ActivateButton((Button)sender);
            LoadForm(new FormGiuong());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Thuốc
            ActivateButton((Button)sender);
            LoadForm(new FormThuoc());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Đơn thuốc
            ActivateButton((Button)sender);
            LoadForm(new FormDonThuoc());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Hóa đơn
            ActivateButton((Button)sender);
            LoadForm(new FormHoadon());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Thanh toán
            ActivateButton((Button)sender);
            LoadForm(new FormThanhToan());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Xuất viện
            ActivateButton((Button)sender);
            LoadForm(new FormXuatVien());
        }
    }
}
