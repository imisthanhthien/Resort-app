using DDL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmCapLaiMatKhau : Form
    {
        DLL_NhanVien nhanvien;

        public FrmCapLaiMatKhau()
        {
            InitializeComponent();

        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Gửi lại mật khẩu vào email cho nhân viên 
        private void btnCapMatKhau_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtTaiKhoan.Text != "")
            {
                nhanvien = new DLL_NhanVien();
                if (nhanvien.IsExistEmail(txtEmail.Text) && nhanvien.IsExistTaiKhoan(txtTaiKhoan.Text))
                {
                    if(nhanvien.TrangThaiNhanVien(txtTaiKhoan.Text.Trim()))
                    {
                        string password = nhanvien.GetRandomPassword();

                        if (nhanvien.UpdatePassword(txtEmail.Text, password))
                        {
                            FrmGuiMail loader = new FrmGuiMail(txtEmail.Text, txtTaiKhoan.Text, password, true);
                            loader.ShowDialog();
                            MsgBox(loader.Result, false);
                            txtTaiKhoan.Text = "";
                            txtEmail.Text = "";
                            txtTaiKhoan.Focus();
                        }
                        else
                            MsgBox("Không thực hiện được", true);
                    }
                    else
                        MsgBox("Tài khoản đã bị vô hiệu hóa!!", true);
                }
                else
                {
                    MsgBox("Email hoặc tài khoản không tồn tại trong hệ thống QL RESORT", true);
                    txtTaiKhoan.Text = "";
                    txtEmail.Text = "";
                }         
            }
            else
                MsgBox("Vui lòng nhập email hoặc tài khoản", true);
        }

    }
}
