using System;

namespace DTO
{
    public class DTO_KhachHang
    {
        private string id_khachhang;
        private string ten_khachhang;
        private DateTime ngaysinh;
        private string diachi;
        private string sdt;
        private string cmnd;
        private string gioithinh;
        public string Id_khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }

        public string Ten_khachhang
        {
            get { return ten_khachhang; }
            set { ten_khachhang = value; }
        }

        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        public string Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }

        public string Gioithinh
        {
            get { return gioithinh; }
            set { gioithinh = value; }
        }
        public DTO_KhachHang() { }
    }
}
