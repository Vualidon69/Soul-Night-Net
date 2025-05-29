using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.ChucNang.menu
{
    public partial class ThemMonAn : Form
    {
        public ThemMonAn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            // TODO: Implement image selection logic
            MessageBox.Show("Chọn ảnh button clicked!");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // TODO: Implement save logic
            MessageBox.Show("Lưu button clicked!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Implement cancel logic
            MessageBox.Show("Hủy button clicked!");
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
