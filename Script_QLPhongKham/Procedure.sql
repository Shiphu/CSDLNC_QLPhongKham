use CSDLNC_QLPhongKham
go

--- PHÂN HỆ CHUNG: Xác thực tài khoản đăng nhập hợp lệ --- Commands completed successfully.
create or alter proc sp_XacThucTaiKhoan 
    @sdt varchar(10), @matkhau varchar(50), @loaivt int out
as 
    --Kiem tra Quan Tri Vien
    if (@sdt = '0123456789' and @matkhau = (select MatKhauQTV from QUANTRIVIEN where @sdt = TenDangNhapQTV))
        begin
            set @loaivt = 1
            return @loaivt
        end
    --Kiem tra tai khoan ton tai
    if not exists (
        select *
        from TAIKHOAN
        where @sdt = TenDangNhap and @matkhau = MatKhau
    )
    begin
        set @loaivt = 0
		print N'TÀI KHOẢN KHÔNG TỒN TẠI! HÃY THỬ LẠI'
        return @loaivt
    end
    else
        begin
            declare @vaitro varchar(10)
            declare @ttrang varchar(10)
            select @vaitro = MAVT, @ttrang = TinhTrang from TAIKHOAN where  @sdt = TenDangNhap and @matkhau = MatKhau
            if (@ttrang = 'disable')
                begin
                    set @loaivt = -1
					print N'TÀI KHOẢN ĐÃ BỊ KHÓA !!!'
                    return @loaivt
                end
            else 
                begin 
                    if (@vaitro = 'NS')
                        begin
                            set @loaivt = 2
                            return @loaivt
                        end 
                    else if (@vaitro = 'NV')
                        begin
                            set @loaivt = 3
                            return @loaivt
                        end
                end
        end
go



--- KHÁCH HÀNG: Khách hàng đặt online cuộc hẹn yêu cầu trên hệ thống ---  Commands completed successfully.
create or alter proc sp_ThemCuocHenYeuCau 
					@hoten nvarchar(50), @ngsinh date, @diachi nvarchar(100),
					@phone varchar(10), @email varchar(50), @gender nvarchar(4),
					@tinhtrangbenh nvarchar(100), @thoigianYC date
as

begin
	-- Kiểm tra bệnh nhân mới hay cũ
	if not exists (select * from BENHNHAN where HoTenBN = @hoten and @ngsinh = NgSinhBN)
	begin
		insert into BENHNHAN(HoTenBN, NgSinhBN, DiaChiBN, DienThoaiBN, EmailBN, GioiTinhBN) values
			(@hoten, @ngsinh, @diachi, @phone, @email, @gender)
	end
		
	declare @mabn int
	select @mabn = MaBenhNhan
	from BENHNHAN
	where HoTenBN = @hoten 

	insert into CH_YEUCAU(TinhTrangBenh, ThoiGianYC, MaBenhNhan) values
		(@tinhtrangbenh, @thoigianYC, @mabn)

	if @@ERROR <>0
	begin
		print N'Đã có lỗi xảy ra, xin quý khách đặt lại'
		return 
	end
	print N'ĐẶT LỊCH HẸN THÀNH CÔNG'
	return
end

go

-- QUẢN TRỊ VIÊN: Thêm loại thuốc mới -- Commands completed successfully.
create or alter proc sp_ThemThuocMoi @tenthuoc nvarchar(100), @donvi nvarchar(10), @chongchidinh nvarchar(100), @ngayhethan date
as
begin
    if exists (
        select *
        from THUOC
        where @tenthuoc = TenThuoc and @donvi = DonVi and @chongchidinh = ChongChiDinh and @ngayhethan = NgayHetHan
    )
    begin
        print N'Thuốc đã tồn tại'
        return 
    end
    else 
        begin 
            if (DATEDIFF(DAY, @ngayhethan, GETDATE()) > 0)
            begin
                print N'Ngày hết hạn không phù hợp'
                return
            end
            else 
            begin
                insert into THUOC(TenThuoc, DonVi, ChongChiDinh, NgayHetHan, MaQTV, SLTK) values (@tenthuoc, @donvi, @chongchidinh, @ngayhethan, 1, 0)
                print N'Thêm thuốc thành công'
            end
			return
        end
end
go

