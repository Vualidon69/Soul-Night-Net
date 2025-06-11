using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.NhanVien
{
    public partial class admin_NhanVien : UserControl
    {
        public admin_NhanVien()
        {
            InitializeComponent();
            LoadData();
            SetupComboBoxes();
        }

        private void LoadData()
        {
            string query = "SELECT * FROM NhanVien";
            dtNhanVien = GetNhanVien(); // Hàm này lấy dữ liệu từ SQL, file, etc.
            // Gán DataTable làm nguồn dữ liệu cho DataGridView
            dataGridView_NhanVien.DataSource = dtNhanVien;
            dataGridView_NhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        public DataTable GetNhanVien()
        {
            // Tạo một DataTable mới để chứa dữ liệu
            DataTable dtNhanVien = new DataTable();

            // Lấy chuỗi kết nối từ file App.config
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Sử dụng 'using' để đảm bảo kết nối được đóng tự động
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Câu lệnh SQL để lấy tất cả nhân viên.
                // Hãy chắc chắn tên bảng (NhanVien) và các cột là chính xác.
                string query = "SELECT ID, HoTen, ChucVu, LoaiNhanVien, DiaChi, SDT, NgaySinh, NgayVaoLam, TaiKhoan FROM NhanVien";

                // Sử dụng SqlDataAdapter để lấy dữ liệu và điền vào DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    try
                    {
                        // Mở kết nối
                        connection.Open();

                        // Đổ dữ liệu từ adapter vào DataTable
                        adapter.Fill(dtNhanVien);
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi nếu không thể kết nối hoặc truy vấn
                        MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message);
                    }
                } // Adapter sẽ được giải phóng ở đây
            } // Connection sẽ được đóng và giải phóng ở đây

            return dtNhanVien;
        }
        private void SetupComboBoxes()
        {
            DataGridViewHelper.SetupDefaultStyle(dataGridView_NhanVien);
            comboBox_ChucVu.Items.AddRange(new string[] { "Quản lý", "Nhân viên", "Kế toán" });
            comboBox_LoaiNhanVien.Items.AddRange(new string[] { "Full-time", "Part-time", "Thực tập" });
        }

        private void ClearInputs()
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

        private void button_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("ID không được để trống!");
                return;
            }

            string query = @"INSERT INTO NhanVien (ID, HoTen, ChucVu, LoaiNhanVien, DiaChi, SDT, NgaySinh, NgayVaoLam)
                             VALUES (@ID, @HoTen, @ChucVu, @LoaiNhanVien, @DiaChi, @SDT, @NgaySinh, @NgayVaoLam)";

            var parameters = new Dictionary<string, object>()
            {
                ["@ID"] = textBoxID.Text.Trim(),
                ["@HoTen"] = textBox_HoTen.Text.Trim(),
                ["@ChucVu"] = comboBox_ChucVu.Text,
                ["@LoaiNhanVien"] = comboBox_LoaiNhanVien.Text,
                ["@DiaChi"] = textBox_DiaChi.Text.Trim(),
                ["@SDT"] = textBox_SDT.Text.Trim(),
                ["@NgaySinh"] = dateTimePicker_NgaySinh.Value,
                ["@NgayVaoLam"] = dateTimePicker_NgayVaoLam.Value,

            };

            int result = DataProvider.Instance.ExecNonQuery(query, parameters);

            if (result >= 0)
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                LoadData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Phải chọn nhân viên để sửa");
                return;
            }

            string query = @"UPDATE NhanVien SET 
                                HoTen = @HoTen,
                                ChucVu = @ChucVu,
                                LoaiNhanVien = @LoaiNhanVien,
                                DiaChi = @DiaChi,
                                SDT = @SDT,
                                NgaySinh = @NgaySinh,
                                NgayVaoLam = @NgayVaoLam,
                                TaiKhoan = @TaiKhoan,
                                MatKhau = @MatKhau
                             WHERE ID = @ID";

            var parameters = new Dictionary<string, object>()
            {
                ["@ID"] = textBoxID.Text.Trim(),
                ["@HoTen"] = textBox_HoTen.Text.Trim(),
                ["@ChucVu"] = comboBox_ChucVu.Text,
                ["@LoaiNhanVien"] = comboBox_LoaiNhanVien.Text,
                ["@DiaChi"] = textBox_DiaChi.Text.Trim(),
                ["@SDT"] = textBox_SDT.Text.Trim(),
                ["@NgaySinh"] = dateTimePicker_NgaySinh.Value,
                ["@NgayVaoLam"] = dateTimePicker_NgayVaoLam.Value,
                ["@TaiKhoan"] = textBox_TaiKhoan.Text.Trim(),
                ["@MatKhau"] = textBox_MatKhau.Text.Trim()
            };

            int result = DataProvider.Instance.ExecNonQuery(query, parameters);
            if (result >= 0)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Không thể cập nhật");
            }
        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView_NhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa!");
                return;
            }

            string id = textBoxID.Text.Trim();
            var confirm = MessageBox.Show($"Xóa nhân viên ID {id}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM NhanVien WHERE ID = @ID";
                var parameters = new Dictionary<string, object>() { ["@ID"] = id };
                int result = DataProvider.Instance.ExecNonQuery(query, parameters);
                if (result > 0)
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Không xóa được!");
                }
            }
        }

        private void dataGridView_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_NhanVien.SelectedRows.Count > 0)
            {
                var row = dataGridView_NhanVien.SelectedRows[0];
                if (row.DataBoundItem is DataRowView drv)
                {
                    DataRow r = drv.Row;
                    textBoxID.Text = r["ID"].ToString();
                    textBox_HoTen.Text = r["HoTen"].ToString();
                    comboBox_ChucVu.Text = r["ChucVu"].ToString();
                    comboBox_LoaiNhanVien.Text = r["LoaiNhanVien"].ToString();
                    textBox_DiaChi.Text = r["DiaChi"].ToString();
                    textBox_SDT.Text = r["SDT"].ToString();
                    textBox_TaiKhoan.Text = r.Table.Columns.Contains("TaiKhoan") ? r["TaiKhoan"].ToString() : "";
                    textBox_MatKhau.Text = r.Table.Columns.Contains("MatKhau") ? r["MatKhau"].ToString() : "";
                    dateTimePicker_NgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
                    dateTimePicker_NgayVaoLam.Value = Convert.ToDateTime(r["NgayVaoLam"]);
                }
            }
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            string search = textBox_TimKiem.Text.Trim().ToLower();
            foreach (DataGridViewRow row in dataGridView_NhanVien.Rows)
            {
                if (row.DataBoundItem is DataRowView drv)
                {
                    string ten = drv["HoTen"].ToString().ToLower();
                    row.Visible = ten.Contains(search);
                }
            }
        }

        private void button_chamCong_Click(object sender, EventArgs e)
        {
            // TODO: Chức năng chấm công chưa được cài đặt
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: xử lý khi comboBox1 thay đổi chọn
        }
        DataTable dtNhanVien;
        private void textBox_TimKiem_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}