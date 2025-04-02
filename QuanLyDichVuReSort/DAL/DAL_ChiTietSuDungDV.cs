using System;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
  public  class DAL_ChiTietSuDungDV :DbConnect
    {
        // Danh sách chi tiết dịch vụ
        public DataTable DanhSachChiTietDV(string madatphong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachChiTietDV";
                cmd.Parameters.AddWithValue("id_datphong", madatphong);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Thêm sử dụng dịch vụ
        public bool ThemSDDV(DTO_ChiTietSuDungDV dv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemSDDV";
                cmd.Parameters.AddWithValue("id_datphong", dv.Id_datphong);
                cmd.Parameters.AddWithValue("id_dichvu", dv.Id_dichvu);
                cmd.Parameters.AddWithValue("sl", dv.Soluong);
                cmd.Parameters.AddWithValue("thanhtien", dv.Tongtien);

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

        // Sửa sử dụng dịch vụ
        public bool SuaSDDV(DTO_ChiTietSuDungDV dv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaSDDV";
                cmd.Parameters.AddWithValue("id_dichvu", dv.Id_dichvu);
                cmd.Parameters.AddWithValue("sl", dv.Soluong);

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

        // Xóa sử dụng dịch vụ
        public bool XoaSDDV(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaSDDV";
                cmd.Parameters.AddWithValue("id_dichvu", id);
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

        // Kiểm tra sử dụng dịch vụ trùng
        public bool KiemTraDichVuTrung(string id, string id_dt)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KiemTraDichVuTrung";
                cmd.Parameters.AddWithValue("id_dichvu", id);
                cmd.Parameters.AddWithValue("id_datphong", id_dt);
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

        // Lấy tổng tiền sử dụng dịch vụ
        public double? TongTienSuDungDV(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TongTienSuDungDV";
                cmd.Parameters.AddWithValue("id_datphong", id);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDouble(result);
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                _conn.Close();
            }
        }


        // Danh sách hoá đơn dịch vụ sử dụng
        public DataTable DanhSachDichVuSuDung()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDichVuSuDung";
              
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách hóa đơn dịch vụ theo ngày
        public DataTable DanhSachDichVuThanToanTheoNgay(DateTime ngay)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDichVuThanToanTheoNgay";
                cmd.Parameters.AddWithValue("ngay", ngay);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy số đơn dịch vụ trong ngày
        public string SoDonDichVuTrongNgayTheoHoaDon(DateTime ngay)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonDichVuTrongNgayTheoHoaDon";
                cmd.Parameters.AddWithValue("ngay", ngay);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền dịch vụ trong ngày
        public string TongTienDichVuTrongNgayTheoHoaDon(DateTime ngay)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienDichVuTrongNgayTheoHoaDon";
                cmd.Parameters.AddWithValue("ngay", ngay);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách hóa đơn theo tháng
        public DataTable DanhSachDichVuThanhToanTheoThang(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDichVuThanhToanTheoThang";
                cmd.Parameters.AddWithValue("thang", thang);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy số đơn đặt phòng trong tháng
        public string SoDonDichVuTrongThangTheoHoaDon(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonDichVuTrongThangTheoHoaDon";
                cmd.Parameters.AddWithValue("thang", thang);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền dịch vụ theo tháng
        public string TongTienDichVuTrongThangTheoHoaDon(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienDichVuTrongThangTheoHoaDon";
                cmd.Parameters.AddWithValue("thang", thang);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách hóa đơn dịch vụ theo quý
        public DataTable DanhSachDichVuThanToanTheoQuy(int quy)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDichVuThanToanTheoQuy";
                cmd.Parameters.AddWithValue("quy", quy);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }
        // Lấy số đơn đặt phòng trong  quý
        public string SoDonDichVuTrongQuyTheoHoaDon(int quy)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonDichVuTrongQuyTheoHoaDon";
                cmd.Parameters.AddWithValue("quy", quy);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền dịch vụ theo  quý
        public string TongTienDichVuTrongQuyTheoHoaDon(int quy)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienDichVuTrongQuyTheoHoaDon";
                cmd.Parameters.AddWithValue("quy", quy);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách hóa đơn dịch vụ theo năm
        public DataTable DanhSachDichVuThanToanTheoNam(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDichVuThanToanTheoNam";
                cmd.Parameters.AddWithValue("nam", nam);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy số đơn đặt phòng  dịch vụ theo quý
        public string SoDonDichVuTrongNamTheoHoaDon(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonDichVuTrongNamTheoHoaDon";
                cmd.Parameters.AddWithValue("nam", nam);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền dịch vụ theo  quý
        public string TongTienDichVuTrongNamTheoHoaDon(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienDichVuTrongNamTheoHoaDon";
                cmd.Parameters.AddWithValue("nam", nam);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách dịch vụ đặt phòng trong hóa đơn 
        public DataTable DanhSachDichVuTheoLoai(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDichVuTheoLoai";
                cmd.Parameters.AddWithValue("id", id);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách dịch vụ theo ID, Name
        public DataTable DanhSachDichVuTheoIDName()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDichVuTheoIDName";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách dịch vụ theo ID, Name
        public DataTable DanhSachPhongTheoIDName()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachPhongTheoIDName";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Danh sách dịch vụ theo loại phòng
        public DataTable DanhSachDichVuTheoLoaiPhong(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDichVuTheoLoaiPhong";
                cmd.Parameters.AddWithValue("id", id);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

    }
}

