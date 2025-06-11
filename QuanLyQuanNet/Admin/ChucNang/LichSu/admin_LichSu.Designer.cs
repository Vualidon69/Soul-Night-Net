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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridView_LichSu = new DataGridView();
            label_XemHoaDon = new Label();
            button_XemChiTiet = new Button();
            button_xuatFile = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_LichSu).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_LichSu
            // 
            dataGridView_LichSu.AllowUserToAddRows = false;
            dataGridView_LichSu.AllowUserToDeleteRows = false;
            dataGridView_LichSu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView_LichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_LichSu.BackgroundColor = Color.White;
            dataGridView_LichSu.BorderStyle = BorderStyle.None;
            dataGridView_LichSu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_LichSu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_LichSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_LichSu.EnableHeadersVisualStyles = false;
            dataGridView_LichSu.GridColor = System.Drawing.Color.Gainsboro;
            dataGridView_LichSu.Location = new Point(2, 71);
            dataGridView_LichSu.Name = "dataGridView_LichSu";
            dataGridView_LichSu.ReadOnly = true;
            dataGridView_LichSu.RowHeadersVisible = false;
            dataGridView_LichSu.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView_LichSu.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView_LichSu.RowTemplate.Height = 40;
            dataGridView_LichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView_LichSu.Size = new Size(715, 507);
            dataGridView_LichSu.TabIndex = 0;
            // 
            // label_XemHoaDon
            // 
            label_XemHoaDon.AutoSize = true;
            label_XemHoaDon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_XemHoaDon.Location = new Point(29, 28);
            label_XemHoaDon.Name = "label_XemHoaDon";
            label_XemHoaDon.Size = new Size(106, 20);
            label_XemHoaDon.TabIndex = 1;
            label_XemHoaDon.Text = "Xem Hóa Đơn:";
            // 
            // button_XemChiTiet
            // 
            button_XemChiTiet.BackColor = System.Drawing.Color.FromArgb(83, 163, 222);
            button_XemChiTiet.FlatAppearance.BorderSize = 0;
            button_XemChiTiet.FlatStyle = FlatStyle.Flat;
            button_XemChiTiet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button_XemChiTiet.ForeColor = Color.White;
            button_XemChiTiet.Location = new Point(230, 18);
            button_XemChiTiet.Name = "button_XemChiTiet";
            button_XemChiTiet.Size = new Size(132, 31);
            button_XemChiTiet.TabIndex = 5;
            button_XemChiTiet.Text = "Xem chi tiết";
            button_XemChiTiet.UseVisualStyleBackColor = false;
            
            // 
            // button_xuatFile
            // 
            button_xuatFile.BackColor = System.Drawing.Color.FromArgb(83, 163, 222);
            button_xuatFile.FlatAppearance.BorderSize = 0;
            button_xuatFile.FlatStyle = FlatStyle.Flat;
            button_xuatFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button_xuatFile.ForeColor = Color.White;
            button_xuatFile.Location = new Point(456, 19);
            button_xuatFile.Name = "button_xuatFile";
            button_xuatFile.Size = new Size(132, 29);
            button_xuatFile.TabIndex = 6;
            button_xuatFile.Text = "Xuất file excel";
            button_xuatFile.UseVisualStyleBackColor = false;
           
            // 
            // uc_LichSu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
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
        private System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1;
        private System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2;
    }
}
