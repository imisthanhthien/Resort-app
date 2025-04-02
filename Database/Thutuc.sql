--Phân quyền đăng nhập
CREATE PROC DangNhap
@taikhoan VARCHAR(50), @matkhau VARCHAR(50)
AS BEGIN
DECLARE @status BIT
IF EXISTS(SELECT * FROM NhanVien WHERE ten_dang_nhap = @taikhoan AND mat_khau = @matkhau)
	SET @status = 1
ELSE
	SET @status = 0
SELECT @status
END

GO

--Kiểm tra tồn tại tài khoản
CREATE PROC IsExistTaiKhoan
@taikhoan VARCHAR(50)
AS BEGIN
DECLARE @result BIT
IF EXISTS(SELECT * FROM NhanVien WHERE ten_dang_nhap = @taikhoan)
	SET @result = 1
ELSE
	SET @result = 0
SELECT @result
END

GO

--Kiểm tra trạng thái nhân viên
CREATE PROC TrangThaiNhanVien
@taikhoan VARCHAR(50)
AS BEGIN
DECLARE @result BIT
IF EXISTS(SELECT * FROM NhanVien WHERE ten_dang_nhap = @taikhoan and trangthai = 1)
	SET @result = 1
ELSE
	SET @result = 0
SELECT @result
END

GO

--Thay đổi mật nhân viên
CREATE PROC ThayDoiMatKhauNhanVien
@taikhoan VARCHAR(50), @oldPassword VARCHAR(50), @newPassword VARCHAR(50)
AS BEGIN
DECLARE @password NVARCHAR(50), @result bit
SELECT @password = mat_khau FROM dbo.nhanvien WHERE ten_dang_nhap = @taikhoan
IF @password = @oldPassword
BEGIN
    UPDATE dbo.nhanvien SET mat_khau = @newPassword WHERE ten_dang_nhap = @taikhoan
	SET @result = 1
END
ELSE SET @result = 0
SELECT @result
END

GO

--Lấy quyền của nhân viên
CREATE PROC LayQuyenNhanVien
@taikhoan NVARCHAR(50)
AS BEGIN
SELECT quyen FROM NhanVien WHERE ten_dang_nhap = @taikhoan
END

GO

--Lấy danh sách nhân viên
CREATE PROC DanhSachNhanVien
AS BEGIN
select id_nhanvien,ten_nhanvien, ngay_sinh, sdt,gioi_tinh,email,ten_dang_nhap,quyen.ten_quyen from NhanVien, quyen
where nhanvien.quyen = quyen.id_quyen and trangthai = 1 
END
GO

--Lấy danh sách nhân viên không hoạt động
CREATE PROC DanhSachNhanVienKhongHoatDong
AS BEGIN
select id_nhanvien,ten_nhanvien, ngay_sinh, sdt,gioi_tinh,email,ten_dang_nhap,quyen.ten_quyen, trangthai from NhanVien, quyen
where nhanvien.quyen = quyen.id_quyen
END
GO

--Thêm nhân viên
create proc ThemNhanVien
	@id varchar(10), @ten nvarchar(100), @ngaysinh date, @sdt varchar(10),
 @gt nvarchar(6), @email varchar(50) , @taikhoan varchar(50), @matkhau varchar(50), @quyen int 
as
begin
	insert into nhanvien(id_nhanvien,ten_nhanvien,ngay_sinh,sdt,gioi_tinh,email,ten_dang_nhap, mat_khau,quyen)
	values(@id, @ten,@ngaysinh,@sdt,@gt,@email,@taikhoan,@matkhau, @quyen)
end

GO

--Xóa nhân viên
CREATE PROC XoaNhanVien
@id varchar(10)
AS BEGIN
DECLARE @result BIT = 1
IF EXISTS(SELECT * FROM dbo.NhanVien WHERE id_nhanvien = @id)
	begin
		UPDATE dbo.NhanVien set trangthai = 0 WHERE id_nhanvien = @id
		DELETE dbo.NhanVien WHERE id_nhanvien = @id
	end
	
ELSE
	SET @result = 0
SELECT @result
END

GO

--Sửa nhân viên
create proc SuaNhanVien
 @id varchar(10), @ten nvarchar(100), @ngaysinh date, @sdt varchar(10),
 @gt nvarchar(6), @email varchar(50) , @taikhoan varchar(50), @quyen int 
as
begin
	update nhanvien set ten_nhanvien = @ten, ngay_sinh = @ngaysinh, sdt = @sdt,
	gioi_tinh = @gt, email = @email, ten_dang_nhap = @taikhoan, quyen = @quyen
	where id_nhanvien = @id
end

GO

--Lấy nhân viên cuối cùng trong database
create proc LayMaNhanVienCuoi
as
begin
	select top 1 id_nhanvien  from nhanvien 
	order by id_nhanvien desc;
end

GO

--Lấy id - tên nhân viên
create proc LayIDNameNhanVien
@taikhoan varchar(50)
as
begin
	select id_nhanvien + ' | ' + ten_nhanvien  from nhanvien 
	where ten_dang_nhap = @taikhoan
end

GO

--Tìm kiếm  nhân viên
CREATE PROC TimKiemNhanVien
@Hoten NVARCHAR(100)
AS BEGIN
select id_nhanvien,ten_nhanvien, ngay_sinh, sdt,gioi_tinh,email,ten_dang_nhap,quyen.ten_quyen from NhanVien, quyen
where nhanvien.quyen = quyen.id_quyen and trangthai = '1' and ten_nhanvien LIKE '%' + @Hoten + '%'
END
GO

--Cập nhập mật khẩu nhân viên
CREATE PROC ThayDoiMatKhau
@email VARCHAR(50), @matkhau VARCHAR(50)
AS BEGIN
UPDATE dbo.NhanVien
SET mat_khau = @matkhau
WHERE email = @email
END

GO

--Lấy chức vụ của nhân viên
CREATE PROC LayChucVuNhanVien
@email VARCHAR(50)
AS BEGIN
SELECT quyen FROM dbo.NhanVien WHERE email = @email
END

GO

--Lấy email nhân viên
CREATE PROC LayMailNhanVien
@taikhoan VARCHAR(50)
AS BEGIN
SELECT email FROM dbo.NhanVien WHERE ten_dang_nhap = @taikhoan
END


GO

--Lấy name, chức vụ nhân viên
CREATE PROC LayNameChucVuNhanVien
@taikhoan varchar(50)
AS BEGIN
	select ten_nhanvien + ' | ' + CONVERT(varchar(50), quyen) from NhanVien 
	where ten_dang_nhap = @taikhoan
END

GO

--Kiểm tra tồn tại Email của nhân viên
CREATE PROC IsExistEmail
@email VARCHAR(50)
AS BEGIN
DECLARE @result BIT
IF EXISTS(SELECT * FROM dbo.nhanvien WHERE email = @email)
	SET @result = 1
ELSE
	SET @result = 0
SELECT @result
END

GO

