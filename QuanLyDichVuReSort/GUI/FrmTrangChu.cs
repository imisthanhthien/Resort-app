using DDL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmTrangChu : Form
    {
        DLL_DatPhong datphong = new DLL_DatPhong();
        DLL_HoaDon hoadon = new DLL_HoaDon ();

        private int number = 1;

        public FrmTrangChu()
        {
            InitializeComponent();
        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            LoadThongTinTrongNgay();
        }
      
        private void loadanh()
        {
            if (number == 9)
            {
                number = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"ImagesResort\{0}.jpg", number);
            number++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loadanh();
        }

        private void LoadThongTinTrongNgay()
        {
            try
            {
                label_sodondatphong.Text = datphong.SoDonDatPhongTrongNgay();
                double danhthu = double.Parse(hoadon.DanhThuTrongNgay());
                label_doanhthungay.Text = danhthu.ToString("N");
                label_soluongkhach.Text = datphong.SoLuongKhachThueTrongNgay();
            }
            catch (Exception) { } 
        }

        public void reload()
        {
            LoadThongTinTrongNgay();
        }

    }
}
