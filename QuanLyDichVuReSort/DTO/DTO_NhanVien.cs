using System;

namespace DTO
{
    public class DTO_NhanVien
    {
       private string _manhanvien;
       private string _Tennhanvien;
       private DateTime _ngaysinh;
       private string _sdt;
       private string _gioitinh;
       private string _email;
       private string _matkhau;
       private string _tendangnhap;
       private byte[] _hinhanh;
       private int _quyen;

        public string Manhanvien
        {
            get { return _manhanvien; }
            set { _manhanvien = value; }
        }
       
        public string Tennhanvien
        {
            get { return _Tennhanvien; }
            set { _Tennhanvien = value; }
        }
       
        public DateTime Ngaysinh
        {
            get { return _ngaysinh; }
            set { _ngaysinh = value; }
        }
        public string Sdt
        {
            get { return _sdt; }
            set { _sdt = value; }
        }
     
        public string Gioitinh
        {
            get { return _gioitinh; }
            set { _gioitinh = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
      
        public byte[] Hinhanh
        {
            get { return _hinhanh; }
            set { _hinhanh = value; }
        }
       
        public string Tendangnhap
        {
            get { return _tendangnhap; }
            set { _tendangnhap = value; }
        }
      
        public string Matkhau
        {
            get { return _matkhau; }
            set { _matkhau = value; }
        }

        public int Quyen
        {
            get { return _quyen; }
            set { _quyen = value; }
        }
        public DTO_NhanVien() { }

        public DTO_NhanVien(string id, string hoten, DateTime ngaysinh, string sdt, string gioitinh, string email, string taikhoan, string matkhau, int quyen)
        {
            this.Manhanvien = id;
            this.Tennhanvien = hoten;
            this.Ngaysinh = ngaysinh;
            this.Sdt = sdt;
            this.Gioitinh = gioitinh;
            this.Email = email;
            this.Tendangnhap = taikhoan;
            this.Matkhau = matkhau;
            this.Quyen = quyen;
        }
        public DTO_NhanVien(string id, string hoten, DateTime ngaysinh, string sdt, string gioitinh, string email, string taikhoan, int quyen)
        {
            this.Manhanvien = id;
            this.Tennhanvien = hoten;
            this.Ngaysinh = ngaysinh;
            this.Sdt = sdt;
            this.Gioitinh = gioitinh;
            this.Email = email;
            this.Tendangnhap = taikhoan;
            this.Quyen = quyen;
        }
        public DTO_NhanVien(string taikhoan, string hoten, DateTime ngaysinh, string sdt, string gioitinh, string email, byte[] hinhanh)
        {
            this.Tendangnhap = taikhoan;
            this.Tennhanvien = hoten;
            this.Ngaysinh = ngaysinh;
            this.Sdt = sdt;
            this.Gioitinh = gioitinh;
            this.Email = email;
            this.Hinhanh = hinhanh;
        }
    }
}
