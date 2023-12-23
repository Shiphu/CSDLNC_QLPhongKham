create database CSDLNC_QLPhongKham
go
use CSDLNC_QLPhongKham
go

create table VAITRO
(
	MaVT varchar(10) check (MaVT IN ('NV', 'NS')),
	TenVaiTro nvarchar(50) check (TenVaiTro IN (N'nha sĩ', N'nhân viên'))
	primary key (MaVT)
)

create table TAIKHOAN
(
	MaTaiKhoan int identity(1,1),
	TenDangNhap varchar(10),
	MatKhau varchar(50),
	TinhTrang varchar(10) check (TinhTrang IN ('enable', 'disable')),
	MaVT varchar(10),
	MaQTV int
	primary key(MaTaiKhoan)
)

create table NHASI
(
	MaNhaSi int,
	HoTenNS nvarchar(50),
	NgSinhNS date,
	DiaChiNS nvarchar(100),
	DienThoaiNS varchar(10) not null unique,
	primary key(MaNhaSi)
)

create table NHANVIEN
(
	MaNhanVien int,
	HoTenNV nvarchar(50),
	NgSinhNV date,
	DiaChiNV nvarchar(100),
	DienThoaiNV varchar(10) not null unique,
	primary key (MaNhanVien)
)

create table QUANTRIVIEN
(
	MaQTV int identity(1,1),
	TenDangNhapQTV nvarchar(10) not null,
	MatKhauQTV varchar(50) not null
	primary key (MaQTV)
)

create table BENHNHAN
(
	MaBenhNhan int identity(1,1),
	HoTenBN nvarchar(50),
	NgSinhBN date,
	DiaChiBN nvarchar(100),
	DienThoaiBN varchar(10) not null unique,
	EmailBN varchar(50),
	GioiTinhBN nvarchar(4) check (GioiTinhBN IN('Nam', N'Nữ'))
	primary key (MaBenhNhan)
)

create table CH_YEUCAU
(
	MaCHYC int identity(1,1),
	TinhTrangBenh nvarchar(100),
	ThoiGianYC date,
	MaBenhNhan int,
	MaNhanVien int
	primary key (MaCHYC)
)

create table HOSOBENHNHAN
(
	MaBenhAn int identity(1,1),
	TongTienDieuTri bigint,
	TongTienThanhToan bigint,
	SucKhoeRang nvarchar(100),
	TinhTrangDiUng nvarchar(100),
	GiayGioiThieu nvarchar(100),
	MaBenhNhan int,
	MaNVQL int
	primary key (MaBenhAn)
)

create table KEHOACHDIEUTRI
(
	MaBenhAn int, 
	MaRangKham int,
	MoTa nvarchar(100),
	NgayDieuTri datetime,
	TrangThaiDieuTri nvarchar(50) check(TrangThaiDieuTri IN (N'kế hoạch', N'đã hoàn thành', N'đã hủy')),
	GhiChu nvarchar(100),
	MaThanhToan int,
	MaNhaSi int not null,
	MaTroKham int,
	primary key (MaBenhAn, MaRangKham)
)

create table THANHTOAN
(
	MaThanhToan int identity(1,1),
	NgayGiaoDich datetime,
	TienCanThanhToan bigint,
	TienDaTra bigint,
	TienThoi bigint,
	LoaiThanhToan varchar(10) check (LoaiThanhToan IN ('cash', 'credit')),
	primary key (MaThanhToan)
)

create table RANG
(
	MaRang int identity(1,1),
	SoRang int not null
	primary key (MaRang),
	unique(SoRang)
)

create table RANG_BEMAT
(
	MaRangKham int identity (1,1),
	MaRang int,
	MaBeMat int
	primary key (MaRangKham)
)

create table BEMATRANG
(
	MaBeMat int identity(1,1),
	MoTa nvarchar(100)
	primary key(MaBeMat)
)

create table GIAIDOAN
(
	MaBenhAn int,
	MaRangKham int,
	MaDieuTri int,
	STTGiaiDoan int check (STTGiaiDoan IN (1,2,3,4,5))
	primary key(MaBenhAn,MaRangKham,MaDieuTri)
)

create table DIEUTRI
(
	MaDieuTri int identity(1,1),
	TenDieuTri nvarchar(50) not null,
	MoTa nvarchar(100),
	PhiDieuTri int
	primary key (MaDieuTri)
)

create table TOATHUOC
(
	MaBenhAn int, 
	MaThuoc int,
	ChiDinh nvarchar(100),
	SoLuong int not null,
	NgayKeThuoc date
	primary key(MaBenhAn, MaThuoc)
)

create table THUOC
(
	MaThuoc int identity(1,1),
	TenThuoc nvarchar(100),
	DonVi nvarchar(10) check (DonVi IN (N'hộp', N'vỉ', N'lọ', N'viên')),
	ChongChiDinh nvarchar(100),
	SLTK int,
	NgayHetHan date,
	MaQTV int
	primary key (MaThuoc)
)

