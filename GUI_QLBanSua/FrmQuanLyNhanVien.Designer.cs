namespace GUI_QLBanSua
{
    partial class FrmQuanLyNhanVien
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
            txtEmail = new TextBox();
            txtTenNV = new TextBox();
            txtDiaChi = new TextBox();
            label3 = new Label();
            dgvNhanVien = new DataGridView();
            rdoNhanVien = new RadioButton();
            rdoQuanTri = new RadioButton();
            rdoHoatDong = new RadioButton();
            rdoNgungHoatDong = new RadioButton();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            grpRole = new GroupBox();
            grpTinhTrang = new GroupBox();
            btnResetPass = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            grpRole.SuspendLayout();
            grpTinhTrang.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 71);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 119);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 1;
            label2.Text = "Nhân Viên";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(139, 71);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(222, 31);
            txtEmail.TabIndex = 2;
            // 
            // txtTenNV
            // 
            txtTenNV.Location = new Point(139, 119);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(222, 31);
            txtTenNV.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(605, 68);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(358, 119);
            txtDiaChi.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(527, 74);
            label3.Name = "label3";
            label3.Size = new Size(65, 25);
            label3.TabIndex = 5;
            label3.Text = "Địa chỉ";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(70, 301);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 62;
            dgvNhanVien.Size = new Size(1155, 263);
            dgvNhanVien.TabIndex = 6;
            // 
            // rdoNhanVien
            // 
            rdoNhanVien.AutoSize = true;
            rdoNhanVien.Location = new Point(107, 30);
            rdoNhanVien.Name = "rdoNhanVien";
            rdoNhanVien.Size = new Size(118, 29);
            rdoNhanVien.TabIndex = 8;
            rdoNhanVien.TabStop = true;
            rdoNhanVien.Text = "Nhân Viên";
            rdoNhanVien.UseVisualStyleBackColor = true;
            // 
            // rdoQuanTri
            // 
            rdoQuanTri.AutoSize = true;
            rdoQuanTri.Location = new Point(248, 30);
            rdoQuanTri.Name = "rdoQuanTri";
            rdoQuanTri.Size = new Size(102, 29);
            rdoQuanTri.TabIndex = 9;
            rdoQuanTri.TabStop = true;
            rdoQuanTri.Text = "Quản Trị";
            rdoQuanTri.UseVisualStyleBackColor = true;
            // 
            // rdoHoatDong
            // 
            rdoHoatDong.AutoSize = true;
            rdoHoatDong.Location = new Point(56, 30);
            rdoHoatDong.Name = "rdoHoatDong";
            rdoHoatDong.Size = new Size(124, 29);
            rdoHoatDong.TabIndex = 11;
            rdoHoatDong.TabStop = true;
            rdoHoatDong.Text = "Hoạt động";
            rdoHoatDong.UseVisualStyleBackColor = true;
            // 
            // rdoNgungHoatDong
            // 
            rdoNgungHoatDong.AutoSize = true;
            rdoNgungHoatDong.Location = new Point(234, 30);
            rdoNgungHoatDong.Name = "rdoNgungHoatDong";
            rdoNgungHoatDong.Size = new Size(182, 29);
            rdoNgungHoatDong.TabIndex = 12;
            rdoNgungHoatDong.TabStop = true;
            rdoNgungHoatDong.Text = "Ngừng hoạt động";
            rdoNgungHoatDong.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(276, 570);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(130, 41);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(66, 575);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(191, 31);
            txtTimKiem.TabIndex = 14;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(56, 656);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(130, 41);
            btnThem.TabIndex = 15;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
         
            // 
            // btnSua
            // 
            btnSua.Location = new Point(231, 656);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(130, 41);
            btnSua.TabIndex = 16;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(395, 656);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(130, 41);
            btnXoa.TabIndex = 17;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // grpRole
            // 
            grpRole.Controls.Add(rdoQuanTri);
            grpRole.Controls.Add(rdoNhanVien);
            grpRole.Location = new Point(66, 202);
            grpRole.Name = "grpRole";
            grpRole.Size = new Size(356, 65);
            grpRole.TabIndex = 18;
            grpRole.TabStop = false;
            grpRole.Text = "Chức vụ";
            // 
            // grpTinhTrang
            // 
            grpTinhTrang.Controls.Add(rdoHoatDong);
            grpTinhTrang.Controls.Add(rdoNgungHoatDong);
            grpTinhTrang.Location = new Point(462, 208);
            grpTinhTrang.Name = "grpTinhTrang";
            grpTinhTrang.Size = new Size(477, 70);
            grpTinhTrang.TabIndex = 19;
            grpTinhTrang.TabStop = false;
            grpTinhTrang.Text = "Tình trạng";
            // 
            // btnResetPass
            // 
            btnResetPass.Location = new Point(969, 238);
            btnResetPass.Name = "btnResetPass";
            btnResetPass.Size = new Size(186, 34);
            btnResetPass.TabIndex = 20;
            btnResetPass.Text = "Reset mật khẩu";
            btnResetPass.UseVisualStyleBackColor = true;
            btnResetPass.Click += btnResetPass_Click;
            // 
            // FrmQuanLyNhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 731);
            Controls.Add(btnResetPass);
            Controls.Add(grpTinhTrang);
            Controls.Add(grpRole);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvNhanVien);
            Controls.Add(label3);
            Controls.Add(txtDiaChi);
            Controls.Add(txtTenNV);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmQuanLyNhanVien";
            Text = "FrmQuanLyNhanVien";
            Load += FrmQuanLyNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            grpRole.ResumeLayout(false);
            grpRole.PerformLayout();
            grpTinhTrang.ResumeLayout(false);
            grpTinhTrang.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtEmail;
        private TextBox txtTenNV;
        private TextBox txtDiaChi;
        private Label label3;
        private DataGridView dgvNhanVien;
        private Label label4;
        private RadioButton rdoNhanVien;
        private RadioButton rdoQuanTri;
        private Label label5;
        private RadioButton rdoHoatDong;
        private RadioButton rdoNgungHoatDong;
        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private GroupBox grpRole;
        private GroupBox grpTinhTrang;
        private Button btnResetPass;
    }
}