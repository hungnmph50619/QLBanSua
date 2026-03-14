using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DAL_QLBanHang.Helpers;
using DTO_QLBanHang.Models;

namespace DAL_QLBanHang.Repositories
{
    public class DAL_HoaDon
    {
        public int ThanhToan(HoaDon hd, List<HoaDonChiTiet> cts)
        {
            if (hd == null) throw new ArgumentNullException(nameof(hd));
            if (cts == null || cts.Count == 0) throw new Exception("Giỏ hàng trống, không thể thanh toán.");

            using var conn = new SqlConnection(DbConfig.ConnectionString);
            conn.Open();

            using var tran = conn.BeginTransaction();

            try
            {
                // 1) Nếu có nhập số ĐT thì check KH tồn tại trước (trải nghiệm đẹp, khỏi để SQL văng lỗi FK)
                if (!string.IsNullOrWhiteSpace(hd.DienThoai))
                {
                    var sqlCheckKh = "SELECT COUNT(1) FROM dbo.KhachHang WHERE DienThoai = @dt";
                    using var cmdCheck = new SqlCommand(sqlCheckKh, conn, tran);
                    cmdCheck.Parameters.AddWithValue("@dt", hd.DienThoai.Trim());
                    int exists = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (exists == 0)
                        throw new Exception("Khách hàng chưa tồn tại trong hệ thống. Vui lòng thêm khách hàng trước khi thanh toán.");
                }

                // 2) Insert HoaDon + lấy MaHD
                var sqlInsertHd = @"
INSERT INTO dbo.HoaDon(NgayLap, MaNV, DienThoai, TongTien, GiamGia, ThanhToan, GhiChu, TrangThai)
VALUES(@NgayLap, @MaNV, @DienThoai, @TongTien, @GiamGia, @ThanhToan, @GhiChu, @TrangThai);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using var cmdHd = new SqlCommand(sqlInsertHd, conn, tran);
                cmdHd.Parameters.AddWithValue("@NgayLap", hd.NgayLap);
                cmdHd.Parameters.AddWithValue("@MaNV", hd.MaNV);
                cmdHd.Parameters.AddWithValue("@DienThoai", (object?)hd.DienThoai ?? DBNull.Value);
                cmdHd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                cmdHd.Parameters.AddWithValue("@GiamGia", hd.GiamGia);
                cmdHd.Parameters.AddWithValue("@ThanhToan", hd.ThanhToan);
                cmdHd.Parameters.AddWithValue("@GhiChu", (object?)hd.GhiChu ?? DBNull.Value);
                cmdHd.Parameters.AddWithValue("@TrangThai", hd.TrangThai);

                int maHD = Convert.ToInt32(cmdHd.ExecuteScalar());

                // 3) Insert CT + trừ tồn kho
                var sqlInsertCt = @"
INSERT INTO dbo.HoaDonChiTiet(MaHD, MaHang, SoLuong, DonGiaBan)
VALUES(@MaHD, @MaHang, @SoLuong, @DonGiaBan);";

                var sqlTruKho = @"
UPDATE dbo.Hang
SET SoLuong = SoLuong - @SoLuong
WHERE MaHang = @MaHang;";

                foreach (var ct in cts)
                {
                    // Insert CT
                    using (var cmdCt = new SqlCommand(sqlInsertCt, conn, tran))
                    {
                        cmdCt.Parameters.AddWithValue("@MaHD", maHD);
                        cmdCt.Parameters.AddWithValue("@MaHang", ct.MaHang);
                        cmdCt.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                        cmdCt.Parameters.AddWithValue("@DonGiaBan", ct.DonGiaBan);
                        cmdCt.ExecuteNonQuery();
                    }

                    // Trừ kho
                    using (var cmdKho = new SqlCommand(sqlTruKho, conn, tran))
                    {
                        cmdKho.Parameters.AddWithValue("@MaHang", ct.MaHang);
                        cmdKho.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                        cmdKho.ExecuteNonQuery();
                    }
                }

                tran.Commit();
                return maHD;
            }
            catch
            {
                tran.Rollback();
                throw;
            }
        }
    }
}
