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
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin! 😅", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = GenerateMaKH();
            string query = "INSERT INTO Khach (MaKhachHang, HoTen, SDT, Email, SoDiem) VALUES (@MaKH, @HoTen, @SDT, @Email, 0)";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", maKH },
                { "@HoTen", txtHoTen.Text },
                { "@SDT", txtSDT.Text },
                { "@Email", txtEmail.Text }
            };
            int result = DataProvider.Instance.ExecNonQuery(query, parameters);

            if (result == 0)
            {
                MessageBox.Show("Đã thêm khách hàng thành công! 🎉");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại! 😢", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}