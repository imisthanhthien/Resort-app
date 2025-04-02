using DDL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmDoiPhong : Form
    {

        DLL_Phong phong_ok = new DLL_Phong();
        DLL_DoiPhong doiphong_ok = new DLL_DoiPhong();
        DLL_DatPhong datphong_ok = new DLL_DatPhong();

        private string madatphong, maphong, makh, tenkh, manv;
        private string[] danhsachPhongTrong, danhsachDoiPhong;
        private string str;
        private char separator = '|';
        private string[] strlist;

        private string strnv;
        private char separatornv = '|';
        private string[] strlistnv;

        public FrmDoiPhong(string madatphong, string maphong, string makh, string tenkh, string manv)
        {
            this.madatphong = madatphong;
            this.maphong = maphong;
            this.makh = makh;
            this.tenkh = tenkh;
            this.manv = manv;
            InitializeComponent();
        }
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string phonghientai = label_tenphong.Text;
                string madatphong = label_madt.Text.Trim();

                str = cbbchonphong.SelectedItem.ToString();
                strlist = str.Split(separator);
                string maphongmoi = strlist[0].Trim();

                strnv = manv;
                strlistnv = strnv.Split(separatornv);
                string manhanvien = strlistnv[0].Trim();


                int songuoio = doiphong_ok.LaySoNguoiO(maphongmoi);
                double giaphong = datphong_ok.LayGiaPhongTheoMaPhong(maphongmoi);
                string strgiaphong = Convert.ToString(giaphong);

                float giaphongnew = float.Parse(strgiaphong);
                DateTime check_in = doiphong_ok.LayTime_CheckIn(madatphong);
                DateTime? check_out = doiphong_ok.LayTime_CheckOut(madatphong);
                DateTime ngaythuchien = DateTime.Now;

                if (MessageBox.Show("Bạn có muốn đổi phòng cho khách hàng " + tenkh + " này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (doiphong_ok.CapNhapKhiDoiPhong(madatphong, manhanvien, maphongmoi, phonghientai, songuoio, giaphongnew, check_in, check_out.Value))
                    {
                        if(txtLyDoiPhong.Text == string.Empty)
                        {
                            if (doiphong_ok.DoiPhong(phonghientai, maphongmoi, manhanvien, ngaythuchien, "Không có lý do"))
                            {
                                this.DialogResult = DialogResult.OK;
                            }                      
                        }
                        else
                        {
                            if (doiphong_ok.DoiPhong(phonghientai, maphongmoi, manhanvien, ngaythuchien, txtLyDoiPhong.Text))
                            {
                                this.DialogResult = DialogResult.OK;
                            }
                        }

                    }
                    
                }
            }
            catch (Exception)
            {
                MsgBox("Không thực hiện được", true);
            }
        }

        private void FrmDoiPhong_Load(object sender, EventArgs e)
        {
            LoadThongTin();
            LoadComboBoxPhongTrong();
            LoadComboBoxDoiPhong();
        }
        private void LoadComboBoxPhongTrong()
        {
            danhsachPhongTrong = phong_ok.DanhSachPhongTrong();

            cbbphongtrong.Items.Clear();

            foreach (string item in danhsachPhongTrong)
            {
                cbbphongtrong.Items.Add(item);
            }
        }
        private void LoadComboBoxDoiPhong()
        {
            danhsachDoiPhong = phong_ok.PhongCanDoi(maphong);

            cbbchonphong.Items.Clear();

            foreach (string item in danhsachDoiPhong)
            {
                cbbchonphong.Items.Add(item);
            }
        }
        private void LoadThongTin()
        {
            label_madt.Text = madatphong.ToString();
            label_tenphong.Text = maphong.ToString();
            label_tenkh.Text = tenkh.ToString();
            label_makh.Text = makh.ToString();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
