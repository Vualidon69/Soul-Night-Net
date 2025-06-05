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
            if (dataGridView_LichSu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = dataGridView_LichSu.SelectedRows[0];

            string soHD = row.Cells["SoHD"].Value?.ToString();
            string maKH = row.Cells["MaKH"].Value?.ToString();
            string maNV = row.Cells["MaNV"].Value?.ToString();
            string may = row.Cells["May"].Value?.ToString();
            string soGio = row.Cells["SoGio"].Value?.ToString();
            string thanhTien = row.Cells["ThanhTien"].Value?.ToString();
            string ngayHoaDon = Convert.ToDateTime(row.Cells["NgayHoaDon"].Value).ToString("dd/MM/yyyy HH:mm");
            string hinhThucTra = row.Cells["HinhThucTra"].Value?.ToString();

            string message = $"Số HĐ: {soHD}\n" +
                             $"Mã KH: {maKH}\n" +
                             $"Mã NV: {maNV}\n" +
                             $"Máy: {may}\n" +
                             $"Số giờ: {soGio}\n" +
                             $"Thành tiền: {thanhTien} VNĐ\n" +
                             $"Ngày hóa đơn: {ngayHoaDon}\n" +
                             $"Hình thức trả: {hinhThucTra}";

            MessageBox.Show(message, "Chi tiết hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
