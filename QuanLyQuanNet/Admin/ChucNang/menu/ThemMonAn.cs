using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyQuanNet.Admin.ChucNang.menu
{
    public partial class ThemMonAn : Form
    {
        // === PUBLIC PROPERTIES ===
        public string MaMon => txtMaMon.Text.Trim();
        public string TenMon => txtTenMon.Text.Trim();

        public decimal GiaMon
        {
            get
            {
                return decimal.TryParse(txtGia.Text, out var gia) ? gia : 0;
            }
        }
        // Add these to your ThemMonAn form class
        public void SetEditValues(string maMon, string tenMon, string gia)
        {
            // Disable the ID field since we shouldn't change it
            txtMaMon.Enabled = false;

            // Set the values
            txtMaMon.Text = maMon;
            txtTenMon.Text = tenMon;
            txtGia.Text = gia;
        }

        public void SetImage(byte[] imageBytes)
        {
            if (imageBytes != null && imageBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    picHinhAnh.Image = Image.FromStream(ms);
                }
            }
        }
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

        private string selectedImagePath = "";

        public ThemMonAn()
        {
            InitializeComponent();

            btnChonAnh.Click += btnChonAnh_Click;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Ảnh (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png|Tất cả tập tin|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = dialog.FileName;
                picHinhAnh.Image = Image.FromFile(selectedImagePath);
                picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Simple validation
            if (string.IsNullOrWhiteSpace(MaMon) ||
                string.IsNullOrWhiteSpace(TenMon) ||
                GiaMon <= 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ và đúng thông tin món ăn!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu cần kiểm tra ảnh bắt buộc:
            // if (AnhMon == null)
            // {
            //     MessageBox.Show("Bạn chưa chọn ảnh món ăn!", "Thiếu ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     return;
            // }

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
