USE [master]
GO
/****** Object:  Database [Bank_LTHD]    Script Date: 2/29/2020 3:50:16 PM ******/
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
/****** Object:  Table [dbo].[DanhBa]    Script Date: 2/29/2020 3:50:16 PM ******/
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
	[tengoinho] [varchar](100) NULL,
	[tennganhang] [varchar](200) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiTaiKhoan]    Script Date: 2/29/2020 3:50:16 PM ******/
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
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 2/29/2020 3:50:16 PM ******/
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
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[mataikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoanAdmin]    Script Date: 2/29/2020 3:50:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoanAdmin](
	[tendangnhap] [varchar](100) NOT NULL,
	[matkhau] [varchar](100) NOT NULL,
	[idloaitaikhoan] [int] NOT NULL,
	[mataikhoan] [varchar](100) NOT NULL,
	[tennhanvien] [varchar](100) NOT NULL,
	[cmnd] [varchar](12) NOT NULL,
	[sdt] [varchar](11) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[diachi] [varchar](500) NOT NULL,
 CONSTRAINT [PK_TaiKhoanAdmin] PRIMARY KEY CLUSTERED 
(
	[mataikhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongBao]    Script Date: 2/29/2020 3:50:16 PM ******/
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
/****** Object:  Table [dbo].[ThongTinChuyenTienNoiBo]    Script Date: 2/29/2020 3:50:16 PM ******/
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
/****** Object:  Table [dbo].[ThongTinTaiKhoan]    Script Date: 2/29/2020 3:50:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinTaiKhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[matk] [varchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[ThongTinTaiKhoanTietKiem]    Script Date: 2/29/2020 3:50:16 PM ******/
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
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoan] ON 
INSERT [dbo].[LoaiTaiKhoan] ([id], [tenloaitaikhoan]) VALUES (1, N'user')
INSERT [dbo].[LoaiTaiKhoan] ([id], [tenloaitaikhoan]) VALUES (2, N'nhanvien')
SET IDENTITY_INSERT [dbo].[LoaiTaiKhoan] OFF
INSERT [dbo].[TaiKhoan] ([tendangnhap], [matkhau], [idloaitaikhoan], [mataikhoan]) VALUES (N'testuser01', N'$2b$12$o7puNf7ZauQP3VySUUv9TuPuJF3J.n8eKLzvjhnYDllcDq8IZkvUy', 1, N'a74605e1-b84b-4354-bd9d-f52823779cb0')
SET IDENTITY_INSERT [dbo].[ThongTinTaiKhoan] ON 
INSERT [dbo].[ThongTinTaiKhoan] ([id], [matk], [email], [sdt], [image], [sotaikhoan], [tentaikhoan], [sodu]) VALUES (1, N'a74605e1-b84b-4354-bd9d-f52823779cb0', N'a@a.com', N'123456789', NULL, N'5645231', N'343643', 100000.0000)
SET IDENTITY_INSERT [dbo].[ThongTinTaiKhoan] OFF

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DanhBa]  WITH CHECK ADD  CONSTRAINT [FK_DanhBa_TaiKhoan] FOREIGN KEY([matk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
GO
ALTER TABLE [dbo].[DanhBa] CHECK CONSTRAINT [FK_DanhBa_TaiKhoan]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_LoaiTaiKhoan] FOREIGN KEY([idloaitaikhoan])
REFERENCES [dbo].[LoaiTaiKhoan] ([id])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_LoaiTaiKhoan]
GO
ALTER TABLE [dbo].[TaiKhoanAdmin]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoanAdmin_LoaiTaiKhoan] FOREIGN KEY([idloaitaikhoan])
REFERENCES [dbo].[LoaiTaiKhoan] ([id])
GO
ALTER TABLE [dbo].[TaiKhoanAdmin] CHECK CONSTRAINT [FK_TaiKhoanAdmin_LoaiTaiKhoan]
GO
ALTER TABLE [dbo].[ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao_TaiKhoan] FOREIGN KEY([matk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
GO
ALTER TABLE [dbo].[ThongBao] CHECK CONSTRAINT [FK_ThongBao_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongTinChuyenTienNoiBo]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinChuyenTienNoiBo_TaiKhoan] FOREIGN KEY([maTk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
GO
ALTER TABLE [dbo].[ThongTinChuyenTienNoiBo] CHECK CONSTRAINT [FK_ThongTinChuyenTienNoiBo_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongTinTaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinTaiKhoan_TaiKhoan] FOREIGN KEY([matk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
GO
ALTER TABLE [dbo].[ThongTinTaiKhoan] CHECK CONSTRAINT [FK_ThongTinTaiKhoan_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongTinTaiKhoanTietKiem]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinTaiKhoanTietKiem_TaiKhoan] FOREIGN KEY([matk])
REFERENCES [dbo].[TaiKhoan] ([mataikhoan])
GO
ALTER TABLE [dbo].[ThongTinTaiKhoanTietKiem] CHECK CONSTRAINT [FK_ThongTinTaiKhoanTietKiem_TaiKhoan]
GO
/****** Object:  StoredProcedure [dbo].[GetUserByTenDangNhap]    Script Date: 3/4/2020 9:36:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetUserByTenDangNhap] (
@tendangnhap varchar(100)
) 
AS BEGIN 
	SELECT tk.idloaitaikhoan, tttk.id, tttk.matk, tk.matkhau, tttk.email, tttk.sdt, tttk.image, tttk.sotaikhoan, tttk.tentaikhoan, tttk.sodu
	FROM TaiKhoan tk, ThongTinTaiKhoan tttk 
	WHERE tk.tendangnhap = @tendangnhap AND tk.mataikhoan = tttk.matk
END
GO
USE [master]
GO
ALTER DATABASE [Bank_LTHD] SET  READ_WRITE 
GO

