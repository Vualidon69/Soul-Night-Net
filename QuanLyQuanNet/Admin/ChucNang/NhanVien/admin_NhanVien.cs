using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.NhanVien
{
    public partial class admin_NhanVien : UserControl
    {
        public admin_NhanVien()
        {
            InitializeComponent();
            DataGridViewHelper.SetupDefaultStyle(dataGridView_NhanVien);
            LoadData();
            SetupComboBoxes();
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();

            // Thêm tất cả các cột tương ứng với form nhập liệu
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Chức vụ", typeof(string));
            dt.Columns.Add("Loại nhân viên", typeof(string));
            dt.Columns.Add("Địa chỉ", typeof(string));
            dt.Columns.Add("SDT", typeof(string));
            dt.Columns.Add("Ngày sinh", typeof(DateTime));
            dt.Columns.Add("Ngày vào làm", typeof(DateTime));
            dt.Columns.Add("Tài khoản", typeof(string));
            dt.Columns.Add("Mật khẩu", typeof(string));

            // Thêm dữ liệu mẫu
            dt.Rows.Add(1, "Hoài Hải", "Quản lý", "Full-time", "123 Đường ABC", "0912345678",
                       new DateTime(1990, 5, 15), new DateTime(2023, 3, 16), "hoaihai", "123456");
            dt.Rows.Add(2, "Văn Phú", "Nhân viên", "Part-time", "456 Đường XYZ", "0987654321",
                       new DateTime(1995, 8, 20), new DateTime(2023, 3, 16), "vanphu", "abcdef");
            dt.Rows.Add(3, "Tuân Vũ", "Nhân viên", "Full-time", "789 Đường DEF", "0978123456",
                       new DateTime(1992, 11, 5), new DateTime(2023, 6, 25), "tuanvu", "password");

            dataGridView_NhanVien.DataSource = dt;

            // Ẩn một số cột nếu cần
            dataGridView_NhanVien.Columns["Mật khẩu"].Visible = false;
            dataGridView_NhanVien.Columns["Tài khoản"].Visible = false;
        }

        private void SetupComboBoxes()
        {
          

            // Thêm dữ liệu cho ComboBox Chức vụ
            comboBox_ChucVu.Items.AddRange(new string[] { "Quản lý", "Nhân viên", "Kế toán" });

            // Thêm dữ liệu cho ComboBox Loại nhân viên
            comboBox_LoaiNhanVien.Items.AddRange(new string[] { "Full-time", "Part-time", "Thực tập" });
        }
        private void button_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(textBox_HoTen.Text) ||
                    string.IsNullOrEmpty(textBox_DiaChi.Text) ||
                    string.IsNullOrEmpty(textBox_SDT.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên");
                    return;
                }

                DataTable dt = (DataTable)dataGridView_NhanVien.DataSource;

                // Tạo ID mới (tăng dần từ ID lớn nhất hiện có)
                int newID = dt.AsEnumerable().Any() ? dt.AsEnumerable().Max(r => r.Field<int>("ID")) + 1 : 1;

                // Thêm dòng mới với đầy đủ thông tin
                dt.Rows.Add(
                    newID,
                    textBox_HoTen.Text,
                    comboBox_ChucVu.SelectedItem?.ToString() ?? "Nhân viên",
                    comboBox_LoaiNhanVien.SelectedItem?.ToString() ?? "Full-time",
                    textBox_DiaChi.Text,
                    textBox_SDT.Text,
                    dateTimePicker_NgaySinh.Value,
                    dateTimePicker_NgayVaoLam.Value,
                    textBox_TaiKhoan.Text,
                    textBox_MatKhau.Text
                );

                ClearInputControls();
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            // Xử lý xóa nhân viên
            if (dataGridView_NhanVien.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView_NhanVien.SelectedRows)
                    {
                        dataGridView_NhanVien.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa");
            }
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            // Xử lý sửa thông tin nhân viên
            if (dataGridView_NhanVien.SelectedRows.Count > 0)
            {
                try
                {
                    // Cập nhật thông tin từ các control nhập liệu vào dòng được chọn
                    DataGridViewRow selectedRow = dataGridView_NhanVien.SelectedRows[0];
                    selectedRow.Cells["Họ tên"].Value = textBox_HoTen.Text;
                    selectedRow.Cells["Chức vụ"].Value = comboBox_ChucVu.SelectedItem?.ToString();
                    selectedRow.Cells["Ngày vào làm"].Value = dateTimePicker_NgayVaoLam.Value;

                    MessageBox.Show("Cập nhật thông tin thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa");
            }
        }

        private void button_chamCong_Click(object sender, EventArgs e)
        {
            // Xử lý chấm công
            MessageBox.Show("Chức năng chấm công đang được phát triển");
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            // Xử lý tìm kiếm nhân viên
            string searchText = textBox_TimKiem.Text.ToLower();
            foreach (DataGridViewRow row in dataGridView_NhanVien.Rows)
            {
                if (row.Cells["Họ tên"].Value != null &&
                    row.Cells["Họ tên"].Value.ToString().ToLower().Contains(searchText))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void dataGridView_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            // Chỉ xử lý khi có dòng được chọn
            if (dataGridView_NhanVien.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dataGridView_NhanVien.SelectedRows[0];

                // Lấy DataRow tương ứng từ DataSource
                DataRowView rowView = (DataRowView)selectedRow.DataBoundItem;
                DataRow row = rowView.Row;

                // Hiển thị thông tin đầy đủ lên các control
                textBoxID.Text = selectedRow.Index.ToString(); // Hoặc ID từ database nếu có
                textBox_HoTen.Text = row["Họ tên"].ToString();
                comboBox_ChucVu.SelectedItem = row["Chức vụ"].ToString();

                // Nếu có thêm các trường khác trong DataTable
                if (row.Table.Columns.Contains("Địa chỉ"))
                    textBox_DiaChi.Text = row["Địa chỉ"].ToString();

                if (row.Table.Columns.Contains("SDT"))
                    textBox_SDT.Text = row["SDT"].ToString();

                if (row.Table.Columns.Contains("Ngày sinh"))
                    dateTimePicker_NgaySinh.Value = Convert.ToDateTime(row["Ngày sinh"]);

                if (row.Table.Columns.Contains("Ngày vào làm"))
                    dateTimePicker_NgayVaoLam.Value = Convert.ToDateTime(row["Ngày vào làm"]);

                if (row.Table.Columns.Contains("Tài khoản"))
                    textBox_TaiKhoan.Text = row["Tài khoản"].ToString();

                if (row.Table.Columns.Contains("Mật khẩu"))
                    textBox_MatKhau.Text = row["Mật khẩu"].ToString();

                if (row.Table.Columns.Contains("Loại nhân viên"))
                    comboBox_LoaiNhanVien.SelectedItem = row["Loại nhân viên"].ToString();
            }
        }

        private void ClearInputControls()
        {
            textBoxID.Clear();
            textBox_HoTen.Clear();
            textBox_DiaChi.Clear();
            textBox_SDT.Clear();
            textBox_TaiKhoan.Clear();
            textBox_MatKhau.Clear();
            comboBox_ChucVu.SelectedIndex = -1;
            comboBox_LoaiNhanVien.SelectedIndex = -1;
            dateTimePicker_NgaySinh.Value = DateTime.Now;
            dateTimePicker_NgayVaoLam.Value = DateTime.Now;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Xử lý khi chọn ComboBox
        }
    }
}