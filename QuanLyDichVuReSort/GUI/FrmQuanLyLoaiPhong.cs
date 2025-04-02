using DDL;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmQuanLyLoaiPhong : Form
    {
        DLL_LoaiPhong loaiphong = new DLL_LoaiPhong();
        string tenloaiphong = "";
        public FrmQuanLyLoaiPhong()
        {
            InitializeComponent();
        }

        private void FrmQuanLyLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadLoaiPhong();
            SetValue(false, true);
        }

        private void LoadLoaiPhong()
        {
            dataLoaiPhong.DataSource = loaiphong.DanhSachLoaiPhong();
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Thiết lặt thao tác
        private void SetValue(bool param, bool isLoad)
        {
            txtMaLoai.Text = null;
            txtTenLoai.Text = null;
            txtGia.Text = null;

            btnThem.Enabled = true;
            LoadLoaiPhong();
            txtTenLoai.Focus();

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

        private void dataLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataLoaiPhong.Rows.Count > 0)
            {
                btnSua.Enabled = btnXoa.Enabled = true;
                this.txtMaLoai.Text = dataLoaiPhong.CurrentRow.Cells[0].Value.ToString();
                this.txtTenLoai.Text = dataLoaiPhong.CurrentRow.Cells[1].Value.ToString();
                this.txtGia.Text = dataLoaiPhong.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa loại phòng này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    int ma = int.Parse(dataLoaiPhong.CurrentRow.Cells[0].Value.ToString());
                    if (loaiphong.XoaLoaiPhong(ma))
                    {
                        SetValue(true, false);
                        MsgBox("Xóa loại phòng thành công", false);
                        LoadLoaiPhong();
                    }
                    else
                        MsgBox("Loại phòng đang sử dụng, không thể xóa!", true);
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

                if (string.IsNullOrWhiteSpace(txtGia.Text))
                {
                    MsgBox("Giá không được để trống!", false);
                    return;
                }

                if (!int.TryParse(txtGia.Text, out giadv))
                {
                    MsgBox("Giá phải là một số nguyên!", false);
                    return;
                }

                int maloai = int.Parse(dataLoaiPhong.CurrentRow.Cells[0].Value.ToString());

                if (loaiphong.SuaLoaiPhong(maloai, txtTenLoai.Text, int.Parse(txtGia.Text)))
                {
                    SetValue(true, false);
                    MsgBox("Sửa thành công loại phòng!", false);
                    LoadLoaiPhong();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int macuoi = loaiphong.LayMaThietBiCuoi();

                int mamoi = 0;

                int makhcu = macuoi;
                int soThuTuCu = 0;

                mamoi = makhcu +1;

                int giadv = 0;

                if (string.IsNullOrWhiteSpace(txtGia.Text))
                {
                    MsgBox("Giá không được để trống!", false);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
                {
                    MsgBox("Tên thiết bị không được để trống!", false);
                    return;
                }

                if (!int.TryParse(txtGia.Text, out giadv))
                {
                    MsgBox("Giá phải là một số nguyên!", false);
                    return;
                }

                if (loaiphong.ThemLoaiPhong(mamoi,txtTenLoai.Text, int.Parse(txtGia.Text)))
                {
                    MsgBox("Thêm loại phòng thành công!", false);
                    LoadLoaiPhong();
                    SetValue(false, true);
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(false, true);
        }

        private void txtTimKiemTenLoaiPhong_TextChanged(object sender, EventArgs e)
        {
            tenloaiphong = txtTimKiemTenLoaiPhong.Text;
            if (tenloaiphong == "")
            {
                LoadLoaiPhong();
            }
            else
            {
                DataTable data = loaiphong.TimKiemLoaiPhongTheoTen(tenloaiphong);
                dataLoaiPhong.DataSource = data;
            }
        }
    }
}