--Cập nhập mật khẩu
CREATE PROC UpdatePassword
@email VARCHAR(50), @matkhau VARCHAR(50)
AS BEGIN
UPDATE dbo.NhanVien
SET mat_khau = @matkhau
WHERE email = @email
END

GO

--Danh sách phòng
create proc DanhSachPhong
as
begin
	select p.id_phong, p.ten, p.so_luong_nguoi,lp.ten_loai, p.trang_thai, lp.gia from phong p, loaiphong lp
	where p.id_loaiphong = lp.id_loaiphong 

end

GO

--Thêm phòng
create proc ThemPhong
@id varchar(10), @ten nvarchar(50), @sl int , @loai int, @trangthai nvarchar(30)
as
begin
	insert into phong(id_phong,ten, so_luong_nguoi,id_loaiphong,trang_thai)
	values(@id, @ten, @sl, @loai,@trangthai)
end

GO

--Sửa phòng
create proc SuaPhong
@id varchar(10), @ten nvarchar(50), @sl int , @loai int, @trangthai nvarchar(30)
as
begin
	update phong set ten = @ten, so_luong_nguoi = @sl, id_loaiphong = @loai, trang_thai = @trangthai
	where id_phong = @id
end

GO

--Xóa phòng
create proc XoaPhong
@id varchar(10)
as
begin
	DECLARE @result BIT = 1
IF EXISTS(SELECT * FROM phong where id_phong = @id)
	delete from phong where id_phong = @id
ELSE
	SET @result = 0
SELECT @result
end

GO

--Tìm kiếm  phòng
CREATE PROC TimKiemPhong
@tenphong NVARCHAR(50)
AS BEGIN
select p.id_phong, p.ten, p.so_luong_nguoi,lp.ten_loai, p.trang_thai, lp.gia from phong p, loaiphong lp
	where p.id_loaiphong = lp.id_loaiphong and p.ten LIKE '%' + @tenphong + '%'
END

GO

--Danh sách ten loại phòng
CREATE PROC DanhsachTenLoaiPhong
AS BEGIN
SELECT ten_loai FROM dbo.loaiphong
END

GO

--Danh sach loai phong
create proc DanhSachLoaiPhong
as
begin
		select * from loaiphong
end

GO

--Danh sach loại phòng theo giá tăng dần
create proc DanhSachLoaiPhongTenVaGia
as
begin
		select ten_loai, gia from loaiphong order by gia asc
end

GO

--Lấy mã và tên loại phòng
create proc MaTenLoaiPhong
as
begin
		select CONVERT(nvarchar(50), id_loaiphong) + '|' + ten_loai   from loaiphong
end

GO

--Tìm kiếm sản phẩm theo loại phòng
CREATE PROC TimKiemLoaiPhong
@tenphong NVARCHAR(50)
AS BEGIN
select p.id_phong, p.ten, p.so_luong_nguoi,lp.ten_loai, p.trang_thai, lp.gia from phong p, loaiphong lp
	where p.id_loaiphong = lp.id_loaiphong and lp.ten_loai = @tenphong
END

GO

--Tìm kiếm sản phẩm theo loại phòng
CREATE PROC TimKiemLoaiPhong2
@tenphong NVARCHAR(50)
AS BEGIN
select p.id_phong, p.so_luong_nguoi,lp.ten_loai, lp.gia, p.trang_thai from phong p, loaiphong lp
	where p.id_loaiphong = lp.id_loaiphong and lp.ten_loai = @tenphong
END
GO

--Tìm kiếm theo giá phòng
CREATE PROCEDURE TimKiemTheoGia
    @gia1 INT,
    @gia2 INT
AS
BEGIN
    IF @gia1 = 1000000 AND @gia2 = 2000000
    BEGIN
        SELECT p.id_phong, p.ten, p.so_luong_nguoi, lp.ten_loai, p.trang_thai, lp.gia
        FROM phong p
        INNER JOIN loaiphong lp ON p.id_loaiphong = lp.id_loaiphong
        WHERE lp.gia BETWEEN @gia1 AND @gia2;
    END
    ELSE IF @gia1 = 2000000 AND @gia2 = 5000000
    BEGIN
        SELECT p.id_phong, p.ten, p.so_luong_nguoi, lp.ten_loai, p.trang_thai, lp.gia
        FROM phong p
        INNER JOIN loaiphong lp ON p.id_loaiphong = lp.id_loaiphong
        WHERE lp.gia BETWEEN @gia1 AND @gia2;
    END
    ELSE IF @gia1 = 5000000 AND @gia2 = 10000000
    BEGIN
        SELECT p.id_phong, p.ten, p.so_luong_nguoi, lp.ten_loai, p.trang_thai, lp.gia
        FROM phong p
        INNER JOIN loaiphong lp ON p.id_loaiphong = lp.id_loaiphong
        WHERE lp.gia BETWEEN @gia1 AND @gia2;
    END
    ELSE
    BEGIN
         SELECT p.id_phong, p.ten, p.so_luong_nguoi, lp.ten_loai, p.trang_thai, lp.gia
        FROM phong p
        INNER JOIN loaiphong lp ON p.id_loaiphong = lp.id_loaiphong
        WHERE lp.gia > 10000000;
    END
END

GO

--Danh sách đặt phòng
create proc DanhSachDatPhong
as
begin
	select p.id_phong, p.so_luong_nguoi, lp.ten_loai,lp.gia, p.trang_thai  from phong p, loaiphong lp
	where p.id_loaiphong = lp.id_loaiphong

end

GO

--Lấy khách hàng đặt phòng
create proc LayKhachHangDatPhong
@id_phong varchar(10)
as
begin
	select   kh.ten_khachhang + '|' + CONVERT(varchar(10) , DATEDIFF(day, dt.check_in, dt.check_out)) AS SoNgayO from datphong dt , khachhang kh
	where kh.id_khachhang  = dt.id_khachhang and dt.id_phong = @id_phong
	and trang_thai = N'Chưa thanh toán'

end

GO

--Danh sách đặt phòng hiện hành
create proc DanhSachDatPhongVer2
as
begin
	select dt.id_datphong, kh.ten_khachhang, nv.ten_nhanvien, p.id_phong, dt.check_in, dt.check_out, dt.so_nguoi_o, dt.dat_coc, dt.trang_thai  from datphong dt, nhanvien nv, khachhang kh, phong p
	where kh.id_khachhang = dt.id_khachhang and nv.id_nhanvien = dt.id_nhanvien and p.id_phong = dt.id_phong and dt.trang_thai = N'Chưa thanh toán'

end

GO

---Lấy mã khách hàng bằng CMND
create proc ThongTinKhachHanginCMND
@cmnd varchar(15)
as
begin
     select id_khachhang from khachhang where cmnd = @cmnd
end

GO

---Lọc phòng theo loại phòng
create proc Locphongtheoloaiphong
@id int
as
begin
     select id_phong from phong where id_loaiphong = @id 
end

GO

---Lấy mã loại phòng
CREATE PROCEDURE LayMaLoaiPhong
    @tenloai NVARCHAR(50)
