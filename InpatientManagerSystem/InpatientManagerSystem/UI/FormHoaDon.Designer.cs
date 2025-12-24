using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    partial class FormHoadon
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvHoaDon;
        private DataGridView dgvChiTiet;
        private Button btnThemHD, btnSuaHD, btnXoaHD;
        private Button btnThemCT, btnSuaCT, btnXoaCT;
        private Label lblTongTien, lblDaThanhToan;
        private Label lblDSHoaDon, lblDSChiTiet;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvHoaDon = new DataGridView();
            this.dgvChiTiet = new DataGridView();
            this.btnThemHD = new Button();
            this.btnSuaHD = new Button();
            this.btnXoaHD = new Button();
            this.btnThemCT = new Button();
            this.btnSuaCT = new Button();
            this.btnXoaCT = new Button();
            this.lblTongTien = new Label();
            this.lblDaThanhToan = new Label();
            this.lblDSHoaDon = new Label();
            this.lblDSChiTiet = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();

            // Labels trên gridview
            this.lblDSHoaDon.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            this.lblDSHoaDon.Location = new Point(12, 35);
            this.lblDSHoaDon.Size = new Size(200, 20);
            this.lblDSHoaDon.Text = "Danh sách Hóa đơn";

            this.lblDSChiTiet.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            this.lblDSChiTiet.Location = new Point(12, 220);
            this.lblDSChiTiet.Size = new Size(200, 20);
            this.lblDSChiTiet.Text = "Chi tiết Hóa đơn";

            // dgvHoaDon
            this.dgvHoaDon.Location = new Point(12, 60);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new Size(800, 150);

            // dgvChiTiet
            this.dgvChiTiet.Location = new Point(12, 250);
            this.dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new Size(800, 200);

            // btnThemHD
            this.btnThemHD.BackColor = Color.FromArgb(46, 204, 113);
            this.btnThemHD.ForeColor = Color.White;
            this.btnThemHD.FlatStyle = FlatStyle.Flat;
            this.btnThemHD.FlatAppearance.BorderSize = 0;
            this.btnThemHD.Location = new Point(830, 60);
            this.btnThemHD.Size = new Size(75, 23);
            this.btnThemHD.Text = "Thêm HĐ";

            // btnSuaHD
            this.btnSuaHD.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSuaHD.ForeColor = Color.White;
            this.btnSuaHD.FlatStyle = FlatStyle.Flat;
            this.btnSuaHD.FlatAppearance.BorderSize = 0;
            this.btnSuaHD.Location = new Point(830, 99);
            this.btnSuaHD.Size = new Size(75, 23);
            this.btnSuaHD.Text = "Sửa HĐ";

            // btnXoaHD
            this.btnXoaHD.BackColor = Color.FromArgb(231, 76, 60);
            this.btnXoaHD.ForeColor = Color.White;
            this.btnXoaHD.FlatStyle = FlatStyle.Flat;
            this.btnXoaHD.FlatAppearance.BorderSize = 0;
            this.btnXoaHD.Location = new Point(830, 141);
            this.btnXoaHD.Size = new Size(75, 23);
            this.btnXoaHD.Text = "Xóa HĐ";

            // btnThemCT
            this.btnThemCT.BackColor = Color.FromArgb(46, 204, 113);
            this.btnThemCT.ForeColor = Color.White;
            this.btnThemCT.FlatStyle = FlatStyle.Flat;
            this.btnThemCT.FlatAppearance.BorderSize = 0;
            this.btnThemCT.Location = new Point(830, 248);
            this.btnThemCT.Size = new Size(75, 23);
            this.btnThemCT.Text = "Thêm CT";

            // btnSuaCT
            this.btnSuaCT.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSuaCT.ForeColor = Color.White;
            this.btnSuaCT.FlatStyle = FlatStyle.Flat;
            this.btnSuaCT.FlatAppearance.BorderSize = 0;
            this.btnSuaCT.Location = new Point(830, 286);
            this.btnSuaCT.Size = new Size(75, 23);
            this.btnSuaCT.Text = "Sửa CT";

            // btnXoaCT
            this.btnXoaCT.BackColor = Color.FromArgb(231, 76, 60);
            this.btnXoaCT.ForeColor = Color.White;
            this.btnXoaCT.FlatStyle = FlatStyle.Flat;
            this.btnXoaCT.FlatAppearance.BorderSize = 0;
            this.btnXoaCT.Location = new Point(830, 325);
            this.btnXoaCT.Size = new Size(75, 23);
            this.btnXoaCT.Text = "Xóa CT";

            // lblTongTien
            this.lblTongTien.Location = new Point(9, 481);
            this.lblTongTien.Size = new Size(200, 25);
            this.lblTongTien.Text = "Tổng Tiền: 0";

            // lblDaThanhToan
            this.lblDaThanhToan.Location = new Point(226, 481);
            this.lblDaThanhToan.Size = new Size(200, 25);
            this.lblDaThanhToan.Text = "Đã Thanh Toán: 0";

            // FormHoadon
            this.ClientSize = new Size(950, 515);
            this.Controls.Add(this.lblDSHoaDon);
            this.Controls.Add(this.lblDSChiTiet);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.btnThemHD);
            this.Controls.Add(this.btnSuaHD);
            this.Controls.Add(this.btnXoaHD);
            this.Controls.Add(this.btnThemCT);
            this.Controls.Add(this.btnSuaCT);
            this.Controls.Add(this.btnXoaCT);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblDaThanhToan);
            this.Name = "FormHoadon";
            this.Text = "Quản lý Hóa Đơn";

            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
