using System.Collections.Generic;
using System.Data;
using DAL;

namespace DDL
{
  public  class DLL_DichVu
    {
      DAL_DichVu dichvu = new DAL_DichVu();

        public DataTable TimKiemDichVuTheoTen(string tendichvu)
        {
            return dichvu.TimKiemDichVuTheoTen(tendichvu);
        }
        public List<dichvu> DanhSachDichVu()
        {
            return dichvu.DanhSachDichVu();
        }
        public List<int> GiaDichVu()
        {
            return dichvu.GiaDichVu();
        }
        public List<dichvu> LoadDichVuComboBoxGia(int gia)
        {
            return dichvu.LoadDichVuComboBoxGia(gia);
        }
        public List<dichvu> TimKiemDichVu(string ten)
        {
            return dichvu.TimKiemDichVu(ten);
        }
        public bool ThemDichVu(string madichvu, string tendv, int gia)
        {
            return dichvu.ThemDichVu(madichvu, tendv, gia);
        }
        public bool KiemTraKhoaChinh(string madv)
        {
            return dichvu.KiemTraKhoaChinh(madv);    
        }
        public bool XoaDichVu(string iddichvu)
        {
            return dichvu.XoaDichVu(iddichvu);
        }
        public bool SuaDichVu(string tendv, int giadv, string madv)
        {
            return dichvu.SuaDichVu(tendv, giadv, madv);
        }
        public bool KiemTraTonTaiMaDV(string ma)
        {
            return dichvu.KiemTraTonTaiMaDV(ma);
        }
        public string[] DanhSachMavaTenDV()
        {
            return dichvu.DanhSachMavaTenDV();
        }
        public string LayMaDichVuCuoiCung()
        {
            return dichvu.LayMaDichVuCuoiCung();
        }
        public double LayGiaDichVu(string id)
        {
            return dichvu.LayGiaDichVu(id);
        }
    }
}
