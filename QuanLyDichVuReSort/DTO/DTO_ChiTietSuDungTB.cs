using System;

namespace DTO
{
  public  class DTO_ChiTietSuDungTB
    {
        private string _id_datphong;
        private string _id_thietbi;
        private int soluong;
        private float tongtien;
        private DateTime ngay_dat;

        public string Id_datphong
        {
            get { return _id_datphong; }
            set { _id_datphong = value; }
        }
        public string Id_thietbi
        {
            get { return _id_thietbi; }
            set { _id_thietbi = value; }
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
        public DTO_ChiTietSuDungTB() { }

        public DTO_ChiTietSuDungTB(string id_dt, string id_tb, int soluong, float tongtien)
        {
            this.Id_datphong = id_dt;
            this.Id_thietbi = id_tb;
            this.Soluong = soluong;
            this.tongtien = tongtien;
        }
        public DTO_ChiTietSuDungTB(string id_tb, int soluong)
        {
            this.Id_thietbi = id_tb;
            this.Soluong = soluong;
        }
    }
}
