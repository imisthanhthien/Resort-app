using System;
using System.Data;
using DAL;


namespace DDL
{
   public class DLL_DatPhong
    {
       DAL_DatPhong datphong = new DAL_DatPhong();

        public DataTable DanhSachDatPhong()
        {
            return datphong.DanhSachDatPhong();
        }
        public DataTable DanhSachDatPhongVer2()
        {
            return datphong.DanhSachDatPhongVer2();
        }
        public DataTable Locphongtheoloaiphong(int loaiphong)
        {
            return datphong.Locphongtheoloaiphong(loaiphong);
        }
        public DataTable Loctheosonguoio(int soluong)
        {
            return datphong.Loctheosonguoio(soluong);
        }
        public DataTable Loctheosonguoio2(int soluong, int maloai)
        {
            return datphong.Loctheosonguoio2(soluong, maloai);
        }
        public DataTable LocLichSuThaoTac(DateTime date)
        {
            return datphong.LocLichSuThaoTac(date);
        }
        public DataTable LocLichSuDoiPhong(DateTime date)
        {
            return datphong.LocLichSuDoiPhong(date);
        }
        public string LayKhachHangDatPhong(string id)
        {
            return datphong.LayKhachHangDatPhong(id);
        }
        public string ThongTinKhachHanginCMND(string cmnd)
        {
            return datphong.ThongTinKhachHanginCMND(cmnd);
        }
        public string LayMaLoaiPhong(string tenloai)
        {
            return datphong.LayMaLoaiPhong(tenloai);
        }
        public double LayGiaPhongTheoMaPhong(string id)
        {
            return datphong.LayGiaPhongTheoMaPhong(id);
        }
        public string LayDatPhongCuoiCung()
        {
            return datphong.LayDatPhongCuoiCung();
        }
        public int laymathaotaccuoicung()
        {
            return datphong.laymathaotaccuoicung();
        }
        public void SetTrangThaiThucHienDatPHong(int mathuchien)
        {
            datphong.SetTrangThaiThucHienDatPHong(mathuchien);
        }
        public bool ThaoTacDatPhong(string id_khachhang, string id_nhanviendatphong, string id_nhanvienthuchien, string id_phong, string tenphong,
    int loaiphong, float giaphong, float datcoc, DateTime ngaydatphong, DateTime check_in, DateTime check_out, string nguoithuchien, DateTime thoigianthuchien)
        {
            return datphong.ThaoTacDatPhong(id_khachhang, id_nhanviendatphong, id_nhanvienthuchien, id_phong, tenphong, loaiphong, giaphong, datcoc, ngaydatphong, check_in, check_out, nguoithuchien, thoigianthuchien);
        }
        public bool ThemDatPhong(string id_dt, string id_nv, string id_kh, string id_p, DateTime check_in, DateTime check_out, double datcoc, int songuoio)
        {
            return datphong.ThemDatPhong(id_dt, id_nv, id_kh, id_p, check_in, check_out, datcoc, songuoio);
        }
        public bool SuaDatPhong(string id_dt, string id_nv, string id_p, DateTime check_in, DateTime check_out, double datcoc, int songuoio)
        {
            return datphong.SuaDatPhong(id_dt, id_nv, id_p, check_in, check_out, datcoc, songuoio);
        }
        public bool XoaDatPhong(string id)
        {
            return datphong.XoaDatPhong(id);
        }
        public string LayMaDatPhonginPhong(string id)
        {
            return datphong.LayMaDatPhonginPhong(id);
        }
        public bool KiemTraDatMaPhong(string name)
        {
            return datphong.KiemTraDatMaPhong(name);
        }
        public string SoDonDatPhongTrongNgay()
        {
            return datphong.SoDonDatPhongTrongNgay();
        }
        public string SoLuongKhachThueTrongNgay()
        {
            return datphong.SoLuongKhachThueTrongNgay();
        }
        public bool KiemTraTrangThaiPhong(string maphong)
        {
            return datphong.KiemTraTrangThaiPhong(maphong);
        }
        public string LayMaKhachHang(string madatohong)
        {
            return datphong.LayMaKhachHang(madatohong);
        }
    }
}
