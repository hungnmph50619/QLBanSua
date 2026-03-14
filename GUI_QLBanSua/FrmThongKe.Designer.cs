namespace GUI_QLBanSua
{
    partial class FrmThongKe
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
            dtFrom = new DateTimePicker();
            dtTo = new DateTimePicker();
            nudTop = new NumericUpDown();
            btnTai = new Button();
            topSanPham = new TabControl();
            tabPage1 = new TabPage();
            dgvNgay = new DataGridView();
            tabPage2 = new TabPage();
            dgvThang = new DataGridView();
            tabPage3 = new TabPage();
            dgvTop = new DataGridView();
            tabPage4 = new TabPage();
            dgvNV = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudTop).BeginInit();
            topSanPham.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNgay).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThang).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTop).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNV).BeginInit();
            SuspendLayout();
            // 
            // dtFrom
            // 
            dtFrom.Location = new Point(42, 57);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(300, 31);
            dtFrom.TabIndex = 0;
            // 
            // dtTo
            // 
            dtTo.Location = new Point(42, 144);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(300, 31);
            dtTo.TabIndex = 1;
            // 
            // nudTop
            // 
            nudTop.Location = new Point(537, 63);
            nudTop.Name = "nudTop";
            nudTop.Size = new Size(180, 31);
            nudTop.TabIndex = 2;
            // 
            // btnTai
            // 
            btnTai.Location = new Point(407, 144);
            btnTai.Name = "btnTai";
            btnTai.Size = new Size(212, 34);
            btnTai.TabIndex = 3;
            btnTai.Text = "Hiện doanh thu";
            btnTai.UseVisualStyleBackColor = true;
            btnTai.Click += btnTai_Click_1;
            // 
            // topSanPham
            // 
            topSanPham.Controls.Add(tabPage1);
            topSanPham.Controls.Add(tabPage2);
            topSanPham.Controls.Add(tabPage3);
            topSanPham.Controls.Add(tabPage4);
            topSanPham.Location = new Point(68, 254);
            topSanPham.Name = "topSanPham";
            topSanPham.SelectedIndex = 0;
            topSanPham.Size = new Size(1083, 393);
            topSanPham.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvNgay);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1075, 355);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Doanh thu theo ngày";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // dgvNgay
            // 
            dgvNgay.AllowUserToAddRows = false;
            dgvNgay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNgay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNgay.Location = new Point(0, 3);
            dgvNgay.Name = "dgvNgay";
            dgvNgay.ReadOnly = true;
            dgvNgay.RowHeadersWidth = 62;
            dgvNgay.Size = new Size(1079, 356);
            dgvNgay.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvThang);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1075, 355);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Doanh thu theo tháng";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvThang
            // 
            dgvThang.AllowUserToAddRows = false;
            dgvThang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThang.Location = new Point(6, 33);
            dgvThang.Name = "dgvThang";
            dgvThang.ReadOnly = true;
            dgvThang.RowHeadersWidth = 62;
            dgvThang.Size = new Size(1066, 316);
            dgvThang.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvTop);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1075, 355);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Top sản phẩm";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += tabPage3_Click;
            // 
            // dgvTop
            // 
            dgvTop.AllowUserToAddRows = false;
            dgvTop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTop.Location = new Point(3, 6);
            dgvTop.Name = "dgvTop";
            dgvTop.ReadOnly = true;
            dgvTop.RowHeadersWidth = 62;
            dgvTop.Size = new Size(1072, 349);
            dgvTop.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dgvNV);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1075, 355);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Theo nhân viên";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvNV
            // 
            dgvNV.AllowUserToAddRows = false;
            dgvNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNV.Location = new Point(12, 6);
            dgvNV.Name = "dgvNV";
            dgvNV.ReadOnly = true;
            dgvNV.RowHeadersWidth = 62;
            dgvNV.Size = new Size(1057, 346);
            dgvNV.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 18);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
            label1.TabIndex = 6;
            label1.Text = "Từ ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 106);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 7;
            label2.Text = "Đến ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(407, 63);
            label3.Name = "label3";
            label3.Size = new Size(124, 25);
            label3.TabIndex = 8;
            label3.Text = "Top sản phẩm";
            // 
            // FrmThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 695);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(topSanPham);
            Controls.Add(btnTai);
            Controls.Add(nudTop);
            Controls.Add(dtTo);
            Controls.Add(dtFrom);
            Name = "FrmThongKe";
            Text = "FrmThongKe";
            Load += FrmThongKe_Load;
            ((System.ComponentModel.ISupportInitialize)nudTop).EndInit();
            topSanPham.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNgay).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThang).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTop).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;
        private NumericUpDown nudTop;
        private Button btnTai;
        private TabControl topSanPham;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dgvNgay;
        private DataGridView dgvThang;
        private DataGridView dgvTop;
        private DataGridView dgvNV;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}