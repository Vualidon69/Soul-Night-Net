namespace QuanLyQuanNet
{
    partial class LogAdmin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlMenu = new Panel();
            btn_dangXuat = new Button();
            roundedPanel1 = new Panel();
            button2 = new Button();
            button9 = new Button();
            button_NhanVien = new Button();
            button6 = new Button();
            button5 = new Button();
            button_khachHang = new Button();
            btn_lichsu = new Button();
            btn_status = new Button();
            btn_menu = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pn_dichvu = new Panel();
            pl_top_admin = new Panel();
            img_dangXuat = new PictureBox();
            lb_tenNhanVien = new Label();
            img_thongBao = new PictureBox();
            lb_chucNangHienTai = new Label();

            pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pl_top_admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)img_dangXuat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)img_thongBao).BeginInit();
            SuspendLayout();

            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = System.Drawing.Color.FromArgb(83, 163, 222);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Controls.Add(btn_dangXuat);
            pnlMenu.Controls.Add(button2);
            pnlMenu.Controls.Add(button9);
            pnlMenu.Controls.Add(button_NhanVien);
            pnlMenu.Controls.Add(button6);
            pnlMenu.Controls.Add(button5);
            pnlMenu.Controls.Add(button_khachHang);
            pnlMenu.Controls.Add(btn_lichsu);
            pnlMenu.Controls.Add(btn_status);
            pnlMenu.Controls.Add(btn_menu);
            pnlMenu.Controls.Add(label1);
            pnlMenu.Controls.Add(pictureBox1);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Width = 300;
            pnlMenu.TabIndex = 0;

            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.edge_background1;
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;

            // 
            // label1 - Tên quán
            // 
            label1.Location = new Point(10, 170);
            label1.Name = "label1";
            label1.Size = new Size(280, 30);
            label1.TabIndex = 1;
            label1.Text = "Quán net bình minh";
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.ForeColor = Color.White;

            // 
            // btn_menu
            // 
            btn_menu.Location = new Point(20, 240);
            btn_menu.Name = "btn_menu";
            btn_menu.Size = new Size(260, 45);
            btn_menu.TabIndex = 2;
            btn_menu.Text = "Menu";
            btn_menu.Font = new Font("Segoe UI", 12F);
            btn_menu.UseVisualStyleBackColor = true;
            btn_menu.Click += btn_menu_Click;
            btn_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_menu.FlatAppearance.BorderSize = 0;
            btn_menu.ForeColor = Color.White;
            btn_menu.TextAlign = ContentAlignment.MiddleLeft;
            btn_menu.Padding = new Padding(20, 0, 0, 0);

            // 
            // btn_status
            // 
            btn_status.Location = new Point(20, 290);
            btn_status.Name = "btn_status";
            btn_status.Size = new Size(260, 45);
            btn_status.TabIndex = 2;
            btn_status.Text = "Tình trạng máy";
            btn_status.Font = new Font("Segoe UI", 12F);
            btn_status.UseVisualStyleBackColor = true;
            btn_status.Click += btn_status_Click;
            btn_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_status.FlatAppearance.BorderSize = 0;
            btn_status.ForeColor = Color.White;
            btn_status.TextAlign = ContentAlignment.MiddleLeft;
            btn_status.Padding = new Padding(20, 0, 0, 0);

            // 
            // btn_lichsu
            // 
            btn_lichsu.Location = new Point(20, 340);
            btn_lichsu.Name = "btn_lichsu";
            btn_lichsu.Size = new Size(260, 45);
            btn_lichsu.TabIndex = 2;
            btn_lichsu.Text = "Lịch sử";
            btn_lichsu.Font = new Font("Segoe UI", 12F);
            btn_lichsu.UseVisualStyleBackColor = true;
            btn_lichsu.Click += btn_lichsu_Click;
            btn_lichsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_lichsu.FlatAppearance.BorderSize = 0;
            btn_lichsu.ForeColor = Color.White;
            btn_lichsu.TextAlign = ContentAlignment.MiddleLeft;
            btn_lichsu.Padding = new Padding(20, 0, 0, 0);

            // 
            // button_khachHang
            // 
            button_khachHang.Location = new Point(20, 390);
            button_khachHang.Name = "button_khachHang";
            button_khachHang.Size = new Size(260, 45);
            button_khachHang.TabIndex = 2;
            button_khachHang.Text = "Khách hàng";
            button_khachHang.Font = new Font("Segoe UI", 12F);
            button_khachHang.UseVisualStyleBackColor = true;
            button_khachHang.Click += button_khachHang_Click;
            button_khachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_khachHang.FlatAppearance.BorderSize = 0;
            button_khachHang.ForeColor = Color.White;
            button_khachHang.TextAlign = ContentAlignment.MiddleLeft;
            button_khachHang.Padding = new Padding(20, 0, 0, 0);

            // 
            // button2 - Chat
            // 
            button2.Location = new Point(20, 440);
            button2.Name = "button2";
            button2.Size = new Size(260, 45);
            button2.TabIndex = 2;
            button2.Text = "Chat";
            button2.Font = new Font("Segoe UI", 12F);
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.ForeColor = Color.White;
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.Padding = new Padding(20, 0, 0, 0);

            // 
            // button_NhanVien
            // 
            button_NhanVien.Location = new Point(20, 490);
            button_NhanVien.Name = "button_NhanVien";
            button_NhanVien.Size = new Size(260, 45);
            button_NhanVien.TabIndex = 2;
            button_NhanVien.Text = "Nhân viên";
            button_NhanVien.Font = new Font("Segoe UI", 12F);
            button_NhanVien.UseVisualStyleBackColor = true;
            button_NhanVien.Click += button_NhanVien_Click;
            button_NhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_NhanVien.FlatAppearance.BorderSize = 0;
            button_NhanVien.ForeColor = Color.White;
            button_NhanVien.TextAlign = ContentAlignment.MiddleLeft;
            button_NhanVien.Padding = new Padding(20, 0, 0, 0);

            // 
            // button9 - Thống kê
            // 
            button9.Location = new Point(20, 540);
            button9.Name = "button9";
            button9.Size = new Size(260, 45);
            button9.TabIndex = 2;
            button9.Text = "Thống kê";
            button9.Font = new Font("Segoe UI", 12F);
            button9.UseVisualStyleBackColor = true;
            button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;
            button9.ForeColor = Color.White;
            button9.TextAlign = ContentAlignment.MiddleLeft;
            button9.Padding = new Padding(20, 0, 0, 0);

            // 
            // button6 - Kho
            // 
            button6.Location = new Point(20, 590);
            button6.Name = "button6";
            button6.Size = new Size(260, 45);
            button6.TabIndex = 2;
            button6.Text = "Kho";
            button6.Font = new Font("Segoe UI", 12F);
            button6.UseVisualStyleBackColor = true;
            button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button6.ForeColor = Color.White;
            button6.TextAlign = ContentAlignment.MiddleLeft;
            button6.Padding = new Padding(20, 0, 0, 0);

            // 
            // button5 - Khuyến mãi
            // 
            button5.Location = new Point(20, 640);
            button5.Name = "button5";
            button5.Size = new Size(260, 45);
            button5.TabIndex = 2;
            button5.Text = "Khuyến mãi";
            button5.Font = new Font("Segoe UI", 12F);
            button5.UseVisualStyleBackColor = true;
            button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.ForeColor = Color.White;
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.Padding = new Padding(20, 0, 0, 0);

            // 
            // btn_dangXuat
            // 
            btn_dangXuat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_dangXuat.Location = new Point(20, 635);
            btn_dangXuat.Name = "btn_dangXuat";
            btn_dangXuat.Size = new Size(260, 50);
            btn_dangXuat.TabIndex = 3;
            btn_dangXuat.Text = "Đăng xuất";
            btn_dangXuat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btn_dangXuat.BackColor = Color.FromArgb(220, 53, 69);
            btn_dangXuat.ForeColor = Color.White;
            btn_dangXuat.UseVisualStyleBackColor = false;
            btn_dangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_dangXuat.FlatAppearance.BorderSize = 0;
            btn_dangXuat.TextAlign = ContentAlignment.MiddleLeft;
            btn_dangXuat.Padding = new Padding(20, 0, 0, 0);

            // 
            // pn_dichvu
            // 
            pn_dichvu.BackColor = Color.White;
            pn_dichvu.Dock = DockStyle.Fill;
            pn_dichvu.Name = "pn_dichvu";
            pn_dichvu.TabIndex = 1;
            pn_dichvu.Padding = new Padding(10);

            // 
            // pl_top_admin
            // 
            pl_top_admin.BackColor = System.Drawing.Color.FromArgb(83, 163, 222);
            pl_top_admin.Dock = DockStyle.Top;
            pl_top_admin.Controls.Add(img_dangXuat);
            pl_top_admin.Controls.Add(lb_tenNhanVien);
            pl_top_admin.Controls.Add(img_thongBao);
            pl_top_admin.Controls.Add(lb_chucNangHienTai);
            pl_top_admin.Name = "pl_top_admin";
            pl_top_admin.Height = 100;
            pl_top_admin.Padding = new Padding(15);
            pl_top_admin.TabIndex = 2;

            // 
            // img_dangXuat
            // 
            img_dangXuat.Image = Properties.Resources.shiroko_removebg_preview2;
            img_dangXuat.Location = new Point(650, 25);
            img_dangXuat.Name = "img_dangXuat";
            img_dangXuat.Size = new Size(50, 50);
            img_dangXuat.SizeMode = PictureBoxSizeMode.Zoom;
            img_dangXuat.TabIndex = 6;
            img_dangXuat.TabStop = false;

            // 
            // lb_tenNhanVien
            // 
            lb_tenNhanVien.Location = new Point(480, 35);
            lb_tenNhanVien.Name = "lb_tenNhanVien";
            lb_tenNhanVien.Size = new Size(160, 30);
            lb_tenNhanVien.TabIndex = 5;
            lb_tenNhanVien.Text = "Admin";
            lb_tenNhanVien.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lb_tenNhanVien.TextAlign = ContentAlignment.MiddleRight;
            lb_tenNhanVien.ForeColor = Color.White;

            // 
            // lb_chucNangHienTai
            // 
            lb_chucNangHienTai.Location = new Point(25, 35);
            lb_chucNangHienTai.Name = "lb_chucNangHienTai";
            lb_chucNangHienTai.Size = new Size(350, 35);
            lb_chucNangHienTai.TabIndex = 7;
            lb_chucNangHienTai.Text = "Menu";
            lb_chucNangHienTai.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lb_chucNangHienTai.AutoSize = true;
            lb_chucNangHienTai.TextAlign = ContentAlignment.MiddleLeft;
            lb_chucNangHienTai.MaximumSize = new Size(400, 0);
            lb_chucNangHienTai.ForeColor = Color.White;

            // 
            // img_thongBao
            // 
            img_thongBao.Image = Properties.Resources.shiroko_removebg_preview1;
            img_thongBao.Location = new Point(420, 25);
            img_thongBao.Name = "img_thongBao";
            img_thongBao.Size = new Size(50, 50);
            img_thongBao.SizeMode = PictureBoxSizeMode.Zoom;
            img_thongBao.TabIndex = 4;
            img_thongBao.TabStop = false;

            // 
            // LogAdmin
            // 
            this.ClientSize = new Size(1200, 800);
            this.MinimumSize = new Size(800, 600);
            this.Controls.Add(pn_dichvu);
            this.Controls.Add(pl_top_admin);
            this.Controls.Add(pnlMenu);
            this.Name = "LogAdmin";
            this.Text = "Quản Lý Quán Net - Admin";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);

            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pl_top_admin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)img_dangXuat).EndInit();
            ((System.ComponentModel.ISupportInitialize)img_thongBao).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlMenu;
        private Panel pn_dichvu;
        private PictureBox pictureBox1;
        private Button button6;
        private Button button5;
        private Button button_khachHang;
        private Button btn_lichsu;
        private Button button2;
        private Button btn_menu;
        private Label label1;
        private Button btn_dangXuat;
        private Panel pl_top_admin;
        private Label lb_tenNhanVien;
        private PictureBox img_thongBao;
        private PictureBox img_dangXuat;
        private Button btn_status;
        private Button button9;
        private Button button_NhanVien;
        private Panel roundedPanel1;
        private Label lb_chucNangHienTai;
    }
}