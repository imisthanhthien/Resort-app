using DDL;
using DevExpress.XtraReports.UI;
using System;
using System.IO;
using System.Reflection;

namespace GUI.Report
{
    public partial class BaoCaoTongQuan : DevExpress.XtraReports.UI.XtraReport
    {
        private XtraReport report;
        DLL_HoaDon hoadon = new DLL_HoaDon();
        DLL_NhanVien nhanvien = new DLL_NhanVien();

        private string taikhoan, index;
        private string str, thang;
        private string[] danhsachNV;
        private string[] strlistkhachhang, strlistphong;
        private string strkh, strphong;
        private double DoanhThu;
        private bool check_nam;
        private char separator = '|';

        public BaoCaoTongQuan(string index, string taikhoan, string thang, double DoanhThu)
        {
            this.DoanhThu = DoanhThu;
            this.index = index;
            this.taikhoan = taikhoan;
            this.thang = thang;
            InitializeComponent();
            Load_Report();
        }
        public BaoCaoTongQuan(string index, string taikhoan,string thang)
        {
            this.index = index;
            this.taikhoan = taikhoan;
            this.thang = thang;
            InitializeComponent();
            Load_Report();
        }
        public BaoCaoTongQuan(string taikhoan, bool check_nam, string thang)
        {
            this.taikhoan = taikhoan;
            this.check_nam = check_nam;
            this.thang = thang;
            InitializeComponent();
            Load_Report();
        }
        private void SetTable()
        {
            tbTong.Visible = false;
            tbQuy1.Visible = false;
            tbQuy11.Visible = false;
            tbQuy2.Visible = false;
            tbQuy3.Visible = false;
            tbQuy4.Visible = false;
            tableCustomThang.Visible = false;
        }
        public void Load_Report()
        {
            report = new XtraReport();

            strkh = hoadon.Top1KhachHang();
            strlistkhachhang = strkh.Split(separator);

            strphong = hoadon.PhongCheckInNhieuNhat();
            strlistphong = strphong.Split(separator);

            str = nhanvien.LayIDNameNhanVien(taikhoan);

            if (str != "")
            {
                danhsachNV = str.Split(separator);
                string tennv = danhsachNV[1].Trim();
                this.Parameters["TenNhanVien"].Value = tennv;
            }
            
            this.Parameters["TopKhachHang"].Value = strlistkhachhang[1];
            this.Parameters["TopPhong"].Value = strlistphong[1];

            string rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            rootDir = Directory.GetParent(rootDir).Parent.FullName;
            string relativePath = @"ImagesResort\logoshop.png";
            string path = Path.Combine(rootDir, relativePath);

            this.Parameters["LogoShop"].Value = path;
            System.DateTime date = System.DateTime.Now;
            this.Parameters["time"].Value = date.ToString("dd/MM/yyyy") + " " + date.ToString("HH:mm:ss");
            this.Parameters["LogoShop"].Visible = false;
            
            SetTable();

            if (index == "1")
            {
                tbQuy11.Visible = true;
                this.Parameters["Quy"].Value = "QUÝ 1";
                this.Parameters["TienThang1"].Value = hoadon.HoaDonThang(1).ToString("C");
                this.Parameters["TienThang2"].Value = hoadon.HoaDonThang(2).ToString("C");
                this.Parameters["TienThang3"].Value = hoadon.HoaDonThang(3).ToString("C");
                double tong = hoadon.HoaDonThang(1) + hoadon.HoaDonThang(2) + hoadon.HoaDonThang(3);
                this.Parameters["TongDoanhThu"].Value = tong.ToString("C");
            }
            else if (index == "2")
            {
                tbQuy2.Visible = true;
                this.Parameters["Quy"].Value = "QUÝ 2";
                this.Parameters["TienThang4"].Value = hoadon.HoaDonThang(4).ToString("C");
                this.Parameters["TienThang5"].Value = hoadon.HoaDonThang(5).ToString("C");
                this.Parameters["TienThang6"].Value = hoadon.HoaDonThang(6).ToString("C");
                double tong = hoadon.HoaDonThang(4) + hoadon.HoaDonThang(5) + hoadon.HoaDonThang(6);
                this.Parameters["TongDoanhThu"].Value = tong.ToString("C");
            }
            else if (index == "3")
            {
                tbQuy3.Visible = true;
                this.Parameters["Quy"].Value = "QUÝ 3";
                this.Parameters["TienThang7"].Value = hoadon.HoaDonThang(7).ToString("C");
                this.Parameters["TienThang8"].Value = hoadon.HoaDonThang(8).ToString("C");
                this.Parameters["TienThang9"].Value = hoadon.HoaDonThang(9).ToString("C");
                double tong = hoadon.HoaDonThang(7) + hoadon.HoaDonThang(8) + hoadon.HoaDonThang(9);
                this.Parameters["TongDoanhThu"].Value = tong.ToString("C");
            }
            else if (index == "4")
            {
                tbQuy4.Visible = true;
                this.Parameters["Quy"].Value = "QUÝ 4";
                this.Parameters["TienThang10"].Value = hoadon.HoaDonThang(10).ToString("C");
                this.Parameters["TienThang11"].Value = hoadon.HoaDonThang(11).ToString("C");
                this.Parameters["TienThang12"].Value = hoadon.HoaDonThang(12).ToString("C");
                double tong = hoadon.HoaDonThang(10) + hoadon.HoaDonThang(11) + hoadon.HoaDonThang(12);
                this.Parameters["TongDoanhThu"].Value = tong.ToString("C");
            }

            if (check_nam == true)
            {
                //báo cáo doanh thu theo năm
                tbTong.Visible = true;

                int currentYear = DateTime.Now.Year;
                string yearString = currentYear.ToString();

                this.Parameters["Quy"].Value = "NĂM " + yearString;
                this.Parameters["TienThang1"].Value = hoadon.HoaDonThang(1).ToString("C");
                this.Parameters["TienThang2"].Value = hoadon.HoaDonThang(2).ToString("C");
                this.Parameters["TienThang3"].Value = hoadon.HoaDonThang(3).ToString("C");
                this.Parameters["TienThang4"].Value = hoadon.HoaDonThang(4).ToString("C");
                this.Parameters["TienThang5"].Value = hoadon.HoaDonThang(5).ToString("C");
                this.Parameters["TienThang6"].Value = hoadon.HoaDonThang(6).ToString("C");
                this.Parameters["TienThang7"].Value = hoadon.HoaDonThang(7).ToString("C");
                this.Parameters["TienThang8"].Value = hoadon.HoaDonThang(8).ToString("C");
                this.Parameters["TienThang9"].Value = hoadon.HoaDonThang(9).ToString("C");
                this.Parameters["TienThang10"].Value = hoadon.HoaDonThang(10).ToString("C");
                this.Parameters["TienThang11"].Value = hoadon.HoaDonThang(11).ToString("C");
                this.Parameters["TienThang12"].Value = hoadon.HoaDonThang(12).ToString("C");
                this.Parameters["TongDoanhThu"].Value = double.Parse(hoadon.TinhTongDoanhThu()).ToString("C");
            }
            // báo cáo doanh thu  theo tháng
            if (thang != "" && DoanhThu == hoadon.HoaDonThang(int.Parse(thang)))
            {
                SetTable();
                tableCustomThang.Visible = true;
                this.Parameters["TienThangDon"].Value = hoadon.HoaDonThang(int.Parse(thang)).ToString("C");
                this.Parameters["TongDoanhThu"].Value = hoadon.HoaDonThang(int.Parse(thang)).ToString("C");
                this.Parameters["NumberThang"].Value = thang;
                this.Parameters["Quy"].Value = "THÁNG " + thang;
            }
        }
    }
}
