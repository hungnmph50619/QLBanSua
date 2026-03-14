using BUS_QLBanHang;
using DTO_QLBanHang.Models;
using System;
using System.Windows.Forms;

namespace GUI_QLBanSua
{
    public partial class FrmKhachHang : Form
    {
        private readonly BUS_KhachHang _bus = new BUS_KhachHang();
        private string _selectedPhone = "";

        public FrmKhachHang()
        {
            InitializeComponent();

            this.Load += FrmKhachHang_Load;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;

            // Nếu Designer đã gán event rồi thì tránh bị chạy 2 lần
            btnThem.Click -= btnThem_Click_1;
            btnThem.Click -= btnThem_Click;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTimKiem.Click += btnTimKiem_Click;
        }

        private void FrmKhachHang_Load(object? sender, EventArgs e)
        {
            SetupGrid();
            LoadData();
            ClearForm();
        }

        private void SetupGrid()
        {
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.AllowUserToAddRows = false;

            dgvKhachHang.AutoGenerateColumns = true;
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = _bus.GetAll();
        }

        private void ClearForm()
        {
            _selectedPhone = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            rdoNam.Checked = true;
        }

        private bool TryGetInput(out KhachHang kh, bool includeKey)
        {
            kh = new KhachHang();

            var phone = txtDienThoai.Text.Trim();
            var name = txtHoTen.Text.Trim();
            var addr = txtDiaChi.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Nhập Điện thoại!");
                txtDienThoai.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Nhập Họ và tên!");
                txtHoTen.Focus();
                return false;
            }

            if (includeKey && string.IsNullOrWhiteSpace(_selectedPhone))
            {
                MessageBox.Show("Chọn 1 dòng để sửa/xóa!");
                return false;
            }

            // Nếu sửa thì KHÔNG cho đổi số điện thoại (khóa chính)
            kh.DienThoai = includeKey ? _selectedPhone : phone;
            kh.HoVaTen = name;
            kh.DiaChi = addr;
            kh.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";

            return true;
        }

        private void dgvKhachHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvKhachHang.Rows[e.RowIndex];

            txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString();
            txtHoTen.Text = row.Cells["HoVaTen"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();

            var gt = row.Cells["GioiTinh"].Value?.ToString();
            rdoNam.Checked = (gt == "Nam");
            rdoNu.Checked = (gt == "Nữ");

            _selectedPhone = txtDienThoai.Text.Trim();
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!TryGetInput(out var kh, includeKey: false)) return;

            int kq = _bus.Insert(kh);

            if (kq == -1)
            {
                MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập số khác!",
                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            if (kq > 0)
            {
                LoadData();
                ClearForm();
                MessageBox.Show("Thêm khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (!TryGetInput(out var kh, includeKey: true)) return;

            int kq = _bus.Update(kh);
            if (kq > 0)
            {
                LoadData();
                MessageBox.Show("Sửa OK!");
            }
            else MessageBox.Show("Sửa thất bại!");
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedPhone))
            {
                MessageBox.Show("Chọn 1 dòng để xóa!");
                return;
            }

            if (MessageBox.Show("Xóa khách hàng này nha?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int kq = _bus.Delete(_selectedPhone);
            if (kq > 0)
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
            dgvKhachHang.DataSource = string.IsNullOrWhiteSpace(kw) ? _bus.GetAll() : _bus.Search(kw);
        }

        // Nếu bạn lỡ tạo event này trong Designer thì để trống cũng được
        private void btnThem_Click_1(object sender, EventArgs e) { }
    }
}
