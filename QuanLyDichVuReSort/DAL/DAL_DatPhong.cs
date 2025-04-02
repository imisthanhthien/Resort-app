using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using DTO;


namespace DAL
{
   public class DAL_DatPhong :DbConnect
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();

        // Danh sách đặt phòng
        public DataTable DanhSachDatPhong()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDatPhong";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy tên khách hàng đặt phòng
        public string LayKhachHangDatPhong(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayKhachHangDatPhong";
                cmd.Parameters.AddWithValue("id_phong", id);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy mã khách hàng đặt phòng
        public string ThongTinKhachHanginCMND(string cmnd)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ThongTinKhachHanginCMND";
                cmd.Parameters.AddWithValue("cmnd", cmnd);
                return Convert.ToString(cmd.ExecuteScalar());
            }

            finally
            {
                _conn.Close();
            }
        }

        // Lấy mã loại phòng
        public string LayMaLoaiPhong(string tenloai)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayMaLoaiPhong";
                cmd.Parameters.AddWithValue("tenloai", tenloai);
                return Convert.ToString(cmd.ExecuteScalar());
            }

            finally
            {
                _conn.Close();
            }
        }

        // Danh sách đặt phòng 2
        public DataTable DanhSachDatPhongVer2()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachDatPhongVer2";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Lọc phòng theo loại phòng
        public DataTable Locphongtheoloaiphong(int loaiphong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Locphongtheoloaiphong";
                cmd.Parameters.AddWithValue("id", loaiphong);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Tìm kiếm số người ở theo số lượng
        public DataTable Loctheosonguoio(int soluong)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Loctheosonguoio";
                cmd.Parameters.AddWithValue("soluong", soluong);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Tìm kiếm số người ở theo số lượng , mã loại
        public DataTable Loctheosonguoio2(int soluong, int maloai)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Loctheosonguoio2";
                cmd.Parameters.AddWithValue("soluong", soluong);
                cmd.Parameters.AddWithValue("id", maloai);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy giá phòng theo mã phòng
        public double LayGiaPhongTheoMaPhong(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayGiaPhongTheoMaPhong";
                cmd.Parameters.AddWithValue("id", id);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        //Lấy đặt phòng cuối cùng trong danh sách
        public string LayDatPhongCuoiCung()
        {
            var dt = qlrs.datphongs.OrderByDescending(p => p.id_datphong).FirstOrDefault();

            if (dt != null)
            {
                return dt.id_datphong;
            }
            else
                return "Không có gì";
        }


        //Thêm đặt phòng 
        public bool ThemDatPhong(string id_dt, string id_nv, string id_kh, string id_p, DateTime check_in, DateTime check_out, double datcoc, int songuoio)
        {
            datphong datphong = new datphong();
           
            datphong.id_datphong= id_dt;
            datphong.id_nhanvien = id_nv;
            datphong.id_khachhang = id_kh;
            datphong.id_phong = id_p;
            datphong.check_in = check_in;
            datphong.check_out = check_out;
            datphong.dat_coc = datcoc;
            datphong.so_nguoi_o= songuoio;

            datphong.trang_thai = "Chưa thanh toán";
            
            datphong.ngaydat = DateTime.Now;

            phong phong = qlrs.phongs.Where(p => p.id_phong == id_p).FirstOrDefault();
            phong.trang_thai = "Đã đặt phòng";

            try
            {
                qlrs.datphongs.InsertOnSubmit(datphong);
                qlrs.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Sửa đặt phòng
        public bool SuaDatPhong(string id_dt, string id_nv, string id_p, DateTime check_in, DateTime check_out, double datcoc, int songuoio)
        {
            datphong sua = qlrs.datphongs.Where(dt => dt.id_datphong == id_dt).FirstOrDefault();

            if (sua != null)
            {
                sua.id_nhanvien = id_nv;
                sua.id_phong = id_p;
                sua.check_in = check_in;
                sua.check_out = check_out;
                sua.dat_coc = datcoc;
                sua.so_nguoi_o = songuoio;
                qlrs.SubmitChanges();
                return true;
            }
            return false;
        }

        //Xóa đặt phòng
        public bool XoaDatPhong(string id)
        {
            datphong xoa = qlrs.datphongs.Where(dt => dt.id_datphong == id).FirstOrDefault();

            phong phong = qlrs.phongs.Where(p => p.id_phong == xoa.id_phong).FirstOrDefault();
        

            if (xoa != null)
            {
                if(xoa.trang_thai == "Đã thanh toán")
                {
                    return false;
                }  
                else if(phong.trang_thai == "Đang sử dụng")
                {
                    return false;
                }    
                else
                {
                    phong.trang_thai = "Còn trống";
                    qlrs.datphongs.DeleteOnSubmit(xoa);
                    qlrs.SubmitChanges();
                    return true;
                }    
            }
            return false;
        }

        // Lấy mã đặt phòng
        public string LayMaDatPhonginPhong(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayMaDatPhonginPhong";
                cmd.Parameters.AddWithValue("id_phong", id);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        //Kiểm tra mã đặt  phòng có tồn tại không
        public bool KiemTraDatMaPhong(string name)
        {
            var phongps = from phong in qlrs.datphongs
                          where phong.id_datphong.Contains(name)
                          select phong;

            bool phongTonTai = phongps.Any();
            return phongTonTai;
        }

        //Kiểm tra trạng thái phòng
        public bool KiemTraTrangThaiPhong(string maphong)
        {

            var phong = qlrs.phongs.FirstOrDefault(p => p.id_phong == maphong);
            if (phong != null)
            {
                if (phong.trang_thai == "Còn trống") 
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        // Lấy đơn đặt hàng trong ngày
        public string SoDonDatPhongTrongNgay()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoDonDatPhongTrongNgay";
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        // Lấy số lượng khách hàng trong ngày
        public string SoLuongKhachThueTrongNgay()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SoLuongKhachThueTrongNgay";
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }

        }

        //Lấy mã KH từ mã đặt phòng
        public string LayMaKhachHang(string madatohong)
        {
            string makh = "";
            var datphongs = qlrs.datphongs.Where(dt => dt.id_datphong== madatohong).FirstOrDefault();
            if (datphongs!=null)
            {
                makh += datphongs.id_khachhang;
            }
            return makh;
        }

        //Lấy mã thao tác cuối cùng trong bảng
        public int laymathaotaccuoicung()
        {
            var thaotaccuoicungs = qlrs.ThaoTacDatPhongs.OrderByDescending(tt => tt.id_lichsudatphong).FirstOrDefault();

            if (thaotaccuoicungs != null)
            {
                return thaotaccuoicungs.id_lichsudatphong;
            }
            else
            {
                return 0;
            }
        }

        //Thêm thao tác đặt phòng khi nhân viên thay đổi
        public bool ThaoTacDatPhong(string id_khachhang, string id_nhanviendatphong, string id_nhanvienthuchien, string id_phong, string tenphong,
            int loaiphong, float giaphong, float datcoc, DateTime ngaydatphong, DateTime check_in, DateTime check_out, string nguoithuchien, DateTime thoigianthuchien)
        {
            ThaoTacDatPhong thaotac = new ThaoTacDatPhong();
            thaotac.id_khachhang = id_khachhang;
            thaotac.id_nhanvien_datphong = id_nhanviendatphong;
            thaotac.id_nhanvien_thuchien = id_nhanvienthuchien;
            thaotac.id_phong= id_phong;
            thaotac.tenphong= tenphong;
            thaotac.loaiphong = loaiphong;
            thaotac.giaphong = giaphong;
            thaotac.datcoc = datcoc;
            thaotac.ngaydatphong= ngaydatphong;
            thaotac.ngay_check_in= check_in;
            thaotac.ngay_check_out= check_out;
            thaotac.nguoithuchien = nguoithuchien;
            thaotac.thoigianthuchien = thoigianthuchien;

            try
            {
                qlrs.ThaoTacDatPhongs.InsertOnSubmit(thaotac);
                qlrs.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Sét trạng thái thực hiện đặt phòng
        public void SetTrangThaiThucHienDatPHong(int mathuchien)
        {
            ThaoTacDatPhong thuchien = qlrs.ThaoTacDatPhongs.Where(tt => tt.id_lichsudatphong== mathuchien).FirstOrDefault();
            if(thuchien != null)
            {
                thuchien.trangthai = true;
                qlrs.SubmitChanges();
            }    
        }

        // Danh sách đổi phòng
        public DataTable LocLichSuDoiPhong(DateTime date)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LocLichSuDoiPhong";
                cmd.Parameters.AddWithValue("date", date);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách thao tác
        public DataTable LocLichSuThaoTac(DateTime date)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LocLichSuThaoTac";
                cmd.Parameters.AddWithValue("date", date);
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
