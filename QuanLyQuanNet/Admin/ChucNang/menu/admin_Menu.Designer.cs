namespace QuanLyQuanNet.Admin.ChucNang
{
    partial class admin_Menu
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
            txtSearch = new TextBox();
            btn_themMon = new Button();
            btn_xoaMon = new Button();
            dgvMenu = new DataGridView();
            lb_tenMon = new Label();
            txt_tenMon = new TextBox();
            txt_Gia = new TextBox();
            lb_Gia = new Label();
            lb_maMon = new Label();
            txt_maMon = new TextBox();
            btnEdit_Click = new Button();
            panel1 = new Panel();
            lb_timKiemMonAn = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel_ChinhSua = new RoundedPanel();
            label3 = new Label();
            label_Gia = new Label();
            label_MaMon = new Label();
            textBox_MaMon = new TextBox();
            textBox_TenMon = new TextBox();
            textBox_Gia = new TextBox();
            button_chinhsua = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            panel1.SuspendLayout();
            panel_ChinhSua.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(13, 14);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(180, 34);
            txtSearch.TabIndex = 0;
            txtSearch.Enter += txtSearch_Enter;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // btn_themMon
            // 
            btn_themMon.Location = new Point(212, 19);
            btn_themMon.Name = "btn_themMon";
            btn_themMon.Size = new Size(94, 29);
            btn_themMon.TabIndex = 1;
            btn_themMon.Text = "Thêm món";
            btn_themMon.UseVisualStyleBackColor = true;
            btn_themMon.Click += btn_themMon_Click;
            // 
            // btn_xoaMon
            // 
            btn_xoaMon.Location = new Point(324, 19);
            btn_xoaMon.Name = "btn_xoaMon";
            btn_xoaMon.Size = new Size(100, 29);
            btn_xoaMon.TabIndex = 2;
            btn_xoaMon.Text = "Xoá Món";
            btn_xoaMon.UseVisualStyleBackColor = true;
            btn_xoaMon.Click += btn_xoaMon_Click_1;
            // 
            // dgvMenu
            // 
            dgvMenu.AllowUserToResizeRows = false;
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Dock = DockStyle.Fill;
            dgvMenu.Location = new Point(0, 0);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.ReadOnly = true;
            dgvMenu.RowHeadersVisible = false;
            dgvMenu.RowHeadersWidth = 51;
            dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMenu.Size = new Size(414, 474);
            dgvMenu.TabIndex = 4;
            dgvMenu.CellClick += dgvMenu_CellClick;
            dgvMenu.CellContentClick += dgvMenu_CellContentClick;
            dgvMenu.CellFormatting += dgvMenu_CellFormatting;
            // 
            // lb_tenMon
            // 
            lb_tenMon.AutoSize = true;
            lb_tenMon.Location = new Point(12, 127);
            lb_tenMon.Name = "lb_tenMon";
            lb_tenMon.Size = new Size(66, 20);
            lb_tenMon.TabIndex = 7;
            lb_tenMon.Text = "Tên món";
            // 
            // txt_tenMon
            // 
            txt_tenMon.Location = new Point(12, 162);
            txt_tenMon.Name = "txt_tenMon";
            txt_tenMon.Size = new Size(217, 27);
            txt_tenMon.TabIndex = 5;
            // 
            // txt_Gia
            // 
            txt_Gia.Location = new Point(127, 63);
            txt_Gia.Name = "txt_Gia";
            txt_Gia.Size = new Size(116, 27);
            txt_Gia.TabIndex = 4;
            // 
            // lb_Gia
            // 
            lb_Gia.AutoSize = true;
            lb_Gia.Location = new Point(127, 26);
            lb_Gia.Name = "lb_Gia";
            lb_Gia.Size = new Size(72, 20);
            lb_Gia.TabIndex = 3;
            lb_Gia.Text = "Giá(VND)";
            // 
            // lb_maMon
            // 
            lb_maMon.AutoSize = true;
            lb_maMon.Location = new Point(12, 26);
            lb_maMon.Name = "lb_maMon";
            lb_maMon.Size = new Size(64, 20);
            lb_maMon.TabIndex = 2;
            lb_maMon.Text = "Mã món";
            // 
            // txt_maMon
            // 
            txt_maMon.Location = new Point(12, 63);
            txt_maMon.Name = "txt_maMon";
            txt_maMon.Size = new Size(109, 27);
            txt_maMon.TabIndex = 1;
            // 
            // btnEdit_Click
            // 
            btnEdit_Click.Location = new Point(28, 210);
            btnEdit_Click.Name = "btnEdit_Click";
            btnEdit_Click.Size = new Size(191, 29);
            btnEdit_Click.TabIndex = 0;
            btnEdit_Click.Text = "Sửa chi tiết menu";
            btnEdit_Click.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvMenu);
            panel1.Location = new Point(11, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(414, 474);
            panel1.TabIndex = 7;
            // 
            // lb_timKiemMonAn
            // 
            lb_timKiemMonAn.AutoSize = true;
            lb_timKiemMonAn.BackColor = Color.White;
            lb_timKiemMonAn.Location = new Point(13, 23);
            lb_timKiemMonAn.Name = "lb_timKiemMonAn";
            lb_timKiemMonAn.Size = new Size(124, 20);
            lb_timKiemMonAn.TabIndex = 8;
            lb_timKiemMonAn.Text = "Tìm kiếm món ăn";
            // 
            // panel_ChinhSua
            // 
            panel_ChinhSua.BorderColor = Color.Black;
            panel_ChinhSua.BorderRadius = 20;
            panel_ChinhSua.BorderThickness = 2;
            panel_ChinhSua.Controls.Add(label3);
            panel_ChinhSua.Controls.Add(label_Gia);
            panel_ChinhSua.Controls.Add(label_MaMon);
            panel_ChinhSua.Controls.Add(textBox_MaMon);
            panel_ChinhSua.Controls.Add(textBox_TenMon);
            panel_ChinhSua.Controls.Add(textBox_Gia);
            panel_ChinhSua.Controls.Add(button_chinhsua);
            panel_ChinhSua.Location = new Point(431, 80);
            panel_ChinhSua.Name = "panel_ChinhSua";
            panel_ChinhSua.Size = new Size(281, 474);
            panel_ChinhSua.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 234);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 6;
            label3.Text = "Tên món";
            // 
            // label_Gia
            // 
            label_Gia.AutoSize = true;
            label_Gia.Location = new Point(3, 174);
            label_Gia.Name = "label_Gia";
            label_Gia.Size = new Size(72, 20);
            label_Gia.TabIndex = 5;
            label_Gia.Text = "Giá(VND)";
            // 
            // label_MaMon
            // 
            label_MaMon.AutoSize = true;
            label_MaMon.Location = new Point(3, 108);
            label_MaMon.Name = "label_MaMon";
            label_MaMon.Size = new Size(64, 20);
            label_MaMon.TabIndex = 4;
            label_MaMon.Text = "Mã món";
            // 
            // textBox_MaMon
            // 
            textBox_MaMon.Location = new Point(93, 101);
            textBox_MaMon.Name = "textBox_MaMon";
            textBox_MaMon.Size = new Size(185, 27);
            textBox_MaMon.TabIndex = 3;
            // 
            // textBox_TenMon
            // 
            textBox_TenMon.Location = new Point(93, 227);
            textBox_TenMon.Name = "textBox_TenMon";
            textBox_TenMon.Size = new Size(185, 27);
            textBox_TenMon.TabIndex = 2;
            // 
            // textBox_Gia
            // 
            textBox_Gia.Location = new Point(93, 167);
            textBox_Gia.Name = "textBox_Gia";
            textBox_Gia.Size = new Size(185, 27);
            textBox_Gia.TabIndex = 1;
            // 
            // button_chinhsua
            // 
            button_chinhsua.Location = new Point(3, 304);
            button_chinhsua.Name = "button_chinhsua";
            button_chinhsua.Size = new Size(278, 35);
            button_chinhsua.TabIndex = 0;
            button_chinhsua.Text = "Chỉnh sửa Menu";
            button_chinhsua.UseVisualStyleBackColor = true;
            button_chinhsua.Click += button_chinhsua_Click;
            // 
            // admin_Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_ChinhSua);
            Controls.Add(lb_timKiemMonAn);
            Controls.Add(panel1);
            Controls.Add(btn_xoaMon);
            Controls.Add(btn_themMon);
            Controls.Add(txtSearch);
            Name = "admin_Menu";
            Size = new Size(715, 575);
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            panel1.ResumeLayout(false);
            panel_ChinhSua.ResumeLayout(false);
            panel_ChinhSua.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btn_themMon;
        private Button btn_xoaMon;
        private DataGridView dgvMenu;
        private RoundedPanel pnl_chiTietMonAn;
        private Label lb_tenMon;
        private TextBox txt_tenMon;
        private TextBox txt_Gia;
        private Label lb_Gia;
        private Label lb_maMon;
        private TextBox txt_maMon;
        private Button btnEdit_Click;
        private Panel panel1;
        private Label lb_timKiemMonAn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RoundedPanel panel_ChinhSua;
        private Button button_chinhsua;
        private Label label3;
        private Label label_Gia;
        private Label label_MaMon;
        private TextBox textBox_MaMon;
        private TextBox textBox_TenMon;
        private TextBox textBox_Gia;
    }
}
