using System;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
  public  class DAL_ChiTietSuDungTB :DbConnect
    {
        // Danh sách chi tiết thiết bị
        public DataTable DanhSachChiTietTB(string madatphong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachChiTietTB";
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

        // Thêm sử dụng thiết bị
        public bool ThemSDTB(DTO_ChiTietSuDungTB tb)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemSDTB";
                cmd.Parameters.AddWithValue("id_datphong", tb.Id_datphong);
                cmd.Parameters.AddWithValue("id_thietbi", tb.Id_thietbi);
                cmd.Parameters.AddWithValue("sl", tb.Soluong);
                cmd.Parameters.AddWithValue("thanhtien", tb.Tongtien);

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

        // Sửa sử dụng thiết bị
        public bool SuaSDTV(DTO_ChiTietSuDungTB tb)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaSDTV";
                cmd.Parameters.AddWithValue("id_thietbi", tb.Id_thietbi);
                cmd.Parameters.AddWithValue("sl", tb.Soluong);

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

        // Xóa sử dụng thiết bị
        public bool XoaSDTB(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaSDTB";
                cmd.Parameters.AddWithValue("id_thietbi", id);
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
        // Kiểm tra sử dụng thiết bị
        public bool KiemTraThietBiTrung(string id, string id_dt)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KiemTraThietBiTrung";
                cmd.Parameters.AddWithValue("id_thietbi", id);
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

        // Lấy tổng tiền sử dụng thiết bị
        public double? TongTienSuDungTB(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TongTienSuDungTB";
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

        // Danh sách hoá đơn thiết bị
        public DataTable DanhSachThietBiSuDung()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachThietBiSuDung";

                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách hóa đơn thiết bị
        public DataTable DanhSachThietBiThanToanTheoNgay(DateTime ngay)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachThietBiThanToanTheoNgay";
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

        // Lấy số đơn  thiết bị trong ngày
        public string SoDonThietBiTrongNgayTheoHoaDon(DateTime ngay)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonThietBiTrongNgayTheoHoaDon";
                cmd.Parameters.AddWithValue("ngay", ngay);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền thiết bị trong ngày
        public string TongTienThietBiTrongNgayTheoHoaDon(DateTime ngay)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienThietBiTrongNgayTheoHoaDon";
                cmd.Parameters.AddWithValue("ngay", ngay);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách hóa đơn thiết bị theo tháng
        public DataTable DanhSachThietBiThanhToanTheoThang(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachThietBiThanhToanTheoThang";
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

        // Lấy số đơn thiết bị đặt phòng trong tháng
        public string SoDonThietBiTrongThangTheoHoaDon(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonThietBiTrongThangTheoHoaDon";
                cmd.Parameters.AddWithValue("thang", thang);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền thiết bị theo tháng
        public string TongTienThietBiTrongThangTheoHoaDon(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienThietBiTrongThangTheoHoaDon";
                cmd.Parameters.AddWithValue("thang", thang);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách hóa đơn thiết bị theo quý
        public DataTable DanhSachThietBiThanToanTheoQuy(int quy)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachThietBiThanToanTheoQuy";
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

        // Lấy số đơn đặt phòng thiết bị theo quý
        public string SoDonThietBiTrongQuyTheoHoaDon(int quy)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonThietBiTrongQuyTheoHoaDon";
                cmd.Parameters.AddWithValue("quy", quy);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền thiết bị theo quý
        public string TongTienThietBiTrongQuyTheoHoaDon(int quy)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienThietBiTrongQuyTheoHoaDon";
                cmd.Parameters.AddWithValue("quy", quy);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách hóa đơn thiết bị theo năm
        public DataTable DanhSachThietBiThanToanTheoNam(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachThietBiThanToanTheoNam";
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

        // Lấy số đơn đặt phòng thiết bị trong  quý
        public string SoDonThietBiTrongNamTheoHoaDon(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonThietBiTrongNamTheoHoaDon";
                cmd.Parameters.AddWithValue("nam", nam);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền thiết bị theo quý
        public string TongTienThietBiTrongNamTheoHoaDon(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienThietBiTrongNamTheoHoaDon";
                cmd.Parameters.AddWithValue("nam", nam);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách dịch vụ đặt phòng thiết bị trong hóa đơn 
        public DataTable DanhSachThietBiTheoLoai(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachThietBiTheoLoai";
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

        // Danh sách thiết bị theo ID, Name
        public DataTable DanhSachThietBiTheoIDName()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachThietBiTheoIDName";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Danh sách thiết bị theo loại loại phòng
        public DataTable DanhSachThietBiTheoLoaiPhong(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachThietBiTheoLoaiPhong";
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
