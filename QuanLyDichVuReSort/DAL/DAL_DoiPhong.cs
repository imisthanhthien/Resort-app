using System;
using System.Linq;

namespace DAL
{
    public class DAL_DoiPhong
    {
        QLDVRSDataContext qlrs = new QLDVRSDataContext();

        //Đổi phòng 
        public bool DoiPhong(string id_phongbandau, string id_phongcandoi, string id_nhanvienthuchien, DateTime ngaythuchien, string lydo)
        {
            doiphong dp = new doiphong();
            dp.id_phong_bandau = id_phongbandau;
            dp.id_phong_doiphong = id_phongcandoi;
            dp.id_nhanvien_thuchien = id_nhanvienthuchien;
            dp.ngaythuchien = ngaythuchien;
            dp.lydodoiphong = lydo;
            try
            {
                qlrs.doiphongs.InsertOnSubmit(dp);
                qlrs.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        //Lấy thời gian check_in
        public DateTime LayTime_CheckIn(string madt)
        {
            var datphong = qlrs.datphongs.FirstOrDefault(dt => dt.id_datphong == madt);
            if (datphong != null)
            {
                return datphong.check_in;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        //Lấy thời gian check_out
        public DateTime? LayTime_CheckOut(string madt)
        {
            var datphong = qlrs.datphongs.FirstOrDefault(dt => dt.id_datphong == madt);
            if (datphong != null)
            {
                if (datphong.check_out != null)
                {
                    return (DateTime)datphong.check_out;
                }
            }
            return null;
        }

        //Cập nhật khi khách hàng đổi phòng
        public bool CapNhapKhiDoiPhong(string id_datphong, string id_nhanvien, string id_phongmoi, string id_phongcu, int songuoio, float giaphongmoi, DateTime check_in, DateTime check_out)
        {
            datphong sua = qlrs.datphongs.Where(dt => dt.id_datphong == id_datphong).FirstOrDefault();

            var phongs = qlrs.phongs.Where(p => p.id_phong == id_phongcu).FirstOrDefault();

            if (sua != null)
            {
                int songayo = TinhSoNgayO(check_in, check_out);
                sua.id_nhanvien = id_nhanvien;
                sua.id_phong = id_phongmoi;
                sua.so_nguoi_o = songuoio;
                sua.dat_coc = (songayo * giaphongmoi) * 0.75;

                var phongmois = qlrs.phongs.Where(p => p.id_phong == id_phongmoi).FirstOrDefault();
                if (phongmois != null)
                {
                    if (phongs != null)
                    {
                        if (phongs.trang_thai == "Đã đặt phòng")
                        {
                            phongs.trang_thai = "Còn trống";
                            phongmois.trang_thai = "Đã đặt phòng";
                        }
                        else if (phongs.trang_thai == "Đang sử dụng")
                        {
                            phongs.trang_thai = "Còn trống";
                            phongmois.trang_thai = "Đang sử dụng";
                        }
                        else
                        {
                            phongs.trang_thai = "Còn trống";
                            phongmois.trang_thai = "Đã đặt phòng";
                        }
                    }
                }
                qlrs.SubmitChanges();
                return true;
            }
            return false;
        }

        //Tính số ngày khách ở
        public int TinhSoNgayO(DateTime ngayDen, DateTime ngayDi)
        {
            int soNgayO = 0;

            TimeSpan thoiGianO = ngayDi.Date - ngayDen.Date;

            if (thoiGianO.TotalDays >= 0)
            {
                soNgayO = (int)thoiGianO.TotalDays;
            }
            return soNgayO;
        }

        //Lấy số người ở của phòng
        public int LaySoNguoiO(string maphongmoi)
        {
            var phongs = qlrs.phongs.Where(p => p.id_phong == maphongmoi).FirstOrDefault();
            if (phongs != null)
            {
                return phongs.so_luong_nguoi;
            }
            return 0;
        }
    }
}
