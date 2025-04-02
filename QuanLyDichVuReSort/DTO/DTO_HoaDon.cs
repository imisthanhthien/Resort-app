using System;

namespace DTO
{
   public class DTO_HoaDon
    {
        private int id_hoadon;
        private string id_datphong;
        private string id_khachhang;
        private string id_nhanvien;
        private double tongTienHD;
        private DateTime ngaylap;
        public int Id_hoadon
        {
            get { return id_hoadon; }
            set { id_hoadon = value; }
        }
        public string Id_datphong
        {
            get { return id_datphong; }
            set { id_datphong = value; }
        }
        public string Id_khachhang
        {
            get { return id_khachhang; }
            set { id_khachhang = value; }
        }
       
        public string Id_nhanvien
        {
            get { return id_nhanvien; }
            set { id_nhanvien = value; }
        }
       
        public double TongTienHD
        {
            get { return tongTienHD; }
            set { tongTienHD = value; }
        }

        public DateTime NgayLap
        {
            get { return ngaylap; }
            set { ngaylap = value; }
        }

        public DTO_HoaDon() { }
        public DTO_HoaDon(string id_dt, string id_nv, string id_kh, double tongtien) 
        {
            this.id_datphong = id_dt;
            this.id_nhanvien = id_nv;
            this.id_khachhang = id_kh;
            this.tongTienHD= tongtien;
        }
    }
}
