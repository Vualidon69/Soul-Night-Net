using System;
using System.Collections.Generic;
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
        public List<MenuItem> MenuList { get; set; }
        public string TenMon { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
        public decimal DonGia { get; set; }

        public frmEditBillDetail()
        {
            InitializeComponent();
            cbTenMon.SelectedIndexChanged += cbTenMon_SelectedIndexChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
        }

        public void SetMenuList(List<MenuItem> menu)
        {
            MenuList = menu;
            cbTenMon.DataSource = MenuList;
            cbTenMon.DisplayMember = "TenMon";
            cbTenMon.ValueMember = "Gia";
        }

        public void SetData(string tenMon, int soLuong, decimal thanhTien)
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
            int.TryParse(txtSoLuong.Text, out int soLuong);
            ThanhTien = DonGia * soLuong;
            txtThanhTien.Text = ThanhTien.ToString("N0");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TenMon = (cbTenMon.SelectedItem as MenuItem)?.TenMon;
            int.TryParse(txtSoLuong.Text, out int soLuong);
            SoLuong = soLuong;
            ThanhTien = DonGia * SoLuong;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
