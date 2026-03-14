using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DTO_QLBanHang.Models;
using BUS_QLBanHang;

namespace GUI_QLBanSua
{
    public partial class FrmBanHang : Form
    {
        private readonly BUS_Hang _busHang = new BUS_Hang();
        private readonly BUS_HoaDon _busHoaDon = new BUS_HoaDon();
        private readonly BUS_KhachHang _busKhachHang = new BUS_KhachHang();

        private Hang? _hangDangChon = null;
        private readonly List<GioHangItem> _gio = new();

        private readonly string _maNv;

        // ====== MENU CHUỘT PHẢI + XOÁ/GIẢM GIỎ HÀNG ======
        private readonly ContextMenuStrip _gioMenu = new ContextMenuStrip();

        public FrmBanHang(string maNv)
        {
            InitializeComponent();
            _maNv = maNv;

            button1.Click -= btnThemVaoGio_Click;
            button1.Click += btnThemVaoGio_Click;

            txtKhachDua.KeyPress += txtKhachDua_KeyPress;   // ✅ THÊM DÒNG NÀY
            txtKhachDua.TextChanged += txtKhachDua_TextChanged;

            btnThanhToan.Click += btnThanhToan_Click;
            button1.Click -= button1_Click;
        }

        private void FrmBanHang_Load(object? sender, EventArgs e)
        {
            nudSoLuong.Value = 1;

            LoadHangLenGrid();
            LoadGioLenGrid();
            UpdateTongTienUI();

            SetupGioHangActions();
        }

        private void LoadHangLenGrid()
        {
            var ds = _busHang.GetAll();
            dgvHang.DataSource = ds;

            if (dgvHang.Columns.Contains("Id"))
                dgvHang.Columns["Id"].Visible = false;
        }

        private void dgvHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _hangDangChon = dgvHang.Rows[e.RowIndex].DataBoundItem as Hang;
        }

        // Designer hay gọi button1_Click -> mình giữ lại để khỏi lỗi (nếu có)
     

        // =========================
        // 1) THÊM VÀO GIỎ (KHÔNG TRÙNG)
        // =========================
        private void btnThemVaoGio_Click(object? sender, EventArgs e)
        {
            if (_hangDangChon == null)
            {
                MessageBox.Show("Bạn chọn 1 hàng bên danh sách trước nha.");
                return;
            }

            int sl = (int)nudSoLuong.Value;
            if (sl <= 0)
            {
                MessageBox.Show("Số lượng phải >= 1.");
                return;
            }

            // Lấy tồn kho mới nhất từ DB (tránh dùng tồn kho cũ)
            int tonKho = GetTonKho(_hangDangChon.MaHang);

            if (sl > tonKho)
            {
                MessageBox.Show($"Không đủ hàng. Tồn kho còn: {tonKho}");
                return;
            }

            var item = _gio.FirstOrDefault(x => x.MaHang == _hangDangChon.MaHang);

            if (item == null)
            {
                _gio.Add(new GioHangItem
                {
                    MaHang = _hangDangChon.MaHang,
                    TenHang = _hangDangChon.TenHang,
                    DonGia = _hangDangChon.DonGiaBan,
                    SoLuong = sl
                });
            }
            else
            {
                if (item.SoLuong + sl > tonKho)
                {
                    MessageBox.Show($"Bạn thêm quá tồn kho. Tối đa còn: {tonKho}");
                    return;
                }
                item.SoLuong += sl;
            }

            LoadGioLenGrid();
            UpdateTongTienUI();
        }

        // =========================
        // 2) HIỂN THỊ GIỎ
        // =========================

        private void LoadGioLenGrid()
        {
            dgvGioHang.DataSource = null;
            dgvGioHang.DataSource = _gio.Select(x => new
            {
                x.MaHang,
                x.TenHang,
                x.SoLuong,
                x.DonGia,
                ThanhTien = x.SoLuong * x.DonGia
            }).ToList();
            // ✅ Ẩn cột Hình ảnh
            if (dgvHang.Columns.Contains("HinhAnh"))
                dgvHang.Columns["HinhAnh"].Visible = false;
        }

        private void UpdateTongTienUI()
        {
            decimal tong = _gio.Sum(x => x.SoLuong * x.DonGia);
            lblTongTien.Text = $"Tổng: {tong:n0}";
        }
        private decimal GetTongTien()
        {
            return _gio.Sum(x => x.SoLuong * x.DonGia);
        }

