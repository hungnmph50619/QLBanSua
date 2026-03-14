using System;
using System.Windows.Forms;
using DAL_QLBanHang.Helpers;

namespace GUI_QLBanSua
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var fLogin = new FrmDangNhap();
            if (fLogin.ShowDialog() != DialogResult.OK) return;

            AppSession.MaNV = fLogin.LoggedMaNV;
            AppSession.VaiTro = fLogin.LoggedVaiTro;

            Application.Run(new Form1()); // Form1 tự đọc AppSession
        }
    }
}
