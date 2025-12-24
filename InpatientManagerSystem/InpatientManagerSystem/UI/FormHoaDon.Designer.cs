using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem.UI
{
    partial class FormHoadon
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
    this.btnXoaHD = new Button();
    this.btnSuaHD = new Button();
         this.btnThemHD = new Button();
            this.lblDSHoaDon = new Label();
 this.panel2 = new Panel();
            this.btnXoaCT = new Button();
            this.btnSuaCT = new Button();
            this.btnThemCT = new Button();
       this.lblDSChiTiet = new Label();
 this.dgvChiTiet = new DataGridView();
        this.panel3 = new Panel();
         this.lblDaThanhToan = new Label();
            this.lblTongTien = new Label();

            this.tableLayoutPanel1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
   this.splitContainer1.Panel1.SuspendLayout();
    this.splitContainer1.Panel2.SuspendLayout();
       this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
       this.panel1.SuspendLayout();
   this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
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
   this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
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
            this.label1.Text = "QUẢN LÝ HÓA ĐƠN";
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
    this.splitContainer1.Panel2.Controls.Add(this.dgvChiTiet);
      this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new Size(1012, 568);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 1;

        // dgvHoaDon
            this.dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
   this.dgvHoaDon.Dock = DockStyle.Fill;
            this.dgvHoaDon.Location = new Point(0, 50);
            this.dgvHoaDon.MultiSelect = false;
      this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
   this.dgvHoaDon.Size = new Size(1012, 200);
      this.dgvHoaDon.TabIndex = 0;

            // panel1
            this.panel1.Controls.Add(this.btnXoaHD);
            this.panel1.Controls.Add(this.btnSuaHD);
        this.panel1.Controls.Add(this.btnThemHD);
        this.panel1.Controls.Add(this.lblDSHoaDon);
 this.panel1.Dock = DockStyle.Top;
         this.panel1.Location = new Point(0, 0);
      this.panel1.Name = "panel1";
            this.panel1.Size = new Size(1012, 50);
 this.panel1.TabIndex = 1;

            // btnXoaHD
            this.btnXoaHD.BackColor = Color.FromArgb(231, 76, 60);
            this.btnXoaHD.FlatStyle = FlatStyle.Flat;
            this.btnXoaHD.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
    this.btnXoaHD.ForeColor = Color.White;
            this.btnXoaHD.Location = new Point(320, 5);
       this.btnXoaHD.Name = "btnXoaHD";
    this.btnXoaHD.Size = new Size(100, 40);
   this.btnXoaHD.TabIndex = 3;
            this.btnXoaHD.Text = "Xóa HĐ";
          this.btnXoaHD.UseVisualStyleBackColor = false;

            // btnSuaHD
            this.btnSuaHD.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSuaHD.FlatStyle = FlatStyle.Flat;
   this.btnSuaHD.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
          this.btnSuaHD.ForeColor = Color.White;
          this.btnSuaHD.Location = new Point(210, 5);
      this.btnSuaHD.Name = "btnSuaHD";
  this.btnSuaHD.Size = new Size(100, 40);
     this.btnSuaHD.TabIndex = 2;
    this.btnSuaHD.Text = "Sửa HĐ";
            this.btnSuaHD.UseVisualStyleBackColor = false;

   // btnThemHD
         this.btnThemHD.BackColor = Color.FromArgb(46, 204, 113);
this.btnThemHD.FlatStyle = FlatStyle.Flat;
            this.btnThemHD.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
    this.btnThemHD.ForeColor = Color.White;
this.btnThemHD.Location = new Point(100, 5);
        this.btnThemHD.Name = "btnThemHD";
            this.btnThemHD.Size = new Size(100, 40);
            this.btnThemHD.TabIndex = 1;
   this.btnThemHD.Text = "Thêm HĐ";
            this.btnThemHD.UseVisualStyleBackColor = false;

            // lblDSHoaDon
          this.lblDSHoaDon.AutoSize = true;
   this.lblDSHoaDon.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
       this.lblDSHoaDon.Location = new Point(5, 15);
        this.lblDSHoaDon.Name = "lblDSHoaDon";
       this.lblDSHoaDon.Size = new Size(82, 19);
this.lblDSHoaDon.TabIndex = 0;
      this.lblDSHoaDon.Text = "Hóa đơn:";

         // panel2
       this.panel2.Controls.Add(this.btnXoaCT);
        this.panel2.Controls.Add(this.btnSuaCT);
            this.panel2.Controls.Add(this.btnThemCT);
   this.panel2.Controls.Add(this.lblDSChiTiet);
            this.panel2.Dock = DockStyle.Top;
     this.panel2.Location = new Point(0, 0);
    this.panel2.Name = "panel2";
    this.panel2.Size = new Size(1012, 50);
            this.panel2.TabIndex = 1;

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

            // lblDSChiTiet
      this.lblDSChiTiet.AutoSize = true;
            this.lblDSChiTiet.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            this.lblDSChiTiet.Location = new Point(5, 15);
         this.lblDSChiTiet.Name = "lblDSChiTiet";
            this.lblDSChiTiet.Size = new Size(67, 19);
     this.lblDSChiTiet.TabIndex = 0;
     this.lblDSChiTiet.Text = "Chi tiết:";

 // dgvChiTiet
 this.dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
     this.dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Dock = DockStyle.Fill;
   this.dgvChiTiet.Location = new Point(0, 50);
  this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new Size(1012, 264);
   this.dgvChiTiet.TabIndex = 0;

  // panel3
 this.panel3.Controls.Add(this.lblDaThanhToan);
       this.panel3.Controls.Add(this.lblTongTien);
     this.panel3.Dock = DockStyle.Fill;
         this.panel3.Location = new Point(13, 637);
  this.panel3.Name = "panel3";
       this.panel3.Size = new Size(1012, 54);
 this.panel3.TabIndex = 2;

   // lblDaThanhToan
    this.lblDaThanhToan.AutoSize = true;
      this.lblDaThanhToan.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
       this.lblDaThanhToan.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblDaThanhToan.Location = new Point(250, 17);
            this.lblDaThanhToan.Name = "lblDaThanhToan";
      this.lblDaThanhToan.Size = new Size(146, 19);
      this.lblDaThanhToan.TabIndex = 1;
    this.lblDaThanhToan.Text = "Đã Thanh Toán: 0đ";

          // lblTongTien
  this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
      this.lblTongTien.ForeColor = Color.FromArgb(192, 57, 43);
     this.lblTongTien.Location = new Point(5, 17);
         this.lblTongTien.Name = "lblTongTien";
          this.lblTongTien.Size = new Size(100, 19);
            this.lblTongTien.TabIndex = 0;
         this.lblTongTien.Text = "Tổng Tiền: 0đ";

            // FormHoadon
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
   this.ClientSize = new Size(1038, 704);
       this.Controls.Add(this.tableLayoutPanel1);
        this.Name = "FormHoadon";
            this.Text = "Quản lý Hóa Đơn";

         this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panel1.ResumeLayout(false);
   this.panel1.PerformLayout();
     this.panel2.ResumeLayout(false);
     this.panel2.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.panel3.ResumeLayout(false);
   this.panel3.PerformLayout();
      this.ResumeLayout(false);
        }

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private SplitContainer splitContainer1;
        private DataGridView dgvHoaDon;
      private Panel panel1;
    private Button btnXoaHD;
        private Button btnSuaHD;
        private Button btnThemHD;
    private Label lblDSHoaDon;
     private Panel panel2;
        private Button btnXoaCT;
     private Button btnSuaCT;
  private Button btnThemCT;
        private Label lblDSChiTiet;
        private DataGridView dgvChiTiet;
        private Panel panel3;
        private Label lblDaThanhToan;
        private Label lblTongTien;
    }
}
