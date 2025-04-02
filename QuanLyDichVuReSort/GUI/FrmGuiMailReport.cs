using DDL;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmGuiMailReport : Form
    {

        private string result;
        private string tenkhachhang;
        private string recipientEmail;
        private byte[] attachmentData;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        public FrmGuiMailReport(string recipientEmail, string tenkhachhang, byte[] attachmentData)
        {
            InitializeComponent();
            this.recipientEmail = recipientEmail;
            this.tenkhachhang = tenkhachhang;
            this.attachmentData = attachmentData;
        }
        private void SendHoaDon()
        {
            string loginEmail = "hethongquanlyresort102@gmail.com";
            string loginPassword = "Resort123";
            DDL_GuiMail mail = new DDL_GuiMail(loginEmail, loginPassword);
            Result = mail.SendEmailWithAttachment(recipientEmail, tenkhachhang, attachmentData, "Hoadonthanhtoan.pdf");
            pcbLoader.Invoke(new Action(() => Close()));
        }
        private void FrmGuiMailReport_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                //Delay 1.2 giây
                Thread.Sleep(1200);
                SendHoaDon();
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
