namespace QuanLyQuanNet.Admin.ChucNang.Tinh_trang_may
{
    partial class uc_tinhTrangMay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            button_suaMay = new Button();
            comboBox_loaiMay = new ComboBox();
            comboBox_DanhSachMay = new ComboBox();
            button_XoaMay = new Button();
            button_themMay = new Button();
            label_loaiMay = new Label();
            dataGridView_thongTinMay = new DataGridView();
            panel2 = new Panel();
            button_ChinhSuaMonAn = new Button();
            comboBox_PhuongThucThanhToan = new ComboBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox_TongCong = new TextBox();
            textBox_TienMay = new TextBox();
            textBox_TongGio = new TextBox();
            dataGridView_GoiDichVu = new DataGridView();
            comboBox_ThongTinKhachHang = new ComboBox();
            label_ThanhTien = new Label();
            button_ThanhToan = new Button();
            label_KhuyenMai = new Label();
            button_XuatHoaDon = new Button();
            label_ThanhVien = new Label();
            label_MaySo = new Label();
            label_TongCong = new Label();
            label_TienMay = new Label();
            label_TongGio = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_thongTinMay).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_GoiDichVu).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button_suaMay);
            panel1.Controls.Add(comboBox_loaiMay);
            panel1.Controls.Add(comboBox_DanhSachMay);
            panel1.Controls.Add(button_XoaMay);
            panel1.Controls.Add(button_themMay);
            panel1.Controls.Add(label_loaiMay);
            panel1.Controls.Add(dataGridView_thongTinMay);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(439, 575);
            panel1.TabIndex = 0;
            // 
            // button_suaMay
            // 
            button_suaMay.Location = new Point(265, 67);
            button_suaMay.Name = "button_suaMay";
            button_suaMay.Size = new Size(94, 29);
            button_suaMay.TabIndex = 6;
            button_suaMay.Text = "Sửa máy";
            button_suaMay.UseVisualStyleBackColor = true;
            button_suaMay.Click += button_suaMay_Click;
            // 
            // comboBox_loaiMay
            // 
            comboBox_loaiMay.FormattingEnabled = true;
            comboBox_loaiMay.Location = new Point(3, 22);
            comboBox_loaiMay.Name = "comboBox_loaiMay";
            comboBox_loaiMay.Size = new Size(151, 28);
            comboBox_loaiMay.TabIndex = 5;
            comboBox_loaiMay.SelectedIndexChanged += comboBox_loaiMay_SelectedIndexChanged;
            // 
            // comboBox_DanhSachMay
            // 
            comboBox_DanhSachMay.FormattingEnabled = true;
            comboBox_DanhSachMay.Location = new Point(221, 22);
            comboBox_DanhSachMay.Name = "comboBox_DanhSachMay";
            comboBox_DanhSachMay.Size = new Size(161, 28);
            comboBox_DanhSachMay.TabIndex = 4;
            // 
            // button_XoaMay
            // 
            button_XoaMay.Location = new Point(137, 67);
            button_XoaMay.Name = "button_XoaMay";
            button_XoaMay.Size = new Size(112, 32);
            button_XoaMay.TabIndex = 2;
            button_XoaMay.Text = "Xóa máy";
            button_XoaMay.UseVisualStyleBackColor = true;
            button_XoaMay.Click += button_XoaMay_Click;
            // 
            // button_themMay
            // 
            button_themMay.Location = new Point(17, 67);
            button_themMay.Name = "button_themMay";
            button_themMay.Size = new Size(114, 32);
            button_themMay.TabIndex = 2;
            button_themMay.Text = "Thêm máy";
            button_themMay.UseVisualStyleBackColor = true;
            button_themMay.Click += button_themMay_Click;
            // 
            // label_loaiMay
            // 
            label_loaiMay.AutoSize = true;
            label_loaiMay.Location = new Point(3, 0);
            label_loaiMay.Name = "label_loaiMay";
            label_loaiMay.Size = new Size(69, 20);
            label_loaiMay.TabIndex = 0;
            label_loaiMay.Text = "Loại máy";
            // 
            // dataGridView_thongTinMay
            // 
            dataGridView_thongTinMay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_thongTinMay.Location = new Point(0, 112);
            dataGridView_thongTinMay.Name = "dataGridView_thongTinMay";
            dataGridView_thongTinMay.RowHeadersWidth = 51;
            dataGridView_thongTinMay.Size = new Size(436, 463);
            dataGridView_thongTinMay.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(button_ChinhSuaMonAn);
            panel2.Controls.Add(comboBox_PhuongThucThanhToan);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox_TongCong);
            panel2.Controls.Add(textBox_TienMay);
            panel2.Controls.Add(textBox_TongGio);
            panel2.Controls.Add(dataGridView_GoiDichVu);
            panel2.Controls.Add(comboBox_ThongTinKhachHang);
            panel2.Controls.Add(label_ThanhTien);
            panel2.Controls.Add(button_ThanhToan);
            panel2.Controls.Add(label_KhuyenMai);
            panel2.Controls.Add(button_XuatHoaDon);
            panel2.Controls.Add(label_ThanhVien);
            panel2.Controls.Add(label_MaySo);
            panel2.Controls.Add(label_TongCong);
            panel2.Controls.Add(label_TienMay);
            panel2.Controls.Add(label_TongGio);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(437, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(278, 575);
            panel2.TabIndex = 1;
            // 
            // button_ChinhSuaMonAn
            // 
            button_ChinhSuaMonAn.Location = new Point(24, 232);
            button_ChinhSuaMonAn.Name = "button_ChinhSuaMonAn";
            button_ChinhSuaMonAn.Size = new Size(227, 33);
            button_ChinhSuaMonAn.TabIndex = 7;
            button_ChinhSuaMonAn.Text = "Chỉnh sửa dịch vụ";
            button_ChinhSuaMonAn.UseVisualStyleBackColor = true;
            button_ChinhSuaMonAn.Click += button_ChinhSuaMonAn_Click;
            // 
            // comboBox_PhuongThucThanhToan
            // 
            comboBox_PhuongThucThanhToan.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox_PhuongThucThanhToan.ForeColor = Color.Silver;
            comboBox_PhuongThucThanhToan.FormattingEnabled = true;
            comboBox_PhuongThucThanhToan.Location = new Point(0, 496);
            comboBox_PhuongThucThanhToan.Name = "comboBox_PhuongThucThanhToan";
            comboBox_PhuongThucThanhToan.Size = new Size(272, 25);
            comboBox_PhuongThucThanhToan.TabIndex = 6;
            comboBox_PhuongThucThanhToan.Text = "Phương thức Thanh Toán";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(134, 423);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(144, 27);
            textBox6.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(134, 379);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(144, 27);
            textBox5.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(134, 337);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(144, 27);
            textBox4.TabIndex = 5;
            // 
            // textBox_TongCong
            // 
            textBox_TongCong.Location = new Point(134, 272);
            textBox_TongCong.Name = "textBox_TongCong";
            textBox_TongCong.Size = new Size(133, 27);
            textBox_TongCong.TabIndex = 5;
            // 
            // textBox_TienMay
            // 
            textBox_TienMay.Location = new Point(167, 70);
            textBox_TienMay.Name = "textBox_TienMay";
            textBox_TienMay.Size = new Size(100, 27);
            textBox_TienMay.TabIndex = 5;
            // 
            // textBox_TongGio
            // 
            textBox_TongGio.Location = new Point(172, 27);
            textBox_TongGio.Name = "textBox_TongGio";
            textBox_TongGio.Size = new Size(100, 27);
            textBox_TongGio.TabIndex = 5;
            textBox_TongGio.TextChanged += textBox_TongGio_TextChanged;
            // 
            // dataGridView_GoiDichVu
            // 
            dataGridView_GoiDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_GoiDichVu.Location = new Point(0, 103);
            dataGridView_GoiDichVu.Name = "dataGridView_GoiDichVu";
            dataGridView_GoiDichVu.RowHeadersWidth = 51;
            dataGridView_GoiDichVu.Size = new Size(278, 123);
            dataGridView_GoiDichVu.TabIndex = 4;
            // 
            // comboBox_ThongTinKhachHang
            // 
            comboBox_ThongTinKhachHang.ForeColor = Color.Silver;
            comboBox_ThongTinKhachHang.FormattingEnabled = true;
            comboBox_ThongTinKhachHang.Location = new Point(0, 301);
            comboBox_ThongTinKhachHang.Name = "comboBox_ThongTinKhachHang";
            comboBox_ThongTinKhachHang.Size = new Size(278, 28);
            comboBox_ThongTinKhachHang.TabIndex = 3;
            comboBox_ThongTinKhachHang.Text = "Thông tin khách hàng";
            // 
            // label_ThanhTien
            // 
            label_ThanhTien.AutoSize = true;
            label_ThanhTien.Location = new Point(24, 430);
            label_ThanhTien.Name = "label_ThanhTien";
            label_ThanhTien.Size = new Size(81, 20);
            label_ThanhTien.TabIndex = 0;
            label_ThanhTien.Text = "Thành tiền:";
            // 
            // button_ThanhToan
            // 
            button_ThanhToan.Location = new Point(154, 527);
            button_ThanhToan.Name = "button_ThanhToan";
            button_ThanhToan.Size = new Size(121, 32);
            button_ThanhToan.TabIndex = 2;
            button_ThanhToan.Text = "Thanh Toán";
            button_ThanhToan.UseVisualStyleBackColor = true;
            // 
            // label_KhuyenMai
            // 
            label_KhuyenMai.AutoSize = true;
            label_KhuyenMai.Location = new Point(24, 386);
            label_KhuyenMai.Name = "label_KhuyenMai";
            label_KhuyenMai.Size = new Size(89, 20);
            label_KhuyenMai.TabIndex = 0;
            label_KhuyenMai.Text = "Khuyến mãi:";
            // 
            // button_XuatHoaDon
            // 
            button_XuatHoaDon.Location = new Point(8, 527);
            button_XuatHoaDon.Name = "button_XuatHoaDon";
            button_XuatHoaDon.Size = new Size(121, 32);
            button_XuatHoaDon.TabIndex = 2;
            button_XuatHoaDon.Text = "Xuất Hóa Đơn";
            button_XuatHoaDon.UseVisualStyleBackColor = true;
            // 
            // label_ThanhVien
            // 
            label_ThanhVien.AutoSize = true;
            label_ThanhVien.Location = new Point(24, 344);
            label_ThanhVien.Name = "label_ThanhVien";
            label_ThanhVien.Size = new Size(83, 20);
            label_ThanhVien.TabIndex = 0;
            label_ThanhVien.Text = "Thành viên:";
            // 
            // label_MaySo
            // 
            label_MaySo.AutoSize = true;
            label_MaySo.Location = new Point(24, 45);
            label_MaySo.Name = "label_MaySo";
            label_MaySo.Size = new Size(37, 20);
            label_MaySo.TabIndex = 0;
            label_MaySo.Text = "Máy";
            // 
            // label_TongCong
            // 
            label_TongCong.AutoSize = true;
            label_TongCong.Location = new Point(23, 272);
            label_TongCong.Name = "label_TongCong";
            label_TongCong.Size = new Size(82, 20);
            label_TongCong.TabIndex = 0;
            label_TongCong.Text = "Tổng Cộng";
            // 
            // label_TienMay
            // 
            label_TienMay.AutoSize = true;
            label_TienMay.Location = new Point(92, 77);
            label_TienMay.Name = "label_TienMay";
            label_TienMay.Size = new Size(69, 20);
            label_TienMay.TabIndex = 0;
            label_TienMay.Text = "Tiền máy";
            // 
            // label_TongGio
            // 
            label_TongGio.AutoSize = true;
            label_TongGio.Location = new Point(92, 30);
            label_TongGio.Name = "label_TongGio";
            label_TongGio.Size = new Size(69, 20);
            label_TongGio.TabIndex = 0;
            label_TongGio.Text = "Tổng giờ";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // uc_tinhTrangMay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "uc_tinhTrangMay";
            Size = new Size(715, 575);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_thongTinMay).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_GoiDichVu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label3;
        private Label label2;
        private Label label_loaiMay;
        private Panel panel2;
        private Label label_TienMay;
        private Label label_TongGio;
        private Button button_XoaMay;
        private Button button_themMay;
        private Button button_ThanhToan;
        private Button button_XuatHoaDon;
        private Label label_MaySo;
        private Label label_TongCong;
        private TextBox textBox_TongGio;
        private ComboBox comboBox2;
        private ComboBox comboBox_loaiMay;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox_TienMay;
        private ComboBox comboBox3;
        private Label label10;
        private Label label9;
        private Label label8;
        private ContextMenuStrip contextMenuStrip1;
        private Button button_suaMay;
        private DataGridView dataGridView_thongTinMay;
        private DataGridView dataGridView_GoiDichVu;
        private TextBox textBox_TongCong;
        private ComboBox comboBox_ThongTinKhachHang;
        private Label label_ThanhTien;
        private Label label_KhuyenMai;
        private Label label_ThanhVien;
        private ComboBox comboBox_PhuongThucThanhToan;
        private Button button_ChinhSuaMonAn;
        private ComboBox comboBox_DanhSachMay;
    }
}
