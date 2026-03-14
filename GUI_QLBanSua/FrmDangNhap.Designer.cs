using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_QLBanSua
{
    partial class FrmDangNhap
    {
        private IContainer components = null;

        private Label lblTitle;
        private Label lblMsg;
        private Label lblEmail;
        private Label lblPass;

        private TextBox txtEmail;
        private TextBox txtPass;

        private CheckBox chkRemember;

        private Button btnLogin;
        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblMsg = new Label();
            lblEmail = new Label();
            lblPass = new Label();
            txtEmail = new TextBox();
            txtPass = new TextBox();
            chkRemember = new CheckBox();
            btnLogin = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(640, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMsg
            // 
            lblMsg.ForeColor = Color.DarkRed;
            lblMsg.Location = new Point(60, 80);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(520, 24);
            lblMsg.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(60, 115);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(189, 30);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email hoặc Mã NV";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Location = new Point(60, 190);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(103, 30);
            lblPass.TabIndex = 3;
            lblPass.Text = "Mật khẩu";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(60, 145);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(520, 37);
            txtEmail.TabIndex = 0;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(60, 220);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(520, 37);
            txtPass.TabIndex = 1;
            txtPass.UseSystemPasswordChar = true;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.Location = new Point(60, 265);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(208, 34);
            chkRemember.TabIndex = 2;
            chkRemember.Text = "Ghi nhớ tài khoản";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.Location = new Point(60, 310);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 48);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.DialogResult = DialogResult.Cancel;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExit.Location = new Point(330, 310);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(250, 48);
            btnExit.TabIndex = 4;
            btnExit.Text = "THOÁT";
            btnExit.Click += BtnExit_Click;
            // 
            // FrmDangNhap
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(640, 420);
            Controls.Add(lblTitle);
            Controls.Add(lblMsg);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPass);
            Controls.Add(txtPass);
            Controls.Add(chkRemember);
            Controls.Add(btnLogin);
            Controls.Add(btnExit);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập hệ thống";
            Load += FrmDangNhap_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
