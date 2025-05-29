using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Giả lập dữ liệu - Thay bằng code truy vấn CSDL thực tế
            DataTable dt = new DataTable();
            dt.Columns.Add("Số HD", typeof(string));
            dt.Columns.Add("Tên khách hàng", typeof(string));
            dt.Columns.Add("Máy", typeof(string));
            dt.Columns.Add("Số giờ", typeof(string));
            dt.Columns.Add("Thành tiền", typeof(string));
            dt.Columns.Add("Ngày hóa đơn", typeof(string));
            dt.Columns.Add("Hình thức trả", typeof(string));

            // Thêm dữ liệu mẫu
            dt.Rows.Add("1033", "Văn Phú", "4", "23h17m", "1.729.578 VND", "03/26/2024 12:44:03", "Thẻ ngân hàng");
            dt.Rows.Add("1034", "Gấm Kamí", "6", "0h13m", "38.977 VND", "03/26/2024 13:18:51", "Chuyển khoản ngân hài");
            dt.Rows.Add("1035", "Gấm Kamí", "8", "0h0m", "238 VND", "03/26/2024 13:16:01", "Chuyển khoản ngân hài");
            dt.Rows.Add("1036", "Gấm Kamí", "3", "0h3m", "3.322 VND", "03/26/2024 13:18:59", "Chuyển MOMO");
            dt.Rows.Add("1037", "Gấm Kamí", "4", "0h0m", "9.106 VND", "03/26/2024 13:16:35", "Thẻ ngân hàng");
            dt.Rows.Add("1038", "Gấm Kamí", "5", "0h0m", "46 VND", "03/26/2024 13:23:35", "Thẻ ngân hàng");
            dt.Rows.Add("1039", "Gấm Kamí", "4", "0h0m", "52 VND", "03/26/2024 13:24:33", "Thẻ ngân hàng");
            dt.Rows.Add("1040", "Gấm Kamí", "4", "0h0m", "80 VND", "03/26/2024 13:26:18", "Thẻ ngân hàng");

            dataGridView_LichSu.DataSource = dt;

            // Định dạng cột
            if (dataGridView_LichSu.Columns.Contains("Thành tiền"))
            {
                 dataGridView_LichSu.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void button_XemChiTiet_Click(object sender, EventArgs e)
        {
            if (dataGridView_LichSu.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView_LichSu.SelectedRows[0];
                // Assuming the column order based on the DataTable definition in LoadData()
                string soHD = row.Cells["Số HD"].Value?.ToString();
                string tenKhachHang = row.Cells["Tên khách hàng"].Value?.ToString();
                string may = row.Cells["Máy"].Value?.ToString();
                string soGio = row.Cells["Số giờ"].Value?.ToString();
                string thanhTien = row.Cells["Thành tiền"].Value?.ToString();
                string ngayHoaDon = row.Cells["Ngày hóa đơn"].Value?.ToString();
                string hinhThucTra = row.Cells["Hình thức trả"].Value?.ToString();

                string message = $"Số HD: {soHD}\n" +
                                $"Tên khách hàng: {tenKhachHang}\n" +
                                $"Máy: {may}\n" +
                                $"Số giờ: {soGio}\n" +
                                $"Thành tiền: {thanhTien}\n" +
                                $"Ngày hóa đơn: {ngayHoaDon}\n" +
                                $"Hình thức trả: {hinhThucTra}";

                MessageBox.Show(message, "Chi tiết hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_xuatFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = $"LichSu_{DateTime.Now:yyyyMMdd}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Lịch Sử");

                        // Xuất header
                        for (int col = 0; col < dataGridView_LichSu.Columns.Count; col++)
                        {
                            worksheet.Cell(1, col + 1).Value = dataGridView_LichSu.Columns[col].HeaderText;
                        }

                        // Xuất dữ liệu
                        for (int row = 0; row < dataGridView_LichSu.Rows.Count; row++)
                        {
                            for (int col = 0; col < dataGridView_LichSu.Columns.Count; col++)
                            {
                                if (dataGridView_LichSu.Rows[row].Cells[col].Value != null)
                                {
                                    worksheet.Cell(row + 2, col + 1).Value = dataGridView_LichSu.Rows[row].Cells[col].Value.ToString();
                                }
                            }
                        }

                        // Lưu file
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
