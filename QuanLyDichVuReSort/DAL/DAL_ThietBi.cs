using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using DTO;

namespace DAL
{
    public class DAL_ThietBi :DbConnect
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();

        //Danh sách dịch vụ
        public List<thietbi> DanhSachThietBi()
        {
            List<thietbi> list = new List<thietbi>();
            var tbs = from tb in qlrs.thietbis
                      select tb;
            list = tbs.ToList();
            return list;
        }

        //Lấy thiết bị cuối cùng
        public string LayMaThietBiCuoi()
        {
            var thietbicuoicung = qlrs.thietbis.OrderByDescending(tb => tb.id_thietbi).FirstOrDefault();

            if (thietbicuoicung != null)
            {
                return thietbicuoicung.id_thietbi;
            }
            else
                return "Không có thiết bị";
        }

        //Kiểm tra mã thiết bị có tồn tại khôngS
        public bool KiemTraTonTaiMaTB(string id)
        {
            var tbs = from tb in qlrs.thietbis
                      where tb.id_thietbi.Contains(id)
                      select tb;

            bool thietbitontai = tbs.Any();
            return thietbitontai;

        }

        //Thêm thiết bị
        public bool ThemThietBi(string ma, string ten, int gia)
        {
            thietbi tb = new thietbi();
            tb.id_thietbi = ma;
            tb.ten_thietbi = ten;
            tb.gia = gia;
            try
            {
                qlrs.thietbis.InsertOnSubmit(tb);
                qlrs.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Kiểm tra khóa chính 
        public bool KiemTraKhoaChinh(string ma)
        {
            thietbi thietbi = qlrs.thietbis.Where(row => row.id_thietbi == ma).FirstOrDefault();
            if (thietbi != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Xóa thiết bị
        public bool XoaThietBi(string ma)
        {
            thietbi dv = qlrs.thietbis.Where(row => row.id_thietbi == ma).FirstOrDefault();
            bool kq = false;
            if (dv != null)
            {
                try
                {
                    qlrs.thietbis.DeleteOnSubmit(dv);
                    qlrs.SubmitChanges();
                    kq = true;
                }
                catch (Exception)
                {
                    kq = false;
                }
            }
            return kq;
        }

        //Sửa thiết bị
        public bool SuaThietBi(string tendv, int giadv, string madv)
        {
            thietbi dv = qlrs.thietbis.Where(row => row.id_thietbi == madv).FirstOrDefault();
            bool kq = false;
            if (dv != null)
            {
                try
                {
                    dv.ten_thietbi = tendv;
                    dv.gia = giadv;
                    qlrs.SubmitChanges();
                    kq = true;
                }
                catch (Exception)
                {
                    kq = false;
                }
            }
            return kq;
        }

        //Tìm kiếm thiết bị
        public DataTable TimKiemThietBiTheoTen(string tenthietbi)
        {
            var thietbis = from tb in qlrs.thietbis
                          where tb.ten_thietbi.Contains(tenthietbi)
                          select tb;

            DataTable ketQuaTable = new DataTable();

            ketQuaTable.Columns.Add("id_thietbi", typeof(string));
            ketQuaTable.Columns.Add("ten_thietbi", typeof(string));
            ketQuaTable.Columns.Add("gia", typeof(float));

            foreach (var thietbi in thietbis)
            {
                ketQuaTable.Rows.Add(thietbi.id_thietbi, thietbi.ten_thietbi, thietbi.gia);
            }
            return ketQuaTable;
        }

        // Danh sách mã, tên thiết bị
        public string[] DanhSachMavaTenTB()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachMavaTenTB";
                List<string> list = new List<string>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
                return list.ToArray();
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy giá thiết bị
        public double LayGiaThietBi(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayGiaThietBi";
                cmd.Parameters.AddWithValue("id_thietbi", id);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
