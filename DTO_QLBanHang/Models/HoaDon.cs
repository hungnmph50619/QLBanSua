public class HoaDon
{
    public int MaHD { get; set; }
    public DateTime NgayLap { get; set; }
    public string MaNV { get; set; } = "";
    public string? DienThoai { get; set; }   // null nếu khách lẻ
    public decimal TongTien { get; set; }
    public decimal GiamGia { get; set; }
    public decimal ThanhToan { get; set; }
    public string? GhiChu { get; set; }
    public byte TrangThai { get; set; } = 1;
}
