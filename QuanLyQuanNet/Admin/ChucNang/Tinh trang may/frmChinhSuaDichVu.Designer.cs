namespace QuanLyQuanNet.Admin.ChucNang.Tinh_trang_may
{
    partial class frmChinhSuaDichVu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvMenu = new DataGridView();
            dgvDichVu = new DataGridView();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnOK = new Button();
            btnCancel = new Button();
            labelMenu = new Label();
            labelDichVu = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).BeginInit();
            SuspendLayout();
            // 
            // dgvMenu
            // 
            dgvMenu.AllowUserToAddRows = false;
            dgvMenu.AllowUserToDeleteRows = false;
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Location = new Point(23, 47);
            dgvMenu.Margin = new Padding(3, 4, 3, 4);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.ReadOnly = true;
            dgvMenu.RowHeadersWidth = 51;
            dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMenu.Size = new Size(400, 467);
            dgvMenu.TabIndex = 1;
            // 
            // dgvDichVu
            // 
            dgvDichVu.AllowUserToAddRows = false;
            dgvDichVu.AllowUserToDeleteRows = false;
            dgvDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDichVu.Location = new Point(457, 47);
            dgvDichVu.Margin = new Padding(3, 4, 3, 4);
            dgvDichVu.Name = "dgvDichVu";
            dgvDichVu.RowHeadersWidth = 51;
            dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDichVu.Size = new Size(400, 467);
            dgvDichVu.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(23, 533);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(114, 40);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm vào dịch vụ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(583, 533);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(114, 40);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa số lượng";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(709, 533);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(114, 40);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "Xóa món";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(457, 600);
            btnOK.Margin = new Padding(3, 4, 3, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(114, 40);
            btnOK.TabIndex = 7;
            btnOK.Text = "Lưu";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(743, 600);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 40);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // labelMenu
            // 
            labelMenu.AutoSize = true;
            labelMenu.Location = new Point(23, 20);
            labelMenu.Name = "labelMenu";
            labelMenu.Size = new Size(84, 20);
            labelMenu.TabIndex = 0;
            labelMenu.Text = "Menu tổng:";
            // 
            // labelDichVu
            // 
            labelDichVu.AutoSize = true;
            labelDichVu.Location = new Point(457, 20);
            labelDichVu.Name = "labelDichVu";
            labelDichVu.Size = new Size(118, 20);
            labelDichVu.TabIndex = 2;
            labelDichVu.Text = "Dịch vụ đã chọn:";
            // 
            // frmChinhSuaDichVu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 668);
            Controls.Add(labelMenu);
            Controls.Add(dgvMenu);
            Controls.Add(labelDichVu);
            Controls.Add(dgvDichVu);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChinhSuaDichVu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chỉnh sửa dịch vụ gọi món";
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMenu;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.Label labelDichVu;
    }
} 