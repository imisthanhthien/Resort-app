using DDL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmThongTinGiaPhong : Form
    {
        public FrmThongTinGiaPhong()
        {
            InitializeComponent();
        }

        private void FrmThongTinGiaPhong_Load(object sender, EventArgs e)
        {
            dataLoaiPhong.DataSource = new DLL_LoaiPhong().DanhSachLoaiPhongTenVaGia();
            dataLoaiPhong.ClearSelection();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataLoaiPhong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    decimal price = Convert.ToDecimal(e.Value);
                    e.Value = price.ToString("C");
                }
            }
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                guna2Panel1.Capture = false;
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }
    }
}
