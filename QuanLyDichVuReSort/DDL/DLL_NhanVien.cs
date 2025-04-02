using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using DAL;
using DTO;

namespace DDL
{
  public  class DLL_NhanVien
    {
      DAL_NhanVien nhanvien = new DAL_NhanVien();

        public bool Login(string taikhoan, string matkhau)
        {
            matkhau = MaHoaMatKhau(matkhau);
            return nhanvien.Login(taikhoan, matkhau);
        }
        public DataTable DanhSachNhanVien()
        {
            return nhanvien.DanhSachNhanVien();
        }
        public DataTable DanhSachNhanVienTheoIDName()
        {
            return nhanvien.DanhSachNhanVienTheoIDName();
        }
        public DataTable DanhSachNhanVienKhongHoatDong()
        {
            return nhanvien.DanhSachNhanVienKhongHoatDong();
        }
        public DataTable TimKiemNhanVien(string hoten)
        {
            return nhanvien.TimKiemNhanVien(hoten);
        }
        public byte[] LayAnhNhanVien(string taikhoan)
        {
            return nhanvien.LayAnhNhanVien(taikhoan);
        }
        public bool IsExistTaiKhoan(string taikhoan)
        {
            return nhanvien.IsExistTaiKhoan(taikhoan);
        }
        public bool TrangThaiNhanVien(string taikhoan)
        {
            return nhanvien.TrangThaiNhanVien(taikhoan);
        }
        public bool CapNhapThongTinNhanVien(DTO_NhanVien nv)
        {
            return nhanvien.CapNhapThongTinNhanVien(nv);
        }
        public string GetQuyen(string taikhoan)
        {
            return nhanvien.GetQuyen(taikhoan);
        }
        public bool CapNhatMatKhauNhanVien(string email, string matkhau)
        {
            matkhau = MaHoaMatKhau(matkhau);
            return nhanvien.CapNhatMatKhauNhanVien(email, matkhau);
        }
        public string LayChucVuNhanVien(string email)
        {
            return nhanvien.LayChucVuNhanVien(email);
        }
        public bool ThemNhanVien(DTO_NhanVien nv)
        {
            nv.Matkhau = MaHoaMatKhau(nv.Matkhau);
            return nhanvien.ThemNhanVien(nv);
        }
        public bool SuaNhanVien(DTO_NhanVien nv)
        {
            return nhanvien.SuaNhanVien(nv);
        }
        public bool XoaNhanVien(string id)
        {
            return nhanvien.XoaNhanVien(id);
        }
        public string LayMailNhanVien(string taikhoan)
        {
            return nhanvien.LayMailNhanVien(taikhoan);
        }
        public string LayNameChucVuNhanVien(string taikhoan)
        {
            return nhanvien.LayNameChucVuNhanVien(taikhoan);
        }
        public bool IsExistEmail(string email)
        {
            return nhanvien.IsExistEmail(email);
        }
        public bool UpdatePassword(string email, string matkhau)
        {
            matkhau = MaHoaMatKhau(matkhau);
            return nhanvien.UpdatePassword(email, matkhau);
        }
        public bool ThayDoiMatKhauNhanVien(string taikhoan, string oldPassword, string newPassword)
        {
            oldPassword = MaHoaMatKhau(oldPassword);
            newPassword = MaHoaMatKhau(newPassword);
            return nhanvien.ThayDoiMatKhauNhanVien(taikhoan, oldPassword, newPassword);
        }
        public string LayMaNhanVienCuoi()
        {
            return nhanvien.LayMaNhanVienCuoi();
        }
        public string LayIDNameNhanVien(string taikhoan)
        {
            return nhanvien.LayIDNameNhanVien(taikhoan);
        }
        public bool KiemTraTonTaiMaNhanVien(string id)
        {
            return nhanvien.KiemTraTonTaiMaNhanVien(id);
        }
        public bool KiemTraTonTaiEmail(string email)
        {
            return nhanvien.KiemTraTonTaiEmail(email);
        }
        public bool KiemTraTonTaiTaiKhoan(string taikhoan)
        {
            return nhanvien.KiemTraTonTaiTaiKhoan(taikhoan);
        }
        public bool KiemTraTonTaiSDT(string sdt)
        {
            return nhanvien.KiemTraTonTaiSDT(sdt);
        }


        // Mã hóa mật khẩu
        private string MaHoaMatKhau(string matkhau)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(matkhau));
            StringBuilder builder = new StringBuilder();
            foreach (var item in encrypt)
            {
                builder.Append(item.ToString());
            }
            return builder.ToString();
        }

        //Ramdom mật khẩu ngẫu nhiên
        public string GetRandomPassword()
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(r.Next(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
      
        //Ramdom chuỗi string ngẫu nhiên
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random r = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToUpper();
            }
            else return builder.ToString().ToLower();
        }
    }
}
