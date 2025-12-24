using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem.UI
{
    partial class FormGiuong
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

        private void InitializeComponent()
        {
     this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label1 = new Label();
            this.groupBox1 = new GroupBox();
     this.cboTrangThai = new ComboBox();
            this.txtMaPhong = new TextBox();
this.txtMaBacSi = new TextBox();
     this.txtMaGiuong = new TextBox();
 this.label5 = new Label();
     this.label4 = new Label();
        this.label3 = new Label();
    this.label2 = new Label();
       this.panel1 = new Panel();
   this.btnTimKiem = new Button();
 this.txtTimKiem = new TextBox();
            this.btnLamMoi = new Button();
          this.btnXoa = new Button();
    this.btnSua = new Button();
 this.btnThem = new Button();
            this.dataGridView1 = new DataGridView();
          this.tableLayoutPanel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
 this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
   this.SuspendLayout();
         // 
    // tableLayoutPanel1
            // 
       this.tableLayoutPanel1.ColumnCount = 1;
    this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
     this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
     this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
 this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 3);
  this.tableLayoutPanel1.Dock = DockStyle.Fill;
        this.tableLayoutPanel1.Location = new Point(0, 0);
       this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new Padding(10);
        this.tableLayoutPanel1.RowCount = 4;
         this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
  this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
 this.tableLayoutPanel1.Size = new Size(1038, 604);
 this.tableLayoutPanel1.TabIndex = 0;
            // 
        // label1
            // 
            this.label1.AutoSize = true;
      this.label1.Dock = DockStyle.Fill;
    this.label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
 this.label1.Location = new Point(13, 10);
       this.label1.Name = "label1";
        this.label1.Size = new Size(1012, 50);
     this.label1.TabIndex = 0;
  this.label1.Text = "QUẢN LÝ GIƯỜNG";
        this.label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
// groupBox1
 // 
            this.groupBox1.Controls.Add(this.cboTrangThai);
        this.groupBox1.Controls.Add(this.txtMaPhong);
    this.groupBox1.Controls.Add(this.txtMaBacSi);
            this.groupBox1.Controls.Add(this.txtMaGiuong);
     this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
 this.groupBox1.Controls.Add(this.label2);
       this.groupBox1.Dock = DockStyle.Fill;
     this.groupBox1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
     this.groupBox1.Location = new Point(13, 63);
      this.groupBox1.Name = "groupBox1";
this.groupBox1.Size = new Size(1012, 164);
       this.groupBox1.TabIndex = 1;
this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Thông tin giường";
  // 
            // cboTrangThai
// 
  this.cboTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
this.cboTrangThai.FormattingEnabled = true;
      this.cboTrangThai.Items.AddRange(new object[] {
            "Trống",
       "Đầy"});
    this.cboTrangThai.Location = new Point(625, 65);
   this.cboTrangThai.Name = "cboTrangThai";
       this.cboTrangThai.Size = new Size(370, 25);
 this.cboTrangThai.TabIndex = 10;
       // 
      // txtMaPhong
  // 
 this.txtMaPhong.Location = new Point(150, 100);
            this.txtMaPhong.Name = "txtMaPhong";
      this.txtMaPhong.Size = new Size(320, 25);
      this.txtMaPhong.TabIndex = 9;
            // 
            // txtMaBacSi
    // 
      this.txtMaBacSi.Location = new Point(150, 65);
  this.txtMaBacSi.Name = "txtMaBacSi";
       this.txtMaBacSi.Size = new Size(320, 25);
       this.txtMaBacSi.TabIndex = 8;
            // 
      // txtMaGiuong
      // 
       this.txtMaGiuong.Location = new Point(150, 30);
 this.txtMaGiuong.Name = "txtMaGiuong";
       this.txtMaGiuong.ReadOnly = true;
            this.txtMaGiuong.Size = new Size(320, 25);
        this.txtMaGiuong.TabIndex = 7;
      // 
        // label5
     // 
     this.label5.AutoSize = true;
            this.label5.Location = new Point(520, 68);
this.label5.Name = "label5";
this.label5.Size = new Size(82, 17);
  this.label5.TabIndex = 3;
      this.label5.Text = "Trạng thái:";
     // 
     // label4
       // 
   this.label4.AutoSize = true;
this.label4.Location = new Point(30, 103);
            this.label4.Name = "label4";
 this.label4.Size = new Size(83, 17);
       this.label4.TabIndex = 2;
this.label4.Text = "Mã phòng:";
     // 
        // label3
   // 
  this.label3.AutoSize = true;
    this.label3.Location = new Point(30, 68);
            this.label3.Name = "label3";
   this.label3.Size = new Size(71, 17);
    this.label3.TabIndex = 1;
            this.label3.Text = "Mã bác sĩ:";
            // 
   // label2
            // 
       this.label2.AutoSize = true;
this.label2.Location = new Point(30, 33);
            this.label2.Name = "label2";
  this.label2.Size = new Size(85, 17);
       this.label2.TabIndex = 0;
       this.label2.Text = "Mã giường:";
            // 
          // panel1
         // 
this.panel1.Controls.Add(this.btnTimKiem);
       this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.btnLamMoi);
       this.panel1.Controls.Add(this.btnXoa);
       this.panel1.Controls.Add(this.btnSua);
      this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = DockStyle.Fill;
       this.panel1.Location = new Point(13, 233);
            this.panel1.Name = "panel1";
     this.panel1.Size = new Size(1012, 54);
       this.panel1.TabIndex = 2;
            // 
            // btnTimKiem
   // 
  this.btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.btnTimKiem.BackColor = Color.FromArgb(52, 73, 94);
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
       this.btnTimKiem.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.btnTimKiem.ForeColor = Color.White;
   this.btnTimKiem.Location = new Point(909, 5);
        this.btnTimKiem.Name = "btnTimKiem";
