using DDL;
using System;
using System.Data;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmQuanLyKhachHang : Form
    {
        DLL_KhachHang khachhang = new DLL_KhachHang();

        private string name;
        public FrmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            SetValue(true, false);
        }
        private void LoadKhachHang()
        {
            dataKhachHang.DataSource = khachhang.DanhSachKhachHang();
            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
            cbbGioiTinh.Items.Add("Khác");
        }

        //Thiết lặt thao tác
        private void SetValue(bool param, bool isLoad)
        {
            txtMa.Text = null;
            txtNgaySinh.Text = null;
            txtDiaChi.Text = null;
            txtCMND.Text = null;
            txtSDT.Text = null;
            txtEmail.Text = null;
            btnThem.Enabled = true;
            txtHoTen.Text = null;
            txtTimKiem.Text = null;
            LoadKhachHang();

            txtHoTen.Focus();

            if (isLoad)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Enabled = !param;// !param == true
                btnXoa.Enabled = !param;// !param == true
            }
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool KiemTraSoDienThoai(string soDienThoai)
        {

            string pattern = @"^\d{10}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(soDienThoai);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            name = txtTimKiem.Text.Trim();
            if (name == "")
            {
                FrmQuanLyKhachHang_Load(sender, e);
                txtTimKiem.Focus();
            }
            else
            {
                DataTable data = khachhang.TimKiemKhachHang(name);
                dataKhachHang.DataSource = data;
            }
        }

        private void dataKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSua.Enabled = btnXoa.Enabled = true;
                if (dataKhachHang.Rows.Count > 0)
                {
                    txtMa.Text = dataKhachHang.CurrentRow.Cells[0].Value.ToString();
                    txtHoTen.Text = dataKhachHang.CurrentRow.Cells[1].Value.ToString();
                    string ngaysinhString = dataKhachHang.CurrentRow.Cells[2].Value.ToString();
                    DateTime ngaysinh = DateTime.Parse(ngaysinhString);
                    txtNgaySinh.Text = ngaysinh.ToString("dd/MM/yyyy");
                    txtDiaChi.Text = dataKhachHang.CurrentRow.Cells[3].Value.ToString();
                    txtSDT.Text = dataKhachHang.CurrentRow.Cells[4].Value.ToString();
                    txtCMND.Text = dataKhachHang.CurrentRow.Cells[5].Value.ToString();
                    cbbGioiTinh.SelectedItem = dataKhachHang.CurrentRow.Cells[6].Value.ToString();
                    txtEmail.Text = dataKhachHang.CurrentRow.Cells[7].Value.ToString();
                }
            }
            catch (Exception) { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
        }

        static bool KiemTraCMNDHopLe(string cmndNumber)
        {

            if (cmndNumber.Length == 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // kiểm tra Email có giá trị
        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string inputDate = txtNgaySinh.Text;
                DateTime parsedDate;

                string macuoi = khachhang.LayKhachHangCuoiCung();

                string mamoi = null;
                string[] parts = macuoi.Split('_');

                if (parts.Length == 2)
                {
                    string makhcu = parts[0];
                    int soThuTuCu = 0;

                    if (int.TryParse(parts[1], out soThuTuCu))
                    {
                        bool makhachhangtrung;
                        do
                        {
                            int soThuTuMoi = soThuTuCu + 1;
                            mamoi = makhcu + "_" + soThuTuMoi;

                            makhachhangtrung = khachhang.KiemTraTonTaiMaKhachHang(mamoi);

                            if (makhachhangtrung)
                            {
                                soThuTuCu++;
                            }
                        } while (makhachhangtrung);
                    }
                }


                if (txtSDT.Text != "" && txtDiaChi.Text != "" && txtHoTen.Text != ""
                && txtCMND.Text != "" && txtNgaySinh.Text != "" && txtEmail.Text != "")
                {
                    if (khachhang.KiemTraTonTaiSDT(txtSDT.Text))
                    {
                        MsgBox("Số điện thoại đã tồn tại, vui lòng xem lại!", true);
                        return;
                    }
                    if (khachhang.KiemTraTonTaiCMND(txtCMND.Text))
                    {
                        MsgBox("CMND đã tồn tại, vui lòng xem lại!", true);
                        return;
                    }
                    if (khachhang.KiemTraTonTaiEmail(txtEmail.Text))
                    {
                        MsgBox("Email đã tồn tại, vui lòng xem lại!", true);
                        return;
                    }
                    if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                    {
                        MsgBox("Ngày sinh không hợp lệ, vui lòng xem lại!", true);
                        return;
                    }

                    if (DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate))
                    {
                        TimeSpan ageDifference = DateTime.Today - parsedDate;
                        int ageInYears = (int)(ageDifference.Days / 365.25); 

                        if (ageInYears < 18)
                        {
                            MsgBox("Tuổi phải lớn hơn hoặc bằng 18 tuổi.", true);
                            return;
                        }
                    }

                    if (IsValidEmail(txtEmail.Text) && KiemTraSoDienThoai(txtSDT.Text) && KiemTraCMNDHopLe(txtCMND.Text))
                    {
                        if (macuoi == "Không có khách hàng")
                        {
                            macuoi = "KH_1";
                            if (khachhang.ThemKhachHang(macuoi, txtHoTen.Text, DateTime.Parse(txtNgaySinh.Text), txtDiaChi.Text, txtSDT.Text, txtCMND.Text, cbbGioiTinh.SelectedItem.ToString(), txtEmail.Text))
                            {
                                SetValue(false, true);
                                MsgBox("Thêm khác hàng thành công!", false);
                                LoadKhachHang();
                            }
                            else
                                MsgBox("Không thể thêm khách hàng được!", true);
                        }
                        else
                        {
                            if (khachhang.ThemKhachHang(mamoi, txtHoTen.Text, DateTime.Parse(txtNgaySinh.Text), txtDiaChi.Text, txtSDT.Text, txtCMND.Text, cbbGioiTinh.SelectedItem.ToString(), txtEmail.Text))
                            {
                                SetValue(false, true);
                                MsgBox("Thêm khác hàng thành công!", false);
                                LoadKhachHang();
                            }
                            else
                                MsgBox("Không thể thêm khách hàng được!", true);
                        }

                    }
                    else MsgBox("Email hoặc SĐT và CMND không đúng định dạng", true);
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
                if (MessageBox.Show("Bạn có muốn xóa khách hàng này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string ma = dataKhachHang.CurrentRow.Cells[0].Value.ToString();
                    if (khachhang.XoaKhachHang(ma))
                    {
                        SetValue(true, false);
                        MsgBox("Xóa khách hàng thành công", false);
                        LoadKhachHang();
                    }
                    else
                        MsgBox("Xóa khách hàng không thành công", true);
                }
            }
            catch (Exception)
            {
                MsgBox("Không thể xóa khách hàng này vì đã sử dụng dịch vụ Resort", true);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSDT.Text != "" && txtDiaChi.Text != "" && txtHoTen.Text != ""
            && txtCMND.Text != "" && txtNgaySinh.Text != "" && txtEmail.Text != "")
                {

                    string manv = dataKhachHang.CurrentRow.Cells[0].Value.ToString();

                    if (manv == null)
                    { manv = txtMa.Text.Trim(); }

                    if (IsValidEmail(txtEmail.Text) && KiemTraSoDienThoai(txtSDT.Text) && KiemTraCMNDHopLe(txtCMND.Text))
                    {
                        if (khachhang.SuaKhachHang(manv, txtHoTen.Text, DateTime.Parse(txtNgaySinh.Text), txtDiaChi.Text, txtSDT.Text, txtCMND.Text, cbbGioiTinh.SelectedItem.ToString(), txtEmail.Text))
                        {
                            SetValue(true, false);
                            MsgBox("Sửa khách hàng thành công", false);
                            LoadKhachHang();
                        }
                        else
                            MsgBox("Sửa khách hàng không thành công!", true);
                    }
                    else MsgBox("Email hoặc SĐT và CMND không đúng định dạng", true);
                }
                else MsgBox("Thiếu trường thông tin!", true);
            }
            catch (Exception ex)
            {

                MsgBox("Lỗi " + ex.Message, true);
            }
            
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNgaySinh_TextChanged(object sender, EventArgs e)
        {
         
            if (txtNgaySinh.TextLength == 2 || txtNgaySinh.TextLength == 5)
            {
                txtNgaySinh.Text += "/";
                txtNgaySinh.SelectionStart = txtNgaySinh.Text.Length;
            }
        }
    }
}
