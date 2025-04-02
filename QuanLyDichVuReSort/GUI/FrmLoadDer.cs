using DevExpress.XtraReports.UI;
using GUI.Report;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace GUI
{
    public partial class FrmLoadDer : Form
    {
        private string cbbthongke, cbbthongketheo, sohoadon, taikhoan, tongtien, check_report;
        private string index, thang;
        string soxuat;
        private double DoanhThu;
        private bool check_nam;


        private DataTable tbTable;
        public FrmLoadDer(DataTable tbTable, string taikhoan, string cbbthongke, string cbbthongketheo, string sohoadon, string tongtien, string check_report)
        {
            this.tbTable = tbTable;
            this.taikhoan = taikhoan;
            this.sohoadon = sohoadon;
            this.cbbthongke = cbbthongke;
            this.cbbthongketheo = cbbthongketheo;
            this.tongtien = tongtien;
            this.check_report = check_report;
            InitializeComponent();
        }
        public FrmLoadDer(string index, string taikhoan, string thang, double DoanhThu, string soxuat)
        {
            this.DoanhThu = DoanhThu;
            this.index = index;
            this.taikhoan = taikhoan;
            this.thang = thang;
            this.soxuat = soxuat;
            InitializeComponent();

        }
        public FrmLoadDer(string index, string taikhoan, string thang, string soxuat)
        {
            this.index = index;
            this.taikhoan = taikhoan;
            this.thang = thang;
            this.soxuat = soxuat;
            InitializeComponent();
        }
        public FrmLoadDer(string taikhoan, bool check_nam, string thang, string soxuat)
        {
            this.taikhoan = taikhoan;
            this.check_nam = check_nam;
            this.thang = thang;
            this.soxuat = soxuat;
            InitializeComponent();
        }

        private void Doanhthutongtheothang()
        {
            BaoCaoTongQuan bc = new BaoCaoTongQuan(index, taikhoan, thang, DoanhThu);
            pcbLoader.Invoke(new Action(() => Close()));
            bc.CreateDocument();
            bc.Parameters.Clear();
            bc.ShowPreviewDialog();
        }
        private void Doanhthutongtheonam()
        {
            BaoCaoTongQuan bc = new BaoCaoTongQuan(taikhoan, true, thang);
            pcbLoader.Invoke(new Action(() => Close()));
            bc.CreateDocument();
            bc.Parameters.Clear();
            bc.ShowPreviewDialog();
        }
        private void Doanhthutongtheoquy()
        {
            BaoCaoTongQuan bc = new BaoCaoTongQuan(index, taikhoan, thang);
            pcbLoader.Invoke(new Action(() => Close()));
            bc.CreateDocument();
            bc.Parameters.Clear();
            bc.ShowPreviewDialog();
        }
        private void Send()
        {
            BaoCaoDatPhong bc = new BaoCaoDatPhong(tbTable, taikhoan, cbbthongke, cbbthongketheo, sohoadon, tongtien, check_report);
            pcbLoader.Invoke(new Action(() => Close()));
            bc.CreateDocument();
            bc.Parameters.Clear();
            bc.ShowPreviewDialog();
        }

        private void FrmLoadDer_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(999);
                if (soxuat == "1")
                {
                    this.Invoke(new Action(Doanhthutongtheothang));
                }
                else if (soxuat == "2")
                {
                    this.Invoke(new Action(Doanhthutongtheoquy));
                }
                else if (soxuat == "3")
                {
                    this.Invoke(new Action(Doanhthutongtheonam));
                }
                else
                    this.Invoke(new Action(Send));
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
