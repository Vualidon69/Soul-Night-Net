using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.ChucNang
{
    public partial class admin_Menu : UserControl
    {
        public admin_Menu()
        {
            InitializeComponent();
            LoadMenuData();
            dgv_style();

        }
        // bang de su ly du lieu mon an


        /// <summary>
        /// text bảng xem có sảy ra chưa cái này load ngay đầu tiên
        /// </summary>
        private void LoadMenuData()
        {
            DataTable dt = new DataTable();
            dgvMenu.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvMenu.EnableHeadersVisualStyles = false;
            dgvMenu.GridColor = Color.White; // Ẩn viền giữa các ô
            dt.Columns.Add("Mã món", typeof(string));
            dt.Columns.Add("Tên món", typeof(string));
            dt.Columns.Add("Giá (VND)", typeof(string));

            // sửa lại đoạn này làm sao cho để trời thành maMon
            dt.Rows.Add("MA001", "Coca cola", "10,000 VND");
            dt.Rows.Add("MA002", "Pepsi", "10,000 VND");
            dt.Rows.Add("MA004", "Trái cây", "40,000 VND");
            dt.Rows.Add("MA006", "Thuốc lá 3 số", "20,000 VND");
            dt.Rows.Add("MA007", "Mì trứng", "50,000 VND");
            dt.Rows.Add("MA010", "Mì gói", "50,000 VND");
            dt.Rows.Add("MA012", "BCS", "199,000 VND");

            dgvMenu.EnableHeadersVisualStyles = false;
            dgvMenu.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvMenu.ColumnHeadersDefaultCellStyle.BackColor;
            dgvMenu.DataSource = dt;

            dgvMenu.Height = dgvMenu.Rows.Count * dgvMenu.RowTemplate.Height + dgvMenu.ColumnHeadersHeight;
            // giúp click vô vẫn hiện màu
            dgvMenu.CellClick += (s, e) =>
            {
                dgvMenu.CurrentRow.Selected = true;
            };

        }
        private void dgv_style()
        {

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
                string billID = dgvMenu.SelectedRows[0].Cells["Mã món"].Value.ToString();
                frmEditBillDetail editForm = new frmEditBillDetail();
                editForm.ShowDialog();
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

        private void admin_Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
