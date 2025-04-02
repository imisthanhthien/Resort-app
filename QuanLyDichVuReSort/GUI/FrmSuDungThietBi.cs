using DDL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmSuDungThietBi : Form
    {
        DLL_ThietBi thietbi = new DLL_ThietBi();
        DLL_ChiTietSuDungTB sudungthietbi = new DLL_ChiTietSuDungTB();

        private string madatphong;
        private string[] danhsachTB;
        private string str;
        private char separator = '|';
        private string[] strlist;

        public FrmSuDungThietBi(string madatphong)
        {
            this.madatphong = madatphong;
            InitializeComponent();
        }

        private void FrmSuDungThietBi_Load(object sender, EventArgs e)
        {
            LoadThietBi();
            LoadComboBoxThietBi();
            SetValue(true, false);
        }

        //Thiết lặt thao tác
        private void SetValue(bool param, bool isLoad)
        {
            txtSoLuong.Text = null;
            txtDonGia.Text = null;
            txtThanhTien.Text = null;
            LoadComboBoxThietBi();

            btnThem.Enabled = true;

            if (isLoad) // true
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else // false
            {
                btnSua.Enabled = !param;// !param == true
                btnXoa.Enabled = !param;// !param == true
            }
        }

        private void LoadThietBi()
        {
            datachitietthietbi.DataSource = sudungthietbi.DanhSachChiTietTB(madatphong);
            txtPhongThue.Text = madatphong;
        }

        private void LoadComboBoxThietBi()
        {
            danhsachTB = thietbi.DanhSachMavaTenTB();

            cbbThietBi.Items.Clear();

            foreach (string item in danhsachTB)
            {
                cbbThietBi.Items.Add(item);
            }
        }
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      
        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbbThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = cbbThietBi.SelectedItem.ToString();
            strlist = str.Split(separator);
            string matb = strlist[0].Trim();
            txtDonGia.Text = thietbi.LayGiaThietBi(matb).ToString();
            txtSoLuong.Text = "1";
        }

        private void datachitietthietbi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datachitietthietbi.Rows.Count > 0)
            {
                btnXoa.Enabled = btnSua.Enabled = true;
                string madv = datachitietthietbi.CurrentRow.Cells[0].Value.ToString();
                txtDonGia.Text = thietbi.LayGiaThietBi(madv).ToString();
                txtSoLuong.Text = datachitietthietbi.CurrentRow.Cells[2].Value.ToString();
                txtThanhTien.Text = datachitietthietbi.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoLuong.Text != "")
                {
                    str = cbbThietBi.SelectedItem.ToString();
                    strlist = str.Split(separator);
                    string matb = strlist[0].Trim();

                    int soluong = int.Parse(txtSoLuong.Text);
                    float dongia = float.Parse(txtDonGia.Text);
                    float tongtien = soluong * dongia;

                    DTO_ChiTietSuDungTB dt_tb = new DTO_ChiTietSuDungTB
                              (
                                  txtPhongThue.Text,
                                  matb,
                                  soluong,
                                  tongtien
                              );

                    if (sudungthietbi.KiemTraThietBiTrung(matb, txtPhongThue.Text))
                    {
                        SetValue(true, false);
                        MsgBox("Thiết bị đã tồn tại, tăng số lượng lên 1", false);
                        LoadThietBi();
                    }
                    else
                    {
                        if (sudungthietbi.ThemSDTB(dt_tb))
                        {
                            SetValue(true, false);
                            LoadThietBi();
                            MsgBox("Thêm thiết bị thành công!", false);
                        }
                        else
                            MsgBox("Không thêm thiết bị được!", true);
                    }
                }
                else
                    MsgBox("Thiếu trường thông tin!", true);
            }
            catch (Exception ex)
            {
                MsgBox("Lỗi " + ex.Message, true);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoLuong.Text != "")
                {

                    string matb = datachitietthietbi.CurrentRow.Cells[0].Value.ToString();
                    int soluong = int.Parse(txtSoLuong.Text);

                    DTO_ChiTietSuDungTB dt_tb = new DTO_ChiTietSuDungTB
                             (
                                  matb,
                                  soluong
                              );

                    if (sudungthietbi.SuaSDTV(dt_tb))
                    {
                        SetValue(true, false);
                        LoadThietBi();
                        MsgBox("Sửa thiết bị thành công!", false);
                    }
                    else
                        MsgBox("Không thể sửa thiết bị được!", true);
                }
                else
                    MsgBox("Số lượng không được để trống!", true);
            }
            catch (Exception ex)
            {

                MsgBox("Lỗi " + ex.Message, true);
            }
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa thiết bị này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string matb = datachitietthietbi.CurrentRow.Cells[0].Value.ToString();
                    if (sudungthietbi.XoaSDTB(matb))
                    {
                        SetValue(true, false);
                        MessageBox.Show("Xóa thiết bị thành công");
                        LoadThietBi();
                    }
                    else
                        MsgBox("Xóa thiết bị không thành công", true);
                }
            }
            catch (Exception ex)
            {

                MsgBox("Lỗi " + ex.Message, true);
            }
           
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                guna2Panel1.Capture = false;
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
