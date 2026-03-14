using System.Data;
using DAL_QLBanHang.Repositories;

namespace BUS_QLBanHang
{
    public class BUS_HoaDonXem
    {
        private readonly DAL_HoaDonXem _dal = new DAL_HoaDonXem();

        public DataTable GetAllHoaDon() => _dal.GetAllHoaDon();
        public DataTable GetHoaDonByMaNV(string maNV) => _dal.GetHoaDonByMaNV(maNV);
        public DataTable GetHoaDonCTByMaHD(int maHD) => _dal.GetHoaDonCTByMaHD(maHD);
    }
}
