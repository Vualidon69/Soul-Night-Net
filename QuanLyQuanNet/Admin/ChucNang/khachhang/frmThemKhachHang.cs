using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.ChucNang.khachhang
{
    public partial class frmThemKhachHang : Form
    {
        private DataTable dtKhachHang;

        public frmThemKhachHang(DataTable dt)
        {
            InitializeComponent();
            dtKhachHang = dt;
            txtMaKH.Text = GenerateMaKH();
        }

        private string GenerateMaKH()
        {
            int newId = dtKhachHang.Rows.Count + 1;
            return "KH" + newId.ToString("D4");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin! 😅", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtKhachHang.Rows.Add(txtMaKH.Text, txtHoTen.Text, txtSDT.Text, txtEmail.Text, 0);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}