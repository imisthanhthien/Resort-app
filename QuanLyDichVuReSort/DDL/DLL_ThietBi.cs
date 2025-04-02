using System.Collections.Generic;
using System.Data;
using DAL;

namespace DDL
{
    public class DLL_ThietBi
    {
        DAL_ThietBi thietbi = new DAL_ThietBi();

        public List<thietbi> DanhSachThietBi()
        {
            return thietbi.DanhSachThietBi();
        }
        public DataTable TimKiemThietBiTheoTen(string tenthietbi)
        {
            return thietbi.TimKiemThietBiTheoTen(tenthietbi);
        }
        public bool ThemThietBi(string ma, string ten, int gia)
        {
            return thietbi.ThemThietBi(ma, ten, gia);
        }
        public bool KiemTraKhoaChinh(string ma)
        {
            return thietbi.KiemTraKhoaChinh(ma);
        }
        public bool XoaThietBi(string ma)
        {
            return thietbi.XoaThietBi(ma);
        }
        public bool SuaThietBi(string tendv, int giadv, string madv)
        {
            return thietbi.SuaThietBi(tendv, giadv, madv);
        }
        public string[] DanhSachMavaTenTB()
        {
            return thietbi.DanhSachMavaTenTB();
        }
        public double LayGiaThietBi(string id)
        {
            return thietbi.LayGiaThietBi(id);
        }
        public bool KiemTraTonTaiMaTB(string id)
        {
            return thietbi.KiemTraTonTaiMaTB(id);
        }
        public string LayMaThietBiCuoi()
        {
            return thietbi.LayMaThietBiCuoi();
        }
    }
}
