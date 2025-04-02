using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DTO;

namespace DAL
{
   public class DAL_KhachHang :DbConnect
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();

        //Danh sách khách hàng
        public List<khachhang> DanhSachKhachHang()
        {
            List<khachhang> list = new List<khachhang>();
            var khs = from kh in qlrs.khachhangs
                      select kh;
            list = khs.ToList();
            return list;
        }

        //Danh sách khách hàng theo ID, Name
        public DataTable DanhSachKhachHangS()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachKhachHangTheoIDName";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        //Thêm khách hàng
        public bool ThemKhachHang(string id, string tenkh, DateTime ngaysinh, string diachi,string sdt, string cmnd, string gioitinh, string email)
        {
            khachhang kh =new khachhang();
            kh.id_khachhang = id;
            kh.ten_khachhang = tenkh;
            kh.ngay_sinh= ngaysinh;
            kh.dia_chi= diachi;
            kh.sdt = sdt;
            kh.cmnd = cmnd;
            kh.gioi_tinh= gioitinh;
            kh.email_khachhang = email;

            try
            {
                qlrs.khachhangs.InsertOnSubmit(kh);
                qlrs.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Sửa khách hàng
        public bool SuaKhachHang(string id, string tenkh, DateTime ngaysinh, string diachi, string sdt, string cmnd, string gioitinh, string email)
        {
            khachhang sua = qlrs.khachhangs.Where(kh => kh.id_khachhang== id).FirstOrDefault();
           
            if(sua != null)
            {
                sua.ten_khachhang= tenkh;
                sua.ngay_sinh= ngaysinh;
                sua.dia_chi= diachi;
                sua.sdt = sdt;
                sua.cmnd = cmnd;
                sua.gioi_tinh= gioitinh;
                sua.email_khachhang = email;
                qlrs.SubmitChanges();
                return true;
            }
            return false;
        }

        //Xóa khách hàng
        public bool XoaKhachHang(string id)
        {
            khachhang xoa = qlrs.khachhangs.Where(kh => kh.id_khachhang == id).FirstOrDefault();

            if(xoa != null) 
            { 
                qlrs.khachhangs.DeleteOnSubmit(xoa);
                qlrs.SubmitChanges();
                return true;
            }
            return false;
        }

        //Tìm kiếm khách hàng theo tên
        public DataTable TimKiemKhachHang(string name)
        {
            var khachhangs = from kh in qlrs.khachhangs
                             where kh.ten_khachhang.Contains(name)
                             select kh;

            DataTable ketQuaTable = new DataTable();

            ketQuaTable.Columns.Add("id_khachhang", typeof(string));
            ketQuaTable.Columns.Add("ten_khachhang", typeof(string));
            ketQuaTable.Columns.Add("ngay_sinh", typeof(DateTime));
            ketQuaTable.Columns.Add("dia_chi", typeof(string));
            ketQuaTable.Columns.Add("sdt", typeof(string));
            ketQuaTable.Columns.Add("cmnd", typeof(string));
            ketQuaTable.Columns.Add("gioi_tinh", typeof(string));
            ketQuaTable.Columns.Add("email_khachhang", typeof(string));
            foreach (var khachhang in khachhangs)
            {
                ketQuaTable.Rows.Add(khachhang.id_khachhang, khachhang.ten_khachhang, khachhang.ngay_sinh, khachhang.dia_chi, khachhang.sdt,khachhang.cmnd,khachhang.gioi_tinh,khachhang.email_khachhang);
            }
            return ketQuaTable;
        }

        //Lấy khách hàng cuối cùng trong bảng
        public string LayKhachHangCuoiCung()
        {
            var khachHangCuoiCung = qlrs.khachhangs.OrderByDescending(kh => kh.id_khachhang).FirstOrDefault();

            if (khachHangCuoiCung != null)
            {
                return khachHangCuoiCung.id_khachhang;
            }
            else
                return "Không có khách hàng";
        }

        //Kiểm tra mã khách hàng có tồn tại khôngS
        public bool KiemTraTonTaiMaKhachHang(string name)
        {
            var khachhangs = from khachhang in qlrs.khachhangs
                          where khachhang.id_khachhang.Contains(name)
                          select khachhang;

            bool khachhangtontai = khachhangs.Any();
            return khachhangtontai;

        }

        //Kiểm tra SĐT tồn tại
        public bool KiemTraTonTaiSDT(string sdt)
        {
            var khachhang = qlrs.khachhangs.FirstOrDefault(kh => kh.sdt == sdt);
            if (khachhang != null)
            {
                return true;
            }
            return false;
        }

        //Kiểm tra CMND tồn tại
        public bool KiemTraTonTaiCMND(string cmnd)
        {
            var khachhang = qlrs.khachhangs.FirstOrDefault(kh => kh.cmnd == cmnd);
            if (khachhang != null)
            {
                return true;
            }
            return false;
        }

        //Kiểm tra Email tồn tại
        public bool KiemTraTonTaiEmail(string email)
        {
            var khachhang = qlrs.khachhangs.FirstOrDefault(kh => kh.email_khachhang == email);
            if (khachhang != null)
            {
                return true;
            }
            return false;
        }

        // Lấy mã và tên khách hàng
        public string[] LayMaTenKhachHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayMaTenKhachHang";
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
