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

namespace QuanLyQuanNet.Admin.ChucNang.menu
{
    public partial class ThemMonAn : Form
    {
        // Public properties to expose data
        public string MaMon { get { return txtMaMon.Text; } }
        public string TenMon { get { return txtTenMon.Text; } }
        public decimal GiaMon // Assuming price is a decimal
        {
            get
            {
                decimal price;
                if (decimal.TryParse(txtGia.Text, out price))
                {
                    return price;
                }
                return 0;
            }
        }
        // Property to get image data from PictureBox
        public byte[] AnhMon
        {
            get
            {
                if (picHinhAnh.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picHinhAnh.Image.Save(ms, picHinhAnh.Image.RawFormat);
                        return ms.ToArray();
                    }
                }
                return null;
            }
        }

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
            // After selecting image, you would set the AnhMon property
            // Example: AnhMon = File.ReadAllBytes(selectedImagePath);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // TODO: Implement save logic (if needed before closing)
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