this.btnTimKiem.Size = new Size(100, 40);
       this.btnTimKiem.TabIndex = 8;
   this.btnTimKiem.Text = "Tìm kiếm";
this.btnTimKiem.UseVisualStyleBackColor = false;
  // 
  // txtTimKiem
     // 
        this.txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
     this.txtTimKiem.Font = new Font("Times New Roman", 11.25F);
            this.txtTimKiem.Location = new Point(674, 13);
  this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new Size(220, 25);
  this.txtTimKiem.TabIndex = 7;
// 
         // btnLamMoi
   // 
          this.btnLamMoi.BackColor = Color.FromArgb(149, 165, 166);
      this.btnLamMoi.FlatStyle = FlatStyle.Flat;
   this.btnLamMoi.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
this.btnLamMoi.ForeColor = Color.White;
this.btnLamMoi.Location = new Point(330, 5);
       this.btnLamMoi.Name = "btnLamMoi";
 this.btnLamMoi.Size = new Size(100, 40);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
     this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
       // btnXoa
            // 
       this.btnXoa.BackColor = Color.FromArgb(231, 76, 60);
       this.btnXoa.FlatStyle = FlatStyle.Flat;
this.btnXoa.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
    this.btnXoa.ForeColor = Color.White;
          this.btnXoa.Location = new Point(220, 5);
            this.btnXoa.Name = "btnXoa";
this.btnXoa.Size = new Size(100, 40);
          this.btnXoa.TabIndex = 5;
       this.btnXoa.Text = "Xóa";
     this.btnXoa.UseVisualStyleBackColor = false;
    // 
 // btnSua
          // 
       this.btnSua.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSua.FlatStyle = FlatStyle.Flat;
          this.btnSua.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
      this.btnSua.ForeColor = Color.White;
       this.btnSua.Location = new Point(110, 5);
this.btnSua.Name = "btnSua";
      this.btnSua.Size = new Size(100, 40);
  this.btnSua.TabIndex = 4;
       this.btnSua.Text = "Sửa";
      this.btnSua.UseVisualStyleBackColor = false;
       // 
  // btnThem
        // 
       this.btnThem.BackColor = Color.FromArgb(46, 204, 113);
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
  this.btnThem.ForeColor = Color.White;
            this.btnThem.Location = new Point(0, 5);
         this.btnThem.Name = "btnThem";
       this.btnThem.Size = new Size(100, 40);
     this.btnThem.TabIndex = 3;
this.btnThem.Text = "Thêm";
this.btnThem.UseVisualStyleBackColor = false;
            // 
       // dataGridView1
// 
         this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
       this.dataGridView1.Dock = DockStyle.Fill;
      this.dataGridView1.Location = new Point(13, 293);
            this.dataGridView1.Name = "dataGridView1";
this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
this.dataGridView1.Size = new Size(1012, 298);
          this.dataGridView1.TabIndex = 3;
            // 
            // FormGiuong
      // 
this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
     this.ClientSize = new Size(1038, 604);
            this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "FormGiuong";
   this.Text = "Quản lý giường";
            this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
   this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
  this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
       ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
     }

        private TableLayoutPanel tableLayoutPanel1;
      private Label label1;
        private GroupBox groupBox1;
  private ComboBox cboTrangThai;
        private TextBox txtMaPhong;
        private TextBox txtMaBacSi;
    private TextBox txtMaGiuong;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel1;
 private Button btnTimKiem;
        private TextBox txtTimKiem;
  private Button btnLamMoi;
  private Button btnXoa;
        private Button btnSua;
  private Button btnThem;
        private DataGridView dataGridView1;
    }
}