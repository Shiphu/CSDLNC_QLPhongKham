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