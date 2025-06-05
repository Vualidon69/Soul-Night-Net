using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.ChucNang.khachhang
{
    public partial class uc_khachhang : UserControl // Đổi tên class thành chữ thường để khớp với tên file
    {
        private DataTable dtKhachHang;

        public uc_khachhang()
        {
            InitializeComponent();
            LoadKhachHangData();
            DgvStyle();
            txtTimKiem.Text = "Tìm kiếm SĐT";
            txtTimKiem.ForeColor = Color.Gray;
        }

        // [ connect database here ]
        private void LoadKhachHangData()
        {
            dtKhachHang = new DataTable();
            string query = "Select * From Khach"; // Câu lệnh SQL để lấy dữ liệu khách hàng

            dtKhachHang = DataProvider.Instance.ExecuteQuery(query);

            dgvKhachHang.DataSource = dtKhachHang;

            if (dgvKhachHang.Columns["MaKH"] != null) dgvKhachHang.Columns["MaKH"].HeaderText = "Mã khách hàng";
            if (dgvKhachHang.Columns["HoTen"] != null) dgvKhachHang.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvKhachHang.Columns["SDT"] != null) dgvKhachHang.Columns["SDT"].HeaderText = "SĐT";
            if (dgvKhachHang.Columns["Email"] != null) dgvKhachHang.Columns["Email"].HeaderText = "Email";
            if (dgvKhachHang.Columns["SoDiem"] != null) dgvKhachHang.Columns["SoDiem"].HeaderText = "Số điểm";

            UpdateDataGridViewHeight();
        }

        private void DgvStyle()
        {
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dgvKhachHang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvKhachHang.EnableHeadersVisualStyles = false;

            dgvKhachHang.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvKhachHang.GridColor = Color.LightGray;

            dgvKhachHang.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 200, 200);
            dgvKhachHang.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.BorderStyle = BorderStyle.None;

            UpdateRowColors();

            dgvKhachHang.RowHeadersVisible = false;
            dgvKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.AllowUserToAddRows = false;

            if (dgvKhachHang.Columns["MaKH"] != null)
            {
                dgvKhachHang.Columns["MaKH"].DefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
                dgvKhachHang.Columns["MaKH"].DefaultCellStyle.ForeColor = Color.Black;
                dgvKhachHang.Columns["MaKH"].DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            }
        }

        private void UpdateRowColors()
        {
            for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
            {
                if (i % 2 == 0)
                    dgvKhachHang.Rows[i].DefaultCellStyle.BackColor = Color.White;
                else
                    dgvKhachHang.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void UpdateDataGridViewHeight()
        {
            int rowHeight = dgvKhachHang.RowTemplate.Height;
            int headerHeight = dgvKhachHang.ColumnHeadersHeight;
            int totalRows = dgvKhachHang.Rows.Count;
            int newHeight = (totalRows * rowHeight) + headerHeight + 2;
            dgvKhachHang.Height = Math.Min(newHeight, pnlMain.Height - 60);
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm SĐT")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tìm kiếm SĐT";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm SĐT") return;

            string filter = string.Format("[SDT] LIKE '%{0}%'", txtTimKiem.Text);
            (dgvKhachHang.DataSource as DataTable).DefaultView.RowFilter = filter;

            UpdateDataGridViewHeight();
            UpdateRowColors();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemKhachHang formThem = new frmThemKhachHang(dtKhachHang);
            if (formThem.ShowDialog() == DialogResult.OK)
            {
                UpdateDataGridViewHeight();
                UpdateRowColors();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)dgvKhachHang.SelectedRows[0].DataBoundItem).Row;
                frmSuaKhachHang formSua = new frmSuaKhachHang(row);
                if (formSua.ShowDialog() == DialogResult.OK)
                {
                    UpdateRowColors();
                }
            }
            else
            {
                MessageBox.Show("Chọn một khách hàng trước đi bạn ơi! 😅", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                // Lấy DataRow từ dòng đang chọn
                DataRow row = ((DataRowView)dgvKhachHang.SelectedRows[0].DataBoundItem).Row;

                // Kiểm tra cột tồn tại
                if (!dtKhachHang.Columns.Contains("MaKhachHang"))
                {
                    MessageBox.Show("Không tìm thấy cột MaKH trong dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string maKH = dgvKhachHang.SelectedRows[0].Cells["MaKhachHang"].Value.ToString();


                // Xác nhận xóa
                var confirm = MessageBox.Show($"Bạn có chắc muốn xóa khách hàng có mã '{maKH}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                // Xóa khỏi CSDL
                string query = "DELETE FROM Khach WHERE MaKhachHang = @MaKH";
                var parameters = new Dictionary<string, object>
        {
            { "@MaKH", maKH }
        };
                int rowsAffected = DataProvider.Instance.ExecNonQuery(query, parameters);

                // Xóa khỏi DataTable
                dtKhachHang.Rows.Remove(row);

                MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateDataGridViewHeight();
                UpdateRowColors();
            }
            else
            {
                MessageBox.Show("Chọn một khách hàng trước đi bạn ơi! 😅", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvKhachHang.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dgvKhachHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRow row = ((DataRowView)dgvKhachHang.Rows[e.RowIndex].DataBoundItem).Row;
                frmSuaKhachHang formSua = new frmSuaKhachHang(row);
                if (formSua.ShowDialog() == DialogResult.OK)
                {
                    UpdateRowColors();
                }
            }
        }
    }
}