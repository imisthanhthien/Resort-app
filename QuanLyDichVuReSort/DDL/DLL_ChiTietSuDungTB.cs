using System;
using System.Data;
using DAL;
using DTO;


namespace DDL
{
   public class DLL_ChiTietSuDungTB
    {
       DAL_ChiTietSuDungTB ctsptb = new DAL_ChiTietSuDungTB();

        public DataTable DanhSachChiTietTB(string madatphong)
        {
            return ctsptb.DanhSachChiTietTB(madatphong);
        }
        public DataTable DanhSachThietBiThanToanTheoNgay(DateTime ngay)
        {
            return ctsptb.DanhSachThietBiThanToanTheoNgay(ngay);
        }
        public DataTable DanhSachThietBiThanhToanTheoThang(int thang)
        {
            return ctsptb.DanhSachThietBiThanhToanTheoThang(thang);
        }
        public DataTable DanhSachThietBiThanToanTheoQuy(int quy)
        {
            return ctsptb.DanhSachThietBiThanToanTheoQuy(quy);
        }
        public DataTable DanhSachThietBiThanToanTheoNam(int nam)
        {
            return ctsptb.DanhSachThietBiThanToanTheoNam(nam);
        }
        public DataTable DanhSachThietBiTheoLoai(string id)
        {
            return ctsptb.DanhSachThietBiTheoLoai(id);
        }
        public DataTable DanhSachThietBiTheoIDName()
        {
            return ctsptb.DanhSachThietBiTheoIDName();
        }
        public DataTable DanhSachThietBiTheoLoaiPhong(string id)
        {
            return ctsptb.DanhSachThietBiTheoLoaiPhong(id);
        }
        public DataTable DanhSachThietBiSuDung()
        {
            return ctsptb.DanhSachThietBiSuDung();
        }
        public bool ThemSDTB(DTO_ChiTietSuDungTB tb)
        {
            return ctsptb.ThemSDTB(tb);
        }
        public bool SuaSDTV(DTO_ChiTietSuDungTB tb)
        {
            return ctsptb.SuaSDTV(tb);
        }
        public bool XoaSDTB(string id)
        {
            return ctsptb.XoaSDTB(id);
        }
        public bool KiemTraThietBiTrung(string id, string id_dt)
        {
            return ctsptb.KiemTraThietBiTrung(id, id_dt);
        }
        public double? TongTienSuDungTB(string id)
        {
            return ctsptb.TongTienSuDungTB(id);
        }  
        public string SoDonThietBiTrongNgayTheoHoaDon(DateTime ngay)
        {
            return ctsptb.SoDonThietBiTrongNgayTheoHoaDon(ngay);
        }
        public string TongTienThietBiTrongNgayTheoHoaDon(DateTime ngay)
        {
            return ctsptb.TongTienThietBiTrongNgayTheoHoaDon(ngay);
        }
        public string SoDonThietBiTrongThangTheoHoaDon(int thang)
        {
            return ctsptb.SoDonThietBiTrongThangTheoHoaDon(thang);
        }
        public string TongTienThietBiTrongThangTheoHoaDon(int thang)
        {
            return ctsptb.TongTienThietBiTrongThangTheoHoaDon(thang);
        }
        public string SoDonThietBiTrongQuyTheoHoaDon(int quy)
        {
            return ctsptb.SoDonThietBiTrongQuyTheoHoaDon(quy);
        }
        public string TongTienThietBiTrongQuyTheoHoaDon(int quy)
        {
            return ctsptb.TongTienThietBiTrongQuyTheoHoaDon(quy);
        }
        public string SoDonThietBiTrongNamTheoHoaDon(int nam)
        {
            return ctsptb.SoDonThietBiTrongNamTheoHoaDon(nam);
        }
        public string TongTienThietBiTrongNamTheoHoaDon(int nam)
        {
            return ctsptb.TongTienThietBiTrongNamTheoHoaDon(nam);
        }
    }
}
