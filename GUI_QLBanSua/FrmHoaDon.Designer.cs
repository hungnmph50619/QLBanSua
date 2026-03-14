namespace GUI_QLBanSua
{
    partial class FrmHoaDon
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
            dgvHoaDon = new DataGridView();
            label2 = new Label();
            dgvHoaDonCT = new DataGridView();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonCT).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 9);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 0;
            label1.Text = "Danh sách hóa đơn";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(14, 37);
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersWidth = 62;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(1106, 225);
            dgvHoaDon.TabIndex = 1;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick_1;

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 275);
            label2.Name = "label2";
            label2.Size = new Size(139, 25);
            label2.TabIndex = 2;
            label2.Text = "Chi tiết hóa đơn";
            // 
            // dgvHoaDonCT
            // 
            dgvHoaDonCT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDonCT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDonCT.Location = new Point(14, 312);
            dgvHoaDonCT.MultiSelect = false;
            dgvHoaDonCT.Name = "dgvHoaDonCT";
            dgvHoaDonCT.ReadOnly = true;
            dgvHoaDonCT.RowHeadersWidth = 62;
            dgvHoaDonCT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDonCT.Size = new Size(1106, 225);
            dgvHoaDonCT.TabIndex = 3;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(870, 9);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(250, 25);
            lblInfo.TabIndex = 4;
            lblInfo.Text = "Tổng tiền / Mã HĐ đang chọn";
            // 
            // FrmHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 450);
            Controls.Add(lblInfo);
            Controls.Add(dgvHoaDonCT);
            Controls.Add(label2);
            Controls.Add(dgvHoaDon);
            Controls.Add(label1);
            Name = "FrmHoaDon";
            Text = "FrmHoaDon";
            Load += FrmHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDonCT).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvHoaDon;
        private Label label2;
        private DataGridView dgvHoaDonCT;
        private Label lblInfo;
    }
}