AS
BEGIN
    SELECT id_loaiphong 
    FROM loaiphong 
    WHERE ten_loai = @tenloai
END 

GO

--Lọc theo số người ở
create proc Loctheosonguoio
@soluong int
as
begin
     select p.id_phong, p.so_luong_nguoi, lp.ten_loai,lp.gia, p.trang_thai  from phong p, loaiphong lp
	where p.id_loaiphong = lp.id_loaiphong and so_luong_nguoi  = @soluong
end

GO

--Lọc theo số người ở khi chọn 
create proc Loctheosonguoio2
@soluong int, @id int
as
begin
     select p.id_phong, p.so_luong_nguoi, lp.ten_loai,lp.gia, p.trang_thai  from phong p, loaiphong lp
	where p.id_loaiphong = lp.id_loaiphong and so_luong_nguoi  = @soluong and p.id_loaiphong = @id
end

GO

--Lấy giá phòng
create proc LayGiaPhongTheoMaPhong
@id varchar(10)
as
begin
    select lp.gia from  phong p, loaiphong lp
	where p.id_loaiphong = lp.id_loaiphong and p.id_phong = @id
end

GO

--Lấy mã đặt phòng từ phòng
create proc LayMaDatPhonginPhong
@id_phong varchar(10)
as
begin
	select  dt.id_datphong from datphong dt, phong p
	where p.id_phong = dt.id_phong and dt.id_phong = @id_phong  and dt.trang_thai = N'Chưa thanh toán'

end

GO

---Danh sách chi tiết dịch vụ
create proc DanhSachChiTietDV
@id_datphong varchar(10)
as
begin
	select ctdv.id_dichvu ,dv.ten_dichvu,dv.gia, ctdv.so_luong, ctdv.tong_tien_dv  from chitietsudungdv ctdv , dichvu dv
	where dv.id_dichvu = ctdv.id_dichvu and ctdv.id_datphong = @id_datphong

end

GO

--Thêm sử dụng dịch vụ
create proc ThemSDDV
@id_datphong varchar(10), @id_dichvu varchar(10), @sl int, @thanhtien float
as
begin
	insert into chitietsudungdv(id_datphong,id_dichvu,so_luong,tong_tien_dv, ngay_thue)
	values (@id_datphong, @id_dichvu, @sl, @thanhtien, default)

end

GO

--Sửa sử dụng dịch vụ
CREATE PROCEDURE SuaSDDV
    @id_dichvu VARCHAR(10),
    @sl INT
AS
BEGIN
    DECLARE @gia FLOAT
    DECLARE @tongtien FLOAT
    
    SELECT @gia = gia FROM dichvu WHERE id_dichvu = @id_dichvu
    
    IF @gia IS NOT NULL
    BEGIN
        SET @tongtien = @sl * @gia

            UPDATE chitietsudungdv
            SET so_luong = @sl, tong_tien_dv = @tongtien
            WHERE id_dichvu = @id_dichvu
    END
  
END

GO

--Xóa sử dụng dịch vụ
create proc XoaSDDV
@id_dichvu varchar(10)
as
begin
	delete from chitietsudungdv where id_dichvu = @id_dichvu
end

GO

--Lấy mã, tên dịch vụ
CREATE PROC DanhSachMavaTenDV

AS BEGIN
	select  id_dichvu + ' | ' + ten_dichvu as 'ThongTinDichVu' from dichvu
END

GO

---Lấy giá dịch vụ
create proc LayGiaDichVu
@id_dichvu varchar(10)
as
begin
		select gia from dichvu where id_dichvu = @id_dichvu
end

GO

--Kiểm tra dịch vụ trùng
CREATE PROCEDURE KiemTraDichVuTrung
    @id_dichvu VARCHAR(10), @id_datphong VARCHAR(10)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM chitietsudungdv WHERE id_dichvu = @id_dichvu and id_datphong = @id_datphong)
    BEGIN
		DECLARE @gia FLOAT
		DECLARE @tongtien FLOAT

        SELECT @gia = gia FROM dichvu WHERE id_dichvu = @id_dichvu 
		
		UPDATE chitietsudungdv SET so_luong = so_luong + 1 WHERE id_dichvu = @id_dichvu and id_datphong = @id_datphong

		DECLARE @sl int
		 SELECT @sl = so_luong FROM chitietsudungdv WHERE id_dichvu = @id_dichvu and id_datphong = @id_datphong
		IF @gia IS NOT NULL
		   set @tongtien = @sl * @gia
		   UPDATE chitietsudungdv SET tong_tien_dv = @tongtien
		    WHERE id_dichvu = @id_dichvu and id_datphong = @id_datphong
			
    END
END

GO

--Lấy tổng tiền sử dụng dịch vụ
create proc TongTienSuDungDV
 @id_datphong VARCHAR(10)
as
begin
	select SUM(tong_tien_dv) from chitietsudungdv
	where id_datphong =  @id_datphong
end

GO

---Thanh toán hóa đơn
create proc ThanhToan
@id_datphong varchar(10), @id_nhanvien varchar(10),@id_khachhang varchar(10), @tongtien float
as
begin
	insert into hoadon(id_datphong, id_nhanvien, id_khachhang, ngay_lap, TongTienHD)
	values(@id_datphong, @id_nhanvien, @id_khachhang, default, @tongtien)
end

GO

---Số đơn đặt hàng trong ngày
create proc SoDonDatPhongTrongNgay
as
begin
SELECT COUNT(*)
FROM datphong
WHERE CONVERT(DATE, ngaydat) = CONVERT(DATE, GETDATE());
end

GO

--Danh thu trong ngày
create proc DanhThuTrongNgay
as
begin
SELECT SUM(TongTienHD)
FROM hoadon
WHERE CONVERT(DATE, ngay_lap) = CONVERT(DATE, GETDATE());
end

GO

--Số lượng khách đặt hàng trong ngày
create proc SoLuongKhachThueTrongNgay
as
begin
SELECT COUNT(DISTINCT id_khachhang) AS SoLuongKhachHangDatPhong
FROM datphong
WHERE CONVERT(DATE, ngaydat) = CONVERT(DATE, GETDATE());
end

GO

---Danh sách chi tiết thiết bị
create proc DanhSachChiTietTB
@id_datphong varchar(10)
as
begin
	select cttb.id_thietbi ,tb.ten_thietbi,tb.gia, cttb.so_luong, cttb.tong_tien_tb  from chitietsudungtb cttb , thietbi tb
	where tb.id_thietbi = cttb.id_thietbi and cttb.id_datphong = @id_datphong

end

GO

--Thêm sử dụng thiết bị
create proc ThemSDTB
@id_datphong varchar(10), @id_thietbi varchar(10), @sl int, @thanhtien float
as
begin
	insert into chitietsudungtb(id_datphong,id_thietbi,so_luong,tong_tien_tb, ngay_thue)
	values (@id_datphong, @id_thietbi, @sl, @thanhtien, default)

end

GO

--Sửa sử dụng thiết bị
CREATE PROCEDURE SuaSDTV
    @id_thietbi VARCHAR(10),
    @sl INT
