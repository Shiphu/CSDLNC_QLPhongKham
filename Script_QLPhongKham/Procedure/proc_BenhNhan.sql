use CSDLNC_QLPhongKham
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