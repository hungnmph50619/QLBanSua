using BUS_QLBanHang;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_QLBanSua
{
    public partial class FrmHoaDon : Form
    {
        private readonly BUS_HoaDonXem _bus = new BUS_HoaDonXem();

        private readonly string _maNv;
        private readonly int _vaiTro; // 1 = admin, 0 = nhân viên

        public FrmHoaDon(string maNv, int vaiTro)
        {
            InitializeComponent();
            _maNv = maNv;
            _vaiTro = vaiTro;
        }

        private void FrmHoaDon_Load(object? sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            DataTable dt;
            dgvHoaDon.AllowUserToAddRows = false;

            if (_vaiTro == 1) // admin
                dt = _bus.GetAllHoaDon();
            else
                dt = _bus.GetHoaDonByMaNV(_maNv);

            dgvHoaDon.DataSource = dt;

            // ✅ Ẩn cột TrangThai
            if (dgvHoaDon.Columns.Contains("TrangThai"))
                dgvHoaDon.Columns["TrangThai"].Visible = false;

            // clear chi tiết khi load lại
            dgvHoaDonCT.DataSource = null;
            lblInfo.Text = "Tổng tiền / Mã HĐ đang chọn";
        }

        // Designer của bạn đang gán dgvHoaDon.CellClick += dgvHoaDon_CellClick_1;
        private void dgvHoaDon_CellClick_1(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cell = dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"];
            if (cell == null || cell.Value == null || cell.Value == DBNull.Value) return;

            int maHd = Convert.ToInt32(cell.Value);

            var dtCT = _bus.GetHoaDonCTByMaHD(maHd);
            dgvHoaDonCT.DataSource = dtCT;

            var tongTienObj = dgvHoaDon.Rows[e.RowIndex].Cells["TongTien"].Value;
            decimal tongTien = 0;
            if (tongTienObj != null && tongTienObj != DBNull.Value &&
                decimal.TryParse(tongTienObj.ToString(), out var t))
                tongTien = t;

            lblInfo.Text = $"Mã HĐ: {maHd} | Tổng tiền: {tongTien:n0}";
        }
    }
}
