namespace QuanLyQuanNet.Admin.ChucNang
{
    partial class frmEditBillDetail
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            button1 = new Button();
            dgvBill = new DataGridView();
            lb_themMonMoi = new Label();
            button2 = new Button();
            lb_maMonAn = new Label();
            lb_Gia = new Label();
            lb_tenMonAn = new Label();
            button3 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBill).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button2);
            panel1.Controls.Add(lb_themMonMoi);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(949, 62);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(447, 184);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(lb_tenMonAn);
            panel2.Controls.Add(lb_Gia);
            panel2.Controls.Add(lb_maMonAn);
            panel2.Location = new Point(483, 80);
            panel2.Name = "panel2";
            panel2.Size = new Size(460, 225);
            panel2.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(12, 270);
            button1.Name = "button1";
            button1.Size = new Size(447, 37);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // dgvBill
            // 
            dgvBill.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBill.Location = new Point(12, 346);
            dgvBill.Name = "dgvBill";
            dgvBill.RowHeadersWidth = 51;
            dgvBill.RowTemplate.Height = 29;
            dgvBill.Size = new Size(949, 308);
            dgvBill.TabIndex = 4;
       
            // 
            // lb_themMonMoi
            // 
            lb_themMonMoi.AutoSize = true;
            lb_themMonMoi.Location = new Point(34, 19);
            lb_themMonMoi.Name = "lb_themMonMoi";
            lb_themMonMoi.Size = new Size(110, 20);
            lb_themMonMoi.TabIndex = 0;
            lb_themMonMoi.Text = "Thêm món mới";
          
            // 
            // button2
            // 
            button2.Location = new Point(831, 10);
            button2.Name = "button2";
            button2.Size = new Size(89, 38);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // lb_maMonAn
            // 
            lb_maMonAn.AutoSize = true;
            lb_maMonAn.Location = new Point(34, 11);
            lb_maMonAn.Name = "lb_maMonAn";
            lb_maMonAn.Size = new Size(84, 20);
            lb_maMonAn.TabIndex = 0;
            lb_maMonAn.Text = "Mã món ăn";
            // 
            // lb_Gia
            // 
            lb_Gia.AutoSize = true;
            lb_Gia.Location = new Point(252, 11);
            lb_Gia.Name = "lb_Gia";
            lb_Gia.Size = new Size(31, 20);
            lb_Gia.TabIndex = 0;
            lb_Gia.Text = "Giá";
   
            // 
            // lb_tenMonAn
            // 
            lb_tenMonAn.AutoSize = true;
            lb_tenMonAn.Location = new Point(38, 85);
            lb_tenMonAn.Name = "lb_tenMonAn";
            lb_tenMonAn.Size = new Size(86, 20);
            lb_tenMonAn.TabIndex = 0;
            lb_tenMonAn.Text = "Tên món ăn";
        
            // 
            // button3
            // 
            button3.Location = new Point(34, 182);
            button3.Name = "button3";
            button3.Size = new Size(415, 40);
            button3.TabIndex = 1;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(34, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(252, 45);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(197, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(38, 117);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(411, 27);
            textBox3.TabIndex = 4;
            // 
            // frmEditBillDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(973, 666);
            Controls.Add(dgvBill);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "frmEditBillDetail";
            Text = "frmEditBillDetail";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBill).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Button button1;
        private DataGridView dgvBill;
        private Label lb_themMonMoi;
        private Button button2;
        private Button button3;
        private Label lb_tenMonAn;
        private Label lb_Gia;
        private Label lb_maMonAn;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}