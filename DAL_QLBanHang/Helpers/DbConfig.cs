using Microsoft.Data.SqlClient;

namespace DAL_QLBanHang.Helpers
{
    public static class DbConfig
    {
        // Sửa đúng Server của bạn nếu khác
        public static string ConnectionString =
            @"Server=localhost\HUNG;Database=DBQLBanHang;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}
