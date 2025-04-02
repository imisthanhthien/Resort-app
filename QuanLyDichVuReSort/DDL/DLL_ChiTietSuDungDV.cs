using System;
using System.Data;
using DAL;
using DTO;

namespace DDL
{
    public class DLL_ChiTietSuDungDV
    {
        DAL_ChiTietSuDungDV ctsddv = new DAL_ChiTietSuDungDV();
        public DataTable DanhSachChiTietDV(string madatphong)
        {
            return ctsddv.DanhSachChiTietDV(madatphong);
        }
        public DataTable DanhSachDichVuThanToanTheoNgay(DateTime ngay)
        {
            return ctsddv.DanhSachDichVuThanToanTheoNgay(ngay);
        }
        public DataTable DanhSachDichVuThanhToanTheoThang(int thang)
        {
            return ctsddv.DanhSachDichVuThanhToanTheoThang(thang);
        }
        public DataTable DanhSachDichVuThanToanTheoQuy(int quy)
        {
            return ctsddv.DanhSachDichVuThanToanTheoQuy(quy);
        }
        public DataTable DanhSachDichVuThanToanTheoNam(int nam)
        {
            return ctsddv.DanhSachDichVuThanToanTheoNam(nam);
        }
        public DataTable DanhSachDichVuTheoLoai(string id)
        {
            return ctsddv.DanhSachDichVuTheoLoai(id);
        }
        public DataTable DanhSachDichVuTheoIDName()
        {
            return ctsddv.DanhSachDichVuTheoIDName();
        }
        public DataTable DanhSachPhongTheoIDName()
        {
            return ctsddv.DanhSachPhongTheoIDName();
        }
        public DataTable DanhSachDichVuTheoLoaiPhong(string id)
        {
            return ctsddv.DanhSachDichVuTheoLoaiPhong(id);
        }
        public DataTable DanhSachDichVuSuDung()
        {
            return ctsddv.DanhSachDichVuSuDung();
        }
        public bool ThemSDDV(DTO_ChiTietSuDungDV dv)
        {
            return ctsddv.ThemSDDV(dv);
        }
        public bool SuaSDDV(DTO_ChiTietSuDungDV dv)
        {
            return ctsddv.SuaSDDV(dv);
        }
        public bool XoaSDDV(string id)
        {
            return ctsddv.XoaSDDV(id);
        }
        public bool KiemTraDichVuTrung(string id, string id_dt)
        {
            return ctsddv.KiemTraDichVuTrung(id, id_dt);
        }
        public double? TongTienSuDungDV(string id)
        {
            return ctsddv.TongTienSuDungDV(id);
        }
        public string SoDonDichVuTrongNgayTheoHoaDon(DateTime ngay)
        {
            return ctsddv.SoDonDichVuTrongNgayTheoHoaDon(ngay);
        }
        public string TongTienDichVuTrongNgayTheoHoaDon(DateTime ngay)
        {
            return ctsddv.TongTienDichVuTrongNgayTheoHoaDon(ngay);
        }
        public string SoDonDichVuTrongThangTheoHoaDon(int thang)
        {
            return ctsddv.SoDonDichVuTrongThangTheoHoaDon(thang);
        }
        public string TongTienDichVuTrongThangTheoHoaDon(int thang)
        {
            return ctsddv.TongTienDichVuTrongThangTheoHoaDon(thang);
        }
        public string SoDonDichVuTrongQuyTheoHoaDon(int quy)
        {
            return ctsddv.SoDonDichVuTrongQuyTheoHoaDon(quy);
        }
        public string TongTienDichVuTrongQuyTheoHoaDon(int quy)
        {
            return ctsddv.TongTienDichVuTrongQuyTheoHoaDon(quy);
        }
        public string SoDonDichVuTrongNamTheoHoaDon(int nam)
        {
            return ctsddv.SoDonDichVuTrongNamTheoHoaDon(nam);
        }
        public string TongTienDichVuTrongNamTheoHoaDon(int nam)
        {
            return ctsddv.TongTienDichVuTrongNamTheoHoaDon(nam);
        }
    } 
}
