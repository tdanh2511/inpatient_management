using System;
using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    partial class FormPopupChiTietHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMaDichVu, lblTenDichVu, lblDonGia, lblSoLuong, lblGhiChu;
        private TextBox txtMaDichVu, txtTenDichVu, txtDonGia, txtSoLuong, txtGhiChu;
        private Button btnChonDichVu, btnLuu, btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMaDichVu = new System.Windows.Forms.Label();
            this.lblTenDichVu = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtMaDichVu = new System.Windows.Forms.TextBox();
            this.txtTenDichVu = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnChonDichVu = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMaDichVu
            // 
            this.lblMaDichVu.Location = new System.Drawing.Point(20, 20);
            this.lblMaDichVu.Name = "lblMaDichVu";
            this.lblMaDichVu.Size = new System.Drawing.Size(100, 25);
            this.lblMaDichVu.TabIndex = 0;
            this.lblMaDichVu.Text = "Mã Dịch Vụ:";
            // 
            // lblTenDichVu
            // 
            this.lblTenDichVu.Location = new System.Drawing.Point(20, 60);
            this.lblTenDichVu.Name = "lblTenDichVu";
            this.lblTenDichVu.Size = new System.Drawing.Size(100, 25);
            this.lblTenDichVu.TabIndex = 1;
            this.lblTenDichVu.Text = "Tên Dịch Vụ:";
            // 
            // lblDonGia
            // 
            this.lblDonGia.Location = new System.Drawing.Point(20, 100);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(100, 25);
            this.lblDonGia.TabIndex = 2;
            this.lblDonGia.Text = "Đơn Giá:";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(20, 140);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(100, 25);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số Lượng:";
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(20, 180);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(100, 25);
            this.lblGhiChu.TabIndex = 4;
            this.lblGhiChu.Text = "Ghi Chú:";
            // 
            // txtMaDichVu
            // 
            this.txtMaDichVu.Location = new System.Drawing.Point(130, 20);
            this.txtMaDichVu.Name = "txtMaDichVu";
            this.txtMaDichVu.ReadOnly = true;
            this.txtMaDichVu.Size = new System.Drawing.Size(200, 20);
            this.txtMaDichVu.TabIndex = 5;
            // 
            // txtTenDichVu
            // 
            this.txtTenDichVu.Location = new System.Drawing.Point(130, 60);
            this.txtTenDichVu.Name = "txtTenDichVu";
            this.txtTenDichVu.ReadOnly = true;
            this.txtTenDichVu.Size = new System.Drawing.Size(200, 20);
            this.txtTenDichVu.TabIndex = 6;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(130, 100);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(200, 20);
            this.txtDonGia.TabIndex = 7;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(130, 140);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(200, 20);
            this.txtSoLuong.TabIndex = 8;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(130, 180);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(200, 20);
            this.txtGhiChu.TabIndex = 9;
            // 
            // btnChonDichVu
            // 
            this.btnChonDichVu.Location = new System.Drawing.Point(350, 20);
            this.btnChonDichVu.Name = "btnChonDichVu";
            this.btnChonDichVu.Size = new System.Drawing.Size(89, 23);
            this.btnChonDichVu.TabIndex = 10;
            this.btnChonDichVu.Text = "Chọn Dịch Vụ";
            this.btnChonDichVu.Click += new System.EventHandler(this.btnChonDichVu_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(130, 220);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(250, 220);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormPopupChiTietHoaDon
            // 
            this.ClientSize = new System.Drawing.Size(500, 270);
            this.Controls.Add(this.lblMaDichVu);
            this.Controls.Add(this.lblTenDichVu);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtMaDichVu);
            this.Controls.Add(this.txtTenDichVu);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.btnChonDichVu);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Name = "FormPopupChiTietHoaDon";
            this.Text = "Chi Tiết Hóa Đơn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
