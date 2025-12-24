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

     private void InitializeComponent()
        {
     this.tableLayoutPanel1 = new TableLayoutPanel();
this.label1 = new Label();
          this.groupBox1 = new GroupBox();
       this.dtpNgayKe = new DateTimePicker();
      this.txtMaKhamBenh = new TextBox();
     this.txtMaDonThuoc = new TextBox();
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
     this.splitContainer1 = new SplitContainer();
this.dgvDonThuoc = new DataGridView();
        this.panel2 = new Panel();
          this.btnXoaCT = new Button();
   this.btnSuaCT = new Button();
  this.btnThemCT = new Button();
            this.labelChiTiet = new Label();
            this.dgvChiTietDonThuoc = new DataGridView();
       
            this.tableLayoutPanel1.SuspendLayout();
     this.groupBox1.SuspendLayout();
          this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
    this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).BeginInit();
            this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonThuoc)).BeginInit();
      this.SuspendLayout();
            
  // tableLayoutPanel1
         this.tableLayoutPanel1.ColumnCount = 1;
        this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
   this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
     this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 3);
         this.tableLayoutPanel1.Dock = DockStyle.Fill;
    this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.Padding = new Padding(10);
       this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
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
        this.label1.Text = "QUẢN LÝ ĐƠN THUỐC";
    this.label1.TextAlign = ContentAlignment.MiddleCenter;
         
         // groupBox1
            this.groupBox1.Controls.Add(this.dtpNgayKe);
            this.groupBox1.Controls.Add(this.txtMaKhamBenh);
            this.groupBox1.Controls.Add(this.txtMaDonThuoc);
         this.groupBox1.Controls.Add(this.label4);
          this.groupBox1.Controls.Add(this.label3);
    this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
          this.groupBox1.Location = new Point(13, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(1012, 144);
  this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đơn thuốc";
     
     // dtpNgayKe
      this.dtpNgayKe.Format = DateTimePickerFormat.Short;
       this.dtpNgayKe.Location = new Point(150, 100);
  this.dtpNgayKe.Name = "dtpNgayKe";
            this.dtpNgayKe.Size = new Size(320, 25);
          this.dtpNgayKe.TabIndex = 8;
            
        // txtMaKhamBenh
            this.txtMaKhamBenh.Location = new Point(150, 65);
            this.txtMaKhamBenh.Name = "txtMaKhamBenh";
  this.txtMaKhamBenh.Size = new Size(320, 25);
          this.txtMaKhamBenh.TabIndex = 7;
       
      // txtMaDonThuoc
            this.txtMaDonThuoc.Location = new Point(150, 30);
       this.txtMaDonThuoc.Name = "txtMaDonThuoc";
  this.txtMaDonThuoc.ReadOnly = true;
       this.txtMaDonThuoc.Size = new Size(320, 25);
            this.txtMaDonThuoc.TabIndex = 6;
        
        // label4
            this.label4.AutoSize = true;
     this.label4.Location = new Point(30, 103);
            this.label4.Name = "label4";
  this.label4.Size = new Size(70, 17);
            this.label4.TabIndex = 2;
  this.label4.Text = "Ngày kê:";
            
    // label3
  this.label3.AutoSize = true;
            this.label3.Location = new Point(30, 68);
 this.label3.Name = "label3";
this.label3.Size = new Size(118, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã khám bệnh:";
            
            // label2
            this.label2.AutoSize = true;
      this.label2.Location = new Point(30, 33);
       this.label2.Name = "label2";
            this.label2.Size = new Size(107, 17);
      this.label2.TabIndex = 0;
         this.label2.Text = "Mã đơn thuốc:";
     
    // panel1
     this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.btnLamMoi);
            this.panel1.Controls.Add(this.btnXoa);
        this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
  this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(13, 213);
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
            this.btnTimKiem.TabIndex = 8;
  this.btnTimKiem.Text = "Tìm kiếm";
      this.btnTimKiem.UseVisualStyleBackColor = false;
         
            // txtTimKiem
            this.txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.txtTimKiem.Font = new Font("Times New Roman", 11.25F);
  this.txtTimKiem.Location = new Point(674, 13);
 this.txtTimKiem.Name = "txtTimKiem";
   this.txtTimKiem.Size = new Size(220, 25);
            this.txtTimKiem.TabIndex = 7;
            
  // btnLamMoi
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
    
    // btnXoa
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
            
      // btnSua
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
       
        // btnThem
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
            
// splitContainer1
   this.splitContainer1.Dock = DockStyle.Fill;
     this.splitContainer1.Location = new Point(13, 273);
   this.splitContainer1.Name = "splitContainer1";
  this.splitContainer1.Orientation = Orientation.Horizontal;
   
    // splitContainer1.Panel1
 this.splitContainer1.Panel1.Controls.Add(this.dgvDonThuoc);
          
            // splitContainer1.Panel2
  this.splitContainer1.Panel2.Controls.Add(this.dgvChiTietDonThuoc);
   this.splitContainer1.Panel2.Controls.Add(this.panel2);
       this.splitContainer1.Size = new Size(1012, 418);
            this.splitContainer1.SplitterDistance = 180;
    this.splitContainer1.TabIndex = 3;
  
          // dgvDonThuoc
          this.dgvDonThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
  this.dgvDonThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
   this.dgvDonThuoc.Dock = DockStyle.Fill;
            this.dgvDonThuoc.Location = new Point(0, 0);
   this.dgvDonThuoc.Name = "dgvDonThuoc";
            this.dgvDonThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgvDonThuoc.Size = new Size(1012, 180);
          this.dgvDonThuoc.TabIndex = 0;
   
 // panel2
            this.panel2.Controls.Add(this.btnXoaCT);
        this.panel2.Controls.Add(this.btnSuaCT);
            this.panel2.Controls.Add(this.btnThemCT);
            this.panel2.Controls.Add(this.labelChiTiet);
   this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0);
      this.panel2.Name = "panel2";
    this.panel2.Size = new Size(1012, 50);
     this.panel2.TabIndex = 0;
    
  // btnXoaCT
            this.btnXoaCT.BackColor = Color.FromArgb(231, 76, 60);
  this.btnXoaCT.FlatStyle = FlatStyle.Flat;
   this.btnXoaCT.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
        this.btnXoaCT.ForeColor = Color.White;
            this.btnXoaCT.Location = new Point(320, 5);
       this.btnXoaCT.Name = "btnXoaCT";
     this.btnXoaCT.Size = new Size(100, 40);
          this.btnXoaCT.TabIndex = 3;
          this.btnXoaCT.Text = "Xóa CT";
        this.btnXoaCT.UseVisualStyleBackColor = false;
            
    // btnSuaCT
        this.btnSuaCT.BackColor = Color.FromArgb(52, 152, 219);
    this.btnSuaCT.FlatStyle = FlatStyle.Flat;
          this.btnSuaCT.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            this.btnSuaCT.ForeColor = Color.White;
          this.btnSuaCT.Location = new Point(210, 5);
  this.btnSuaCT.Name = "btnSuaCT";
    this.btnSuaCT.Size = new Size(100, 40);
          this.btnSuaCT.TabIndex = 2;
        this.btnSuaCT.Text = "Sửa CT";
    this.btnSuaCT.UseVisualStyleBackColor = false;
   this.btnSuaCT.Click += new System.EventHandler(this.btnSuaCT_Click);
     
   // btnThemCT
      this.btnThemCT.BackColor = Color.FromArgb(46, 204, 113);
         this.btnThemCT.FlatStyle = FlatStyle.Flat;
       this.btnThemCT.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
         this.btnThemCT.ForeColor = Color.White;
  this.btnThemCT.Location = new Point(100, 5);
    this.btnThemCT.Name = "btnThemCT";
            this.btnThemCT.Size = new Size(100, 40);
            this.btnThemCT.TabIndex = 1;
 this.btnThemCT.Text = "Thêm CT";
        this.btnThemCT.UseVisualStyleBackColor = false;
         this.btnThemCT.Click += new System.EventHandler(this.btnThemCT_Click);
            
   // labelChiTiet
            this.labelChiTiet.AutoSize = true;
            this.labelChiTiet.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
