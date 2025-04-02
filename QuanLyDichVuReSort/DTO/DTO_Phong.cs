namespace DTO

{
    public class DTO_Phong
    {
        private string id_phong;
        private int id_loaiphong;
        private string tenphong;
        private int soluongnguoi;
        private string trangthai;

        public string Id_phong
        {
            get { return id_phong; }
            set { id_phong = value; }
        }

        public int Id_loaiphong
        {
            get { return id_loaiphong; }
            set { id_loaiphong = value; }
        }

        public string Tenphong
        {
            get { return tenphong; }
            set { tenphong = value; }
        }

        public int Soluongnguoi
        {
            get { return soluongnguoi; }
            set { soluongnguoi = value; }
        }
        public string Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        public DTO_Phong() { }
        public DTO_Phong(string id, string tenphong, int soluong, int loai, string trangthai)
        {
            this.id_phong = id;
            this.tenphong = tenphong;
            this.soluongnguoi = soluong;
            this.id_loaiphong = loai;
            this.trangthai = trangthai;
        }
    }
}
