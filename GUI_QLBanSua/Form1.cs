using DAL_QLBanHang.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QLBanSua
{
    public partial class Form1 : Form
    {
        private string _maNv = "";
        private int _vaiTro = 0; // 1 = admin (theo DB bạn gửi). Nếu DB bạn quy ước ngược thì đổi điều kiện isAdmin.

        public Form1()
        {
            InitializeComponent();
        }

        // ✅ Program.cs gọi constructor này
        public Form1(string maNv, int vaiTro) : this()
        {
            _maNv = maNv ?? "";
            _vaiTro = vaiTro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _maNv = AppSession.MaNV;
            _vaiTro = AppSession.VaiTro;

            ApplyPermission();

            // mở màn bán hàng luôn (nếu đã đăng nhập)
            if (!string.IsNullOrWhiteSpace(_maNv))
                OpenChild(new FrmBanHang(_maNv));
        }

        private void ApplyPermission()
        {
            bool isLoggedIn = !string.IsNullOrWhiteSpace(_maNv);
            bool isAdmin = (_vaiTro == 1); // ✅ theo bảng DB bạn chụp: admin@gmail.com có VaiTro=1

            // mặc định: bật Hệ Thống + Hướng Dẫn
            hệThốngToolStripMenuItem.Enabled = true;
            mnuHuongDan.Enabled = true;

            // Đăng nhập/đăng xuất
            mnuDangNhap.Enabled = !isLoggedIn;
            mnuDangXuat.Enabled = isLoggedIn;
      

            if (!isLoggedIn)
            {
                // chưa login => khóa hết nghiệp vụ
                mnuDanhMuc.Enabled = false;
                mnuThongKe.Enabled = false;
                return;
            }

            if (isAdmin)
            {
                // ✅ Admin: mở hết
                mnuDanhMuc.Enabled = true;
                mnuThongKe.Enabled = true;

                mnuNhanVien.Enabled = true;
                sảnPhẩmToolStripMenuItem.Enabled = true;
                kháchHàngToolStripMenuItem.Enabled = true;


                mnuBanRaDoanhThu.Enabled = true;
                xemHóaĐơnToolStripMenuItem.Enabled = true;
            }
            else
            {
                // Nhân viên: tuỳ bài bạn mở gì thì mở (ở đây: chỉ cho xem thống kê & hóa đơn)
                mnuDanhMuc.Enabled = false;

                mnuThongKe.Enabled = true;

                mnuBanRaDoanhThu.Enabled = false;

                xemHóaĐơnToolStripMenuItem.Enabled = true;
            }
        }

        private void OpenChild(Form f)
        {
            // không mở trùng form cùng loại
            foreach (Form child in this.MdiChildren)
            {
                if (child.GetType() == f.GetType())
                {
                    child.BringToFront();
                    child.Activate();
                    return;
                }
            }

            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        // ===== MENU EVENTS =====

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            using var f = new FrmDangNhap();
            if (f.ShowDialog() != DialogResult.OK) return;

            _maNv = f.LoggedMaNV;
            _vaiTro = f.LoggedVaiTro;

            ApplyPermission();
            OpenChild(new FrmBanHang(_maNv));
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            // đóng hết form con
            foreach (var c in this.MdiChildren.ToList())
                c.Close();

            _maNv = "";
            _vaiTro = 0;

            ApplyPermission();

            // mở lại login
            mnuDangNhap_Click(sender, e);
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmQuanLyNhanVien());
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmSanPham());
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmKhachHang());
        }

        private void mnuTonKho_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmThongKe());
        }

        private void mnuBanRaDoanhThu_Click_Click(object sender, EventArgs e)
        {
            OpenChild(new FrmThongKe());
        }

        private void xemHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ✅ Vì bạn đang có constructor FrmHoaDon(string, int) nên phải truyền đủ
            OpenChild(new FrmHoaDon(_maNv, _vaiTro));
        }

        private void mnuNhapKho_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng nhập kho: bạn làm sau cũng được nha.");
        }
        private void DoLogout()
        {
            var ok = MessageBox.Show("Bạn muốn đăng xuất không?", "Xác nhận",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ok != DialogResult.Yes) return;
            // 1) Đóng hết form con (MDI children)
            foreach (var c in this.MdiChildren.ToList())
                c.Close();

            // 2) Xóa session
            AppSession.MaNV = "";
            AppSession.VaiTro = 0;

            // 3) Reset biến của Form1
            _maNv = "";
            _vaiTro = 0;

            // 4) Khóa/mở menu theo quyền
            ApplyPermission();

            // 5) Mở lại đăng nhập (tuỳ bạn: muốn hiện login luôn hay không)
            using var f = new FrmDangNhap();
            if (f.ShowDialog() == DialogResult.OK)
            {
                _maNv = f.LoggedMaNV;
                _vaiTro = f.LoggedVaiTro;

                AppSession.MaNV = _maNv;
                AppSession.VaiTro = _vaiTro;

                ApplyPermission();
                OpenChild(new FrmBanHang(_maNv));
            }
        }

        private void mnuDangXuat_Click_1(object sender, EventArgs e)
        {
            DoLogout();
        }

        private void mnuDangNhap_Click_1(object sender, EventArgs e)
        {
            using (var f = new FrmDangNhap())
            {
                // mở dạng dialog (khóa form cha lại)
                f.ShowDialog(this);
            }
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Nếu chưa đăng nhập thì bắt đăng nhập trước
            if (string.IsNullOrWhiteSpace(_maNv))
            {
                MessageBox.Show("Bạn cần đăng nhập trước.");
                mnuDangNhap_Click(sender, e);   // gọi form đăng nhập
                if (string.IsNullOrWhiteSpace(_maNv)) return; // user bấm Cancel/Thoát
            }

            // Mở form bán hàng (không mở trùng vì OpenChild đã chặn)
            OpenChild(new FrmBanHang(_maNv));
        }

        private void mnuHuongDan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_maNv))
            {
                MessageBox.Show("Bạn cần đăng nhập trước.");
                mnuDangNhap_Click(sender, e);
                if (string.IsNullOrWhiteSpace(_maNv)) return;
            }

            using var f = new FrmDoiMatKhau(_maNv);
            f.ShowDialog(this);
        }
    }
}