        // =========================
        // 3) MENU CHUỘT PHẢI / TĂNG GIẢM / XOÁ
        // =========================
        private void SetupGioHangActions()
        {
            // Right click chọn đúng dòng
            dgvGioHang.MouseDown += (s, e) =>
            {
                if (e.Button != MouseButtons.Right) return;
                var hit = dgvGioHang.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvGioHang.ClearSelection();
                    dgvGioHang.Rows[hit.RowIndex].Selected = true;
                    dgvGioHang.CurrentCell = dgvGioHang.Rows[hit.RowIndex].Cells[0];
                }
            };

            // Double click: giảm 1
            dgvGioHang.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                Giam1();
            };

            // Phím Delete: xoá món
            dgvGioHang.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Delete)
                {
                    XoaMonDangChon();
                    e.Handled = true;
                }
            };

            // Menu chuột phải
            _gioMenu.Items.Clear();
            _gioMenu.Items.Add("Giảm 1", null, (s, e) => Giam1());
            _gioMenu.Items.Add("Tăng 1", null, (s, e) => Tang1());
            _gioMenu.Items.Add(new ToolStripSeparator());
            _gioMenu.Items.Add("Xóa món", null, (s, e) => XoaMonDangChon());
            _gioMenu.Items.Add("Xóa hết giỏ", null, (s, e) => XoaHetGio());

            dgvGioHang.ContextMenuStrip = _gioMenu;
        }

        private int? GetMaHangDangChonTrongGio()
        {
            if (dgvGioHang.CurrentRow == null) return null;

            if (dgvGioHang.Columns.Contains("MaHang"))
            {
                var v = dgvGioHang.CurrentRow.Cells["MaHang"].Value;
                if (v != null && int.TryParse(v.ToString(), out int ma))
                    return ma;
            }

            var v2 = dgvGioHang.CurrentRow.Cells[0].Value;
            if (v2 != null && int.TryParse(v2.ToString(), out int ma2))
                return ma2;

            return null;
        }

        private int GetTonKho(int maHang)
        {
            var h = _busHang.GetAll().FirstOrDefault(x => x.MaHang == maHang);
            return h?.SoLuong ?? 0;
        }

        private void Giam1()
        {
            var ma = GetMaHangDangChonTrongGio();
            if (ma == null) return;

            var item = _gio.FirstOrDefault(x => x.MaHang == ma.Value);
            if (item == null) return;

            item.SoLuong -= 1;
            if (item.SoLuong <= 0) _gio.Remove(item);

            LoadGioLenGrid();
            UpdateTongTienUI();
        }

        private void Tang1()
        {
            var ma = GetMaHangDangChonTrongGio();
            if (ma == null) return;

            var item = _gio.FirstOrDefault(x => x.MaHang == ma.Value);
            if (item == null) return;

            int ton = GetTonKho(item.MaHang);
            if (item.SoLuong + 1 > ton)
            {
                MessageBox.Show($"Không đủ hàng. Tồn kho còn: {ton}");
                return;
            }

            item.SoLuong += 1;

            LoadGioLenGrid();
            UpdateTongTienUI();
        }

        private void XoaMonDangChon()
        {
            var ma = GetMaHangDangChonTrongGio();
            if (ma == null) return;

            var item = _gio.FirstOrDefault(x => x.MaHang == ma.Value);
            if (item == null) return;

            _gio.Remove(item);

            LoadGioLenGrid();
            UpdateTongTienUI();
        }

        private void XoaHetGio()
        {
            if (_gio.Count == 0) return;

            var ok = MessageBox.Show("Xóa hết giỏ hàng hả?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ok != DialogResult.Yes) return;

            _gio.Clear();
            LoadGioLenGrid();
            UpdateTongTienUI();
        }

        // =========================
        // 4) THANH TOÁN (✅ check khách trước để khỏi SQL văng lỗi FK)
        // =========================
        private void btnThanhToan_Click(object? sender, EventArgs e)
        {
            if (_gio.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.");
                return;
            }

            // chuẩn hóa SĐT
            string? sdt = string.IsNullOrWhiteSpace(txtDienThoai.Text)
                ? null
                : txtDienThoai.Text.Trim();

            // check khách trước
            if (!string.IsNullOrWhiteSpace(sdt))
            {
                bool tonTai = _busKhachHang.ExistsByPhone(sdt);
                if (!tonTai)
                {
                    MessageBox.Show(
                        "Khách hàng chưa tồn tại trong hệ thống.\nBạn vui lòng tạo khách hàng trước rồi hãy thanh toán.",
                        "Thiếu khách hàng",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            decimal tong = GetTongTien();

            // tiền khách đưa
            decimal khachDua = 0;
            decimal.TryParse(txtKhachDua.Text, out khachDua);

            // (tuỳ bạn) chặn thanh toán nếu khách đưa < tổng
            if (khachDua < tong)
            {
                MessageBox.Show("Khách đưa chưa đủ tiền!");
                return;
            }

            var hd = new HoaDon
            {
                MaNV = _maNv,
                NgayLap = DateTime.Now,
                DienThoai = sdt,
                TongTien = tong,
                GiamGia = 0,
                ThanhToan = tong,
                GhiChu = null,
                TrangThai = 1
            };

            var cts = _gio.Select(it => new HoaDonChiTiet
            {
                MaHang = it.MaHang,
                SoLuong = it.SoLuong,
                DonGiaBan = it.DonGia
            }).ToList();

            try
            {
                int maHd = _busHoaDon.ThanhToan(hd, cts);

                // bill: build từ giỏ hiện tại (trước khi clear)
                string bill = BuildBillText(maHd, _maNv, sdt, _gio.ToList(), tong, khachDua);
                new FrmBillPreview(bill).ShowDialog(this);

                // xong mới clear
                _gio.Clear();
                LoadGioLenGrid();
                UpdateTongTienUI();
                LoadHangLenGrid();
                txtKhachDua.Text = "";
                MessageBox.Show($"Thanh toán xong! Mã HĐ: {maHd}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thanh toán thất bại: " + ex.Message);
            }
        }
        private void button1_Click(object? sender, EventArgs e)
        {
            btnThemVaoGio_Click(sender, e);
        }
        private void txtKhachDua_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // cho phép phím điều khiển: Backspace, Delete...
            if (char.IsControl(e.KeyChar)) return;

            // chỉ cho nhập số 0-9 (=> chặn luôn dấu '-' và chữ)
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            // ✅ chặn paste dấu '-' hoặc ký tự lạ
            string raw = txtKhachDua.Text;
            string onlyDigits = new string(raw.Where(char.IsDigit).ToArray());
            if (raw != onlyDigits)
            {
                int pos = txtKhachDua.SelectionStart;
                txtKhachDua.Text = onlyDigits;
                txtKhachDua.SelectionStart = Math.Min(pos, txtKhachDua.Text.Length);
            }

            var tong = GetTongTien();

            if (!decimal.TryParse(txtKhachDua.Text, out var khachDua))
            {
                lblTienThoi.Text = "0";
                return;
            }

            var tienThoi = khachDua - tong;
            lblTienThoi.Text = tienThoi.ToString("N0");

        }
        private string BuildBillText(int maHd, string maNv, string? sdt, List<GioHangItem> gio, decimal tong, decimal khachDua)
        {
            var nl = Environment.NewLine;
            decimal tienThoi = khachDua - tong;

            string Line(char c, int n) => new string(c, n);

            string HeaderCenter(string t, int width = 34)
            {
                if (t.Length >= width) return t;
                int left = (width - t.Length) / 2;
                return new string(' ', left) + t;
            }

            // Dòng item: Tên | SL | Giá | TT
            string ItemLine(string ten, int sl, decimal gia, decimal tt)
            {
                ten = ten.Length > 14 ? ten.Substring(0, 14) : ten;
                return $"{ten.PadRight(14)} {sl.ToString().PadLeft(2)} {gia.ToString("N0").PadLeft(7)} {tt.ToString("N0").PadLeft(8)}";
            }

            var text = "";
            text += HeaderCenter("HÓA ĐƠN BÁN HÀNG") + nl;
            text += Line('-', 34) + nl;
            text += $"Số HĐ: {maHd}" + nl;
            text += $"Ngày: {DateTime.Now:dd/MM/yyyy HH:mm}" + nl;
            text += $"Thu ngân: {maNv}" + nl;
            text += $"Khách: {(string.IsNullOrWhiteSpace(sdt) ? "Khách lẻ" : sdt)}" + nl;
            text += Line('-', 34) + nl;
            text += $"{"Mặt hàng".PadRight(14)} {"SL",2} {"Giá",7} {"T.Tiền",8}" + nl;
            text += Line('-', 34) + nl;

            foreach (var it in gio)
            {
                var tt = it.SoLuong * it.DonGia;
                text += ItemLine(it.TenHang, it.SoLuong, it.DonGia, tt) + nl;
            }

            text += Line('-', 34) + nl;
            text += $"Tổng: {tong:N0}".PadLeft(34) + nl;
            text += $"Khách đưa: {khachDua:N0}".PadLeft(34) + nl;
            text += $"Tiền thối: {tienThoi:N0}".PadLeft(34) + nl;
            text += Line('-', 34) + nl;
            text += HeaderCenter("Cảm ơn Quý khách!") + nl;

            return text;
        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }
    }

    public class GioHangItem
    {
        public int MaHang { get; set; }
        public string TenHang { get; set; } = "";
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
