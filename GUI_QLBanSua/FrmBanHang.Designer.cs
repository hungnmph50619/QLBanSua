namespace GUI_QLBanSua
{
    partial class FrmBanHang
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
            dgvHang = new DataGridView();
            nudSoLuong = new NumericUpDown();
            button1 = new Button();
            dgvGioHang = new DataGridView();
            txtDienThoai = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnThanhToan = new Button();
            label4 = new Label();
            lblTongTien = new Label();
            label5 = new Label();
            txtKhachDua = new TextBox();
            lblTienThoi = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            SuspendLayout();
            // 
            // dgvHang
            // 
            dgvHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHang.Location = new Point(70, 49);
            dgvHang.MultiSelect = false;
            dgvHang.Name = "dgvHang";
            dgvHang.ReadOnly = true;
            dgvHang.RowHeadersWidth = 62;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.Size = new Size(1047, 312);
            dgvHang.TabIndex = 0;
            dgvHang.CellClick += dgvHang_CellClick;
            // 
            // nudSoLuong
            // 
            nudSoLuong.Location = new Point(719, 424);
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(180, 31);
            nudSoLuong.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(919, 424);
            button1.Name = "button1";
            button1.Size = new Size(148, 36);
            button1.TabIndex = 2;
            button1.Text = "Thêm vào giỏ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvGioHang
            // 
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Location = new Point(70, 414);
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.ReadOnly = true;
            dgvGioHang.RowHeadersWidth = 62;
            dgvGioHang.Size = new Size(608, 225);
            dgvGioHang.TabIndex = 3;
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(719, 513);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(150, 31);
            txtDienThoai.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(719, 475);
            label1.Name = "label1";
            label1.Size = new Size(213, 25);
            label1.TabIndex = 5;
            label1.Text = "Số điện thoại khách hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 9);
            label2.Name = "label2";
            label2.Size = new Size(83, 25);
            label2.TabIndex = 6;
            label2.Text = "List hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 386);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 7;
            label3.Text = "giỏ hàng";
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(719, 589);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(109, 41);
            btnThanhToan.TabIndex = 8;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(710, 396);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 9;
            label4.Text = "Số lượng";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(719, 561);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(72, 25);
            lblTongTien.TabIndex = 10;
            lblTongTien.Text = "Tổng: 0";
            lblTongTien.Click += lblTongTien_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(947, 475);
            label5.Name = "label5";
            label5.Size = new Size(131, 25);
            label5.TabIndex = 11;
            label5.Text = "Tiền khách đưa";
            // 
            // txtKhachDua
            // 
            txtKhachDua.Location = new Point(947, 513);
            txtKhachDua.Name = "txtKhachDua";
            txtKhachDua.Size = new Size(150, 31);
            txtKhachDua.TabIndex = 12;
            txtKhachDua.TextChanged += txtKhachDua_TextChanged;
            // 
            // lblTienThoi
            // 
            lblTienThoi.AutoSize = true;
            lblTienThoi.Location = new Point(947, 614);
            lblTienThoi.Name = "lblTienThoi";
            lblTienThoi.Size = new Size(22, 25);
            lblTienThoi.TabIndex = 13;
            lblTienThoi.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(947, 573);
            label6.Name = "label6";
            label6.Size = new Size(121, 25);
            label6.TabIndex = 14;
            label6.Text = "Tiền trả khách";
            // 
            // FrmBanHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1156, 667);
            Controls.Add(label6);
            Controls.Add(lblTienThoi);
            Controls.Add(txtKhachDua);
            Controls.Add(label5);
            Controls.Add(lblTongTien);
            Controls.Add(label4);
            Controls.Add(btnThanhToan);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDienThoai);
            Controls.Add(dgvGioHang);
            Controls.Add(button1);
            Controls.Add(nudSoLuong);
            Controls.Add(dgvHang);
            Name = "FrmBanHang";
            Text = "FrmBanHang";
            Load += FrmBanHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHang;
        private NumericUpDown nudSoLuong;
        private Button button1;
        private DataGridView dgvGioHang;
        private TextBox txtDienThoai;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnThanhToan;
        private Label label4;
        private Label lblTongTien;
        private Label label5;
        private TextBox txtKhachDua;
        private Label lblTienThoi;
        private Label label6;
    }
}