using DDL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmQuanLyPhong : Form
    {
        DLL_Phong phong = new DLL_Phong();
        DLL_LoaiPhong loaiphong = new DLL_LoaiPhong();

        DTO_Phong dto_phong;

        private string tenphong, tenloaiphong;
        private string[] Danhsachloaiphong;
        private int gia1, gia2;

        public FrmQuanLyPhong()
        {
            InitializeComponent();
        }

        private void FrmQuanLyPhong_Load(object sender, EventArgs e)
        {
            LoadPhong();
            LoadLoaiPhong();
            LoadComboboxTiemKiem();
            SetValue(true, false);
        }
        private void LoadPhong()
        {
            dataPhong.DataSource = phong.DanhSachPhong();

            cbbTrangThai.Items.Clear();
            cbbTrangThai.Items.Add("Còn trống");
            cbbTrangThai.Items.Add("Đang sử dụng");
            cbbTrangThai.Items.Add("Đang sửa chữa");
            cbbTrangThai.Items.Add("Đang dọn dẹp");
            cbbTrangThai.Items.Add("Đã đặt phòng");
        }
        private void LoadLoaiPhong()
        {
            cbbLoaiPhong.DataSource = loaiphong.DanhSachLoaiPhong();
            cbbLoaiPhong.DisplayMember = "ten_loai";
            cbbLoaiPhong.ValueMember = "id_loaiphong";
        }

        private void LoadComboboxTiemKiem()
        {
            Danhsachloaiphong = phong.DanhsachTenLoaiPhong();
            cbbLocLoaiPhong.Items.Clear();

            foreach (string item in Danhsachloaiphong)
            {
                cbbLocLoaiPhong.Items.Add(item);
            }

            cbbLocTheoGia.Items.Clear();
            cbbLocTheoGia.Items.Add("Từ 1 triệu đến 2 triệu");
            cbbLocTheoGia.Items.Add("Từ 2 triệu đến 5 triệu");
            cbbLocTheoGia.Items.Add("Từ 5 triệu đến 10 triệu");
            cbbLocTheoGia.Items.Add("Từ 10 triệu trở lên");
        }
        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetValue(bool param, bool isLoad)
        {

            txtMaPhong.Text = null;
            txtTenPhong.Text = null;
            txtSoLuong.Text = null;
            btnThem.Enabled = true;
            txtTimKiem.Text= null;
            LoadLoaiPhong();
            LoadPhong();
            LoadComboboxTiemKiem();
            txtMaPhong.Focus();

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

        private void dataPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSua.Enabled = btnXoa.Enabled = true;
                if (dataPhong.Rows.Count > 0)
                {
                    txtMaPhong.Text = dataPhong.CurrentRow.Cells[0].Value.ToString();
                    txtTenPhong.Text = dataPhong.CurrentRow.Cells[1].Value.ToString();
                    txtSoLuong.Text = dataPhong.CurrentRow.Cells[2].Value.ToString();
                    string selectedValue = dataPhong.CurrentRow.Cells[3].Value.ToString();

                    foreach (var item in cbbLoaiPhong.Items)
                    {
                        DataRowView row = item as DataRowView;
                        if (row["ten_loai"].ToString() == selectedValue)
                        {
                            cbbLoaiPhong.SelectedItem = item;
                            break;
                        }
                    }
                    cbbTrangThai.SelectedItem = dataPhong.CurrentRow.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi " + ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string macuoi = phong.LayPhongCuoiCung();
                string mamoi = null;

                string[] parts = macuoi.Split('_');

                if (parts.Length == 2)
                {
                    string makhcu = parts[0];
                    int soThuTuCu = 0;

                    if (int.TryParse(parts[1], out soThuTuCu))
                    {
                        bool maPhongTrung;
                        do
                        {
                            int soThuTuMoi = soThuTuCu + 1;
                            mamoi = makhcu + "_" + soThuTuMoi;

                            maPhongTrung = phong.KiemTraMaPhong(mamoi);

                            if (maPhongTrung)
                            {
                                soThuTuCu++;
                            }
                        } while (maPhongTrung);
                    }
                }

                if (txtTenPhong.Text != "" && txtSoLuong.Text != "")
                {


                    if (macuoi == "Không có phòng cuối cùng")
                    {
                        macuoi = "PH_1";
                        dto_phong = new DTO_Phong
                        (
                            macuoi,
                            txtTenPhong.Text,
                           int.Parse(txtSoLuong.Text),
                           int.Parse(cbbLoaiPhong.SelectedValue.ToString()),
                           cbbTrangThai.SelectedItem.ToString()
                        );
                        if (phong.ThemPhong(dto_phong))
                        {
                            SetValue(false, true);
                            MsgBox("Thêm phòng thành công!", false);
                            LoadPhong();
                            LoadComboboxTiemKiem();
                        }
                        else
                            MsgBox("Không thể thêm phòng  được!", true);
                    }
                    else
                    {
                        dto_phong = new DTO_Phong
                      (
                          mamoi,
                          txtTenPhong.Text,
                         int.Parse(txtSoLuong.Text),
                         int.Parse(cbbLoaiPhong.SelectedValue.ToString()),
                         cbbTrangThai.SelectedItem.ToString()
                      );

                        if (phong.ThemPhong(dto_phong))
                        {
                            SetValue(false, true);
                            MsgBox("Thêm phòng thành công!", false);
                            LoadPhong();
                            LoadComboboxTiemKiem();
                        }
                        else
                        {
                            MsgBox("Đã có lỗi vui lòng đăng nhập lại", true);
                            Application.Restart();
                        }
                    }
                }
                else MsgBox("Thiếu trường thông tin!", true);
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
                if (MessageBox.Show("Bạn có muốn xóa phòng này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string ma = dataPhong.CurrentRow.Cells[0].Value.ToString();
                    if (phong.XoaPhong(ma))
                    {
                        SetValue(true, false);
                        MsgBox("Xóa phòng  thành công" , false);
                        LoadPhong();
                        LoadComboboxTiemKiem();
                    }
                    else
                        MsgBox("Xóa phòng  không thành công", true);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenPhong.Text != "" && txtSoLuong.Text != "")
                {
                    string ma = dataPhong.CurrentRow.Cells[0].Value.ToString();
                    if (ma == null)
                    { ma = txtMaPhong.Text.Trim(); }

                    dto_phong = new DTO_Phong
                       (
                           ma,
                           txtTenPhong.Text,
                          int.Parse(txtSoLuong.Text),
                          int.Parse(cbbLoaiPhong.SelectedValue.ToString()),
                          cbbTrangThai.SelectedItem.ToString()
                       );

                    if (phong.SuaPhong(dto_phong))
                    {
                        SetValue(true, false);

                        MsgBox("Sửa phòng thành công", false);
                        LoadPhong();
                        LoadComboboxTiemKiem();
                    }
                    else
                    {
                        MsgBox("Đã có lỗi vui lòng đăng nhập lại", true);
                        Application.Restart();
                    }
                }
                else MsgBox("Thiếu trường thông tin!", true);
            }
            catch (Exception ex)
            {

                MsgBox("Lỗi " + ex.Message, true);
            }
           
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            tenphong = txtTimKiem.Text.Trim();
            if (tenphong == "")
            {
                FrmQuanLyPhong_Load(sender, e);
                txtTimKiem.Focus();
            }
            else
            {
                DataTable data = phong.TimKiemPhong(tenphong);
                dataPhong.DataSource = data;
            }
        }

        private void picinfoprice_Click(object sender, EventArgs e)
        {
            new FrmThongTinGiaPhong().Show();
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSoLuong.Text, "^[0-9]*$"))
            {
                txtSoLuong.Text = string.Empty;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbLocLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenloaiphong = cbbLocLoaiPhong.SelectedItem.ToString();

            if (tenloaiphong == "")
            {
                FrmQuanLyPhong_Load(sender, e);
            }
            else
            {
                DataTable data = loaiphong.TimKiemLoaiPhong(tenloaiphong);
                dataPhong.DataSource = data;
            }

        }
        private void cbbLocTheoGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLocTheoGia.SelectedIndex == 0)
            {
                gia1 = 1000000;
                gia2 = 2000000;
            }
            else if (cbbLocTheoGia.SelectedIndex == 1)
            {
                gia1 = 2000000;
                gia2 = 5000000;
            }
            else if (cbbLocTheoGia.SelectedIndex == 2)
            {
                gia1 = 5000000;
                gia2 = 10000000;
            }
            else
            {
                gia1 = 9999999;
                gia2 = 9999999;
            }

            if (gia1 == 0 && gia2 == 0)
            {
                FrmQuanLyPhong_Load(sender, e);
            }
            else
            {
                DataTable data = loaiphong.TimKiemTheoGia(gia1, gia2);
                dataPhong.DataSource = data;
            }
        }

    }
}
