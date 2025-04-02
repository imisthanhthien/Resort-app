using DAL;
using System.Data;


namespace DDL
{
    public class DLL_DuyetPhongOnline
    {
        DAL_DuyetPhongOnline dalduyetphong = new DAL_DuyetPhongOnline();

        public DataTable DanhSachDatPhongOnline()
        {
            return dalduyetphong.DanhSachDatPhongOnline();
        }
        public bool DuyetDatPhongOnline(string id_datphong, string id_nhanvien)
        {
            return dalduyetphong.DuyetDatPhongOnline(id_datphong, id_nhanvien);
        }
        public bool CapNhapTrangThaiPhongOnline(string id_phong)
        {
            return dalduyetphong.CapNhapTrangThaiPhongOnline(id_phong);
        }
        public bool HuyDatPhongOnline(string id_datphong)
        {
            return dalduyetphong.HuyDatPhongOnline(id_datphong);
        }
    }
}
