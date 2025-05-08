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
            img_monAn = new PictureBox();
            pnl_chiTietMonAn = new RoundedPanel();
            lb_tenMon = new Label();
            txt_tenMon = new TextBox();
            txt_Gia = new TextBox();
            lb_Gia = new Label();
            lb_maMon = new Label();
            txt_maMon = new TextBox();
            btnEdit_Click = new Button();
            panel1 = new Panel();
            lb_timKiemMonAn = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)img_monAn).BeginInit();
            pnl_chiTietMonAn.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(13, 14);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(180, 34);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += textBox1_TextChanged;
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
            // 
            // btn_xoaMon
            // 
            btn_xoaMon.Location = new Point(324, 19);
            btn_xoaMon.Name = "btn_xoaMon";
            btn_xoaMon.Size = new Size(100, 29);
            btn_xoaMon.TabIndex = 2;
            btn_xoaMon.Text = "Xoá Món";
            btn_xoaMon.UseVisualStyleBackColor = true;
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
            dgvMenu.RowTemplate.Height = 29;
            dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMenu.Size = new Size(414, 474);
            dgvMenu.TabIndex = 3;
            dgvMenu.CellClick += dgvMenu_CellClick;
            // 
            // img_monAn
            // 
            img_monAn.Location = new Point(450, 80);
            img_monAn.Name = "img_monAn";
            img_monAn.Size = new Size(246, 162);
            img_monAn.SizeMode = PictureBoxSizeMode.Zoom;
            img_monAn.TabIndex = 4;
            img_monAn.TabStop = false;
            // 
            // pnl_chiTietMonAn
            // 
            pnl_chiTietMonAn.BorderColor = Color.Black;
            pnl_chiTietMonAn.BorderRadius = 20;
            pnl_chiTietMonAn.BorderThickness = 2;
            pnl_chiTietMonAn.Controls.Add(lb_tenMon);
            pnl_chiTietMonAn.Controls.Add(txt_tenMon);
            pnl_chiTietMonAn.Controls.Add(txt_Gia);
            pnl_chiTietMonAn.Controls.Add(lb_Gia);
            pnl_chiTietMonAn.Controls.Add(lb_maMon);
            pnl_chiTietMonAn.Controls.Add(txt_maMon);
            pnl_chiTietMonAn.Controls.Add(btnEdit_Click);
            pnl_chiTietMonAn.Location = new Point(450, 283);
            pnl_chiTietMonAn.Name = "pnl_chiTietMonAn";
            pnl_chiTietMonAn.Size = new Size(246, 251);
            pnl_chiTietMonAn.TabIndex = 5;
            // 
            // lb_tenMon
            // 
            lb_tenMon.AutoSize = true;
            lb_tenMon.Location = new Point(12, 127);
            lb_tenMon.Name = "lb_tenMon";
            lb_tenMon.Size = new Size(66, 20);
            lb_tenMon.TabIndex = 6;
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
            btnEdit_Click.Text = "Sửa chi tiêt hóa đơn";
            btnEdit_Click.UseVisualStyleBackColor = true;
            btnEdit_Click.Click += btnEdit_Click_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvMenu);
            panel1.Location = new Point(11, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(414, 474);
            panel1.TabIndex = 6;
            // 
            // lb_timKiemMonAn
            // 
            lb_timKiemMonAn.AutoSize = true;
            lb_timKiemMonAn.Location = new Point(13, 23);
            lb_timKiemMonAn.Name = "lb_timKiemMonAn";
            lb_timKiemMonAn.Size = new Size(124, 20);
            lb_timKiemMonAn.TabIndex = 7;
            lb_timKiemMonAn.Text = "Tìm kiếm món ăn";
            lb_timKiemMonAn.Click += lb_timKiemMonAn_Click;
            // 
            // admin_Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lb_timKiemMonAn);
            Controls.Add(panel1);
            Controls.Add(pnl_chiTietMonAn);
            Controls.Add(img_monAn);
            Controls.Add(btn_xoaMon);
            Controls.Add(btn_themMon);
            Controls.Add(txtSearch);
            Name = "admin_Menu";
            Size = new Size(715, 575);
            Load += admin_Menu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)img_monAn).EndInit();
            pnl_chiTietMonAn.ResumeLayout(false);
            pnl_chiTietMonAn.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btn_themMon;
        private Button btn_xoaMon;
        private DataGridView dgvMenu;
        private PictureBox img_monAn;
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
    }
}
