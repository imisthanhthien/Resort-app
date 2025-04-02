using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using DTO;


namespace DAL
{
    public class DAL_Phong : DbConnect
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();

        // Danh sách phòng 
        public DataTable DanhSachPhong()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachPhong";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Thêm phòng
        public bool ThemPhong(DTO_Phong phong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemPhong";
                cmd.Parameters.AddWithValue("id", phong.Id_phong);
                cmd.Parameters.AddWithValue("ten", phong.Tenphong);
                cmd.Parameters.AddWithValue("sl", phong.Soluongnguoi);
                cmd.Parameters.AddWithValue("loai", phong.Id_loaiphong);
                cmd.Parameters.AddWithValue("trangthai", phong.Trangthai);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception) { }

            finally
            {
                _conn.Close();
            }
            return false;


        }

        // Sửa phòng
        public bool SuaPhong(DTO_Phong phong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaPhong";
                cmd.Parameters.AddWithValue("id", phong.Id_phong);
                cmd.Parameters.AddWithValue("ten", phong.Tenphong);
                cmd.Parameters.AddWithValue("sl", phong.Soluongnguoi);
                cmd.Parameters.AddWithValue("loai", phong.Id_loaiphong);
                cmd.Parameters.AddWithValue("trangthai", phong.Trangthai);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception) { }

            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Xóa phòng
        public bool XoaPhong(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaPhong";
                cmd.Parameters.AddWithValue("id", id);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception) { }

            finally
            {
                _conn.Close();
            }
            return false;
        }

        //Lấy phòng cuối cùng
        public string LayPhongCuoiCung()
        {
            var pcuoi = qlrs.phongs.OrderByDescending(kh => kh.id_phong).FirstOrDefault();

            if (pcuoi != null)
            {
                return pcuoi.id_phong;
            }
            else
            {
                return "Không có phòng cuối cùng";
            }
        }

        //Kiểm tra mã phòng có tồn tại không
        public bool KiemTraMaPhong(string id)
        {
            var phongps = from phong in qlrs.phongs
                          where phong.id_phong.Contains(id)
                          select phong;

            bool phongTonTai = phongps.Any();
            return phongTonTai;

        }

        // Tìm kiếm phòng
        public DataTable TimKiemPhong(string tenphong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemPhong";
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

        // Danh sách theo tên phòng
        public string[] DanhsachTenLoaiPhong()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhsachTenLoaiPhong";
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

        // Danh sách phòng trống
        public string[] DanhSachPhongTrong()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachPhongTrong";
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

        // Danh sách phòng cần đổi
        public string[] PhongCanDoi(string maphong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PhongCanDoi";
                cmd.Parameters.AddWithValue("id_phong", maphong);
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
    }
}
