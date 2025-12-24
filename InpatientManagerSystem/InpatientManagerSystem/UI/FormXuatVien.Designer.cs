using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    partial class FormXuatVien
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
            this.groupBox1 = new GroupBox();
            this.cbTinhTrang = new ComboBox();
            this.dtpNgayXuatVien = new DateTimePicker();
            this.txtMaHoaDon = new TextBox();
            this.txtMaHoSo = new TextBox();
            this.txtMaXuatVien = new TextBox();
            this.lblTinhTrang = new Label();
            this.lblNgayXuatVien = new Label();
            this.lblMaHoaDon = new Label();
            this.lblMaHoSo = new Label();
            this.lblMaXuatVien = new Label();
            this.panel1 = new Panel();
            this.btnTimKiem = new Button();
            this.txtTimKiem = new TextBox();
            this.btnLamMoi = new Button();
            this.btnXoa = new Button();
            this.btnSua = new Button();
            this.btnThem = new Button();
            this.dgvXuatVien = new DataGridView();

            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuatVien)).BeginInit();
            this.SuspendLayout();

            // tableLayoutPanel1
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvXuatVien, 0, 3);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new Padding(10);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 210F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
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
            this.label1.Text = "QUẢN LÝ XUẤT VIỆN";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;

            // groupBox1
            this.groupBox1.Controls.Add(this.cbTinhTrang);
            this.groupBox1.Controls.Add(this.dtpNgayXuatVien);
            this.groupBox1.Controls.Add(this.txtMaHoaDon);
            this.groupBox1.Controls.Add(this.txtMaHoSo);
            this.groupBox1.Controls.Add(this.txtMaXuatVien);
            this.groupBox1.Controls.Add(this.lblTinhTrang);
            this.groupBox1.Controls.Add(this.lblNgayXuatVien);
            this.groupBox1.Controls.Add(this.lblMaHoaDon);
            this.groupBox1.Controls.Add(this.lblMaHoSo);
            this.groupBox1.Controls.Add(this.lblMaXuatVien);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.groupBox1.Location = new Point(13, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(1012, 204);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin xuất viện";

            // cbTinhTrang
            this.cbTinhTrang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.cbTinhTrang.FormattingEnabled = true;
            this.cbTinhTrang.Items.AddRange(new object[] { "Đã khỏi", "Chuyển viện", "Tử vong" });
            this.cbTinhTrang.Location = new Point(625, 100);
            this.cbTinhTrang.Name = "cbTinhTrang";
            this.cbTinhTrang.Size = new Size(370, 25);
            this.cbTinhTrang.TabIndex = 9;

            // dtpNgayXuatVien
            this.dtpNgayXuatVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.dtpNgayXuatVien.Format = DateTimePickerFormat.Short;
            this.dtpNgayXuatVien.Location = new Point(625, 65);
            this.dtpNgayXuatVien.Name = "dtpNgayXuatVien";
            this.dtpNgayXuatVien.Size = new Size(370, 25);
            this.dtpNgayXuatVien.TabIndex = 8;

            // txtMaHoaDon
            this.txtMaHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtMaHoaDon.Location = new Point(625, 30);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new Size(370, 25);
            this.txtMaHoaDon.TabIndex = 7;

            // txtMaHoSo
            this.txtMaHoSo.Location = new Point(150, 65);
            this.txtMaHoSo.Name = "txtMaHoSo";
            this.txtMaHoSo.Size = new Size(320, 25);
            this.txtMaHoSo.TabIndex = 6;

            // txtMaXuatVien
            this.txtMaXuatVien.Location = new Point(150, 30);
            this.txtMaXuatVien.Name = "txtMaXuatVien";
            this.txtMaXuatVien.ReadOnly = true;
            this.txtMaXuatVien.Size = new Size(320, 25);
            this.txtMaXuatVien.TabIndex = 5;

            // lblTinhTrang
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Location = new Point(520, 103);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new Size(82, 17);
            this.lblTinhTrang.TabIndex = 4;
            this.lblTinhTrang.Text = "Tình trạng:";

            // lblNgayXuatVien
            this.lblNgayXuatVien.AutoSize = true;
            this.lblNgayXuatVien.Location = new Point(520, 68);
            this.lblNgayXuatVien.Name = "lblNgayXuatVien";
            this.lblNgayXuatVien.Size = new Size(117, 17);
            this.lblNgayXuatVien.TabIndex = 3;
            this.lblNgayXuatVien.Text = "Ngày xuất viện:";

            // lblMaHoaDon
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Location = new Point(520, 33);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new Size(90, 17);
            this.lblMaHoaDon.TabIndex = 2;
            this.lblMaHoaDon.Text = "Mã hóa đơn:";

            // lblMaHoSo
            this.lblMaHoSo.AutoSize = true;
            this.lblMaHoSo.Location = new Point(30, 68);
            this.lblMaHoSo.Name = "lblMaHoSo";
            this.lblMaHoSo.Size = new Size(71, 17);
            this.lblMaHoSo.TabIndex = 1;
            this.lblMaHoSo.Text = "Mã hồ sơ:";

            // lblMaXuatVien
            this.lblMaXuatVien.AutoSize = true;
            this.lblMaXuatVien.Location = new Point(30, 33);
            this.lblMaXuatVien.Name = "lblMaXuatVien";
            this.lblMaXuatVien.Size = new Size(102, 17);
            this.lblMaXuatVien.TabIndex = 0;
            this.lblMaXuatVien.Text = "Mã xuất viện:";

            // panel1
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.btnLamMoi);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(13, 273);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(1012, 54);
            this.panel1.TabIndex = 2;

            // btnTimKiem
            this.btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnTimKiem.BackColor = Color.FromArgb(52, 73, 94);
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.btnTimKiem.ForeColor = Color.White;
            this.btnTimKiem.Location = new Point(909, 5);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new Size(100, 40);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;

            // txtTimKiem
            this.txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.txtTimKiem.Font = new Font("Times New Roman", 11.25F);
            this.txtTimKiem.Location = new Point(674, 13);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new Size(220, 25);
            this.txtTimKiem.TabIndex = 4;

            // btnLamMoi
            this.btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.btnLamMoi.ForeColor = Color.White;
            this.btnLamMoi.Location = new Point(330, 5);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new Size(100, 40);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;

            // btnXoa
            this.btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            this.btnXoa.FlatStyle = FlatStyle.Flat;
            this.btnXoa.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.btnXoa.ForeColor = Color.White;
            this.btnXoa.Location = new Point(220, 5);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new Size(100, 40);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;

            // btnSua
            this.btnSua.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.btnSua.ForeColor = Color.White;
            this.btnSua.Location = new Point(110, 5);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new Size(100, 40);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;

            // btnThem
            this.btnThem.BackColor = Color.FromArgb(46, 204, 113);
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.btnThem.ForeColor = Color.White;
            this.btnThem.Location = new Point(0, 5);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new Size(100, 40);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;

            // dgvXuatVien
            this.dgvXuatVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXuatVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXuatVien.Dock = DockStyle.Fill;
            this.dgvXuatVien.Location = new Point(13, 333);
            this.dgvXuatVien.MultiSelect = false;
            this.dgvXuatVien.Name = "dgvXuatVien";
            this.dgvXuatVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvXuatVien.Size = new Size(1012, 358);
            this.dgvXuatVien.TabIndex = 3;

            // FormXuatVien
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1038, 704);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormXuatVien";
            this.Text = "Quản lý Xuất viện";

            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuatVien)).EndInit();
            this.ResumeLayout(false);
        }

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private GroupBox groupBox1;
        private ComboBox cbTinhTrang;
        private DateTimePicker dtpNgayXuatVien;
        private TextBox txtMaHoaDon;
        private TextBox txtMaHoSo;
        private TextBox txtMaXuatVien;
        private Label lblTinhTrang;
        private Label lblNgayXuatVien;
        private Label lblMaHoaDon;
        private Label lblMaHoSo;
        private Label lblMaXuatVien;
        private Panel panel1;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private DataGridView dgvXuatVien;
    }
}
