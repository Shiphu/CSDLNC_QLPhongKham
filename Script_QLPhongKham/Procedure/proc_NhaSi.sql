use CSDLNC_QLPhongKham
go


-- NHA SĨ: cập nhật hồ sơ bẹnh nhân
create or alter proc sp_capNhatHoSoBenhNhan @mabenhnhan int, @suckhoerang nvarchar(100), @tinhtrangdiung nvarchar(100)
as
begin
	if not exists (select * from BENHNHAN where @mabenhnhan = MaBenhNhan)
		begin
			print N'Không tồn tại bệnh nhân này'
			return 
		end
	update HOSOBENHNHAN set SucKhoeRang = @suckhoerang, TinhTrangDiUng = @tinhtrangdiung 
	where MaBenhNhan = @mabenhnhan 
	print N'Cập nhật hồ sơ bệnh nhân thành công'
	return 
end
go

--Cập nhật lại toa thuốc
CREATE OR ALTER PROCEDURE sp_SuaToaThuoc
    @mabenhan int,
    @maThuoc int,
    @soluong int,
    @ChiDinh nvarchar(100)
AS
    IF NOT EXISTS (SELECT * FROM THUOC WHERE MaThuoc = @maThuoc)
    BEGIN
        PRINT N'Thuốc không tồn tại trong hệ thống'
        RETURN
    END
    IF NOT EXISTS (SELECT * FROM HOSOBENHNHAN WHERE MaBenhAn = @mabenhan)
    BEGIN
        PRINT N'Không có bệnh án này'
        RETURN
    END
    IF @soluong <= 0
    BEGIN
        DELETE FROM TOATHUOC
        WHERE MaBenhAn = @mabenhan AND MaThuoc = @maThuoc
    END
    ELSE
    BEGIN
        UPDATE TOATHUOC
        SET SoLuong = @soluong, ChiDinh = @ChiDinh
        WHERE MaBenhAn = @mabenhan AND MaThuoc = @maThuoc
    END
    IF @@ERROR <> 0
    BEGIN
        PRINT N'Có lỗi trong quá trình thực hiện'
        RETURN
    END
    ELSE
    BEGIN
        PRINT N'Cập nhật thành công'
        RETURN
    END
GO

--Thêm thuốc mới vào toa thuốc
CREATE OR ALTER PROCEDURE sp_ThemThuocVaoToa
    @mabenhan int,
    @maThuoc int,
    @soluong int,
    @ChiDinh nvarchar(100)
AS
    IF NOT EXISTS (SELECT * FROM THUOC WHERE MaThuoc = @maThuoc)
    BEGIN
        PRINT N'Thuốc không tồn tại trong hệ thống'
        RETURN;
    END

    IF NOT EXISTS (SELECT * FROM HOSOBENHNHAN WHERE MaBenhAn = @mabenhan)
    BEGIN
        PRINT N'Không có bệnh án này'
        RETURN;
    END

    IF @soluong <= 0
    BEGIN
        PRINT N'Số lượng thuốc kê phải lớn hơn 0'
        RETURN;
    END
    ELSE
    BEGIN
        DECLARE @SLTK INT
        SELECT @SLTK = SLTK FROM THUOC WHERE MaThuoc = @maThuoc

        IF @soluong > @SLTK
        BEGIN
            PRINT N'Số lượng thuốc kê nhiều hơn tồn kho'
            RETURN;
        END
        ELSE
        BEGIN
            INSERT INTO TOATHUOC(MaBenhAn, MaThuoc, SoLuong, ChiDinh, NgayKeThuoc) 
            VALUES (@mabenhan, @maThuoc, @soluong, @ChiDinh, GETDATE())
        END
    END

    IF @@ERROR <> 0
    BEGIN
        PRINT N'Có lỗi trong quá trình thực hiện'
        RETURN;
    END
    ELSE
    BEGIN
        PRINT N'Cập nhật thành công'
        RETURN;
    END
GO