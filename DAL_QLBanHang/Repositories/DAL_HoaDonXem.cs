using System.Data;
using Microsoft.Data.SqlClient;
using DAL_QLBanHang.Helpers;

namespace DAL_QLBanHang.Repositories
{
    public class DAL_HoaDonXem
    {
        public DataTable GetAllHoaDon()
        {
            string sql = @"
SELECT MaHD, NgayLap, MaNV, DienThoai, TongTien, GiamGia, ThanhToan, GhiChu, TrangThai
FROM dbo.HoaDon
ORDER BY MaHD DESC;";
            return DbHelper.Query(sql);
        }

        public DataTable GetHoaDonByMaNV(string maNV)
        {
            string sql = @"
SELECT MaHD, NgayLap, MaNV, DienThoai, TongTien, GiamGia, ThanhToan, GhiChu, TrangThai
FROM dbo.HoaDon
WHERE MaNV = @MaNV
ORDER BY MaHD DESC;";
            return DbHelper.Query(sql, new SqlParameter("@MaNV", maNV));
        }

        public DataTable GetHoaDonCTByMaHD(int maHD)
        {
            string sql = @"
SELECT MaHD, MaHang, SoLuong, DonGiaBan,
       (SoLuong * DonGiaBan) AS ThanhTien
FROM dbo.HoaDonChiTiet
WHERE MaHD = @MaHD;";
            return DbHelper.Query(sql, new SqlParameter("@MaHD", maHD));
        }
    }
}
