using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using DDL;

namespace GUI
{
    public partial class FrmMain : Form
    {
        string email = "";
        string taikhoan;
        private string str;
        private char separator = '|';
        private string[] strlist;
        private byte[] img; 

        DLL_NhanVien ddl_nhanvien = new DLL_NhanVien();

        FrmTrangChu frmTrangChu = new FrmTrangChu();
        FrmQuanLyNhanVien frm_nhanvien = new FrmQuanLyNhanVien();
        FrmQuanLyPhong frm_phong = new FrmQuanLyPhong();
        FrmQuanLyLoaiPhong frm_loaiphong = new FrmQuanLyLoaiPhong();
        FrmQuanLyThietBi frm_thietbi = new FrmQuanLyThietBi();
        FrmQuanLyDichVu frm_dichvu = new FrmQuanLyDichVu();
        FrmQuanLyKhachHang drm_khachhang = new FrmQuanLyKhachHang();

        public FrmMain(string taikhoan)
        {
            this.taikhoan = taikhoan;
            InitializeComponent();

            // Kiểm tra quyền của nhân viên
            if (ddl_nhanvien.GetQuyen(taikhoan) == "1")
            {
                //Quyền lễ Tân
                btn_TrangChu.Checked = true;
                frmTrangChu.TopLevel = false;
                pnlBody.Controls.Add(frmTrangChu);
                frmTrangChu.Dock = DockStyle.Fill;
                frmTrangChu.Show();
            }
            else if (ddl_nhanvien.GetQuyen(taikhoan) == "2")
            {
                //Quyền thu Ngân
                btn_TrangChu.Checked = true;
                frmTrangChu.TopLevel = false;
                pnlBody.Controls.Add(frmTrangChu);
                frmTrangChu.Dock = DockStyle.Fill;
                frmTrangChu.Show();
            }
            else
            {
                //Quyền quản lý
                btn_qlphong.Visible = true;
                btn_quanlyloaiphong.Visible = true;
                btn_pldichvu.Visible = true;
                btn_qlthietbi.Visible = true;
                btn_qlnhanvien.Visible = true;
                btn_thongkedoanhthu.Visible = true;

                //Chọn trang chủ là mặt định
                btn_TrangChu.Checked = true;
                frmTrangChu.TopLevel = false;
                pnlBody.Controls.Add(frmTrangChu);
                frmTrangChu.Dock = DockStyle.Fill;
                frmTrangChu.Show();
            }

            //Lấy email nhân viên để truy cập tài khoản
            email = ddl_nhanvien.LayMailNhanVien(taikhoan);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            loadthongtinnhanvien();
            LoadAnhNhanVien();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát phầm mềm không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                Application.Exit();
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            frmTrangChu.TopLevel = false;
            pnlBody.Controls.Add(frmTrangChu);
            frmTrangChu.Dock = DockStyle.Fill;
            frmTrangChu.Show();
            frmTrangChu.reload();
        }

        private void btn_datphong_Click(object sender, EventArgs e)
        {
            FrmDanhSachPhong FrmDachSachPhong = new FrmDanhSachPhong(taikhoan);
            pnlBody.Controls.Clear();
            FrmDachSachPhong.TopLevel = false;
            pnlBody.Controls.Add(FrmDachSachPhong);
            FrmDachSachPhong.Dock = DockStyle.Fill;
            FrmDachSachPhong.Show();
        }

        private void btn_nhanphong_Click(object sender, EventArgs e)
        {
            FrmDatPhong frmDatPhong = new FrmDatPhong(taikhoan);
            pnlBody.Controls.Clear();
            frmDatPhong.TopLevel = false;
            pnlBody.Controls.Add(frmDatPhong);
            frmDatPhong.Dock = DockStyle.Fill;
            frmDatPhong.Show();
        }

        private void btn_khachhang_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            drm_khachhang.TopLevel = false;
            pnlBody.Controls.Add(drm_khachhang);
            drm_khachhang.Dock = DockStyle.Fill;
            drm_khachhang.Show();
        }

        private void btn_qlphong_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            frm_phong.TopLevel = false;
            pnlBody.Controls.Add(frm_phong);
            frm_phong.Dock = DockStyle.Fill;
            frm_phong.Show();
        }
        private void btn_quanlyloaiphong_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            frm_loaiphong.TopLevel = false;
            pnlBody.Controls.Add(frm_loaiphong);
            frm_loaiphong.Dock = DockStyle.Fill;
            frm_loaiphong.Show();
        }
        private void btn_pldichvu_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            frm_dichvu.TopLevel = false;
            pnlBody.Controls.Add(frm_dichvu);
            frm_dichvu.Dock = DockStyle.Fill;
            frm_dichvu.Show();
        }
        private void btn_qlnhanvien_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            frm_nhanvien.TopLevel = false;
            pnlBody.Controls.Add(frm_nhanvien);
            frm_nhanvien.Dock = DockStyle.Fill;
            frm_nhanvien.Show();
        }

        private void btn_thongkedoanhthu_Click(object sender, EventArgs e)
        {
            FrmThongKeDoanhThu frmThongKe = new FrmThongKeDoanhThu(taikhoan);
            pnlBody.Controls.Clear();
            frmThongKe.TopLevel = false;
            pnlBody.Controls.Add(frmThongKe);
            frmThongKe.Dock = DockStyle.Fill;
            frmThongKe.Show();
        }
        private void btn_qlthietbi_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            frm_thietbi.TopLevel = false;
            pnlBody.Controls.Add(frm_thietbi);
            frm_thietbi.Dock = DockStyle.Fill;
            frm_thietbi.Show();
        }

        //Hiển thị thông tin nhân viên (Họ tên - quyền)
        private void loadthongtinnhanvien()
        {
            str = ddl_nhanvien.LayNameChucVuNhanVien(taikhoan);
            strlist = str.Split(separator);
            lb_name.Text = "Họ tên: " + strlist[0].Trim();
            string chucvu = strlist[1].Trim();

            if (chucvu == "1")
            {
                chucvu = "Lễ tân";
            }
            else if (chucvu == "2")
            {
                chucvu = "Thu ngân";
            }
            else
                chucvu = "Quản lý";
            lb_chucvu.Text = "Chức vụ: " + chucvu;
        }

        //Đăng xuất
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                this.Close();
        }

        private void linkLabel_quydinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmQuyDinh().ShowDialog();
        }

        private void btn_caidat_Click(object sender, EventArgs e)
        {
            if(new FrmCatDatThongTin(taikhoan).ShowDialog() == DialogResult.OK)
            {
                FrmMain_Load(sender, e);
            }
        }
        private void LoadAnhNhanVien()
        {
            try
            {
                img = ddl_nhanvien.LayAnhNhanVien(taikhoan);

                MemoryStream memoryStream = new MemoryStream(img);
                if (memoryStream != null)
                {
                    pic_anhnhanvien.Image = Image.FromStream(memoryStream);
                }
                else
                    pic_anhnhanvien.Image.Clone();
            }
            catch (Exception) { }

        }
    
    }
}
