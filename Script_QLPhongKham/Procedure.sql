use CSDLNC_QLPhongKham
go

--- Xác thực tài khoản đăng nhập hợp lệ
create or alter proc sp_XacThucTaiKhoan 
    @sdt varchar(10), @matkhau varchar(50), @loaivt int out
as 
    --Kiem tra Quan Tri Vien
    if (@sdt = '0123456789' and @matkhau = '123')
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

--- KHÁCH HÀNG: Khách hàng đặt online cuộc hẹn yêu cầu trên hệ thống
create or alter proc sp_ThemCuocHenYeuCau 
					@hoten nvarchar(50), @ngsinh date, @diachi nvarchar(100),
					@phone varchar(10), @email varchar(50), @gender nvarchar(4),
					@tinhtrangbenh nvarchar(100), @thoigianYC date, @manvql int 
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

	insert into CH_YEUCAU(TinhTrangBenh, ThoiGianYC, MaBenhNhan, MaNhanVien) values
		(@tinhtrangbenh, @thoigianYC, @mabn, @manvql)

	if @@ERROR <>0
	begin
		return 
	end
	return
end

go

-- QUẢN TRỊ VIÊN: Thêm loại thuốc mới
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

-- QUẢN TRỊ VIÊN: Cập nhật số lượng tồn kho của thuốc
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


-- QUẢN TRỊ VIÊN: Thêm tài khoản cho nhân viên và nha sĩ
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


-- NHÂN VIÊN: tạo kế hoạch điều trị cho bệnh nhân






