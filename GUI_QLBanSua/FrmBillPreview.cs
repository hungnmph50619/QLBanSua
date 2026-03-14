using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_QLBanSua
{
    public partial class FrmBillPreview : Form
    {
        public FrmBillPreview(string billText)
        {
            Text = "Preview hóa đơn";
            Width = 420;
            Height = 520;
            StartPosition = FormStartPosition.CenterParent;

            var txt = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new Font("Consolas", 10f),
                Text = billText
            };

            var btnCopy = new Button { Text = "Copy", Dock = DockStyle.Bottom, Height = 36 };
            btnCopy.Click += (s, e) =>
            {
                Clipboard.SetText(billText);
                MessageBox.Show("Đã copy hóa đơn!");
            };

            var btnClose = new Button { Text = "Đóng", Dock = DockStyle.Bottom, Height = 36 };
            btnClose.Click += (s, e) => Close();

            Controls.Add(txt);
            Controls.Add(btnClose);
            Controls.Add(btnCopy);
        }
        private void FrmBillPreview_Load(object sender, EventArgs e)
        {
            // Không cần làm gì cũng được
        }

    }
}
