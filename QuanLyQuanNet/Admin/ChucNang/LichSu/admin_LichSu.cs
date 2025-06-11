using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace QuanLyQuanNet.Admin.ChucNang.LichSu
{
    public partial class uc_LichSu : UserControl
    {
        public uc_LichSu()
        {
            InitializeComponent();
            SetupUI();
            LoadData();
        }

        private void SetupUI()
        {
            DataGridViewHelper.SetupDefaultStyle(dataGridView_LichSu);
        }

        private void LoadData()
        {
            string query = "SELECT * FROM HoaDon";

            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);
                dataGridView_LichSu.DataSource = dt;

                if (dataGridView_LichSu.Columns.Contains("ThanhTien"))
                {
                    dataGridView_LichSu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                    dataGridView_LichSu.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dataGridView_LichSu.Columns.Contains("NgayHoaDon"))
                {
                    dataGridView_LichSu.Columns["NgayHoaDon"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dataGridView_LichSu.Columns["NgayHoaDon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dataGridView_LichSu.Columns.Contains("HinhThucTra"))
                {
                    dataGridView_LichSu.Columns["HinhThucTra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_XemChiTiet_Click(object sender, EventArgs e)
        {
            // **1. Check if a row is selected**
            if (dataGridView_LichSu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                DataGridViewRow row = dataGridView_LichSu.SelectedRows[0];

                // **2. Safely retrieve cell values (handle nulls)**
                string soHD = row.Cells["SoHD"].Value?.ToString() ?? "N/A";
                string maKH = row.Cells["MaKH"].Value?.ToString() ?? "N/A";
                string maNV = row.Cells["MaNV"].Value?.ToString() ?? "N/A";
                string may = row.Cells["May"].Value?.ToString() ?? "N/A";
                string soGio = row.Cells["SoGio"].Value?.ToString() ?? "N/A";
                string thanhTien = row.Cells["ThanhTien"].Value?.ToString() ?? "0";
                string ngayHoaDon = "N/A";
                string hinhThucTra = row.Cells["HinhThucTra"].Value?.ToString() ?? "N/A";

                // **3. Handle date parsing safely**
                if (row.Cells["NgayHoaDon"].Value != null && DateTime.TryParse(row.Cells["NgayHoaDon"].Value.ToString(), out DateTime date))
                {
                    ngayHoaDon = date.ToString("dd/MM/yyyy HH:mm");
                }

                // **4. Format the message with clear labels**
                string message = $@"=== CHI TIẾT HÓA ĐƠN ===
Số HĐ: {soHD}
Mã KH: {maKH}
Mã NV: {maNV}
Máy: {may}
Số giờ: {soGio} giờ
Thành tiền: {thanhTien:N0} VNĐ
Ngày hóa đơn: {ngayHoaDon}
Hình thức thanh toán: {hinhThucTra}";

                // **5. Show the details in a formatted MessageBox**
                MessageBox.Show(message, "Chi tiết hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_xuatFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu file Excel",
                FileName = $"LichSu_{DateTime.Now:yyyyMMdd}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Lịch Sử");

                        // Header
                        for (int col = 0; col < dataGridView_LichSu.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dataGridView_LichSu.Columns[col].HeaderText;
                        }

                        // Data
                        for (int row = 0; row < dataGridView_LichSu.Rows.Count; row++)
                        {
                            for (int col = 0; col < dataGridView_LichSu.Columns.Count; col++)
                            {
                                var cellValue = dataGridView_LichSu.Rows[row].Cells[col].Value;
                                worksheet.Cell(row + 2, col + 1).Value = cellValue?.ToString() ?? "";
                            }
                        }

                        workbook.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
