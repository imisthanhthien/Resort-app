using DDL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmDatDichVu : Form
    {
        DLL_DichVu dichvu = new DLL_DichVu();
        DLL_ChiTietSuDungDV ctsddv = new DLL_ChiTietSuDungDV();

        private string madatphong;
        private string str;
        private string[] danhsachDV;
        private string[] strlist;
        private char separator = '|';

        public FrmDatDichVu(string madatphong)
        {
            this.madatphong = madatphong;
            InitializeComponent();
        }

        private void FrmDatDichVu_Load(object sender, EventArgs e)
        {
            LoadDichVu();
            LoadComboBoxDichVu();
            SetValue(true, false);
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadDichVu()
        {
            datachitietdichvu.DataSource = ctsddv.DanhSachChiTietDV(madatphong);
            txtPhongThue.Text = madatphong;
        }

        private void LoadComboBoxDichVu()
        {
            danhsachDV = dichvu.DanhSachMavaTenDV();

            cbbDichVu.Items.Clear();

            foreach (string item in danhsachDV)
            {
                cbbDichVu.Items.Add(item);
            }
        }

        //Thiết lặt thao tác
        private void SetValue(bool param, bool isLoad)
        {
            txtSoLuong.Text = null;
            txtDonGia.Text = null;
            txtThanhTien.Text = null;
            LoadComboBoxDichVu();

            btnThem.Enabled = true;

            if (isLoad) 
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else 
            {
                btnSua.Enabled = !param;
                btnXoa.Enabled = !param;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = cbbDichVu.SelectedItem.ToString();
            strlist = str.Split(separator);
            string madv = strlist[0].Trim();
            txtDonGia.Text = dichvu.LayGiaDichVu(madv).ToString();
            txtSoLuong.Text = "1";
        }

        private void datachitietdichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datachitietdichvu.Rows.Count > 0)
            {
                btnXoa.Enabled = btnSua.Enabled = true;
                string madv = datachitietdichvu.CurrentRow.Cells[0].Value.ToString();
                txtDonGia.Text = dichvu.LayGiaDichVu(madv).ToString();
                txtSoLuong.Text = datachitietdichvu.CurrentRow.Cells[2].Value.ToString();
                txtThanhTien.Text = datachitietdichvu.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoLuong.Text != "")
                {
                    str = cbbDichVu.SelectedItem.ToString();
                    strlist = str.Split(separator);
                    string madv = strlist[0].Trim();

                    int soluong = int.Parse(txtSoLuong.Text);
                    float dongia = float.Parse(txtDonGia.Text);
                    float tongtien = soluong * dongia;

                    DTO_ChiTietSuDungDV dt_dv = new DTO_ChiTietSuDungDV
                              (
                                  txtPhongThue.Text,
                                  madv,
                                  soluong,
                                  tongtien
                              );

                    if (ctsddv.KiemTraDichVuTrung(madv, txtPhongThue.Text))
                    {
                        SetValue(true, false);
                        MsgBox("Dịch vụ đã tồn tại, tăng số lượng lên 1", false);
                        LoadDichVu();
                    }
                    else
                    {
                        if (ctsddv.ThemSDDV(dt_dv))
                        {
                            SetValue(true, false);
                            LoadDichVu();
                            MsgBox("Thêm dịch vụ thành công!", false);
                        }
                        else
                            MsgBox("Không thêm dịch vụ được!", true);
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

                    string madv = datachitietdichvu.CurrentRow.Cells[0].Value.ToString();
                    int soluong = int.Parse(txtSoLuong.Text);

                    DTO_ChiTietSuDungDV dt_dv = new DTO_ChiTietSuDungDV
                              (
                                  madv,
                                  soluong
                              );

                    if (ctsddv.SuaSDDV(dt_dv))
                    {
                        SetValue(true, false);
                        LoadDichVu();
                        MsgBox("Sửa dịch vụ thành công!", false);
                    }
                    else
                        MsgBox("Không thể sửa dịch vụ được!", true);
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
                if (MessageBox.Show("Bạn có muốn xóa dịch vụ này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string madv = datachitietdichvu.CurrentRow.Cells[0].Value.ToString();
                    if (ctsddv.XoaSDDV(madv))
                    {
                        SetValue(true, false);
                        MsgBox("Xóa dịch vụ thành công", false);
                        LoadDichVu();
                    }
                    else
                        MsgBox("Xóa dịch vụ không thành công", true);
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

        //Di chuyển panel
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