AS
BEGIN
    DECLARE @gia FLOAT
    DECLARE @tongtien FLOAT
    
    SELECT @gia = gia FROM thietbi WHERE id_thietbi = @id_thietbi
    
    IF @gia IS NOT NULL
    BEGIN
        SET @tongtien = @sl * @gia

            UPDATE chitietsudungtb
            SET so_luong = @sl, tong_tien_tb = @tongtien
            WHERE id_thietbi = @id_thietbi
    END
  
END

GO

--Xóa sử dụng thiết bị
create proc XoaSDTB
@id_thietbi varchar(10)
as
begin
	delete from chitietsudungtb where id_thietbi = @id_thietbi
end

GO

--Kiểm tra thiết bị trùng
CREATE PROCEDURE KiemTraThietBiTrung
    @id_thietbi VARCHAR(10), @id_datphong VARCHAR(10)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM chitietsudungtb WHERE id_thietbi = @id_thietbi and id_datphong = @id_datphong)
    BEGIN
		DECLARE @gia FLOAT
		DECLARE @tongtien FLOAT

        SELECT @gia = gia FROM thietbi WHERE id_thietbi = @id_thietbi 
		
		UPDATE chitietsudungtb SET so_luong = so_luong + 1 WHERE id_thietbi = @id_thietbi and id_datphong = @id_datphong

		DECLARE @sl int
		SELECT @sl = so_luong FROM chitietsudungtb WHERE id_thietbi = @id_thietbi and id_datphong = @id_datphong
		IF @gia IS NOT NULL
		   set @tongtien = @sl * @gia

		   UPDATE chitietsudungtb SET tong_tien_tb = @tongtien WHERE id_thietbi = @id_thietbi and id_datphong = @id_datphong
			
    END
END

GO

--Lấy tổng tiền sử dụng thiết bị
create proc TongTienSuDungTB
 @id_datphong VARCHAR(10)
as
begin
	select SUM(tong_tien_tb) from chitietsudungtb
	where id_datphong =  @id_datphong
end

GO

--Lấy mã, tên thiết bị
CREATE PROC DanhSachMavaTenTB

AS BEGIN
	select  id_thietbi + ' | ' + ten_thietbi as 'ThongTinThietBi' from thietbi
END

GO

---Lấy giá thiết bị
create proc LayGiaThietBi
@id_thietbi varchar(10)
as
begin
		select gia from thietbi where id_thietbi = @id_thietbi
end

GO

---Danh sách phòng trống
create proc DanhSachPhongTrong
as
begin
		select  ten  + ' | ' + CONVERT(nvarchar(50) ,so_luong_nguoi) + ' | ' +  trang_thai from phong where trang_thai = N'Còn trống'
end

GO

---Chọn phòng trừ phòng đang ở
create proc PhongCanDoi
@id_phong varchar(10)
as
begin
		select id_phong + ' | ' + ten from phong where trang_thai = N'Còn trống' AND id_phong != @id_phong
end

GO

--Lấy mã , tên khách hàng
create proc LayMaTenKhachHang
as
begin
		select id_khachhang + ' | ' + ten_khachhang  from khachhang
end

GO

---Cập nhập thông tin nhân viên
CREATE PROC CapNhapThongTinNhanVien
@taikhoan VARCHAR(50), @hoten NVARCHAR(50), @ngaysinh DATE, @sdt VARCHAR(10), @gioitinh VARCHAR(6), @email VARCHAR(50), @hinhanh IMAGE

AS BEGIN
	UPDATE nhanvien SET ten_nhanvien = @hoten, ngay_sinh = @ngaysinh, sdt = @sdt, gioi_tinh = @gioitinh, email = @email,
	hinh_anh = @hinhanh where ten_dang_nhap = @taikhoan
END

GO

--Lấy hình nhân viên
CREATE PROC LayAnhNhanVien
@taikhoan varchar(50)
AS BEGIN
	select hinh_anh from nhanvien 
	where ten_dang_nhap = @taikhoan
END

GO

--Top khách hàng
create proc Top1KhachHang
as
begin
SELECT top 1
  kh.id_khachhang  + ' | '+
  kh.ten_khachhang + ' | '+
   CONVERT(varchar(50),   SUM(hd.TongTienHD)) as tongtienhd
FROM
  hoadon hd
JOIN
  khachhang kh
ON
  hd.id_khachhang = kh.id_khachhang
GROUP BY
  kh.id_khachhang,
  kh.ten_khachhang
ORDER BY
  CONVERT(float,   SUM(hd.TongTienHD)) DESC
end

GO

--Doanh thu tháng so với tháng trước
CREATE PROCEDURE TinhTongDoanhThuSoVoiThangTruoc
AS
BEGIN
    DECLARE @ThangHienTai INT;
    DECLARE @NamHienTai INT;

    -- Lấy thông tin về tháng và năm hiện tại
    SET @ThangHienTai = MONTH(GETDATE());
    SET @NamHienTai = YEAR(GETDATE());

    -- Lấy tổng doanh thu trong tháng hiện tại
    DECLARE @DoanhThuThangHienTai DECIMAL(18, 2);
    SELECT @DoanhThuThangHienTai = ISNULL(SUM(TongTienHD), 0)
    FROM HoaDon
    WHERE MONTH(ngay_lap) = @ThangHienTai AND YEAR(ngay_lap) = @NamHienTai;

    -- Lấy tổng doanh thu trong tháng trước
    DECLARE @DoanhThuThangTruoc DECIMAL(18, 2);
    SELECT @DoanhThuThangTruoc = ISNULL(SUM(TongTienHD), 0)
    FROM HoaDon
    WHERE MONTH(ngay_lap) = CASE WHEN @ThangHienTai > 1 THEN @ThangHienTai - 1 ELSE 12 END
      AND YEAR(ngay_lap) = CASE WHEN @ThangHienTai > 1 THEN @NamHienTai ELSE @NamHienTai - 1 END;

    -- In kết quả
    SELECT 
         CAST(@DoanhThuThangHienTai AS NVARCHAR(50))
        + ' | ' + CAST(@DoanhThuThangTruoc AS NVARCHAR(50)) AS KetQua;
END;

GO

--Phòng check in nhiều nhất
create proc PhongCheckInNhieuNhat
as
begin
  SELECT top 1
  p.id_phong + ' | '+
  p.ten + ' | '+
 CONVERT(varchar(50), COUNT(*))  + ' | '+
 CONVERT(varchar(50), MAX(DATEDIFF(day,check_in,check_out )))
FROM
  datphong dp,
  phong p
WHERE
  p.id_phong = dp.id_phong
GROUP BY
  p.id_phong,
  p.ten
ORDER BY
   CONVERT(int, COUNT(*)) DESC,
   CONVERT(int,MAX(DATEDIFF(day,check_in,check_out)))  DESC
end

GO

