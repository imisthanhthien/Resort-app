namespace DTO

{
    public class DTO_KhachSan
    {
        private string id_khachsan;
        private string tenkhachsan;
        private string diachi;
        public string Id_khachsan
        {
            get { return id_khachsan; }
            set { id_khachsan = value; }
        }

        public string Tenkhachsan
        {
            get { return tenkhachsan; }
            set { tenkhachsan = value; }
        }

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public DTO_KhachSan() { }
    }
}
