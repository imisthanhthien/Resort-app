using DDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace GUI.Report
{
    public partial class BaoCaoHoaDonThanhToan : DevExpress.XtraReports.UI.XtraReport
    {
        private string maphong, songuoi, songayo, str, taikhoan, doanhthu, tienphong;
        private string[] danhsachNV;
        private char separator = '|';

        private DataTable tbDichVu, tbThietBi;
        DLL_NhanVien nhanvien = new DLL_NhanVien();

        public BaoCaoHoaDonThanhToan(string maphong, string songuoi, string songayo, string taikhoan, string doanhthu, DataTable tbDichVu, DataTable tbThietBi, string tienphong)
        {
            this.maphong = maphong;
            this.songuoi = songuoi;
            this.songayo = songayo;
            this.taikhoan = taikhoan;
            this.doanhthu = doanhthu;
            this.tbDichVu = tbDichVu;
            this.tbThietBi = tbThietBi;
            this.tienphong = tienphong;
            InitializeComponent();
            load_BaoCao();
        }
        private void LoadPanelReport()
        {
            this.paneldichvu.Visible = false;
            this.panelthietbi.Visible = false;
            this.paneltienphong.Visible = false;
            this.paneltong.Visible = false;
        }
     
        private void load_BaoCao()
        {
            string rootDir2 = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); 
            rootDir2 = Directory.GetParent(rootDir2).Parent.FullName; 
            string relativePath2 = @"ImagesResort\heart.png"; 
            string path2 = Path.Combine(rootDir2, relativePath2);

            string rootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            rootDir = Directory.GetParent(rootDir).Parent.FullName;
            string relativePath = @"ImagesResort\logoshop.png"; 
            string path = Path.Combine(rootDir, relativePath); 

            this.Parameters["LogoShop"].Value = path;
            this.Parameters["icon"].Value = path2;
            System.DateTime date = System.DateTime.Now;
            this.Parameters["time"].Value = date.ToString("dd/MM/yyyy") + " " + date.ToString("HH:mm:ss");
            this.Parameters["SoPhong"].Value = maphong;
            this.Parameters["SoNguoi"].Value = songuoi;
            this.Parameters["SoNgay"].Value = songayo;
            
            str = nhanvien.LayIDNameNhanVien(taikhoan);

            if (str != "")
            {
                danhsachNV = str.Split(separator);
                string tennv = danhsachNV[1].Trim();
                this.Parameters["TenNhanVien"].Value = tennv;
            }
            
            //Trường hợp tổng
            if (tbDichVu.Rows.Count != 0 && tbThietBi.Rows.Count != 0)
            {
                LoadPanelReport();
                this.paneltong.Visible = true;

                List<string> listTenDichVu = new List<string>();
                List<string> listSLDichVu = new List<string>();
                List<string> listTongTienDichVu = new List<string>();
                List<string> listDonGiaDichVu = new List<string>();

                foreach (DataRow row in tbDichVu.Rows)
                {
                    listTenDichVu.Add(row["Tên Dịch Vụ"].ToString());
                    listSLDichVu.Add(row["SL"].ToString());
                    listTongTienDichVu.Add(row["Tổng Tiền"].ToString());
                    listDonGiaDichVu.Add(row["Giá"].ToString());
                }

                string lstdv = String.Join(",", listTenDichVu.ToArray());
                lstdv = lstdv.Replace(",", "\n\n");
                string lstsldv = String.Join(",", listSLDichVu.ToArray());
                lstsldv = lstsldv.Replace(",", "\n\n");
                string lstttdv = String.Join(",", listTongTienDichVu.ToArray());
                lstttdv = lstttdv.Replace(",", "\n\n");
                string lstdgdv = String.Join(",", listDonGiaDichVu.ToArray());
                lstdgdv = lstdgdv.Replace(",", "\n\n");


                this.Parameters["TenSanPham"].Value = lstdv;
                this.Parameters["SoLuong"].Value = lstsldv;
                this.Parameters["DonGia"].Value = lstdgdv;
                this.Parameters["ThanhTien"].Value = lstttdv;
      
                List<string> listTenThietBi = new List<string>();
                List<string> listSLThietBi = new List<string>();
                List<string> listTongTienThietBi = new List<string>();
                List<string> SumTongTienThietBi = new List<string>();
                List<string> listDonGiaThietBi = new List<string>();

                foreach (DataRow row in tbThietBi.Rows)
                {
                    listTenThietBi.Add(row["Tên Thiết Bị"].ToString());
                    listSLThietBi.Add(row["SL"].ToString());
                    listTongTienThietBi.Add(row["Tổng Tiền"].ToString());
                    double dongia = double.Parse(row["Giá"].ToString());
                    listDonGiaThietBi.Add(row["Giá"].ToString());
                }
                string lsttb = String.Join(",", listTenThietBi.ToArray());
                lsttb = lsttb.Replace(",", "\n\n");
                string lstsltb = String.Join(",", listSLThietBi.ToArray());
                lstsltb = lstsltb.Replace(",", "\n\n");
                string lsttttb = String.Join(",", listTongTienThietBi.ToArray());
                lsttttb = lsttttb.Replace(",", "\n\n");
                string lstThanhTientb = String.Join(",", SumTongTienThietBi.ToArray());
                lstThanhTientb = lstThanhTientb.Replace(",", "\n\n");
                string lstdgtb = String.Join(",", listDonGiaThietBi.ToArray());
                lstdgtb = lstdgtb.Replace(",", "\n\n");

                this.Parameters["TenSanPhamThietBi"].Value = lsttb;
                this.Parameters["SoLuongThietBi"].Value = lstsltb;
                this.Parameters["DonGiaThietBi"].Value = lstdgtb;
                this.Parameters["ThanhTienThietBi"].Value = lsttttb;

                this.Parameters["TienPhong"].Value = tienphong;
                this.Parameters["TienThanhToan"].Value = doanhthu;

                double thanhtienphong = double.Parse(tienphong) * double.Parse(songayo);
                this.Parameters["ThanhTienPhong"].Value = thanhtienphong.ToString("C");
            }
            else
            {
                LoadPanelReport();
                this.paneltienphong.Visible = true;
                this.Parameters["TienPhong"].Value = tienphong;

                this.Parameters["TienThanhToan"].Value = doanhthu;

                double thanhtienphong = double.Parse(tienphong) * double.Parse(songayo);
                this.Parameters["ThanhTienPhong"].Value = thanhtienphong.ToString("C");
            }

            // Trường hợp chỉ sử dụng dịch vụ
            if (tbDichVu.Rows.Count != 0 && tbThietBi.Rows.Count == 0)
            {
                LoadPanelReport();
                this.paneldichvu.Visible = true;
                List<string> listTenDichVu = new List<string>();
                List<string> listSLDichVu = new List<string>();
                List<string> listTongTienDichVu = new List<string>();

                List<string> listDonGiaDichVu = new List<string>();
                foreach (DataRow row in tbDichVu.Rows)
                {
                    listTenDichVu.Add(row["Tên Dịch Vụ"].ToString());
                    listSLDichVu.Add(row["SL"].ToString());
                    listTongTienDichVu.Add(row["Tổng Tiền"].ToString());

                    listDonGiaDichVu.Add(row["Giá"].ToString());
                }
                string lstdv = String.Join(",", listTenDichVu.ToArray());
                lstdv = lstdv.Replace(",", "\n\n");
                string lstsldv = String.Join(",", listSLDichVu.ToArray());
                lstsldv = lstsldv.Replace(",", "\n\n");
                string lstttdv = String.Join(",", listTongTienDichVu.ToArray());
                lstttdv = lstttdv.Replace(",", "\n\n");
                string lstdgdv = String.Join(",", listDonGiaDichVu.ToArray());
                lstdgdv = lstdgdv.Replace(",", "\n\n");

                this.Parameters["TenSanPham"].Value = lstdv;
                this.Parameters["SoLuong"].Value = lstsldv;
                this.Parameters["DonGia"].Value = lstdgdv;
                this.Parameters["ThanhTien"].Value = lstttdv;
                this.Parameters["TienPhong"].Value = tienphong;

                this.Parameters["TienThanhToan"].Value = doanhthu;

                double thanhtienphong = double.Parse(tienphong) * double.Parse(songayo);
                this.Parameters["ThanhTienPhong"].Value = thanhtienphong.ToString("C");
            }

            //Trường hợp chỉ sử dụng thiết bị
            if (tbThietBi.Rows.Count!=0 && tbDichVu.Rows.Count == 0)
            {
                LoadPanelReport();
                this.panelthietbi.Visible = true;

                List<string> listTenThietBi = new List<string>();
                List<string> listSLThietBi = new List<string>();
                List<string> listTongTienThietBi = new List<string>();
                List<string> SumTongTienThietBi = new List<string>();
                List<string> listDonGiaThietBi = new List<string>();

                foreach (DataRow row in tbThietBi.Rows)
                {
                    listTenThietBi.Add(row["Tên Thiết Bị"].ToString());
                    listSLThietBi.Add(row["SL"].ToString());
                    listTongTienThietBi.Add(row["Tổng Tiền"].ToString());
                    double dongia = double.Parse(row["Giá"].ToString());
                    listDonGiaThietBi.Add(row["Giá"].ToString());
                }

                string lsttb = String.Join(",", listTenThietBi.ToArray());
                lsttb = lsttb.Replace(",", "\n\n");
                string lstsltb = String.Join(",", listSLThietBi.ToArray());
                lstsltb = lstsltb.Replace(",", "\n\n");
                string lsttttb = String.Join(",", listTongTienThietBi.ToArray());
                lsttttb = lsttttb.Replace(",", "\n\n");
                string lstThanhTientb = String.Join(",", SumTongTienThietBi.ToArray());
                lstThanhTientb = lstThanhTientb.Replace(",", "\n\n");
                string lstdgtb = String.Join(",", listDonGiaThietBi.ToArray());
                lstdgtb = lstdgtb.Replace(",", "\n\n");


                this.Parameters["TenSanPhamThietBi"].Value = lsttb;
                this.Parameters["SoLuongThietBi"].Value = lstsltb;
                this.Parameters["DonGiaThietBi"].Value = lstdgtb;
                this.Parameters["ThanhTienThietBi"].Value = lsttttb;

                this.Parameters["TienPhong"].Value = tienphong;
                this.Parameters["TienThanhToan"].Value = doanhthu;

                double thanhtienphong = double.Parse(tienphong) * double.Parse(songayo);
                this.Parameters["ThanhTienPhong"].Value = thanhtienphong.ToString("C");
            }
        }
    }
}
