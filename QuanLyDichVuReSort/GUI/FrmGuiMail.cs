using System;
using System.Threading;
using System.Windows.Forms;
using DDL;

namespace GUI
{
    public partial class FrmGuiMail : Form
    {
        private string result;
        private string taikhoan;
        private string email; 
        private string password; 
        private bool isUpdate;

        public string Result
        {
            get { return result; }
            set { result = value; }
        }

        public FrmGuiMail(string email, string taikhoan, string pass, bool isUpdate = false)
        {
            InitializeComponent();
            this.email = email;
            this.taikhoan = taikhoan;
            this.password = pass;
            this.isUpdate = isUpdate;
        }

        private void Send()
        {
            string loginEmail = "hethongquanlyresort102@gmail.com";
            string loginPassword = "Resort123";
            DDL_GuiMail mail = new DDL_GuiMail(loginEmail, loginPassword);
            Result = mail.SendMail(email, taikhoan, password, isUpdate);
            pcbLoader.Invoke(new Action(() => Close()));
        }

        private void FrmGuiMail_Load_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                //Delay 1.2 giây
                Thread.Sleep(1200); 
                Send(); 
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
