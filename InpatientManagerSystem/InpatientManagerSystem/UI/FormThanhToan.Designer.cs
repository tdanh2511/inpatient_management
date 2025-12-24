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
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label1 = new Label();
            this.splitContainer1 = new SplitContainer();
            this.dgvHoaDon = new DataGridView();
            this.panel1 = new Panel();
            this.lblDSHoaDon = new Label();
            this.groupBox1 = new GroupBox();
            this.txtGhiChu = new TextBox();
            this.cbPhuongThuc = new ComboBox();
            this.txtSoTien = new TextBox();
            this.btnXoa = new Button();
            this.btnSua = new Button();
            this.btnThem = new Button();
            this.lblGhiChu = new Label();
            this.lblPhuongThuc = new Label();
            this.lblSoTien = new Label();
            this.dgvChiTiet = new DataGridView();
            this.panel2 = new Panel();
            this.lblDSChiTiet = new Label();
            this.panel3 = new Panel();
            this.lblTinhTrang = new Label();
            this.lblNgayTao = new Label();
            this.lblMaHoaDon = new Label();
            this.lblDaThanhToan = new Label();
            this.lblTongTien = new Label();

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

            // tableLayoutPanel1
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new Padding(10);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new Size(1038, 704);
            this.tableLayoutPanel1.TabIndex = 0;

            // label1
            this.label1.AutoSize = true;
            this.label1.Dock = DockStyle.Fill;
            this.label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            this.label1.Location = new Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(1012, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THANH TOÁN";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;

            // splitContainer1
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(13, 63);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Orientation.Horizontal;

            // splitContainer1.Panel1
            this.splitContainer1.Panel1.Controls.Add(this.dgvHoaDon);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);

            // splitContainer1.Panel2
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.dgvChiTiet);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new Size(1012, 551);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 1;

            // dgvHoaDon
            this.dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Dock = DockStyle.Fill;
            this.dgvHoaDon.Location = new Point(0, 40);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new Size(1012, 160);
            this.dgvHoaDon.TabIndex = 0;

            // panel1
            this.panel1.Controls.Add(this.lblDSHoaDon);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(1012, 40);
            this.panel1.TabIndex = 1;

            // lblDSHoaDon
            this.lblDSHoaDon.AutoSize = true;
            this.lblDSHoaDon.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.lblDSHoaDon.Location = new Point(5, 10);
            this.lblDSHoaDon.Name = "lblDSHoaDon";
            this.lblDSHoaDon.Size = new Size(169, 19);
            this.lblDSHoaDon.TabIndex = 0;
            this.lblDSHoaDon.Text = "Danh sách Hóa đơn:";

            // groupBox1
            this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.cbPhuongThuc);
            this.groupBox1.Controls.Add(this.txtSoTien);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.lblGhiChu);
            this.groupBox1.Controls.Add(this.lblPhuongThuc);
            this.groupBox1.Controls.Add(this.lblSoTien);
            this.groupBox1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.groupBox1.Location = new Point(742, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(265, 290);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thanh toán";

            // txtGhiChu
            this.txtGhiChu.Location = new Point(15, 185);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new Size(235, 60);
            this.txtGhiChu.TabIndex = 8;

            // cbPhuongThuc
            this.cbPhuongThuc.FormattingEnabled = true;
            this.cbPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản" });
            this.cbPhuongThuc.Location = new Point(15, 125);
            this.cbPhuongThuc.Name = "cbPhuongThuc";
            this.cbPhuongThuc.Size = new Size(235, 25);
            this.cbPhuongThuc.TabIndex = 7;

            // txtSoTien
            this.txtSoTien.Location = new Point(15, 60);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new Size(235, 25);
            this.txtSoTien.TabIndex = 6;

            // btnXoa
            this.btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            this.btnXoa.FlatStyle = FlatStyle.Flat;
            this.btnXoa.ForeColor = Color.White;
            this.btnXoa.Location = new Point(175, 251);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new Size(75, 30);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;

            // btnSua
            this.btnSua.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.ForeColor = Color.White;
            this.btnSua.Location = new Point(95, 251);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new Size(75, 30);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;

            // btnThem
            this.btnThem.BackColor = Color.FromArgb(46, 204, 113);
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.ForeColor = Color.White;
            this.btnThem.Location = new Point(15, 251);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new Size(75, 30);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;

            // lblGhiChu
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new Point(15, 165);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new Size(66, 17);
            this.lblGhiChu.TabIndex = 2;
            this.lblGhiChu.Text = "Ghi chú:";

            // lblPhuongThuc
            this.lblPhuongThuc.AutoSize = true;
            this.lblPhuongThuc.Location = new Point(15, 105);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new Size(103, 17);
            this.lblPhuongThuc.TabIndex = 1;
            this.lblPhuongThuc.Text = "Phương thức:";

            // lblSoTien
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new Point(15, 40);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new Size(59, 17);
            this.lblSoTien.TabIndex = 0;
            this.lblSoTien.Text = "Số tiền:";

            // dgvChiTiet
            this.dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Dock = DockStyle.Fill;
            this.dgvChiTiet.Location = new Point(0, 40);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new Size(1012, 307);
            this.dgvChiTiet.TabIndex = 1;

            // panel2
            this.panel2.Controls.Add(this.lblDSChiTiet);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(1012, 40);
            this.panel2.TabIndex = 0;

            // lblDSChiTiet
            this.lblDSChiTiet.AutoSize = true;
            this.lblDSChiTiet.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.lblDSChiTiet.Location = new Point(5, 10);
            this.lblDSChiTiet.Name = "lblDSChiTiet";
            this.lblDSChiTiet.Size = new Size(165, 19);
            this.lblDSChiTiet.TabIndex = 0;
            this.lblDSChiTiet.Text = "Chi tiết Thanh toán:";

            // panel3
            this.panel3.Controls.Add(this.lblTinhTrang);
            this.panel3.Controls.Add(this.lblNgayTao);
            this.panel3.Controls.Add(this.lblMaHoaDon);
            this.panel3.Controls.Add(this.lblDaThanhToan);
            this.panel3.Controls.Add(this.lblTongTien);
            this.panel3.Dock = DockStyle.Fill;
            this.panel3.Location = new Point(13, 627);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(1012, 64);
            this.panel3.TabIndex = 2;

            // lblTinhTrang
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.lblTinhTrang.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTinhTrang.Location = new Point(680, 10);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new Size(83, 17);
            this.lblTinhTrang.TabIndex = 4;
            this.lblTinhTrang.Text = "Tình trạng:";

            // lblNgayTao
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.lblNgayTao.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblNgayTao.Location = new Point(460, 10);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new Size(75, 17);
            this.lblNgayTao.TabIndex = 3;
            this.lblNgayTao.Text = "Ngày tạo:";

            // lblMaHoaDon
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.lblMaHoaDon.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblMaHoaDon.Location = new Point(5, 10);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new Size(68, 17);
            this.lblMaHoaDon.TabIndex = 2;
            this.lblMaHoaDon.Text = "Mã HĐ:";

            // lblDaThanhToan
            this.lblDaThanhToan.AutoSize = true;
            this.lblDaThanhToan.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.lblDaThanhToan.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblDaThanhToan.Location = new Point(250, 37);
            this.lblDaThanhToan.Name = "lblDaThanhToan";
            this.lblDaThanhToan.Size = new Size(150, 19);
            this.lblDaThanhToan.TabIndex = 1;
            this.lblDaThanhToan.Text = "Đã thanh toán: 0 đ";

            // lblTongTien
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.lblTongTien.ForeColor = Color.FromArgb(192, 57, 43);
            this.lblTongTien.Location = new Point(5, 37);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new Size(104, 19);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "Tổng tiền: 0 đ";

            // FormThanhToan
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1038, 704);
            this.Controls.Add(this.tableLayoutPanel1);
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
