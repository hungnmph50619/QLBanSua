using DAL_QLBanHang.Helpers;
using DTO_QLBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL_QLBanHang.Repositories
{
    public class DAL_KhachHang
    {
        public List<KhachHang> GetAll()
        {
            var list = new List<KhachHang>();

            string sql = @"
SELECT DienThoai,
       TenKhach AS HoVaTen,
       DiaChi,
       Phai AS GioiTinh,
       MaNV
FROM dbo.KhachHang";

            using var conn = new SqlConnection(DbConfig.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);

            conn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new KhachHang
                {
                    DienThoai = rd["DienThoai"]?.ToString(),
                    HoVaTen = rd["HoVaTen"]?.ToString(),
                    DiaChi = rd["DiaChi"]?.ToString(),
                    GioiTinh = rd["GioiTinh"]?.ToString(),
                    MaNV = rd["MaNV"]?.ToString()
                });
            }
            return list;
        }

        public bool ExistsByPhone(string dienThoai)
        {
            var sql = @"SELECT COUNT(1) FROM dbo.KhachHang WHERE DienThoai = @dt";
            var countObj = DbHelper.Scalar(sql, new SqlParameter("@dt", dienThoai));
            int count = Convert.ToInt32(countObj);
            return count > 0;
        }

        public int Insert(KhachHang kh)
        {
            try
            {
                string sql = @"
INSERT INTO dbo.KhachHang(DienThoai, TenKhach, DiaChi, Phai, MaNV)
VALUES(@DienThoai, @TenKhach, @DiaChi, @Phai, @MaNV)";

                using var conn = new SqlConnection(DbConfig.ConnectionString);
                using var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@DienThoai", kh.DienThoai ?? "");
                cmd.Parameters.AddWithValue("@TenKhach", kh.HoVaTen ?? "");
                cmd.Parameters.AddWithValue("@DiaChi", (object?)kh.DiaChi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phai", kh.GioiTinh ?? "Nam");
                cmd.Parameters.AddWithValue("@MaNV", string.IsNullOrWhiteSpace(kh.MaNV) ? "NV1000" : kh.MaNV);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Trùng PK/Unique
                return -1;
            }
        }

        public int Update(KhachHang kh)
        {
            string sql = @"
UPDATE dbo.KhachHang
SET TenKhach = @TenKhach,
    DiaChi   = @DiaChi,
    Phai     = @Phai
WHERE DienThoai = @DienThoai";

            using var conn = new SqlConnection(DbConfig.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@DienThoai", kh.DienThoai ?? "");
            cmd.Parameters.AddWithValue("@TenKhach", kh.HoVaTen ?? "");
            cmd.Parameters.AddWithValue("@DiaChi", (object?)kh.DiaChi ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Phai", kh.GioiTinh ?? "Nam");

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Delete(string dienThoai)
        {
            string sql = "DELETE FROM dbo.KhachHang WHERE DienThoai = @DienThoai";

            using var conn = new SqlConnection(DbConfig.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@DienThoai", dienThoai ?? "");

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public List<KhachHang> Search(string kw)
        {
            var list = new List<KhachHang>();

            string sql = @"
SELECT DienThoai,
       TenKhach AS HoVaTen,
       DiaChi,
       Phai AS GioiTinh,
       MaNV
FROM dbo.KhachHang
WHERE DienThoai LIKE @kw OR TenKhach LIKE @kw";

            using var conn = new SqlConnection(DbConfig.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kw", "%" + (kw ?? "") + "%");

            conn.Open();
            using var rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                list.Add(new KhachHang
                {
                    DienThoai = rd["DienThoai"]?.ToString(),
                    HoVaTen = rd["HoVaTen"]?.ToString(),
                    DiaChi = rd["DiaChi"]?.ToString(),
                    GioiTinh = rd["GioiTinh"]?.ToString(),
                    MaNV = rd["MaNV"]?.ToString()
                });
            }

            return list;
        }
    }
}
