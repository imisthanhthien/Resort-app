using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DanhSachPhong : UserControl
    {
        public DanhSachPhong()
        {
            InitializeComponent();
        }

        private string _maphong;
        private string _tenphong;
        private string _trangthai;
        private string _thoigian;
        private string _tenkhachhang;

        public string Maphong
        {
            get { return _maphong; }
            set { _maphong = value; label_maphong.Text = value; }
        }
        public string Tenphong 
        {
            get { return _tenphong; }
            set { _tenphong = value; label_tenphong.Text = value; }
        }
        public string Trangthai
        {
            get { return _trangthai; }
            set { _trangthai = value; label_trangthai.Text = value; }
        }
        public string Thoigian 
        {
            get { return _thoigian; }
            set { _thoigian = value; }
        }
        public string Tenkhachhang 
        {
            get { return _tenkhachhang; }
            set { _tenkhachhang = value; }
        }
        public async Task LoadDataAsync(string maphong, string tenphong, string trangthai)
        {
            Maphong = maphong;
            Tenphong = tenphong;
            Trangthai = trangthai;
            await Task.Delay(0); 
        }
        public void UpdatePanelColor(Color color, Color color2)
        {
            if (pannel_main != null)
            {
                pannel_main.FillColor = color;
                pannel_main.FillColor2 = color2;
            }
        }
        public void SetTenKhachHang(string tenkh)
        {
            label_tenkhachhang.Visible = true;
            label_tenkhachhang.Text = tenkh;
        }
        public void setSongayo(int songayo)
        {
            label_thoigian.Text = Convert.ToString(songayo) + " Ngày";
        }
      
    }
}
