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
        public FormMain()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Quản lý người dùng
            LoadForm(new QuanLiNguoiDung());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Bác sĩ
            LoadForm(new BacSi());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Bệnh nhân
            LoadForm(new BenhNhan());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Khám bệnh
            LoadForm(new KhamBenh());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Dịch vụ
            LoadForm(new DichVu());
        }
    }
}