-- QUẢN TRỊ VIÊN: Cập nhật số lượng tồn kho của thuốc -- Commands completed successfully.
create or alter proc sp_CapNhatSLTK @mathuoc int, @soluong int
as
begin
    if not exists (
        select* 
        from THUOC
        where @mathuoc = MaThuoc
    )
    begin 
        print N'Thuốc không tồn tại'
		return
    end
    else 
    begin
        declare @sltk int
        select @sltk = SLTK from THUOC where @mathuoc = MaThuoc
        set @sltk = @sltk + @soluong
        update THUOC set SLTK = @sltk where @mathuoc = MaThuoc
        print N'Cập nhật số lượng tồn kho thành công'
		return
    end
end
go


-- QUẢN TRỊ VIÊN: Thêm tài khoản cho nhân viên và nha sĩ  --- Commands completed successfully. 
CREATE OR ALTER PROC sp_ThemTaiKhoan
    @tendangnhap VARCHAR(10),
    @matkhau VARCHAR(50),
    @hoten NVARCHAR(50),
    @ngsinh DATE,
    @diachi NVARCHAR(100),
    @mavt VARCHAR(10)
AS
BEGIN
    DECLARE @existedAccount INT
    IF EXISTS ( SELECT MaTaiKhoan FROM TAIKHOAN WHERE TenDangNhap = @tendangnhap )
    BEGIN
        PRINT N'Tài khoản đã tồn tại trong hệ thống';
        RETURN;
    END
    INSERT INTO TAIKHOAN(TenDangNhap, MatKhau, MaVT, TinhTrang, MaQTV) 
    VALUES (@tendangnhap, @matkhau, @mavt, 'enable', 1)
    SELECT @existedAccount = SCOPE_IDENTITY() --hàm có sẵn, trả về identity của table vừa Insert vào
    IF @mavt = 'NS'
    BEGIN
        INSERT INTO NHASI(MaNhaSi, HoTenNS, NgSinhNS, DiaChiNS, DienThoaiNS) 
        VALUES (@existedAccount, @hoten, @ngsinh, @diachi, @tendangnhap)
    END
    ELSE IF @mavt = 'NV'
    BEGIN
        INSERT INTO NHANVIEN(MaNhanVien, HoTenNV, NgSinhNV, DiaChiNV, DienThoaiNV) 
        VALUES (@existedAccount, @hoten, @ngsinh, @diachi, @tendangnhap)
    END
    ELSE
    BEGIN
        PRINT N'Không tồn tại vai trò này'
        RETURN;
    END
    IF @@ERROR <> 0
    BEGIN
        RETURN;
    END
    ELSE
    BEGIN
        PRINT N'Thêm tài khoản thành công!!!'
        RETURN;
    END
END

go


-- QUANTRIVIEN: Thống kê lịch hẹn yêu cầu theo NGÀY (trong khoảng thời gian từ NgàyBD đến NgàyKT trong cùng 1 tháng)
create or alter proc sp_ThongKeLichHenYeuCauTheoNgay @NgayBD datetime, @NgayKT datetime
as
	begin
		select DATEPART(day, ThoiGianYC) as N'Ngày', COUNT(*) as N'Số lượng cuộc hẹn yêu cầu'
		from CH_YEUCAU
		where ThoiGianYC between @NgayBD and @NgayKT
		group by DATEPART(day, ThoiGianYC)
		order by DATEPART(day, ThoiGianYC)
	end
go

-- QUANTRIVIEN: Thống kê lịch hẹn yêu cầu theo THÁNG (trong khoảng thời gian từ NgàyBD đến NgàyKT trong cùng 1 năm)
create or alter proc sp_ThongKeLichHenYeuCauTheoThang @NgayBD datetime, @NgayKT datetime
as
	begin
		select DATEPART(month, ThoiGianYC) as N'Tháng', COUNT(*) as N'Số lượng cuộc hẹn yêu cầu'
		from CH_YEUCAU
		where ThoiGianYC between @NgayBD and @NgayKT
		group by DATEPART(month, ThoiGianYC)
		order by DATEPART(month, ThoiGianYC)
	end
go