--Lấy hóa đơn của tháng 1 đến 12
CREATE PROC HoaDonThang
@thang int 
AS BEGIN
    DECLARE @CurrentYear INT = YEAR(GETDATE());

    SELECT 
        SUM(TongTienHD) AS Revenue, 
        Date = DATEADD(MONTH, DATEDIFF(MONTH, 0, CONVERT(DATE, ngay_lap)), 0)
    FROM    
        dbo.HoaDon
    WHERE   
        YEAR(ngay_lap) = @CurrentYear
        AND MONTH(ngay_lap) = @thang
    GROUP BY 
        DATEADD(MONTH, DATEDIFF(MONTH, 0, CONVERT(DATE, ngay_lap)), 0);
END

GO

--Doanh thu theo năm
CREATE PROCEDURE DanhThuTheoNam
    @nam INT
AS
BEGIN
    DECLARE  @tongtien float
     IF EXISTS(SELECT SUM(TongTienHD) AS TongDoanhThu FROM HoaDon WHERE YEAR(CONVERT(DATE, ngay_lap)) = @nam)
		BEGIN
			set @tongtien = (SELECT SUM(TongTienHD) AS TongDoanhThu FROM HoaDon WHERE YEAR(CONVERT(DATE, ngay_lap)) = @nam)
		END
	ELSE
	set @tongtien =0;
	select @tongtien;
END;

GO

--Doanh thu theo quý
CREATE PROCEDURE DoanhThuTheoQuy
    @quy INT,
    @nam INT
AS
BEGIN
    SELECT SUM(TongTienHD) AS TongDoanhThu
    FROM HoaDon
    WHERE DATEPART(QUARTER, CONVERT(DATE, ngay_lap)) = @quy AND YEAR(CONVERT(DATE, ngay_lap)) = @nam;
END;

GO

--Doanh thu theo tháng
CREATE PROCEDURE DoanhThuTheoThang
    @Thang INT,
    @nam INT
AS
BEGIN
	DECLARE  @tongtien float
    IF EXISTS (SELECT SUM(TongTienHD) AS TongDoanhThu FROM HoaDon WHERE MONTH(CONVERT(DATE, ngay_lap)) = @Thang AND YEAR(CONVERT(DATE, ngay_lap)) = @nam)
		BEGIN
			set @tongtien = (SELECT SUM(TongTienHD) AS TongDoanhThu FROM HoaDon WHERE MONTH(CONVERT(DATE, ngay_lap)) = @Thang AND YEAR(CONVERT(DATE, ngay_lap)) = @nam)
		END

	ELSE
			set @tongtien = 0;
	select @tongtien;
END;

GO

--Doanh thu theo ngày
 CREATE PROCEDURE LocDoanhThuTheoNgay
    @NgayTao DATE
AS
BEGIN
    SELECT SUM(TongTienHD) AS TongDoanhThu
    FROM HoaDon
    WHERE CONVERT(DATE, ngay_lap) = @NgayTao;
END;

GO

--Doanh thu theo từ ngày x đến ngày y
 CREATE PROCEDURE LocDoanhThuTheoNgayTuChon
    @ngaybatdau DATE, @ngayketthuc DATE
AS
BEGIN
    SELECT SUM(TongTienHD) AS TongDoanhThu
    FROM HoaDon
    WHERE CONVERT(DATE, ngay_lap) >=  @ngaybatdau and  CONVERT(DATE, ngay_lap) <= @ngayketthuc;
END;

GO

-- Tổng doanh thu
CREATE PROCEDURE TinhTongDoanhThu
AS
BEGIN
    DECLARE @TongDoanhThu DECIMAL(18, 2);

    -- Lấy tổng doanh thu từ bảng HoaDon
    SELECT @TongDoanhThu = ISNULL(SUM(TongTienHD), 0)
    FROM HoaDon;

  SELECT 
         CAST(@TongDoanhThu AS NVARCHAR(50))
END;

GO

--Danh sách hóa đơn đặt phòng thanh toán
create proc DanhSachHoaDonThanToan
as
begin
select  hd.id_hoadon ,dt.id_datphong, dt.ngaydat, nvdt.ten_nhanvien as nhanviendatphong, nv.ten_nhanvien as nhanvienthanhtoan, kh.ten_khachhang, hd.ngay_lap, hd.TongTienHD  from hoadon hd, nhanvien nv, khachhang kh, datphong dt, nhanvien nvdt
where nv.id_nhanvien = hd.id_nhanvien and kh.id_khachhang = hd.id_khachhang and dt.id_datphong = hd.id_datphong and nvdt.id_nhanvien = dt.id_nhanvien
 
end

GO

--Danh sách dịch vụ sử dụng
create proc DanhSachDichVuSuDung
as
begin
select ctdv.id_datphong, dv.ten_dichvu,  ctdv.ngay_thue ,ctdv.so_luong, dv.gia, ctdv.tong_tien_dv  from chitietsudungdv ctdv, datphong dt, dichvu dv
where dt.id_datphong = ctdv.id_datphong and dv.id_dichvu = ctdv.id_dichvu
end

GO

--Danh sách thiết bị sử dụng
create proc DanhSachThietBiSuDung
as
begin
select cttb.id_datphong, tb.ten_thietbi as N'Tên thiết bị',  cttb.ngay_thue ,cttb.so_luong, tb.gia, cttb.tong_tien_tb as  N'Tổng tiền' from chitietsudungtb cttb, datphong dt, thietbi tb
where dt.id_datphong = cttb.id_datphong and tb.id_thietbi = cttb.id_thietbi
end

GO

---Số lượng đặt phòng trong ngày
create proc SoDonDatPhongTrongNgayTheoHoaDon
@ngay Date
as
begin
SELECT COUNT(*) as TongSoHoaDon
FROM hoadon
WHERE ngay_lap = @ngay;
end

GO

---Tổng tiền trong ngày
create proc TongTienDatPhongTrongNgayTheoHoaDon
@ngay Date
as
begin
SELECT SUM(TongTienHD) as TongTienHoaDonTheoNgay
FROM hoadon
WHERE ngay_lap = @ngay;
end

GO

--Danh sách hóa đơn đặt phòng trong ngày
create proc DanhSachHoaDonThanToanTheoNgay
@ngay Date
as
begin
select  hd.id_hoadon ,dt.id_datphong, dt.ngaydat, nvdt.ten_nhanvien as nhanviendatphong, nv.ten_nhanvien as nhanvienthanhtoan, kh.ten_khachhang, hd.ngay_lap, hd.TongTienHD  from hoadon hd, nhanvien nv, khachhang kh, datphong dt, nhanvien nvdt
where nv.id_nhanvien = hd.id_nhanvien and kh.id_khachhang = hd.id_khachhang and dt.id_datphong = hd.id_datphong and nvdt.id_nhanvien = dt.id_nhanvien and hd.ngay_lap = @ngay
end

GO

---Số lượng đặt phòng trong tháng
create proc SoDonDatPhongTrongThangTheoHoaDon
@thang int
as
begin
SELECT COUNT(*) as TongSoHoaDon
FROM hoadon
WHERE MONTH(CONVERT(DATE, ngay_lap)) = @thang;
end

