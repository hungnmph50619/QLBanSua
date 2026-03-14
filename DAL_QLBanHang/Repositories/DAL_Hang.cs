using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL_QLBanHang.Helpers;
using DTO_QLBanHang.Models;
using Microsoft.Data.SqlClient;

namespace DAL_QLBanHang
{
    public class DAL_Hang
    {
        public List<Hang> GetAll()
        {
            var dt = DbHelper.Query(@"
        SELECT MaHang, TenHang, SoLuong, DonGiaNhap, DonGiaBan, HinhAnh, GhiChu, MaNV
        FROM dbo.Hang
        ORDER BY MaHang DESC");

            var list = new List<Hang>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new Hang
                {
                    MaHang = Convert.ToInt32(r["MaHang"]),
                    TenHang = r["TenHang"]?.ToString() ?? "",
                    SoLuong = Convert.ToInt32(r["SoLuong"]),
                    DonGiaNhap = Convert.ToDecimal(r["DonGiaNhap"]),
                    DonGiaBan = Convert.ToDecimal(r["DonGiaBan"]),
                    HinhAnh = r["HinhAnh"]?.ToString(),
                    GhiChu = r["GhiChu"]?.ToString(),
                    MaNV = r["MaNV"]?.ToString() ?? ""
                });
            }
            return list;
        }

        public List<Hang> Search(string keyword)
        {
            var dt = DbHelper.Query(@"
                SELECT MaHang, TenHang, SoLuong, DonGiaNhap, DonGiaBan, HinhAnh, GhiChu
                FROM dbo.Hang
                WHERE TenHang LIKE @kw OR CAST(MaHang AS NVARCHAR(20)) LIKE @kw
                ORDER BY MaHang DESC",
                new SqlParameter("@kw", "%" + keyword + "%"));

            var list = new List<Hang>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new Hang
                {
                    MaHang = Convert.ToInt32(r["MaHang"]),
                    TenHang = r["TenHang"]?.ToString() ?? "",
                    SoLuong = Convert.ToInt32(r["SoLuong"]),
                    DonGiaNhap = Convert.ToDecimal(r["DonGiaNhap"]),
                    DonGiaBan = Convert.ToDecimal(r["DonGiaBan"]),
                    HinhAnh = r["HinhAnh"]?.ToString(),
                    GhiChu = r["GhiChu"]?.ToString(),
                });
            }
            return list;
        }

        public int Insert(Hang h)
        {
            string sql = @"
INSERT INTO dbo.Hang(TenHang, SoLuong, DonGiaNhap, DonGiaBan, GhiChu, MaNV)
VALUES(@TenHang, @SoLuong, @DonGiaNhap, @DonGiaBan, @GhiChu, @MaNV)";

            return DbHelper.Execute(sql,
                new SqlParameter("@TenHang", h.TenHang),
                new SqlParameter("@SoLuong", h.SoLuong),
                new SqlParameter("@DonGiaNhap", h.DonGiaNhap),
                new SqlParameter("@DonGiaBan", h.DonGiaBan),
                new SqlParameter("@GhiChu", (object?)h.GhiChu ?? DBNull.Value),
                new SqlParameter("@MaNV", h.MaNV) // bắt buộc có
            );
        }

        public int Update(Hang h)
        {
            return DbHelper.Execute(@"
                UPDATE dbo.Hang
                SET TenHang=@TenHang, SoLuong=@SoLuong, DonGiaNhap=@DonGiaNhap, DonGiaBan=@DonGiaBan,
                    HinhAnh=@HinhAnh, GhiChu=@GhiChu
                WHERE MaHang=@MaHang",
                new SqlParameter("@MaHang", h.MaHang),
                new SqlParameter("@TenHang", h.TenHang),
                new SqlParameter("@SoLuong", h.SoLuong),
                new SqlParameter("@DonGiaNhap", h.DonGiaNhap),
                new SqlParameter("@DonGiaBan", h.DonGiaBan),
                new SqlParameter("@HinhAnh", (object?)h.HinhAnh ?? DBNull.Value),
                new SqlParameter("@GhiChu", (object?)h.GhiChu ?? DBNull.Value)
            );
        }

        public int Delete(int maHang)
        {
            return DbHelper.Execute("DELETE dbo.Hang WHERE MaHang=@MaHang",
                new SqlParameter("@MaHang", maHang));
        }
    }
}
