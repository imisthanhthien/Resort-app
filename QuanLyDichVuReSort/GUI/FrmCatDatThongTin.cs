using DAL;
using DDL;
using DTO;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmCatDatThongTin : Form
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();
        DLL_NhanVien dllNhanvien = new DLL_NhanVien();

        private string taikhoan;
        private string fileAddress;
        private byte[] img; // mã hóa hình ảnh lưu trử

        public FrmCatDatThongTin(string taikhoan)
        {
            this.taikhoan = taikhoan;
            InitializeComponent();
        }

        private void FrmCatDatThongTin_Load(object sender, EventArgs e)
        {
            this.LoadComboBox();
            this.LoadThongTinNhanVien();
        }

        //Copy ảnh 
        private Image CloneImage(string path)
        {
            Image result;
            using (Bitmap original = new Bitmap(path))
            {
                result = (Bitmap)original.Clone();

            };
            return result;
        }

        //Lưu trử ảnh dạng mảng
        private byte[] ImageToByteArray(PictureBox pictureBox)
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
            return memoryStream.ToArray();
        }

        // Mở  ảnh trong disk
        private void OpenImage()
        {
            OpenFileDialog open = new OpenFileDialog();

            //File ảnh cho phép đc upload
            open.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            open.Title = "Chọn ảnh cần upload";

            //Nếu chọn OK thì úp load ảnh
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileAddress = open.FileName;
                Pic_anhnhanvien.Image = CloneImage(fileAddress);
                Pic_anhnhanvien.ImageLocation = fileAddress;
                img = ImageToByteArray(Pic_anhnhanvien);
            }
        }

        private void MsgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadThongTinNhanVien()
        {
            try
            {
                var nhanviens = qlrs.nhanviens.Where(nv => nv.ten_dang_nhap == taikhoan).FirstOrDefault();

                if (nhanviens != null)
                {
                    txtHoTen.Text = nhanviens.ten_nhanvien;
                    DateTime ngaysinh = nhanviens.ngay_sinh;
                    string ngaysinhstr = ngaysinh.ToString("dd/MM/yyyy");
                    txtNamSinh.Text = ngaysinhstr;
                    txtSDT.Text = nhanviens.sdt;
                    if(nhanviens.gioi_tinh != "Nam")
                    {
                        cbbGioiTinh.SelectedItem = "Nữ";
                    }    
                    else
                        cbbGioiTinh.SelectedItem = nhanviens.gioi_tinh;

                    txtEmail.Text = nhanviens.email;
                    txtTaiKhoan.Text = taikhoan;
                    img = dllNhanvien.LayAnhNhanVien(taikhoan);

                    MemoryStream memoryStream = new MemoryStream(img);
                    if (memoryStream != null)
                    {
                        Pic_anhnhanvien.Image = Image.FromStream(memoryStream);
                    }
                    else
                        Pic_anhnhanvien.Image.Clone();
                }
            }
            catch (Exception) { }
        }

        private void LoadComboBox()
        {
            cbbGioiTinh.Items.Clear();
            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            new FrmDoiMatKhau(taikhoan).ShowDialog();
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        // kiểm tra Email có giá trị
        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool KiemTraSoDienThoai(string soDienThoai)
        {

            string pattern = @"^\d{10}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(soDienThoai);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string inputDate = txtNamSinh.Text;
                DateTime parsedDate;

           
                if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    MsgBox("Ngày sinh không hợp lệ, vui lòng xem lại!", true);
                    return;
                }

                if (DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate))
                {
                    TimeSpan ageDifference = DateTime.Today - parsedDate;
                    int ageInYears = (int)(ageDifference.Days / 365.25);

                    if (ageInYears < 18)
                    {
                        MsgBox("Tuổi phải lớn hơn hoặc bằng 18 tuổi.", true);
                        return;
                    }
                }

                if (IsValidEmail(txtEmail.Text.Trim()))
                {
                    if (KiemTraSoDienThoai(txtSDT.Text.Trim()))
                    {
                        DTO_NhanVien dtonhanvien = new DTO_NhanVien(
                  taikhoan,
                  txtHoTen.Text,
                  DateTime.Parse(txtNamSinh.Text),
                  txtSDT.Text,
                  cbbGioiTinh.SelectedItem.ToString(),
                  txtEmail.Text,
                  ImageToByteArray(Pic_anhnhanvien)
                  );

                        if (dllNhanvien.CapNhapThongTinNhanVien(dtonhanvien))
                        {
                            MsgBox("Cập nhật thành công!", false);
                        }
                        else
                            MsgBox("Cập nhật thất bại!", true);
                    }
                    else
                        MsgBox("Số điện thoại không đúng định dạng!", true);
                }
                else
                    MsgBox("Email không đúng định dạng", true);

            }
            catch (Exception ex)
            {
                MsgBox("Lỗi " + ex.Message, true);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtNamSinh_TextChanged(object sender, EventArgs e)
        {
            if (txtNamSinh.TextLength == 2 || txtNamSinh.TextLength == 5)
            {
                txtNamSinh.Text += "/";
                txtNamSinh.SelectionStart = txtNamSinh.Text.Length;
            }
        }
    }
}
