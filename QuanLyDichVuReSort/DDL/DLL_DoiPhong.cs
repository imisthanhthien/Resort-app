using System;
using DAL;

namespace DDL
{
    public class DLL_DoiPhong
    {
        DAL_DoiPhong doiphong = new DAL_DoiPhong();
        public bool DoiPhong(string id_phongbandau, string id_phongcandoi, string id_nhanvienthuchien, DateTime ngaythuchien, string lydo)
        {
            return doiphong.DoiPhong(id_phongbandau, id_phongcandoi, id_nhanvienthuchien, ngaythuchien, lydo);
        }
        public bool CapNhapKhiDoiPhong(string id_datphong, string id_nhanvien, string id_phongmoi, string id_phongcu, int songuoio, float giaphongmoi, DateTime check_in, DateTime check_out)
        {
            return doiphong.CapNhapKhiDoiPhong(id_datphong, id_nhanvien, id_phongmoi, id_phongcu, songuoio, giaphongmoi, check_in, check_out);
        }
        public int TinhSoNgayO(DateTime ngayDen, DateTime ngayDi)
        {
            return doiphong.TinhSoNgayO(ngayDen, ngayDi);
        }
        public DateTime LayTime_CheckIn(string madt)
        {
            return doiphong.LayTime_CheckIn(madt);
        }
        public DateTime? LayTime_CheckOut(string madt)
        {
            return doiphong.LayTime_CheckOut(madt);
        }
        public int LaySoNguoiO(string maphongmoi)
        {
            return doiphong.LaySoNguoiO(maphongmoi);
        }
    }
}
