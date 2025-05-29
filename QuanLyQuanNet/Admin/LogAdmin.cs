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
        public LogAdmin()
        {
            InitializeComponent();
            btn_menu.Click += btn_menu_Click;
            btn_status.Click += btn_status_Click;
            button_khachHang.Click += button_khachHang_Click;
            btn_lichsu.Click += btn_lichsu_Click;
            button_NhanVien.Click += button_NhanVien_Click;
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
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
    }
}
