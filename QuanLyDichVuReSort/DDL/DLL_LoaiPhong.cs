using System.Data;
using DAL;

namespace DDL
{
   public class DLL_LoaiPhong
    {
       DAL_LoaiPhong loaiphong = new DAL_LoaiPhong();

        public DataTable DanhSachLoaiPhong()
        {
            return loaiphong.DanhSachLoaiPhong();
        }
        public DataTable DanhSachLoaiPhongTenVaGia()
        {
            return loaiphong.DanhSachLoaiPhongTenVaGia();
        }
        public DataTable TimKiemLoaiPhongTheoTen(string tenloaiphong)
        {
            return loaiphong.TimKiemLoaiPhongTheoTen(tenloaiphong);
        }
        public DataTable TimKiemLoaiPhong(string tenphong)
        {
            return loaiphong.TimKiemLoaiPhong(tenphong);
        }
        public DataTable TimKiemLoaiPhong2(string tenphong)
        {
            return loaiphong.TimKiemLoaiPhong2(tenphong);
        }
        public DataTable TimKiemTheoGia(int gia1, int gia2)
        {
            return loaiphong.TimKiemTheoGia(gia1, gia2);
        }
        public bool ThemLoaiPhong(int maloai, string tenloai, int giaphong)
        {
            return loaiphong.ThemLoaiPhong(maloai,tenloai, giaphong);
        }
        public bool SuaLoaiPhong(int maloai, string tenloai, int giaphong)
        {
            return loaiphong.SuaLoaiPhong(maloai, tenloai, giaphong);
        }
        public int LayMaThietBiCuoi()
        {
            return loaiphong.LayMaThietBiCuoi();
        }
        public bool KiemTraTonTaiMaLoaiPhong(string id)
        {
            return loaiphong.KiemTraTonTaiMaLoaiPhong(id);
        }
        public bool XoaLoaiPhong(int maloai)
        {
            return loaiphong.XoaLoaiPhong(maloai);
        }  
        public string[] MaTenLoaiPhong()
        {
            return loaiphong.MaTenLoaiPhong();
        }
    }
}
