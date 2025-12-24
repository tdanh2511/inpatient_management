using System.Drawing;
using System.Windows.Forms;

namespace InpatientManagerSystem
{
    partial class FormThanhToan
    {
        private DataGridView dgvHoaDon;
        private DataGridView dgvChiTiet;
        private Button btnThem, btnSua, btnXoa;
        private Label lblMaHoaDon, lblNgayTao, lblTinhTrang, lblTongTien, lblDaThanhToan;
        private TextBox txtSoTien, txtGhiChu;
        private ComboBox cbPhuongThuc;
        private Label lblSoTien, lblPhuongThuc, lblGhiChu;
        private Label lblDSHoaDon, lblDSChiTiet;

        private void InitializeComponent()
        {
            this.dgvHoaDon = new DataGridView();
            this.dgvChiTiet = new DataGridView();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnXoa = new Button();
            this.lblMaHoaDon = new Label();
            this.lblNgayTao = new Label();
            this.lblTinhTrang = new Label();
            this.lblTongTien = new Label();
            this.lblDaThanhToan = new Label();
            this.txtSoTien = new TextBox();
            this.txtGhiChu = new TextBox();
            this.cbPhuongThuc = new ComboBox();
            this.lblSoTien = new Label();
            this.lblPhuongThuc = new Label();
            this.lblGhiChu = new Label();
            this.lblDSHoaDon = new Label();
            this.lblDSChiTiet = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();

            // dgvHoaDon
            this.dgvHoaDon.Location = new Point(12, 20);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new Size(700, 150);
            this.dgvHoaDon.TabIndex = 2;

            // dgvChiTiet
            this.dgvChiTiet.Location = new Point(12, 212);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new Size(700, 200);
            this.dgvChiTiet.TabIndex = 3;

            // btnThem
            this.btnThem.BackColor = Color.FromArgb(46, 204, 113);
            this.btnThem.ForeColor = Color.White;
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.Location = new Point(730, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;

            // btnSua
            this.btnSua.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSua.ForeColor = Color.White;
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.FlatAppearance.BorderSize = 0;
            this.btnSua.Location = new Point(730, 70);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new Size(75, 23);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;

            // btnXoa
            this.btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            this.btnXoa.ForeColor = Color.White;
            this.btnXoa.FlatStyle = FlatStyle.Flat;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.Location = new Point(730, 110);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new Size(75, 23);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;

            // Labels Hóa đơn
            this.lblDSHoaDon.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            this.lblDSHoaDon.Location = new Point(12, -2);
            this.lblDSHoaDon.Name = "lblDSHoaDon";
            this.lblDSHoaDon.Size = new Size(200, 20);
            this.lblDSHoaDon.TabIndex = 0;
            this.lblDSHoaDon.Text = "Danh sách Hóa đơn";

            this.lblDSChiTiet.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            this.lblDSChiTiet.Location = new Point(12, 183);
            this.lblDSChiTiet.Name = "lblDSChiTiet";
            this.lblDSChiTiet.Size = new Size(200, 20);
            this.lblDSChiTiet.TabIndex = 1;
            this.lblDSChiTiet.Text = "Chi tiết Thanh toán";

            this.lblMaHoaDon.Location = new Point(12, 433);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new Size(200, 25);
            this.lblMaHoaDon.TabIndex = 7;
            this.lblMaHoaDon.Text = "Mã HĐ: ";

            this.lblNgayTao.Location = new Point(220, 433);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new Size(200, 25);
            this.lblNgayTao.TabIndex = 8;
            this.lblNgayTao.Text = "Ngày tạo: ";

            this.lblTinhTrang.Location = new Point(426, 433);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new Size(200, 25);
            this.lblTinhTrang.TabIndex = 9;
            this.lblTinhTrang.Text = "Tình trạng: ";

            this.lblTongTien.Location = new Point(9, 458);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new Size(200, 25);
            this.lblTongTien.TabIndex = 10;
            this.lblTongTien.Text = "Tổng tiền: 0";

            this.lblDaThanhToan.Location = new Point(220, 458);
            this.lblDaThanhToan.Name = "lblDaThanhToan";
            this.lblDaThanhToan.Size = new Size(200, 25);
            this.lblDaThanhToan.TabIndex = 11;
            this.lblDaThanhToan.Text = "Đã thanh toán: 0";

            // TextBox & ComboBox
            this.txtSoTien.Location = new Point(730, 235);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new Size(180, 20);
            this.txtSoTien.TabIndex = 13;

            this.cbPhuongThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản" });
            this.cbPhuongThuc.Location = new Point(730, 293);
            this.cbPhuongThuc.Name = "cbPhuongThuc";
            this.cbPhuongThuc.Size = new Size(180, 21);
            this.cbPhuongThuc.TabIndex = 15;

            this.txtGhiChu.Location = new Point(730, 352);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new Size(180, 60);
            this.txtGhiChu.TabIndex = 17;

            // Labels cho input
            this.lblSoTien.Location = new Point(730, 209);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new Size(100, 23);
            this.lblSoTien.TabIndex = 12;
            this.lblSoTien.Text = "Số tiền:";

            this.lblPhuongThuc.Location = new Point(730, 267);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new Size(100, 23);
            this.lblPhuongThuc.TabIndex = 14;
            this.lblPhuongThuc.Text = "Phương thức:";

            this.lblGhiChu.Location = new Point(730, 326);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new Size(100, 23);
            this.lblGhiChu.TabIndex = 16;
            this.lblGhiChu.Text = "Ghi chú:";

            // FormThanhToan
            this.ClientSize = new Size(950, 492);
            this.Controls.Add(this.lblDSHoaDon);
            this.Controls.Add(this.lblDSChiTiet);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lblMaHoaDon);
            this.Controls.Add(this.lblNgayTao);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblDaThanhToan);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.lblPhuongThuc);
            this.Controls.Add(this.cbPhuongThuc);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtGhiChu);

            this.Name = "FormThanhToan";
            this.Text = "Quản lý Thanh Toán";

            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
