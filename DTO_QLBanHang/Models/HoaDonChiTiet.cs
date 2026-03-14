using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang.Models
{
    public class HoaDonChiTiet
    {
        public int MaHD { get; set; }
        public int MaHang { get; set; }
        public int SoLuong { get; set; }

        public decimal DonGiaBan { get; set; }   // ✅ đúng tên cột DB
        public decimal ThanhTien { get; set; }   // (optional) DB computed, để cũng được

    }
}
