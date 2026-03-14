using BUS_QLBanHang;
using DTO_QLBanHang.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace GUI_QLBanSua
{
    public partial class FrmSanPham : Form
    {
        private readonly BUS_Hang _bus = new BUS_Hang();
        private int _selectedMaHang = 0;

        public FrmSanPham()
        {
            InitializeComponent();
            txtMaHang.ReadOnly = true;
            txtMaHang.TabStop = false;  // optional: bỏ focus

            // gán event cho chắc
            this.Load += FrmSanPham_Load;
            dgvHang.CellClick += dgvHang_CellClick;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
           
            btnTimKiem.Click += btnTimKiem_Click;

        }

        private void FrmSanPham_Load(object? sender, EventArgs e)
        {
            SetupGrid();
            LoadData();
            ClearForm();
        }

        private void SetupGrid()
        {
            dgvHang.ReadOnly = true;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.MultiSelect = false;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.AutoGenerateColumns = true; // làm nhanh cho lẹ
        }

        private void LoadData()
        {
            dgvHang.DataSource = _bus.GetAll();

            // Ẩn cột HinhAnh nếu có
            if (dgvHang.Columns.Contains("HinhAnh"))
                dgvHang.Columns["HinhAnh"].Visible = false;
        }

        private void ClearForm()
        {
            _selectedMaHang = 0;
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            txtSoLuong.Text = "";
            txtDonGiaNhap.Text = "";
            txtDonGiaBan.Text = "";
            rtbGhiChu.Text = "";


        }

        private bool TryGetInput(out Hang hang, bool includeId)
        {
            hang = new Hang();

            var ten = txtTenHang.Text.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Nhập Tên hàng!");
                txtTenHang.Focus();
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên >= 0");
                txtSoLuong.Focus();
                return false;
            }

            // parse decimal (cho phép 12000 hoặc 12,000 hoặc 12.000 tùy máy)
            if (!decimal.TryParse(txtDonGiaNhap.Text.Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal giaNhap))
            {
                MessageBox.Show("Đơn giá nhập không hợp lệ!");
                txtDonGiaNhap.Focus();
                return false;
            }
            if (!decimal.TryParse(txtDonGiaBan.Text.Trim(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal giaBan))
            {
                MessageBox.Show("Đơn giá bán không hợp lệ!");
                txtDonGiaBan.Focus();
                return false;
            }

            hang.TenHang = ten;
            hang.SoLuong = soLuong;
            hang.DonGiaNhap = giaNhap;
            hang.DonGiaBan = giaBan;
            hang.GhiChu = rtbGhiChu.Text.Trim();


            if (includeId)
            {
                if (!int.TryParse(txtMaHang.Text.Trim(), out int ma) || ma <= 0)
                {
                    MessageBox.Show("Mã hàng không hợp lệ!");
                    return false;
                }
                hang.MaHang = ma;
            }

            return true;
        }

        private void dgvHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvHang.Rows[e.RowIndex];

            // nếu dgv auto-generate theo Hang thì cell name đúng property
            txtMaHang.Text = row.Cells["MaHang"].Value?.ToString();
            txtTenHang.Text = row.Cells["TenHang"].Value?.ToString();
            txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
            txtDonGiaNhap.Text = row.Cells["DonGiaNhap"].Value?.ToString();
            txtDonGiaBan.Text = row.Cells["DonGiaBan"].Value?.ToString();
            rtbGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();





            int.TryParse(txtMaHang.Text, out _selectedMaHang);
        }


        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!TryGetInput(out var h, includeId: false)) return;

            var n = _bus.Insert(h);
            if (n > 0)
            {
                LoadData();
                ClearForm();
                MessageBox.Show("Thêm OK!");
            }
            else MessageBox.Show("Thêm thất bại!");
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (_selectedMaHang <= 0)
            {
                MessageBox.Show("Chọn 1 dòng để sửa!");
                return;
            }

            txtMaHang.Text = _selectedMaHang.ToString();
            if (!TryGetInput(out var h, includeId: true)) return;

            var n = _bus.Update(h);
            if (n > 0)
            {
                LoadData();
                MessageBox.Show("Sửa OK!");
            }
            else MessageBox.Show("Sửa thất bại!");
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (_selectedMaHang <= 0)
            {
                MessageBox.Show("Chọn 1 dòng để xóa!");
                return;
            }

            if (MessageBox.Show("Xóa sản phẩm này nha?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var n = _bus.Delete(_selectedMaHang);
            if (n > 0)
            {
                LoadData();
                ClearForm();
                MessageBox.Show("Xóa OK!");
            }
            else MessageBox.Show("Xóa thất bại!");
        }

        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            var kw = txtTimKiem.Text.Trim();
            dgvHang.DataSource = string.IsNullOrWhiteSpace(kw) ? _bus.GetAll() : _bus.Search(kw);

            if (dgvHang.Columns.Contains("HinhAnh"))
                dgvHang.Columns["HinhAnh"].Visible = false;
        }

        private void FrmSanPham_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (_selectedMaHang <= 0)
            {
                MessageBox.Show("Chọn 1 dòng để xóa!");
                return;
            }

            if (MessageBox.Show("Xóa sản phẩm này nha?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                var n = _bus.Delete(_selectedMaHang);
                if (n > 0)
                {
                    LoadData();
                    ClearForm();
                    MessageBox.Show("Xóa OK!");
                }
                else MessageBox.Show("Xóa thất bại!");
            }
            catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show(
                    "Không xóa được vì sản phẩm này đã phát sinh trong hóa đơn (HoaDonChiTiet).\n" +
                    "Gợi ý: Xóa chi tiết hóa đơn liên quan hoặc chuyển sang trạng thái 'Ngừng bán'.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
