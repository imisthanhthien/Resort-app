using DAL;
using DDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmDanhSachPhong : Form
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();
        DLL_DatPhong ddldatphong = new DLL_DatPhong();
        DLL_Phong dllphong = new DLL_Phong();

        private string str;
        private string[] danhsachKH;
        private string taikhoan;
        private string[] Danhsachloaiphong;
        private string tenphong, tenloaiphong, tenkh, ngayo;
        private int son_ngay_o;
        private char separator = '|';

        public FrmDanhSachPhong(string taikhoan)
        {
            this.taikhoan = taikhoan;
            InitializeComponent();
        }
        private void FrmDatPhong_Load(object sender, EventArgs e)
        {
            //LoadDanhSachPhong();
            _ = LoadDanhSachPhongAsync();
            LoadComboboxTiemKiem();
        }

        private void LoadComboboxTiemKiem()
        {
            Danhsachloaiphong = dllphong.DanhsachTenLoaiPhong();
            cbbLoaiPhong.Items.Clear();

            foreach (string item in Danhsachloaiphong)
            {
                cbbLoaiPhong.Items.Add(item);
            }
        }

        //Load danh sách phòng
        private DanhSachPhong TaoDanhSachPhong(phong item)
        {
            DanhSachPhong DSPhong = new DanhSachPhong();

            DSPhong.Maphong = item.id_phong;
            DSPhong.Tenphong = item.ten;
            DSPhong.Trangthai = item.trang_thai;

            DSPhong.ContextMenuStrip = contextMenu;

            str = ddldatphong.LayKhachHangDatPhong(DSPhong.Maphong);

            if (!string.IsNullOrEmpty(str))
            {
                danhsachKH = str.Split(separator);

                tenkh = danhsachKH[0].Trim();
                ngayo = danhsachKH[1];

                if (int.TryParse(ngayo, out son_ngay_o))
                {
                    DSPhong.SetTenKhachHang(tenkh);
                    DSPhong.setSongayo(son_ngay_o);
                }
            }
            setTrangThaiPhong(DSPhong);
            return DSPhong;
        }

        //Bất đồng bộ khởi tạo danh sách phòng - load nhanh hơn
        private async Task<DanhSachPhong> TaoDanhSachPhongAsync(phong item)
        {
            DanhSachPhong DSPhong = new DanhSachPhong();
            await DSPhong.LoadDataAsync(item.id_phong, item.ten, item.trang_thai);
            DSPhong.ContextMenuStrip = contextMenu;

            string str = await Task.Run(() => ddldatphong.LayKhachHangDatPhong(DSPhong.Maphong));

            if (!string.IsNullOrEmpty(str))
            {
                string[] danhsachKH = str.Split(separator);
                string tenkh = danhsachKH[0].Trim();
                string ngayo = danhsachKH[1];

                if (int.TryParse(ngayo, out int son_ngay_o))
                {
                    DSPhong.SetTenKhachHang(tenkh);
                    DSPhong.setSongayo(son_ngay_o);
                }
            }
            setTrangThaiPhong(DSPhong);
            return DSPhong;
        }

        //Bất đồng bộ load danh sách phòng - load nhanh hơn
        private async Task LoadDanhSachPhongAsync()
        {
            qlrs.Refresh(RefreshMode.OverwriteCurrentValues, qlrs.phongs);

            List<phong> list = qlrs.phongs.ToList();
            List<Task<DanhSachPhong>> tasks = new List<Task<DanhSachPhong>>();

            foreach (var item in list)
            {
                tasks.Add(TaoDanhSachPhongAsync(item));
            }

            DanhSachPhong[] DSPhongs = await Task.WhenAll(tasks);

            flowLayoutPanel_phong.SuspendLayout();
            flowLayoutPanel_phong.Controls.Clear();

            foreach (var DSPhong in DSPhongs)
            {
                flowLayoutPanel_phong.Controls.Add(DSPhong);
            }
            flowLayoutPanel_phong.ResumeLayout();
        }

        private void LoadDanhSachPhong()
        {
            //Reset lai Model LinQ table phong
            qlrs.Refresh(RefreshMode.OverwriteCurrentValues, qlrs.phongs);

            List<phong> list = qlrs.phongs.ToList();

            flowLayoutPanel_phong.Controls.Clear();
            foreach (var item in list)
            {
                DanhSachPhong DSPhong = TaoDanhSachPhong(item);
                flowLayoutPanel_phong.Controls.Add(DSPhong);
            }
        }

        private void TrangThaiPhong(string trangthai)
        {
            //Reset lai Model LinQ table phong
            qlrs.Refresh(RefreshMode.OverwriteCurrentValues, qlrs.phongs);

            List<phong> list = qlrs.phongs.Where(p => p.trang_thai == trangthai).ToList();

            flowLayoutPanel_phong.Controls.Clear();
            foreach (var item in list)
            {
                DanhSachPhong DSPhong = TaoDanhSachPhong(item);
                flowLayoutPanel_phong.Controls.Add(DSPhong);
            }
        }

        private void LoadTheoTenPhong(string tenphong)
        {
            //Reset lai Model LinQ table phong
            qlrs.Refresh(RefreshMode.OverwriteCurrentValues, qlrs.phongs);

            List<phong> list = qlrs.phongs.Where(p => p.ten.Contains(tenphong)).ToList();

            flowLayoutPanel_phong.Controls.Clear();
            foreach (var item in list)
            {
                DanhSachPhong userControl11 = TaoDanhSachPhong(item);
                flowLayoutPanel_phong.Controls.Add(userControl11);
            }
        }
        private void LoadTheoTenLoaiPhong(string tenloaiphong)
        {
            //Reset lai Model LinQ table phong
            qlrs.Refresh(RefreshMode.OverwriteCurrentValues, qlrs.phongs);

            var loaiphong = qlrs.loaiphongs.Where(lp => lp.ten_loai == tenloaiphong).FirstOrDefault();
            int idloaiphong = loaiphong.id_loaiphong;

            List<phong> list = qlrs.phongs.Where(p => p.id_loaiphong == idloaiphong).ToList();

            flowLayoutPanel_phong.Controls.Clear();
            foreach (var item in list)
            {
                DanhSachPhong DSPhong = TaoDanhSachPhong(item);
                flowLayoutPanel_phong.Controls.Add(DSPhong);
            }
        }

        private void setTrangThaiPhong(DanhSachPhong ds)
        {
            if (ds.Trangthai == "Đang sử dụng")
            {
                ds.UpdatePanelColor(Color.DeepPink, Color.DeepPink);
            }
            else if (ds.Trangthai == "Đang sửa chữa")
            {
                ds.UpdatePanelColor(Color.Yellow, Color.Red);
            }
            else if (ds.Trangthai == "Đang dọn dẹp")
            {
                ds.UpdatePanelColor(Color.SeaGreen, Color.SeaGreen);
            }
            else if (ds.Trangthai == "Đã đặt phòng")
            {
                ds.UpdatePanelColor(Color.Gray, Color.DarkSlateGray);
            }
            else
                ds.UpdatePanelColor(Color.SteelBlue, Color.SteelBlue);

        }
        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            foreach (ToolStripItem item in contextMenu.Items)
            {
                item.Visible = false;
            }

            ToolStripMenuItem clickedMenuItem = sender as ToolStripMenuItem;
            System.Windows.Forms.Control sourceControl = contextMenu.SourceControl;

            if (sourceControl is DanhSachPhong selectedControl)
            {
                string maPhong = selectedControl.Maphong;
                var phongToUpdate = qlrs.phongs.FirstOrDefault(p => p.id_phong == maPhong);

                if (phongToUpdate != null)
                {
                    if (phongToUpdate.trang_thai == "Còn trống")
                    {
                        dondepphong.Visible = true;
                        suachuaphong.Visible = true;
                        selectedControl.UpdatePanelColor(Color.SteelBlue, Color.SteelBlue);
                    }
                    else if (phongToUpdate.trang_thai == "Đang sử dụng")
                    {
                        chitietnhanphong.Visible = true;
                        selectedControl.UpdatePanelColor(Color.DeepPink, Color.DeepPink);
                    }
                    else if (phongToUpdate.trang_thai == "Đang sửa chữa")
                    {
                        ngungsuachua.Visible = true;
                        selectedControl.UpdatePanelColor(Color.Yellow, Color.Red);
                    }
                    else if (phongToUpdate.trang_thai == "Đang dọn dẹp")
                    {
                        ngungdondep.Visible = true;
                        selectedControl.UpdatePanelColor(Color.SeaGreen, Color.SeaGreen);
                    }
                    else if (phongToUpdate.trang_thai == "Đã đặt phòng")
                    {
                        nhanphong.Visible = true;
                        selectedControl.UpdatePanelColor(Color.Gray, Color.DarkSlateGray);
                    }
                }
            }
        }

        private void dondepphong_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedMenuItem = sender as ToolStripMenuItem;
            System.Windows.Forms.Control sourceControl = contextMenu.SourceControl;

            if (sourceControl is DanhSachPhong selectedControl)
            {
                string maPhong = selectedControl.Maphong;
                var phongToUpdate = qlrs.phongs.FirstOrDefault(p => p.id_phong == maPhong);

                if (phongToUpdate != null)
                {
                    phongToUpdate.trang_thai = "Đang dọn dẹp";
                    qlrs.SubmitChanges();
                    selectedControl.Trangthai = phongToUpdate.trang_thai;
                    selectedControl.UpdatePanelColor(Color.SeaGreen, Color.SeaGreen);
                }
            }
        }

        private void ngungdondep_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedMenuItem = sender as ToolStripMenuItem;
            System.Windows.Forms.Control sourceControl = contextMenu.SourceControl;

            if (sourceControl is DanhSachPhong selectedControl)
            {
                string maPhong = selectedControl.Maphong;
                var phongToUpdate = qlrs.phongs.FirstOrDefault(p => p.id_phong == maPhong);

                if (phongToUpdate != null)
                {
                    phongToUpdate.trang_thai = "Còn trống";
                    qlrs.SubmitChanges();
                    selectedControl.Trangthai = phongToUpdate.trang_thai;
                    selectedControl.UpdatePanelColor(Color.SteelBlue, Color.SteelBlue);
                }
            }
        }

        private void suachuaphong_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedMenuItem = sender as ToolStripMenuItem;
            System.Windows.Forms.Control sourceControl = contextMenu.SourceControl;

            if (sourceControl is DanhSachPhong selectedControl)
            {
                string maPhong = selectedControl.Maphong;
                var phongToUpdate = qlrs.phongs.FirstOrDefault(p => p.id_phong == maPhong);

                if (phongToUpdate != null)
                {
                    phongToUpdate.trang_thai = "Đang sửa chữa";
                    qlrs.SubmitChanges();
                    selectedControl.Trangthai = phongToUpdate.trang_thai;
                    selectedControl.UpdatePanelColor(Color.Yellow, Color.Red);
                }
            }
        }

        private void ngungsuachua_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedMenuItem = sender as ToolStripMenuItem;
            System.Windows.Forms.Control sourceControl = contextMenu.SourceControl;

            if (sourceControl is DanhSachPhong selectedControl)
            {
                string maPhong = selectedControl.Maphong;
                var phongToUpdate = qlrs.phongs.FirstOrDefault(p => p.id_phong == maPhong);

                if (phongToUpdate != null)
                {
                    phongToUpdate.trang_thai = "Còn trống";
                    qlrs.SubmitChanges();
                    selectedControl.Trangthai = phongToUpdate.trang_thai;
                    selectedControl.UpdatePanelColor(Color.SteelBlue, Color.SteelBlue);
                }
            }
        }
        private void chitietnhanphong_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedMenuItem = sender as ToolStripMenuItem;
            System.Windows.Forms.Control sourceControl = contextMenu.SourceControl;

            if (sourceControl is DanhSachPhong selectedControl)
            {
                string maPhong = selectedControl.Maphong;
                var phongToUpdate = qlrs.phongs.Where(p => p.id_phong == maPhong).FirstOrDefault();

                str = ddldatphong.LayKhachHangDatPhong(maPhong);
                if (str != "")
                {
                    danhsachKH = str.Split(separator);
                    string ngayo = danhsachKH[1];
                    int songayo = int.Parse(ngayo);

                    FrmNhanPhong frmNhanPhong = new FrmNhanPhong(maPhong, songayo, taikhoan);

                    if (new FrmNhanPhong(maPhong, songayo, taikhoan).ShowDialog() == DialogResult.OK)
                    {
                        string madt = ddldatphong.LayMaDatPhonginPhong(maPhong);
                        var kiemtratraphong = qlrs.datphongs.Where(dt => dt.id_datphong == madt).FirstOrDefault();

                        if (kiemtratraphong != null)
                        {
                            phongToUpdate.trang_thai = "Đang sử dụng";
                            qlrs.SubmitChanges();
                            selectedControl.Trangthai = phongToUpdate.trang_thai;
                            selectedControl.UpdatePanelColor(Color.DeepPink, Color.DeepPink);
                        }
                        else
                        {
                            phongToUpdate.trang_thai = "Đang dọn dẹp";
                            qlrs.SubmitChanges();
                            selectedControl.Trangthai = phongToUpdate.trang_thai;
                            selectedControl.UpdatePanelColor(Color.SeaGreen, Color.SeaGreen);
                            LoadDanhSachPhong();
                        }
                    }
                }
                else
                    new FrmNhanPhong("", 0, "").ShowDialog();
            }
        }
        private void nhanphong_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedMenuItem = sender as ToolStripMenuItem;
            System.Windows.Forms.Control sourceControl = contextMenu.SourceControl;
            if (sourceControl is DanhSachPhong selectedControl)
            {
                string maPhong = selectedControl.Maphong;
                var phongToUpdate = qlrs.phongs.Where(p => p.id_phong == maPhong).FirstOrDefault();

                str = ddldatphong.LayKhachHangDatPhong(maPhong);
                if (str != "")
                {
                    danhsachKH = str.Split(separator);
                    string ngayo = danhsachKH[1];
                    int songayo = int.Parse(ngayo);

                    FrmNhanPhong frmNhanPhong = new FrmNhanPhong(maPhong, songayo, taikhoan);

                    if (new FrmNhanPhong(maPhong, songayo, taikhoan).ShowDialog() == DialogResult.OK)
                    {
                        string madt = ddldatphong.LayMaDatPhonginPhong(maPhong);
                        var kiemtratraphong = qlrs.datphongs.Where(dt => dt.id_datphong == madt).FirstOrDefault();

                        if (kiemtratraphong != null)
                        {
                            phongToUpdate.trang_thai = "Đang sử dụng";
                            qlrs.SubmitChanges();
                            selectedControl.Trangthai = phongToUpdate.trang_thai;
                            selectedControl.UpdatePanelColor(Color.DeepPink, Color.DeepPink);
                        }
                        else
                        {
                            phongToUpdate.trang_thai = "Đang dọn dẹp";
                            qlrs.SubmitChanges();
                            selectedControl.Trangthai = phongToUpdate.trang_thai;
                            selectedControl.UpdatePanelColor(Color.SeaGreen, Color.SeaGreen);
                            LoadDanhSachPhong();
                        }
                    }
                }
                else
                    new FrmNhanPhong("", 0, "").ShowDialog();
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                //LoadDanhSachPhong();
                _ = LoadDanhSachPhongAsync();
                rad_tatcaphong.Checked = true;
                txtTimKiem.Text = null;
                LoadComboboxTiemKiem();
            }
            catch (Exception) { }
        }
        private void rad_tatcaphong_CheckedChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
        }
        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TrangThaiPhong("Còn trống");
        }
        private void guna2RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            TrangThaiPhong("Đang sử dụng");
        }
        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            TrangThaiPhong("Đang sửa chữa");
        }
        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TrangThaiPhong("Đã đặt phòng");
        }
        private void guna2RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            TrangThaiPhong("Đang dọn dẹp");
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            tenphong = txtTimKiem.Text.Trim();
            if (tenphong == "")
            {
                FrmDatPhong_Load(sender, e);
                txtTimKiem.Focus();
            }
            else
                LoadTheoTenPhong(tenphong);
        }

        private void cbbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenloaiphong = cbbLoaiPhong.SelectedItem.ToString();

            if (tenloaiphong == "")
            {
                FrmDatPhong_Load(sender, e);
            }
            else
                LoadTheoTenLoaiPhong(tenloaiphong);
        }
    }
}
