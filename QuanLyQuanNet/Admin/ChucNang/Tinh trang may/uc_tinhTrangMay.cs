using QuanLyQuanNet.Admin.ChucNang.menu;
using System.Data;

namespace QuanLyQuanNet.Admin.ChucNang.Tinh_trang_may
{
    public partial class uc_tinhTrangMay : UserControl
    {
        private List<MayTinh> danhSachMay;
        private const string FILE_PATH = "danhSachMay.json";
        private List<MenuItem> menuList = new List<MenuItem>
        {
            new MenuItem { TenMon = "Coca cola", Gia = 10000 },
            new MenuItem { TenMon = "Pepsi", Gia = 10000 },
            new MenuItem { TenMon = "Trái cây", Gia = 40000 },
            new MenuItem { TenMon = "Thuốc lá 3 số", Gia = 20000 },
            new MenuItem { TenMon = "Mì trứng", Gia = 50000 },
            new MenuItem { TenMon = "Mì gói", Gia = 50000 },
        };

        public uc_tinhTrangMay()
        {
            InitializeComponent();
            danhSachMay = new List<MayTinh>();

            // Cài đặt giao diện
            DataGridViewHelper.SetupDefaultStyle(dataGridView_thongTinMay);
            DataGridViewHelper.SetupDefaultStyle(dataGridView_GoiDichVu);
            
            SetupComboBoxes();
            LoadData();
            AddGoiDichVuColumns();

            // Đăng ký sự kiện
            dataGridView_thongTinMay.CellEndEdit += DataGridView_thongTinMay_CellEndEdit;
            comboBox_DanhSachMay.SelectedIndexChanged += ComboBox_DanhSachMay_SelectedIndexChanged;
            button_ThanhToan.Click += Button_ThanhToan_Click;
            button_XuatHoaDon.Click += Button_XuatHoaDon_Click;
            textBox_TongGio.TextChanged += textBox_TongGio_TextChanged;
            comboBox_loaiMay.SelectedIndexChanged += comboBox_loaiMay_SelectedIndexChanged;
            if (button_ChinhSuaMonAn != null) button_ChinhSuaMonAn.Click += button_ChinhSuaMonAn_Click;
        }

        private void SetupComboBoxes()
        {
            // Cài đặt ComboBox loại máy
            comboBox_loaiMay.Items.Clear();
            comboBox_loaiMay.Items.Add("Tất cả");
            comboBox_loaiMay.Items.AddRange(new[] { "Máy vip", "Máy Thường", "Máy Đôi" });
            comboBox_loaiMay.SelectedIndex = 0;

            // Cài đặt ComboBox phương thức thanh toán
            comboBox_PhuongThucThanhToan.Items.Clear();
            comboBox_PhuongThucThanhToan.Items.AddRange(new[] { "Tiền mặt", "Chuyển khoản", "Thẻ" });
            comboBox_PhuongThucThanhToan.SelectedIndex = 0;
        }
        private void LoadDataFromDatabase()
        {
            try
            {
                string query = "SELECT * FROM May"; // Table gốc trong hệ thống của bạn
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    danhSachMay = ConvertDataTableToMayTinhList(dt);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu máy tính trong database!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi truy vấn dữ liệu máy tính từ database: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                danhSachMay = new List<MayTinh>(); // fallback tránh crash
            }
        }

        private List<MayTinh> ConvertDataTableToMayTinhList(DataTable dt)
        {
            var list = new List<MayTinh>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MayTinh
                {
                    SoMay = row["SoMay"].ToString(), // hoặc "SoMay" nếu đúng tên cột
                    LoaiMay = row["LoaiMay"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                });
            }

            return list;
        }

