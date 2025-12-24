using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    partial class FormDonThuoc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaDonThuoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaKhamBenh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayKe = new System.Windows.Forms.DateTimePicker();
            this.labelTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvDonThuoc = new System.Windows.Forms.DataGridView();
            this.dgvChiTietDonThuoc = new System.Windows.Forms.DataGridView();
            this.labelChiTiet = new System.Windows.Forms.Label();
            this.btnThemCT = new System.Windows.Forms.Button();
            this.btnSuaCT = new System.Windows.Forms.Button();
            this.btnXoaCT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn thuốc:";
            // 
            // txtMaDonThuoc
            // 
            this.txtMaDonThuoc.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.txtMaDonThuoc.Location = new System.Drawing.Point(160, 20);
            this.txtMaDonThuoc.Name = "txtMaDonThuoc";
            this.txtMaDonThuoc.Size = new System.Drawing.Size(200, 24);
            this.txtMaDonThuoc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(30, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã khám bệnh:";
            // 
            // txtMaKhamBenh
            // 
            this.txtMaKhamBenh.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.txtMaKhamBenh.Location = new System.Drawing.Point(160, 60);
            this.txtMaKhamBenh.Name = "txtMaKhamBenh";
            this.txtMaKhamBenh.Size = new System.Drawing.Size(200, 24);
            this.txtMaKhamBenh.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(30, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày kê:";
            // 
            // dtpNgayKe
            // 
            this.dtpNgayKe.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.dtpNgayKe.Location = new System.Drawing.Point(160, 100);
            this.dtpNgayKe.Name = "dtpNgayKe";
            this.dtpNgayKe.Size = new System.Drawing.Size(200, 24);
            this.dtpNgayKe.TabIndex = 5;
            // 
            // labelTimKiem
            // 
            this.labelTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.labelTimKiem.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.labelTimKiem.ForeColor = System.Drawing.Color.White;
            this.labelTimKiem.Location = new System.Drawing.Point(750, 20);
            this.labelTimKiem.Name = "labelTimKiem";
            this.labelTimKiem.Size = new System.Drawing.Size(90, 30);
            this.labelTimKiem.TabIndex = 6;
            this.labelTimKiem.Text = "Tìm kiếm:";
            this.labelTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.txtTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtTimKiem.Location = new System.Drawing.Point(850, 20);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 24);
            this.txtTimKiem.TabIndex = 7;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 150);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 40);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(150, 150);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 40);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(280, 150);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 40);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(410, 150);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(110, 40);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // dgvDonThuoc
            // 
            this.dgvDonThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDonThuoc.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.dgvDonThuoc.Location = new System.Drawing.Point(20, 200);
            this.dgvDonThuoc.Name = "dgvDonThuoc";
            this.dgvDonThuoc.Size = new System.Drawing.Size(1030, 146);
            this.dgvDonThuoc.TabIndex = 13;
            // 
            // dgvChiTietDonThuoc
            // 
            this.dgvChiTietDonThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietDonThuoc.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.dgvChiTietDonThuoc.Location = new System.Drawing.Point(20, 423);
            this.dgvChiTietDonThuoc.Name = "dgvChiTietDonThuoc";
            this.dgvChiTietDonThuoc.Size = new System.Drawing.Size(1030, 227);
            this.dgvChiTietDonThuoc.TabIndex = 14;
            // 
            // labelChiTiet
            // 
            this.labelChiTiet.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.labelChiTiet.Location = new System.Drawing.Point(30, 349);
            this.labelChiTiet.Name = "labelChiTiet";
            this.labelChiTiet.Size = new System.Drawing.Size(200, 25);
            this.labelChiTiet.TabIndex = 12;
            this.labelChiTiet.Text = "Chi tiết đơn thuốc:";
            // 
            // btnThemCT
            // 
            this.btnThemCT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThemCT.FlatAppearance.BorderSize = 0;
            this.btnThemCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnThemCT.ForeColor = System.Drawing.Color.White;
            this.btnThemCT.Location = new System.Drawing.Point(20, 377);
            this.btnThemCT.Name = "btnThemCT";
            this.btnThemCT.Size = new System.Drawing.Size(110, 40);
            this.btnThemCT.TabIndex = 15;
            this.btnThemCT.Text = "Thêm CT";
            this.btnThemCT.UseVisualStyleBackColor = false;
            this.btnThemCT.Click += new System.EventHandler(this.btnThemCT_Click);
            // 
            // btnSuaCT
            // 
            this.btnSuaCT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSuaCT.FlatAppearance.BorderSize = 0;
            this.btnSuaCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSuaCT.ForeColor = System.Drawing.Color.White;
            this.btnSuaCT.Location = new System.Drawing.Point(150, 377);
            this.btnSuaCT.Name = "btnSuaCT";
            this.btnSuaCT.Size = new System.Drawing.Size(110, 40);
            this.btnSuaCT.TabIndex = 16;
            this.btnSuaCT.Text = "Sửa CT";
            this.btnSuaCT.UseVisualStyleBackColor = false;
            this.btnSuaCT.Click += new System.EventHandler(this.btnSuaCT_Click);
            // 
            // btnXoaCT
            // 
            this.btnXoaCT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaCT.FlatAppearance.BorderSize = 0;
            this.btnXoaCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoaCT.ForeColor = System.Drawing.Color.White;
            this.btnXoaCT.Location = new System.Drawing.Point(280, 377);
            this.btnXoaCT.Name = "btnXoaCT";
            this.btnXoaCT.Size = new System.Drawing.Size(110, 40);
            this.btnXoaCT.TabIndex = 17;
            this.btnXoaCT.Text = "Xóa CT";
            this.btnXoaCT.UseVisualStyleBackColor = false;
            // 
            // FormDonThuoc
            // 
            this.ClientSize = new System.Drawing.Size(1080, 670);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaDonThuoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaKhamBenh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpNgayKe);
            this.Controls.Add(this.labelTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.labelChiTiet);
            this.Controls.Add(this.dgvDonThuoc);
            this.Controls.Add(this.dgvChiTietDonThuoc);
            this.Controls.Add(this.btnThemCT);
            this.Controls.Add(this.btnSuaCT);
            this.Controls.Add(this.btnXoaCT);
            this.Name = "FormDonThuoc";
            this.Text = "Quản lý đơn thuốc";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonThuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1, label2, label3, labelTimKiem, labelChiTiet;
        private TextBox txtMaDonThuoc, txtMaKhamBenh, txtTimKiem;
        private DateTimePicker dtpNgayKe;
        private Button btnThem, btnSua, btnXoa, btnLamMoi;
        private Button btnThemCT, btnSuaCT, btnXoaCT;
        private DataGridView dgvDonThuoc, dgvChiTietDonThuoc;
    }
}
