namespace GUI
{
    partial class DanhSachPhong
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
            this.pannel_main = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pic_ngay = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label_thoigian = new System.Windows.Forms.Label();
            this.label_tenkhachhang = new System.Windows.Forms.Label();
            this.label_trangthai = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label_tenphong = new System.Windows.Forms.Label();
            this.label_maphong = new System.Windows.Forms.Label();
            this.pannel_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ngay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pannel_main
            // 
            this.pannel_main.BackColor = System.Drawing.Color.Transparent;
            this.pannel_main.BorderColor = System.Drawing.Color.White;
            this.pannel_main.BorderRadius = 10;
            this.pannel_main.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            this.pannel_main.Controls.Add(this.guna2PictureBox2);
            this.pannel_main.Controls.Add(this.pic_ngay);
            this.pannel_main.Controls.Add(this.label_thoigian);
            this.pannel_main.Controls.Add(this.label_tenkhachhang);
            this.pannel_main.Controls.Add(this.label_trangthai);
            this.pannel_main.Controls.Add(this.guna2PictureBox1);
            this.pannel_main.Controls.Add(this.label_tenphong);
            this.pannel_main.Controls.Add(this.label_maphong);
            this.pannel_main.FillColor = System.Drawing.Color.RoyalBlue;
            this.pannel_main.FillColor2 = System.Drawing.Color.RoyalBlue;
            this.pannel_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pannel_main.Location = new System.Drawing.Point(5, 3);
            this.pannel_main.Name = "pannel_main";
            this.pannel_main.Size = new System.Drawing.Size(363, 149);
            this.pannel_main.TabIndex = 0;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::GUI.Properties.Resources.star;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(14, 13);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(28, 23);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 9;
            this.guna2PictureBox2.TabStop = false;
            // 
            // pic_ngay
            // 
            this.pic_ngay.Image = global::GUI.Properties.Resources.calendar;
            this.pic_ngay.ImageRotate = 0F;
            this.pic_ngay.Location = new System.Drawing.Point(14, 114);
            this.pic_ngay.Name = "pic_ngay";
            this.pic_ngay.Size = new System.Drawing.Size(36, 32);
            this.pic_ngay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ngay.TabIndex = 8;
            this.pic_ngay.TabStop = false;
            // 
            // label_thoigian
            // 
            this.label_thoigian.AutoEllipsis = true;
            this.label_thoigian.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thoigian.ForeColor = System.Drawing.Color.White;
            this.label_thoigian.Location = new System.Drawing.Point(56, 118);
            this.label_thoigian.Name = "label_thoigian";
            this.label_thoigian.Size = new System.Drawing.Size(152, 28);
            this.label_thoigian.TabIndex = 6;
            this.label_thoigian.Text = "0 ngày";
            this.label_thoigian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_tenkhachhang
            // 
            this.label_tenkhachhang.AutoEllipsis = true;
            this.label_tenkhachhang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tenkhachhang.ForeColor = System.Drawing.Color.Yellow;
            this.label_tenkhachhang.Location = new System.Drawing.Point(103, 78);
            this.label_tenkhachhang.Name = "label_tenkhachhang";
            this.label_tenkhachhang.Size = new System.Drawing.Size(263, 36);
            this.label_tenkhachhang.TabIndex = 5;
            this.label_tenkhachhang.Text = "Tên khách hàng";
            this.label_tenkhachhang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_tenkhachhang.Visible = false;
            // 
            // label_trangthai
            // 
            this.label_trangthai.AutoEllipsis = true;
            this.label_trangthai.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_trangthai.ForeColor = System.Drawing.Color.White;
            this.label_trangthai.Location = new System.Drawing.Point(131, 114);
            this.label_trangthai.Name = "label_trangthai";
            this.label_trangthai.Size = new System.Drawing.Size(227, 32);
            this.label_trangthai.TabIndex = 4;
            this.label_trangthai.Text = "Trạng thái ";
            this.label_trangthai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::GUI.Properties.Resources.resort__1_;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(14, 13);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(94, 95);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label_tenphong
            // 
            this.label_tenphong.AutoEllipsis = true;
            this.label_tenphong.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tenphong.ForeColor = System.Drawing.Color.White;
            this.label_tenphong.Location = new System.Drawing.Point(99, 42);
            this.label_tenphong.Name = "label_tenphong";
            this.label_tenphong.Size = new System.Drawing.Size(261, 36);
            this.label_tenphong.TabIndex = 2;
            this.label_tenphong.Text = "Tên phòng";
            this.label_tenphong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_maphong
            // 
            this.label_maphong.AutoEllipsis = true;
            this.label_maphong.BackColor = System.Drawing.Color.Transparent;
            this.label_maphong.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_maphong.ForeColor = System.Drawing.Color.Yellow;
            this.label_maphong.Location = new System.Drawing.Point(215, 0);
            this.label_maphong.Name = "label_maphong";
            this.label_maphong.Size = new System.Drawing.Size(148, 36);
            this.label_maphong.TabIndex = 1;
            this.label_maphong.Text = "Mã phòng";
            this.label_maphong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DanhSachPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GUI.Properties.Resources.snapedit_1700120992627;
            this.Controls.Add(this.pannel_main);
            this.Name = "DanhSachPhong";
            this.Size = new System.Drawing.Size(371, 158);
            this.pannel_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ngay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pannel_main;
        private System.Windows.Forms.Label label_maphong;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label_tenphong;
        private System.Windows.Forms.Label label_trangthai;
        private System.Windows.Forms.Label label_tenkhachhang;
        private System.Windows.Forms.Label label_thoigian;
        private Guna.UI2.WinForms.Guna2PictureBox pic_ngay;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
    }
}
