using DAL_QLBanHang.Helpers;
using DAL_QLBanHang.Repositories;
using DTO_QLBanHang.Models;
using System.Collections.Generic;

namespace BUS_QLBanHang
{
    public class BUS_KhachHang
    {
        private readonly DAL_KhachHang _dal = new DAL_KhachHang();

        public List<KhachHang> GetAll()
            => _dal.GetAll();

        public List<KhachHang> Search(string kw)
            => _dal.Search(kw);

        public int Insert(KhachHang k)
        {
            k.MaNV = AppSession.MaNV;
            if (string.IsNullOrWhiteSpace(k.MaNV))
                throw new Exception("Chưa có thông tin nhân viên đăng nhập (MaNV).");

            return _dal.Insert(k);
        }

        public int Update(KhachHang kh)
            => _dal.Update(kh);

        public int Delete(string dienThoai)
            => _dal.Delete(dienThoai);

        public bool ExistsByPhone(string dienThoai)
            => _dal.ExistsByPhone(dienThoai);
    }
}
