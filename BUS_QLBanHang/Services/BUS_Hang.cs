using System.Collections.Generic;
using DAL_QLBanHang;
using DTO_QLBanHang.Models;

namespace BUS_QLBanHang
{
    public class BUS_Hang
    {
        private readonly DAL_Hang _dal = new DAL_Hang();

        public List<Hang> GetAll() => _dal.GetAll();
        public List<Hang> Search(string kw) => _dal.Search(kw);
       
        public int Update(Hang h) => _dal.Update(h);
        public int Delete(int maHang) => _dal.Delete(maHang);
        public int Insert(Hang h)
        {
            h.MaNV = DAL_QLBanHang.Helpers.AppSession.MaNV;

            if (string.IsNullOrWhiteSpace(h.MaNV))
                throw new Exception("Chưa có thông tin nhân viên đăng nhập (MaNV).");

            return _dal.Insert(h);
        }


    }


}
