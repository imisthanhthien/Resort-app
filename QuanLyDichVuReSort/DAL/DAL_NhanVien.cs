using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DTO;

namespace DAL
{
    public class DAL_NhanVien :DbConnect
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();

        //Kiểm tra đăng nhập của nhân viên
        public bool Login(string taikhoan, string matkhau)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DangNhap";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                cmd.Parameters.AddWithValue("matkhau", matkhau);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Đã xảy ra lỗi vui lòng xem lại!!!");
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Kiểm tra sự tồn tại của tài khoản
        public bool IsExistTaiKhoan(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "IsExistTaiKhoan";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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

        // Kiểm tra trạng thái nhân viên
        public bool TrangThaiNhanVien(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TrangThaiNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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

        // Kiểm tra sự tồn tại của Email nhân viên
        public bool IsExistEmail(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "IsExistEmail";
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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

        // Kiểm tra và cập nhập lại mật khẩu cho nhân viên
        public bool UpdatePassword(string email, string matkhau)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdatePassword";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("matkhau", matkhau);
                if (cmd.ExecuteNonQuery() != 0)
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

        // Lấy quyền của nhân viên 
        public string GetQuyen(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayQuyenNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                return Convert.ToString(cmd.ExecuteScalar());
            }

            finally
            {
                _conn.Close();
            }
          
        }

        // Lấy mã nhân viên cuối cùng
        public string LayMaNhanVienCuoi()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayMaNhanVienCuoi";
                return Convert.ToString(cmd.ExecuteScalar());
            }

            finally
            {
                _conn.Close();
            }

        }

        // Danh sách nhân viên 
        public DataTable DanhSachNhanVien()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachNhanVien";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Danh sách nhân viên theo ID,Name
        public DataTable DanhSachNhanVienTheoIDName()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachNhanVienTheoIDName";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }


        // Danh sách nhân viên không hoạt động
        public DataTable DanhSachNhanVienKhongHoatDong()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachNhanVienKhongHoatDong";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Thêm nhân viên
        public bool ThemNhanVien(DTO_NhanVien nhanvien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemNhanVien";
                cmd.Parameters.AddWithValue("id", nhanvien.Manhanvien);
                cmd.Parameters.AddWithValue("ten", nhanvien.Tennhanvien);
                cmd.Parameters.AddWithValue("ngaysinh", nhanvien.Ngaysinh);
                cmd.Parameters.AddWithValue("sdt", nhanvien.Sdt);
                cmd.Parameters.AddWithValue("gt", nhanvien.Gioitinh);
                cmd.Parameters.AddWithValue("email", nhanvien.Email);
                cmd.Parameters.AddWithValue("taikhoan", nhanvien.Tendangnhap);
                cmd.Parameters.AddWithValue("matkhau", nhanvien.Matkhau);
                cmd.Parameters.AddWithValue("quyen", nhanvien.Quyen);

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

        // Cập nhật nhân viên
        public bool SuaNhanVien(DTO_NhanVien nhanvien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SuaNhanVien";
                cmd.Parameters.AddWithValue("id", nhanvien.Manhanvien);
                cmd.Parameters.AddWithValue("ten", nhanvien.Tennhanvien);
                cmd.Parameters.AddWithValue("ngaysinh", nhanvien.Ngaysinh);
                cmd.Parameters.AddWithValue("sdt", nhanvien.Sdt);
                cmd.Parameters.AddWithValue("gt", nhanvien.Gioitinh);
                cmd.Parameters.AddWithValue("email", nhanvien.Email);
                cmd.Parameters.AddWithValue("taikhoan", nhanvien.Tendangnhap);       
                cmd.Parameters.AddWithValue("quyen", nhanvien.Quyen);

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

        // Xóa nhân viên
        public bool XoaNhanVien(string id)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XoaNhanVien";
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

        // Tìm kiếm nhân viên
        public DataTable TimKiemNhanVien(string hoten)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TimKiemNhanVien";
                cmd.Parameters.AddWithValue("Hoten", hoten);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }

        // Kiểm tra và cập nhập lại mật khẩu cho nhân viên
        public bool CapNhatMatKhauNhanVien(string email, string matkhau)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ThayDoiMatKhau";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("matkhau", matkhau);
                if (cmd.ExecuteNonQuery() != 0)
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

        // Lấy chức vụ của nhân viên 
        public string LayChucVuNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayChucVuNhanVien";
                cmd.Parameters.AddWithValue("email", email);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // Lấy Mail nhân viên
        public string LayMailNhanVien(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayMailNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        //Lấy tên và quyền nhân viên
        public string LayNameChucVuNhanVien(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayNameChucVuNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        //Lấy id và tên nhân viên
        public string LayIDNameNhanVien(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LayIDNameNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                return Convert.ToString(cmd.ExecuteScalar());
            }
            finally
            {
                _conn.Close();
            }
        }

        // Thay đổi mật khẩu chức vụ của nhân viên
        public bool ThayDoiMatKhauNhanVien(string taikhoan, string oldPassword, string newPassword)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ThayDoiMatKhauNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);
                cmd.Parameters.AddWithValue("oldPassword", oldPassword);
                cmd.Parameters.AddWithValue("newPassword", newPassword);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
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

        //Kiểm tra nhân viên có tồn tại không
        public bool KiemTraTonTaiMaNhanVien(string id)
        {
            var nhanviens = from nhanvien in qlrs.nhanviens
                          where nhanvien.id_nhanvien.Contains(id)
                          select nhanvien;

            bool nhanvientontai = nhanviens.Any();
            return nhanvientontai;

        }

        //Kiểm tra email tồn tại
        public bool KiemTraTonTaiEmail(string email)
        {      
            var nhanvien = qlrs.nhanviens.FirstOrDefault(nv => nv.email == email);
            if (nhanvien != null)
            {
                return true;
            }
            return false;
        }

        //Kiểm tra tài khoản tồn tại
        public bool KiemTraTonTaiTaiKhoan(string taikhoan)
        {
            var nhanvien = qlrs.nhanviens.FirstOrDefault(nv => nv.ten_dang_nhap == taikhoan);
            if (nhanvien != null)
            {
                return true;
            }
            return false;
        }

        //Kiểm tra SĐT tồn tại
        public bool KiemTraTonTaiSDT(string sdt)
        {
            var nhanvien = qlrs.nhanviens.FirstOrDefault(nv => nv.sdt == sdt);
            if (nhanvien != null)
            {
                return true;
            }
            return false;
        }

        //Cập nhập thông tin nhân viên
        public bool CapNhapThongTinNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CapNhapThongTinNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", nv.Tendangnhap);
                cmd.Parameters.AddWithValue("hoten", nv.Tennhanvien);
                cmd.Parameters.AddWithValue("ngaysinh", nv.Ngaysinh);
                cmd.Parameters.AddWithValue("sdt", nv.Sdt);
                cmd.Parameters.AddWithValue("gioitinh", nv.Gioitinh);
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("hinhanh", nv.Hinhanh);
            
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

        // Lấy ảnh nhân viên
        public byte[] LayAnhNhanVien(string taikhoan)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayAnhNhanVien";
                cmd.Parameters.AddWithValue("taikhoan", taikhoan);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader["hinh_anh"] != DBNull.Value)
                        {
                            return (byte[])reader["hinh_anh"];
                        }
                    }
                }
            }
            finally
            {
                _conn.Close();
            }
            return null;
        }
    }
}
