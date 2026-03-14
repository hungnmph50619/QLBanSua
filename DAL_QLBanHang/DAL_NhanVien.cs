using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO_QLBanHang.Models;
using DAL_QLBanHang.Helpers;

namespace DAL_QLBanHang.Repositories
{
    public class DAL_NhanVien
    {
        public List<NhanVien> GetAll()
        {
            var dt = DbHelper.Query(
                "SELECT MaNV, Email, TenNV, DiaChi, VaiTro, TinhTrang, MatKhau FROM dbo.NhanVien"
            );
            return ToList(dt);
        }

        public List<NhanVien> Search(string keyword)
        {
            keyword ??= "";
            var dt = DbHelper.Query(
                "SELECT MaNV, Email, TenNV, DiaChi, VaiTro, TinhTrang, MatKhau " +
                "FROM dbo.NhanVien " +
                "WHERE MaNV LIKE @kw OR Email LIKE @kw OR TenNV LIKE @kw",
                new SqlParameter("@kw", $"%{keyword}%")
            );
            return ToList(dt);
        }

        public int Insert(NhanVien nv)
        {
            try
            {
                int nextNumber = Convert.ToInt32(DbHelper.Scalar(@"
SELECT ISNULL(MAX(CAST(SUBSTRING(MaNV, 3, 20) AS INT)), 0) + 1
FROM dbo.NhanVien
WHERE MaNV LIKE 'NV%';
"));

                string maNV = "NV" + nextNumber.ToString("0000");

                string sql = @"
INSERT INTO dbo.NhanVien(MaNV, Email, TenNV, DiaChi, VaiTro, TinhTrang, MatKhau)
VALUES(@MaNV, @Email, @TenNV, @DiaChi, @VaiTro, @TinhTrang, @MatKhau)";

                return DbHelper.Execute(sql,
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@Email", (nv.Email ?? "").Trim()),
                    new SqlParameter("@TenNV", (nv.TenNV ?? "").Trim()),
                    new SqlParameter("@DiaChi", (nv.DiaChi ?? "").Trim()),
                    new SqlParameter("@VaiTro", nv.VaiTro),
                    new SqlParameter("@TinhTrang", nv.TinhTrang),
                    new SqlParameter("@MatKhau", string.IsNullOrWhiteSpace(nv.MatKhau) ? "123456" : nv.MatKhau)
                );
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // 2627/2601 = trùng PK hoặc UNIQUE
                // Nếu bạn có unique constraint tên UQ_Email thì bắt đúng luôn:
                if (ex.Message.Contains("UQ_Email", StringComparison.OrdinalIgnoreCase)
                    || ex.Message.Contains("Email", StringComparison.OrdinalIgnoreCase))
                {
                    return -1; // trùng email
                }

                return -2; // trùng khóa khác
            }
            catch
            {
                return 0; // lỗi khác
            }
        }

        public bool DoiMatKhau(string maNv, string mkCu, string mkMoi)
        {
            var mkDbObj = DbHelper.Scalar(
                "SELECT MatKhau FROM dbo.NhanVien WHERE MaNV=@ma",
                new SqlParameter("@ma", maNv)
            );

            var mkDb = mkDbObj?.ToString();
            if (string.IsNullOrEmpty(mkDb)) return false;
            if (mkDb != mkCu) return false;

            int n = DbHelper.Execute(
                "UPDATE dbo.NhanVien SET MatKhau=@mkmoi WHERE MaNV=@ma",
                new SqlParameter("@mkmoi", mkMoi),
                new SqlParameter("@ma", maNv)
            );

            return n > 0;
        }

        public int Update(NhanVien nv)
        {
            return DbHelper.Execute(
                "UPDATE dbo.NhanVien SET TenNV=@TenNV, DiaChi=@DiaChi, VaiTro=@VaiTro, TinhTrang=@TinhTrang " +
                "WHERE Email=@Email",
                new SqlParameter("@Email", nv.Email ?? ""),
                new SqlParameter("@TenNV", nv.TenNV ?? ""),
                new SqlParameter("@DiaChi", nv.DiaChi ?? ""),
                new SqlParameter("@VaiTro", nv.VaiTro),
                new SqlParameter("@TinhTrang", nv.TinhTrang)
            );
        }

        public int Delete(string email)
        {
            return DbHelper.Execute(
                "DELETE FROM dbo.NhanVien WHERE Email=@Email",
                new SqlParameter("@Email", email ?? "")
            );
        }

        public int ResetPassword(string email, string newPlain)
        {
            return DbHelper.Execute(
                "UPDATE dbo.NhanVien SET MatKhau=@MatKhau WHERE Email=@Email",
                new SqlParameter("@Email", email ?? ""),
                new SqlParameter("@MatKhau", newPlain ?? "")
            );
        }

        private static List<NhanVien> ToList(DataTable dt)
        {
            var list = new List<NhanVien>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new NhanVien
                {
                    MaNV = r.Table.Columns.Contains("MaNV") ? (r["MaNV"]?.ToString() ?? "") : "",
                    Email = r["Email"]?.ToString() ?? "",
                    TenNV = r["TenNV"]?.ToString() ?? "",
                    DiaChi = r["DiaChi"]?.ToString() ?? "",
                    VaiTro = Convert.ToInt32(r["VaiTro"]),
                    TinhTrang = Convert.ToInt32(r["TinhTrang"]),
                    MatKhau = r["MatKhau"]?.ToString() ?? ""
                });
            }
            return list;
        }
    }
}