this.labelChiTiet.Location = new Point(5, 15);
            this.labelChiTiet.Name = "labelChiTiet";
          this.labelChiTiet.Size = new Size(88, 19);
         this.labelChiTiet.TabIndex = 0;
     this.labelChiTiet.Text = "Chi tiết:";
      
    // dgvChiTietDonThuoc
       this.dgvChiTietDonThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietDonThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
       this.dgvChiTietDonThuoc.Dock = DockStyle.Fill;
         this.dgvChiTietDonThuoc.Location = new Point(0, 50);
            this.dgvChiTietDonThuoc.Name = "dgvChiTietDonThuoc";
      this.dgvChiTietDonThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
  this.dgvChiTietDonThuoc.Size = new Size(1012, 184);
    this.dgvChiTietDonThuoc.TabIndex = 1;
  
     // FormDonThuoc
 this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
this.BackColor = Color.White;
          this.ClientSize = new Size(1038, 704);
        this.Controls.Add(this.tableLayoutPanel1);
   this.Name = "FormDonThuoc";
         this.Text = "Quản lý đơn thuốc";
   
            this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
       this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
   this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
     this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonThuoc)).EndInit();
       this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDonThuoc)).EndInit();
       this.ResumeLayout(false);
 }

        private TableLayoutPanel tableLayoutPanel1;
      private Label label1;
        private GroupBox groupBox1;
        private DateTimePicker dtpNgayKe;
   private TextBox txtMaKhamBenh;
        private TextBox txtMaDonThuoc;
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
        private SplitContainer splitContainer1;
        private DataGridView dgvDonThuoc;
        private Panel panel2;
        private Button btnXoaCT;
        private Button btnSuaCT;
   private Button btnThemCT;
    private Label labelChiTiet;
        private DataGridView dgvChiTietDonThuoc;
    }
}
