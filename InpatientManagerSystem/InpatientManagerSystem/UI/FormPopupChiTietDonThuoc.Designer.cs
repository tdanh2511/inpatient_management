using System;
using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    partial class FormPopupChiTietDonThuoc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtMaThuoc = new System.Windows.Forms.TextBox();
            this.txtTenThuoc = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtLieuLuong = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnChonThuoc = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMaThuoc
            // 
            this.txtMaThuoc.Location = new System.Drawing.Point(130, 20);
            this.txtMaThuoc.Name = "txtMaThuoc";
            this.txtMaThuoc.ReadOnly = true;
            this.txtMaThuoc.Size = new System.Drawing.Size(200, 22);
            this.txtMaThuoc.TabIndex = 7;
            this.txtMaThuoc.TextChanged += new System.EventHandler(this.txtMaThuoc_TextChanged);
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.Location = new System.Drawing.Point(130, 60);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.ReadOnly = true;
            this.txtTenThuoc.Size = new System.Drawing.Size(200, 22);
            this.txtTenThuoc.TabIndex = 8;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(130, 100);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.ReadOnly = true;
            this.txtDonVi.Size = new System.Drawing.Size(200, 22);
            this.txtDonVi.TabIndex = 9;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(130, 140);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.Size = new System.Drawing.Size(200, 22);
            this.txtDonGia.TabIndex = 10;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(130, 180);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(200, 22);
            this.txtSoLuong.TabIndex = 11;
            // 
            // txtLieuLuong
            // 
            this.txtLieuLuong.Location = new System.Drawing.Point(130, 220);
            this.txtLieuLuong.Name = "txtLieuLuong";
            this.txtLieuLuong.Size = new System.Drawing.Size(200, 22);
            this.txtLieuLuong.TabIndex = 12;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(130, 260);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(200, 50);
            this.txtGhiChu.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Thuốc:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Thuốc:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn vị:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Đơn giá:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số lượng:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Liều lượng:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(20, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ghi chú:";
            // 
            // btnChonThuoc
            // 
            this.btnChonThuoc.Location = new System.Drawing.Point(350, 20);
            this.btnChonThuoc.Name = "btnChonThuoc";
            this.btnChonThuoc.Size = new System.Drawing.Size(100, 25);
            this.btnChonThuoc.TabIndex = 14;
            this.btnChonThuoc.Text = "Chọn Thuốc";
            this.btnChonThuoc.Click += new System.EventHandler(this.btnChonThuoc_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(130, 330);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(80, 30);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(250, 330);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 30);
            this.btnHuy.TabIndex = 16;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormPopupChiTietDonThuoc
            // 
            this.ClientSize = new System.Drawing.Size(500, 380);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMaThuoc);
            this.Controls.Add(this.txtTenThuoc);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtLieuLuong);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.btnChonThuoc);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Name = "FormPopupChiTietDonThuoc";
            this.Text = "Chi tiết đơn thuốc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtMaThuoc, txtTenThuoc, txtDonVi, txtDonGia, txtSoLuong, txtLieuLuong, txtGhiChu;
        private Label label1, label2, label3, label4, label5, label6, label7;
        private Button btnChonThuoc, btnLuu, btnHuy;
    }
}
