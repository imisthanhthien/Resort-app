using DAL;
using DDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;
using DTO;
using GUI.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;

namespace GUI
{
    public partial class FrmNhanPhong : Form
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();

        DLL_NhanVien dllnhanvien = new DLL_NhanVien();
        DLL_DatPhong ddldatphong = new DLL_DatPhong();
        DLL_ChiTietSuDungDV ctsddv = new DLL_ChiTietSuDungDV();
        DLL_ChiTietSuDungTB ctsdtb = new DLL_ChiTietSuDungTB();
        DLL_HoaDon dlhoadon = new DLL_HoaDon();

        private string maphong, madatphong;
        private string makh;
        private string taikhoan;
        private string email, chucvu;
        private string str;
        private string[] danhsachNV;
        private int songayo;
        private double giaphong;
        private double? thanhtien;
        private char separator = '|';

        //Lưu trạng thái nhận phòng 
        public static Dictionary<string, bool> TrangThaiNhanPhong { get; set; } = new Dictionary<string, bool>();

        public FrmNhanPhong(string maphong, int songayo, string taikhoan)
        {
            this.maphong = maphong;
            this.songayo = songayo;
            this.taikhoan = taikhoan;

            InitializeComponent();
        }

        private void FrmNhanPhong_Load(object sender, EventArgs e)
        {

            RestoreRoomStatus();
            loadThongTinNhanPhong();
            LoadThongTin();
            LoadThongTinDichVu();
            LoadThongTinThietBi();
            LoadTongTienDVvaTB();
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void LoadThongTinDichVu()
        {
            try
            {
                madatphong = ddldatphong.LayMaDatPhonginPhong(maphong);
                if (madatphong != "")
                {
                    dataDichVu.DataSource = ctsddv.DanhSachChiTietDV(madatphong);
                    dataDichVu.ClearSelection();
                }
            }
            catch (Exception) { }
        }
        private void LoadThongTinThietBi()
        {
            try
            {
                madatphong = ddldatphong.LayMaDatPhonginPhong(maphong);
                if (madatphong != "")
                {
                    dataThietBi.DataSource = ctsdtb.DanhSachChiTietTB(madatphong);
                    dataThietBi.ClearSelection();
                }
            }
            catch (Exception) { }
        }

        private void LoadTongTienDVvaTB()
        {
            madatphong = ddldatphong.LayMaDatPhonginPhong(maphong);

            if (madatphong != "")
            {
                double? tongtienDV = ctsddv.TongTienSuDungDV(madatphong);
                double? tongtienTB = ctsdtb.TongTienSuDungTB(madatphong);

                if (tongtienDV.HasValue && tongtienTB.HasValue)
                {
                    thanhtien = tongtienDV.Value + tongtienTB.Value;
                }
                else if (tongtienDV.HasValue && !tongtienTB.HasValue)
                {
                    thanhtien = tongtienDV.Value;
                }
                else if (!tongtienDV.HasValue && tongtienTB.HasValue)
                {
                    thanhtien = tongtienTB.Value;
                }
                else
                    thanhtien = null;

                if (thanhtien.HasValue)
                {
                    string formattedThanhtien = thanhtien.Value.ToString("C");
                    label_thanhtien.Text = formattedThanhtien;
                }
            }
        }

        private void loadThongTinNhanPhong()
        {
            if (!string.IsNullOrEmpty(maphong))
            {
                var datphong = qlrs.datphongs.Where(dt => dt.id_phong == maphong && dt.trang_thai == "Chưa thanh toán").FirstOrDefault();

                if (datphong != null)
                {
                    string madt = ddldatphong.LayMaDatPhonginPhong(maphong);
                    giaphong = ddldatphong.LayGiaPhongTheoMaPhong(maphong);
                    var madatphong = qlrs.datphongs.Where(dt => dt.id_datphong == madt).FirstOrDefault();

                    if (madatphong != null)
                    {
                        makh = datphong.id_khachhang;

                        if (makh != null)
                        {
                            var khachHang = qlrs.khachhangs.Where(kh => kh.id_khachhang == makh).FirstOrDefault();

                            var phong = qlrs.phongs.Where(p => p.id_phong == maphong).FirstOrDefault();
                            label_hoten.Text = khachHang.ten_khachhang;
                            label_ngaysinh.Text = khachHang.ngay_sinh.ToString("dd/MM/yyyy");
                            label_sdt.Text = khachHang.sdt;
                            label_gioitinh.Text = khachHang.gioi_tinh;
                            label_email.Text = khachHang.email_khachhang;
                            label_songay.Text = Convert.ToString(songayo) + " Ngày";
                            label_checkin.Text = datphong.check_in.ToString();
                            label_checkout.Text = datphong.check_out.ToString();
                            label_tenphong.Text = phong.ten.ToUpper();
                            label_songuoio.Text = Convert.ToString(phong.so_luong_nguoi);
                            label_giaphong.Text = giaphong.ToString("C");

                            setthuoctinh(true);
                        }
                    }
                }
            }
        }

        private void setthuoctinh(bool giatri)
        {
            if (giatri)
            {
                label_hoten.Visible = giatri;
                label_ngaysinh.Visible = giatri;
                label_gioitinh.Visible = giatri;
                label_checkin.Visible = giatri;
                label_checkout.Visible = giatri;
                label_sdt.Visible = giatri;
                label_songay.Visible = giatri;
                label_thanhtien.Visible = giatri;
                btnNhanPhong.Enabled = giatri;
            }
        }

        private void ChucVuNhanVien()
        {
            email = dllnhanvien.LayMailNhanVien(taikhoan);
            if (email != "")
            {
                chucvu = dllnhanvien.LayChucVuNhanVien(email);
                if (chucvu == "1")
                {
                    btnThanhToan.Visible = false;
                }
                else
                    btnThanhToan.Visible = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            string tenkh = label_hoten.Text;

            if (MessageBox.Show("Nhận phòng cho khách hàng: " + tenkh, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MsgBox("Nhận phòng thành công!", false);
                btnNhanPhong.Visible = false;
                btn_dichvu.Enabled = true;
                btnThemThietBi.Enabled = true;
                btnHuy.Enabled = false;
                btnLuu.Enabled = true;

                NhanPhong(maphong);
                ChucVuNhanVien();
            }
        }

        private void LoadThongTin()
        {
            bool KT = KiemTraTrangThaiNhanPhong(maphong);
            if (KT)
            {
                ChucVuNhanVien();
                btnNhanPhong.Visible = false;
                btn_dichvu.Enabled = true;
                btnThemThietBi.Enabled = true;
                btnLuu.Enabled = true;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            SaveRoomStatus();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string tenkh = label_hoten.Text;
            double tongtienHD = 0;

            if (MessageBox.Show("Bạn có muốn trả phòng và thanh toán cho khách hàng: " + tenkh + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(maphong))
                {
                    string madt = ddldatphong.LayMaDatPhonginPhong(maphong);
                    str = dllnhanvien.LayIDNameNhanVien(taikhoan);
                    danhsachNV = str.Split(separator);
                    string madv = danhsachNV[0].Trim();

                    giaphong = ddldatphong.LayGiaPhongTheoMaPhong(maphong);

                    if (thanhtien.HasValue)
                    {
                        tongtienHD += ((songayo * giaphong) + thanhtien.Value);
                    }
                    else
                        tongtienHD += (songayo * giaphong);

                    var datphongs = qlrs.datphongs.Where(dt => dt.id_datphong == madt).FirstOrDefault();

                    if (datphongs != null)
                    {
                        string makh = datphongs.id_khachhang;
                        string maphongdoi = datphongs.id_phong;
                        var phongs = qlrs.phongs.Where(dt => dt.id_phong == maphong).FirstOrDefault();

                        DTO_HoaDon dtohoadon = new DTO_HoaDon
                            (
                                madt,
                                madv,
                                makh,
                                tongtienHD
                            );

                        if (dlhoadon.ThanhToan(dtohoadon))
                        {
                            if (phongs != null && phongs.id_phong == maphong)
                            {
                                datphongs.trang_thai = "Đã thanh toán";
                                MsgBox("Thanh toán thành công", false);

                                XoaTrangThaiNhanPhong(maphong);
                                qlrs.SubmitChanges();
                                InBaoCaoBanHang();
                                btnHuy.Enabled = false;
                                btnThanhToan.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        //Xác nhận phòng đã nhận và lưu mã phòng true
        public static void NhanPhong(string maPhong)
        {
            TrangThaiNhanPhong[maPhong] = true;
        }

        //Kiểm tra trạng thái phòng đã nhận hay không
        public static bool KiemTraTrangThaiNhanPhong(string maPhongCanKiemTra)
        {
            if (TrangThaiNhanPhong.ContainsKey(maPhongCanKiemTra))
            {
                return TrangThaiNhanPhong[maPhongCanKiemTra];
            }
            else
            {
                return false;
            }
        }

        //Thanh toán xong xóa trạng thái nhận phòng
        public static void XoaTrangThaiNhanPhong(string maPhongCanXoa)
        {
            if (TrangThaiNhanPhong.ContainsKey(maPhongCanXoa))
            {
                TrangThaiNhanPhong.Remove(maPhongCanXoa);
            }
        }

        //Lưu trạng thái vào một file để so sánh khi đăng nhập lại lần sau
        private static void SaveRoomStatus()
        {
            try
            {
                using (FileStream fs = new FileStream("RoomStatus.dat", FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, TrangThaiNhanPhong);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu trạng thái phòng: {ex.Message}");
            }
        }


        //Thêm dịch vụ sử dụng
        private void btn_dichvu_Click(object sender, EventArgs e)
        {
            madatphong = ddldatphong.LayMaDatPhonginPhong(maphong);

            if (madatphong != "")
            {
                FrmDatDichVu frmDatDichVu = new FrmDatDichVu(madatphong);

                if (new FrmDatDichVu(madatphong).ShowDialog() == DialogResult.OK)
                {
                    LoadThongTinDichVu();
                    LoadTongTienDVvaTB();
                }
            }
        }

        private void guna2GradientPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                guna2GradientPanel2.Capture = false;
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
     
        private void InBaoCaoBanHang()
        {
            DataTable dtDichVu = new DataTable();
            DataTable dtThietBi = new DataTable();

            dtDichVu.Columns.Add("Tên Dịch Vụ", typeof(string));
            dtDichVu.Columns.Add("Giá", typeof(string));
            dtDichVu.Columns.Add("SL", typeof(string));
            dtDichVu.Columns.Add("Tổng Tiền", typeof(string));

            // Duyệt qua từng hàng của DataGridView
            foreach (DataGridViewRow row in dataDichVu.Rows)
            {
                DataRow dataRow = dtDichVu.NewRow();
                dataRow["Tên Dịch Vụ"] = row.Cells[1].Value;
                dataRow["Giá"] = row.Cells[2].Value;
                dataRow["SL"] = row.Cells[3].Value;
                dataRow["Tổng Tiền"] = row.Cells[4].Value;
                dtDichVu.Rows.Add(dataRow);
            }

            dtThietBi.Columns.Add("Tên Thiết Bị", typeof(string));
            dtThietBi.Columns.Add("Giá", typeof(string));
            dtThietBi.Columns.Add("SL", typeof(string));
            dtThietBi.Columns.Add("Tổng Tiền", typeof(string));

            // Duyệt qua từng hàng của DataGridView
            foreach (DataGridViewRow row in dataThietBi.Rows)
            {
                DataRow dataRow = dtThietBi.NewRow();
                dataRow["Tên Thiết Bị"] = row.Cells[1].Value;
                dataRow["Giá"] = row.Cells[2].Value;
                dataRow["SL"] = row.Cells[3].Value;
                dataRow["Tổng Tiền"] = row.Cells[4].Value;
                dtThietBi.Rows.Add(dataRow);
            }

            var phong = qlrs.phongs.Where(p => p.id_phong == maphong).FirstOrDefault();
            giaphong = ddldatphong.LayGiaPhongTheoMaPhong(maphong);

            var doanhthu = label_thanhtien.Text;

            double tongtien = 0;
            string maphongg = phong.ten.ToString();
            string songuoi = phong.so_luong_nguoi.ToString();
            string songayoo = Convert.ToString(songayo);

            if (doanhthu != "0 VNĐ")
            {
                int indexx = doanhthu.IndexOf("VND");

                string doanhthu_cattruoc = doanhthu.Substring(0, indexx);
                string doanhthu_ = doanhthu_cattruoc.Replace(",", "");
                tongtien = (giaphong * double.Parse(songayoo)) + double.Parse(doanhthu_);
            }
            else
                tongtien = (giaphong * double.Parse(songayoo));

            string mail_nhan = label_email.Text;
            string tenkhachhang = label_hoten.Text;

            //Kiểm tra nếu mail tồn tại và không trống
            if (mail_nhan != "")
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BaoCaoHoaDonThanhToan report = new BaoCaoHoaDonThanhToan(maphongg, songuoi, songayoo, taikhoan, tongtien.ToString("C"), dtDichVu, dtThietBi, giaphong.ToString());
                    report.ExportToPdf(ms);

                    //Gửi hóa đơn cho khách
                    FrmGuiMailReport mail = new FrmGuiMailReport(mail_nhan, tenkhachhang, ms.ToArray());
                    mail.ShowDialog();
                    MsgBox(mail.Result);
                    report.CreateDocument();
                    report.Parameters.Clear();
                    report.ShowPreview();
                }
            }
            else
            {
                BaoCaoHoaDonThanhToan bc = new BaoCaoHoaDonThanhToan(maphongg, songuoi, songayoo, taikhoan, tongtien.ToString("C"), dtDichVu, dtThietBi, giaphong.ToString());
                bc.CreateDocument();
                bc.Parameters.Clear();
                bc.ShowPreview();
            }
        }

        //Thêm thiết bị sử dụng
        private void btnThemThietBi_Click(object sender, EventArgs e)
        {
            madatphong = ddldatphong.LayMaDatPhonginPhong(maphong);

            if (madatphong != "")
            {
                FrmSuDungThietBi frmSuDungThiet = new FrmSuDungThietBi(madatphong);
                if (new FrmSuDungThietBi(madatphong).ShowDialog() == DialogResult.OK)
                {
                    LoadThongTinThietBi();
                    LoadTongTienDVvaTB();
                }
            }
        }

        //Phục hồi trạng thái nhận phòng khi đăng nhập lại 
        private static void RestoreRoomStatus()
        {
            if (File.Exists("RoomStatus.dat"))
            {
                try
                {
                    using (FileStream fs = new FileStream("RoomStatus.dat", FileMode.Open))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        TrangThaiNhanPhong = (Dictionary<string, bool>)formatter.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi RestoreRoomStatus: {ex.Message}");
                }
            }
        }
    }
}
