using System;
using System.Collections.Generic;
using System.Data;
using DAL;

namespace DDL
{
   public class DLL_KhachHang
    {
       DAL_KhachHang khachhang = new DAL_KhachHang();

        public List<khachhang> DanhSachKhachHang()
        {
            return khachhang.DanhSachKhachHang();
        }
        public DataTable DanhSachKhachHangS()
        {
            return khachhang.DanhSachKhachHangS();
        }
        public DataTable TimKiemKhachHang(string name)
        {
            return khachhang.TimKiemKhachHang(name);
        }
        public bool ThemKhachHang(string id, string tenkh, DateTime ngaysinh, string diachi, string sdt, string cmnd, string gioitinh,string email)
        {
            return khachhang.ThemKhachHang(id, tenkh, ngaysinh, diachi, sdt, cmnd, gioitinh, email);
        }
        public bool SuaKhachHang(string id, string tenkh, DateTime ngaysinh, string diachi, string sdt, string cmnd, string gioitinh, string email)
        {
            return khachhang.SuaKhachHang(id, tenkh, ngaysinh, diachi, sdt, cmnd, gioitinh, email);
        }
        public bool XoaKhachHang(string id)
        {
            return khachhang.XoaKhachHang(id);
        }
        public string LayKhachHangCuoiCung()
        {
            return khachhang.LayKhachHangCuoiCung();
        }
        public bool KiemTraTonTaiMaKhachHang(string name)
        {
            return khachhang.KiemTraTonTaiMaKhachHang(name);
        }
        public bool KiemTraTonTaiSDT(string sdt)
        {
            return khachhang.KiemTraTonTaiSDT(sdt);
        }
        public bool KiemTraTonTaiCMND(string cmnd)
        {
            return khachhang.KiemTraTonTaiCMND(cmnd);
        }
        public bool KiemTraTonTaiEmail(string email)
        {
            return khachhang.KiemTraTonTaiEmail(email);
        }
        public string[] LayMaTenKhachHang()
        {
            return khachhang.LayMaTenKhachHang();
        }
    }
}
