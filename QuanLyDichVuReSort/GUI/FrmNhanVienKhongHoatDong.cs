using DAL;
using DDL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmNhanVienKhongHoatDong : Form
    {
        DLL_NhanVien nhanvien = new DLL_NhanVien();
        QLDVRSDataContext qlrs = new QLDVRSDataContext();
        public FrmNhanVienKhongHoatDong()
        {
            InitializeComponent();
        }

        private void FrmNhanVienKhongHoatDong_Load(object sender, EventArgs e)
        {
            dataNhanVien.DataSource = nhanvien.DanhSachNhanVienKhongHoatDong();
        }

        private void dataNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(dataNhanVien.Rows.Count > 0)
                {
                    string taikhoan = this.dataNhanVien.CurrentRow.Cells[6].Value.ToString();
                    bool trangthai = nhanvien.TrangThaiNhanVien(taikhoan);
                    if(trangthai)
                    {
                        ra_hoatdong.Checked = true;
                    }    
                    else
                        ra_khonghoatdong.Checked = true;


                }    
            }
            catch (Exception) { }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = dataNhanVien.CurrentRow.Cells[0].Value.ToString();

                var nhanviens = qlrs.nhanviens.Where(nv => nv.id_nhanvien== manv).FirstOrDefault(); 
                if(nhanviens != null)
                {
                    if(ra_hoatdong.Checked)
                    {
                        nhanviens.trangthai =  true;
                        qlrs.SubmitChanges();
                        MessageBox.Show("Cập nhập thành công");
                        FrmNhanVienKhongHoatDong_Load(sender, e);
                    }
                    else
                    {
                        nhanviens.trangthai = false;
                        MessageBox.Show("Cập nhập thành công");
                        qlrs.SubmitChanges();
                        FrmNhanVienKhongHoatDong_Load(sender, e);
                    }    
                 
                }

            }
            catch (Exception) { }
            
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
