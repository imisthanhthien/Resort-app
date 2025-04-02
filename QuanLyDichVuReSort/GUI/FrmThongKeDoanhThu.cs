using DAL;
using DDL;
using DevExpress.XtraReports.UI;
using GUI.Report;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmThongKeDoanhThu : Form
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();

        DLL_HoaDon hoadon = new DLL_HoaDon();
        DLL_NhanVien nhanviendll = new DLL_NhanVien();
        DLL_KhachHang khachhangdll = new DLL_KhachHang();
        DLL_ChiTietSuDungDV chitietsudungDV = new DLL_ChiTietSuDungDV();
        DLL_ChiTietSuDungTB chitietsudungTB = new DLL_ChiTietSuDungTB();
        DLL_DatPhong datphongdll = new DLL_DatPhong();

        private string[] strlistkhachhang, strlistphong, strlistthongke;
        private string taikhoan;
        private string strkh, strphong, strthongke;
        private int currentYear = DateTime.Now.Year;
        private int quy = 0, nam = 0, thang = 0;
        private double TongDoanhThu = 0;
        private char separator = '|';

        public FrmThongKeDoanhThu(string taikhoan)
        {
            this.taikhoan = taikhoan;
            InitializeComponent();
        }

        private void FrmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            LoadTopResort();
            LoadCombobox();
            SetTimeChonNgay();
            BarTongQuat(chtImportProduct);
            LoadTongDoanhThu();
            LoadHoaDonThanhToan();
            LoadHoaDonDichVu();
            LoadHoaDonThietBi();
            LoadLichSuThaoTac();
            btnXuatDT.Enabled = false;
            btnXuatTB.Enabled = false;
            btnXuatDV.Enabled = false;
        }

        private void LoadHoaDonThietBi()
        {
            LoadComBoBox(cbbThongKeThietBi, cbbThietBiThang, cbbThietBiQuy, cbbThietBiNam);
            LoadComboboxTimKiemHoaDonThietBi();
            dataHoaDonThietBi.DataSource = chitietsudungTB.DanhSachThietBiSuDung();
        }

        private void SetTimeChonNgay()
        {

            time_in.Value = DateTime.Now;
            time_out.Value = DateTime.Now;
            time_dichvu.Value = DateTime.Now;
            time_thietbi.Value = DateTime.Now;
            time_ngay.Value = DateTime.Now;
        }

        private void LoadHoaDonDichVu()
        {
            LoadComBoBox(cbbThongKeDichVu, cbbDichThuTheoThang, cbbDichVuTheoQuy, cbbDichVuTheoNam);
            LoadComboboxTimKiemDichVuDatPhong();
            dataHoaDonDichVu.DataSource = chitietsudungDV.DanhSachDichVuSuDung();
        }

        private void LoadHoaDonThanhToan()
        {
            LoadComBoBox(cbbThongKeHoaDon, cbbThongKeTheoThang, cbbThongKeTheoQuy, cbbThongKeTheoNam);
            LoadComboboxTimKiemHoaDonDatPhong();
            datahoadonthanhtoan.DataSource = hoadon.DanhSachHoaDonThanToan();
        }
        private void LoadLichSuThaoTac()
        {
            var doiphongs = from dp in qlrs.doiphongs
                            select dp;
            var thaotacs = qlrs.ThaoTacDatPhongs.ToList();

            datadoiphong.DataSource = doiphongs;
            datathaotac.DataSource = thaotacs;
        }

        private void LoadComboboxTimKiemHoaDonDatPhong()
        {
            DataTable danhSachNhanVien = nhanviendll.DanhSachNhanVienTheoIDName();
            DataTable danhSachNhanVien1 = nhanviendll.DanhSachNhanVienTheoIDName();
            DataTable danhSachKhachHang = khachhangdll.DanhSachKhachHangS();

            DataRow rowChonDuLieuNhanVien = danhSachNhanVien.NewRow();
            rowChonDuLieuNhanVien["ten_nhanvien"] = "Chọn nhân viên đặt phòng";
            rowChonDuLieuNhanVien["id_nhanvien"] = -1;

            DataRow rowChonDuLieuNhanVien1 = danhSachNhanVien1.NewRow();
            rowChonDuLieuNhanVien1["ten_nhanvien"] = "Chọn nhân viên thanh toán";
            rowChonDuLieuNhanVien1["id_nhanvien"] = -1;

            DataRow rowChonDuLieuKhachHang = danhSachKhachHang.NewRow();
            rowChonDuLieuKhachHang["ten_khachhang"] = "Chọn khách hàng đặt phòng";
            rowChonDuLieuKhachHang["id_khachhang"] = -1;

            danhSachNhanVien.Rows.InsertAt(rowChonDuLieuNhanVien, 0);
            danhSachNhanVien1.Rows.InsertAt(rowChonDuLieuNhanVien1, 0);
            danhSachKhachHang.Rows.InsertAt(rowChonDuLieuKhachHang, 0);

            cbbnhanviendatphong.DataSource = danhSachNhanVien;
            cbbnhanvienthanhtoan.DataSource = danhSachNhanVien1;
            cbbkhachhangdatphong.DataSource = danhSachKhachHang;

            cbbnhanviendatphong.DisplayMember = "ten_nhanvien";
            cbbnhanviendatphong.ValueMember = "id_nhanvien";

            cbbnhanvienthanhtoan.DisplayMember = "ten_nhanvien";
            cbbnhanvienthanhtoan.ValueMember = "id_nhanvien";

            cbbkhachhangdatphong.DisplayMember = "ten_khachhang";
            cbbkhachhangdatphong.ValueMember = "id_khachhang";
        }

        private void LoadComboboxTimKiemDichVuDatPhong()
        {
            DataTable danhsachdichvu = chitietsudungDV.DanhSachDichVuTheoIDName();
            DataTable danhsachphong = chitietsudungDV.DanhSachPhongTheoIDName();


            DataRow rowChonDuLieuDichVu = danhsachdichvu.NewRow();
            rowChonDuLieuDichVu["ten_dichvu"] = "Chọn loại dịch vụ";
            rowChonDuLieuDichVu["id_dichvu"] = -1;


            DataRow rowChonDuLieuPhong = danhsachphong.NewRow();
            rowChonDuLieuPhong["ten"] = "Chọn loại phòng";
            rowChonDuLieuPhong["ma"] = -1;

            danhsachdichvu.Rows.InsertAt(rowChonDuLieuDichVu, 0);
            danhsachphong.Rows.InsertAt(rowChonDuLieuPhong, 0);

            cbbThongTinDichVu.DataSource = danhsachdichvu;
            CbbThongTinPhong.DataSource = danhsachphong;

            cbbThongTinDichVu.DisplayMember = "ten_dichvu";
            cbbThongTinDichVu.ValueMember = "id_dichvu";

            CbbThongTinPhong.DisplayMember = "ten";
            CbbThongTinPhong.ValueMember = "ma";
        }

        private void LoadComboboxTimKiemHoaDonThietBi()
        {
            DataTable danhsachthietbi = chitietsudungTB.DanhSachThietBiTheoIDName();
            DataTable danhsachphong = chitietsudungDV.DanhSachPhongTheoIDName();


            DataRow rowChonDuLieuThietBi = danhsachthietbi.NewRow();
            rowChonDuLieuThietBi["ten_thietbi"] = "Chọn loại thiết bị";
            rowChonDuLieuThietBi["id_thietbi"] = -1;


            DataRow rowChonDuLieuPhong = danhsachphong.NewRow();
            rowChonDuLieuPhong["ten"] = "Chọn loại phòng";
            rowChonDuLieuPhong["ma"] = -1;

            danhsachthietbi.Rows.InsertAt(rowChonDuLieuThietBi, 0);
            danhsachphong.Rows.InsertAt(rowChonDuLieuPhong, 0);

            cbbThongTinThietBi.DataSource = danhsachthietbi;
            cbbThongTinPhongSDTB.DataSource = danhsachphong;

            cbbThongTinThietBi.DisplayMember = "ten_thietbi";
            cbbThongTinThietBi.ValueMember = "id_thietbi";

            cbbThongTinPhongSDTB.DisplayMember = "ten";
            cbbThongTinPhongSDTB.ValueMember = "ma";
        }

        //Load combobox Thao tac
        private void LoadComBoBox(Guna2ComboBox cbbTong, Guna2ComboBox cbbThang, Guna2ComboBox cbbQuy, Guna2ComboBox cbbNam)
        {

            cbbTong.Items.Clear();
            cbbThang.Items.Clear();
            cbbQuy.Items.Clear();
            cbbNam.Items.Clear();

            cbbTong.Items.Add("Chọn dữ liệu");
            cbbTong.Items.Add("Theo ngày");
            cbbTong.Items.Add("Theo Tháng");
            cbbTong.Items.Add("Theo quý");
            cbbTong.Items.Add("Theo năm");

            cbbTong.SelectedIndex = 0;

            for (int i = 1; i <= 12; i++)
            { cbbThang.Items.Add(i); }
            for (int i = 1; i <= 4; i++)
            { cbbQuy.Items.Add(i); }
            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year; i++)
            { cbbNam.Items.Add(i); }
        }


        private void cbbTheoThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            thang = int.Parse(cbbTheoThang.SelectedItem.ToString());
            btnInBaoCao.Enabled = true;
            if (thang != 0)
            {
                TongDoanhThu = hoadon.DoanhThuTheoThang(thang, currentYear);
                if (TongDoanhThu != 0)
                {

                    label_tongdoanhthu.Text = TongDoanhThu.ToString("C") + " (Tháng " + thang + ")";
                    BarThang(chtImportProduct, thang);
                }
                else
                {
                    BarThang(chtImportProduct, thang);
                    label_tongdoanhthu.Text = "0 VND" + " (Tháng " + thang + ")";

                }
            }
        }

        //Load top nổi bật
        private void LoadTopResort()
        {
            try
            {
                strkh = hoadon.Top1KhachHang();
                strlistkhachhang = strkh.Split(separator);

                strthongke = hoadon.TinhTongDoanhThuSoVoiThangTruoc();
                strlistthongke = strthongke.Split(separator);

                strphong = hoadon.PhongCheckInNhieuNhat();
                strlistphong = strphong.Split(separator);

                if (strkh != null || strthongke != null || strphong != null)
                {
                    label_maKH.Text = strlistkhachhang[0];
                    label_tenKH.Text = strlistkhachhang[1];

                    label_maphong.Text = strlistphong[0];
                    label_tenphong.Text = strlistphong[1];

                    double danhthuthangnay = double.Parse(strlistthongke[0]);
                    double danhthuthangtruoc = double.Parse(strlistthongke[1]);

                    double danhthugiua2thang = danhthuthangnay - danhthuthangtruoc;

                    label_doanhthuthangnay.Text = danhthugiua2thang.ToString("N");

                    if (danhthuthangnay > danhthuthangtruoc)
                    {
                        tang.Visible = true;
                    }
                    else
                        giam.Visible = true;

                }
                else
                {
                    label_maKH.Text = "Chưa cập nhập";
                    label_tenKH.Text = "Chưa cập nhập";
                }
            }
            catch (Exception) { }
        }

        private void cbbTheoNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            nam = int.Parse(cbbTheoNam.SelectedItem.ToString());
            btnInBaoCao.Enabled = true;
            if (nam != 0)
            {

                TongDoanhThu = hoadon.DanhThuTheoNam(nam);
                if (TongDoanhThu != 0)
                {
                    Bar(chtImportProduct);
                    label_tongdoanhthu.Text = TongDoanhThu.ToString("C") + " (năm " + nam + ")";
                }
                else
                {
                    Bar(chtImportProduct);
                    label_tongdoanhthu.Text = "0 VND" + " (năm " + nam + ")";
                }

            }
        }

        private void time_out_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngaybatdau = time_in.Value;
            DateTime ngayketthuc = time_out.Value;
            try
            {
                if (ngayketthuc < ngaybatdau)
                {
                    MessageBox.Show("Ngày lọc âm, vui lòng chọn lại");
                    time_in.ResetText();
                    time_out.ResetText();
                    return;
                }

                TongDoanhThu = hoadon.LocDoanhThuTheoNgayTuChon(ngaybatdau, ngayketthuc);
                if (TongDoanhThu != 0)
                {
                    BarTheoNgay(chtImportProduct, ngaybatdau, ngayketthuc);
                    label_tongdoanhthu.Text = TongDoanhThu.ToString("C");
                }
                else
                {
                    BarTheoNgay(chtImportProduct, ngaybatdau, ngayketthuc);
                    label_tongdoanhthu.Text = "0 VND";
                }

            }
            catch (Exception) { }
        }

        private void cbbTheoQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            quy = int.Parse(cbbTheoQuy.SelectedItem.ToString());
            btnInBaoCao.Enabled = true;
            if (quy != 0)
            {
                TongDoanhThu = hoadon.DoanhThuTheoQuy(quy, currentYear);
                if (TongDoanhThu != 0)
                {
                    label_tongdoanhthu.Text = TongDoanhThu.ToString("C") + " (quý " + quy + ")"; ;
                    Bar(chtImportProduct);
                }
                else
                {
                    Bar(chtImportProduct);
                    label_tongdoanhthu.Text = "0 VND" + " (quý " + quy + ")"; ;
                }

            }
        }

        //Làm mới
        private void btnlammoi_Click(object sender, EventArgs e)
        {
            time_in.ResetText();
            time_out.ResetText();
            btnInBaoCao.Enabled = false;
            time_in.Value = DateTime.Now;
            time_out.Value = DateTime.Now;
            BarTongQuat(chtImportProduct);
            LoadTopResort();
            LoadCombobox();
            LoadTongDoanhThu();
        }

        //Tổng danh thu resort
        private void LoadTongDoanhThu()
        {
            TongDoanhThu = double.Parse(hoadon.TinhTongDoanhThu());

            label_tongdoanhthu.Text = TongDoanhThu.ToString("C");
        }

        private void cbbThongKeHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string textchon = cbbThongKeHoaDon.SelectedItem.ToString().Trim();

                switch (textchon)
                {
                    case "Theo ngày":
                        pannel_theongay.Visible = true;
                        pannel_theothang.Visible = false;
                        pannel_theoquy.Visible = false;
                        pannel_theonam.Visible = false;
                        break;
                    case "Theo Tháng":
                        pannel_theongay.Visible = false;
                        pannel_theothang.Visible = true;
                        pannel_theoquy.Visible = false;
                        pannel_theonam.Visible = false;
                        break;
                    case "Theo quý":
                        pannel_theongay.Visible = false;
                        pannel_theothang.Visible = false;
                        pannel_theoquy.Visible = true;
                        pannel_theonam.Visible = false;
                        break;
                    case "Theo năm":
                        pannel_theongay.Visible = false;
                        pannel_theothang.Visible = false;
                        pannel_theoquy.Visible = false;
                        pannel_theonam.Visible = true;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception) { }
        }

        private void time_ngay_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngaychon = time_ngay.Value;
            DataTable danhsach = hoadon.DanhSachHoaDonThanToanTheoNgay(ngaychon);
            btnXuatDT.Enabled = true;
            try
            {

                int songay = int.Parse(hoadon.SoDonDatPhongTrongNgayTheoHoaDon(ngaychon));
                double tongtienngay = double.Parse(hoadon.TongTienDatPhongTrongNgayTheoHoaDon(ngaychon));
                ThongKeTheoNgay(ngaychon, songay, tongtienngay, soluong_theongay, tongtien_theongay, datahoadonthanhtoan, danhsach);
            }
            catch (Exception)
            {
                soluong_theongay.Text = "Không có dữ liệu";
                tongtien_theongay.Text = "Không có dữ liệu";
                DanhSachData(datahoadonthanhtoan, ngaychon, danhsach);
            }
        }

        private void cbbThongKeTheoThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thangchon = int.Parse(cbbThongKeTheoThang.SelectedItem.ToString().Trim());
            DataTable danhsach = hoadon.DanhSachHoaDonThanToanTheoThang(thangchon);
            btnXuatDT.Enabled = true;
            try
            {
                int sothang = int.Parse(hoadon.SoDonDatPhongTrongThangTheoHoaDon(thangchon));
                double tongtienthang = double.Parse(hoadon.TongTienDatPhongTrongThangTheoHoaDon(thangchon));
                ThongKeMain(thangchon, sothang, tongtienthang, soluong_trongthang, tongtien_theothang, datahoadonthanhtoan, danhsach);

            }
            catch (Exception)
            {
                soluong_trongthang.Text = "Không có dữ liệu";
                tongtien_theothang.Text = "Không có dữ liệu";
                DanhSachData(datahoadonthanhtoan, thangchon, danhsach);
            }
        }

        private void cbbThongKeTheoQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int quychon = int.Parse(cbbThongKeTheoQuy.SelectedItem.ToString().Trim());
            DataTable danhsach = hoadon.DanhSachHoaDonThanToanTheoQuy(quychon);
            btnXuatDT.Enabled = true;
            try
            {
                int sotquy = int.Parse(hoadon.SoDonDatPhongTrongQuyTheoHoaDon(quychon));
                double tongtienquy = double.Parse(hoadon.TongTienDatPhongTrongQuyTheoHoaDon(quychon));
                ThongKeMain(quychon, sotquy, tongtienquy, soluong_theoquy, tongtien_theoquy, datahoadonthanhtoan, danhsach);
            }
            catch (Exception)
            {
                soluong_theoquy.Text = "Không có dữ liệu";
                tongtien_theoquy.Text = "Không có dữ liệu";
                DanhSachData(datahoadonthanhtoan, quychon, danhsach);
            }
        }

        private void cbbThongKeTheoNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int namchon = int.Parse(cbbThongKeTheoNam.SelectedItem.ToString().Trim());
            DataTable danhsach = hoadon.DanhSachHoaDonThanToanTheoNam(namchon);
            btnXuatDT.Enabled = true;
            try
            {
                int sonam = int.Parse(hoadon.SoDonDatPhongTrongNamTheoHoaDon(namchon));
                double tongtiennam = double.Parse(hoadon.TongTienDatPhongTrongNamTheoHoaDon(namchon));
                ThongKeMain(namchon, sonam, tongtiennam, soluong_theonam, tongtien_theonam, datahoadonthanhtoan, danhsach);
            }
            catch (Exception)
            {
                soluong_theonam.Text = "Không có dữ liệu";
                tongtien_theonam.Text = "Không có dữ liệu";
                DanhSachData(datahoadonthanhtoan, namchon, danhsach);
            }


        }


        private void cbbnhanviendatphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_nhanvien = cbbnhanviendatphong.SelectedValue.ToString();
            if (id_nhanvien != "-1")
            {
                datahoadonthanhtoan.DataSource = hoadon.DanhSachNhanVienDatPhong(id_nhanvien);
            }
            else
                datahoadonthanhtoan.DataSource = hoadon.DanhSachHoaDonThanToan();
        }

        private void cbbnhanvienthanhtoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_nhanvien = cbbnhanvienthanhtoan.SelectedValue.ToString();
            if (id_nhanvien != "-1")
            {
                datahoadonthanhtoan.DataSource = hoadon.DanhSachNhanVienThanhToan(id_nhanvien);
            }
            else
                datahoadonthanhtoan.DataSource = hoadon.DanhSachHoaDonThanToan();

        }

        private void cbbkhachhangdatphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_khachhang = cbbkhachhangdatphong.SelectedValue.ToString();
            if (id_khachhang != "-1")
            {
                datahoadonthanhtoan.DataSource = hoadon.DanhSachKhachHangDatPhong(id_khachhang);
            }
            else
                datahoadonthanhtoan.DataSource = hoadon.DanhSachHoaDonThanToan();

        }

        private void cbbThongKeHoaDon_MouseClick(object sender, MouseEventArgs e)
        {
            cbbThongKeHoaDon.Items.Remove("Chọn dữ liệu");
        }

        private void cbbThongKeDichVu_MouseClick(object sender, MouseEventArgs e)
        {
            cbbThongKeDichVu.Items.Remove("Chọn dữ liệu");
        }

        private void cbbThongKeThietBi_MouseClick(object sender, MouseEventArgs e)
        {
            cbbThongKeThietBi.Items.Remove("Chọn dữ liệu");
        }

        private void cbbThongKeDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string textchon = cbbThongKeDichVu.SelectedItem.ToString().Trim();

                switch (textchon)
                {
                    case "Theo ngày":
                        pannel_dichvutheongay.Visible = true;
                        pannel_dichvutheothang.Visible = false;
                        pannel_dichvutheoquy.Visible = false;
                        pannel_dichvutheonam.Visible = false;
                        break;
                    case "Theo Tháng":
                        pannel_dichvutheongay.Visible = false;
                        pannel_dichvutheothang.Visible = true;
                        pannel_dichvutheoquy.Visible = false;
                        pannel_dichvutheonam.Visible = false;
                        break;
                    case "Theo quý":
                        pannel_dichvutheongay.Visible = false;
                        pannel_dichvutheothang.Visible = false;
                        pannel_dichvutheoquy.Visible = true;
                        pannel_dichvutheonam.Visible = false;
                        break;
                    case "Theo năm":
                        pannel_dichvutheongay.Visible = false;
                        pannel_dichvutheothang.Visible = false;
                        pannel_dichvutheoquy.Visible = false;
                        pannel_dichvutheonam.Visible = true;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception) { }
        }

        private void cbbThongKeThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string textchon = cbbThongKeThietBi.SelectedItem.ToString().Trim();

                switch (textchon)
                {
                    case "Theo ngày":
                        pannel_thietbi_ngay.Visible = true;
                        pannel_thietbi_thang.Visible = false;
                        pannel_thietbi_quy.Visible = false;
                        pannel_thietbi_nam.Visible = false;
                        break;
                    case "Theo Tháng":
                        pannel_thietbi_ngay.Visible = false;
                        pannel_thietbi_thang.Visible = true;
                        pannel_thietbi_quy.Visible = false;
                        pannel_thietbi_nam.Visible = false;
                        break;
                    case "Theo quý":
                        pannel_thietbi_ngay.Visible = false;
                        pannel_thietbi_thang.Visible = false;
                        pannel_thietbi_quy.Visible = true;
                        pannel_thietbi_nam.Visible = false;
                        break;
                    case "Theo năm":
                        pannel_thietbi_ngay.Visible = false;
                        pannel_thietbi_thang.Visible = false;
                        pannel_thietbi_quy.Visible = false;
                        pannel_thietbi_nam.Visible = true;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception) { }
        }

        private void LoadCombobox()
        {
            cbbTheoThang.Items.Clear();
            cbbTheoQuy.Items.Clear();
            cbbTheoNam.Items.Clear();

            for (int i = 1; i <= 12; i++)
            {
                cbbTheoThang.Items.Add(i);
            }
            for (int i = 1; i <= 4; i++)
            {
                cbbTheoQuy.Items.Add(i);
            }
            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year; i++)
            {
                cbbTheoNam.Items.Add(i);
            }
        }

        //Doanh thu lọc theo ngày
        public void BarTheoNgay(GunaChart chart, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            try
            {
                //Cấu hình biểu đồ
                chart.YAxes.GridLines.Display = false;
                //Tạo dữ liệu mới
                var dataset = new GunaBarDataset();
                chtImportProduct.Datasets.Clear();

                if (TongDoanhThu != 0)
                {
                    dataset.DataPoints.Add("Doanh thu ngày " + ngaybatdau.Day + "/" + ngaybatdau.Month + "/" + ngaybatdau.Year + " đến ngày " + ngayketthuc.Day + "/" + ngayketthuc.Month + "/" + ngayketthuc.Year, hoadon.LocDoanhThuTheoNgayTuChon(ngaybatdau, ngayketthuc));
                }
                else
                    dataset.DataPoints.Add("Doanh thu ngày " + ngaybatdau.Day + "/" + ngaybatdau.Month + "/" + ngaybatdau.Year + " đến ngày " + ngayketthuc.Day + "/" + ngayketthuc.Month + "/" + ngayketthuc.Year, 0);

                dataset.Label = "Tổng tiền";

                chart.Datasets.Add(dataset);

                chart.Update();

            }
            catch (Exception) { }
        }

        //Doanh thu lọc theo tháng
        public void BarThang(GunaChart chart, int thang)
        {
            try
            {
                //Cấu hình biểu đồ
                chart.YAxes.GridLines.Display = false;
                //Tạo dữ liệu mới
                var dataset = new GunaBarDataset();
                chtImportProduct.Datasets.Clear();

                switch (thang)
                {
                    case 1:
                        dataset.DataPoints.Add("Danh thu tháng " + 1, hoadon.HoaDonThang(1));
                        break;
                    case 2:
                        dataset.DataPoints.Add("Danh thu Tháng " + 2, hoadon.HoaDonThang(2));
                        break;
                    case 3:
                        dataset.DataPoints.Add("Danh thu Tháng " + 3, hoadon.HoaDonThang(3));
                        break;
                    case 4:
                        dataset.DataPoints.Add("Danh thu Tháng " + 4, hoadon.HoaDonThang(4));
                        break;
                    case 5:
                        dataset.DataPoints.Add("Danh thu Tháng " + 5, hoadon.HoaDonThang(5));
                        break;
                    case 6:
                        dataset.DataPoints.Add("Danh thu Tháng " + 6, hoadon.HoaDonThang(6));
                        break;
                    case 7:
                        dataset.DataPoints.Add("Danh thu Tháng " + 7, hoadon.HoaDonThang(7));
                        break;
                    case 8:
                        dataset.DataPoints.Add("Danh thu Tháng " + 8, hoadon.HoaDonThang(8));
                        break;
                    case 9:
                        dataset.DataPoints.Add("Danh thu Tháng " + 9, hoadon.HoaDonThang(9));
                        break;
                    case 10:
                        dataset.DataPoints.Add("Danh thu Tháng " + 10, hoadon.HoaDonThang(10));
                        break;
                    case 11:
                        dataset.DataPoints.Add("Danh thu Tháng " + 11, hoadon.HoaDonThang(11));
                        break;
                    case 12:
                        dataset.DataPoints.Add("Danh thu Tháng " + 12, hoadon.HoaDonThang(12));
                        break;

                    default:
                        break;
                }

                dataset.Label = "Tổng tiền";

                chart.Datasets.Add(dataset);

                chart.Update();
            }
            catch (Exception) { }
        }

        //Danh thu lọc theo quý
        public void Bar(GunaChart chart)
        {
            try
            {
                //Cấu hình biểu đồ
                chart.YAxes.GridLines.Display = false;
                //Tạo dữ liệu mới
                var dataset = new GunaBarDataset();
                chtImportProduct.Datasets.Clear();


                if (quy == 1)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        dataset.DataPoints.Add("Tháng " + i, hoadon.HoaDonThang(i));
                    }

                }
                else if (quy == 2)
                {
                    for (int i = 4; i <= 6; i++)
                    {
                        dataset.DataPoints.Add("Tháng " + i, hoadon.HoaDonThang(i));
                    }

                }
                else if (quy == 3)
                {
                    for (int i = 7; i <= 9; i++)
                    {
                        dataset.DataPoints.Add("Tháng " + i, hoadon.HoaDonThang(i));
                    }

                }
                else if (quy == 4)
                {
                    for (int i = 10; i <= 12; i++)
                    {
                        dataset.DataPoints.Add("Tháng " + i, hoadon.HoaDonThang(i));
                    }
                }
                else if (TongDoanhThu == 0)
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        dataset.DataPoints.Add("Tháng " + i, 0);
                    }
                }

                else
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        dataset.DataPoints.Add("Tháng " + i, hoadon.HoaDonThang(i));
                    }
                }

                dataset.Label = "Tổng tiền";

                chart.Datasets.Add(dataset);

                chart.Update();

            }
            catch (Exception) { }
        }

        private void time_dichvu_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngaychon = time_dichvu.Value;
            DataTable danhsach = chitietsudungDV.DanhSachDichVuThanToanTheoNgay(ngaychon);
            btnXuatDV.Enabled = true;
            try
            {

                int songay = int.Parse(chitietsudungDV.SoDonDichVuTrongNgayTheoHoaDon(ngaychon));
                double tongtienngay = double.Parse(chitietsudungDV.TongTienDichVuTrongNgayTheoHoaDon(ngaychon));
                ThongKeTheoNgay(ngaychon, songay, tongtienngay, songay_dvngay, tongtien_dvngay, dataHoaDonDichVu, danhsach);
            }
            catch (Exception)
            {
                songay_dvngay.Text = "Không có dữ liệu";
                tongtien_dvngay.Text = "Không có dữ liệu";
                DanhSachData(dataHoaDonDichVu, ngaychon, danhsach);
            }
        }

        private void cbbDichThuTheoThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thangchon = int.Parse(cbbDichThuTheoThang.SelectedItem.ToString().Trim());
            DataTable danhsach = chitietsudungDV.DanhSachDichVuThanhToanTheoThang(thangchon);
            btnXuatDV.Enabled = true;
            try
            {
                int sothang = int.Parse(chitietsudungDV.SoDonDichVuTrongThangTheoHoaDon(thangchon));
                double tongtienthang = double.Parse(chitietsudungDV.TongTienDichVuTrongThangTheoHoaDon(thangchon));
                ThongKeMain(thangchon, sothang, tongtienthang, songay_dvthang, tongtien_dvthang, dataHoaDonDichVu, danhsach);

            }
            catch (Exception)
            {
                songay_dvthang.Text = "Không có dữ liệu";
                tongtien_dvthang.Text = "Không có dữ liệu";
                DanhSachData(dataHoaDonDichVu, thangchon, danhsach);
            }
        }

        private void cbbDichVuTheoQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int quychon = int.Parse(cbbDichVuTheoQuy.SelectedItem.ToString().Trim());
            DataTable danhsach = chitietsudungDV.DanhSachDichVuThanToanTheoQuy(quychon);
            btnXuatDV.Enabled = true;
            try
            {
                int sotquy = int.Parse(chitietsudungDV.SoDonDichVuTrongQuyTheoHoaDon(quychon));
                double tongtienquy = double.Parse(chitietsudungDV.TongTienDichVuTrongQuyTheoHoaDon(quychon));
                ThongKeMain(quychon, sotquy, tongtienquy, songay_dvquy, tongtien_dvquy, dataHoaDonDichVu, danhsach);
            }
            catch (Exception)
            {
                songay_dvquy.Text = "Không có dữ liệu";
                tongtien_dvquy.Text = "Không có dữ liệu";
                DanhSachData(dataHoaDonDichVu, quychon, danhsach);
            }
        }

        private void cbbDichVuTheoNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int namchon = int.Parse(cbbDichVuTheoNam.SelectedItem.ToString().Trim());
            DataTable danhsach = chitietsudungDV.DanhSachDichVuThanToanTheoNam(namchon);
            btnXuatDV.Enabled = true;

            try
            {
                int sonam = int.Parse(chitietsudungDV.SoDonDichVuTrongNamTheoHoaDon(namchon));
                double tongtiennam = double.Parse(chitietsudungDV.TongTienDichVuTrongNamTheoHoaDon(namchon));
                ThongKeMain(namchon, sonam, tongtiennam, songay_dvnam, tongtien_dvnam, dataHoaDonDichVu, danhsach);
            }
            catch (Exception)
            {
                songay_dvnam.Text = "Không có dữ liệu";
                tongtien_dvnam.Text = "Không có dữ liệu";
                DanhSachData(dataHoaDonDichVu, namchon, danhsach);
            }
        }


        private void time_thietbi_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngaychon = time_thietbi.Value;
            DataTable danhsach = chitietsudungTB.DanhSachThietBiThanToanTheoNgay(ngaychon);
            btnXuatTB.Enabled = true;
            try
            {
                int songay = int.Parse(chitietsudungTB.SoDonThietBiTrongNgayTheoHoaDon(ngaychon));
                double tongtienngay = double.Parse(chitietsudungTB.TongTienThietBiTrongNgayTheoHoaDon(ngaychon));
                ThongKeTheoNgay(ngaychon, songay, tongtienngay, soluong_tbngay, tongtien_tbngay, dataHoaDonThietBi, danhsach);
            }
            catch (Exception)
            {
                soluong_tbngay.Text = "Không có dữ liệu";
                tongtien_tbngay.Text = "Không có dữ liệu";
                DanhSachData(dataHoaDonThietBi, ngaychon, danhsach);
            }
        }



        private void cbbThietBiThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thangchon = int.Parse(cbbThietBiThang.SelectedItem.ToString().Trim());
            DataTable danhsach = chitietsudungTB.DanhSachThietBiThanhToanTheoThang(thangchon);
            btnXuatTB.Enabled = true;
            try
            {
                int sothang = int.Parse(chitietsudungTB.SoDonThietBiTrongThangTheoHoaDon(thangchon));
                double tongtienthang = double.Parse(chitietsudungTB.TongTienThietBiTrongThangTheoHoaDon(thangchon));
                ThongKeMain(thangchon, sothang, tongtienthang, soluong_tbthang, tongtien_tbthang, dataHoaDonThietBi, danhsach);

            }
            catch (Exception)
            {
                soluong_tbthang.Text = "Không có dữ liệu";
                tongtien_tbthang.Text = "Không có dữ liệu";
                DanhSachData(dataHoaDonThietBi, thangchon, danhsach);
            }
        }

        private void cbbThietBiQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            int quychon = int.Parse(cbbThietBiQuy.SelectedItem.ToString().Trim());
            DataTable danhsach = chitietsudungTB.DanhSachThietBiThanToanTheoQuy(quychon);
            btnXuatTB.Enabled = true;
            try
            {
                int sotquy = int.Parse(chitietsudungTB.SoDonThietBiTrongQuyTheoHoaDon(quychon));
                double tongtienquy = double.Parse(chitietsudungTB.TongTienThietBiTrongQuyTheoHoaDon(quychon));
                ThongKeMain(quychon, sotquy, tongtienquy, soluong_quy, tongtien_tbquy, dataHoaDonThietBi, danhsach);
            }
            catch (Exception)
            {
                soluong_quy.Text = "Không có dữ liệu";
                tongtien_tbquy.Text = "Không có dữ liệu";
                DanhSachData(dataHoaDonThietBi, quychon, danhsach);
            }
        }

        private void cbbThietBiNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int namchon = int.Parse(cbbThietBiNam.SelectedItem.ToString().Trim());
            DataTable danhsach = chitietsudungTB.DanhSachThietBiThanToanTheoNam(namchon);
            btnXuatTB.Enabled = true;
            try
            {
                int sonam = int.Parse(chitietsudungTB.SoDonThietBiTrongNamTheoHoaDon(namchon));
                double tongtiennam = double.Parse(chitietsudungTB.TongTienThietBiTrongNamTheoHoaDon(namchon));
                ThongKeMain(namchon, sonam, tongtiennam, soluong_tbnam, tongtien_tbnam, dataHoaDonThietBi, danhsach);
            }
            catch (Exception)
            {
                soluong_tbnam.Text = "Không có dữ liệu";
                tongtien_tbnam.Text = "Không có dữ liệu";
                DanhSachData(dataHoaDonThietBi, namchon, danhsach);
            }
        }

        public void BarTongQuat(GunaChart chart)
        {
            try
            {
                //Cấu hình biểu đồ
                chart.YAxes.GridLines.Display = false;

                //Tạo dữ liệu mới
                var dataset = new GunaBarDataset();
                chtImportProduct.Datasets.Clear();

                for (int i = 1; i <= 12; i++)
                {
                    dataset.DataPoints.Add("Tháng " + i, hoadon.HoaDonThang(i));
                }

                dataset.Label = "Tổng tiền";
                chart.Datasets.Add(dataset);
                chart.Update();

            }
            catch (Exception) { }
        }
        public void Barload(GunaChart chart)
        {
            //Cấu hình biểu đồ
            chart.YAxes.GridLines.Display = false;
            chart.Update();
        }
        private void btnLamoiTB_Click(object sender, EventArgs e)
        {
            LoadHoaDonThietBi();
            pannel_thietbi_ngay.Visible = false;
            pannel_thietbi_thang.Visible = false;
            pannel_thietbi_quy.Visible = false;
            pannel_thietbi_nam.Visible = false;
            btnXuatTB.Enabled = false;
        }

        private void cbbThongTinDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_dichvu = cbbThongTinDichVu.SelectedValue.ToString();
            if (id_dichvu != "-1")
            {
                dataHoaDonDichVu.DataSource = chitietsudungDV.DanhSachDichVuTheoLoai(id_dichvu);
            }
            else
                dataHoaDonDichVu.DataSource = chitietsudungDV.DanhSachDichVuSuDung();
        }

        private void CbbThongTinPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_phong = CbbThongTinPhong.SelectedValue.ToString();
            if (id_phong != "-1")
            {
                dataHoaDonDichVu.DataSource = chitietsudungDV.DanhSachDichVuTheoLoaiPhong(id_phong);
            }
            else
                dataHoaDonDichVu.DataSource = chitietsudungDV.DanhSachDichVuSuDung();
        }

        private void cbbThongTinThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_thietbi = cbbThongTinThietBi.SelectedValue.ToString();
            if (id_thietbi != "-1")
            {
                dataHoaDonThietBi.DataSource = chitietsudungTB.DanhSachThietBiTheoLoai(id_thietbi);
            }
            else
                dataHoaDonThietBi.DataSource = chitietsudungTB.DanhSachThietBiSuDung();
        }

        private void cbbThongTinPhongSDTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_phong = cbbThongTinPhongSDTB.SelectedValue.ToString();
            if (id_phong != "-1")
            {
                dataHoaDonThietBi.DataSource = chitietsudungTB.DanhSachThietBiTheoLoaiPhong(id_phong);
            }
            else
                dataHoaDonThietBi.DataSource = chitietsudungTB.DanhSachThietBiSuDung();
        }

        private void time_thuchien_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngaythuchien = time_thuchien.Value;
            try
            {
                datadoiphong.DataSource = datphongdll.LocLichSuDoiPhong(ngaythuchien);
            }
            catch (Exception) { }
        }

        private void time_thaotac_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngaythaotac = time_thaotac.Value;
            try
            {
                datathaotac.DataSource = datphongdll.LocLichSuThaoTac(ngaythaotac);
            }
            catch (Exception) { }
        }

        private void btn_lammoidulieu_Click(object sender, EventArgs e)
        {
            LoadLichSuThaoTac();
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            string index = cbbTheoQuy.Text;
            string thang = cbbTheoThang.Text;
            string nam = cbbTheoNam.Text;
            string labelText = label_tongdoanhthu.Text;
            string yearPart = "";

            int indexxx = labelText.IndexOf("năm");

            if (indexxx != -1)
            {
                yearPart = labelText.Substring(indexxx + 4).Trim(new char[] { ' ', '(', ')' });
            }
            else
                Console.WriteLine("Bạn chưa chọn lọc theo năm");

            char firstCharacter = labelText[0];

            if (nam != "" && labelText.Contains("năm " + nam))
            {
                if (labelText.Contains("năm " + nam) && firstCharacter != '0')
                {
                    FrmLoadDer loadDer = new FrmLoadDer(taikhoan, true, thang, "3");
                    loadDer.ShowDialog();
                }
                else
                    MessageBox.Show("Năm " + nam + " không có doanh thu.Không thể lập báo cáo");
            }

            if (thang != "" && labelText.Contains("Tháng"))
            {
                var doanhthu = label_tongdoanhthu.Text;

                int indexx = doanhthu.IndexOf("VND");

                string doanhthu_cattruoc = doanhthu.Substring(0, indexx);
                string doanhthu_ = doanhthu_cattruoc.Replace(",", "");

                Console.WriteLine(doanhthu_cattruoc);
                TongDoanhThu = hoadon.HoaDonThang(int.Parse(thang));

                FrmLoadDer loadDer = new FrmLoadDer(index, taikhoan, thang, double.Parse(doanhthu_), "1");
                loadDer.ShowDialog();
            }

            if (index != null && labelText.Contains("quý"))
            {
                FrmLoadDer loadDer = new FrmLoadDer(index, taikhoan, thang, "2");
                loadDer.ShowDialog();
            }
        }

        private void btnXuatDT_Click(object sender, EventArgs e)
        {
            DataTable tbHoaDon = new DataTable();
            tbHoaDon.Columns.Add("Mã hóa đơn", typeof(string));
            tbHoaDon.Columns.Add("Nhân viên đặt phòng", typeof(string));
            tbHoaDon.Columns.Add("Nhân viên thanh toán", typeof(string));
            tbHoaDon.Columns.Add("Ngày lập", typeof(string));
            tbHoaDon.Columns.Add("Tổng tiền", typeof(string));

            // Duyệt qua từng hàng của DataGridView
            foreach (DataGridViewRow row in datahoadonthanhtoan.Rows)
            {
                DataRow dataRow = tbHoaDon.NewRow();
                dataRow["Mã hóa đơn"] = row.Cells[0].Value;
                dataRow["Nhân viên đặt phòng"] = row.Cells[3].Value;
                dataRow["Nhân viên thanh toán"] = row.Cells[4].Value;
                dataRow["Ngày lập"] = row.Cells[6].Value;
                dataRow["Tổng tiền"] = row.Cells[7].Value;
                tbHoaDon.Rows.Add(dataRow);
            }
            string cbbthongke = cbbThongKeHoaDon.Text;

            if (cbbthongke == "Theo ngày")
            {
                string cbbthongketheo = time_ngay.Text;
                string sohoadon = soluong_theongay.Text;
                string tongtien = tongtien_theongay.Text;
                FrmLoadDer loadDer = new FrmLoadDer(tbHoaDon, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Hóa đơn");
                loadDer.ShowDialog();
            }
            if (cbbthongke == "Theo Tháng")
            {
                string cbbthongketheo = cbbThongKeTheoThang.Text;
                string sohoadon = soluong_trongthang.Text;
                string tongtien = tongtien_theothang.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbHoaDon, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Hóa đơn");
                loadDer.ShowDialog();
            }
            if (cbbthongke == "Theo quý")
            {
                string cbbthongketheo = cbbThongKeTheoQuy.Text;
                string sohoadon = soluong_theoquy.Text;
                string tongtien = tongtien_theoquy.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbHoaDon, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Hóa đơn");
                loadDer.ShowDialog();
            }
            if (cbbthongke == "Theo năm")
            {
                string cbbthongketheo = cbbThongKeTheoNam.Text;
                string sohoadon = soluong_theonam.Text;
                string tongtien = tongtien_theonam.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbHoaDon, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Hóa đơn");
                loadDer.ShowDialog();
            }
        }

        private void btnXuatDV_Click(object sender, EventArgs e)
        {
            DataTable tbDichVu = new DataTable();
            tbDichVu.Columns.Add("Mã phòng đặt", typeof(string));
            tbDichVu.Columns.Add("Tên dịch vụ", typeof(string));
            tbDichVu.Columns.Add("Ngày thuê", typeof(string));
            tbDichVu.Columns.Add("Số lượng", typeof(string));
            tbDichVu.Columns.Add("Đơn giá", typeof(string));
            tbDichVu.Columns.Add("Thành tiền", typeof(string));

            // Duyệt qua từng hàng của DataGridView
            foreach (DataGridViewRow row in dataHoaDonDichVu.Rows)
            {
                DataRow dataRow = tbDichVu.NewRow();
                dataRow["Mã phòng đặt"] = row.Cells[0].Value;
                dataRow["Tên dịch vụ"] = row.Cells[1].Value;
                dataRow["Ngày thuê"] = row.Cells[2].Value;
                dataRow["Số lượng"] = row.Cells[3].Value;
                dataRow["Đơn giá"] = row.Cells[4].Value;
                dataRow["Thành tiền"] = row.Cells[5].Value;
                tbDichVu.Rows.Add(dataRow);
            }

            string cbbthongke = cbbThongKeDichVu.Text;

            if (cbbthongke == "Theo ngày")
            {
                string cbbthongketheo = time_dichvu.Text;
                string sohoadon = songay_dvngay.Text;
                string tongtien = tongtien_dvngay.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbDichVu, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Dịch vụ");
                loadDer.ShowDialog();
            }
            if (cbbthongke == "Theo Tháng")
            {
                string cbbthongketheo = cbbDichThuTheoThang.Text;
                string sohoadon = songay_dvthang.Text;
                string tongtien = tongtien_dvthang.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbDichVu, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Dịch vụ");
                loadDer.ShowDialog();
            }
            if (cbbthongke == "Theo quý")
            {
                string cbbthongketheo = cbbDichVuTheoQuy.Text;
                string sohoadon = songay_dvquy.Text;
                string tongtien = tongtien_dvquy.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbDichVu, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Dịch vụ");
                loadDer.ShowDialog();
            }
            if (cbbthongke == "Theo năm")
            {
                string cbbthongketheo = cbbDichVuTheoNam.Text;
                string sohoadon = songay_dvnam.Text;
                string tongtien = tongtien_dvnam.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbDichVu, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Dịch vụ");
                loadDer.ShowDialog();
            }
        }

        private void btnXuatTB_Click(object sender, EventArgs e)
        {
            DataTable tbDichVu = new DataTable();
            tbDichVu.Columns.Add("Mã phòng đặt", typeof(string));
            tbDichVu.Columns.Add("Tên dịch vụ", typeof(string));
            tbDichVu.Columns.Add("Ngày thuê", typeof(string));
            tbDichVu.Columns.Add("Số lượng", typeof(string));
            tbDichVu.Columns.Add("Đơn giá", typeof(string));
            tbDichVu.Columns.Add("Thành tiền", typeof(string));

            // Duyệt qua từng hàng của DataGridView
            foreach (DataGridViewRow row in dataHoaDonThietBi.Rows)
            {
                DataRow dataRow = tbDichVu.NewRow();
                dataRow["Mã phòng đặt"] = row.Cells[0].Value;
                dataRow["Tên dịch vụ"] = row.Cells[1].Value;
                dataRow["Ngày thuê"] = row.Cells[2].Value;
                dataRow["Số lượng"] = row.Cells[3].Value;
                dataRow["Đơn giá"] = row.Cells[4].Value;
                dataRow["Thành tiền"] = row.Cells[5].Value;
                tbDichVu.Rows.Add(dataRow);
            }

            string cbbthongke = cbbThongKeThietBi.Text;

            if (cbbthongke == "Theo ngày")
            {
                string cbbthongketheo = time_thietbi.Text;
                string sohoadon = soluong_tbngay.Text;
                string tongtien = tongtien_tbngay.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbDichVu, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Thiết bị");
                loadDer.ShowDialog();
            }
            if (cbbthongke == "Theo Tháng")
            {
                string cbbthongketheo = cbbThietBiThang.Text;
                string sohoadon = soluong_tbthang.Text;

                string tongtien = tongtien_tbthang.Text;
                FrmLoadDer loadDer = new FrmLoadDer(tbDichVu, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Thiết bị");
                loadDer.ShowDialog();
            }
            if (cbbthongke == "Theo quý")
            {
                string cbbthongketheo = cbbThietBiQuy.Text;
                string sohoadon = soluong_quy.Text;
                string tongtien = tongtien_tbquy.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbDichVu, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Thiết bị");
                loadDer.ShowDialog();
            }
            if (cbbthongke == "Theo năm")
            {
                string cbbthongketheo = cbbThietBiNam.Text;
                string sohoadon = soluong_tbnam.Text;
                string tongtien = tongtien_tbnam.Text;

                FrmLoadDer loadDer = new FrmLoadDer(tbDichVu, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, "Thiết bị");
                loadDer.ShowDialog();
            }
        }

        private void btnlamMoiDV_Click(object sender, EventArgs e)
        {
            LoadHoaDonDichVu();
            pannel_dichvutheongay.Visible = false;
            pannel_dichvutheothang.Visible = false;
            pannel_dichvutheoquy.Visible = false;
            pannel_dichvutheonam.Visible = false;
            btnXuatDV.Enabled = false;
        }

        private void btnLamMoiHoaDon_Click(object sender, EventArgs e)
        {
            LoadHoaDonThanhToan();
            pannel_theongay.Visible = false;
            pannel_theothang.Visible = false;
            pannel_theoquy.Visible = false;
            pannel_theonam.Visible = false;
            btnXuatDT.Enabled = false;
        }
        private void DanhSachData(Guna2DataGridView giv, int dulieu, DataTable table)
        {
            giv.DataSource = table;
        }
        private void DanhSachData(Guna2DataGridView giv, DateTime ngay, DataTable table)
        {
            giv.DataSource = table;
        }
        private void ThongKeMain(int kieu, int so, double tongtien, System.Windows.Forms.Label sl, System.Windows.Forms.Label tong, Guna2DataGridView data, DataTable danhsach)
        {
            try
            {
                sl.Text = so.ToString();
                tong.Text = tongtien.ToString("C");
                DanhSachData(data, kieu, danhsach);
            }
            catch (Exception) { MessageBox.Show("Loi"); }
        }
        private void ThongKeTheoNgay(DateTime ngaychon, int songay, double tongtienngay, System.Windows.Forms.Label text_sl, System.Windows.Forms.Label text_tongtien, Guna2DataGridView data, DataTable danhsach)
        {
            try
            {
                if (songay != 0)
                {
                    text_sl.Text = songay.ToString();
                    text_tongtien.Text = tongtienngay.ToString("C");
                    DanhSachData(data, ngaychon, danhsach);
                }
            }
            catch (Exception) { }
        }

    }
}
