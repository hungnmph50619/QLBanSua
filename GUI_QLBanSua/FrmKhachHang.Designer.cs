namespace GUI_QLBanSua
{
    partial class FrmKhachHang
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
            grpGioiTinh = new GroupBox();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            dgvKhachHang = new DataGridView();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            txtDienThoai = new TextBox();
            txtHoTen = new TextBox();
            txtDiaChi = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            grpGioiTinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 54);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 0;
            label1.Text = "Điện thoại";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 110);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 1;
            label2.Text = "Họ và tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(411, 51);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 2;
            label3.Text = "Địa chỉ";
            // 
            // grpGioiTinh
            // 
            grpGioiTinh.Controls.Add(rdoNu);
            grpGioiTinh.Controls.Add(rdoNam);
            grpGioiTinh.Location = new Point(411, 100);
            grpGioiTinh.Name = "grpGioiTinh";
            grpGioiTinh.Size = new Size(314, 85);
            grpGioiTinh.TabIndex = 3;
            grpGioiTinh.TabStop = false;
            grpGioiTinh.Text = "Giới tính";
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(167, 41);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(61, 29);
            rdoNu.TabIndex = 1;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(24, 41);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(75, 29);
            rdoNam.TabIndex = 0;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(42, 244);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.RowHeadersWidth = 62;
            dgvKhachHang.Size = new Size(783, 158);
            dgvKhachHang.TabIndex = 4;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(166, 466);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(150, 31);
            txtTimKiem.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(338, 466);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(112, 34);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(138, 51);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(150, 31);
            txtDienThoai.TabIndex = 7;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(138, 110);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(150, 31);
            txtHoTen.TabIndex = 8;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(494, 48);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(150, 31);
            txtDiaChi.TabIndex = 9;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(151, 546);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 10;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click_1;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(307, 546);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 11;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(457, 546);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 34);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // FrmKhachHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 632);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtDiaChi);
            Controls.Add(txtHoTen);
            Controls.Add(txtDienThoai);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(dgvKhachHang);
            Controls.Add(grpGioiTinh);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmKhachHang";
            Text = "FrmKhachHang";
            Load += FrmKhachHang_Load;
            grpGioiTinh.ResumeLayout(false);
            grpGioiTinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox grpGioiTinh;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private DataGridView dgvKhachHang;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private TextBox txtDienThoai;
        private TextBox txtHoTen;
        private TextBox txtDiaChi;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
    }
}