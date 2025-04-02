using DDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmQuanLyThietBi : Form
    {
        DLL_ThietBi thietbi = new DLL_ThietBi();

        string tenthietbi = "";
        public FrmQuanLyThietBi()
        {
            InitializeComponent();
        }

        private void FrmQuanLyThietBi_Load(object sender, EventArgs e)
        {
            LoadThietBi();
            SetValue(false, true);
        }
        private void LoadThietBi()
        {
            dataThietBi.DataSource = thietbi.DanhSachThietBi();
        }

        //Thiết lặt thao tác
        private void SetValue(bool param, bool isLoad)
        {
            txtMaTB.Text = null;
            txtTenTB.Text = null;
            txtGiaTB.Text = null;
          
            btnThem.Enabled = true;
            LoadThietBi();
            txtTenTB.Focus();

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

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(false, true);
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string macuoi = thietbi.LayMaThietBiCuoi();
                string mamoi = null;

                string[] parts = macuoi.Split('_');

                if (parts.Length == 2)
                {
                    string makhcu = parts[0];
                    int soThuTuCu = 0;

                    if (int.TryParse(parts[1], out soThuTuCu))
                    {
                        bool mathietbitrung;
                        do
                        {
                            int soThuTuMoi = soThuTuCu + 1;
                            mamoi = makhcu + "_" + soThuTuMoi;

                            mathietbitrung = thietbi.KiemTraTonTaiMaTB(mamoi);

                            if (mathietbitrung)
                            {
                                soThuTuCu++;
                            }
                        } while (mathietbitrung);
                    }
                }

                int giadv = 0;

                if (string.IsNullOrWhiteSpace(txtGiaTB.Text))
                {
                    MsgBox("Giá không được để trống!", false);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTenTB.Text))
                {
                    MsgBox("Tên thiết bị không được để trống!", false);
                    return;
                }

                if (!int.TryParse(txtGiaTB.Text, out giadv))
                {
                    MsgBox("Giá phải là một số nguyên!", false);
                    return;
                }

                if (macuoi == "Không có thiết bị")
                {
                    macuoi = "DV_1";
                    if (thietbi.ThemThietBi(macuoi, txtTenTB.Text, int.Parse(txtGiaTB.Text)))
                    {
                        MsgBox("Thêm thiết bị thành công!", false);
                        LoadThietBi();
                        SetValue(false, true);
                    }
                    else
                        MsgBox("Không thể thêm thiết bị được!", true);

                }
                else
                {
                    if (thietbi.ThemThietBi(mamoi, txtTenTB.Text, int.Parse(txtGiaTB.Text)))
                    {
                        MsgBox("Thêm thiết bị thành công!", false);
                        LoadThietBi();
                        SetValue(false, true);
                    }
                    else
                    {
                        MsgBox("Đã có lỗi vui lòng đăng nhập lại", true);
                        Application.Restart();
                    }
                }

            }
            catch (Exception ex)
            {

                MsgBox("Lỗi " + ex.Message, true);
            }
        }

        private void dataThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataThietBi.Rows.Count > 0)
            {
                btnSua.Enabled = btnXoa.Enabled = true;
                this.txtMaTB.Text = dataThietBi.CurrentRow.Cells[0].Value.ToString();
                this.txtTenTB.Text = dataThietBi.CurrentRow.Cells[1].Value.ToString();
                this.txtGiaTB.Text = dataThietBi.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa thiết bị này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string ma = dataThietBi.CurrentRow.Cells[0].Value.ToString();
                    if (thietbi.XoaThietBi(ma))
                    {
                        SetValue(true, false);
                        MsgBox("Xóa thiết bị thành công", false);
                        LoadThietBi();
                    }
                    else
                        MsgBox("Thiết bị đang sử dụng, không thể xóa!", true);
                }

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
                int giadv = 0;

                if (string.IsNullOrWhiteSpace(txtGiaTB.Text))
                {
                    MsgBox("Giá không được để trống!", false);
                    return;
                }

                if (!int.TryParse(txtGiaTB.Text, out giadv))
                {
                    MsgBox("Giá phải là một số nguyên!", false);
                    return;
                }

                string matb = dataThietBi.CurrentRow.Cells[0].Value.ToString();

                if (matb == null)
                { matb = txtMaTB.Text.Trim(); }

                if (thietbi.SuaThietBi(txtTenTB.Text, int.Parse(txtGiaTB.Text), matb))
                {
                    SetValue(true, false);
                    MsgBox("Sửa thành công thiết bị!", false);
                    LoadThietBi();
                }
                else
                {
                    MsgBox("Đã có lỗi vui lòng đăng nhập lại", true);
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {

                MsgBox("Lỗi " + ex.Message, true);
            }
        }
      
        private void txtGiaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiemTenTB_TextChanged(object sender, EventArgs e)
        {
            tenthietbi = txtTimKiemTenTB.Text;
            if (tenthietbi == "")
            {
                LoadThietBi();
            }
            else
            {
                DataTable data = thietbi.TimKiemThietBiTheoTen(tenthietbi);
                dataThietBi.DataSource = data;
            }
        }
    }
}