-- QUANTRIVIEN: Thống kê lịch hẹn khám trong ngày theo từng NHA SĨ (trong một ngày được chỉ định)
create or alter proc sp_ThongKeLichHenKhamTrongNgayTheoTungNhaSi @NgayThongKe datetime
as
	begin
		select MaNhaSi as N'Mã nha sĩ', count(*) as N'Số lượng lịch hẹn khám'
		from CUOCHEN CH join CH_BENHNHAN CHBN on CH.MaCuocHen = CHBN.MaCHBN and LoaiCuocHen = N'bệnh nhân'
		where cast(NgayGioHen as date) = cast(@NgayThongKe as date)
		GROUP BY MaNhaSi
		ORDER BY MaNhaSi
	end
go

-- QUANTRIVIEN: Thống kê lịch hẹn khám theo NGÀY (trong khoảng thời gian từ NgàyBD đến NgàyKT trong cùng 1 tháng) 
create or alter proc sp_ThongKeLichHenKhamTheoNgay @NgayBD datetime, @NgayKT datetime
as
	begin
		select DATEPART(day, NgayGioHen) as N'Ngày', count(*) as N'Số lượng lịch hẹn khám'
		from CUOCHEN CH join CH_BENHNHAN CHBN on CH.MaCuocHen = CHBN.MaCHBN and LoaiCuocHen = N'bệnh nhân'
		where NgayGioHen between @NgayBD and @NgayKT
		GROUP BY DATEPART(day, NgayGioHen)
		ORDER BY DATEPART(day, NgayGioHen)
	end
go

-- QUANTRIVIEN: Thêm cuộc hẹn làm việc của nha sĩ
CREATE OR ALTER PROC ADD_LICHHEN_NHASI 
    @MaNhaSi int,
    @NgayGioBan datetime,
    @MoTaHD nvarchar(100)
AS
BEGIN
    BEGIN TRY
		IF EXISTS (SELECT * 
					FROM CUOCHEN
					WHERE @NgayGioBan = NgayGioHen
					)
				BEGIN
					PRINT N'Đã có khách hàng đặt lịch. Vui lòng chọn thời gian khác!'
					ROLLBACK TRAN
					RETURN
				END
			ELSE
				BEGIN
					DECLARE @MaCHCN INT
					INSERT INTO CUOCHEN (NgayGioHen, LoaiCuocHen, MaNVQL, MaNhaSi)
								VALUES (@NgayGioBan, N'cá nhân', NULL, @MaNhaSi)
					SET @MaCHCN = (SELECT TOP 1 MaCuocHen
										FROM CUOCHEN
										WHERE NgayGioHen = @NgayGioBan)
					INSERT INTO CH_CANHAN(MaCHCN, MoTaHD, MaQTV) VALUES (@MaCHCN, @MoTaHD, 1)
				END
    END TRY
    BEGIN CATCH
        IF @@ERROR <> 0
            RETURN;
		PRINT N'Có lỗi trong quá trình thực hiện'
    END CATCH
END
GO

-- NHASI: 

-- NHÂN VIÊN: Duyệt cuộc hẹn yêu cầu của bệnh nhân
create or alter proc sp_DuyetCHYC @machyc int
as
begin
	if not exists(select * from CH_YEUCAU where MaCHYC = @machyc)
	begin
		print N'Mã cuộc hẹn yêu cầu không tồn tại' 
		return -- không tồn tại tại CHYC này
	end
	-- Lấy mã bệnh nhân
	declare @mabn int
	select @mabn = MaBenhNhan
	from CH_YEUCAU
	where @machyc = MaCHYC

	-- trường hợp bệnh nhân mới
	if not exists (select * from HOSOBENHNHAN where MaBenhNhan = @mabn)
	begin 
		insert into HOSOBENHNHAN(TongTienDieuTri, TongTienThanhToan, MaBenhNhan) values (0,0, @mabn)
	end
	delete from CH_YEUCAU where MaCHYC = MaCHYC
	print N'Duyệt cuộc hẹn thành công'
	return
end

go
-- NHÂN VIÊN: Xóa cuộc hẹn yêu cầu của bệnh nhân
create or alter proc sp_XoaCHYC @machyc int
as
begin
	if not exists(select * from CH_YEUCAU where MaCHYC = @machyc)
	begin
		print N'Mã cuộc hẹn yêu cầu không tồn tại'
		return
	end

	delete from CH_YEUCAU where MaCHYC = @machyc
end
go


-- NHÂN VIÊN: Tạo cuộc hẹn với nha sĩ cho bệnh nhân
-- NHÂN VIÊN: Tạo kế hoạch điều trị cho bệnh nhân