namespace GUI
{
    partial class FrmNhanVienKhongHoatDong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.dataNhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id_nhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_nhanvien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngay_sinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioi_tinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_dang_nhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ra_khonghoatdong = new Guna.UI2.WinForms.Guna2RadioButton();
            this.ra_hoatdong = new Guna.UI2.WinForms.Guna2RadioButton();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnChonAnh = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataNhanVien)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.guna2Panel3);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(45)))), ((int)(((byte)(81)))));
            this.guna2Panel1.Location = new System.Drawing.Point(12, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1331, 651);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.dataNhanVien);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 159);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1331, 492);
            this.guna2Panel3.TabIndex = 1;
            // 
            // dataNhanVien
            // 
            this.dataNhanVien.AllowUserToAddRows = false;
            this.dataNhanVien.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dataNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataNhanVien.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkViolet;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataNhanVien.ColumnHeadersHeight = 45;
            this.dataNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_nhanvien,
            this.ten_nhanvien,
            this.ngay_sinh,
            this.Sdt,
            this.gioi_tinh,
            this.email,
            this.ten_dang_nhap,
            this.quyen,
            this.trangthai});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataNhanVien.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataNhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataNhanVien.Location = new System.Drawing.Point(22, 6);
            this.dataNhanVien.Name = "dataNhanVien";
            this.dataNhanVien.ReadOnly = true;
            this.dataNhanVien.RowHeadersVisible = false;
            this.dataNhanVien.RowHeadersWidth = 100;
            this.dataNhanVien.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataNhanVien.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.dataNhanVien.RowTemplate.Height = 50;
            this.dataNhanVien.Size = new System.Drawing.Size(1296, 466);
            this.dataNhanVien.TabIndex = 1;
            this.dataNhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataNhanVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataNhanVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataNhanVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataNhanVien.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataNhanVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataNhanVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataNhanVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataNhanVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataNhanVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataNhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataNhanVien.ThemeStyle.HeaderStyle.Height = 45;
            this.dataNhanVien.ThemeStyle.ReadOnly = true;
            this.dataNhanVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataNhanVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataNhanVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataNhanVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Yellow;
            this.dataNhanVien.ThemeStyle.RowsStyle.Height = 50;
            this.dataNhanVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataNhanVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataNhanVien_CellClick);
            // 
            // id_nhanvien
            // 
            this.id_nhanvien.DataPropertyName = "id_nhanvien";
            this.id_nhanvien.HeaderText = "Mã NV";
            this.id_nhanvien.MinimumWidth = 6;
            this.id_nhanvien.Name = "id_nhanvien";
            this.id_nhanvien.ReadOnly = true;
            // 
            // ten_nhanvien
            // 
            this.ten_nhanvien.DataPropertyName = "ten_nhanvien";
            this.ten_nhanvien.HeaderText = "Họ tên";
            this.ten_nhanvien.MinimumWidth = 6;
            this.ten_nhanvien.Name = "ten_nhanvien";
            this.ten_nhanvien.ReadOnly = true;
            // 
            // ngay_sinh
            // 
            this.ngay_sinh.DataPropertyName = "ngay_sinh";
            this.ngay_sinh.HeaderText = "Ngày sinh";
            this.ngay_sinh.MinimumWidth = 6;
            this.ngay_sinh.Name = "ngay_sinh";
            this.ngay_sinh.ReadOnly = true;
            this.ngay_sinh.Visible = false;
            // 
            // Sdt
            // 
            this.Sdt.DataPropertyName = "Sdt";
            this.Sdt.HeaderText = "SĐT";
            this.Sdt.MinimumWidth = 6;
            this.Sdt.Name = "Sdt";
            this.Sdt.ReadOnly = true;
            // 
            // gioi_tinh
            // 
            this.gioi_tinh.DataPropertyName = "gioi_tinh";
            this.gioi_tinh.HeaderText = "Giới tính";
            this.gioi_tinh.MinimumWidth = 6;
            this.gioi_tinh.Name = "gioi_tinh";
            this.gioi_tinh.ReadOnly = true;
            this.gioi_tinh.Visible = false;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // ten_dang_nhap
            // 
            this.ten_dang_nhap.DataPropertyName = "ten_dang_nhap";
            this.ten_dang_nhap.HeaderText = "Tài khoản";
            this.ten_dang_nhap.MinimumWidth = 6;
            this.ten_dang_nhap.Name = "ten_dang_nhap";
            this.ten_dang_nhap.ReadOnly = true;
            // 
            // quyen
            // 
            this.quyen.DataPropertyName = "ten_quyen";
            this.quyen.HeaderText = "Quyền";
            this.quyen.MinimumWidth = 6;
            this.quyen.Name = "quyen";
            this.quyen.ReadOnly = true;
            // 
            // trangthai
            // 
            this.trangthai.DataPropertyName = "trangthai";
            this.trangthai.HeaderText = "TrangThai";
            this.trangthai.MinimumWidth = 6;
            this.trangthai.Name = "trangthai";
            this.trangthai.ReadOnly = true;
            this.trangthai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.trangthai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.groupBox1);
            this.guna2Panel2.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel2.Controls.Add(this.btnChonAnh);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1331, 159);
            this.guna2Panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ra_khonghoatdong);
            this.groupBox1.Controls.Add(this.ra_hoatdong);
            this.groupBox1.ForeColor = System.Drawing.Color.Transparent;
            this.groupBox1.Location = new System.Drawing.Point(63, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 98);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            // 
            // ra_khonghoatdong
            // 
            this.ra_khonghoatdong.AutoSize = true;
            this.ra_khonghoatdong.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ra_khonghoatdong.CheckedState.BorderThickness = 0;
            this.ra_khonghoatdong.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ra_khonghoatdong.CheckedState.InnerColor = System.Drawing.Color.White;
            this.ra_khonghoatdong.CheckedState.InnerOffset = -4;
            this.ra_khonghoatdong.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ra_khonghoatdong.Location = new System.Drawing.Point(463, 31);
            this.ra_khonghoatdong.Name = "ra_khonghoatdong";
            this.ra_khonghoatdong.Size = new System.Drawing.Size(268, 40);
            this.ra_khonghoatdong.TabIndex = 1;
            this.ra_khonghoatdong.Text = "Ngưng hoạt động";
            this.ra_khonghoatdong.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ra_khonghoatdong.UncheckedState.BorderThickness = 2;
            this.ra_khonghoatdong.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.ra_khonghoatdong.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // ra_hoatdong
            // 
            this.ra_hoatdong.AutoSize = true;
            this.ra_hoatdong.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ra_hoatdong.CheckedState.BorderThickness = 0;
            this.ra_hoatdong.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ra_hoatdong.CheckedState.InnerColor = System.Drawing.Color.White;
            this.ra_hoatdong.CheckedState.InnerOffset = -4;
            this.ra_hoatdong.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ra_hoatdong.Location = new System.Drawing.Point(31, 31);
            this.ra_hoatdong.Name = "ra_hoatdong";
            this.ra_hoatdong.Size = new System.Drawing.Size(249, 40);
            this.ra_hoatdong.TabIndex = 0;
            this.ra_hoatdong.Text = "Đang hoạt động";
            this.ra_hoatdong.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ra_hoatdong.UncheckedState.BorderThickness = 2;
            this.ra_hoatdong.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.ra_hoatdong.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.Font = new System.Drawing.Font("Microsoft MHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1276, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(42, 34);
            this.guna2ControlBox1.TabIndex = 98;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.Transparent;
            this.btnChonAnh.BorderRadius = 10;
            this.btnChonAnh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChonAnh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChonAnh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChonAnh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChonAnh.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChonAnh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChonAnh.FillColor = System.Drawing.Color.Red;
            this.btnChonAnh.FillColor2 = System.Drawing.Color.Blue;
            this.btnChonAnh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(974, 65);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(249, 67);
            this.btnChonAnh.TabIndex = 97;
            this.btnChonAnh.Text = "CẬP NHẬP";
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // FrmNhanVienKhongHoatDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1355, 669);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNhanVienKhongHoatDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNhanVienKhongHoatDong";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.FrmNhanVienKhongHoatDong_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataNhanVien)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2DataGridView dataNhanVien;
        private Guna.UI2.WinForms.Guna2GradientButton btnChonAnh;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2RadioButton ra_khonghoatdong;
        private Guna.UI2.WinForms.Guna2RadioButton ra_hoatdong;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nhanvien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_nhanvien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngay_sinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioi_tinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_dang_nhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn quyen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn trangthai;
    }
}