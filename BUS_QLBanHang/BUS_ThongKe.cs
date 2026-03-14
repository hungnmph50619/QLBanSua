using System;
using System.Data;
using DAL_QLBanHang.Repositories;

namespace BUS_QLBanHang
{
    public class BUS_ThongKe
    {
        private readonly DAL_ThongKe _dal = new DAL_ThongKe();

        public DataTable DoanhThuTheoNgay(DateTime from, DateTime to)
            => _dal.DoanhThuTheoNgay(from, to);

        public DataTable DoanhThuTheoThang(int year)
            => _dal.DoanhThuTheoThang(year);

        public DataTable TopSanPham(DateTime from, DateTime to, int topN)
            => _dal.TopSanPham(from, to, topN);

        public DataTable DoanhThuTheoNhanVien(DateTime from, DateTime to)
            => _dal.DoanhThuTheoNhanVien(from, to);
    }
}