create table CUOCHEN
(
	MaCuocHen int identity(1,1),
	NgayGioHen datetime,
	LoaiCuocHen nvarchar(10) check (LoaiCuocHen IN (N'bệnh nhân', N'cá nhân')),
	MaNVQL int,
	MaNhaSi int
	primary key (MaCuocHen)
)

create table CH_BENHNHAN
(
	MaCHBN int,
	ThuTuKham int not null,
	TinhTrang nvarchar(100),
	MaPhongKham int,
	MaBenhNhan int,
	primary key(MaCHBN)
)

create table CH_CANHAN
(
	MaCHCN int, 
	MoTaHD nvarchar(100),
	MaQTV int
	primary key(MaCHCN)
)

create table PHONGKHAM
(
	MaPhongKham int identity(1,1),
	PhongKham varchar(10)
	primary key(MaPhongKham)
)

alter table TAIKHOAN add
	constraint FK_TAIKHOAN_VAITRO foreign key (MaVT) references VAITRO (MaVT),
	constraint FK_TAIKHOAN_QUANTRIVIEN foreign key(MaQTV) references QUANTRIVIEN(MaQTV)

alter table NHASI add
	constraint FK_NHASI_TAIKHOAN foreign key (MaNhaSi) references TAIKHOAN(MaTaiKhoan)

alter table NHANVIEN add
	constraint FK_NHANVIEN_TAIKHOAN foreign key (MaNhanVien) references TAIKHOAN(MaTaiKhoan)

alter table CH_YEUCAU add
	constraint FK_CH_YEUCAU_BENHNHAN foreign key (MaBenhNhan) references BENHNHAN(MaBenhNhan),
	constraint FK_CH_YEUCAU_NHANVIEN foreign key (MaNhanVien) references NHANVIEN(MaNhanVien)

alter table HOSOBENHNHAN add
	constraint FK_HOSOBENHNHAN_BENHNHAN foreign key (MaBenhNhan) references BENHNHAN(MaBenhNhan),
	constraint FK_HOSEBENHNHAN_NHANVIEN foreign key (MaNVQL) references NHANVIEN(MaNhanVien)

alter table KEHOACHDIEUTRI add
	constraint FK_KEHOACHDIEUTRI_THANHTOAN foreign key (MaThanhToan) references THANHTOAN(MaThanhToan),
	constraint FK_KEHOACHDIEUTRI_HOSOBENHNHAN foreign key (MaBenhAn) references HOSOBENHNHAN(MaBenhAn),
	constraint FK_KEHOACHDIEUTRI_RANG_BEMAT foreign key (MaRangKham) references RANG_BEMAT(MaRangKham),
	constraint FK_KEHOACHDIEUTRI_NHASI foreign key (MaNhaSi) references NHASI(MaNhaSi),
	constraint FK_KEHOACHDIEUTRI_TROKHAM foreign key (MaTroKham) references NHASI(MaNhaSi)

alter table RANG_BEMAT add
	constraint FK_RANG_BEMAT_RANG foreign key (MaRang) references RANG(SoRang),
	constraint FK_RANG_BEMAT_BEMATRANG foreign key (MaBeMat) references BEMATRANG(MaBeMat)

alter table GIAIDOAN add
	constraint FK_GIAIDOAN_KEHOACHDIEUTRI foreign key (MaBenhAn, MaRangKham) references KEHOACHDIEUTRI(MaBenhAn, MaRangKham),
	constraint FK_GIAIDOAN_DIEUTRI foreign key (MaDieuTri) references DIEUTRI(MaDieuTri)

alter table TOATHUOC add
	constraint FK_TOATHUOC_HOSOBENHNHAN foreign key (MaBenhAn) references HOSOBENHNHAN(MaBenhAn),
	constraint FK_TOATHUOC_THUOC foreign key (MaThuoc) references THUOC(MaThuoc)

alter table THUOC add
	constraint FK_THUOC_QUANTRIVIEN foreign key (MaQTV) references QUANTRIVIEN(MaQTV)

alter table CUOCHEN add
	constraint FK_CUOCHEN_NHANVIEN foreign key (MaNVQL) references NHANVIEN(MaNhanVien),
	constraint FK_CUOCHEN_NHASI foreign key (MaNhaSi) references NHASI(MaNhaSi)
	
alter table CH_BENHNHAN add
	constraint FK_CH_BENHNHAN_CUOCHEN foreign key (MaCHBN) references CUOCHEN(MaCuocHen),
	constraint FK_CH_BENHNHAN_PHONGKHAM foreign key (MaPhongKham) references PHONGKHAM(MaPhongKHam),
	constraint FK_CH_BENHNHAN_BENHNHAN_ foreign key (MaBenhNhan) references BENHNHAN(MaBenhNhan)

alter table CH_CANHAN add
	constraint FK_CH_CANHAN_CUOCHEN foreign key (MaCHCN) references CUOCHEN(MaCuocHen),
	constraint FK_CH_CANHAN_QUANTRIVIEN foreign key (MaQTV) references QUANTRIVIEN(MaQTV)