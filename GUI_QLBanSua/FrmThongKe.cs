using System;
using System.Windows.Forms;
using BUS_QLBanHang;

namespace GUI_QLBanSua
{
    public partial class FrmThongKe : Form
    {
        private readonly BUS_ThongKe _bus = new BUS_ThongKe();

        public FrmThongKe()
        {
            InitializeComponent();

            // Gán event ở code để khỏi sợ Designer bị mất
            this.Load += FrmThongKe_Load;
            btnTai.Click += btnTai_Click;
            

            // Mặc định
            nudTop.Minimum = 1;
            nudTop.Maximum = 100;
            nudTop.Value = 10;

            SetupGrid(dgvNgay);
            SetupGrid(dgvThang);
            SetupGrid(dgvTop);
            SetupGrid(dgvNV);
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            // mặc định 30 ngày gần nhất
            dtTo.Value = DateTime.Today;
            dtFrom.Value = DateTime.Today.AddDays(-30);

            TaiTheoKhoangNgay();
            TaiTheoThang();
        }

        private void btnTai_Click(object sender, EventArgs e)
        {
            TaiTheoKhoangNgay();
        }

        private void btnTaiThang_Click(object sender, EventArgs e)
        {
            TaiTheoThang();
        }

        private void TaiTheoKhoangNgay()
        {
            DateTime from = dtFrom.Value.Date;
            DateTime to = dtTo.Value.Date.AddDays(1);

            var dtNgay = _bus.DoanhThuTheoNgay(from, to);
            BindGrid(dgvNgay, dtNgay);

            int topN = (int)nudTop.Value;
            var dtTop = _bus.TopSanPham(from, to, topN);
            BindGrid(dgvTop, dtTop);

            var dtNV = _bus.DoanhThuTheoNhanVien(from, to);
            BindGrid(dgvNV, dtNV);

            FormatMoneyColumns(dgvNgay, "DoanhThu");
            FormatMoneyColumns(dgvTop, "TongTien");
            FormatMoneyColumns(dgvNV, "DoanhThu");

        }

        private void TaiTheoThang()
        {
            int year = dtTo.Value.Year;

            var dtThang = _bus.DoanhThuTheoThang(year);
            BindGrid(dgvThang, dtThang);

            FormatMoneyColumns(dgvThang, "DoanhThu");

        }

        private void SetupGrid(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.AutoGenerateColumns = true;

            // QUAN TRỌNG: xoá các cột designer (nếu có)
            dgv.DataSource = null;
            dgv.Columns.Clear();
        }
        private void BindGrid(DataGridView dgv, object data)
        {
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = null;
            dgv.Columns.Clear();
            dgv.DataSource = data;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            // không cần làm gì
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            // không cần làm gì
        }

        private void FormatMoneyColumns(DataGridView dgv, string colName)
        {
            if (dgv.Columns.Contains(colName))
            {
                dgv.Columns[colName].DefaultCellStyle.Format = "N0";
                dgv.Columns[colName].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btnTai_Click_1(object sender, EventArgs e)
        {

        }
    }
}
