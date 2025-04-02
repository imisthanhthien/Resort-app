using System;
using System.Windows.Forms;
using DDL;

namespace GUI
{
    public partial class FrmDuyetPhong : Form
    {
        DLL_DuyetPhongOnline dllduyetphong = new DLL_DuyetPhongOnline();
        DLL_NhanVien nhanvien = new DLL_NhanVien();

        private string[] danhsachNV;
        private string str;
        private string taikhoan;
        private char separator = '|';

        public FrmDuyetPhong(string taikhoan)
        {
            this.taikhoan = taikhoan;
            InitializeComponent();
        }

        private void FrmDuyetPhong_Load(object sender, EventArgs e)
        {
            loadThongTinDatPhong();
            LoadNhanVienDatPhong();
            SetValue(true, false);
        }

        private void loadThongTinDatPhong()
        {
            var danhsachdatphong = dllduyetphong.DanhSachDatPhongOnline();
            dtDuyetPhong.DataSource = danhsachdatphong;
        }

        //Thiết lặt thao tác
        private void SetValue(bool param, bool isLoad)
        {
            dtDuyetPhong.ClearSelection();
            if (isLoad)
            {
                btn_duyetphong.Enabled = false;
                btnHuyPhong.Enabled = false;
            }
            else
            {
                btn_duyetphong.Enabled = !param;
                btnHuyPhong.Enabled = !param;
            }
        }

        private void LoadNhanVienDatPhong()
        {
            str = nhanvien.LayIDNameNhanVien(taikhoan);
            if (str != "")
            {
                txtNhanVien.Text = str;
            }
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_duyetphong_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn duyệt đơn đặt phòng này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string id_datphong = dtDuyetPhong.CurrentRow.Cells[0].Value.ToString();
                    string id_phong = dtDuyetPhong.CurrentRow.Cells[1].Value.ToString();

                    danhsachNV = str.Split(separator);
                    string manv = danhsachNV[0].Trim();
                    if (dllduyetphong.DuyetDatPhongOnline(id_datphong, manv))
                    {
                        if (dllduyetphong.CapNhapTrangThaiPhongOnline(id_phong))
                        {
                            MsgBox("Duyệt phòng thành công!", false);
                            loadThongTinDatPhong();
                            SetValue(true, false);
                        }
                    }
                }    

            }
            catch (Exception ex)
            {
                MsgBox("Lỗi " + ex.Message, true);
            }
        }

        private void btnHuyPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn hủy đơn đặt phòng này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string id_datphong = dtDuyetPhong.CurrentRow.Cells[0].Value.ToString();
                    if (dllduyetphong.HuyDatPhongOnline(id_datphong))
                    {
                        MsgBox("Hủy đặt phòng thành công!",false);
                        loadThongTinDatPhong();
                        SetValue(true, false);
                    }
                }    
            }
            catch (Exception ex)
            {
                MsgBox("Lỗi " + ex.Message, true);
            }     
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void dtDuyetPhong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dtDuyetPhong.Rows.Count > 0)
            {
                btn_duyetphong.Enabled = btnHuyPhong.Enabled = true;
            }
        }
    }
}
