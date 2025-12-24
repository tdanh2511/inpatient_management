using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    partial class FormXuatVien
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvXuatVien;
        private Button btnThem, btnSua, btnXoa;
        private Label lblMaXuatVien, lblMaHoSo, lblMaHoaDon, lblNgayXuatVien, lblTinhTrang;
        private TextBox txtMaXuatVien, txtMaHoSo, txtMaHoaDon;
        private DateTimePicker dtpNgayXuatVien;
        private ComboBox cbTinhTrang;
        private Label lblDSXuatVien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvXuatVien = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblMaXuatVien = new System.Windows.Forms.Label();
            this.lblMaHoSo = new System.Windows.Forms.Label();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.lblNgayXuatVien = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.txtMaXuatVien = new System.Windows.Forms.TextBox();
            this.txtMaHoSo = new System.Windows.Forms.TextBox();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.dtpNgayXuatVien = new System.Windows.Forms.DateTimePicker();
            this.cbTinhTrang = new System.Windows.Forms.ComboBox();
            this.lblDSXuatVien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuatVien)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvXuatVien
            // 
            this.dgvXuatVien.Location = new System.Drawing.Point(12, 40);
            this.dgvXuatVien.MultiSelect = false;
            this.dgvXuatVien.Name = "dgvXuatVien";
            this.dgvXuatVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvXuatVien.Size = new System.Drawing.Size(700, 250);
            this.dgvXuatVien.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(350, 300);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(350, 340);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(350, 380);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // lblMaXuatVien
            // 
            this.lblMaXuatVien.Location = new System.Drawing.Point(12, 300);
            this.lblMaXuatVien.Name = "lblMaXuatVien";
            this.lblMaXuatVien.Size = new System.Drawing.Size(100, 23);
            this.lblMaXuatVien.TabIndex = 2;
            this.lblMaXuatVien.Text = "Mã Xuất viện:";
            // 
            // lblMaHoSo
            // 
            this.lblMaHoSo.Location = new System.Drawing.Point(12, 330);
            this.lblMaHoSo.Name = "lblMaHoSo";
            this.lblMaHoSo.Size = new System.Drawing.Size(100, 23);
            this.lblMaHoSo.TabIndex = 3;
            this.lblMaHoSo.Text = "Mã Hồ sơ:";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.Location = new System.Drawing.Point(12, 360);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(100, 23);
            this.lblMaHoaDon.TabIndex = 4;
            this.lblMaHoaDon.Text = "Mã Hóa đơn:";
            // 
            // lblNgayXuatVien
            // 
            this.lblNgayXuatVien.Location = new System.Drawing.Point(12, 390);
            this.lblNgayXuatVien.Name = "lblNgayXuatVien";
            this.lblNgayXuatVien.Size = new System.Drawing.Size(100, 23);
            this.lblNgayXuatVien.TabIndex = 5;
            this.lblNgayXuatVien.Text = "Ngày xuất viện:";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Location = new System.Drawing.Point(12, 420);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(100, 23);
            this.lblTinhTrang.TabIndex = 6;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // txtMaXuatVien
            // 
            this.txtMaXuatVien.Location = new System.Drawing.Point(120, 300);
            this.txtMaXuatVien.Name = "txtMaXuatVien";
            this.txtMaXuatVien.ReadOnly = true;
            this.txtMaXuatVien.Size = new System.Drawing.Size(200, 20);
            this.txtMaXuatVien.TabIndex = 7;
            // 
            // txtMaHoSo
            // 
            this.txtMaHoSo.Location = new System.Drawing.Point(120, 330);
            this.txtMaHoSo.Name = "txtMaHoSo";
            this.txtMaHoSo.Size = new System.Drawing.Size(200, 20);
            this.txtMaHoSo.TabIndex = 8;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Location = new System.Drawing.Point(120, 360);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(200, 20);
            this.txtMaHoaDon.TabIndex = 9;
            // 
            // dtpNgayXuatVien
            // 
            this.dtpNgayXuatVien.Location = new System.Drawing.Point(120, 390);
            this.dtpNgayXuatVien.Name = "dtpNgayXuatVien";
            this.dtpNgayXuatVien.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayXuatVien.TabIndex = 10;
            // 
            // cbTinhTrang
            // 
            this.cbTinhTrang.Items.AddRange(new object[] {
            "Đã khỏi",
            "Chuyển viện",
            "Tử vong"});
            this.cbTinhTrang.Location = new System.Drawing.Point(120, 420);
            this.cbTinhTrang.Name = "cbTinhTrang";
            this.cbTinhTrang.Size = new System.Drawing.Size(200, 21);
            this.cbTinhTrang.TabIndex = 11;
            // 
            // lblDSXuatVien
            // 
            this.lblDSXuatVien.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.lblDSXuatVien.Location = new System.Drawing.Point(12, 15);
            this.lblDSXuatVien.Name = "lblDSXuatVien";
            this.lblDSXuatVien.Size = new System.Drawing.Size(200, 20);
            this.lblDSXuatVien.TabIndex = 0;
            this.lblDSXuatVien.Text = "Danh sách Xuất viện";
            // 
            // FormXuatVien
            // 
            this.ClientSize = new System.Drawing.Size(734, 470);
            this.Controls.Add(this.lblDSXuatVien);
            this.Controls.Add(this.dgvXuatVien);
            this.Controls.Add(this.lblMaXuatVien);
            this.Controls.Add(this.lblMaHoSo);
            this.Controls.Add(this.lblMaHoaDon);
            this.Controls.Add(this.lblNgayXuatVien);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.txtMaXuatVien);
            this.Controls.Add(this.txtMaHoSo);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.dtpNgayXuatVien);
            this.Controls.Add(this.cbTinhTrang);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Name = "FormXuatVien";
            this.Text = "Quản lý Xuất viện";
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuatVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
