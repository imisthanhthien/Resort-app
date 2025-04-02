using System;

namespace DTO
{
   public class DTO_ChiTietSuDungDV
    {
        private string _id_datphong;
        private string _id_dichvu;
        private int soluong;
        private float tongtien;
        private DateTime ngay_dat;
        public string Id_datphong
        {
            get { return _id_datphong; }
            set { _id_datphong = value; }
        }

        public string Id_dichvu
        {
            get { return _id_dichvu; }
            set { _id_dichvu = value; }
        }
      
        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
       
        public float Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
       
        public DateTime Ngay_dat
        {
            get { return ngay_dat; }
            set { ngay_dat = value; }
        }
        public DTO_ChiTietSuDungDV() { }

        public DTO_ChiTietSuDungDV(string id_dt, string id_dv, int soluong, float tongtien)
        {
            this.Id_datphong = id_dt;
            this.Id_dichvu=id_dv;
            this.Soluong = soluong;
            this.tongtien= tongtien;
        }
        public DTO_ChiTietSuDungDV(string id_dv, int soluong)
        {
            this.Id_dichvu = id_dv;
            this.Soluong = soluong;
        }
    }
}
