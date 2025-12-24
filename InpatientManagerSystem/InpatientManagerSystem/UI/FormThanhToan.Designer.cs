using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    partial class FormThanhToan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDSHoaDon = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cbPhuongThuc = new System.Windows.Forms.ComboBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDSChiTiet = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.lblDaThanhToan = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1384, 866);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1350, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THANH TOÁN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(17, 78);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvHoaDon);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            var tableLayout2 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2
            };
            tableLayout2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayout2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayout2.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
            tableLayout2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayout2.SetColumnSpan(this.panel2, 2);
            tableLayout2.Controls.Add(this.panel2, 0, 0);
            tableLayout2.Controls.Add(this.dgvChiTiet, 0, 1);
            tableLayout2.Controls.Add(this.groupBox1, 1, 1);
            this.splitContainer1.Panel2.Controls.Add(tableLayout2);
            this.splitContainer1.Size = new System.Drawing.Size(1350, 674);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 49);
            this.dgvHoaDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1350, 195);
            this.dgvHoaDon.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDSHoaDon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1350, 49);
            this.panel1.TabIndex = 1;
            // 
            // lblDSHoaDon
            // 
            this.lblDSHoaDon.AutoSize = true;
            this.lblDSHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblDSHoaDon.Location = new System.Drawing.Point(7, 12);
            this.lblDSHoaDon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDSHoaDon.Name = "lblDSHoaDon";
            this.lblDSHoaDon.Size = new System.Drawing.Size(179, 23);
            this.lblDSHoaDon.TabIndex = 0;
            this.lblDSHoaDon.Text = "Danh sách Hóa đơn:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.cbPhuongThuc);
            this.groupBox1.Controls.Add(this.txtSoTien);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.lblGhiChu);
            this.groupBox1.Controls.Add(this.lblPhuongThuc);
            this.groupBox1.Controls.Add(this.lblSoTien);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(100, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thanh toán";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(15, 190);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(280, 55);
            this.txtGhiChu.TabIndex = 8;
            // 
            // cbPhuongThuc
            // 
            this.cbPhuongThuc.FormattingEnabled = true;
            this.cbPhuongThuc.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản"});
            this.cbPhuongThuc.Location = new System.Drawing.Point(15, 135);
            this.cbPhuongThuc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPhuongThuc.Name = "cbPhuongThuc";
            this.cbPhuongThuc.Size = new System.Drawing.Size(280, 30);
            this.cbPhuongThuc.TabIndex = 7;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(15, 60);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(280, 29);
            this.txtSoTien.TabIndex = 6;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(205, 255);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 35);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(108, 255);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 35);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(15, 255);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 35);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(15, 170);
            this.lblGhiChu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(79, 22);
            this.lblGhiChu.TabIndex = 2;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.AutoSize = true;
            this.lblPhuongThuc.Location = new System.Drawing.Point(15, 110);
            this.lblPhuongThuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(120, 22);
            this.lblPhuongThuc.TabIndex = 1;
            this.lblPhuongThuc.Text = "Phương thức:";
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(15, 35);
            this.lblSoTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(71, 22);
            this.lblSoTien.TabIndex = 0;
            this.lblSoTien.Text = "Số tiền:";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Location = new System.Drawing.Point(0, 0);
            this.dgvChiTiet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 51;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(100, 100);
            this.dgvChiTiet.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDSChiTiet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 49);
            this.panel2.TabIndex = 0;
            // 
            // lblDSChiTiet
            // 
            this.lblDSChiTiet.AutoSize = true;
            this.lblDSChiTiet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblDSChiTiet.Location = new System.Drawing.Point(7, 12);
            this.lblDSChiTiet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDSChiTiet.Name = "lblDSChiTiet";
            this.lblDSChiTiet.Size = new System.Drawing.Size(180, 23);
            this.lblDSChiTiet.TabIndex = 0;
            this.lblDSChiTiet.Text = "Chi tiết Thanh toán:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTinhTrang);
            this.panel3.Controls.Add(this.lblNgayTao);
            this.panel3.Controls.Add(this.lblMaHoaDon);
            this.panel3.Controls.Add(this.lblDaThanhToan);
            this.panel3.Controls.Add(this.lblTongTien);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(17, 760);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1350, 90);
            this.panel3.TabIndex = 2;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTinhTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTinhTrang.Location = new System.Drawing.Point(907, 12);
            this.lblTinhTrang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(102, 22);
            this.lblTinhTrang.TabIndex = 4;
            this.lblTinhTrang.Text = "Tình trạng:";
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblNgayTao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblNgayTao.Location = new System.Drawing.Point(613, 12);
            this.lblNgayTao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(89, 22);
            this.lblNgayTao.TabIndex = 3;
            this.lblNgayTao.Text = "Ngày tạo:";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblMaHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMaHoaDon.Location = new System.Drawing.Point(7, 12);
            this.lblMaHoaDon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(76, 22);
            this.lblMaHoaDon.TabIndex = 2;
            this.lblMaHoaDon.Text = "Mã HĐ:";
            // 
            // lblDaThanhToan
            // 
            this.lblDaThanhToan.AutoSize = true;
            this.lblDaThanhToan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblDaThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblDaThanhToan.Location = new System.Drawing.Point(333, 46);
            this.lblDaThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDaThanhToan.Name = "lblDaThanhToan";
            this.lblDaThanhToan.Size = new System.Drawing.Size(165, 23);
            this.lblDaThanhToan.TabIndex = 1;
            this.lblDaThanhToan.Text = "Đã thanh toán: 0 đ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblTongTien.Location = new System.Drawing.Point(7, 46);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(127, 23);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "Tổng tiền: 0 đ";
            // 
            // FormThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1384, 866);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormThanhToan";
            this.Text = "Quản lý Thanh Toán";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private SplitContainer splitContainer1;
        private DataGridView dgvHoaDon;
        private Panel panel1;
        private Label lblDSHoaDon;
        private GroupBox groupBox1;
        private TextBox txtGhiChu;
        private ComboBox cbPhuongThuc;
        private TextBox txtSoTien;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Label lblGhiChu;
        private Label lblPhuongThuc;
        private Label lblSoTien;
        private DataGridView dgvChiTiet;
        private Panel panel2;
        private Label lblDSChiTiet;
        private Panel panel3;
        private Label lblTinhTrang;
        private Label lblNgayTao;
        private Label lblMaHoaDon;
        private Label lblDaThanhToan;
        private Label lblTongTien;
    }
}
