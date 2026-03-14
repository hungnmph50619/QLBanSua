namespace DTO_QLBanHang.Models
{
    public class Hang
    {
        public int MaHang { get; set; }
        public string TenHang { get; set; } = "";
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public string? HinhAnh { get; set; }
        public string? GhiChu { get; set; }
        public string MaNV { get; set; } = "";

    }
}
