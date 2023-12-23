use CSDLNC_QLPhongKham
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


-- QUANTRIVIEN: Thống kê các kế hoạch điều trị được tạo trong NGÀY theo từng NHA SĨ (trong một ngày chỉ định)
create or alter proc sp_ThongKeKeHoachDieuTriTrongNgayTheoTungNhaSi @NgayThongKe datetime
as
	begin
		select MaNhaSi as N'Mã nha sĩ', COUNT(*) as N'Số kế hoạch điều trị'
		from KEHOACHDIEUTRI
		where cast(NgayDieuTri as date) = cast(@NgayThongKe as date)
		group by MaNhaSi
		order by MaNhaSi
	end
go

-- QUANTRIVIEN: Thống kê các kế hoạch điều trị  được tạo theo NGÀY (trong khoảng thời gian từ NgàyBD đến NgàyKT trong cùng 1 tháng)
create or alter proc sp_ThongKeKeHoachDieuTriTheoNgay @NgayBD datetime, @NgayKT datetime
as
	begin
		select DATEPART(day, NgayDieuTri) as N'Ngày', count(*) as N'Số kế hoạch điều trị'
		from KEHOACHDIEUTRI
		where NgayDieuTri between @NgayBD and @NgayKT
		GROUP BY DATEPART(day, NgayDieuTri)
		ORDER BY DATEPART(day, NgayDieuTri)
	end
go


-- QUANTRIVIEN: 19 - Thống kê lịch hẹn khám trong NGÀY theo từng NHA SĨ (trong một ngày được chỉ định)
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

-- QUANTRIVIEN: 20 - Thống kê lịch hẹn khám theo NGÀY (trong khoảng thời gian từ NgàyBD đến NgàyKT trong cùng 1 tháng) 
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

-- QUANTRIVIEN: 21 - Thống kê lịch hẹn khám theo THÁNG (trong khoảng thời gian từ NgàyBD đến NgàyKT trong cùng 1 năm) 
create or alter proc sp_ThongKeLichHenKhamTheoThang @NgayBD datetime, @NgayKT datetime
as
	begin
		select DATEPART(month, NgayGioHen) as N'Tháng', count(*) as N'Số lượng lịch hẹn khám'
		from CUOCHEN CH join CH_BENHNHAN CHBN on CH.MaCuocHen = CHBN.MaCHBN and LoaiCuocHen = N'bệnh nhân'
		where NgayGioHen between @NgayBD and @NgayKT
		GROUP BY DATEPART(month, NgayGioHen)
		ORDER BY DATEPART(month, NgayGioHen) 
	end
go


-- QUANTRIVIEN: 22 - Thống kê lịch hẹn khám theo NĂM (trong khoảng thời gian từ NgàyBD đến NgàyKT) 
create or alter proc sp_ThongKeLichHenKhamTheoNam @NgayBD datetime, @NgayKT datetime
as
	begin
		select DATEPART(year, NgayGioHen) as N'Năm', count(*) as N'Số lượng lịch hẹn khám'
		from CUOCHEN CH join CH_BENHNHAN CHBN on CH.MaCuocHen = CHBN.MaCHBN and LoaiCuocHen = N'bệnh nhân'
		where NgayGioHen between @NgayBD and @NgayKT
		GROUP BY DATEPART(year, NgayGioHen)
		ORDER BY DATEPART(year, NgayGioHen)
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

-- QUANTRIVIEN: Thêm điều trị mới cho phòng khám
create or alter proc sp_themDieuTri @tendieutri nvarchar(50), @mota nvarchar(100), @phidieutri int
as
begin
	if exists (select * from dieutri where @tendieutri = tendieutri )
	begin
		print N'Điều trị này đã tồn tại'
		return 0
	end
	insert into DIEUTRI(TenDieuTri,MoTa,PhiDieuTri) values(@tendieutri,@mota,@phidieutri)
	print N'Thêm điều trị thành công'
	return 1
end
go

-- QUANTRIVIEN: Cập nhật giá điều trị
create or alter proc sp_capNhatGiaDieuTri @tendieutri nvarchar(50), @phidieutri int
as
begin 
	if not exists (select * from dieutri where @tendieutri = tendieutri )
	begin
		print N'Điều trị này không tồn tại'
		rollback tran
		return 0
	end
	update DIEUTRI set PhiDieuTri = @phidieutri where TenDieuTri = @tendieutri
	print N'Cập nhật phí điều trị thành công'
	return 1
end
go