using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DAL_QLBanHang.Helpers;

namespace DAL_QLBanHang.Repositories
{
    public class DAL_ThongKe
    {
        // ✅ Top sản phẩm (tổng số lượng + tổng tiền)
        public DataTable TopSanPham(DateTime from, DateTime to, int topN)
        {
            string sql = @"
SELECT TOP(@top)
    ct.MaHang,
    h.TenHang,
    ISNULL(SUM(ct.SoLuong), 0) AS TongSoLuong,
    ISNULL(SUM(ISNULL(ct.ThanhTien, ct.SoLuong * ct.DonGiaBan)), 0) AS TongTien
FROM dbo.HoaDon hd
JOIN dbo.HoaDonChiTiet ct ON ct.MaHD = hd.MaHD
JOIN dbo.Hang h ON h.MaHang = ct.MaHang
WHERE hd.NgayLap >= @from
  AND hd.NgayLap < @to
  AND ISNULL(hd.TrangThai, 1) = 1
GROUP BY ct.MaHang, h.TenHang
ORDER BY TongTien DESC;";

            return DbHelper.Query(sql,
                new SqlParameter("@top", topN),
                new SqlParameter("@from", from),
                new SqlParameter("@to", to)
            );
        }

        // ✅ Doanh thu theo ngày (trong khoảng [from, to) )
        public DataTable DoanhThuTheoNgay(DateTime from, DateTime to)
        {
            string sql = @"
SELECT
    CONVERT(date, hd.NgayLap) AS Ngay,
    COUNT(DISTINCT hd.MaHD)  AS SoHoaDon,
    ISNULL(SUM(ISNULL(hd.ThanhToan, hd.TongTien)), 0) AS DoanhThu
FROM dbo.HoaDon hd
WHERE hd.NgayLap >= @from
  AND hd.NgayLap <  @to
  AND ISNULL(hd.TrangThai, 1) = 1
GROUP BY CONVERT(date, hd.NgayLap)
ORDER BY Ngay;";

            return DbHelper.Query(sql,
                new SqlParameter("@from", from),
                new SqlParameter("@to", to)
            );
        }

        // ✅ Doanh thu theo tháng (theo năm)
        public DataTable DoanhThuTheoThang(int year)
        {
            string sql = @"
SELECT 
    MONTH(hd.NgayLap) AS Thang,
    COUNT(DISTINCT hd.MaHD) AS SoHoaDon,
    ISNULL(SUM(ISNULL(ct.SoLuong,0) * ISNULL(ct.DonGiaBan,0)), 0) AS DoanhThu
FROM dbo.HoaDon hd
LEFT JOIN dbo.HoaDonChiTiet ct ON ct.MaHD = hd.MaHD
WHERE YEAR(hd.NgayLap) = @year
  AND ISNULL(hd.TrangThai, 1) = 1
GROUP BY MONTH(hd.NgayLap)
ORDER BY Thang;";

            return DbHelper.Query(sql, new SqlParameter("@year", year));
        }

        // ✅ Doanh thu theo nhân viên
        public DataTable DoanhThuTheoNhanVien(DateTime from, DateTime to)
        {
            string sql = @"
SELECT
    hd.MaNV,
    nv.TenNV,
    COUNT(DISTINCT hd.MaHD) AS SoHoaDon,
    ISNULL(SUM(ISNULL(hd.ThanhToan, hd.TongTien)), 0) AS DoanhThu
FROM dbo.HoaDon hd
LEFT JOIN dbo.NhanVien nv ON nv.MaNV = hd.MaNV
WHERE hd.NgayLap >= @from
  AND hd.NgayLap <  @to
  AND ISNULL(hd.TrangThai, 1) = 1
GROUP BY hd.MaNV, nv.TenNV
ORDER BY DoanhThu DESC;";

            return DbHelper.Query(sql,
                new SqlParameter("@from", from),
                new SqlParameter("@to", to)
            );
        }
    }
}
