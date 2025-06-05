using System;
using System.Data;
using System.Windows.Forms;
// ← Đảm bảo đã thêm namespace chứa DataProvider

namespace QuanLyQuanNet.Admin.ChucNang.khachhang
{
    public partial class frmSuaKhachHang : Form
    {
        private string maKH; // Dùng riêng, không phụ thuộc vào DataRow nữa

        public frmSuaKhachHang(DataRow selectedRow)
        {
            InitializeComponent();
            maKH = selectedRow["MaKH"].ToString();
            txtMaKH.Text = maKH;
            txtHoTen.Text = selectedRow["HoTen"].ToString();
            txtSDT.Text = selectedRow["SDT"].ToString();
            txtEmail.Text = selectedRow["Email"].ToString();
            txtSoDiem.Text = selectedRow["SoDiem"].ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSoDiem.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin! 😅", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "UPDATE Khach SET HoTen = @HoTen, SDT = @SDT, Email = @Email, SoDiem = @SoDiem WHERE MaKhachHang = @MaKH";
                var parameters = new Dictionary<string, object>
                {
                    { "@HoTen", txtHoTen.Text },
                    { "@SDT", txtSDT.Text },
                    { "@Email", txtEmail.Text },
                    { "@SoDiem", int.Parse(txtSoDiem.Text) },
                    { "@MaKH", maKH }
                };
                int rowsAffected = DataProvider.Instance.ExecNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật khách hàng thành công! 🎉", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng để cập nhật! 😓", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng:\n" + ex.Message, "Lỗi nặng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
