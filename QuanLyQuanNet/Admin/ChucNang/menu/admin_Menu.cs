using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanNet.Admin.ChucNang.menu;

namespace QuanLyQuanNet.Admin.ChucNang
{
    public partial class admin_Menu : UserControl
    {
        private DataTable menuData;
        private const string MENU_DATA_FILE = "menu_data.xml";

        public admin_Menu()
        {
            InitializeComponent();
            LoadMenuData();
            dgv_style();


        }

        private void LoadMenuData()
        {
            string query = "SELECT * FROM Menu";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            dgvMenu.DataSource = dt; // Đảm bảo dgvMenu là DataGridView trên Form
        }



        private void dgv_style()
        {

            dgvMenu.EnableHeadersVisualStyles = false;
            dgvMenu.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvMenu.ColumnHeadersDefaultCellStyle.BackColor;


            dgvMenu.Height = dgvMenu.Rows.Count * dgvMenu.RowTemplate.Height + dgvMenu.ColumnHeadersHeight;
            // giúp click vô vẫn hiện màu
            dgvMenu.CellClick += (s, e) =>
            {
                dgvMenu.CurrentRow.Selected = true;
            };
            // thiết lập cho dòng đầu
            dgvMenu.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10); // Chỉnh font to hơn

            // Thiết lập kiểu đường kẻ
            dgvMenu.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Chỉ có đường kẻ ngang

            // Đặt màu của đường kẻ
            dgvMenu.GridColor = Color.LightGray; // Đường kẻ màu xám nhạt

            // Tắt viền ô và viền ngoài
            dgvMenu.DefaultCellStyle.SelectionBackColor = Color.Transparent; // Không đổi màu khi chọn
            dgvMenu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; // Không có viền header

            // Bật màu nền trắng để tránh bị mất đường kẻ
            dgvMenu.BackgroundColor = Color.White;

            // Căn chỉnh kiểu hiển thị
            dgvMenu.RowHeadersVisible = false; // Ẩn cột đầu dòng
            dgvMenu.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dgvMenu.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvMenu.BackgroundColor = this.BackColor; // Đặt màu nền trùng với Form
            dgvMenu.BorderStyle = BorderStyle.None;   // Xóa viền nếu cần

            // Tự động căn chỉnh kích thước
            dgvMenu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMenu.AllowUserToAddRows = false; // Tắt hàng trống ở cuối

        }

