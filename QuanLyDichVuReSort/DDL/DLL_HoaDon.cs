using System;
using System.Data;
using DAL;
using DTO;


namespace DDL
{
  public  class DLL_HoaDon
    {
      DAL_HoaDon hoadon = new DAL_HoaDon();

        public DataTable DanhSachHoaDonThanToan()
        {
            return hoadon.DanhSachHoaDonThanToan();
        }
        public DataTable DanhSachHoaDonThanToanTheoNgay(DateTime ngay)
        {
            return hoadon.DanhSachHoaDonThanToanTheoNgay(ngay);
        }
        public DataTable DanhSachHoaDonThanToanTheoThang(int thang)
        {
            return hoadon.DanhSachHoaDonThanToanTheoThang(thang);
        }
        public DataTable DanhSachHoaDonThanToanTheoQuy(int quy)
        {
            return hoadon.DanhSachHoaDonThanToanTheoQuy(quy);
        }
        public DataTable DanhSachHoaDonThanToanTheoNam(int nam)
        {
            return hoadon.DanhSachHoaDonThanToanTheoNam(nam);
        }
        public DataTable DanhSachNhanVienThanhToan(string id)
        {
            return hoadon.DanhSachNhanVienThanhToan(id);
        }
        public DataTable DanhSachNhanVienDatPhong(string id)
        {
            return hoadon.DanhSachNhanVienDatPhong(id);
        }
        public DataTable DanhSachKhachHangDatPhong(string id)
        {
            return hoadon.DanhSachKhachHangDatPhong(id);
        }
        public bool ThanhToan(DTO_HoaDon hd)
        {
            return hoadon.ThanhToan(hd);
        }
        public string DanhThuTrongNgay()
        {
            return hoadon.DanhThuTrongNgay();
        }
        public string Top1KhachHang()
        {
            return hoadon.Top1KhachHang();
        }
        public string TinhTongDoanhThuSoVoiThangTruoc()
        {
            return hoadon.TinhTongDoanhThuSoVoiThangTruoc();
        }
        public string PhongCheckInNhieuNhat()
        {
            return hoadon.PhongCheckInNhieuNhat();
        }
        public double HoaDonThang(int thang)
        {
            return hoadon.HoaDonThang(thang);
        }
        public string TinhTongDoanhThu()
        {
            return hoadon.TinhTongDoanhThu();   
        }
        public double DoanhThuTheoQuy(int quy, int nam)
        {
            return hoadon.DoanhThuTheoQuy(quy,nam);
        }
        public double DoanhThuTheoThang(int thang, int nam)
        {
            return hoadon.DoanhThuTheoThang(thang,nam);
        }
        public double DanhThuTheoNam(int nam)
        {
            return hoadon.DanhThuTheoNam(nam);
        }
        public double LocDoanhThuTheoNgayTuChon(DateTime ngaybatdau, DateTime ngayketthuc)
        {
            return hoadon.LocDoanhThuTheoNgayTuChon(ngaybatdau, ngayketthuc);
        }
        public string SoDonDatPhongTrongNgayTheoHoaDon(DateTime ngay)
        {
            return hoadon.SoDonDatPhongTrongNgayTheoHoaDon(ngay);
        }
        public string TongTienDatPhongTrongNgayTheoHoaDon(DateTime ngay)
        {
            return hoadon.TongTienDatPhongTrongNgayTheoHoaDon(ngay);
        }

        public string SoDonDatPhongTrongThangTheoHoaDon(int thang)
        {
            return hoadon.SoDonDatPhongTrongThangTheoHoaDon(thang);
        }
        public string TongTienDatPhongTrongThangTheoHoaDon(int thang)
        {
            return hoadon.TongTienDatPhongTrongThangTheoHoaDon(thang);
        }
        public string SoDonDatPhongTrongQuyTheoHoaDon(int quy)
        {
            return hoadon.SoDonDatPhongTrongQuyTheoHoaDon(quy);
        }
        public string TongTienDatPhongTrongQuyTheoHoaDon(int quy)
        {
            return hoadon.TongTienDatPhongTrongQuyTheoHoaDon(quy);
        }
        public string SoDonDatPhongTrongNamTheoHoaDon(int nam)
        {
            return hoadon.SoDonDatPhongTrongNamTheoHoaDon(nam);
        }
        public string TongTienDatPhongTrongNamTheoHoaDon(int nam)
        {
            return hoadon.TongTienDatPhongTrongNamTheoHoaDon(nam);
        }
    }
}
