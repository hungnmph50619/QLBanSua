using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace GUI_QLBanSua
{
    public partial class FrmDangNhap : Form
    {
        private const string SERVER_NAME = @"localhost\HUNG";
        private const string DB_NAME = "DBQLBanHang";

        private static readonly string ConnectionString =
            $"Server={SERVER_NAME};Database={DB_NAME};Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        private readonly string rememberPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "QLBanSua", "remember_email.txt");

        // ✅ Program.cs sẽ lấy 2 giá trị này sau khi đăng nhập OK
        public string LoggedMaNV { get; private set; } = "";
        public int LoggedVaiTro { get; private set; } = 0;

        public FrmDangNhap()
        {
            InitializeComponent();

            // cho Enter = Đăng nhập, Esc = Thoát
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
        }

        private void FrmDangNhap_Load(object? sender, EventArgs e)
        {
            try
            {
                if (File.Exists(rememberPath))
                {
                    txtEmail.Text = File.ReadAllText(rememberPath).Trim();
                    chkRemember.Checked = !string.IsNullOrWhiteSpace(txtEmail.Text);
                    txtEmail.SelectionStart = txtEmail.Text.Length;
                }
            }
            catch { }
        }

        // ✅ nếu Designer đang trỏ btnExit.Click vào BtnExit_Click thì phải có hàm này
        private void BtnExit_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            lblMsg.Text = "";

            var id = txtEmail.Text.Trim();
            var pass = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                lblMsg.Text = "Bạn chưa nhập Email/Mã NV.";
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(pass))
            {
                lblMsg.Text = "Bạn chưa nhập mật khẩu.";
                txtPass.Focus();
                return;
            }

            try
            {
                if (!TryDangNhap(id, pass, out var maNv, out var vaiTro))
                {
                    lblMsg.Text = "Sai tài khoản hoặc mật khẩu.";
                    txtPass.SelectAll();
                    txtPass.Focus();
                    return;
                }

                // ✅ lưu info cho Program.cs / Form1
                LoggedMaNV = maNv;
                LoggedVaiTro = vaiTro;

                SaveRememberEmail(id);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ LẤY MaNV + VaiTro (đây là chỗ quan trọng để admin không bị mờ menu)
        private static bool TryDangNhap(string emailOrMaNv, string passPlain, out string maNv, out int vaiTro)
        {
            maNv = "";
            vaiTro = 0;

            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(@"
SELECT TOP 1 MaNV, VaiTro
FROM dbo.NhanVien
WHERE (LTRIM(RTRIM(Email)) = @id OR LTRIM(RTRIM(MaNV)) = @id)
  AND LTRIM(RTRIM(MatKhau)) = @pass
  AND TinhTrang = 1;
", conn);

            cmd.Parameters.AddWithValue("@id", emailOrMaNv.Trim());
            cmd.Parameters.AddWithValue("@pass", passPlain.Trim());

            conn.Open();
            using var rd = cmd.ExecuteReader();

            if (!rd.Read()) return false;

            maNv = rd["MaNV"]?.ToString() ?? "";
            vaiTro = Convert.ToInt32(rd["VaiTro"]);

            return !string.IsNullOrWhiteSpace(maNv);
        }

        private void SaveRememberEmail(string emailOrMaNv)
        {
            try
            {
                var dir = Path.GetDirectoryName(rememberPath)!;
                Directory.CreateDirectory(dir);

                if (chkRemember.Checked)
                    File.WriteAllText(rememberPath, emailOrMaNv);
                else if (File.Exists(rememberPath))
                    File.Delete(rememberPath);
            }
            catch { }
        }
    }
}
