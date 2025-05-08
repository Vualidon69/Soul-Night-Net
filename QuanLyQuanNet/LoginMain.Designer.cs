namespace QuanLyQuanNet
{
    partial class LoginMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginMain));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ptn_fDangNhap = new RoundedPanel();
            cb_hienThiMK = new CheckBox();
            btn_dangNhap = new Button();
            lb_matKhau = new Label();
            lb_tenDangNhap = new Label();
            txt_matKhau = new TextBox();
            txt_dangNhap = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ptn_fDangNhap.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(322, 309);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 29);
            label1.Name = "label1";
            label1.Size = new Size(131, 17);
            label1.TabIndex = 2;
            label1.Text = "Quán Net Bình Minh";
            // 
            // ptn_fDangNhap
            // 
            ptn_fDangNhap.AutoSize = true;
            ptn_fDangNhap.BackColor = Color.White;
            ptn_fDangNhap.BorderColor = Color.Black;
            ptn_fDangNhap.BorderRadius = 20;
            ptn_fDangNhap.BorderThickness = 2;
            ptn_fDangNhap.Controls.Add(cb_hienThiMK);
            ptn_fDangNhap.Controls.Add(btn_dangNhap);
            ptn_fDangNhap.Controls.Add(lb_matKhau);
            ptn_fDangNhap.Controls.Add(lb_tenDangNhap);
            ptn_fDangNhap.Controls.Add(txt_matKhau);
            ptn_fDangNhap.Controls.Add(txt_dangNhap);
            ptn_fDangNhap.Location = new Point(384, 37);
            ptn_fDangNhap.Name = "ptn_fDangNhap";
            ptn_fDangNhap.Size = new Size(354, 333);
            ptn_fDangNhap.TabIndex = 3;
            ptn_fDangNhap.Paint += ptn_fDangNhap_Paint;
            // 
            // cb_hienThiMK
            // 
            cb_hienThiMK.AutoSize = true;
            cb_hienThiMK.Location = new Point(155, 216);
            cb_hienThiMK.Name = "cb_hienThiMK";
            cb_hienThiMK.Size = new Size(134, 21);
            cb_hienThiMK.TabIndex = 5;
            cb_hienThiMK.Text = "Hiện thị mật khẩu";
            cb_hienThiMK.UseVisualStyleBackColor = true;
            cb_hienThiMK.CheckedChanged += cb_hienThiMK_CheckedChanged;
            // 
            // btn_dangNhap
            // 
            btn_dangNhap.BackColor = Color.Blue;
            btn_dangNhap.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btn_dangNhap.ForeColor = Color.FromArgb(224, 224, 224);
            btn_dangNhap.Location = new Point(74, 243);
            btn_dangNhap.Name = "btn_dangNhap";
            btn_dangNhap.Size = new Size(222, 38);
            btn_dangNhap.TabIndex = 4;
            btn_dangNhap.Text = "Đăng nhập";
            btn_dangNhap.UseVisualStyleBackColor = false;
            btn_dangNhap.Click += btn_dangNhap_Click;
            // 
            // lb_matKhau
            // 
            lb_matKhau.AutoSize = true;
            lb_matKhau.ForeColor = Color.Gray;
            lb_matKhau.Location = new Point(74, 177);
            lb_matKhau.Name = "lb_matKhau";
            lb_matKhau.Size = new Size(64, 17);
            lb_matKhau.TabIndex = 3;
            lb_matKhau.Text = "Mật khẩu";
            lb_matKhau.Click += lb_matKhau_Click;
            // 
            // lb_tenDangNhap
            // 
            lb_tenDangNhap.AutoSize = true;
            lb_tenDangNhap.ForeColor = Color.Gray;
            lb_tenDangNhap.Location = new Point(74, 89);
            lb_tenDangNhap.Name = "lb_tenDangNhap";
            lb_tenDangNhap.Size = new Size(96, 17);
            lb_tenDangNhap.TabIndex = 2;
            lb_tenDangNhap.Text = "Tên đăng nhập";
            lb_tenDangNhap.Click += lb_tenDangNhap_Click;
            // 
            // txt_matKhau
            // 
            txt_matKhau.BackColor = Color.White;
            txt_matKhau.Location = new Point(74, 174);
            txt_matKhau.Name = "txt_matKhau";
            txt_matKhau.Size = new Size(222, 25);
            txt_matKhau.TabIndex = 1;
            txt_matKhau.Enter += txt_matKhau_Enter;
            txt_matKhau.KeyDown += txt_matKhau_KeyDown;
            txt_matKhau.Leave += txt_matKhau_Leave;
            // 
            // txt_dangNhap
            // 
            txt_dangNhap.BackColor = Color.White;
            txt_dangNhap.ForeColor = Color.Black;
            txt_dangNhap.Location = new Point(74, 87);
            txt_dangNhap.Name = "txt_dangNhap";
            txt_dangNhap.Size = new Size(222, 25);
            txt_dangNhap.TabIndex = 0;
            txt_dangNhap.Enter += txt_dangNhap_Enter;
            txt_dangNhap.KeyDown += txt_dangNhap_KeyDown;
            txt_dangNhap.Leave += txt_dangNhap_Leave;
            // 
            // LoginMain
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 395);
            Controls.Add(ptn_fDangNhap);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "LoginMain";
            Text = "Form1";
            Load += LoginMain_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ptn_fDangNhap.ResumeLayout(false);
            ptn_fDangNhap.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label1;
        private RoundedPanel ptn_fDangNhap;
        private TextBox txt_dangNhap;
        private TextBox txt_matKhau;
        private Label lb_matKhau;
        private Label lb_tenDangNhap;
        private Button btn_dangNhap;
        private CheckBox cb_hienThiMK;
    }
}