        // đọc file ảnh và load thong tin cho chi tiết hóa đơn
        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvMenu_CellClick_pln_chiTietMonAn(sender, e); // lấy dgv vô chi tiết món ăn

        }
        // đọc file ảnh
     
        // lấy dgv vô chi tiết món ăn
        private void dgvMenu_CellClick_pln_chiTietMonAn(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && !dgvMenu.Rows[e.RowIndex].IsNewRow)
            {
                if (pnl_chiTietMonAn != null)
                {
                    pnl_chiTietMonAn.Visible = true;
                }
                else
                {
                    // Optionally handle the null case, e.g., log an error or show a message
                   
                }

                // Lấy dòng được chọn
                DataGridViewRow row = dgvMenu.Rows[e.RowIndex];

                // Điền dữ liệu vào các TextBox tương ứng
                textBox_MaMon.Text = row.Cells["MaMon"].Value.ToString();
                textBox_TenMon.Text = row.Cells["TenMon"].Value.ToString();
                textBox_Gia.Text = row.Cells["Gia"].Value.ToString();

                // Load ảnh
                string maMon = textBox_MaMon.Text;
                string imgPath = Path.Combine(Application.StartupPath, "img", maMon + ".jpg");
              
            }
        }

        // Hàm load ảnh an toàn, tránh lỗi OutOfMemoryException
        private void LoadImage(PictureBox pictureBox, string imagePath)
        {
            try
            {
                if (!File.Exists(imagePath))
                {
                    MessageBox.Show($"Ảnh không tồn tại!\nĐường dẫn thử: {imagePath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Giải phóng ảnh cũ trước khi gán ảnh mới
                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                    pictureBox.Image = null;
                }

                // Đọc ảnh vào bộ nhớ bằng MemoryStream để tránh khóa file
                using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    pictureBox.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dgvMenu.DataSource as DataTable).DefaultView.RowFilter =
         string.Format("[Tên món] LIKE '%{0}%'", txtSearch.Text);
        }
        // Đưa con trỏ vào ô tìm kiếm và Ẩn label
        private void lb_timKiemMonAn_Click(object sender, EventArgs e)
        {
            txtSearch.Focus(); // Đưa con trỏ vào ô tìm kiếm
            lb_timKiemMonAn.Visible = false;
        }
        // Ẩn label khi nhập
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            lb_timKiemMonAn.Visible = false;
        }
        // Hiện lại label nếu không có chữ và mất focus
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                lb_timKiemMonAn.Visible = true;
            }
        }


        private void btn_themMon_Click(object sender, EventArgs e)
        {
            using (var formThemMon = new ThemMonAn())
            {
                if (formThemMon.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Get the current DataTable from DataGridView
                        DataTable dt = (DataTable)dgvMenu.DataSource;

                        // Add new row with the data from the form
                        DataRow newRow = dt.NewRow();
                        newRow["MaMon"] = formThemMon.MaMon;
                        newRow["TenMon"] = formThemMon.TenMon;
                        newRow["Gia"] = formThemMon.GiaMon; // giữ kiểu số để dễ xử lý

                        dt.Rows.Add(newRow);

                        // Refresh the DataGridView
                        dgvMenu.DataSource = dt;

                        // Save the image if it exists
                        if (formThemMon.AnhMon != null)
                        {
                            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                            string imgFolder = Path.Combine(projectRoot, "img");

                            if (!Directory.Exists(imgFolder))
                                Directory.CreateDirectory(imgFolder);

                            string imagePath = Path.Combine(imgFolder, formThemMon.MaMon + ".jpg");
                            File.WriteAllBytes(imagePath, formThemMon.AnhMon);
                        }

                        MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btn_xoaMon_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra có dòng được chọn không
            if (dgvMenu.CurrentRow != null && !dgvMenu.CurrentRow.IsNewRow)
            {
                // Hỏi xác nhận từ người dùng
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Lấy mã món từ dòng được chọn
                        string maMon = dgvMenu.CurrentRow.Cells["MaMon"].Value.ToString(); // SỬA TÊN CỘT

                        // Xóa dòng khỏi DataTable
                        DataTable dt = (DataTable)dgvMenu.DataSource;
                        dt.Rows.RemoveAt(dgvMenu.CurrentRow.Index);

                        // Xóa ảnh nếu có
                        string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                        string imgFolder = Path.Combine(projectRoot, "img");
                        string imagePath = Path.Combine(imgFolder, maMon + ".jpg");

                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }

                        // Xóa dữ liệu trên giao diện
                        txt_maMon.Clear();
                        txt_tenMon.Clear();
                        txt_Gia.Clear();
                  

                        MessageBox.Show("Xóa món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMenu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dgvMenu.Columns[e.ColumnIndex].Name == "Gia" && e.Value != null)
            {
                e.Value = string.Format("{0:N0} VND", Convert.ToDecimal(e.Value));
                e.FormattingApplied = true;
            }
        }

        private void button_chinhsua_Click(object sender, EventArgs e)
        {
            if (dgvMenu.CurrentRow != null && !dgvMenu.CurrentRow.IsNewRow)
            {
                try
                {
                    // Lấy chỉ số dòng đang chọn
                    int rowIndex = dgvMenu.CurrentRow.Index;
                    DataTable dt = (DataTable)dgvMenu.DataSource;

                    // Lấy thông tin mới từ các TextBox
                    string maMon = textBox_MaMon.Text.Trim();
                    string tenMon = textBox_TenMon.Text.Trim();
                    string giaStr = textBox_Gia.Text.Trim();

                    if (string.IsNullOrWhiteSpace(maMon) || string.IsNullOrWhiteSpace(tenMon) || !decimal.TryParse(giaStr, out decimal gia))
                    {
                        MessageBox.Show("Vui lòng nhập đúng và đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Cập nhật vào DataTable
                    dt.Rows[rowIndex]["MaMon"] = maMon;
                    dt.Rows[rowIndex]["TenMon"] = tenMon;
                    dt.Rows[rowIndex]["Gia"] = gia;

                    dgvMenu.DataSource = dt; // Cập nhật lại lưới

                    MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món trong danh sách để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMenu.Columns["TenMon"].Index && e.RowIndex >= 0)
            {
                // Lấy giá trị ô được click
                string tenMon = dgvMenu.Rows[e.RowIndex].Cells["TenMon"].Value.ToString();

                // Điền vào TextBox tên món
                textBox_TenMon.Text = tenMon;

                // Focus vào TextBox để chỉnh sửa ngay
                textBox_TenMon.Focus();
            }
        }
    }
}
