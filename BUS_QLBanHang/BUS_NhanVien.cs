using System.Collections.Generic;
using DAL_QLBanHang.Repositories;
using DTO_QLBanHang.Models;

namespace BUS_QLBanHang
{
    public class BUS_NhanVien
    {
        private readonly DAL_NhanVien _dal = new DAL_NhanVien();

        public List<NhanVien> GetAll() => _dal.GetAll();
        public List<NhanVien> Search(string keyword) => _dal.Search(keyword);

        public int Insert(NhanVien nv) => _dal.Insert(nv);
        public int Update(NhanVien nv) => _dal.Update(nv);
        public int Delete(string email) => _dal.Delete(email);

        // ✅ reset mật khẩu THUẦN
        public int ResetPassword(string email, string newPlain)
            => _dal.ResetPassword(email, newPlain);
        public bool DoiMatKhau(string maNv, string mkCu, string mkMoi)
           => _dal.DoiMatKhau(maNv, mkCu, mkMoi);
    }
}
