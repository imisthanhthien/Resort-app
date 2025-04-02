using System;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
   public class DAL_HoaDon :DbConnect
    {
        // ThanhToán
        public bool ThanhToan(DTO_HoaDon hd)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThanhToan";
                cmd.Parameters.AddWithValue("id_datphong", hd.Id_datphong);
                cmd.Parameters.AddWithValue("id_nhanvien", hd.Id_nhanvien);
                cmd.Parameters.AddWithValue("id_khachhang", hd.Id_khachhang);
                cmd.Parameters.AddWithValue("tongtien", hd.TongTienHD);

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

        // Lấy doanh thu trong ngày
        public string DanhThuTrongNgay()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DanhThuTrongNgay";
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        //Lấy top khách hàng
        public string Top1KhachHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Top1KhachHang";
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        //Doanh thu tháng hiện tại so với tháng trước
        public string TinhTongDoanhThuSoVoiThangTruoc()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TinhTongDoanhThuSoVoiThangTruoc";
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        //Phòng check in nhiều nhất
        public string PhongCheckInNhieuNhat()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PhongCheckInNhieuNhat";
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy tống doanh thu
        public string TinhTongDoanhThu()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TinhTongDoanhThu";
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy thu nhập của tháng 
        public double HoaDonThang(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HoaDonThang";
                cmd.Parameters.AddWithValue("thang", thang);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy thu nhập theo quý
        public double DoanhThuTheoQuy(int quy, int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoanhThuTheoQuy";
                cmd.Parameters.AddWithValue("quy", quy);
                cmd.Parameters.AddWithValue("nam", nam);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy thu nhập theo tháng
        public double DoanhThuTheoThang(int thang, int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DoanhThuTheoThang";
                cmd.Parameters.AddWithValue("Thang", thang);
                cmd.Parameters.AddWithValue("nam", nam);
               string dt = Convert.ToString(cmd.ExecuteScalar());
                if(dt != "")
                {
                    return Convert.ToDouble(dt);
                }
                return 0;
            }
         
            finally
            {
                _conn.Close();
            }   
        }

        // Lấy thu nhập theo năm
        public double DanhThuTheoNam(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhThuTheoNam";
                cmd.Parameters.AddWithValue("nam", nam);
                string dt = Convert.ToString(cmd.ExecuteScalar());
                if (dt != "")
                {
                    return Convert.ToDouble(dt);
                }
                return 0;
            }

            finally
            {
                _conn.Close();
            }
        }

        // Lấy thu nhập theo ngày bắt đầu - kết thúc
        public double LocDoanhThuTheoNgayTuChon(DateTime ngaybatdau, DateTime ngayketthuc)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LocDoanhThuTheoNgayTuChon";
                cmd.Parameters.AddWithValue("ngaybatdau", ngaybatdau);
                cmd.Parameters.AddWithValue("ngayketthuc", ngayketthuc);
                string dt = Convert.ToString(cmd.ExecuteScalar());
                if (dt != "")
                {
                    return Convert.ToDouble(dt);
                }
                return 0;
            }

            finally
            {
                _conn.Close();
            }
        }

        // Danh sách hóa đơn thanh toán
        public DataTable DanhSachHoaDonThanToan()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHoaDonThanToan";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách hóa đơn thanh toán theo ngày
        public DataTable DanhSachHoaDonThanToanTheoNgay(DateTime ngay)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHoaDonThanToanTheoNgay";
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

        // Lấy số đơn đặt phòng trong ngày
        public string SoDonDatPhongTrongNgayTheoHoaDon(DateTime ngay)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonDatPhongTrongNgayTheoHoaDon";
                cmd.Parameters.AddWithValue("ngay", ngay);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền theo ngày
        public string TongTienDatPhongTrongNgayTheoHoaDon(DateTime ngay)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienDatPhongTrongNgayTheoHoaDon";
                cmd.Parameters.AddWithValue("ngay", ngay);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách hóa đơn theo tháng
        public DataTable DanhSachHoaDonThanToanTheoThang(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHoaDonThanToanTheoThang";
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
        public string SoDonDatPhongTrongThangTheoHoaDon(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonDatPhongTrongThangTheoHoaDon";
                cmd.Parameters.AddWithValue("thang", thang);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền theo tháng
        public string TongTienDatPhongTrongThangTheoHoaDon(int thang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienDatPhongTrongThangTheoHoaDon";
                cmd.Parameters.AddWithValue("thang", thang);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách hóa đơn  theo quý
        public DataTable DanhSachHoaDonThanToanTheoQuy(int quy)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHoaDonThanToanTheoQuy";
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
        public string SoDonDatPhongTrongQuyTheoHoaDon(int quy)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonDatPhongTrongQuyTheoHoaDon";
                cmd.Parameters.AddWithValue("quy", quy);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền theo  quý
        public string TongTienDatPhongTrongQuyTheoHoaDon(int quy)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienDatPhongTrongQuyTheoHoaDon";
                cmd.Parameters.AddWithValue("quy", quy);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách hóa đơn  theo năm
        public DataTable DanhSachHoaDonThanToanTheoNam(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachHoaDonThanToanTheoNam";
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

        // Lấy số đơn đặt phòng trong  quý
        public string SoDonDatPhongTrongNamTheoHoaDon(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonDatPhongTrongNamTheoHoaDon";
                cmd.Parameters.AddWithValue("nam", nam);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy tổng tiền theo quý
        public string TongTienDatPhongTrongNamTheoHoaDon(int nam)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TongTienDatPhongTrongNamTheoHoaDon";
                cmd.Parameters.AddWithValue("nam", nam);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Danh sách nhân viên đặt phòng trong hóa đơn 
        public DataTable DanhSachNhanVienDatPhong(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachNhanVienDatPhong";
                cmd.Parameters.AddWithValue("id_nhanvien", id);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách nhân viên thanh toán trong hóa đơn 
        public DataTable DanhSachNhanVienThanhToan(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachNhanVienThanhToan";
                cmd.Parameters.AddWithValue("id_nhanvien", id);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách nhân viên thanh toán trong hóa đơn 
        public DataTable DanhSachKhachHangDatPhong(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachKhachHangDatPhong";
                cmd.Parameters.AddWithValue("id_khachhang", id);
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
