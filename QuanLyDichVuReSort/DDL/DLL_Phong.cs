using System.Data;
using DAL;
using DTO;

namespace DDL
{
   public class DLL_Phong
    {
       DAL_Phong phong = new DAL_Phong();

        public DataTable TimKiemPhong(string tenphong)
        {
            return phong.TimKiemPhong(tenphong);
        }
        public DataTable DanhSachPhong()
        {
            return phong.DanhSachPhong();
        }
        public bool ThemPhong(DTO_Phong p)
        {
            return phong.ThemPhong(p);
        }
        public bool SuaPhong(DTO_Phong p)
        {
            return phong.SuaPhong(p);
        }
        public string LayPhongCuoiCung()
        {
            return phong.LayPhongCuoiCung();
        }
        public bool KiemTraMaPhong(string name)
        {
            return phong.KiemTraMaPhong(name);
        }
        public bool XoaPhong(string id)
        {
            return phong.XoaPhong(id);
        }
        public string[] DanhsachTenLoaiPhong()
        {
            return phong.DanhsachTenLoaiPhong();
        }
        public string[] DanhSachPhongTrong()
        {
            return phong.DanhSachPhongTrong();
        }
        public string[] PhongCanDoi(string maphong)
        {
            return phong.PhongCanDoi(maphong);
        }
    }
}