GO

---Tổng tiền trong tháng
create proc TongTienDatPhongTrongThangTheoHoaDon
@thang int
as
begin
SELECT SUM(TongTienHD) as TongTienHoaDonTheoThang
FROM hoadon
WHERE  MONTH(CONVERT(DATE, ngay_lap)) = @thang;
end

GO

--Danh sách hóa đơn đặt phòng trong tháng
create proc DanhSachHoaDonThanToanTheoThang
@thang int
as
begin
select  hd.id_hoadon ,dt.id_datphong, dt.ngaydat, nvdt.ten_nhanvien as nhanviendatphong, nv.ten_nhanvien as nhanvienthanhtoan, kh.ten_khachhang, hd.ngay_lap, hd.TongTienHD  from hoadon hd, nhanvien nv, khachhang kh, datphong dt, nhanvien nvdt
where nv.id_nhanvien = hd.id_nhanvien and kh.id_khachhang = hd.id_khachhang and dt.id_datphong = hd.id_datphong and nvdt.id_nhanvien = dt.id_nhanvien and MONTH(CONVERT(DATE, ngay_lap)) = @thang
 
end

GO

---Số lượng đặt phòng theo quý
create proc SoDonDatPhongTrongQuyTheoHoaDon
@quy int
as
begin
SELECT COUNT(*) as TongSoHoaDon
FROM hoadon
WHERE DATEPART(QUARTER, CONVERT(DATE, ngay_lap)) = @quy;
end

GO

---Tổng tiền trong quý
create proc TongTienDatPhongTrongQuyTheoHoaDon
@quy int
as
begin
SELECT SUM(TongTienHD) as TongTienHoaDonTheoThang
FROM hoadon
WHERE DATEPART(QUARTER, CONVERT(DATE, ngay_lap)) = @quy;
end

GO

--Danh sách đặt phòng theo quý
create proc DanhSachHoaDonThanToanTheoQuy
@quy int
as
begin
select  hd.id_hoadon ,dt.id_datphong, dt.ngaydat, nvdt.ten_nhanvien as nhanviendatphong, nv.ten_nhanvien as nhanvienthanhtoan, kh.ten_khachhang, hd.ngay_lap, hd.TongTienHD  from hoadon hd, nhanvien nv, khachhang kh, datphong dt, nhanvien nvdt
where nv.id_nhanvien = hd.id_nhanvien and kh.id_khachhang = hd.id_khachhang and dt.id_datphong = hd.id_datphong and nvdt.id_nhanvien = dt.id_nhanvien and DATEPART(QUARTER, CONVERT(DATE, ngay_lap)) = @quy;
end

GO

---Số lượng đặt phòng theo năm
create proc SoDonDatPhongTrongNamTheoHoaDon
@nam int
as
begin
SELECT COUNT(*) as TongSoHoaDon
FROM hoadon
WHERE YEAR(CONVERT(DATE, ngay_lap)) = @nam;
end

GO

---Tổng tiền trong Nam
create proc TongTienDatPhongTrongNamTheoHoaDon
@nam int
as
begin
SELECT SUM(TongTienHD) as TongTienHoaDonTheoThang
FROM hoadon
WHERE YEAR(CONVERT(DATE, ngay_lap)) = @nam;
end

GO

--Danh sách hóa đơn đặt phòng theo năm
create proc DanhSachHoaDonThanToanTheoNam
@nam int
as
begin
select  hd.id_hoadon ,dt.id_datphong, dt.ngaydat, nvdt.ten_nhanvien as nhanviendatphong, nv.ten_nhanvien as nhanvienthanhtoan, kh.ten_khachhang, hd.ngay_lap, hd.TongTienHD  from hoadon hd, nhanvien nv, khachhang kh, datphong dt, nhanvien nvdt
where nv.id_nhanvien = hd.id_nhanvien and kh.id_khachhang = hd.id_khachhang and dt.id_datphong = hd.id_datphong and nvdt.id_nhanvien = dt.id_nhanvien and YEAR(CONVERT(DATE, ngay_lap)) = @nam;
 
end

GO

--Danh sách khách hàng
create proc DanhSachKhachHangTheoIDName
as
begin
	select id_khachhang, ten_khachhang  from khachhang
end

GO

--Danh sách nhân viên theo id , name
create proc DanhSachNhanVienTheoIDName
as
begin
	select id_nhanvien, ten_nhanvien  from nhanvien where trangthai = '1'
end

GO

--Danh sách nhân viên đặt phòng 
create proc DanhSachNhanVienDatPhong
@id_nhanvien varchar(10)
as
begin
	select  hd.id_hoadon ,dt.id_datphong, dt.ngaydat, nvdt.ten_nhanvien as nhanviendatphong, nv.ten_nhanvien as nhanvienthanhtoan, kh.ten_khachhang, hd.ngay_lap, hd.TongTienHD  from hoadon hd, nhanvien nv, khachhang kh, datphong dt, nhanvien nvdt
where nv.id_nhanvien = hd.id_nhanvien and kh.id_khachhang = hd.id_khachhang and dt.id_datphong = hd.id_datphong and nvdt.id_nhanvien = dt.id_nhanvien and nv.trangthai = '1' and nvdt.id_nhanvien = @id_nhanvien
end

GO

--Nhân viên thanh toán
create proc DanhSachNhanVienThanhToan
@id_nhanvien varchar(10)
as
begin
	select  hd.id_hoadon ,dt.id_datphong, dt.ngaydat, nvdt.ten_nhanvien as nhanviendatphong, nv.ten_nhanvien as nhanvienthanhtoan, kh.ten_khachhang, hd.ngay_lap, hd.TongTienHD  from hoadon hd, nhanvien nv, khachhang kh, datphong dt, nhanvien nvdt
where nv.id_nhanvien = hd.id_nhanvien and kh.id_khachhang = hd.id_khachhang and dt.id_datphong = hd.id_datphong and nvdt.id_nhanvien = dt.id_nhanvien and nv.trangthai = '1' and nv.id_nhanvien = @id_nhanvien
end

GO

--Danh sách khách hàng đặt phòng 
create proc DanhSachKhachHangDatPhong
@id_khachhang varchar(10)
as
begin
	select  hd.id_hoadon ,dt.id_datphong, dt.ngaydat, nvdt.ten_nhanvien as nhanviendatphong, nv.ten_nhanvien as nhanvienthanhtoan, kh.ten_khachhang, hd.ngay_lap, hd.TongTienHD  from hoadon hd, nhanvien nv, khachhang kh, datphong dt, nhanvien nvdt
where nv.id_nhanvien = hd.id_nhanvien and kh.id_khachhang = hd.id_khachhang and dt.id_datphong = hd.id_datphong and nvdt.id_nhanvien = dt.id_nhanvien and kh.id_khachhang = @id_khachhang
end

GO

---Số lượng dịch vụ trong ngày
create proc SoDonDichVuTrongNgayTheoHoaDon
@ngay Date
as
begin
SELECT COUNT(*) as TongSoDinhVuTheoNgay
FROM chitietsudungdv
WHERE ngay_thue = @ngay;
end

