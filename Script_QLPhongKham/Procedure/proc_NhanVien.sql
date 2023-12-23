use CSDLNC_QLPhongKham
go

-- NHÂN VIÊN: Duyệt cuộc hẹn yêu cầu của bệnh nhân
create or alter proc sp_DuyetCHYC @machyc int, @manvql int
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
		insert into HOSOBENHNHAN(TongTienDieuTri, TongTienThanhToan, MaBenhNhan, MaNVQL) values (0,0, @mabn, @manvql)
		print N'Đã lập hồ sơ cho bệnh nhân này'
	end
	delete from CH_YEUCAU where MaCHYC = @machyc;
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
	print N'Xóa cuộc hẹn yêu cầu thành công !!'
end
go


-- NHÂN VIÊN: Tạo cuộc hẹn ở phòng khám với nha sĩ cho bệnh nhân
create or alter proc sp_TaoCuocHenPhongKham @mabenhnhan int, @manhasi int,
					 @ngaygiohen datetime, @manvql int, @maphongkham int
as
begin
	declare @mach_benhnhan int
	
	-- Thêm cuộc hẹn
	insert into CUOCHEN(NgayGioHen, LoaiCuocHen, MaNVQL, MaNhaSi) values (@ngaygiohen, N'bệnh nhân', @manvql, @manhasi)
	
	select @mach_benhnhan = MaCuocHen
	from CUOCHEN
	order by MaCuocHen desc
	
	-- xử lý thứ tự khám 
	declare @dem int
	declare @thutukham int

	select @dem = COUNT(*)
	from CUOCHEN ch, CH_BENHNHAN chbn, PHONGKHAM pk
	where ch.NgayGioHen = @ngaygiohen and ch.MaCuocHen = chbn.MaCHBN and
		chbn.MaPhongKham = pk.MaPhongKham and pk.MaPhongKham = @maphongkham

	if @dem = 0
	begin
		insert into CH_BENHNHAN(MaCHBN, ThuTuKham, MaPhongKham, MaBenhNhan) values
			(@mach_benhnhan, 1, @maphongkham, @mabenhnhan)
	end
	else
	begin
		select @thutukham =  MAX(chbn.ThuTuKham) + 1
		from CUOCHEN ch, CH_BENHNHAN chbn, PHONGKHAM pk
		where ch.NgayGioHen = @ngaygiohen and ch.MaCuocHen = chbn.MaCHBN and
		chbn.MaPhongKham = pk.MaPhongKham and pk.MaPhongKham = @maphongkham

		insert into CH_BENHNHAN(MaCHBN, ThuTuKham, MaPhongKham, MaBenhNhan) values
			(@mach_benhnhan, @thutukham, @maphongkham, @mabenhnhan)
	end
end


go

-- NHÂN VIÊN: Tạo liệu trình cho bệnh nhân
create or alter proc sp_TaoLieuTrinh @sdt_benhnhan varchar(10), @sttgiaidoan int,
					@sorang int, @bematrang nvarchar(100), @tendieutri nvarchar(50)
as 
begin
	declare @mabenhan int --
	declare @mabenhnhan int -- 
	declare @madieutri int --
	declare @marangkham int -- 
	
	-- Lấy mã điều trị
	select @madieutri
	from DIEUTRI where TenDieuTri = @tendieutri

	-- Lấy mã răng khám
	select @marangkham = rbm.MaRangKham
	from RANG_BEMAT rbm, RANG r, BEMATRANG bmr 
	where rbm.MaRang = r.MaRang and rbm.MaBeMat = bmr.MaBeMat and
		r.SoRang = @sorang and bmr.MoTa = @bematrang

	-- Lấy mã bệnh nhân
	if not exists(select * from BENHNHAN where DienThoaiBN = @sdt_benhnhan)
	begin
		print N'Bệnh nhân này không tồn tại !!'
		return
	end
	else
	begin
		select @mabenhnhan = MaBenhNhan from BENHNHAN where DienThoaiBN = @sdt_benhnhan
	end

	-- Lấy mã bệnh án
	if not exists(select * from HOSOBENHNHAN where MaBenhNhan = @mabenhnhan)
	begin
		print N'Hồ sơ bệnh nhân không tồn tại !!'
		return
	end
	else
	begin
		select @mabenhan = MaBenhAn from HOSOBENHNHAN where MaBenhNhan = @mabenhnhan
	end

	insert into GIAIDOAN(MaBenhAn, MaRangKham, MaDieuTri, STTGiaiDoan) values
			(@mabenhan, @marangkham, @madieutri, @sttgiaidoan)
	return
end


go
-- NHÂN VIÊN: Tạo kế hoạch điều trị cho bệnh nhân
create or alter proc sp_TaoKeHoachDieuTri @sdt_benhnhan varchar(10), @ngaykham datetime, 
	@manhasikham nvarchar(50), @phongkham varchar(10), @sorang int, @bematrang nvarchar(100),
	@manvql int
as
begin 
	declare @marangkham int --
	declare @mabenhan int --
	declare @mathanhtoan int --
	declare @mabenhnhan int --
	declare @maphongkham int -- 

	-- Lấy mã răng khám
	select @marangkham = rbm.MaRangKham
	from RANG_BEMAT rbm, RANG r, BEMATRANG bmr 
	where rbm.MaRang = r.MaRang and rbm.MaBeMat = bmr.MaBeMat and
		r.SoRang = @sorang and bmr.MoTa = @bematrang
	
	-- Lấy mã bệnh nhân
	if not exists(select * from BENHNHAN where DienThoaiBN = @sdt_benhnhan)
	begin
		print N'Bệnh nhân này không tồn tại !!'
		return
	end
	else
	begin
		select @mabenhnhan = MaBenhNhan from BENHNHAN where DienThoaiBN = @sdt_benhnhan
	end

	-- Lấy mã bệnh án
	if not exists(select * from HOSOBENHNHAN where MaBenhNhan = @mabenhnhan)
	begin
		print N'Hồ sơ bệnh nhân không tồn tại !!'
		return
	end
	else
	begin
		select @mabenhan = MaBenhAn from HOSOBENHNHAN where MaBenhNhan = @mabenhnhan
	end


	-- Lấy mã phòng khám
	select @maphongkham = MaPhongKham from PHONGKHAM WHERE PhongKham = @phongkham
	

	insert into THANHTOAN (NgayGiaoDich, TienCanThanhToan, TienDaTra, TienThoi, LoaiThanhToan) values
			('', 0, 0, 0, 'cash')

	-- Lấy mã thanh toán
	select @mathanhtoan = MaThanhToan
	from THANHTOAN
	order by MaThanhToan desc

	-- Thêm kế hoạch điều trị vào hệ thống
	insert into KEHOACHDIEUTRI(MaBenhAn, MaRangKham, NgayDieuTri, TrangThaiDieuTri, MaThanhToan, MaNhaSi) values
				(@mabenhan, @marangkham, @ngaykham, N'kế hoạch', @mathanhtoan, @manhasikham)

	-- Tạo cuộc hẹn ở phòng nào với nha sĩ cho bệnh nhân
	exec sp_TaoCuocHenPhongKham @mabenhnhan, @manhasikham, @ngaykham, @manvql, @maphongkham

	print N'Tạo kế hoạch điều trị thành công'
	return 
end