        private void LoadData()
        {
            try
            {
                // Thử load từ database trước
                LoadDataFromDatabase();

                // Nếu danh sách rỗng thì fallback về file JSON
                if (danhSachMay == null || danhSachMay.Count == 0)
                {
                    if (System.IO.File.Exists(FILE_PATH))
                    {
                        string json = System.IO.File.ReadAllText(FILE_PATH);
                        danhSachMay = System.Text.Json.JsonSerializer.Deserialize<List<MayTinh>>(json) ?? new List<MayTinh>();
                    }
                    else
                    {
                        danhSachMay = new List<MayTinh>
                        {
                            new MayTinh { SoMay = "M001", LoaiMay = "Máy vip", TrangThai = "Đang hoạt động" },
                            new MayTinh { SoMay = "M002", LoaiMay = "Máy Thường", TrangThai = "Đang hoạt động" },
                            new MayTinh { SoMay = "M003", LoaiMay = "Máy Thường", TrangThai = "Bảo trì" },
                            new MayTinh { SoMay = "M004", LoaiMay = "Máy Đôi", TrangThai = "Đang hoạt động" },
                            new MayTinh { SoMay = "M005", LoaiMay = "Máy Thường", TrangThai = "Đã hỏng" }
                        };
                    }
                }

                RefreshDataGridView();
                UpdateComboBoxDanhSachMay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RefreshDataGridView()
        {
            dataGridView_thongTinMay.Rows.Clear();
            AddDefaultColumns(); // <-- Thêm dòng này
            foreach (var may in danhSachMay)
            {
                dataGridView_thongTinMay.Rows.Add(
                    danhSachMay.IndexOf(may) + 1,
                    may.SoMay,
                    may.LoaiMay,
                    may.TrangThai
                );
            }
        }

        private void UpdateComboBoxDanhSachMay()
        {
            comboBox_DanhSachMay.Items.Clear();
            comboBox_DanhSachMay.Items.AddRange(danhSachMay.Select(m => m.SoMay).ToArray());
        }

        private void SaveData()
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(danhSachMay);
                System.IO.File.WriteAllText(FILE_PATH, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //============================ THÊM MÁY ============================//
        private void button_themMay_Click(object sender, EventArgs e)
        {
            try
            {
                string newSoMay = "M" + (danhSachMay.Count + 1).ToString("D3");
                var mayMoi = new MayTinh
                {
                    SoMay = newSoMay,
                    LoaiMay = "Máy Thường",
                    TrangThai = "Sẵn sàng"
                };

                danhSachMay.Add(mayMoi);
                SaveData();
                RefreshDataGridView();
                UpdateComboBoxDanhSachMay();

                // Chọn máy mới thêm
                int rowIndex = dataGridView_thongTinMay.Rows.Count - 1;
                dataGridView_thongTinMay.ClearSelection();
                dataGridView_thongTinMay.Rows[rowIndex].Selected = true;
                dataGridView_thongTinMay.FirstDisplayedScrollingRowIndex = rowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm máy: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //============================ XÓA MÁY ============================//
        private void button_XoaMay_Click(object sender, EventArgs e)
        {
            if (dataGridView_thongTinMay.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa máy đã chọn?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var selectedRows = dataGridView_thongTinMay.SelectedRows.Cast<DataGridViewRow>();
                        var soMayToDelete = selectedRows.Select(r => r.Cells["SoMay"].Value.ToString()).ToList();

                        danhSachMay.RemoveAll(m => soMayToDelete.Contains(m.SoMay));
                        SaveData();
                        RefreshDataGridView();
                        UpdateComboBoxDanhSachMay();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa máy: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một máy để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //============================ SỬA MÁY ============================//
        private void button_suaMay_Click(object sender, EventArgs e)
        {
            if (dataGridView_thongTinMay.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = dataGridView_thongTinMay.SelectedRows[0];
                string soMay = selectedRow.Cells["SoMay"].Value.ToString();
                var may = danhSachMay.FirstOrDefault(m => m.SoMay == soMay);

                if (may != null)
                {
                    ShowEditForm(may);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một máy để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowEditForm(MayTinh may)
        {
            using (var form = new Form())
            {
                form.Text = "Chỉnh sửa thông tin máy";
                form.Size = new Size(300, 250);
                form.StartPosition = FormStartPosition.CenterParent;

                var lblSoMay = new Label { Text = "Số máy:", Left = 10, Top = 20, Width = 80 };
                var txtSoMay = new TextBox { Text = may.SoMay, Left = 100, Top = 20, Width = 150, ReadOnly = true };

                var lblLoaiMay = new Label { Text = "Loại máy:", Left = 10, Top = 60, Width = 80 };
                var cbLoaiMay = new ComboBox { Left = 100, Top = 60, Width = 150 };
                cbLoaiMay.Items.AddRange(new[] { "Máy vip", "Máy Thường", "Máy Đôi" });
                cbLoaiMay.SelectedItem = may.LoaiMay;

                var lblTrangThai = new Label { Text = "Trạng thái:", Left = 10, Top = 100, Width = 80 };
                var cbTrangThai = new ComboBox { Left = 100, Top = 100, Width = 150 };
                cbTrangThai.Items.AddRange(new[] { "Đang hoạt động", "Bảo trì", "Đã hỏng", "Sẵn sàng" });
                cbTrangThai.SelectedItem = may.TrangThai;

                var btnSave = new Button { Text = "Lưu", Left = 100, Top = 150, Width = 70 };
                var btnCancel = new Button { Text = "Hủy", Left = 180, Top = 150, Width = 70 };

                btnSave.Click += (s, e) =>
                {
                    may.LoaiMay = cbLoaiMay.SelectedItem.ToString();
                    may.TrangThai = cbTrangThai.SelectedItem.ToString();
                    SaveData();
                    RefreshDataGridView();
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                };

                btnCancel.Click += (s, e) =>
                {
                    form.DialogResult = DialogResult.Cancel;
                    form.Close();
                };

                form.Controls.AddRange(new Control[] { lblSoMay, txtSoMay, lblLoaiMay, cbLoaiMay, lblTrangThai, cbTrangThai, btnSave, btnCancel });

                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Cập nhật thông tin máy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //============================ COMBOBOX LOẠI MÁY ============================//
        private void comboBox_loaiMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedLoaiMay = comboBox_loaiMay.SelectedItem.ToString();
            if (selectedLoaiMay == "Tất cả" || string.IsNullOrEmpty(selectedLoaiMay))
            {
                // Hiển thị tất cả máy
                RefreshDataGridView();
            }
            else
            {
                // Lọc theo loại máy
                var filtered = danhSachMay.Where(m => m.LoaiMay == selectedLoaiMay).ToList();
                dataGridView_thongTinMay.Rows.Clear();
                AddDefaultColumns();
                foreach (var may in filtered)
                {
                    dataGridView_thongTinMay.Rows.Add(
                        danhSachMay.IndexOf(may) + 1,
                        may.SoMay,
                        may.LoaiMay,
                        may.TrangThai
                    );
                }
            }
        }

        //============================ SỰ KIỆN ============================//
        private void DataGridView_thongTinMay_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var row = dataGridView_thongTinMay.Rows[e.RowIndex];
                string soMay = row.Cells["SoMay"].Value.ToString();
                var may = danhSachMay.FirstOrDefault(m => m.SoMay == soMay);

                if (may != null)
                {
                    switch (dataGridView_thongTinMay.Columns[e.ColumnIndex].Name)
                    {
                        case "LoaiMay":
                            may.LoaiMay = row.Cells["LoaiMay"].Value.ToString();
                            break;
                        case "TrangThai":
                            may.TrangThai = row.Cells["TrangThai"].Value.ToString();
                            break;
                    }
                    SaveData();
                }
            }
        }

        private void ComboBox_DanhSachMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DanhSachMay.SelectedIndex != -1)
            {
                string selectedSoMay = comboBox_DanhSachMay.SelectedItem.ToString();
                var may = danhSachMay.FirstOrDefault(m => m.SoMay == selectedSoMay);

                if (may != null)
                {
                    // Cập nhật thông tin chi tiết máy
                    textBox_TongGio.Text = "0"; // TODO: Lấy từ dữ liệu thực tế
                    textBox_TienMay.Text = "0"; // TODO: Tính toán dựa trên thời gian và loại máy
                    textBox_TongCong.Text = "0"; // TODO: Tính tổng tiền
                }
            }
        }

        private void Button_ThanhToan_Click(object sender, EventArgs e)
        {
            if (comboBox_DanhSachMay.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn máy để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Implement payment logic
            MessageBox.Show("Chức năng thanh toán đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button_XuatHoaDon_Click(object sender, EventArgs e)
        {
            if (comboBox_DanhSachMay.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn máy để xuất hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Implement invoice generation
            MessageBox.Show("Chức năng xuất hóa đơn đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddDefaultColumns()
        {
            if (dataGridView_thongTinMay.Columns.Count == 0)
            {
                dataGridView_thongTinMay.Columns.Add("STT", "STT");
                dataGridView_thongTinMay.Columns.Add("SoMay", "Số Máy");
                dataGridView_thongTinMay.Columns.Add("LoaiMay", "Loại Máy");
                dataGridView_thongTinMay.Columns.Add("TrangThai", "Trạng Thái");
            }
        }

        private void textBox_TongGio_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_DanhSachMay.SelectedIndex != -1)
            {
                string selectedSoMay = comboBox_DanhSachMay.SelectedItem.ToString();
                var may = danhSachMay.FirstOrDefault(m => m.SoMay == selectedSoMay);

                if (may != null)
                {
                    int gia = GetGiaTheoLoaiMay(may.LoaiMay);
                    if (double.TryParse(textBox_TongGio.Text, out double tongGio))
                    {
                        int tongTien = (int)(gia * tongGio);
                        textBox_TongCong.Text = tongTien.ToString("N0");
                    }
                    else
                    {
                        textBox_TongCong.Text = "0";
                    }
                }
            }
        }

        private int GetGiaTheoLoaiMay(string loaiMay)
        {
            switch (loaiMay)
            {
                case "Máy vip": return 25000;
                case "Máy Đôi": return 20000;
                case "Máy Thường": return 10000;
                default: return 0;
            }
        }

        private void AddGoiDichVuColumns()
        {
            if (dataGridView_GoiDichVu.Columns.Count == 0)
            {
                dataGridView_GoiDichVu.Columns.Add("TenMon", "Tên món");
                dataGridView_GoiDichVu.Columns.Add("SoLuong", "Số lượng");
                dataGridView_GoiDichVu.Columns.Add("ThanhTien", "Thành tiền");
            }
            // Ensure columns auto-size to fit content, preventing text cutoff
            dataGridView_GoiDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // Thêm món vào dịch vụ gọi món (dataGridView_GoiDichVu)
        private void button_ThemMon_Click(object sender, EventArgs e)
        {
            using (var form = new QuanLyQuanNet.Admin.ChucNang.menu.frmEditBillDetail())
            {
                form.SetMenuList(menuList); // menuList là List<MenuItem> lấy từ menu tổng
                if (form.ShowDialog() == DialogResult.OK)
                {
                    dataGridView_GoiDichVu.Rows.Add(form.TenMon, form.SoLuong, form.ThanhTien);
                }
            }
        }

        // Sửa món trong dịch vụ gọi món
        private void button_SuaMon_Click(object sender, EventArgs e)
        {
            if (dataGridView_GoiDichVu.SelectedRows.Count == 1)
            {
                var row = dataGridView_GoiDichVu.SelectedRows[0];
                using (var form = new QuanLyQuanNet.Admin.ChucNang.menu.frmEditBillDetail())
                {
                    form.SetMenuList(menuList);
                    form.SetData(
                        row.Cells["TenMon"].Value?.ToString(),
                        Convert.ToInt32(row.Cells["SoLuong"].Value),
                        Convert.ToDecimal(row.Cells["ThanhTien"].Value)
                    );
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        row.Cells["TenMon"].Value = form.TenMon;
                        row.Cells["SoLuong"].Value = form.SoLuong;
                        row.Cells["ThanhTien"].Value = form.ThanhTien;
                    }
                }
            }
        }

        // Xóa món trong dịch vụ gọi món
        private void button_XoaMon_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView_GoiDichVu.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridView_GoiDichVu.Rows.Remove(row);
            }
        }

        private void button_ChinhSuaMonAn_Click(object sender, EventArgs e)
        {
            // Tạo DataTable từ dataGridView_GoiDichVu hiện tại
            DataTable currentDichVu = new DataTable();
            currentDichVu.Columns.Add("TenMon");
            currentDichVu.Columns.Add("SoLuong", typeof(int));
            currentDichVu.Columns.Add("ThanhTien", typeof(decimal));
            foreach (DataGridViewRow row in dataGridView_GoiDichVu.Rows)
            {
                if (!row.IsNewRow)
                    currentDichVu.Rows.Add(row.Cells["TenMon"].Value, row.Cells["SoLuong"].Value, row.Cells["ThanhTien"].Value);
            }

            // Tạo DataTable menu tổng từ menuList
            DataTable menu = new DataTable();
            menu.Columns.Add("Tên món");
            menu.Columns.Add("Giá (VND)");
            foreach (var item in menuList)
            {
                menu.Rows.Add(item.TenMon, item.Gia.ToString("N0") + " VND");
            }

            // Mở form chỉnh sửa dịch vụ
            using (var form = new frmChinhSuaDichVu(currentDichVu, menu))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật lại dataGridView_GoiDichVu theo bảng dịch vụ đã chỉnh sửa
                    dataGridView_GoiDichVu.Rows.Clear();
                    foreach (DataRow r in form.DichVuTable.Rows)
                    {
                        dataGridView_GoiDichVu.Rows.Add(r["TenMon"], r["SoLuong"], r["ThanhTien"]);
                    }
                }
            }
        }
    }

    public class MayTinh
    {
        public string SoMay { get; set; }
        public string LoaiMay { get; set; }
        public string TrangThai { get; set; }
    }
}