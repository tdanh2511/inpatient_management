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
            LoadForm(new WelcomePanel());
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
            LoadForm(new QuanLiNguoiDung());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bác sĩ
            ActivateButton((Button)sender);
            LoadForm(new BacSi());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Bệnh nhân
            ActivateButton((Button)sender);
            LoadForm(new BenhNhan());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Khám bệnh
            ActivateButton((Button)sender);
            LoadForm(new KhamBenh());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Dịch vụ
            ActivateButton((Button)sender);
            LoadForm(new DichVu());
        }
    }
}
