namespace GUI_QLBanSua
{
    partial class FrmDoiMatKhau
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
            txtMatKhauCu = new TextBox();
            label1 = new Label();
            txtMatKhauMoi = new TextBox();
            label2 = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            txtXacNhan = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(419, 152);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.Size = new Size(150, 31);
            txtMatKhauCu.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(279, 158);
            label1.Name = "label1";
            label1.Size = new Size(109, 25);
            label1.TabIndex = 1;
            label1.Text = "Mật khẩu cũ";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(422, 217);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(150, 31);
            txtMatKhauMoi.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 217);
            label2.Name = "label2";
            label2.Size = new Size(122, 25);
            label2.TabIndex = 3;
            label2.Text = "Mật khẩu mới";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(199, 351);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(365, 351);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(112, 34);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // txtXacNhan
            // 
            txtXacNhan.Location = new Point(422, 276);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.Size = new Size(147, 31);
            txtXacNhan.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 282);
            label3.Name = "label3";
            label3.Size = new Size(192, 25);
            label3.TabIndex = 7;
            label3.Text = "Nhập lại mật khẩu mới";
            // 
            // FrmDoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(txtXacNhan);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(label2);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(label1);
            Controls.Add(txtMatKhauCu);
            Name = "FrmDoiMatKhau";
            Text = "FrmDoiMatKhau";
            Load += FrmDoiMatKhau_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMatKhauCu;
        private Label label1;
        private TextBox txtMatKhauMoi;
        private Label label2;
        private Button btnLuu;
        private Button btnHuy;
        private TextBox txtXacNhan;
        private Label label3;
    }
}