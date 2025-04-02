namespace DTO

{
   public class DTO_ThietBi
    {
        private string id_thietbi;
        private string ten_thietbi;
        private int gia;
        public string Id_thietbi
        {
            get { return id_thietbi; }
            set { id_thietbi = value; }
        }      
        public string Ten_thietbi
        {
            get { return ten_thietbi; }
            set { ten_thietbi = value; }
        }
        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        public DTO_ThietBi() { }
    }
}
