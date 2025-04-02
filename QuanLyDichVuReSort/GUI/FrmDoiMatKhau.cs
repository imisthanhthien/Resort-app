using DDL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmDoiMatKhau : Form
    {
        private string taikhoan;

        public FrmDoiMatKhau(string taikhoan)
        {
            this.taikhoan = taikhoan;
            InitializeComponent();
        }

        private void btn_hide_Click(object sender, EventArgs e)
        {
            txtNhapLaiMatKhau.PasswordChar = '\0';
            txtMatKhauMoi.PasswordChar = '\0';
            txtMatKhauCu.PasswordChar = '\0';
            btn_show.Visible = true;
            btn_hide.Visible = false;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            txtNhapLaiMatKhau.PasswordChar = '*';
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauCu.PasswordChar = '*';
            btn_show.Visible = false;
            btn_hide.Visible = true;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text != "")
            {
                if (txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text)
                {
                    DLL_NhanVien nhanvien = new DLL_NhanVien();

                    if (nhanvien.ThayDoiMatKhauNhanVien(taikhoan, txtMatKhauCu.Text, txtMatKhauMoi.Text))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Properties.Settings.Default.matkhau = "";
                        Properties.Settings.Default.Save();
                        Application.Restart();
                    }
                    else MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
