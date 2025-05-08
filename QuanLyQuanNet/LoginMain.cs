using System.Security.Policy;

namespace QuanLyQuanNet
{
    public partial class LoginMain : Form
    {
        public LoginMain()
        {
            InitializeComponent();
            txt_matKhau.UseSystemPasswordChar = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //======================================================================
        // Tên đăng nhập
        private void lb_tenDangNhap_Click(object sender, EventArgs e)
        {
            txt_dangNhap.Focus();
        }
        private void txt_dangNhap_Enter(object sender, EventArgs e)
        {
            lb_tenDangNhap.Top = txt_dangNhap.Top - 20;  // Đẩy label lên trên
            lb_tenDangNhap.ForeColor = Color.Blue;     // Đổi màu (tùy chỉnh)
        }

        private void txt_dangNhap_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_dangNhap.Text))
            {
                lb_tenDangNhap.Top = txt_dangNhap.Top + 5;  // Đẩy label xuống dưới
                lb_tenDangNhap.ForeColor = Color.Gray;     // Đổi màu (tùy chỉnh)
            }
        }

        //=====================================================================
        // Mật khẩu
        private void lb_matKhau_Click(object sender, EventArgs e)
        {
            txt_matKhau.Focus();
        }
        private void txt_matKhau_Enter(object sender, EventArgs e)
        {
            lb_matKhau.Top = txt_matKhau.Top - 20;  // Đẩy label lên trên
            lb_matKhau.ForeColor = Color.Blue;     // Đổi màu (tùy chỉnh)
        }
        private void txt_matKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_matKhau.Text)) // Kiểm tra nếu không có chữ
            {
                lb_matKhau.Top = txt_matKhau.Top + 5;  // Đẩy label xuống lại vị trí ban đầu
                lb_matKhau.ForeColor = Color.Gray;     // Đổi màu xám
            }
        }

        // cái này là j ko biết nữa
        private void LoginMain_Load(object sender, EventArgs e)
        {

        }
        // cái này xóa sau
        private void ptn_fDangNhap_Paint(object sender, PaintEventArgs e)
        {

        }
        // cái này cần sửa để kết nối với sql 
        private void btn_dangNhap_Click(object sender, EventArgs e)
        {
            string username = txt_dangNhap.Text.Trim();
            string password = txt_matKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (username == "admin" && password == "1")
            {
                MessageBox.Show("Đăng nhập thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Ẩn form hiện tại
                this.Hide();

                // Mở form LogAdmin
                LogAdmin adminForm = new LogAdmin();
                adminForm.ShowDialog();

                // Sau khi đóng form LogAdmin, đóng luôn form hiện tại (nếu cần)
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // giúp hiện thị mk
        private void cb_hienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_hienThiMK.Checked == true)
            {
                txt_matKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txt_matKhau.UseSystemPasswordChar = true;
            }
        }

        private void txt_dangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_dangNhap.PerformClick(); // Gọi sự kiện nhấn nút Đăng Nhập
            }
        }

        private void txt_matKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_dangNhap.PerformClick();
            }
        }
    }
}
