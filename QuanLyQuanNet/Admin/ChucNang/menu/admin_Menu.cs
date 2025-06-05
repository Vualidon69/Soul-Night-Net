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

            // Explicitly reference frmEditBillDetail to help IDE recognize it
            // frmEditBillDetail tempForm = new frmEditBillDetail();
        }
        // bang de su ly du lieu mon an


        /// <summary>
        /// text bảng xem có sảy ra chưa cái này load ngay đầu tiên
        /// </summary>
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
            dgvMenu_CellClick_pln_img(sender, e);// đọc file ảnh
            dgvMenu_CellClick_pln_chiTietMonAn(sender, e); // lấy dgv vô chi tiết món ăn

        }
        // đọc file ảnh
        private void dgvMenu_CellClick_pln_img(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu click vào dòng hợp lệ
            {
                dgvMenu.ClearSelection(); // Xóa lựa chọn cũ

                foreach (DataGridViewRow row in dgvMenu.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.DefaultCellStyle.BackColor = Color.White; // Reset màu các dòng
                    }
                }

                // Lấy mã món ăn
                string maMon = dgvMenu.Rows[e.RowIndex].Cells[0].Value.ToString();
                string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

                // Đường dẫn thư mục chứa ảnh
                string imgFolder = Path.Combine(projectRoot, "img");

                // Đường dẫn file ảnh món ăn
                string path = Path.Combine(imgFolder, maMon + ".jpg");

                // Đường dẫn file ảnh mặc định
                string defaultImage = Path.Combine(imgFolder, "default.jpg");

                // Hàm load ảnh an toàn
                LoadImage(img_monAn, File.Exists(path) ? path : defaultImage);

                // Căn chỉnh ảnh
                img_monAn.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        // lấy dgv vô chi tiết món ăn
        private void dgvMenu_CellClick_pln_chiTietMonAn(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu người dùng chọn dòng hợp lệ
            {
                DataGridViewRow row = dgvMenu.Rows[e.RowIndex];

                // Hiển thị thông tin lên các TextBox
                txt_maMon.Text = row.Cells["Mã món"].Value.ToString();
                txt_tenMon.Text = row.Cells["Tên món"].Value.ToString();
                txt_Gia.Text = row.Cells["Giá (VND)"].Value.ToString();
                // Hiển thị hình ảnh nếu có
                string foodID = row.Cells["Mã món"].Value.ToString();

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

        // ấn vào sửa chi tiết hóa đơn hiện ra form sửa
        private void btnEdit_Click_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvMenu.SelectedRows[0];

                // Tạo danh sách món ăn cho ComboBox
                List<MenuItem> menuItems = new List<MenuItem>();
                foreach (DataRow row in ((DataTable)dgvMenu.DataSource).Rows)
                {
                    menuItems.Add(new MenuItem
                    {
                        TenMon = row["Tên món"].ToString(),
                        Gia = decimal.Parse(row["Giá (VND)"].ToString().Replace(" VND", "").Replace(",", ""))
                    });
                }

                // Tạo form chỉnh sửa
                frmEditBillDetail editForm = new frmEditBillDetail();
                editForm.SetMenuList(menuItems);

                // Lấy thông tin hiện tại
                string tenMon = selectedRow.Cells["Tên món"].Value.ToString();
                int soLuong = 1; // Mặc định số lượng là 1 khi chỉnh sửa
                decimal thanhTien = decimal.Parse(selectedRow.Cells["Giá (VND)"].Value.ToString()
                                                 .Replace(" VND", "").Replace(",", ""));

                // Thiết lập dữ liệu cho form
                editForm.SetData(tenMon, soLuong, thanhTien);

                // Hiển thị form và xử lý kết quả
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Cập nhật thông tin món ăn
                        selectedRow.Cells["Tên món"].Value = editForm.TenMon;

                        // Format lại giá tiền theo định dạng "xx,xxx VND"
                        selectedRow.Cells["Giá (VND)"].Value = editForm.DonGia.ToString("N0") + " VND";

                        MessageBox.Show("Cập nhật thông tin món thành công!", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật món: " + ex.Message, "Lỗi",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần chỉnh sửa", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void img_monAn_Click(object sender, EventArgs e)
        {

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
                        newRow["Mã món"] = formThemMon.MaMon;
                        newRow["Tên món"] = formThemMon.TenMon;
                        newRow["Giá (VND)"] = formThemMon.GiaMon.ToString("N0") + " VND";

                        dt.Rows.Add(newRow);

                        // Refresh the DataGridView
                        dgvMenu.DataSource = dt;

                        // Save the image if it exists
                        if (formThemMon.AnhMon != null)
                        {
                            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                            string imgFolder = Path.Combine(projectRoot, "img");

                            // Create directory if it doesn't exist
                            if (!Directory.Exists(imgFolder))
                            {
                                Directory.CreateDirectory(imgFolder);
                            }

                            // Save the image
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
            // Check if a row is selected in the DataGridView
            if (dgvMenu.CurrentRow != null && !dgvMenu.CurrentRow.IsNewRow)
            {
                // Confirm deletion with user
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa món này?", "Xác nhận xóa",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Get the food ID from the selected row
                        string maMon = dgvMenu.CurrentRow.Cells["Mã món"].Value.ToString();

                        // Remove the row from the DataGridView
                        DataTable dt = (DataTable)dgvMenu.DataSource;
                        dt.Rows.RemoveAt(dgvMenu.CurrentRow.Index);

                        // Delete the associated image if it exists
                        string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                        string imgFolder = Path.Combine(projectRoot, "img");
                        string imagePath = Path.Combine(imgFolder, maMon + ".jpg");

                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }

                        // Clear the textboxes after deletion
                        txt_maMon.Clear();
                        txt_tenMon.Clear();
                        txt_Gia.Clear();
                        img_monAn.Image = null;

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
    }
}
