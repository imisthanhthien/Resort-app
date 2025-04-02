namespace DTO

{
   public class DTO_LoaiPhong
    {
        private int id_loaiphong;
        private string ten_loaiphong;
        private int gia;

        public int Id_loaiphong
        {
            get { return id_loaiphong; }
            set { id_loaiphong = value; }
        }
        public string Ten_loaiphong
        {
            get { return ten_loaiphong; }
            set { ten_loaiphong = value; }
        }       
        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public DTO_LoaiPhong() { }
        public DTO_LoaiPhong(string ten, int gia) 
        {
            this.ten_loaiphong= ten;
            this.gia = gia;
        }
    }
}
