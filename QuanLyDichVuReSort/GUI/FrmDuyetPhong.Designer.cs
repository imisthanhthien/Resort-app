namespace GUI
{
    partial class FrmDuyetPhong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNhanVien = new Guna.UI2.WinForms.Guna2TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label_tenphong = new System.Windows.Forms.Label();
            this.btnHuyPhong = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btn_duyetphong = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.dtDuyetPhong = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id_datphong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_khachhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ten_loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_in = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_out = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dat_coc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.so_nguoi_o = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngaydat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GradientPanel2.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDuyetPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.BorderColor = System.Drawing.Color.RoyalBlue;
            this.txtNhanVien.BorderRadius = 5;
            this.txtNhanVien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNhanVien.DefaultText = "";
            this.txtNhanVien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNhanVien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNhanVien.Enabled = false;
            this.txtNhanVien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(55)))), ((int)(((byte)(81)))));
            this.txtNhanVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNhanVien.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanVien.ForeColor = System.Drawing.Color.White;
            this.txtNhanVien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNhanVien.Location = new System.Drawing.Point(35, 36);
            this.txtNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.PasswordChar = '\0';
            this.txtNhanVien.PlaceholderText = "";
            this.txtNhanVien.SelectedText = "";
            this.txtNhanVien.Size = new System.Drawing.Size(216, 38);
            this.txtNhanVien.TabIndex = 38;
            this.txtNhanVien.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(50, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(94, 23);
            this.label23.TabIndex = 37;
            this.label23.Text = "Nhân viên";
            this.label23.Visible = false;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel2.BorderColor = System.Drawing.Color.Indigo;
            this.guna2GradientPanel2.BorderRadius = 12;
            this.guna2GradientPanel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2GradientPanel2.BorderThickness = 3;
            this.guna2GradientPanel2.Controls.Add(this.guna2GradientButton1);
            this.guna2GradientPanel2.Controls.Add(this.guna2ControlBox1);
            this.guna2GradientPanel2.Controls.Add(this.label_tenphong);
            this.guna2GradientPanel2.Controls.Add(this.btnHuyPhong);
            this.guna2GradientPanel2.Controls.Add(this.btn_duyetphong);
            this.guna2GradientPanel2.Controls.Add(this.guna2GradientPanel1);
            this.guna2GradientPanel2.Controls.Add(this.txtNhanVien);
            this.guna2GradientPanel2.Controls.Add(this.label23);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(45)))), ((int)(((byte)(81)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(45)))), ((int)(((byte)(81)))));
            this.guna2GradientPanel2.Location = new System.Drawing.Point(12, 12);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(1511, 632);
            this.guna2GradientPanel2.TabIndex = 76;
            // 
            // guna2GradientButton1
            // 
            this.guna2GradientButton1.BorderRadius = 10;
            this.guna2GradientButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2GradientButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButton1.FillColor = System.Drawing.Color.Blue;
            this.guna2GradientButton1.FillColor2 = System.Drawing.Color.DeepPink;
            this.guna2GradientButton1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GradientButton1.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButton1.Image = global::GUI.Properties.Resources.undo1;
            this.guna2GradientButton1.ImageSize = new System.Drawing.Size(35, 35);
            this.guna2GradientButton1.Location = new System.Drawing.Point(996, 542);
            this.guna2GradientButton1.Name = "guna2GradientButton1";
            this.guna2GradientButton1.Size = new System.Drawing.Size(225, 69);
            this.guna2GradientButton1.TabIndex = 77;
            this.guna2GradientButton1.Text = "Làm mới đơn";
            this.guna2GradientButton1.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderRadius = 5;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.Font = new System.Drawing.Font("Microsoft MHei", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(1450, 9);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(49, 43);
            this.guna2ControlBox1.TabIndex = 77;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // label_tenphong
            // 
            this.label_tenphong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label_tenphong.AutoSize = true;
            this.label_tenphong.Font = new System.Drawing.Font("Arial", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tenphong.ForeColor = System.Drawing.Color.White;
            this.label_tenphong.Location = new System.Drawing.Point(463, 19);
            this.label_tenphong.Name = "label_tenphong";
            this.label_tenphong.Size = new System.Drawing.Size(614, 55);
            this.label_tenphong.TabIndex = 76;
            this.label_tenphong.Text = "ĐƠN ĐẶT PHÒNG ONLINE";
            this.label_tenphong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHuyPhong
            // 
            this.btnHuyPhong.BorderRadius = 10;
            this.btnHuyPhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyPhong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuyPhong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuyPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuyPhong.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuyPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuyPhong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnHuyPhong.FillColor2 = System.Drawing.Color.Red;
            this.btnHuyPhong.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyPhong.ForeColor = System.Drawing.Color.White;
            this.btnHuyPhong.Image = global::GUI.Properties.Resources.remove1;
            this.btnHuyPhong.ImageSize = new System.Drawing.Size(35, 35);
            this.btnHuyPhong.Location = new System.Drawing.Point(643, 542);
            this.btnHuyPhong.Name = "btnHuyPhong";
            this.btnHuyPhong.Size = new System.Drawing.Size(225, 69);
            this.btnHuyPhong.TabIndex = 76;
            this.btnHuyPhong.Text = "Hủy đơn";
            this.btnHuyPhong.Click += new System.EventHandler(this.btnHuyPhong_Click);
            // 
            // btn_duyetphong
            // 
            this.btn_duyetphong.BorderRadius = 10;
            this.btn_duyetphong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_duyetphong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_duyetphong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_duyetphong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_duyetphong.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_duyetphong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_duyetphong.FillColor = System.Drawing.Color.Blue;
            this.btn_duyetphong.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_duyetphong.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.btn_duyetphong.ForeColor = System.Drawing.Color.White;
            this.btn_duyetphong.Image = global::GUI.Properties.Resources.check1;
            this.btn_duyetphong.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_duyetphong.Location = new System.Drawing.Point(271, 542);
            this.btn_duyetphong.Name = "btn_duyetphong";
            this.btn_duyetphong.Size = new System.Drawing.Size(225, 69);
            this.btn_duyetphong.TabIndex = 68;
            this.btn_duyetphong.Text = "Duyệt đơn";
            this.btn_duyetphong.Click += new System.EventHandler(this.btn_duyetphong_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.Black;
            this.guna2GradientPanel1.BorderRadius = 15;
            this.guna2GradientPanel1.Controls.Add(this.dtDuyetPhong);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.MintCream;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.MintCream;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(21, 93);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1478, 438);
            this.guna2GradientPanel1.TabIndex = 56;
            // 
            // dtDuyetPhong
            // 
            this.dtDuyetPhong.AllowUserToAddRows = false;
            this.dtDuyetPhong.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtDuyetPhong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtDuyetPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dtDuyetPhong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtDuyetPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtDuyetPhong.ColumnHeadersHeight = 40;
            this.dtDuyetPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_datphong,
            this.id_phong,
            this.ten_khachhang,
            this.ten_loai,
            this.check_in,
            this.check_out,
            this.dat_coc,
            this.so_nguoi_o,
            this.ngaydat});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtDuyetPhong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtDuyetPhong.GridColor = System.Drawing.Color.Black;
            this.dtDuyetPhong.Location = new System.Drawing.Point(14, 8);
            this.dtDuyetPhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtDuyetPhong.Name = "dtDuyetPhong";
            this.dtDuyetPhong.ReadOnly = true;
            this.dtDuyetPhong.RowHeadersVisible = false;
            this.dtDuyetPhong.RowHeadersWidth = 100;
            this.dtDuyetPhong.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtDuyetPhong.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.dtDuyetPhong.RowTemplate.Height = 50;
            this.dtDuyetPhong.Size = new System.Drawing.Size(1448, 415);
            this.dtDuyetPhong.TabIndex = 5;
            this.dtDuyetPhong.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtDuyetPhong.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtDuyetPhong.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtDuyetPhong.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtDuyetPhong.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtDuyetPhong.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtDuyetPhong.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.dtDuyetPhong.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtDuyetPhong.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtDuyetPhong.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDuyetPhong.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtDuyetPhong.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtDuyetPhong.ThemeStyle.HeaderStyle.Height = 40;
            this.dtDuyetPhong.ThemeStyle.ReadOnly = true;
            this.dtDuyetPhong.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtDuyetPhong.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtDuyetPhong.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDuyetPhong.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Yellow;
            this.dtDuyetPhong.ThemeStyle.RowsStyle.Height = 50;
            this.dtDuyetPhong.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtDuyetPhong.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtDuyetPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDuyetPhong_CellClick_1);
            // 
            // id_datphong
            // 
            this.id_datphong.DataPropertyName = "id_datphong";
            this.id_datphong.HeaderText = "Mã đặt";
            this.id_datphong.MinimumWidth = 6;
            this.id_datphong.Name = "id_datphong";
            this.id_datphong.ReadOnly = true;
            this.id_datphong.Width = 80;
            // 
            // id_phong
            // 
            this.id_phong.DataPropertyName = "id_phong";
            this.id_phong.HeaderText = "Mã phòng";
            this.id_phong.MinimumWidth = 6;
            this.id_phong.Name = "id_phong";
            this.id_phong.ReadOnly = true;
            this.id_phong.Visible = false;
            this.id_phong.Width = 164;
            // 
            // ten_khachhang
            // 
            this.ten_khachhang.DataPropertyName = "ten_khachhang";
            this.ten_khachhang.HeaderText = "Khách hàng";
            this.ten_khachhang.MinimumWidth = 6;
            this.ten_khachhang.Name = "ten_khachhang";
            this.ten_khachhang.ReadOnly = true;
            this.ten_khachhang.Width = 200;
            // 
            // ten_loai
            // 
            this.ten_loai.DataPropertyName = "ten_loai";
            this.ten_loai.HeaderText = "Loại phòng";
            this.ten_loai.MinimumWidth = 6;
            this.ten_loai.Name = "ten_loai";
            this.ten_loai.ReadOnly = true;
            this.ten_loai.Width = 200;
            // 
            // check_in
            // 
            this.check_in.DataPropertyName = "check_in";
            this.check_in.HeaderText = "Check in";
            this.check_in.MinimumWidth = 6;
            this.check_in.Name = "check_in";
            this.check_in.ReadOnly = true;
            this.check_in.Width = 130;
            // 
            // check_out
            // 
            this.check_out.DataPropertyName = "check_out";
            this.check_out.HeaderText = "Check out";
            this.check_out.MinimumWidth = 6;
            this.check_out.Name = "check_out";
            this.check_out.ReadOnly = true;
            this.check_out.Width = 130;
            // 
            // dat_coc
            // 
            this.dat_coc.DataPropertyName = "dat_coc";
            this.dat_coc.HeaderText = "Đặt cọc";
            this.dat_coc.MinimumWidth = 6;
            this.dat_coc.Name = "dat_coc";
            this.dat_coc.ReadOnly = true;
            this.dat_coc.Width = 130;
            // 
            // so_nguoi_o
            // 
            this.so_nguoi_o.DataPropertyName = "so_nguoi_o";
            this.so_nguoi_o.HeaderText = "Số người";
            this.so_nguoi_o.MinimumWidth = 6;
            this.so_nguoi_o.Name = "so_nguoi_o";
            this.so_nguoi_o.ReadOnly = true;
            this.so_nguoi_o.Width = 80;
            // 
            // ngaydat
            // 
            this.ngaydat.DataPropertyName = "ngaydat";
            this.ngaydat.HeaderText = "Ngày đặt";
            this.ngaydat.MinimumWidth = 6;
            this.ngaydat.Name = "ngaydat";
            this.ngaydat.ReadOnly = true;
            this.ngaydat.Width = 130;
            // 
            // FrmDuyetPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1535, 656);
            this.Controls.Add(this.guna2GradientPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDuyetPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDuyetPhong";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.FrmDuyetPhong_Load);
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDuyetPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtNhanVien;
        private System.Windows.Forms.Label label23;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientButton btnHuyPhong;
        private Guna.UI2.WinForms.Guna2GradientButton btn_duyetphong;
        private System.Windows.Forms.Label label_tenphong;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dtDuyetPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_datphong;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_phong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_khachhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ten_loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_in;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_out;
        private System.Windows.Forms.DataGridViewTextBoxColumn dat_coc;
        private System.Windows.Forms.DataGridViewTextBoxColumn so_nguoi_o;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngaydat;
    }
}