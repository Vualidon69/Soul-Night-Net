using QuanLyQuanNet.Admin.ChucNang;
using QuanLyQuanNet.Admin.ChucNang.khachhang;
using QuanLyQuanNet.Admin.ChucNang.Tinh_trang_may;
using QuanLyQuanNet.Admin.ChucNang.LichSu;
using QuanLyQuanNet.Admin.NhanVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNet
{
    public partial class LogAdmin : Form
    {
        private Button? _currentButton;
        private readonly Color _normalColor = Color.FromArgb(83, 163, 222);
        private readonly Color _selectedColor = Color.FromArgb(70, 150, 210);

        public LogAdmin()
        {
            this.DoubleBuffered = true;
            InitializeComponent();

            // Đăng ký event handlers cho tất cả các buttons
            btn_menu.Click += btn_menu_Click;
            btn_status.Click += btn_status_Click;
            button_khachHang.Click += button_khachHang_Click;
            btn_lichsu.Click += btn_lichsu_Click;
            button_NhanVien.Click += button_NhanVien_Click;
            button2.Click += button2_Click; // Chat
            button9.Click += button9_Click; // Thống kê
            button6.Click += button6_Click; // Kho
            button5.Click += button5_Click; // Khuyến mãi
            btn_dangXuat.Click += btn_dangXuat_Click; // Đăng xuất

            // Đăng ký event cho resize form
            this.Resize += LogAdmin_Resize;

            // Thiết lập các thuộc tính của Form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Quán Net";

            // Khởi tạo layout ban đầu
            InitializeButtonStyles();
            AdjustPanelSizes();

            // Mở tab Menu mặc định khi vào form
            btn_menu_Click(btn_menu, EventArgs.Empty);
        }

        private void LogAdmin_Resize(object sender, EventArgs e)
        {
            AdjustPanelSizes();
        }

        private void AdjustPanelSizes()
        {
            const int gap = 15;
            int menuWidth, topHeight;

            if (this.WindowState == FormWindowState.Maximized)
            {
                menuWidth = 300;
                topHeight = 80;
            }
            else
            {
                menuWidth = Math.Max(200, (int)(this.ClientSize.Width * 0.22));
                menuWidth = Math.Min(menuWidth, 280);

                topHeight = Math.Max(65, Math.Min(80, (int)(this.ClientSize.Height * 0.1)));
            }

            // Undock controls for manual positioning
            pnlMenu.Dock = DockStyle.None;
            pl_top_admin.Dock = DockStyle.None;
            pn_dichvu.Dock = DockStyle.None;

            // Calculate positions and sizes
            pnlMenu.Location = new Point(gap, gap);
            pnlMenu.Size = new Size(menuWidth, this.ClientSize.Height - 2 * gap);

            pl_top_admin.Location = new Point(pnlMenu.Right + gap, gap);
            pl_top_admin.Size = new Size(this.ClientSize.Width - pnlMenu.Right - 2 * gap, topHeight);

            pn_dichvu.Location = new Point(pnlMenu.Right + gap, pl_top_admin.Bottom + gap);
            pn_dichvu.Size = new Size(this.ClientSize.Width - pnlMenu.Right - 2 * gap, this.ClientSize.Height - pl_top_admin.Bottom - 2 * gap);

            AdjustMenuButtons(pnlMenu.Width);
            AdjustTopPanelControls();
        }

        private void AdjustTopPanelControls()
        {
            int panelWidth = pl_top_admin.Width;
            int panelHeight = pl_top_admin.Height;
            int rightPadding = 20;

            // Center all controls vertically
            lb_chucNangHienTai.Top = (panelHeight - lb_chucNangHienTai.Height) / 2;
            img_dangXuat.Top = (panelHeight - img_dangXuat.Height) / 2;
            lb_tenNhanVien.Top = (panelHeight - lb_tenNhanVien.Height) / 2;
            img_thongBao.Top = (panelHeight - img_thongBao.Height) / 2;

            // Position controls horizontally from the right edge
            img_dangXuat.Left = panelWidth - img_dangXuat.Width - rightPadding;
            lb_tenNhanVien.Left = img_dangXuat.Left - lb_tenNhanVien.Width - 5;
            img_thongBao.Left = lb_tenNhanVien.Left - img_thongBao.Width - 5;
        }

        private void AdjustMenuButtons(int menuWidth)
        {
            // Adjust picture box, label, and font size
            pictureBox1.Width = menuWidth - 20; // 10px margin each side
            label1.Width = menuWidth - 20;

            float newFontSize = (menuWidth > 280) ? 14f : 12f;
            label1.Font = new Font(label1.Font.FontFamily, newFontSize, label1.Font.Style);

            int buttonWidth = menuWidth - 40; // 20px margin mỗi bên
            int buttonHeight = 40; // Thu nhỏ height để vừa
            int startY = 240;
            int spacing = 45; // Khoảng cách giữa các buttons

            // Resize tất cả buttons
            btn_menu.Size = new Size(buttonWidth, buttonHeight);
            btn_status.Size = new Size(buttonWidth, buttonHeight);
            btn_lichsu.Size = new Size(buttonWidth, buttonHeight);
            button_khachHang.Size = new Size(buttonWidth, buttonHeight);
            button2.Size = new Size(buttonWidth, buttonHeight);
            button_NhanVien.Size = new Size(buttonWidth, buttonHeight);
            button9.Size = new Size(buttonWidth, buttonHeight);
            button6.Size = new Size(buttonWidth, buttonHeight);
            button5.Size = new Size(buttonWidth, buttonHeight);

            // Repositioning buttons
            btn_menu.Location = new Point(20, startY);
            btn_status.Location = new Point(20, startY + spacing);
            btn_lichsu.Location = new Point(20, startY + spacing * 2);
            button_khachHang.Location = new Point(20, startY + spacing * 3);
            button2.Location = new Point(20, startY + spacing * 4);
            button_NhanVien.Location = new Point(20, startY + spacing * 5);
            button9.Location = new Point(20, startY + spacing * 6);
            button6.Location = new Point(20, startY + spacing * 7);
            button5.Location = new Point(20, startY + spacing * 8);

            // Nút đăng xuất luôn ở cuối, với màu đỏ nổi bật
            btn_dangXuat.Size = new Size(buttonWidth, 50);
            btn_dangXuat.Location = new Point(20, pnlMenu.Height - 70); // 70px từ dưới lên
        }

        private void InitializeButtonStyles()
        {
            foreach (Control control in pnlMenu.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = _normalColor;
                    button.FlatAppearance.MouseDownBackColor = _selectedColor;
                    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 175, 230);
                }
            }
        }

        private void HighlightButton(Button? selectedButton)
        {
            if (selectedButton == null) return;

            if (_currentButton != null)
            {
                _currentButton.BackColor = _normalColor;
            }
            selectedButton.BackColor = _selectedColor;
            _currentButton = selectedButton;
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            // Cập nhật tên chức năng hiện tại
            lb_chucNangHienTai.Text = "Menu";

            pn_dichvu.Controls.Clear();

            // Tạo một instance của UserControl admin_Menu
            admin_Menu menuControl = new admin_Menu();

            // Thiết lập Dock để nó tự động fit vào panel
            menuControl.Dock = DockStyle.Fill;

            // Thêm UserControl vào panel
            pn_dichvu.Controls.Add(menuControl);

            // Đưa UserControl lên trên cùng để hiển thị
            menuControl.BringToFront();
        }

        private void btn_status_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            // Cập nhật tên chức năng hiện tại
            lb_chucNangHienTai.Text = "Tình trạng máy";

            pn_dichvu.Controls.Clear();

            // Tạo một instance của UserControl uc_tinhTrangMay
            uc_tinhTrangMay statusControl = new uc_tinhTrangMay();

            // Thiết lập Dock để nó tự động fit vào panel
            statusControl.Dock = DockStyle.Fill;

            // Thêm UserControl vào panel
            pn_dichvu.Controls.Add(statusControl);

            // Đưa UserControl lên trên cùng để hiển thị
            statusControl.BringToFront();
        }

        private void button_khachHang_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            // Cập nhật tên chức năng hiện tại
            lb_chucNangHienTai.Text = "Khách hàng";

            pn_dichvu.Controls.Clear();

            // Tạo một instance của UserControl uc_khachhang
            uc_khachhang khachHangControl = new uc_khachhang();

            // Thiết lập Dock để tự động fit vào panel
            khachHangControl.Dock = DockStyle.Fill;

            // Thêm UserControl vào panel
            pn_dichvu.Controls.Add(khachHangControl);

            // Đưa UserControl lên trên cùng để hiển thị
            khachHangControl.BringToFront();
        }

        private void btn_lichsu_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            // Cập nhật tên chức năng hiện tại
            lb_chucNangHienTai.Text = "Lịch sử";

            pn_dichvu.Controls.Clear();

            // Tạo một instance của UserControl admin_LichSu
            uc_LichSu lichsuControl = new uc_LichSu();

            // Thiết lập Dock để tự động fit vào panel
            lichsuControl.Dock = DockStyle.Fill;

            // Thêm UserControl vào panel
            pn_dichvu.Controls.Add(lichsuControl);

            // Đưa UserControl lên trên cùng để hiển thị
            lichsuControl.BringToFront();
        }

        private void button_NhanVien_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            // Cập nhật tên chức năng hiện tại
            lb_chucNangHienTai.Text = "Nhân viên";

            pn_dichvu.Controls.Clear();

            // Tạo một instance của UserControl admin_NhanVien
            admin_NhanVien nhanVienControl = new admin_NhanVien();

            // Thiết lập Dock để tự động fit vào panel
            nhanVienControl.Dock = DockStyle.Fill;

            // Thêm UserControl vào panel
            pn_dichvu.Controls.Add(nhanVienControl);

            // Đưa UserControl lên trên cùng để hiển thị
            nhanVienControl.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            // Cập nhật tên chức năng hiện tại
            lb_chucNangHienTai.Text = "Chat";

            pn_dichvu.Controls.Clear();

            // TODO: Tạo và hiển thị UserControl chat
            // Ví dụ:
            // uc_Chat chatControl = new uc_Chat();
            // chatControl.Dock = DockStyle.Fill;
            // pn_dichvu.Controls.Add(chatControl);
            // chatControl.BringToFront();

            // Hiển thị thông báo tạm thời
            Label lblNotImplemented = new Label();
            lblNotImplemented.Text = "Chức năng Chat đang được phát triển";
            lblNotImplemented.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblNotImplemented.AutoSize = false;
            lblNotImplemented.TextAlign = ContentAlignment.MiddleCenter;
            lblNotImplemented.Dock = DockStyle.Fill;
            pn_dichvu.Controls.Add(lblNotImplemented);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            // Cập nhật tên chức năng hiện tại
            lb_chucNangHienTai.Text = "Thống kê";

            pn_dichvu.Controls.Clear();

            // TODO: Tạo và hiển thị UserControl thống kê
            // Ví dụ:
            // uc_ThongKe thongKeControl = new uc_ThongKe();
            // thongKeControl.Dock = DockStyle.Fill;
            // pn_dichvu.Controls.Add(thongKeControl);
            // thongKeControl.BringToFront();

            Label lblNotImplemented = new Label();
            lblNotImplemented.Text = "Chức năng Thống kê đang được phát triển";
            lblNotImplemented.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblNotImplemented.AutoSize = false;
            lblNotImplemented.TextAlign = ContentAlignment.MiddleCenter;
            lblNotImplemented.Dock = DockStyle.Fill;
            pn_dichvu.Controls.Add(lblNotImplemented);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            // Cập nhật tên chức năng hiện tại
            lb_chucNangHienTai.Text = "Kho";

            pn_dichvu.Controls.Clear();

            // TODO: Tạo và hiển thị UserControl kho
            // Ví dụ:
            // uc_Kho khoControl = new uc_Kho();
            // khoControl.Dock = DockStyle.Fill;
            // pn_dichvu.Controls.Add(khoControl);
            // khoControl.BringToFront();

            Label lblNotImplemented = new Label();
            lblNotImplemented.Text = "Chức năng Kho đang được phát triển";
            lblNotImplemented.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblNotImplemented.AutoSize = false;
            lblNotImplemented.TextAlign = ContentAlignment.MiddleCenter;
            lblNotImplemented.Dock = DockStyle.Fill;
            pn_dichvu.Controls.Add(lblNotImplemented);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HighlightButton(sender as Button);
            // Cập nhật tên chức năng hiện tại
            lb_chucNangHienTai.Text = "Khuyến mãi";

            pn_dichvu.Controls.Clear();

            // TODO: Tạo và hiển thị UserControl khuyến mãi
            // Ví dụ:
            // uc_KhuyenMai khuyenMaiControl = new uc_KhuyenMai();
            // khuyenMaiControl.Dock = DockStyle.Fill;
            // pn_dichvu.Controls.Add(khuyenMaiControl);
            // khuyenMaiControl.BringToFront();

            Label lblNotImplemented = new Label();
            lblNotImplemented.Text = "Chức năng Khuyến mãi đang được phát triển";
            lblNotImplemented.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblNotImplemented.AutoSize = false;
            lblNotImplemented.TextAlign = ContentAlignment.MiddleCenter;
            lblNotImplemented.Dock = DockStyle.Fill;
            pn_dichvu.Controls.Add(lblNotImplemented);
        }

        private void btn_dangXuat_Click(object sender, EventArgs e)
        {
            // Nút đăng xuất không cần highlight
            // Xác nhận đăng xuất
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại
                this.Hide();
            }
        }
    }
}