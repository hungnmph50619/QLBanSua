namespace GUI_QLBanSua
{
    partial class FrmSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            txtMaHang = new TextBox();
            txtTenHang = new TextBox();
            txtSoLuong = new TextBox();
            txtDonGiaNhap = new TextBox();
            txtDonGiaBan = new TextBox();
            rtbGhiChu = new TextBox();
            dgvHang = new DataGridView();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 47);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 0;
            label1.Text = "Mã Hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 99);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 1;
            label2.Text = "Tên Hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 144);
            label3.Name = "label3";
            label3.Size = new Size(85, 25);
            label3.TabIndex = 2;
            label3.Text = "Số lượng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 191);
            label4.Name = "label4";
            label4.Size = new Size(124, 25);
            label4.TabIndex = 3;
            label4.Text = "Đơn Giá Nhập";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 234);
            label5.Name = "label5";
            label5.Size = new Size(110, 25);
            label5.TabIndex = 4;
            label5.Text = "Đơn Giá Bán";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(390, 50);
            label7.Name = "label7";
            label7.Size = new Size(71, 25);
            label7.TabIndex = 6;
            label7.Text = "Ghi chú";
            // 
            // txtMaHang
            // 
            txtMaHang.Location = new Point(169, 47);
            txtMaHang.Name = "txtMaHang";
            txtMaHang.Size = new Size(150, 31);
            txtMaHang.TabIndex = 7;
            // 
            // txtTenHang
            // 
            txtTenHang.Location = new Point(169, 99);
            txtTenHang.Name = "txtTenHang";
            txtTenHang.Size = new Size(146, 31);
            txtTenHang.TabIndex = 8;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(169, 144);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(146, 31);
            txtSoLuong.TabIndex = 9;
            // 
            // txtDonGiaNhap
            // 
            txtDonGiaNhap.Location = new Point(168, 185);
            txtDonGiaNhap.Name = "txtDonGiaNhap";
            txtDonGiaNhap.Size = new Size(146, 31);
            txtDonGiaNhap.TabIndex = 10;
            // 
            // txtDonGiaBan
            // 
            txtDonGiaBan.Location = new Point(165, 234);
            txtDonGiaBan.Name = "txtDonGiaBan";
            txtDonGiaBan.Size = new Size(146, 31);
            txtDonGiaBan.TabIndex = 11;
            // 
            // rtbGhiChu
            // 
            rtbGhiChu.Location = new Point(467, 50);
            rtbGhiChu.Multiline = true;
            rtbGhiChu.Name = "rtbGhiChu";
            rtbGhiChu.ScrollBars = ScrollBars.Vertical;
            rtbGhiChu.Size = new Size(389, 103);
            rtbGhiChu.TabIndex = 12;
            // 
            // dgvHang
            // 
            dgvHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHang.Location = new Point(-28, 404);
            dgvHang.MultiSelect = false;
            dgvHang.Name = "dgvHang";
            dgvHang.RowHeadersWidth = 62;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.Size = new Size(1250, 239);
            dgvHang.TabIndex = 14;
            dgvHang.CellContentClick += dgvHang_CellContentClick;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(165, 680);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(150, 31);
            txtTimKiem.TabIndex = 15;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(334, 680);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(112, 34);
            btnTimKiem.TabIndex = 16;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(103, 780);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click_1;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(254, 783);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(107, 31);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(390, 783);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 34);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click_1;
            // 
            // FrmSanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1357, 837);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(dgvHang);
            Controls.Add(rtbGhiChu);
            Controls.Add(txtDonGiaBan);
            Controls.Add(txtDonGiaNhap);
            Controls.Add(txtSoLuong);
            Controls.Add(txtTenHang);
            Controls.Add(txtMaHang);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sản phẩm - QLBH";
            Load += FrmSanPham_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private TextBox txtMaHang;
        private TextBox txtTenHang;
        private TextBox txtSoLuong;
        private TextBox txtDonGiaNhap;
        private TextBox txtDonGiaBan;
        private TextBox rtbGhiChu;
        private DataGridView dgvHang;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
    }
}