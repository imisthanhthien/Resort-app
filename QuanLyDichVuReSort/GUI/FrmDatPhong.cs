using DAL;
using DDL;
using System;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmDatPhong : Form
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();
        DLL_DatPhong datphong = new DLL_DatPhong();
        DLL_Phong phong = new DLL_Phong();
        DLL_LoaiPhong loaiphong = new DLL_LoaiPhong();
        DLL_NhanVien nhanvien = new DLL_NhanVien();
        DLL_KhachHang KhachHang = new DLL_KhachHang();
        DLL_DoiPhong doiphong = new DLL_DoiPhong();
        DLL_DuyetPhongOnline dllduyetphong = new DLL_DuyetPhongOnline();

        private string taikhoan;
        private string tenloaiphong;
        private string[] Danhsachloaiphong, danhsachKH, danhsachNV;
        private string strmaphong;
        private string str, strKH;
        private string strmakh, strtenkh;
        private string[] strlist;
        private double giaphong;
        private int songuoio;
        private int maloaip;
        private char separator = '|';

        public FrmDatPhong(string taikhoan)
        {
            this.taikhoan = taikhoan;
            InitializeComponent();
        }

        private void FrmDatPhong_Load(object sender, EventArgs e)
        {
            Load_datphong();
            LoadCombobox();
            LoadLoaiPhong();
            LoadPhongThue();
            LoadComboboxKH();
            setTimeNgaydi();
            LoadNhanVienDatPhong();
            LoadThongTinCoDatPhong();
            SetValue(true, false);
        }

        private void Load_datphong()
        {
            datadatphong.DataSource = datphong.DanhSachDatPhong();
            datadatphong2.DataSource = datphong.DanhSachDatPhongVer2();
        }

        private void LoadCombobox()
        {
            cbbGioiTinhOK.Items.Clear();
            cbbGioiTinhOK.Items.Add("Nam");
            cbbGioiTinhOK.Items.Add("Nữ");
            cbbGioiTinhOK.Items.Add("Khác");
        }

        private void LoadLoaiPhong()
        {
            Danhsachloaiphong = phong.DanhsachTenLoaiPhong();
            cbbLoaiPhong.Items.Clear();
            foreach (string item in Danhsachloaiphong)
            {
                cbbLoaiPhong.Items.Add(item);
            }
        }
        private void LoadThongTinCoDatPhong()
        {
            var danhsachdatphong = dllduyetphong.DanhSachDatPhongOnline();

            if (danhsachdatphong != null && danhsachdatphong.Rows.Count > 0)
            {
                pic_thongtin.Visible = true;
            }
            else
            {
                pic_thongtin.Visible = false;
            }
        }
        private void LoadComboboxKH()
        {
            danhsachKH = KhachHang.LayMaTenKhachHang();

            cbbKhachHang.Items.Clear();
            foreach (string item in danhsachKH)
            {
                cbbKhachHang.Items.Add(item);
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

        private void setTimeNgaydi()
        {
            DateTime ngayHienTai = DateTime.Now.Date;
            DateTime ngayHienTaiThem1Ngay = ngayHienTai.AddDays(1);

            time_out.Value = ngayHienTaiThem1Ngay.Date;
        }

        //Thiết lặt thao tác
        private void SetValue(bool param, bool isLoad)
        {
            txtSoNguoi.Text = null;
            txtDatCoc.Text = null;
            time_in.Text = null;
            time_out.Text = null;
            txtHoTen.Text = null;
            txtEmail.Text = null;
            txtNgaySinh.Text = null;
            txtTimKiemCMND.Text = null;
            txtCMND.Text = null;
            txtDiaChiKH.Text = null;
            btnDatPhong.Enabled = true;
            txtSoDienThoai.Text = null;

            if (isLoad)
            {
                btnSuaDatPhong.Enabled = false;
                btnXoaDatPhong.Enabled = false;
            }
            else
            {
                btnSuaDatPhong.Enabled = !param;
                btnXoaDatPhong.Enabled = !param;
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

        private void LoadPhongThue()
        {
            cbbphongthue.DataSource = phong.DanhSachPhong();
            cbbphongthue.DisplayMember = "id_phong";
            cbbphongthue.ValueMember = "id_phong";
        }

        private void cbbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenloaiphong = cbbLoaiPhong.SelectedItem.ToString();

            if (tenloaiphong == "")
            {
                FrmDatPhong_Load(sender, e);
            }
            else
            {
                DataTable data = loaiphong.TimKiemLoaiPhong2(tenloaiphong);
                datadatphong.DataSource = data;
            }

            string maloaiphong = datphong.LayMaLoaiPhong(tenloaiphong);
            int ma = int.Parse(maloaiphong);

            cbbphongthue.DataSource = datphong.Locphongtheoloaiphong(ma);
            cbbphongthue.DisplayMember = "id_phong";
            cbbphongthue.ValueMember = "id_phong";
        }

        private void txtSoNguoi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbLoaiPhong.SelectedIndex == -1)
                {
                    if (string.IsNullOrEmpty(txtSoNguoi.Text))
                    {
                        FrmDatPhong_Load(sender, e);
                    }
                    else
                    {
                        songuoio = int.Parse(txtSoNguoi.Text);
                        DataTable data = datphong.Loctheosonguoio(songuoio);
                        datadatphong.DataSource = data;
                    }
                }
                else
                {
                    tenloaiphong = cbbLoaiPhong.SelectedItem.ToString();
                    if (string.IsNullOrEmpty(txtSoNguoi.Text))
                    {
                        datadatphong.DataSource = loaiphong.TimKiemLoaiPhong2(tenloaiphong);
                    }
                    else
                    {
                        songuoio = int.Parse(txtSoNguoi.Text);
                        maloaip = int.Parse(datphong.LayMaLoaiPhong(tenloaiphong));

                        DataTable data = datphong.Loctheosonguoio2(songuoio, maloaip);
                        datadatphong.DataSource = data;
                    }
                }
            }
            catch (Exception) { }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            SetValue(true, false);
            FrmDatPhong_Load(sender, e);
        }

        private void time_in_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayHienTai = DateTime.Now.Date;
            DateTime ngayChon = time_in.Value.Date;

            if (ngayChon < ngayHienTai)
            {
                MessageBox.Show("Ngày đặt phải từ ngày hiện tại trở đi, vui lòng chọn lại!!");
                time_in.ResetText();
            }
        }


        private void time_out_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayHienTai = DateTime.Now;
            DateTime ngayden = time_in.Value.Date;
            DateTime ngayDi = time_out.Value.Date;

            if (ngayDi < ngayden)
            {
                return;
            }

            int songayo = doiphong.TinhSoNgayO(ngayden, ngayDi);
            label_songayo.Text = Convert.ToString(songayo);
            strmaphong = cbbphongthue.SelectedValue.ToString();

            if (strmaphong != "")
            {
                giaphong = datphong.LayGiaPhongTheoMaPhong(strmaphong);
                double tiendatcoc = (songayo * giaphong) * 0.75;
                txtDatCoc.Text = Convert.ToString(tiendatcoc);
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

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                string macuoi = datphong.LayDatPhongCuoiCung();

                string mamoi = null;
                string[] parts = macuoi.Split('_');

                DateTime ngayden = time_in.Value;
                DateTime ngayDi = time_out.Value;

                double tiendatcoc = double.Parse(txtDatCoc.Text);

                danhsachNV = str.Split(separator);
                string manv = danhsachNV[0].Trim();
                string maphong = cbbphongthue.SelectedValue.ToString();

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

                            // Kiểm tra xem mã phòng mới đã tồn tại hay chưa
                            maPhongTrung = datphong.KiemTraDatMaPhong(mamoi);

                            if (maPhongTrung)
                            {
                                soThuTuCu++;
                            }
                        } while (maPhongTrung);
                    }
                }

                if (txtSoDienThoai.Text != "" && txtHoTen.Text != ""
                && txtCMND.Text != "" && txtNgaySinh.Text != "" && txtDiaChiKH.Text != "" && txtSoNguoi.Text != "")
                {
                    if (KiemTraSoDienThoai(txtSoDienThoai.Text))
                    {
                        if (datphong.KiemTraTrangThaiPhong(maphong))
                        {
                            if (KhachHang.KiemTraTonTaiCMND(txtCMND.Text.Trim()) == false)
                            {
                                string macuoikh = KhachHang.LayKhachHangCuoiCung();

                                string mamoikh = null;
                                string[] partskh = macuoikh.Split('_');

                                if (partskh.Length == 2)
                                {
                                    string makhcukh = partskh[0];
                                    int soThuTuCukh = 0;

                                    if (int.TryParse(partskh[1], out soThuTuCukh))
                                    {
                                        bool makhachhangtrungkh;
                                        do
                                        {
                                            int soThuTuMoikh = soThuTuCukh + 1;
                                            mamoikh = makhcukh + "_" + soThuTuMoikh;

                                            makhachhangtrungkh = KhachHang.KiemTraTonTaiMaKhachHang(mamoikh);

                                            if (makhachhangtrungkh)
                                            {
                                                soThuTuCukh++;
                                            }
                                        } while (makhachhangtrungkh);
                                    }
                                }

                                if (txtSoDienThoai.Text != "" && txtDiaChiKH.Text != "" && txtHoTen.Text != ""
                && txtCMND.Text != "" && txtNgaySinh.Text != "")
                                {
                                    if (KhachHang.KiemTraTonTaiSDT(txtSoDienThoai.Text))
                                    {
                                        MsgBox("Số điện thoại đã tồn tại, vui lòng xem lại!", true);
                                        return;
                                    }
                                    if (KhachHang.KiemTraTonTaiCMND(txtCMND.Text))
                                    {
                                        MsgBox("CMND đã tồn tại, vui lòng xem lại!", true);
                                        return;
                                    }
                                    if (KhachHang.KiemTraTonTaiEmail(txtEmail.Text))
                                    {
                                        MsgBox("Email đã tồn tại, vui lòng xem lại!", true);
                                        return;
                                    }

                                    if (IsValidEmail(txtEmail.Text) && KiemTraSoDienThoai(txtSoDienThoai.Text))
                                    {
                                        if (macuoikh == "Không có khách hàng")
                                        {
                                            macuoikh = "KH_1";

                                            if (KhachHang.ThemKhachHang(macuoikh, txtHoTen.Text, DateTime.Parse(txtNgaySinh.Text), txtDiaChiKH.Text, txtSoDienThoai.Text, txtCMND.Text, cbbGioiTinhOK.SelectedItem.ToString(), txtEmail.Text))
                                            {

                                                MsgBox("Thêm khác hàng mới thành công!", false);
                                            }
                                            else
                                                MsgBox("Không thể thêm khách hàng được!", true);
                                        }
                                        else
                                        {
                                            if (KhachHang.ThemKhachHang(mamoikh, txtHoTen.Text, DateTime.Parse(txtNgaySinh.Text), txtDiaChiKH.Text, txtSoDienThoai.Text, txtCMND.Text, cbbGioiTinhOK.SelectedItem.ToString(), txtEmail.Text))
                                            {

                                                MsgBox("Thêm khác hàng mới thành công!", false);
                                            }
                                            else
                                                MsgBox("Không thể thêm khách hàng được!", true);
                                        }

                                    }
                                    else MsgBox("Email hoặc SĐT không đúng định dạng!", true);
                                }
                                else MsgBox("Thiếu trường thông tin!", true);


                            }
                            string makh = datphong.ThongTinKhachHanginCMND(txtCMND.Text);
                            int songayo = doiphong.TinhSoNgayO(ngayden, ngayDi);

                            if (songayo >= 1)
                            {
                                if (macuoi == "Không có gì")
                                {

                                    macuoi = "DT_1";
                                    if (datphong.ThemDatPhong(macuoi, manv, makh, cbbphongthue.SelectedValue.ToString(), ngayden, ngayDi, tiendatcoc, int.Parse(txtSoNguoi.Text)))
                                    {

                                        MsgBox("Đặt phòng thành công!", false);
                                        SetValue(false, true);
                                        Load_datphong();
                                    }
                                    else
                                        MsgBox("Không thể đặt phòng được!", true);
                                }
                                else
                                {
                                    if (datphong.ThemDatPhong(mamoi, manv, makh, cbbphongthue.SelectedValue.ToString(), ngayden, ngayDi, tiendatcoc, int.Parse(txtSoNguoi.Text)))
                                    {

                                        MsgBox("Đặt phòng thành công!", false);
                                        SetValue(false, true);
                                        Load_datphong();
                                    }
                                    else
                                        MsgBox("Không thể đặt phòng được!", true);
                                }
                            }
                            else
                                MsgBox("Số ngày ở tối thiểu 1 ngày!!!", true);

                        }
                        else
                            MsgBox("Phòng không trống hoặc bận, vui lòng xem lại!", true);

                    }
                    else MsgBox("Số điện thoai không đúng định dạng!", true);
                }
                else MsgBox("Thiếu trường thông tin!", true);
            }
            catch (Exception ex)
            {

                MsgBox("Lỗi " + ex.Message, true);
            }
        }

        private void btnXoaDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn phòng này không", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {

                    string ma = datadatphong2.CurrentRow.Cells[0].Value.ToString();
                    string datcoc = datadatphong2.CurrentRow.Cells[7].Value.ToString();
                    string check_in = datadatphong2.CurrentRow.Cells[4].Value.ToString();
                    string check_out = datadatphong2.CurrentRow.Cells[5].Value.ToString();
                    var datphongs = qlrs.datphongs.Where(dt => dt.id_datphong == ma).FirstOrDefault();

                    if (datphongs != null)
                    {
                        string makh = datphongs.id_khachhang;
                        string manv_datphong = datphongs.id_nhanvien;
                        string maphong = datphongs.id_phong;
                        var phongs = qlrs.phongs.Where(p => p.id_phong == maphong).FirstOrDefault();
                        string tenphong = phongs.ten;
                        int loaiphong = phongs.id_loaiphong;
                        DateTime? ngaydatphong = datphongs.ngaydat;
                        giaphong = datphong.LayGiaPhongTheoMaPhong(maphong);
                        string gia = Convert.ToString(giaphong);

                        str = txtNhanVien.Text;
                        danhsachNV = str.Split(separator);
                        string manv = danhsachNV[0].Trim();


                        if (datphong.XoaDatPhong(ma))
                        {
                            if (datphong.ThaoTacDatPhong(makh, manv_datphong, manv, maphong, tenphong, loaiphong, float.Parse(gia), float.Parse(datcoc), ngaydatphong.Value, DateTime.Parse(check_in), DateTime.Parse(check_out), "Hủy đặt", DateTime.Now))
                            {
                                int save = datphong.laymathaotaccuoicung();
                                datphong.SetTrangThaiThucHienDatPHong(save);
                                SetValue(true, false);
                                Load_datphong();
                                MsgBox("Hủy đặt phòng thành công", false);
                            }
                        }
                        else
                            MsgBox("Phòng đặt đang sử dụng hoặc đã thanh toán, không thể xóa!!", true);
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox("Lỗi " + ex.Message, true);
            }

        }

        private void datadatphong2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (datadatphong2.Rows.Count > 0)
            {
                btnSuaDatPhong.Enabled = btnXoaDatPhong.Enabled = true;
                string madt = datadatphong2.CurrentRow.Cells[0].Value.ToString();
                string map = datadatphong2.CurrentRow.Cells[3].Value.ToString();
                string makh = datphong.LayMaKhachHang(madt);
                var khs = qlrs.khachhangs.Where(kh => kh.id_khachhang == makh).FirstOrDefault();
                if (khs != null)
                {
                    txtHoTen.Text = khs.ten_khachhang;

                    string ngaysinhKh = khs.ngay_sinh.ToString("dd/MM/yyyy");

                    txtNgaySinh.Text = ngaysinhKh;
                    txtCMND.Text = khs.cmnd;
                    txtSoDienThoai.Text = khs.sdt;
                    txtDiaChiKH.Text = khs.dia_chi;
                    cbbGioiTinhOK.SelectedItem = khs.gioi_tinh;
                    txtEmail.Text = khs.email_khachhang;
                    strmakh = khs.id_khachhang;
                    strtenkh = khs.ten_khachhang;
                }
            }
        }

        private void btnSuaDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                string madt = datadatphong2.CurrentRow.Cells[0].Value.ToString();
                string map = datadatphong2.CurrentRow.Cells[3].Value.ToString();
                string manv = txtNhanVien.Text;

                if (madt != "" && map != "")
                {
                    var datphongs = qlrs.datphongs.Where(dt => dt.id_datphong == madt).FirstOrDefault();

                    if (datphongs.trang_thai != "Đã thanh toán")
                    {
                        if (new FrmDoiPhong(madt, map, strmakh, strtenkh, manv).ShowDialog() == DialogResult.OK)
                        {
                            MsgBox("Đổi phòng cho khách hàng " + strtenkh + " thành công!", false);
                            SetValue(true, false);
                            Load_datphong();
                        }
                    }
                    else
                        MsgBox("Phòng đặt đã thanh toán không thể đổi!!", true);
                }
            }
            catch (Exception ex)
            {

                MsgBox("Lỗi " + ex.Message, true);
            }

        }

        private void cbbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            strKH = cbbKhachHang.SelectedItem.ToString();
            strlist = strKH.Split(separator);
            string makh = strlist[0].Trim();

            if (!string.IsNullOrEmpty(makh))
            {
                var khachHang = qlrs.khachhangs
                    .Where(kh => kh.id_khachhang == makh)
                    .FirstOrDefault();

                if (khachHang != null)
                {
                    txtHoTen.Text = khachHang.ten_khachhang;
                    string ngaysinhKH = khachHang.ngay_sinh.ToString("dd/MM/yyyy");
                    txtNgaySinh.Text = ngaysinhKH;
                    txtDiaChiKH.Text = khachHang.dia_chi;
                    txtSoDienThoai.Text = khachHang.sdt;
                    txtCMND.Text = khachHang.cmnd;
                    cbbGioiTinhOK.SelectedItem = khachHang.gioi_tinh;
                    txtEmail.Text = khachHang.email_khachhang;
                }
                else
                    MsgBox("Lỗi", true);
            }
            else
                MsgBox("Lỗi", true);
        }

        private void btnDuyetPhong_Click(object sender, EventArgs e)
        {
            if (new FrmDuyetPhong(taikhoan).ShowDialog() == DialogResult.OK)
            {
                Load_datphong();
                LoadThongTinCoDatPhong();
            }

        }

        private void btn_TimKiemTheoCMND_Click(object sender, EventArgs e)
        {
            string cmndInput = txtTimKiemCMND.Text.Trim();
            if (!string.IsNullOrEmpty(cmndInput))
            {
                var khachHang = qlrs.khachhangs.Where(kh => kh.cmnd == cmndInput).FirstOrDefault();
                if (khachHang != null)
                {
                    txtHoTen.Text = khachHang.ten_khachhang;
                    txtNgaySinh.Text = khachHang.ngay_sinh.ToString();
                    txtDiaChiKH.Text = khachHang.dia_chi; txtSoDienThoai.Text = khachHang.sdt;
                    txtCMND.Text = khachHang.cmnd; cbbGioiTinhOK.SelectedItem = khachHang.gioi_tinh;
                    txtEmail.Text = khachHang.email_khachhang;
                }
                else MsgBox("Không tìm thấy thông tin cho số CMND này.", true);
            }
            else MsgBox("Vui lòng nhập số CMND để tìm kiếm.", true);
        }
 
        private void txtSoNguoi_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtTimKiemCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
