using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.ChucNang.menu
{
    public class MenuItem
    {
        public string TenMon { get; set; }
        public decimal Gia { get; set; }

        public override string ToString() => TenMon;
    }

    public partial class frmEditBillDetail : Form
    {
        public string TenMon { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        private List<MenuItem> MenuList = new List<MenuItem>();

        public frmEditBillDetail()
        {
            InitializeComponent();
            cbTenMon.SelectedIndexChanged += cbTenMon_SelectedIndexChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            LoadMenuFromDatabase();
        }

        private void LoadMenuFromDatabase()
        {
            try
            {
                string query = "SELECT TenMon, Gia FROM Menu";
                DataTable dt = DataProvider.Instance.ExecuteQuery(query);

                MenuList = dt.AsEnumerable().Select(row => new MenuItem
                {
                    TenMon = row["TenMon"].ToString(),
                    Gia = Convert.ToDecimal(row["Gia"])
                }).ToList();

                cbTenMon.DataSource = MenuList;
                cbTenMon.DisplayMember = "TenMon";
                cbTenMon.ValueMember = "Gia";

                if (MenuList.Count > 0)
                {
                    cbTenMon.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetData(string? tenMon, int soLuong, decimal thanhTien)
        {
            cbTenMon.SelectedItem = MenuList.FirstOrDefault(m => m.TenMon == tenMon);
            txtSoLuong.Text = soLuong.ToString();
            txtThanhTien.Text = thanhTien.ToString("N0");
        }


        private void cbTenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenMon.SelectedItem is MenuItem item)
            {
                DonGia = item.Gia;
                TinhThanhTien();
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void TinhThanhTien()
        {
            if (int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                ThanhTien = DonGia * soLuong;
                txtThanhTien.Text = ThanhTien.ToString("N0");
            }
            else
            {
                txtThanhTien.Text = "0";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbTenMon.SelectedItem is MenuItem item && int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                TenMon = item.TenMon;
                SoLuong = soLuong;
                ThanhTien = DonGia * soLuong;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thông tin chưa hợp lệ! 😅", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public void SetMenuList(List<MenuItem> menu)
        {
            MenuList = menu;
            cbTenMon.DataSource = MenuList;
            cbTenMon.DisplayMember = "TenMon";
            cbTenMon.ValueMember = "Gia";
        }

    }
}
