using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using DTO;

namespace DAL
{
   public class DAL_LoaiPhong :DbConnect
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();

        //Danh sách loại phòng
        public DataTable DanhSachLoaiPhong()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachLoaiPhong";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Danh sách loại phòng (tên, giá)
        public DataTable DanhSachLoaiPhongTenVaGia()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachLoaiPhongTenVaGia";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách số lượng, Name of sản phẩm 
        public string[] MaTenLoaiPhong()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MaTenLoaiPhong";
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

        // Tìm kiếm tên loại phòng
        public DataTable TimKiemLoaiPhong(string tenphong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemLoaiPhong";
                cmd.Parameters.AddWithValue("tenphong", tenphong);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Tìm kiếm tên loại phòng
        public DataTable TimKiemLoaiPhong2(string tenphong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemLoaiPhong2";
                cmd.Parameters.AddWithValue("tenphong", tenphong);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Tìm kiếm theo giá 
        public DataTable TimKiemTheoGia(int gia1, int gia2)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemTheoGia";
                cmd.Parameters.AddWithValue("gia1", gia1);
                cmd.Parameters.AddWithValue("gia2", gia2);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Thêm loại phòng
        public bool ThemLoaiPhong(int maloai, string tenloai, int giaphong)
        {
            loaiphong loaiphongs = new loaiphong();

            loaiphongs.id_loaiphong = maloai;
            loaiphongs.ten_loai = tenloai;
            loaiphongs.gia = giaphong;

            try
            {
                qlrs.loaiphongs.InsertOnSubmit(loaiphongs);
                qlrs.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Sửa loại phòng
        public bool SuaLoaiPhong(int maloai, string tenloai, int giaphong)
        {

            loaiphong lp = qlrs.loaiphongs.Where(row => row.id_loaiphong == maloai).FirstOrDefault();
            bool kq = false;
            if (lp != null)
            {
                try
                {
                    lp.ten_loai = tenloai;
                    lp.gia = giaphong;
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

        //Xóa loại phòng
        public bool XoaLoaiPhong(int maloai)
        {
            loaiphong lp = qlrs.loaiphongs.Where(row => row.id_loaiphong == maloai).FirstOrDefault();
            bool kq = false;
            if (lp != null)
            {
                try
                {
                    qlrs.loaiphongs.DeleteOnSubmit(lp);
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

        //Lấy mã loại phòng  cuối cùng
        public int LayMaThietBiCuoi()
        {
            var loaiphongcuoi = qlrs.loaiphongs.OrderByDescending(tb => tb.id_loaiphong).FirstOrDefault();

            if (loaiphongcuoi != null)
            {
                return loaiphongcuoi.id_loaiphong;
            }
            else
                return 0;
        }

        //Kiểm tra mã loại có tồn tại khôngS
        public bool KiemTraTonTaiMaLoaiPhong(string id)
        {
            var loaiphongs = from lp in qlrs.loaiphongs
                      where Convert.ToString(lp.id_loaiphong).Contains(id)
                      select lp;

            bool thietbitontai = loaiphongs.Any();
            return thietbitontai;

        }

        //Tìm kiếm tên loại phòng
        public DataTable TimKiemLoaiPhongTheoTen(string tenloaiphong)
        {
            var loaiphongs = from lp in qlrs.loaiphongs
                           where lp.ten_loai.Contains(tenloaiphong)
                           select lp;
            DataTable ketQuaTable = new DataTable();

            ketQuaTable.Columns.Add("id_loaiphong", typeof(int));
            ketQuaTable.Columns.Add("ten_loai", typeof(string));
            ketQuaTable.Columns.Add("gia", typeof(float));

            foreach (var loaiphong in loaiphongs)
            {
                ketQuaTable.Rows.Add(loaiphong.id_loaiphong, loaiphong.ten_loai, loaiphong.gia);
            }
            return ketQuaTable;
        }

    }
}
