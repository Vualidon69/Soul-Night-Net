using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.ChucNang.Tinh_trang_may
{
    public partial class frmChinhSuaDichVu : Form
    {
        public DataTable DichVuTable { get; set; }
        public DataTable MenuTable { get; set; }

        public frmChinhSuaDichVu(DataTable currentDichVu, DataTable menu)
        {
            InitializeComponent();
            DichVuTable = currentDichVu.Copy();
            MenuTable = menu;
            dgvDichVu.DataSource = DichVuTable;
            dgvMenu.DataSource = MenuTable;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dgvMenu.SelectedRows.Count > 0)
            {
                var row = dgvMenu.SelectedRows[0];
                string tenMon = row.Cells["Tên món"].Value.ToString();
                string gia = row.Cells["Giá (VND)"].Value.ToString();
                int soLuong = 1;
                if (InputBox("Nhập số lượng", "", ref soLuong) == DialogResult.OK)
                {
                    var found = DichVuTable.Rows.Cast<DataRow>().FirstOrDefault(r => r["TenMon"].ToString() == tenMon);
                    if (found != null)
                    {
                        found["SoLuong"] = Convert.ToInt32(found["SoLuong"]) + soLuong;
                        found["ThanhTien"] = Convert.ToDecimal(gia.Replace(" VND", "").Replace(",", "")) * Convert.ToInt32(found["SoLuong"]);
                    }
                    else
                    {
                        DichVuTable.Rows.Add(tenMon, soLuong, Convert.ToDecimal(gia.Replace(" VND", "").Replace(",", "")) * soLuong);
                    }

                    // ➕ Ghi xuống DB bảng May (ví dụ chỉ lưu tên món như là tên máy, tuỳ mục đích)
                    string query = "INSERT INTO May (TenMay, TinhTrang) VALUES (@TenMay, @TinhTrang)";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@TenMay", tenMon },
                        { "@TinhTrang", "Hoạt động" } // mặc định, hoặc cho chọn
                    };
                    DataProvider.Instance.ExecNonQuery(query, parameters);
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.SelectedRows.Count > 0)
            {
                string tenMay = dgvDichVu.SelectedRows[0].Cells["TenMon"].Value.ToString();

                // ⛔ Xoá trong DB
                string query = "DELETE FROM May WHERE TenMay = @TenMay";
                var parameters = new Dictionary<string, object>
                {
                    { "@TenMay", tenMay }
                };
                DataProvider.Instance.ExecNonQuery(query, parameters);

                // ⛔ Xoá khỏi bảng hiện tại
                dgvDichVu.Rows.RemoveAt(dgvDichVu.SelectedRows[0].Index);
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.SelectedRows.Count > 0)
            {
                var row = dgvDichVu.SelectedRows[0];
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                if (InputBox("Sửa số lượng", "Số lượng:", ref soLuong) == DialogResult.OK)
                {
                    string tenMay = row.Cells["TenMon"].Value.ToString();

                    decimal gia = Convert.ToDecimal(row.Cells["ThanhTien"].Value) / Convert.ToInt32(row.Cells["SoLuong"].Value);
                    row.Cells["SoLuong"].Value = soLuong;
                    row.Cells["ThanhTien"].Value = gia * soLuong;

                    // ✏️ Update tình trạng máy (nếu có) trong DB
                    string query = "UPDATE May SET TinhTrang = @TinhTrang WHERE TenMay = @TenMay";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@TinhTrang", "Đang sử dụng" }, // hardcode hoặc cho chọn tình trạng tùy mày
                        { "@TenMay", tenMay }
                    };
                    DataProvider.Instance.ExecNonQuery(query, parameters);
                }
            }
        }


        public static DialogResult InputBox(string title, string promptText, ref int value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value.ToString();

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                int.TryParse(textBox.Text, out value);
            }
            return dialogResult;
        }
    }
} 