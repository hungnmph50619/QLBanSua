using BUS_QLBanHang;
using DTO_QLBanHang.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_QLBanSua
{
    public partial class FrmQuanLyNhanVien : Form
    {
        private readonly BUS_NhanVien _bus = new BUS_NhanVien();
        private string _selectedEmail = null;

        public FrmQuanLyNhanVien()
        {
            InitializeComponent();

            // Gán event chắc kèo (tránh design không link event)
            this.Load += FrmQuanLyNhanVien_Load;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTimKiem.Click += btnTimKiem_Click;

            dgvNhanVien.CellClick += dgvNhanVien_CellClick;

            // UI grid cho dễ dùng
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.AutoGenerateColumns = true;
        }

        private void FrmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            rdoNhanVien.Checked = true;
            rdoHoatDong.Checked = true;
            txtEmail.ReadOnly = false;

            LoadData();
        }

        private void LoadData()
        {
            var list = _bus.GetAll();
            dgvNhanVien.DataSource = null;
            dgvNhanVien.DataSource = list;

            ClearForm();
        }

        private void ClearForm()
        {
            _selectedEmail = null;

            txtEmail.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";

            rdoNhanVien.Checked = true;
            rdoHoatDong.Checked = true;

            txtEmail.ReadOnly = false;
            txtEmail.Focus();
        }

        private bool IsValidEmail(string email)
        {
            // kiểm tra nhanh, đủ dùng cho bài
            return Regex.IsMatch(email ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private NhanVien ReadForm(out string error)
        {
            error = "";

            var email = txtEmail.Text.Trim();
            var ten = txtTenNV.Text.Trim();
            var diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                error = "Bạn chưa nhập Email.";
                return null;
            }
            if (!IsValidEmail(email))
            {
                error = "Email không đúng định dạng.";
                return null;
            }
            if (string.IsNullOrWhiteSpace(ten))
            {
                error = "Bạn chưa nhập Tên nhân viên.";
                return null;
            }

            // DB thường lưu int: VaiTro(0/1), TinhTrang(0/1)
            int vaiTro = rdoQuanTri.Checked ? 1 : 0;
            int tinhTrang = rdoHoatDong.Checked ? 1 : 0;


            return new NhanVien
            {
                Email = email,
                TenNV = ten,
                DiaChi = diaChi,
                VaiTro = vaiTro,
                TinhTrang = tinhTrang,




            };
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvNhanVien.Rows[e.RowIndex];
            if (row == null) return;

            _selectedEmail = row.Cells["Email"]?.Value?.ToString();

            txtEmail.Text = _selectedEmail ?? "";
            txtTenNV.Text = row.Cells["TenNV"]?.Value?.ToString() ?? "";
            txtDiaChi.Text = row.Cells["DiaChi"]?.Value?.ToString() ?? "";

            var vaiTro = row.Cells["VaiTro"]?.Value?.ToString() ?? "0";
            rdoQuanTri.Checked = (vaiTro == "1");
            rdoNhanVien.Checked = !rdoQuanTri.Checked;

            var tinhTrang = row.Cells["TinhTrang"]?.Value?.ToString() ?? "1";
            rdoHoatDong.Checked = (tinhTrang == "1");
            rdoNgungHoatDong.Checked = !rdoHoatDong.Checked;

            // Email coi như khóa chính -> không cho sửa
            txtEmail.ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var nv = ReadForm(out var err);
            if (nv == null)
            {
                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            nv.MatKhau = "123456"; // chỉ set khi thêm

            int kq = _bus.Insert(nv);

            if (kq == -1)
            {
                MessageBox.Show("Email này đã tồn tại trong hệ thống. Bạn nhập email khác nha!",
                    "Trùng email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (kq == -2)
            {
                MessageBox.Show("Dữ liệu bị trùng (khóa duy nhất). Bạn kiểm tra lại nha!",
                    "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kq > 0)
            {
                MessageBox.Show("Thêm nhân viên thành công!", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Bạn kiểm tra lại dữ liệu hoặc kết nối DB.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedEmail))
            {
                MessageBox.Show("Bạn chọn 1 nhân viên trong bảng trước đã.", "Thông báo");
                return;
            }

            var nv = ReadForm(out var err);
            if (nv == null)
            {
                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // giữ đúng email đang chọn (khóa chính)
            nv.Email = _selectedEmail;

            try
            {
                var rows = _bus.Update(nv);
                if (rows > 0)
                {
                    MessageBox.Show("Sửa nhân viên thành công!", "OK");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedEmail))
            {
                MessageBox.Show("Bạn chọn 1 nhân viên trong bảng trước đã.", "Thông báo");
                return;
            }

            var ok = MessageBox.Show($"Xóa nhân viên Email: {_selectedEmail} ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ok != DialogResult.Yes) return;

            try
            {
                var rows = _bus.Delete(_selectedEmail);
                if (rows > 0)
                {
                    MessageBox.Show("Xóa thành công!", "OK");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.", "Lỗi");
                }
            }
            catch (SqlException ex) when (ex.Number == 547) // lỗi FK: đang bị tham chiếu
            {
                MessageBox.Show(
                    "❌ Không thể xóa nhân viên này.\n\n" +
                    $"Nhân viên: {_selectedEmail}\n\n" +
                    "Lý do: Nhân viên đang được sử dụng trong dữ liệu hệ thống (ràng buộc khóa ngoại).\n" +
                    "Ví dụ: nhân viên đang là người tạo/cập nhật ở bảng Hàng/Sản phẩm hoặc các bảng khác.\n\n" +
                    "Cách xử lý:\n" +
                    "1) Khuyến nghị: Chuyển nhân viên sang trạng thái 'Ngưng hoạt động' (không xóa).\n" +
                    "2) Hoặc: Chuyển các dữ liệu đang gán cho nhân viên này sang nhân viên khác, rồi hãy xóa.\n",
                    "Không thể xóa (dính dữ liệu)",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Xóa thất bại do lỗi hệ thống.\n\nChi tiết: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var key = txtTimKiem.Text.Trim();

            try
            {
                List<NhanVien> list;
                if (string.IsNullOrWhiteSpace(key))
                    list = _bus.GetAll();
                else
                    list = _bus.Search(key);

                dgvNhanVien.DataSource = null;
                dgvNhanVien.DataSource = list;

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedEmail))
            {
                MessageBox.Show("Bạn chọn 1 nhân viên trong bảng trước đã.", "Thông báo");
                return;
            }

            var ok = MessageBox.Show(
                $"Reset mật khẩu cho: {_selectedEmail}\nMật khẩu mới sẽ là: 123456",
                "Xác nhận reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (ok != DialogResult.Yes) return;

            try
            {
                // ✅ truyền mật khẩu dạng plain, BUS sẽ tự hash
                int rows = _bus.ResetPassword(_selectedEmail, "123456");

                if (rows > 0) MessageBox.Show("Reset mật khẩu thành công! (Mật khẩu mới: 123456)", "OK");
                else MessageBox.Show("Reset thất bại.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reset: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         
    }
}
