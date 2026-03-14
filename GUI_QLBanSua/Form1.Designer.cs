namespace GUI_QLBanSua
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            mnuDangNhap = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuDanhMuc = new ToolStripMenuItem();
            mnuNhanVien = new ToolStripMenuItem();
            sảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            kháchHàngToolStripMenuItem = new ToolStripMenuItem();
            mnuThongKe = new ToolStripMenuItem();
            mnuBanRaDoanhThu = new ToolStripMenuItem();
            xemHóaĐơnToolStripMenuItem = new ToolStripMenuItem();
            mnuHuongDan = new ToolStripMenuItem();
            bánHàngToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, mnuDanhMuc, mnuThongKe, mnuHuongDan, bánHàngToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuDangNhap, mnuDangXuat });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(106, 29);
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // mnuDangNhap
            // 
            mnuDangNhap.Name = "mnuDangNhap";
            mnuDangNhap.Size = new Size(270, 34);
            mnuDangNhap.Text = "Đăng Nhập";
            mnuDangNhap.Click += mnuDangNhap_Click_1;
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(270, 34);
            mnuDangXuat.Text = "Đăng Xuất";
            mnuDangXuat.Click += mnuDangXuat_Click_1;
            // 
            // mnuDanhMuc
            // 
            mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { mnuNhanVien, sảnPhẩmToolStripMenuItem, kháchHàngToolStripMenuItem });
            mnuDanhMuc.Name = "mnuDanhMuc";
            mnuDanhMuc.Size = new Size(109, 29);
            mnuDanhMuc.Text = "Danh Mục";
            // 
            // mnuNhanVien
            // 
            mnuNhanVien.Name = "mnuNhanVien";
            mnuNhanVien.Size = new Size(209, 34);
            mnuNhanVien.Text = "Nhân Viên";
            mnuNhanVien.Click += mnuNhanVien_Click;
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            sảnPhẩmToolStripMenuItem.Size = new Size(209, 34);
            sảnPhẩmToolStripMenuItem.Text = "Sản Phẩm";
            sảnPhẩmToolStripMenuItem.Click += sảnPhẩmToolStripMenuItem_Click;
            // 
            // kháchHàngToolStripMenuItem
            // 
            kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            kháchHàngToolStripMenuItem.Size = new Size(209, 34);
            kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            kháchHàngToolStripMenuItem.Click += kháchHàngToolStripMenuItem_Click;
            // 
            // mnuThongKe
            // 
            mnuThongKe.DropDownItems.AddRange(new ToolStripItem[] { mnuBanRaDoanhThu, xemHóaĐơnToolStripMenuItem });
            mnuThongKe.Name = "mnuThongKe";
            mnuThongKe.Size = new Size(103, 29);
            mnuThongKe.Text = "Thống Kê";
            // 
            // mnuBanRaDoanhThu
            // 
            mnuBanRaDoanhThu.Name = "mnuBanRaDoanhThu";
            mnuBanRaDoanhThu.Size = new Size(254, 34);
            mnuBanRaDoanhThu.Text = "Bán ra/Doanh thu";
            mnuBanRaDoanhThu.Click += mnuBanRaDoanhThu_Click_Click;
            // 
            // xemHóaĐơnToolStripMenuItem
            // 
            xemHóaĐơnToolStripMenuItem.Name = "xemHóaĐơnToolStripMenuItem";
            xemHóaĐơnToolStripMenuItem.Size = new Size(254, 34);
            xemHóaĐơnToolStripMenuItem.Text = "Xem hóa đơn";
            xemHóaĐơnToolStripMenuItem.Click += xemHóaĐơnToolStripMenuItem_Click;
            // 
            // mnuHuongDan
            // 
            mnuHuongDan.Name = "mnuHuongDan";
            mnuHuongDan.Size = new Size(140, 29);
            mnuHuongDan.Text = "Đổi Mật khẩu ";
            mnuHuongDan.Click += mnuHuongDan_Click;
            // 
            // bánHàngToolStripMenuItem
            // 
            bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            bánHàngToolStripMenuItem.Size = new Size(105, 29);
            bánHàngToolStripMenuItem.Text = "Bán Hàng";
            bánHàngToolStripMenuItem.Click += bánHàngToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " QUẢN LÝ CỬA HÀNG SỮA";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem mnuDangNhap;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuThongKe;
        private ToolStripMenuItem mnuHuongDan;
        private ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem kháchHàngToolStripMenuItem;
        private ToolStripMenuItem mnuBanRaDoanhThu;
        private ToolStripMenuItem xemHóaĐơnToolStripMenuItem;
        private ToolStripMenuItem bánHàngToolStripMenuItem;
    }
}
