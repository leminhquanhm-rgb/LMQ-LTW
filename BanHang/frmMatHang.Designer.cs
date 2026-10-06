namespace BanHang
{
    partial class frmMatHang
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTieuDe = new Panel();
            lblTieuDe = new Label();
            pnlChucNang = new Panel();
            btnThoat = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            btnTimKiem = new Button();
            grbChiTiet = new GroupBox();
            btnHuy = new Button();
            btnLuu = new Button();
            dtpNgayHH = new DateTimePicker();
            dtpNgaySX = new DateTimePicker();
            txtGhiChu = new TextBox();
            txtDonGia = new TextBox();
            txtDonVi = new TextBox();
            txtTenSP = new TextBox();
            txtMaSP = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            grbTimKiem = new GroupBox();
            txtTKTenSP = new TextBox();
            txtTKMaSP = new TextBox();
            label9 = new Label();
            label8 = new Label();
            grbKetQua = new GroupBox();
            dgvMatHang = new DataGridView();
            pnlTieuDe.SuspendLayout();
            pnlChucNang.SuspendLayout();
            grbChiTiet.SuspendLayout();
            grbTimKiem.SuspendLayout();
            grbKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMatHang).BeginInit();
            SuspendLayout();
            // 
            // pnlTieuDe
            // 
            pnlTieuDe.Controls.Add(lblTieuDe);
            pnlTieuDe.Dock = DockStyle.Top;
            pnlTieuDe.Location = new Point(0, 0);
            pnlTieuDe.Name = "pnlTieuDe";
            pnlTieuDe.Size = new Size(1367, 79);
            pnlTieuDe.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Location = new Point(569, 21);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(254, 25);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ MẶT HÀNG";
            // 
            // pnlChucNang
            // 
            pnlChucNang.Controls.Add(btnThoat);
            pnlChucNang.Controls.Add(btnXoa);
            pnlChucNang.Controls.Add(btnSua);
            pnlChucNang.Controls.Add(btnThem);
            pnlChucNang.Controls.Add(btnTimKiem);
            pnlChucNang.Dock = DockStyle.Bottom;
            pnlChucNang.Location = new Point(0, 559);
            pnlChucNang.Name = "pnlChucNang";
            pnlChucNang.Size = new Size(1367, 112);
            pnlChucNang.TabIndex = 1;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(1055, 32);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 47);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Th&oát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(851, 32);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(95, 47);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(641, 32);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 47);
            btnSua.TabIndex = 2;
            btnSua.Text = "&Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(416, 32);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 47);
            btnThem.TabIndex = 1;
            btnThem.Text = "T&hêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(206, 32);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(95, 47);
            btnTimKiem.TabIndex = 0;
            btnTimKiem.Text = "&Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // grbChiTiet
            // 
            grbChiTiet.Controls.Add(btnHuy);
            grbChiTiet.Controls.Add(btnLuu);
            grbChiTiet.Controls.Add(dtpNgayHH);
            grbChiTiet.Controls.Add(dtpNgaySX);
            grbChiTiet.Controls.Add(txtGhiChu);
            grbChiTiet.Controls.Add(txtDonGia);
            grbChiTiet.Controls.Add(txtDonVi);
            grbChiTiet.Controls.Add(txtTenSP);
            grbChiTiet.Controls.Add(txtMaSP);
            grbChiTiet.Controls.Add(label7);
            grbChiTiet.Controls.Add(label6);
            grbChiTiet.Controls.Add(label5);
            grbChiTiet.Controls.Add(label4);
            grbChiTiet.Controls.Add(label3);
            grbChiTiet.Controls.Add(label2);
            grbChiTiet.Controls.Add(label1);
            grbChiTiet.Dock = DockStyle.Right;
            grbChiTiet.Location = new Point(946, 79);
            grbChiTiet.Name = "grbChiTiet";
            grbChiTiet.Size = new Size(421, 480);
            grbChiTiet.TabIndex = 2;
            grbChiTiet.TabStop = false;
            grbChiTiet.Text = "Chi tiết";
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(267, 418);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(89, 40);
            btnHuy.TabIndex = 15;
            btnHuy.Text = "&Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(109, 418);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(89, 40);
            btnLuu.TabIndex = 14;
            btnLuu.Text = "&Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // dtpNgayHH
            // 
            dtpNgayHH.Format = DateTimePickerFormat.Short;
            dtpNgayHH.Location = new Point(144, 171);
            dtpNgayHH.Name = "dtpNgayHH";
            dtpNgayHH.Size = new Size(123, 27);
            dtpNgayHH.TabIndex = 13;
            // 
            // dtpNgaySX
            // 
            dtpNgaySX.Format = DateTimePickerFormat.Short;
            dtpNgaySX.Location = new Point(144, 118);
            dtpNgaySX.Name = "dtpNgaySX";
            dtpNgaySX.Size = new Size(123, 27);
            dtpNgaySX.TabIndex = 12;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(144, 330);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(224, 27);
            txtGhiChu.TabIndex = 11;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(144, 279);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(224, 27);
            txtDonGia.TabIndex = 10;
            txtDonGia.KeyPress += txtDonGia_KeyPress;
            // 
            // txtDonVi
            // 
            txtDonVi.Location = new Point(144, 229);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.Size = new Size(224, 27);
            txtDonVi.TabIndex = 9;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(144, 70);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(224, 27);
            txtTenSP.TabIndex = 8;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(144, 30);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(224, 27);
            txtMaSP.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(44, 337);
            label7.Name = "label7";
            label7.Size = new Size(61, 20);
            label7.TabIndex = 6;
            label7.Text = "Ghi chú:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(44, 282);
            label6.Name = "label6";
            label6.Size = new Size(65, 20);
            label6.TabIndex = 5;
            label6.Text = "Đơn giá:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 232);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 4;
            label5.Text = "Đơn vị:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 176);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày HH:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 125);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 2;
            label3.Text = "Ngày SX:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 77);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên SP:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 33);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã SP:";
            // 
            // grbTimKiem
            // 
            grbTimKiem.Controls.Add(txtTKTenSP);
            grbTimKiem.Controls.Add(txtTKMaSP);
            grbTimKiem.Controls.Add(label9);
            grbTimKiem.Controls.Add(label8);
            grbTimKiem.Dock = DockStyle.Top;
            grbTimKiem.Location = new Point(0, 79);
            grbTimKiem.Name = "grbTimKiem";
            grbTimKiem.Size = new Size(946, 125);
            grbTimKiem.TabIndex = 3;
            grbTimKiem.TabStop = false;
            grbTimKiem.Text = "Tìm kiếm";
            // 
            // txtTKTenSP
            // 
            txtTKTenSP.Location = new Point(641, 52);
            txtTKTenSP.Name = "txtTKTenSP";
            txtTKTenSP.Size = new Size(271, 27);
            txtTKTenSP.TabIndex = 3;
            // 
            // txtTKMaSP
            // 
            txtTKMaSP.Location = new Point(106, 52);
            txtTKMaSP.Name = "txtTKMaSP";
            txtTKMaSP.Size = new Size(269, 27);
            txtTKMaSP.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(580, 55);
            label9.Name = "label9";
            label9.Size = new Size(55, 20);
            label9.TabIndex = 1;
            label9.Text = "Tên SP:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(47, 55);
            label8.Name = "label8";
            label8.Size = new Size(53, 20);
            label8.TabIndex = 0;
            label8.Text = "Mã SP:";
            // 
            // grbKetQua
            // 
            grbKetQua.Controls.Add(dgvMatHang);
            grbKetQua.Dock = DockStyle.Fill;
            grbKetQua.Location = new Point(0, 204);
            grbKetQua.Name = "grbKetQua";
            grbKetQua.Size = new Size(946, 355);
            grbKetQua.TabIndex = 4;
            grbKetQua.TabStop = false;
            grbKetQua.Text = "Kết quả";
            // 
            // dgvMatHang
            // 
            dgvMatHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMatHang.Dock = DockStyle.Fill;
            dgvMatHang.Location = new Point(3, 23);
            dgvMatHang.Name = "dgvMatHang";
            dgvMatHang.RowHeadersWidth = 51;
            dgvMatHang.Size = new Size(940, 329);
            dgvMatHang.TabIndex = 0;
            dgvMatHang.CellClick += dgvMatHang_CellClick;
            // 
            // frmMatHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1367, 671);
            Controls.Add(grbKetQua);
            Controls.Add(grbTimKiem);
            Controls.Add(grbChiTiet);
            Controls.Add(pnlChucNang);
            Controls.Add(pnlTieuDe);
            Name = "frmMatHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "  ";
            Load += frmMatHang_Load;
            pnlTieuDe.ResumeLayout(false);
            pnlTieuDe.PerformLayout();
            pnlChucNang.ResumeLayout(false);
            grbChiTiet.ResumeLayout(false);
            grbChiTiet.PerformLayout();
            grbTimKiem.ResumeLayout(false);
            grbTimKiem.PerformLayout();
            grbKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMatHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTieuDe;
        private Label lblTieuDe;
        private Panel pnlChucNang;
        private Button btnThoat;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnTimKiem;
        private GroupBox grbChiTiet;
        private TextBox txtGhiChu;
        private TextBox txtDonGia;
        private TextBox txtDonVi;
        private TextBox txtTenSP;
        private TextBox txtMaSP;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpNgaySX;
        private DateTimePicker dtpNgayHH;
        private Button btnHuy;
        private Button btnLuu;
        private GroupBox grbTimKiem;
        private TextBox txtTKTenSP;
        private TextBox txtTKMaSP;
        private Label label9;
        private Label label8;
        private GroupBox grbKetQua;
        private DataGridView dgvMatHang;
    }
}