GO

---Tổng tiền dịch vụ trong ngày
create proc TongTienDichVuTrongNgayTheoHoaDon
@ngay Date
as
begin
SELECT SUM(tong_tien_dv) as TongTienDinhVuTheoNgay
FROM chitietsudungdv
WHERE ngay_thue = @ngay;
end

GO

--Danh sách dịch vụ theo ngày
create proc DanhSachDichVuThanToanTheoNgay
@ngay Date
as
begin
select ctdv.id_datphong, dv.ten_dichvu,  ctdv.ngay_thue ,ctdv.so_luong, dv.gia, ctdv.tong_tien_dv  from chitietsudungdv ctdv, datphong dt, dichvu dv
where dt.id_datphong = ctdv.id_datphong and dv.id_dichvu = ctdv.id_dichvu and ctdv.ngay_thue = @ngay
end

GO

---Số lượng dịch vụ trong tháng
create proc SoDonDichVuTrongThangTheoHoaDon
@thang int
as
begin
SELECT COUNT(*) as TongSoDinhVuTheoNgay
FROM chitietsudungdv
WHERE MONTH(CONVERT(DATE, ngay_thue)) = @thang;
end

GO

---Tổng tiền dịch vụ trong tháng
create proc TongTienDichVuTrongThangTheoHoaDon
@thang int
as
begin
SELECT SUM(tong_tien_dv) as TongTienDinhVuTheoNgay
FROM chitietsudungdv
WHERE  MONTH(CONVERT(DATE, ngay_thue)) = @thang;
end

GO

--DS  dịch vụ theo tháng
create proc DanhSachDichVuThanhToanTheoThang
@thang int
as
begin
select ctdv.id_datphong, dv.ten_dichvu,  ctdv.ngay_thue ,ctdv.so_luong, dv.gia, ctdv.tong_tien_dv  from chitietsudungdv ctdv, datphong dt, dichvu dv
where dt.id_datphong = ctdv.id_datphong and dv.id_dichvu = ctdv.id_dichvu and MONTH(CONVERT(DATE, ngay_thue)) = @thang
 
end

GO

---Số lượng  dịch vụ theo quý
create proc SoDonDichVuTrongQuyTheoHoaDon
@quy int
as
begin
SELECT COUNT(*) as TongSoDinhVuTheoNgay
FROM chitietsudungdv
WHERE DATEPART(QUARTER, CONVERT(DATE, ngay_thue)) = @quy;
end

GO

---Tổng tiền  dịch vụ trong quý
create proc TongTienDichVuTrongQuyTheoHoaDon
@quy int
as
begin
SELECT SUM(tong_tien_dv) as TongTienDinhVuTheoNgay
FROM chitietsudungdv
WHERE DATEPART(QUARTER, CONVERT(DATE, ngay_thue)) = @quy;
end

GO

--DS  dịch vụ theo quý
create proc DanhSachDichVuThanToanTheoQuy
@quy int
as
begin
select ctdv.id_datphong, dv.ten_dichvu,  ctdv.ngay_thue ,ctdv.so_luong, dv.gia, ctdv.tong_tien_dv  from chitietsudungdv ctdv, datphong dt, dichvu dv
where dt.id_datphong = ctdv.id_datphong and dv.id_dichvu = ctdv.id_dichvu and DATEPART(QUARTER, CONVERT(DATE, ngay_thue)) = @quy;
 
end

GO

---Số lượng  dịch vụ theo năm
create proc SoDonDichVuTrongNamTheoHoaDon
@nam int
as
begin
SELECT COUNT(*) as TongSoDinhVuTheoNgay
FROM chitietsudungdv
WHERE YEAR(CONVERT(DATE, ngay_thue)) = @nam;
end

GO

---Tổng tiền  dịch vụ trong năm
create proc TongTienDichVuTrongNamTheoHoaDon
@nam int
as
begin
SELECT SUM(tong_tien_dv) as TongTienDinhVuTheoNgay
FROM chitietsudungdv
WHERE YEAR(CONVERT(DATE, ngay_thue)) = @nam;
end

GO

--Danh sách dịch vụ theo năm
create proc DanhSachDichVuThanToanTheoNam
@nam int
as
begin
select ctdv.id_datphong, dv.ten_dichvu,  ctdv.ngay_thue ,ctdv.so_luong, dv.gia, ctdv.tong_tien_dv  from chitietsudungdv ctdv, datphong dt, dichvu dv
where dt.id_datphong = ctdv.id_datphong and dv.id_dichvu = ctdv.id_dichvu and YEAR(CONVERT(DATE, ngay_thue)) = @nam;
 
end

GO

--Danh sách dịch vụ theo loại dịch vụ sử dụng
create proc DanhSachDichVuTheoLoai
@id varchar(10)
as
begin
select ctdv.id_datphong, dv.ten_dichvu,  ctdv.ngay_thue ,ctdv.so_luong, dv.gia, ctdv.tong_tien_dv  from chitietsudungdv ctdv, datphong dt, dichvu dv
where dt.id_datphong = ctdv.id_datphong and dv.id_dichvu = ctdv.id_dichvu and ctdv.id_dichvu = @id
end

GO

--Danh sách tên dịch vụ , id
create proc DanhSachDichVuTheoIDName
as
begin
	select id_dichvu, ten_dichvu  from dichvu
end

GO

--Danh sách phòng tên  , id
create proc DanhSachPhongTheoIDName
as
begin
	select p.id_phong as ma, (lp.ten_loai + ' | ' + p.ten)  as ten from phong p, loaiphong lp
	where p.id_loaiphong = lp.id_loaiphong
end

GO

--Danh sách dịch vụ theo loại phòng sử dụng
create proc DanhSachDichVuTheoLoaiPhong
@id varchar(10)
as
begin
select ctdv.id_datphong, dv.ten_dichvu,  ctdv.ngay_thue ,ctdv.so_luong, dv.gia, ctdv.tong_tien_dv  from chitietsudungdv ctdv, datphong dt, dichvu dv
where dt.id_datphong = ctdv.id_datphong and dv.id_dichvu = ctdv.id_dichvu and dt.id_phong = @id
end

GO

---Số lượng thiết bị trong ngày
create proc SoDonThietBiTrongNgayTheoHoaDon
@ngay Date
as
begin
SELECT COUNT(*) as TongSoDichVu
FROM chitietsudungtb
WHERE ngay_thue = @ngay;
end

GO

---Tổng tiền thiết bị trong ngày
create proc TongTienThietBiTrongNgayTheoHoaDon
@ngay Date
as
begin
SELECT SUM(tong_tien_tb) as TongTienThietBi
FROM chitietsudungtb
WHERE ngay_thue = @ngay;
end

GO

