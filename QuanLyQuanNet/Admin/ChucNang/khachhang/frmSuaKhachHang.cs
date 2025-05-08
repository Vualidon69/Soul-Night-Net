using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.ChucNang.khachhang // Cập nhật namespace
{
    public partial class frmSuaKhachHang : Form
    {
        private DataRow row;

        public frmSuaKhachHang(DataRow selectedRow)
        {
            InitializeComponent();
            row = selectedRow;
            txtMaKH.Text = row["MaKH"].ToString();
            txtHoTen.Text = row["HoTen"].ToString();
            txtSDT.Text = row["SDT"].ToString();
            txtEmail.Text = row["Email"].ToString();
            txtSoDiem.Text = row["SoDiem"].ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin! 😅", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            row["HoTen"] = txtHoTen.Text;
            row["SDT"] = txtSDT.Text;
            row["Email"] = txtEmail.Text;
            row["SoDiem"] = int.Parse(txtSoDiem.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}