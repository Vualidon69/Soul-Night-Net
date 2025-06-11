namespace QuanLyQuanNet.Admin.ChucNang.LichSu
{
    partial class uc_LichSu 
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
            dataGridView_LichSu = new DataGridView();
            label_XemHoaDon = new Label();
            button_XemChiTiet = new Button();
            button_xuatFile = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_LichSu).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_LichSu
            // 
            dataGridView_LichSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_LichSu.Location = new Point(2, 71);
            dataGridView_LichSu.Name = "dataGridView_LichSu";
            dataGridView_LichSu.RowHeadersWidth = 51;
            dataGridView_LichSu.Size = new Size(715, 507);
            dataGridView_LichSu.TabIndex = 0;
            // 
            // label_XemHoaDon
            // 
            label_XemHoaDon.AutoSize = true;
            label_XemHoaDon.Location = new Point(29, 28);
            label_XemHoaDon.Name = "label_XemHoaDon";
            label_XemHoaDon.Size = new Size(106, 20);
            label_XemHoaDon.TabIndex = 1;
            label_XemHoaDon.Text = "Xem Hóa Đơn:";
            // 
            // button_XemChiTiet
            // 
            button_XemChiTiet.Location = new Point(230, 18);
            button_XemChiTiet.Name = "button_XemChiTiet";
            button_XemChiTiet.Size = new Size(132, 31);
            button_XemChiTiet.TabIndex = 5;
            button_XemChiTiet.Text = "Xem chi tiết";
            button_XemChiTiet.UseVisualStyleBackColor = true;
            button_XemChiTiet.Click += button_XemChiTiet_Click;
            // 
            // button_xuatFile
            // 
            button_xuatFile.Location = new Point(456, 19);
            button_xuatFile.Name = "button_xuatFile";
            button_xuatFile.Size = new Size(132, 29);
            button_xuatFile.TabIndex = 6;
            button_xuatFile.Text = "Xuất file excel";
            button_xuatFile.UseVisualStyleBackColor = true;
            button_xuatFile.Click += button_xuatFile_Click;
            // 
            // uc_LichSu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button_xuatFile);
            Controls.Add(button_XemChiTiet);
            Controls.Add(label_XemHoaDon);
            Controls.Add(dataGridView_LichSu);
            Name = "uc_LichSu";
            Size = new Size(715, 575);
            ((System.ComponentModel.ISupportInitialize)dataGridView_LichSu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_LichSu;
        private Label label_XemHoaDon;
        private Button button_XemChiTiet;
        private Button button_xuatFile;
    }
}
