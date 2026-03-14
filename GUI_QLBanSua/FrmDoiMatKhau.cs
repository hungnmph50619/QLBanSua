using System;
using System.Windows.Forms;
using BUS_QLBanHang;

namespace GUI_QLBanSua
{
    public partial class FrmDoiMatKhau : Form
    {
        private readonly string _maNv;
        private readonly BUS_NhanVien _busNv = new BUS_NhanVien();

        public FrmDoiMatKhau(string maNv)
        {
            InitializeComponent();
            _maNv = maNv ?? "";

            // đảm bảo có event Load (tránh lỗi Designer gọi Load mà bạn chưa có)
            this.Load += FrmDoiMatKhau_Load;

            // nếu bạn lỡ chưa gắn event trong Designer thì vẫn chạy
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            // ẩn ký tự password
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtXacNhan.UseSystemPasswordChar = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mkCu = txtMatKhauCu.Text.Trim();
            string mkMoi = txtMatKhauMoi.Text.Trim();
            string xacNhan = txtXacNhan.Text.Trim();

            if (string.IsNullOrWhiteSpace(_maNv))
            {
                MessageBox.Show("Bạn chưa đăng nhập.");
                return;
            }

            if (string.IsNullOrWhiteSpace(mkCu) || string.IsNullOrWhiteSpace(mkMoi))
            {
                MessageBox.Show("Nhập mật khẩu cũ và mật khẩu mới.");
                return;
            }

            if (mkMoi.Length < 4)
            {
                MessageBox.Show("Mật khẩu mới tối thiểu 4 ký tự.");
                return;
            }

            if (mkMoi != xacNhan)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp.");
                return;
            }

            bool ok = _busNv.DoiMatKhau(_maNv, mkCu, mkMoi);
            if (!ok)
            {
                MessageBox.Show("Mật khẩu cũ không đúng (hoặc không tìm thấy nhân viên).");
                return;
            }

            MessageBox.Show("Đổi mật khẩu thành công!");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
