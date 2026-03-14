using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL_QLBanHang.Helpers
{
    public static class DbHelper
    {
        public static DataTable Query(string sql, params SqlParameter[] ps)
        {
            using var conn = new SqlConnection(DbConfig.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable ExecuteProcToDataTable(string procName, params SqlParameter[] ps)
        {
            using var conn = new SqlConnection(DbConfig.ConnectionString);
            using var cmd = new SqlCommand(procName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            if (ps != null && ps.Length > 0)
                cmd.Parameters.AddRange(ps);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static int Execute(string sql, params SqlParameter[] ps)
        {
            using var conn = new SqlConnection(DbConfig.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public static object Scalar(string sql, params SqlParameter[] ps)
        {
            using var conn = new SqlConnection(DbConfig.ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);

            conn.Open();
            return cmd.ExecuteScalar();
        }
    }
}
