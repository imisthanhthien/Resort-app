using DDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace GUI.Report
{
    public partial class BaoCaoDatPhong : DevExpress.XtraReports.UI.XtraReport
    {
        private string cbbthongke, cbbthongketheo, sohoadon, str, taikhoan, tongtien, check_report;
        private string[] danhsachNV;
        private char separator = '|';

        DLL_NhanVien nhanvien = new DLL_NhanVien();
        private DataTable tbHoaDon;
        public BaoCaoDatPhong(DataTable tbHoaDon, string taikhoan, string cbbthongke, string cbbthongketheo, string sohoadon, string tongtien, string check_report)
        {
            this.tbHoaDon = tbHoaDon;
            this.taikhoan = taikhoan;
            this.sohoadon = sohoadon;
            this.cbbthongke = cbbthongke;
            this.cbbthongketheo = cbbthongketheo;
            this.tongtien = tongtien;
            this.check_report = check_report;
            InitializeComponent();
            Report_Load();
        }

        private void initPanel()
        {
            this.panelDichVuVaThietBi.Visible = false;
            this.panelHoaDon.Visible = false;
        }

        private void Report_Load()
        {
            System.DateTime date = System.DateTime.Now;
            this.Parameters["time"].Value = date.ToString("dd/MM/yyyy") + " " + date.ToString("HH:mm:ss");
            str = nhanvien.LayIDNameNhanVien(taikhoan);

            if (str != "")
            {
                danhsachNV = str.Split(separator);
                string tennv = danhsachNV[1].Trim();
                this.Parameters["TenNhanVien"].Value = tennv;

            }

            string rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            rootDir = Directory.GetParent(rootDir).Parent.FullName; 
            string relativePath = @"ImagesResort\logoshop.png";
            string path = Path.Combine(rootDir, relativePath);

            this.Parameters["LogoShop"].Value = path;
            this.Parameters["SoDon"].Value = sohoadon;
            this.Parameters["TongDoanhThu"].Value = tongtien;
            this.Parameters["Param"].Value = cbbthongke;
            this.Parameters["thongke"].Value = cbbthongketheo;
            
           
            //Load hóa đơn
            if (check_report == "Hóa đơn")
            {
                initPanel();
                this.panelHoaDon.Visible = true;
                List<string> listMaHoaDon = new List<string>();
                List<string> listNVDatPhong = new List<string>();
                List<string> listNVThanhToan = new List<string>();
                List<string> listNgayLap = new List<string>();
                List<string> listTongTien = new List<string>();

                foreach (DataRow row in tbHoaDon.Rows)
                {
                    listMaHoaDon.Add(row["Mã hóa đơn"].ToString());
                    listNVDatPhong.Add(row["Nhân viên đặt phòng"].ToString());
                    listNVThanhToan.Add(row["Nhân viên thanh toán"].ToString());
                    listNgayLap.Add(row["Ngày lập"].ToString().Replace("12:00:00 AM", ""));
                    listTongTien.Add(row["Tổng tiền"].ToString());
                }

                string lstMaHD = String.Join(",", listMaHoaDon.ToArray());
                lstMaHD = lstMaHD.Replace(",", "\n\n");
                string lstNVDatPhong = String.Join(",", listNVDatPhong.ToArray());
                lstNVDatPhong = lstNVDatPhong.Replace(",", "\n\n");
                string lstNVThanhToan = String.Join(",", listNVThanhToan.ToArray());
                lstNVThanhToan = lstNVThanhToan.Replace(",", "\n\n");
                string lstNgayLap = String.Join(",", listNgayLap.ToArray());
                lstNgayLap = lstNgayLap.Replace(",", "\n\n");
                string lstTongTien = String.Join(",", listTongTien.ToArray());
                lstTongTien = lstTongTien.Replace(",", "\n\n");

                this.Parameters["MaHoaDon"].Value = lstMaHD;
                this.Parameters["NhanVienDatPhong"].Value = lstNVDatPhong;
                this.Parameters["NhanVienThanhToan"].Value = lstNVThanhToan;
                this.Parameters["NgayLap"].Value = lstNgayLap;
                this.Parameters["TongTien"].Value = lstTongTien;
                this.Parameters["TenDoanhThu"].Value = "ĐẶT PHÒNG";
            }
           
            //Load dịch vụ
            if (check_report == "Dịch vụ")
            {
                initPanel();
                this.panelDichVuVaThietBi.Visible = true;
                List<string> listMaPhongDat = new List<string>();
                List<string> listTenDichVu = new List<string>();
                List<string> listNgayThue = new List<string>();
                List<string> listSoLuong = new List<string>();
                List<string> listDonGia = new List<string>();
                List<string> listThanhTien = new List<string>();

                foreach (DataRow row in tbHoaDon.Rows)
                {
                    listMaPhongDat.Add(row["Mã phòng đặt"].ToString());
                    listTenDichVu.Add(row["Tên dịch vụ"].ToString());
                    listNgayThue.Add(row["Số lượng"].ToString());
                    listSoLuong.Add(row["Ngày thuê"].ToString().Replace("12:00:00 AM", ""));
                    listDonGia.Add(row["Đơn giá"].ToString());
                    listThanhTien.Add(row["Thành tiền"].ToString());
                }

                string lstMaPhongDat = String.Join(",", listMaPhongDat.ToArray());
                lstMaPhongDat = lstMaPhongDat.Replace(",", "\n\n");
                string lstTenDichVu = String.Join(",", listTenDichVu.ToArray());
                lstTenDichVu = lstTenDichVu.Replace(",", "\n\n");
                string lstNgayThue = String.Join(",", listNgayThue.ToArray());
                lstNgayThue = lstNgayThue.Replace(",", "\n\n");
                string lstSoLuong = String.Join(",", listSoLuong.ToArray());
                lstSoLuong = lstSoLuong.Replace(",", "\n\n");
                string lstDonGia = String.Join(",", listDonGia.ToArray());
                lstDonGia = lstDonGia.Replace(",", "\n\n");
                string lstThanhTien = String.Join(",", listThanhTien.ToArray());
                lstThanhTien = lstThanhTien.Replace(",", "\n\n");

                this.Parameters["MaPhongDat"].Value = lstMaPhongDat;
                this.Parameters["TenDichVu"].Value = lstTenDichVu;
                this.Parameters["NgayThue"].Value = lstNgayThue;
                this.Parameters["SoLuong"].Value = lstSoLuong;
                this.Parameters["DonGia"].Value = lstDonGia;
                this.Parameters["ThanhTien"].Value = lstThanhTien;

                this.labelTenDichVu.Text = "Tên dịch vụ";
                this.Parameters["TenDoanhThu"].Value = "DỊCH VỤ";
            }

          
            //Load thiết bị
            if (check_report == "Thiết bị")
            {
                initPanel();
                this.panelDichVuVaThietBi.Visible = true;
                List<string> listMaPhongDat = new List<string>();
                List<string> listTenDichVu = new List<string>();
                List<string> listNgayThue = new List<string>();
                List<string> listSoLuong = new List<string>();
                List<string> listDonGia = new List<string>();
                List<string> listThanhTien = new List<string>();

                foreach (DataRow row in tbHoaDon.Rows)
                {
                    listMaPhongDat.Add(row["Mã phòng đặt"].ToString());
                    listTenDichVu.Add(row["Tên dịch vụ"].ToString());
                    listNgayThue.Add(row["Số lượng"].ToString());
                    listSoLuong.Add(row["Ngày thuê"].ToString().Replace("12:00:00 AM", ""));
                    listDonGia.Add(row["Đơn giá"].ToString());
                    listThanhTien.Add(row["Thành tiền"].ToString());
                }

                string lstMaPhongDat = String.Join(",", listMaPhongDat.ToArray());
                lstMaPhongDat = lstMaPhongDat.Replace(",", "\n\n");
                string lstTenDichVu = String.Join(",", listTenDichVu.ToArray());
                lstTenDichVu = lstTenDichVu.Replace(",", "\n\n");
                string lstNgayThue = String.Join(",", listNgayThue.ToArray());
                lstNgayThue = lstNgayThue.Replace(",", "\n\n");
                string lstSoLuong = String.Join(",", listSoLuong.ToArray());
                lstSoLuong = lstSoLuong.Replace(",", "\n\n");
                string lstDonGia = String.Join(",", listDonGia.ToArray());
                lstDonGia = lstDonGia.Replace(",", "\n\n");
                string lstThanhTien = String.Join(",", listThanhTien.ToArray());
                lstThanhTien = lstThanhTien.Replace(",", "\n\n");

                this.Parameters["MaPhongDat"].Value = lstMaPhongDat;
                this.Parameters["TenDichVu"].Value = lstTenDichVu;
                this.Parameters["NgayThue"].Value = lstNgayThue;
                this.Parameters["SoLuong"].Value = lstSoLuong;
                this.Parameters["DonGia"].Value = lstDonGia;
                this.Parameters["ThanhTien"].Value = lstThanhTien;

                this.labelTenDichVu.Text = "Tên thiết bị";
                this.Parameters["TenDoanhThu"].Value = "THIẾT BỊ";
            }
        }
    }
}
