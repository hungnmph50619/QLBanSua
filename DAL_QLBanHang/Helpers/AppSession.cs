namespace DAL_QLBanHang.Helpers
{
    public static class AppSession
    {
        public static string MaNV { get; set; } = "";
        public static string Email { get; set; } = "";
        public static int VaiTro { get; set; } = 0;

        public static void Clear()
        {
            MaNV = "";
            Email = "";
            VaiTro = 0;
        }
    }
}
