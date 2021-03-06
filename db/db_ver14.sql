USE [master]
GO
/****** Object:  Database [Bank_LTHD]    Script Date: 5/26/2020 10:44:52 AM ******/
CREATE DATABASE [Bank_LTHD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bank_LTHD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Bank_LTHD.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Bank_LTHD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Bank_LTHD_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Bank_LTHD] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bank_LTHD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bank_LTHD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bank_LTHD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bank_LTHD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bank_LTHD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bank_LTHD] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bank_LTHD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bank_LTHD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bank_LTHD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bank_LTHD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bank_LTHD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bank_LTHD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bank_LTHD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bank_LTHD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bank_LTHD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bank_LTHD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bank_LTHD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bank_LTHD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bank_LTHD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bank_LTHD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bank_LTHD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bank_LTHD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bank_LTHD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bank_LTHD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Bank_LTHD] SET  MULTI_USER 
GO
ALTER DATABASE [Bank_LTHD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bank_LTHD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bank_LTHD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bank_LTHD] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Bank_LTHD] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Bank_LTHD]
GO
/****** Object:  Table [dbo].[DanhBa]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DanhBa](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[matk] [varchar](100) NOT NULL,
	[sotaikhoan] [varchar](100) NOT NULL,
	[tentaikhoan] [varchar](100) NULL,
	[tengoinho] [varchar](100) NOT NULL,
	[tennganhang] [varchar](200) NULL,
	[idnganhanglienket] [int] NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiTaiKhoan]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiTaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenloaitaikhoan] [varchar](100) NOT NULL,
 CONSTRAINT [PK_LoaiTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NganHangLienKet]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NganHangLienKet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tennganhang] [varchar](100) NOT NULL,
	[secretKey] [varchar](200) NULL,
	[publicKey] [varchar](max) NULL,
 CONSTRAINT [PK_NganHangLienKet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhacNo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhacNo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[matktao] [varchar](100) NOT NULL,
	[matkno] [varchar](100) NOT NULL,
	[sotienno] [money] NOT NULL,
	[noidungnhacno] [nvarchar](max) NOT NULL,
	[ngaytao] [date] NOT NULL,
	[noidunghuynhacno] [nvarchar](max) NULL,
	[trangthai] [int] NOT NULL,
 CONSTRAINT [PK_NhacNo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[tendangnhap] [varchar](100) NOT NULL,
	[matkhau] [varchar](100) NOT NULL,
	[idloaitaikhoan] [int] NOT NULL,
	[mataikhoan] [varchar](100) NOT NULL,
	[refreshToken] [varchar](max) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[mataikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongBao]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongBao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[matk] [varchar](100) NOT NULL,
	[noidung] [nvarchar](500) NOT NULL,
	[trangthai] [bit] NOT NULL,
 CONSTRAINT [PK_ThongBao] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinChuyenTienNoiBo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinChuyenTienNoiBo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[maTk] [varchar](100) NOT NULL,
	[ngayGD] [date] NOT NULL,
	[stkGui] [varchar](100) NOT NULL,
	[stkNhan] [varchar](100) NOT NULL,
	[sotiengui] [money] NOT NULL,
	[noidung] [varchar](200) NULL,
	[loaitraphi] [bit] NOT NULL,
	[trangthaichuyentien] [bit] NOT NULL,
 CONSTRAINT [PK_ThongTinChuyenTienNoiBo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinGiaoDichLienNganHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinGiaoDichLienNganHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[soTkGui] [varchar](100) NOT NULL,
	[tenNganHangGui] [varchar](100) NOT NULL,
	[soTkNhan] [varchar](100) NOT NULL,
	[tenNganHangNhan] [varchar](100) NOT NULL,
	[soTien] [money] NOT NULL,
	[noiDung] [varchar](500) NULL,
	[ngayTao] [date] NOT NULL,
	[delete] [bit] NULL,
 CONSTRAINT [PK_ThongTinGiaoDichLienNganHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinTaiKhoan]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinTaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[matk] [varchar](100) NULL,
	[email] [varchar](200) NOT NULL,
	[sdt] [varchar](11) NOT NULL,
	[image] [varchar](max) NULL,
	[sotaikhoan] [varchar](100) NOT NULL,
	[tentaikhoan] [varchar](100) NOT NULL,
	[sodu] [money] NOT NULL,
 CONSTRAINT [PK_ThongTinTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinTaiKhoanAdmin]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinTaiKhoanAdmin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[matk] [varchar](100) NOT NULL,
	[tennhanvien] [varchar](100) NOT NULL,
	[cmnd] [varchar](12) NOT NULL,
	[sdt] [varchar](11) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[diachi] [varchar](500) NOT NULL,
 CONSTRAINT [PK_TaiKhoanAdmin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinTaiKhoanTietKiem]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinTaiKhoanTietKiem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[matk] [varchar](100) NOT NULL,
	[tentaikhoantietkiem] [varchar](100) NULL,
	[ngaytao] [date] NOT NULL,
	[sotientietkiem] [money] NOT NULL,
 CONSTRAINT [PK_ThongTinTaiKhoanTietKiem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DanhBa] ON 

INSERT [dbo].[DanhBa] ([id], [matk], [sotaikhoan], [tentaikhoan], [tengoinho], [tennganhang], [idnganhanglienket]) VALUES (12, N'tk423498', N'23422423659', N'KHACH HANG 02', N'khach hang 2', N'18HCB BANK', 0)
SET IDENTITY_INSERT [dbo].[DanhBa] OFF
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoan] ON 

INSERT [dbo].[LoaiTaiKhoan] ([id], [tenloaitaikhoan]) VALUES (1, N'user')
INSERT [dbo].[LoaiTaiKhoan] ([id], [tenloaitaikhoan]) VALUES (2, N'nhanvien')
INSERT [dbo].[LoaiTaiKhoan] ([id], [tenloaitaikhoan]) VALUES (3, N'admin')
INSERT [dbo].[LoaiTaiKhoan] ([id], [tenloaitaikhoan]) VALUES (4, N'nganhanglienket')
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[NganHangLienKet] ON 

INSERT [dbo].[NganHangLienKet] ([id], [tennganhang], [secretKey], [publicKey]) VALUES (0, N'18HCB BANK', NULL, NULL)
INSERT [dbo].[NganHangLienKet] ([id], [tennganhang], [secretKey], [publicKey]) VALUES (3, N'NHOM_21_BANK', N'nhom21', N'MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCFY/7R0ap4a1Bl+Bg9g9Y6MHa7
yNVkGxdPHeFR9tICa4kQSFYQfa++hEHBGNX/7tmmmJnInEmFHUoybcXxiFRO79d5
86o2kHBZv9jMkaDcYGFdMM1re0I/aL7EwHub3MWMYJEkaoRbM6Rj9gjOom5bpcQE
VTWuNZ2FodcIGYPqZwIDAQAB')
SET IDENTITY_INSERT [dbo].[NganHangLienKet] OFF
SET IDENTITY_INSERT [dbo].[NhacNo] ON 

INSERT [dbo].[NhacNo] ([id], [matktao], [matkno], [sotienno], [noidungnhacno], [ngaytao], [noidunghuynhacno], [trangthai]) VALUES (6, N'tk423498', N'tk342491', 200000.0000, N'no tien thi lai', CAST(N'2020-05-18' AS Date), N'', 1)
INSERT [dbo].[NhacNo] ([id], [matktao], [matkno], [sotienno], [noidungnhacno], [ngaytao], [noidunghuynhacno], [trangthai]) VALUES (7, N'tk423498', N'tk342491', 100000.0000, N'no tien thi lai lan 2', CAST(N'2020-05-18' AS Date), N'Nhac no da duoc thanh toan hoac ly do khac', -1)
SET IDENTITY_INSERT [dbo].[NhacNo] OFF
INSERT [dbo].[TaiKhoan] ([tendangnhap], [matkhau], [idloaitaikhoan], [mataikhoan], [refreshToken]) VALUES (N'admin', N'$2b$12$E6R/2KRvtl27LzzHBiYMKO40mYiONpMcaNQZ9bO1nMYwTPSjjUgz.', 3, N'ad01', N'SzPllaKecIGn42PdDmeDqxfPvP7rQw/7mcScngFHSyQ=')
INSERT [dbo].[TaiKhoan] ([tendangnhap], [matkhau], [idloaitaikhoan], [mataikhoan], [refreshToken]) VALUES (N'nhom21', N'$2b$12$T9JSKufz76RgMTWDTXY.k..THenOlsqSmKD8EUbx0BWk3MEZYXVnm', 4, N'nhlk21', NULL)
INSERT [dbo].[TaiKhoan] ([tendangnhap], [matkhau], [idloaitaikhoan], [mataikhoan], [refreshToken]) VALUES (N'nhanvien1', N'$2b$12$E6R/2KRvtl27LzzHBiYMKO40mYiONpMcaNQZ9bO1nMYwTPSjjUgz.', 2, N'nv01', N'aMydv5m8ccQ6f9hn8Sb0MqQW8Xz2OfcNFimit8Ry30o=')
INSERT [dbo].[TaiKhoan] ([tendangnhap], [matkhau], [idloaitaikhoan], [mataikhoan], [refreshToken]) VALUES (N'khachhang2', N'$2b$12$NklV88nFpv3A9gcvFBFCfuVGnqvI2RX650Nd0v4/BuGKVIGu81JYm', 1, N'tk342491', N'0EILpR7R2mSLO0de+Hoe0zJUczQuVhIySS3RoTh/2uI=')
INSERT [dbo].[TaiKhoan] ([tendangnhap], [matkhau], [idloaitaikhoan], [mataikhoan], [refreshToken]) VALUES (N'khachhang1', N'$2b$12$T9JSKufz76RgMTWDTXY.k..THenOlsqSmKD8EUbx0BWk3MEZYXVnm', 1, N'tk423498', N'SI6qAdaByNUjJvQcD0SYVDP6MPvP+oYaVjd9CEW12C0=')
SET IDENTITY_INSERT [dbo].[ThongBao] ON 

INSERT [dbo].[ThongBao] ([id], [matk], [noidung], [trangthai]) VALUES (9, N'tk342491', N'Bạn có 1 nhắc nợ từ tài khoản tên : KHACH HANG 01', 1)
INSERT [dbo].[ThongBao] ([id], [matk], [noidung], [trangthai]) VALUES (10, N'tk342491', N'Bạn có 1 nhắc nợ từ tài khoản tên : KHACH HANG 01', 1)
INSERT [dbo].[ThongBao] ([id], [matk], [noidung], [trangthai]) VALUES (11, N'tk342491', N'Ban co 1 nhac no da huy tu tai khoan ten : : KHACH HANG 01', 1)
INSERT [dbo].[ThongBao] ([id], [matk], [noidung], [trangthai]) VALUES (12, N'tk423498', N'Ban co 1 thanh toan no tu tai khoan  : KHACH HANG 02', 1)
SET IDENTITY_INSERT [dbo].[ThongBao] OFF
SET IDENTITY_INSERT [dbo].[ThongTinChuyenTienNoiBo] ON 

INSERT [dbo].[ThongTinChuyenTienNoiBo] ([id], [maTk], [ngayGD], [stkGui], [stkNhan], [sotiengui], [noidung], [loaitraphi], [trangthaichuyentien]) VALUES (15, N'nv01', CAST(N'2020-04-04' AS Date), N'13133243242', N'123456789', 20000.0000, N'nhan vien chuyen tien', 0, 1)
INSERT [dbo].[ThongTinChuyenTienNoiBo] ([id], [maTk], [ngayGD], [stkGui], [stkNhan], [sotiengui], [noidung], [loaitraphi], [trangthaichuyentien]) VALUES (16, N'tk423498', CAST(N'2020-05-18' AS Date), N'44233946496', N'23422423659', 1000000.0000, N'chuyen tien cho khach hang 2', 0, 1)
INSERT [dbo].[ThongTinChuyenTienNoiBo] ([id], [maTk], [ngayGD], [stkGui], [stkNhan], [sotiengui], [noidung], [loaitraphi], [trangthaichuyentien]) VALUES (17, N'tk342491', CAST(N'2020-05-18' AS Date), N'23422423659', N'44233946496', 200000.0000, N'Thanh toan no cho tai khoan :KHACH HANG 01', 0, 1)
INSERT [dbo].[ThongTinChuyenTienNoiBo] ([id], [maTk], [ngayGD], [stkGui], [stkNhan], [sotiengui], [noidung], [loaitraphi], [trangthaichuyentien]) VALUES (18, N'nv01', CAST(N'2020-05-23' AS Date), N'44233946496', N'44233946496', 220000.0000, N'nop tien vao tai khoan', 0, 1)
INSERT [dbo].[ThongTinChuyenTienNoiBo] ([id], [maTk], [ngayGD], [stkGui], [stkNhan], [sotiengui], [noidung], [loaitraphi], [trangthaichuyentien]) VALUES (19, N'nv01', CAST(N'2020-05-23' AS Date), N'44233946496', N'44233946496', 500000.0000, N'nop tien vao tai khoan', 0, 1)
SET IDENTITY_INSERT [dbo].[ThongTinChuyenTienNoiBo] OFF
SET IDENTITY_INSERT [dbo].[ThongTinGiaoDichLienNganHang] ON 

INSERT [dbo].[ThongTinGiaoDichLienNganHang] ([id], [soTkGui], [tenNganHangGui], [soTkNhan], [tenNganHangNhan], [soTien], [noiDung], [ngayTao], [delete]) VALUES (6, N'44233946496', N'18HCB BANK', N'28143434343', N'NHOM_21_BANK', 220000.0000, N'chuyen tien khac ngan hang', CAST(N'2020-05-23' AS Date), 0)
SET IDENTITY_INSERT [dbo].[ThongTinGiaoDichLienNganHang] OFF
SET IDENTITY_INSERT [dbo].[ThongTinTaiKhoan] ON 

INSERT [dbo].[ThongTinTaiKhoan] ([id], [matk], [email], [sdt], [image], [sotaikhoan], [tentaikhoan], [sodu]) VALUES (11, N'tk423498', N'huynhtony08@gmail.com', N'3946464423', NULL, N'44233946496', N'KHACH HANG 01', 4780000.0000)
INSERT [dbo].[ThongTinTaiKhoan] ([id], [matk], [email], [sdt], [image], [sotaikhoan], [tentaikhoan], [sodu]) VALUES (12, N'tk342491', N'huynhtony08@gmail.com', N'242342342', NULL, N'23422423659', N'KHACH HANG 02', 5000000.0000)
SET IDENTITY_INSERT [dbo].[ThongTinTaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[ThongTinTaiKhoanAdmin] ON 

INSERT [dbo].[ThongTinTaiKhoanAdmin] ([id], [matk], [tennhanvien], [cmnd], [sdt], [email], [diachi]) VALUES (1, N'nv01', N'nhan vien 01', N'131232424', N'23423423423', N'nv01@gmail.com', N'xxxxxx')
INSERT [dbo].[ThongTinTaiKhoanAdmin] ([id], [matk], [tennhanvien], [cmnd], [sdt], [email], [diachi]) VALUES (2, N'ad01', N'admin 01', N'1312312312', N'3123123123', N'ad01@gmail.com', N'xxxxxx')
SET IDENTITY_INSERT [dbo].[ThongTinTaiKhoanAdmin] OFF
SET IDENTITY_INSERT [dbo].[ThongTinTaiKhoanTietKiem] ON 

INSERT [dbo].[ThongTinTaiKhoanTietKiem] ([id], [matk], [tentaikhoantietkiem], [ngaytao], [sotientietkiem]) VALUES (3, N'tk423498', N'Tien thi lai lan 1', CAST(N'2020-05-18' AS Date), 500000.0000)
INSERT [dbo].[ThongTinTaiKhoanTietKiem] ([id], [matk], [tentaikhoantietkiem], [ngaytao], [sotientietkiem]) VALUES (4, N'tk423498', N'Tien thi lai lan 2', CAST(N'2020-05-18' AS Date), 500000.0000)
INSERT [dbo].[ThongTinTaiKhoanTietKiem] ([id], [matk], [tentaikhoantietkiem], [ngaytao], [sotientietkiem]) VALUES (5, N'tk423498', N'Tien thi lai lan 3', CAST(N'2020-05-18' AS Date), 500000.0000)
INSERT [dbo].[ThongTinTaiKhoanTietKiem] ([id], [matk], [tentaikhoantietkiem], [ngaytao], [sotientietkiem]) VALUES (6, N'tk342491', N'Tien thi lai 1', CAST(N'2020-05-18' AS Date), 500000.0000)
INSERT [dbo].[ThongTinTaiKhoanTietKiem] ([id], [matk], [tentaikhoantietkiem], [ngaytao], [sotientietkiem]) VALUES (7, N'tk342491', N'Tien thi lai 2', CAST(N'2020-05-18' AS Date), 500000.0000)
INSERT [dbo].[ThongTinTaiKhoanTietKiem] ([id], [matk], [tentaikhoantietkiem], [ngaytao], [sotientietkiem]) VALUES (8, N'tk342491', N'Tien thi lai 3', CAST(N'2020-05-18' AS Date), 500000.0000)
SET IDENTITY_INSERT [dbo].[ThongTinTaiKhoanTietKiem] OFF
ALTER TABLE [dbo].[DanhBa]  WITH CHECK ADD  CONSTRAINT [FK_DanhBa_NganHangLienKet] FOREIGN KEY([idnganhanglienket])
REFERENCES [dbo].[NganHangLienKet] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DanhBa] CHECK CONSTRAINT [FK_DanhBa_NganHangLienKet]
GO
ALTER TABLE [dbo].[DanhBa]  WITH CHECK ADD  CONSTRAINT [FK_DanhBa_TaiKhoan] FOREIGN KEY([matk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DanhBa] CHECK CONSTRAINT [FK_DanhBa_TaiKhoan]
GO
ALTER TABLE [dbo].[NhacNo]  WITH CHECK ADD  CONSTRAINT [FK_NhacNo_TaiKhoan] FOREIGN KEY([matktao])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NhacNo] CHECK CONSTRAINT [FK_NhacNo_TaiKhoan]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_LoaiTaiKhoan] FOREIGN KEY([idloaitaikhoan])
REFERENCES [dbo].[LoaiTaiKhoan] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_LoaiTaiKhoan]
GO
ALTER TABLE [dbo].[ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao_TaiKhoan] FOREIGN KEY([matk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongBao] CHECK CONSTRAINT [FK_ThongBao_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongTinChuyenTienNoiBo]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinChuyenTienNoiBo_TaiKhoan] FOREIGN KEY([maTk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinChuyenTienNoiBo] CHECK CONSTRAINT [FK_ThongTinChuyenTienNoiBo_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongTinTaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinTaiKhoan_TaiKhoan] FOREIGN KEY([matk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinTaiKhoan] CHECK CONSTRAINT [FK_ThongTinTaiKhoan_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongTinTaiKhoanAdmin]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoanAdmin_TaiKhoan] FOREIGN KEY([matk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinTaiKhoanAdmin] CHECK CONSTRAINT [FK_TaiKhoanAdmin_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongTinTaiKhoanTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinTaiKhoanTietKiem_TaiKhoan] FOREIGN KEY([matk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThongTinTaiKhoanTietKiem] CHECK CONSTRAINT [FK_ThongTinTaiKhoanTietKiem_TaiKhoan]
GO
/****** Object:  StoredProcedure [dbo].[ChuyenKhoanNoiBo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ChuyenKhoanNoiBo] (
	@matk varchar(100),
	@ngayGD varchar(100),
	@stkGui varchar(100),
	@stkNhan varchar(100),
	@sotiengui int,
	@noidung varchar(500),
	@loaitraphi bit
) 
AS BEGIN 
	IF (@sotiengui > 10000) 
	BEGIN
		 IF EXISTS (SELECT 1 FROM TaiKhoan tk, ThongTinTaiKhoan tttk WHERE tk.mataikhoan = @matk or tttk.sotaikhoan = @stkGui)
		 BEGIN 
			INSERT INTO ThongTinChuyenTienNoiBo (maTk, ngayGD, stkGui, stkNhan, sotiengui, noidung, loaitraphi, trangthaichuyentien)
			VALUES (@matk, @ngayGD, @stkGui, @stkNhan, @sotiengui, @noidung, @loaitraphi, 1)
			RETURN 1
		 END
	END
END 
GO
/****** Object:  StoredProcedure [dbo].[DeleteThongTinGiaoDichKhacNganHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteThongTinGiaoDichKhacNganHang](@id int)
AS BEGIN
	 UPDATE ThongTinGiaoDichLienNganHang
	 SET [delete] = 1
	 WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DoiMatKhau]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DoiMatKhau](
	@matk varchar(100),
	@matkhaumoi varchar(max)
) 
AS BEGIN 
	UPDATE TaiKhoan 
	SET matkhau = @matkhaumoi
	WHERE mataikhoan = @matk
END
GO
/****** Object:  StoredProcedure [dbo].[DongTaiKhoanThanhToan]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DongTaiKhoanThanhToan] (@matk varchar(100))
AS BEGIN
	IF EXISTS (SELECT 1 FROM TaiKhoan WHERE @matk = mataikhoan and idloaitaikhoan = 1 )
	BEGIN
		DELETE TaiKhoan
		WHERE @matk = mataikhoan 
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUser]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetAllUser]
AS BEGIN
	SELECT id, matk, email, sdt, sotaikhoan, tentaikhoan, sodu
	FROM ThongTinTaiKhoan 
END
GO
/****** Object:  StoredProcedure [dbo].[GetDanhSachGiaoDich]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDanhSachGiaoDich]
AS BEGIN
	SELECT id, maTk, ngayGD, stkGui, stkNhan, sotiengui, noidung, loaitraphi, trangthaichuyentien
	FROM ThongTinChuyenTienNoiBo 
	ORDER BY ngayGD DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetDanhSachTaiKhoanAdmin]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDanhSachTaiKhoanAdmin]
AS BEGIN 
	SELECT tttk.id, tttk.matk, tttk.tennhanvien, tttk.cmnd, tttk.sdt, tttk.email, tttk.diachi, tk.idloaitaikhoan
	FROM ThongTinTaiKhoanAdmin tttk, TaiKhoan tk
	WHERE tttk.matk = tk.mataikhoan
END
GO
/****** Object:  StoredProcedure [dbo].[GetDSDanhBa]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDSDanhBa] (@matk varchar(100)) 
AS BEGIN
	 SELECT id, matk, tengoinho, tennganhang, sotaikhoan, tentaikhoan, idnganhanglienket
	 FROM DanhBa
	 WHERE matk = @matk
END
GO
/****** Object:  StoredProcedure [dbo].[GetDSGiaoDichKhacNganHangAll]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDSGiaoDichKhacNganHangAll]
AS BEGIN
	SELECT id, soTkGui, tenNganHangGui, soTkNhan, tenNganHangNhan, soTien, noiDung, ngayTao
	FROM ThongTinGiaoDichLienNganHang
	WHERE [delete] = 0
	ORDER BY ngayTao desc 
END
GO
/****** Object:  StoredProcedure [dbo].[GetDSNganHangLienKet]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDSNganHangLienKet] 
AS BEGIN 
	SELECT id, tennganhang
	FROM NganHangLienKet
END
GO
/****** Object:  StoredProcedure [dbo].[GetDSNguoiNo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDSNguoiNo] (@matk varchar(100)) 
AS BEGIN 
	SELECT nc.id, 
		   nc.matktao, 
		   nc.matkno, 
		   nc.sotienno, 
		   nc.noidungnhacno, 
		   nc.ngaytao, 
		   nc.noidunghuynhacno, 
		   nc.trangthai,
		   tk.tentaikhoan, 
		   tk.sotaikhoan,
		   tk.email
	FROM NhacNo nc, ThongTinTaiKhoan tk
	WHERE nc.matktao = @matk AND matkno = tk.matk
	ORDER BY ngaytao DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetDSNo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDSNo] (@matk varchar(100)) 
AS BEGIN 
	SELECT nc.id, 
		   nc.matktao, 
		   nc.matkno, 
		   nc.sotienno, 
		   nc.noidungnhacno, 
		   nc.ngaytao, 
		   nc.noidunghuynhacno, 
		   nc.trangthai,
		   tk.tentaikhoan, 
		   tk.sotaikhoan,
		   tk.email
	FROM NhacNo nc, ThongTinTaiKhoan tk
	WHERE nc.matkno = @matk AND matktao = tk.matk
	ORDER BY ngaytao DESC
END
GO
/****** Object:  StoredProcedure [dbo].[GetDsTaiKhoanTietKiem]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDsTaiKhoanTietKiem] (@matk varchar(100))
AS BEGIN 
	SELECT id, matk, tentaikhoantietkiem, ngaytao, sotientietkiem
	FROM ThongTinTaiKhoanTietKiem
	WHERE matk = @matk
END
GO
/****** Object:  StoredProcedure [dbo].[GetDSThongBao]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetDSThongBao] (@matk varchar(100))  
AS BEGIN 
	SELECT id, matk, noidung,trangthai
	FROM ThongBao
	WHERE matk = @matk
	ORDER BY id desc
END
GO
/****** Object:  StoredProcedure [dbo].[GetNganHangLienKetByIdOrTenNganHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetNganHangLienKetByIdOrTenNganHang] (
	@id int,
	@tennganhang varchar(100)
)
AS BEGIN
	IF (@id != -1) 
	BEGIN 
		SELECT id, tennganhang, secretKey, publicKey
		FROM NganHangLienKet
		WHERE id = @id
	END
	IF ( @id = -1)
	BEGIN
		SELECT id, tennganhang, secretKey, publicKey
		FROM NganHangLienKet
		WHERE tennganhang = @tennganhang
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetPasswordByMaTk]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[GetPasswordByMaTk] (@matk varchar(100))
AS BEGIN 
	SELECT matkhau
	FROM TaiKhoan
	WHERE mataikhoan = @matk
END
GO
/****** Object:  StoredProcedure [dbo].[GetRefreshTokenByMatk]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetRefreshTokenByMatk] (@matk varchar(100))
AS BEGIN 
	SELECT refreshToken
	From TaiKhoan
	WHERE mataikhoan = @matk
END
GO
/****** Object:  StoredProcedure [dbo].[GetThongTinTaiKhoan]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetThongTinTaiKhoan](@matk varchar(100))
AS BEGIN 
	SELECT id, matk, email, sdt, [image], sotaikhoan, tentaikhoan, sodu
	FROM ThongTinTaiKhoan
	WHERE matk = @matk
END


GO
/****** Object:  StoredProcedure [dbo].[GetThongTinTaiKhoanAdmin]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetThongTinTaiKhoanAdmin] (@matk varchar(100))
AS BEGIN 
	SELECT id, tk.idloaitaikhoan, matk, tennhanvien as tentaikhoan,cmnd, email, sdt, tk.refreshToken
	FROM ThongTinTaiKhoanAdmin tttk , TaiKhoan tk
	WHERE tttk.matk = @matk and tk.mataikhoan = @matk
END
GO
/****** Object:  StoredProcedure [dbo].[GetThongTinTaiKhoanBySTK]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetThongTinTaiKhoanBySTK] (@sotaikhoan varchar(100))
AS BEGIN
	SELECT id, matk, email, sdt, sotaikhoan, tentaikhoan
	FROM ThongTinTaiKhoan  
	WHERE sotaikhoan = @sotaikhoan
END
GO
/****** Object:  StoredProcedure [dbo].[GetThongTinTaiKhoanKhachHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetThongTinTaiKhoanKhachHang] (@matk varchar(100))
AS BEGIN 
	SELECT tk.idloaitaikhoan, tttk.id, tttk.matk, tttk.email, tttk.sdt, tttk.image, tttk.sotaikhoan, tttk.tentaikhoan, tttk.sodu, tk.refreshToken
	FROM ThongTinTaiKhoan tttk , TaiKhoan tk
	WHERE tttk.matk =@matk and tk.mataikhoan = @matk 
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByTenDangNhap]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetUserByTenDangNhap] (
@tendangnhap varchar(100)
) 
AS BEGIN 
	SELECT tk.idloaitaikhoan, tk.mataikhoan as matk, tk.matkhau
	FROM TaiKhoan tk
	WHERE tk.tendangnhap = @tendangnhap
END
GO
/****** Object:  StoredProcedure [dbo].[QuenMatKhauUser]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[QuenMatKhauUser] (
	@tendangnhap varchar(100), 
	@email varchar(200),
	@matkhaumoi varchar(500)
)
AS BEGIN 
	IF EXISTS (SELECT 1 
			   FROM TaiKhoan tk, ThongTinTaiKhoan tttk 
			   WHERE tk.tendangnhap = @tendangnhap AND tk.mataikhoan = tttk.matk and tttk.email = @email
			   ) 
	BEGIN 
		UPDATE TaiKhoan
		SET matkhau = @matkhaumoi
		WHERE tendangnhap =@tendangnhap
		RETURN 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[SuaDanhBa]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SuaDanhBa] (
	@id int,
	@matk varchar(100),
	@tengoinho varchar(100),
	@tennganhang varchar(100),
	@sotaikhoan varchar(100)
)
AS BEGIN 
	UPDATE DanhBa
	SET tengoinho = @tengoinho, tennganhang = @tennganhang, sotaikhoan = @sotaikhoan
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ThemDanhBa]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemDanhBa] (
	@matk varchar(100),
	@tengoinho varchar(100),
	@tennganhang varchar(100),
	@sotaikhoan varchar(100),
	@tentaikhoan varchar(100),
	@idnganhanglienket int
)
AS BEGIN 
	IF NOT EXISTS (SELECT 1 FROM DanhBa WHERE matk = @matk and sotaikhoan = @sotaikhoan)
	BEGIN 
		INSERT INTO DanhBa (matk, sotaikhoan, tengoinho, tennganhang, tentaikhoan , idnganhanglienket)
		VALUES (@matk,@sotaikhoan,  @tengoinho, @tennganhang, @tentaikhoan,  @idnganhanglienket)
		return 1
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ThemNganHangLienKet]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROC [dbo].[ThemNganHangLienKet] (
	@tennganhang varchar(100),
	@secretkey varchar(100),
	@publickey varchar(100)
)
AS BEGIN 
	IF NOT EXISTS (SELECT 1 FROM NganHangLienKet WHERE tennganhang = @tennganhang)
	BEGIN
		INSERT INTO NganHangLienKet (tennganhang, secretKey, publicKey)
		VALUES (@tennganhang, @secretkey, @publickey)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ThemNhacNo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemNhacNo](
	@matktao varchar(100),
	@matkno varchar(100),
	@sotienno int,
	@noidungnhacno varchar(200),
	@ngaytao varchar(100),
	@noidunghuynhacno varchar(200),
	@trangthai int
) AS BEGIN 
	INSERT INTO NhacNo (matktao, matkno, sotienno, noidungnhacno, ngaytao, noidunghuynhacno, trangthai)
	VALUES (@matktao, @matkno, @sotienno, @noidungnhacno, @ngaytao, @noidunghuynhacno, @trangthai)
END
GO
/****** Object:  StoredProcedure [dbo].[ThemTaiKhoanDangNhap]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemTaiKhoanDangNhap] (
	@tendangnhap varchar(100),
	@matkhau varchar(100),
	@idloaitaikhoan int,
	@mataikhoan varchar(100),
	@refreshToken varchar(max)
) AS BEGIN 
	IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE tendangnhap = @tendangnhap and mataikhoan = @mataikhoan)
	BEGIN 
		INSERT INTO TaiKhoan (tendangnhap, matkhau, idloaitaikhoan, mataikhoan, refreshToken)
		VALUES (@tendangnhap, @matkhau, @idloaitaikhoan, @mataikhoan, @refreshToken)
	END
END
GO
/****** Object:  StoredProcedure [dbo].[ThemTaiKhoanNhanVien]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemTaiKhoanNhanVien] (
	@matk varchar(100),
	@tennhanvien varchar(100), 
	@cmnd varchar(100),
	@sdt varchar(12),
	@email varchar(100),
	@diachi varchar(200)
)
AS BEGIN 
	INSERT INTO ThongTinTaiKhoanAdmin (matk, tennhanvien, cmnd, sdt, email, diachi)
	VALUES (@matk, @tennhanvien, @cmnd, @sdt, @email, @diachi)
END
GO
/****** Object:  StoredProcedure [dbo].[ThemThongBao]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemThongBao] (@matk varchar(100), @noidung nvarchar(max))
AS BEGIN
	INSERT INTO ThongBao (matk, noidung, trangthai)
	VALUES (@matk, @noidung, 0); 
END
GO
/****** Object:  StoredProcedure [dbo].[ThemThongTinGiaoDichKhacNganHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemThongTinGiaoDichKhacNganHang](
	@soTKGui varchar(100),
	@tenNganHangGui varchar(100),
	@soTkNhan varchar(100),
	@tenNganHangNhan varchar(100),
	@soTien int,
	@noiDung varchar(100),
	@ngayTao varchar(100)
) 
AS BEGIN 
	INSERT INTO ThongTinGiaoDichLienNganHang (soTkGui,tenNganHangGui, soTkNhan, tenNganHangNhan, soTien, noiDung, ngayTao, [delete])
	VALUES (@soTKGui,@tenNganHangGui, @soTkNhan, @tenNganHangNhan, @soTien, @noiDung, @ngayTao, 0)
END
GO
/****** Object:  StoredProcedure [dbo].[ThemThongTinTaiKhoanKhachHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[ThemThongTinTaiKhoanKhachHang] (
	@mataikhoan varchar(100),
	@email varchar(100),
	@sdt varchar(12),
	@sotaikhoan varchar(20),
	@tentaikhoan varchar(100),
	@sodu int
) AS BEGIN 
	IF NOT EXISTS (SELECT 1 FROM ThongTinTaiKhoan WHERE sotaikhoan = @sotaikhoan)
	BEGIN
		 INSERT INTO ThongTinTaiKhoan (matk, email, sdt, sotaikhoan, tentaikhoan, sodu)
		 VALUES (@mataikhoan, @email, @sdt, @sotaikhoan, @tentaikhoan, @sodu);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[TimKiemGiaoDich]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TimKiemGiaoDich] (@key varchar(100))
AS BEGIN
	SELECT id, maTk, ngayGD, stkGui, stkNhan, sotiengui, noidung, loaitraphi, trangthaichuyentien
	FROM ThongTinChuyenTienNoiBo 
	WHERE stkGui = @key OR stkNhan = @key
	ORDER BY ngayGD DESC
END
GO
/****** Object:  StoredProcedure [dbo].[TimKiemGiaoDichKhacNganHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TimKiemGiaoDichKhacNganHang](@sotaikhoan varchar(100), @tennganhang varchar(100))
AS BEGIN
	SELECT id, soTkGui, tenNganHangGui, soTkNhan, tenNganHangNhan, soTien, noiDung, ngayTao
	FROM ThongTinGiaoDichLienNganHang
	WHERE (soTkGui = @sotaikhoan or soTkNhan = @sotaikhoan or tenNganHangGui = @tennganhang or tenNganHangNhan = @tennganhang) AND [delete] = 0
	ORDER BY ngayTao desc   
END
GO
/****** Object:  StoredProcedure [dbo].[TimKiemThongTinTaiKhoan]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[TimKiemThongTinTaiKhoan] (@key varchar(100)) 
AS BEGIN 
	SELECT id, matk, email, sdt, sotaikhoan, tentaikhoan, sodu
	FROM ThongTinTaiKhoan 
	WHERE tentaikhoan = @key OR sotaikhoan = @key OR sdt = @key
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateRefreshToken]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateRefreshToken](@matk varchar(100), @refreshToken varchar(max))
AS BEGIN 
	UPDATE TaiKhoan 
	SET refreshToken = @refreshToken
	WHERE mataikhoan = @matk
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSoDuGiaoDichKhacNganHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateSoDuGiaoDichKhacNganHang] (
	@sotaikhoan varchar(100),
	@sotien int,
	@loaigiaodich bit
)
AS BEGIN
	IF EXISTS (SELECT 1 FROM ThongTinTaiKhoan WHERE sotaikhoan = @sotaikhoan)
	BEGIN 
		-- CHUYEN TIEN
		IF(@loaigiaodich = 0) 
		BEGIN 
			UPDATE ThongTinTaiKhoan 
			SET sodu = sodu - @sotien
			WHERE sotaikhoan = @sotaikhoan
		END

		-- NHAN TIEN
		IF(@loaigiaodich = 1) 
		BEGIN 
			UPDATE ThongTinTaiKhoan 
			SET sodu = sodu + @sotien
			WHERE sotaikhoan = @sotaikhoan
		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSoDuSauKhiChuyenKhoanNoiBo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateSoDuSauKhiChuyenKhoanNoiBo] (
	@taikhoangui varchar(100),
	@taikhoannhan varchar(100),
	@sotiengui int
) 
AS BEGIN 
	IF EXISTS (SELECT 1 FROM ThongTinTaiKhoan WHERE sotaikhoan = @taikhoangui) 
	BEGIN
			IF EXISTS (SELECT 1 FROM ThongTinTaiKhoan WHERE sotaikhoan =@taikhoannhan) 
			BEGIN
				UPDATE ThongTinTaiKhoan 
				SET sodu = sodu  - @sotiengui 
				WHERE sotaikhoan = @taikhoangui

				UPDATE ThongTinTaiKhoan 
				SET sodu = sodu  + @sotiengui 
				WHERE sotaikhoan = @taikhoannhan
			END 
	END
	
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateThongBao]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateThongBao] (@id int )
AS BEGIN
	UPDATE ThongBao 
	SET trangthai = 1
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateThongTinTaiKhoanKhachHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateThongTinTaiKhoanKhachHang] (
	@id int,
	@email varchar(100),
	@sdt varchar(12)
) AS BEGIN
	 UPDATE ThongTinTaiKhoan
	 SET email = @email, sdt = @sdt
	 WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateThongTinTaiKhoanNhanVien]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateThongTinTaiKhoanNhanVien] (
	@id int,
	@tennv varchar(100),
	@email varchar(100),
	@sdt varchar(12),
	@cmnd varchar(20)
) AS BEGIN
	UPDATE ThongTinTaiKhoanAdmin
	SET tennhanvien = @tennv, email = @email, sdt = @sdt, cmnd = @cmnd
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTrangThaiNhacNo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateTrangThaiNhacNo] (@id int, @matk varchar(100), @trangthai int, @noidunghuynhacno varchar(500))
AS BEGIN 
	IF EXISTS (SELECT 1 FROM ThongTinTaiKhoan WHERE matk = @matk) 
	BEGIN
		UPDATE NhacNo  
		SET trangthai =  @trangthai, noidunghuynhacno = @noidunghuynhacno
		WHERE id = @id
	END
END
GO
/****** Object:  StoredProcedure [dbo].[XemGiaoDichGuiTienNoiBo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XemGiaoDichGuiTienNoiBo](@stk varchar(100))
AS BEGIN 
	SELECT id, maTk, ngayGD, stkGui, stkNhan, sotiengui, noidung, loaitraphi, trangthaichuyentien
	FROM ThongTinChuyenTienNoiBo
	WHERE stkGui = @stk
	ORDER BY ngayGD DESC 
END
GO
/****** Object:  StoredProcedure [dbo].[XemGiaoDichKhacNganHang]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XemGiaoDichKhacNganHang](
	@sotaikhoan varchar(100)
)
AS BEGIN 
	SELECT id, soTkGui, tenNganHangGui, soTkNhan, tenNganHangNhan, soTien, noiDung, ngayTao
	FROM ThongTinGiaoDichLienNganHang
	WHERE (soTkGui = @sotaikhoan OR soTkNhan = @sotaikhoan ) and [delete] = 0
	ORDER BY ngayTao DESC
END
GO
/****** Object:  StoredProcedure [dbo].[XemGiaoDichNhanTienNoiBo]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XemGiaoDichNhanTienNoiBo](@sotaikhoan varchar(100))
AS BEGIN 
	SELECT id, maTk, ngayGD, stkGui, stkNhan, sotiengui, noidung, loaitraphi, trangthaichuyentien
	FROM ThongTinChuyenTienNoiBo
	WHERE stkNhan = @sotaikhoan
	ORDER BY ngayGD DESC 
END
GO
/****** Object:  StoredProcedure [dbo].[XoaDanhBa]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XoaDanhBa] (@id int )
AS BEGIN 
	DELETE DanhBa Where id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[XoaGiaoDich]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XoaGiaoDich] (@id int)
AS BEGIN 
	DELETE ThongTinChuyenTienNoiBo
	WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[XoaTaiKhoan]    Script Date: 5/26/2020 10:44:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[XoaTaiKhoan] (@matk varchar(100))
AS BEGIN
	DELETE TaiKhoan
	WHERE mataikhoan = @matk AND idloaitaikhoan != 3
END
GO
USE [master]
GO
ALTER DATABASE [Bank_LTHD] SET  READ_WRITE 
GO
