namespace DTO_QLBanHang.Models
{
    public class KhachHang
    {
        public string DienThoai { get; set; } = "";
        public string HoVaTen { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string GioiTinh { get; set; } = ""; // "Nam"/"Nữ"
        public string? MaNV { get; set; }

    }
}
