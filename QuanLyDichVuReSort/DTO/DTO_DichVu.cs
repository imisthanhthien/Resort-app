namespace DTO

{
  public  class DTO_DichVu
    {
        private string id_dichvu;
        private string ten_dichvu;
        private int gia;
        public string Id_dichvu
        {
            get { return id_dichvu; }
            set { id_dichvu = value; }
        }

        public string Ten_dichvu
        {
            get { return ten_dichvu; }
            set { ten_dichvu = value; }
        }

        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public DTO_DichVu() { }
    }
}
