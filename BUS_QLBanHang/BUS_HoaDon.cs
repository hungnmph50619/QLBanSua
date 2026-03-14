using System.Collections.Generic;
using DAL_QLBanHang.Repositories;
using DTO_QLBanHang.Models;

namespace BUS_QLBanHang
{
    public class BUS_HoaDon
    {
        private readonly DAL_HoaDon _dal = new DAL_HoaDon();

        public int ThanhToan(HoaDon hd, List<HoaDonChiTiet> cts)
        {
            return _dal.ThanhToan(hd, cts);
        }
    }
}
