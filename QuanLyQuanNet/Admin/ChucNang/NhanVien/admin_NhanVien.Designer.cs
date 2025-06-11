namespace QuanLyQuanNet.Admin.NhanVien
{
    partial class admin_NhanVien
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
            textBox_TimKiem = new TextBox();
            button_Them = new Button();
            button_chamCong = new Button();
            button_Xóa = new Button();
            panel1 = new Panel();
            label10 = new Label();
            label_TaiKhoan = new Label();
            label_NgayVaoLam = new Label();
            label_NgaySinh = new Label();
            label_SDT = new Label();
            label_DiaChi = new Label();
            label4 = new Label();
            label_ChucVu = new Label();
            label_HoTen = new Label();
            label_ID = new Label();
            comboBox_LoaiNhanVien = new ComboBox();
            comboBox_ChucVu = new ComboBox();
            button_Sua = new Button();
            textBox_MatKhau = new TextBox();
            textBox_TaiKhoan = new TextBox();
            dateTimePicker_NgayVaoLam = new DateTimePicker();
            dateTimePicker_NgaySinh = new DateTimePicker();
            textBox_SDT = new TextBox();
            textBox_DiaChi = new TextBox();
            textBox_HoTen = new TextBox();
            textBoxID = new TextBox();
            dataGridView_NhanVien = new DataGridView();
            label_TimKiem = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_NhanVien).BeginInit();
            SuspendLayout();
            // 
            // textBox_TimKiem
            // 
            textBox_TimKiem.Location = new Point(3, 39);
            textBox_TimKiem.Name = "textBox_TimKiem";
            textBox_TimKiem.Size = new Size(121, 27);
            textBox_TimKiem.TabIndex = 0;
            textBox_TimKiem.TextChanged += textBox_TimKiem_TextChanged_1;
            // 
            // button_Them
            // 
            button_Them.Location = new Point(130, 37);
            button_Them.Name = "button_Them";
            button_Them.Size = new Size(94, 29);
            button_Them.TabIndex = 1;
            button_Them.Text = "Thêm";
            button_Them.UseVisualStyleBackColor = true;
            button_Them.Click += button_Them_Click;
            // 
            // button_chamCong
            // 
            button_chamCong.Location = new Point(241, 37);
            button_chamCong.Name = "button_chamCong";
            button_chamCong.Size = new Size(94, 29);
            button_chamCong.TabIndex = 2;
            button_chamCong.Text = "Chấm công";
            button_chamCong.UseVisualStyleBackColor = true;
            button_chamCong.Click += button_chamCong_Click;
            // 
            // button_Xóa
            // 
            button_Xóa.Location = new Point(341, 37);
            button_Xóa.Name = "button_Xóa";
            button_Xóa.Size = new Size(94, 29);
            button_Xóa.TabIndex = 3;
            button_Xóa.Text = "Xóa";
            button_Xóa.UseVisualStyleBackColor = true;
            button_Xóa.Click += button_Xoa_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label_TaiKhoan);
            panel1.Controls.Add(label_NgayVaoLam);
            panel1.Controls.Add(label_NgaySinh);
            panel1.Controls.Add(label_SDT);
            panel1.Controls.Add(label_DiaChi);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label_ChucVu);
            panel1.Controls.Add(label_HoTen);
            panel1.Controls.Add(label_ID);
            panel1.Controls.Add(comboBox_LoaiNhanVien);
            panel1.Controls.Add(comboBox_ChucVu);
            panel1.Controls.Add(button_Sua);
            panel1.Controls.Add(textBox_MatKhau);
            panel1.Controls.Add(textBox_TaiKhoan);
            panel1.Controls.Add(dateTimePicker_NgayVaoLam);
            panel1.Controls.Add(dateTimePicker_NgaySinh);
            panel1.Controls.Add(textBox_SDT);
            panel1.Controls.Add(textBox_DiaChi);
            panel1.Controls.Add(textBox_HoTen);
            panel1.Controls.Add(textBoxID);
            panel1.Location = new Point(447, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 533);
            panel1.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(136, 363);
            label10.Name = "label10";
            label10.Size = new Size(72, 20);
            label10.TabIndex = 19;
            label10.Text = "Mật Khẩu";
            // 
            // label_TaiKhoan
            // 
            label_TaiKhoan.AutoSize = true;
            label_TaiKhoan.Location = new Point(0, 363);
            label_TaiKhoan.Name = "label_TaiKhoan";
            label_TaiKhoan.Size = new Size(73, 20);
            label_TaiKhoan.TabIndex = 18;
            label_TaiKhoan.Text = "Tài Khoản";
            // 
            // label_NgayVaoLam
            // 
            label_NgayVaoLam.AutoSize = true;
            label_NgayVaoLam.Location = new Point(136, 260);
            label_NgayVaoLam.Name = "label_NgayVaoLam";
            label_NgayVaoLam.Size = new Size(101, 20);
            label_NgayVaoLam.TabIndex = 17;
            label_NgayVaoLam.Text = "Ngày vào làm";
            // 
            // label_NgaySinh
            // 
            label_NgaySinh.AutoSize = true;
            label_NgaySinh.Location = new Point(3, 260);
            label_NgaySinh.Name = "label_NgaySinh";
            label_NgaySinh.Size = new Size(74, 20);
            label_NgaySinh.TabIndex = 16;
            label_NgaySinh.Text = "Ngày sinh";
            // 
            // label_SDT
            // 
            label_SDT.AutoSize = true;
            label_SDT.Location = new Point(136, 185);
            label_SDT.Name = "label_SDT";
            label_SDT.Size = new Size(35, 20);
            label_SDT.TabIndex = 15;
            label_SDT.Text = "SDT";
            // 
            // label_DiaChi
            // 
            label_DiaChi.AutoSize = true;
            label_DiaChi.Location = new Point(0, 185);
            label_DiaChi.Name = "label_DiaChi";
            label_DiaChi.Size = new Size(55, 20);
            label_DiaChi.TabIndex = 14;
            label_DiaChi.Text = "Địa chỉ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(128, 106);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 13;
            label4.Text = "Loại Nhân Viên";
            // 
            // label_ChucVu
            // 
            label_ChucVu.AutoSize = true;
            label_ChucVu.Location = new Point(0, 106);
            label_ChucVu.Name = "label_ChucVu";
            label_ChucVu.Size = new Size(63, 20);
            label_ChucVu.TabIndex = 12;
            label_ChucVu.Text = "Chức Vụ";
            // 
            // label_HoTen
            // 
            label_HoTen.AutoSize = true;
            label_HoTen.Location = new Point(110, 28);
            label_HoTen.Name = "label_HoTen";
            label_HoTen.Size = new Size(54, 20);
            label_HoTen.TabIndex = 11;
            label_HoTen.Text = "Họ tên";
            // 
            // label_ID
            // 
            label_ID.AutoSize = true;
            label_ID.Location = new Point(3, 28);
            label_ID.Name = "label_ID";
            label_ID.Size = new Size(24, 20);
            label_ID.TabIndex = 10;
            label_ID.Text = "ID";
            // 
            // comboBox_LoaiNhanVien
            // 
            comboBox_LoaiNhanVien.FormattingEnabled = true;
            comboBox_LoaiNhanVien.Location = new Point(128, 129);
            comboBox_LoaiNhanVien.Name = "comboBox_LoaiNhanVien";
            comboBox_LoaiNhanVien.Size = new Size(124, 28);
            comboBox_LoaiNhanVien.TabIndex = 9;
            comboBox_LoaiNhanVien.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox_ChucVu
            // 
            comboBox_ChucVu.FormattingEnabled = true;
            comboBox_ChucVu.Location = new Point(0, 129);
            comboBox_ChucVu.Name = "comboBox_ChucVu";
            comboBox_ChucVu.Size = new Size(108, 28);
            comboBox_ChucVu.TabIndex = 9;
            comboBox_ChucVu.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button_Sua
            // 
            button_Sua.Location = new Point(10, 478);
            button_Sua.Name = "button_Sua";
            button_Sua.Size = new Size(235, 29);
            button_Sua.TabIndex = 8;
            button_Sua.Text = "Sửa";
            button_Sua.UseVisualStyleBackColor = true;
            button_Sua.Click += button_Sua_Click;
            // 
            // textBox_MatKhau
            // 
            textBox_MatKhau.Location = new Point(128, 395);
            textBox_MatKhau.Name = "textBox_MatKhau";
            textBox_MatKhau.Size = new Size(124, 27);
            textBox_MatKhau.TabIndex = 7;
            // 
            // textBox_TaiKhoan
            // 
            textBox_TaiKhoan.Location = new Point(0, 395);
            textBox_TaiKhoan.Name = "textBox_TaiKhoan";
            textBox_TaiKhoan.Size = new Size(121, 27);
            textBox_TaiKhoan.TabIndex = 6;
            // 
            // dateTimePicker_NgayVaoLam
            // 
            dateTimePicker_NgayVaoLam.Location = new Point(128, 290);
            dateTimePicker_NgayVaoLam.Name = "dateTimePicker_NgayVaoLam";
            dateTimePicker_NgayVaoLam.Size = new Size(124, 27);
            dateTimePicker_NgayVaoLam.TabIndex = 5;
            // 
            // dateTimePicker_NgaySinh
            // 
            dateTimePicker_NgaySinh.Location = new Point(0, 290);
            dateTimePicker_NgaySinh.Name = "dateTimePicker_NgaySinh";
            dateTimePicker_NgaySinh.Size = new Size(108, 27);
            dateTimePicker_NgaySinh.TabIndex = 4;
            // 
            // textBox_SDT
            // 
            textBox_SDT.Location = new Point(128, 208);
            textBox_SDT.Name = "textBox_SDT";
            textBox_SDT.Size = new Size(124, 27);
            textBox_SDT.TabIndex = 3;
            // 
            // textBox_DiaChi
            // 
            textBox_DiaChi.Location = new Point(3, 208);
            textBox_DiaChi.Name = "textBox_DiaChi";
            textBox_DiaChi.Size = new Size(108, 27);
            textBox_DiaChi.TabIndex = 3;
            // 
            // textBox_HoTen
            // 
            textBox_HoTen.Location = new Point(110, 51);
            textBox_HoTen.Name = "textBox_HoTen";
            textBox_HoTen.Size = new Size(142, 27);
            textBox_HoTen.TabIndex = 1;
            // 
            // textBoxID
            // 
            textBoxID.Location = new Point(3, 51);
            textBoxID.Name = "textBoxID";
            textBoxID.Size = new Size(86, 27);
            textBoxID.TabIndex = 0;
            // 
            // dataGridView_NhanVien
            // 
            dataGridView_NhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_NhanVien.Location = new Point(0, 72);
            dataGridView_NhanVien.Name = "dataGridView_NhanVien";
            dataGridView_NhanVien.RowHeadersWidth = 51;
            dataGridView_NhanVien.Size = new Size(441, 500);
            dataGridView_NhanVien.TabIndex = 5;
            dataGridView_NhanVien.SelectionChanged += dataGridView_NhanVien_SelectionChanged;
            // 
            // label_TimKiem
            // 
            label_TimKiem.AutoSize = true;
            label_TimKiem.Location = new Point(3, 16);
            label_TimKiem.Name = "label_TimKiem";
            label_TimKiem.Size = new Size(72, 20);
            label_TimKiem.TabIndex = 6;
            label_TimKiem.Text = "Tìm Kiếm";
            // 
            // admin_NhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label_TimKiem);
            Controls.Add(dataGridView_NhanVien);
            Controls.Add(panel1);
            Controls.Add(button_Xóa);
            Controls.Add(button_chamCong);
            Controls.Add(button_Them);
            Controls.Add(textBox_TimKiem);
            Name = "admin_NhanVien";
            Size = new Size(715, 575);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_NhanVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_TimKiem;
        private Button button_Them;
        private Button button_chamCong;
        private Button button_Xóa;
        private Panel panel1;
        private TextBox textBox_SDT;
        private TextBox textBox_DiaChi;
        private TextBox textBox_HoTen;
        private TextBox textBoxID;
        private DataGridView dataGridView_NhanVien;
        private ComboBox comboBox_ChucVu;
        private Button button_Sua;
        private TextBox textBox_MatKhau;
        private TextBox textBox_TaiKhoan;
        private DateTimePicker dateTimePicker_NgayVaoLam;
        private DateTimePicker dateTimePicker_NgaySinh;
        private ComboBox comboBox_LoaiNhanVien;
        private Label label10;
        private Label label_TaiKhoan;
        private Label label_NgayVaoLam;
        private Label label_NgaySinh;
        private Label label_SDT;
        private Label label_DiaChi;
        private Label label4;
        private Label label_ChucVu;
        private Label label_HoTen;
        private Label label_ID;
        private Label label_TimKiem;
    }
}