--Danh sách thiết bị theo ngày
create proc DanhSachThietBiThanToanTheoNgay
@ngay Date
as
begin
select cttb.id_datphong, tb.ten_thietbi as N'Tên thiết bị',  cttb.ngay_thue ,cttb.so_luong, tb.gia, cttb.tong_tien_tb as  N'Tổng tiền' from chitietsudungtb cttb, datphong dt, thietbi tb
where dt.id_datphong = cttb.id_datphong and tb.id_thietbi = cttb.id_thietbi and cttb.ngay_thue = @ngay
end

GO

---Số lượng thiết bị trong tháng
create proc SoDonThietBiTrongThangTheoHoaDon
@thang int
as
begin
SELECT COUNT(*) as TongSoDichVu
FROM chitietsudungtb
WHERE MONTH(CONVERT(DATE, ngay_thue)) = @thang;
end

GO

---Tổng tiền thiết bị trong tháng
create proc TongTienThietBiTrongThangTheoHoaDon
@thang int
as
begin
SELECT SUM(tong_tien_tb) as TongTienThietBi
FROM chitietsudungtb
WHERE  MONTH(CONVERT(DATE, ngay_thue)) = @thang;
end

GO

--DS thiết bị theo tháng
create proc DanhSachThietBiThanhToanTheoThang
@thang int
as
begin
select cttb.id_datphong, tb.ten_thietbi as N'Tên thiết bị',  cttb.ngay_thue ,cttb.so_luong, tb.gia, cttb.tong_tien_tb as  N'Tổng tiền' from chitietsudungtb cttb, datphong dt, thietbi tb
where dt.id_datphong = cttb.id_datphong and tb.id_thietbi = cttb.id_thietbi and MONTH(CONVERT(DATE, ngay_thue)) = @thang
 
end

GO

---Số lượng thiết bị theo quý
create proc SoDonThietBiTrongQuyTheoHoaDon
@quy int
as
begin
SELECT COUNT(*) as TongSoDichVu
FROM chitietsudungtb
WHERE DATEPART(QUARTER, CONVERT(DATE, ngay_thue)) = @quy;
end

GO

---Tổng tiền thiết bị trong quý
create proc TongTienThietBiTrongQuyTheoHoaDon
@quy int
as
begin
SELECT SUM(tong_tien_tb) as TongTienThietBi
FROM chitietsudungtb
WHERE DATEPART(QUARTER, CONVERT(DATE, ngay_thue)) = @quy;
end

GO

--DS thiết bị theo quý
create proc DanhSachThietBiThanToanTheoQuy
@quy int
as
begin
select cttb.id_datphong, tb.ten_thietbi as N'Tên thiết bị',  cttb.ngay_thue ,cttb.so_luong, tb.gia, cttb.tong_tien_tb as  N'Tổng tiền' from chitietsudungtb cttb, datphong dt, thietbi tb
where dt.id_datphong = cttb.id_datphong and tb.id_thietbi = cttb.id_thietbi and DATEPART(QUARTER, CONVERT(DATE, ngay_thue)) = @quy;
 
end

GO

---Số lượng thiết bị theo năm
create proc SoDonThietBiTrongNamTheoHoaDon
@nam int
as
begin
SELECT COUNT(*) as TongSoDichVu
FROM chitietsudungtb
WHERE YEAR(CONVERT(DATE, ngay_thue)) = @nam;
end

GO

---Tổng tiền thiết bị trong Nam
create proc TongTienThietBiTrongNamTheoHoaDon
@nam int
as
begin
SELECT SUM(tong_tien_tb) as TongTienThietBi
FROM chitietsudungtb
WHERE YEAR(CONVERT(DATE, ngay_thue)) = @nam;
end

GO

--DanhSach thiết bị theo Nam
create proc DanhSachThietBiThanToanTheoNam
@nam int
as
begin
select cttb.id_datphong, tb.ten_thietbi as N'Tên thiết bị',  cttb.ngay_thue ,cttb.so_luong, tb.gia, cttb.tong_tien_tb as  N'Tổng tiền' from chitietsudungtb cttb, datphong dt, thietbi tb
where dt.id_datphong = cttb.id_datphong and tb.id_thietbi = cttb.id_thietbi and YEAR(CONVERT(DATE, ngay_thue)) = @nam;
 
end

GO

--Danh sách thiết bị theo loại thiết bị sử dụng
create proc DanhSachThietBiTheoLoai
@id varchar(10)
as
begin
select cttb.id_datphong, tb.ten_thietbi as N'Tên thiết bị',  cttb.ngay_thue ,cttb.so_luong, tb.gia, cttb.tong_tien_tb as  N'Tổng tiền' from chitietsudungtb cttb, datphong dt, thietbi tb
where dt.id_datphong = cttb.id_datphong and tb.id_thietbi = cttb.id_thietbi and cttb.id_thietbi = @id
end

GO

--Danh sách tên thiết bị , id
create proc DanhSachThietBiTheoIDName
as
begin
	select id_thietbi, ten_thietbi  from thietbi
end

GO

--Danh sách thiết bị theo loại phòng sử dụng
create proc DanhSachThietBiTheoLoaiPhong
@id varchar(10)
as
begin
select cttb.id_datphong, tb.ten_thietbi as N'Tên thiết bị',  cttb.ngay_thue ,cttb.so_luong, tb.gia, cttb.tong_tien_tb as  N'Tổng tiền' from chitietsudungtb cttb, datphong dt, thietbi tb
where dt.id_datphong = cttb.id_datphong and tb.id_thietbi = cttb.id_thietbi and dt.id_phong = @id
end

GO

--Lọc lịch sử thao tác
create proc LocLichSuThaoTac
@date date
as
begin
	select *from ThaoTacDatPhong where thoigianthuchien = @date
end

GO

--Lọc lịch sử đổi phòng
create proc LocLichSuDoiPhong
@date date
as
begin
	select *from doiphong where ngaythuchien = @date
end

GO

--Danh sách đặt phòng online
create proc DanhSachDatPhongOnline
as
begin
	select id_datphong,phong.id_phong ,khachhang.ten_khachhang, loaiphong.ten_loai, check_in, check_out, dat_coc, datphong.so_nguoi_o, ngaydat
	from datphong, khachhang, phong, loaiphong
	where datphong.id_khachhang = khachhang.id_khachhang and datphong.id_phong = phong.id_phong and phong.id_loaiphong = loaiphong.id_loaiphong and datphong.trang_thai = N'Chờ xác nhận'
end

GO

--Duyệt phòng online
create proc DuyetDatPhongOnline
@id_datphong varchar(10), @id_nhanvien varchar(10)
as
begin
	update datphong
	set trang_thai = N'Chưa thanh toán'
	where id_datphong = @id_datphong and id_nhanvien = @id_nhanvien
end

GO

--cập nhập trạng thái phòng "Đã đặt phòng"
create proc CapNhapTrangThaiPhongOnline
@id_phong varchar(10)
as
begin
	update phong
	set trang_thai = N'Đã đặt phòng'
	where id_phong = @id_phong
end

GO

--Hủy đặt phòng online
create proc HuyDatPhongOnline
@id_datphong varchar(10)
as
begin
	delete from datphong
	where id_datphong = @id_datphong
end


