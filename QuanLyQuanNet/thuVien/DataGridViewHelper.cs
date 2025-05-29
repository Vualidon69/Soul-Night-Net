using System;
using System.Drawing;
using System.Windows.Forms;

public static class DataGridViewHelper
{
    public static void SetupDefaultStyle(DataGridView dgv)
    {
        // Kích thước mặc định
        dgv.BorderStyle = BorderStyle.None;
        dgv.BackgroundColor = Color.White;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        // Cấu hình cơ bản
        dgv.AllowUserToAddRows = false;
        dgv.ReadOnly = true;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // Font và căn giữa
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        // Màu header
        dgv.EnableHeadersVisualStyles = false;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;

        // Đường kẻ và màu sắc
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgv.GridColor = Color.LightGray;

        // Tùy chỉnh khi chọn dòng
        dgv.DefaultCellStyle.SelectionBackColor = Color.LightGray;
        dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
        // Đảm bảo dòng được chọn khi click
        dgv.CellClick += (s, e) =>
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgv.Rows.Count)
                dgv.CurrentRow.Selected = true;
        };
        if (dgv.Rows.Count > 0)
        {
            dgv.Height = dgv.Rows.Count * dgv.RowTemplate.Height + dgv.ColumnHeadersHeight;
        }
    }
}
