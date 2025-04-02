using DTO;
using System;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAL_DuyetPhongOnline : DbConnect
    {
        //Danh sách phòng đặt online (web)
        public DataTable DanhSachDatPhongOnline()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDatPhongOnline";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Duyệt phòng online cập nhập trạng thái đặt phòng "Chưa thanh toán"
        public bool DuyetDatPhongOnline(string id_datphong, string id_nhanvien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DuyetDatPhongOnline";
                cmd.Parameters.AddWithValue("@id_datphong", id_datphong);
                cmd.Parameters.AddWithValue("@id_nhanvien", id_nhanvien);
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

        //Cập nhập trạng thái phòng "Đã đặt phòng"
        public bool CapNhapTrangThaiPhongOnline(string id_phong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CapNhapTrangThaiPhongOnline";
                cmd.Parameters.AddWithValue("@id_phong", id_phong);
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

        //Hủy đặt phòng
        public bool HuyDatPhongOnline(string id_datphong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HuyDatPhongOnline";
                cmd.Parameters.AddWithValue("@id_datphong", id_datphong);
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
    }
}
