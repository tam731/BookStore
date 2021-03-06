USE [QLSach]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[SoHD] [nchar](10) NOT NULL,
	[MaSach] [nchar](10) NOT NULL,
	[SLMua] [int] NULL,
	[DonGia] [int] NULL,
	[GiamGia] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[SoHD] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[SoPN] [nchar](10) NOT NULL,
	[MaSach] [nchar](10) NOT NULL,
	[SoLuongN] [int] NULL,
	[DongiaN] [float] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[SoPN] ASC,
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[SoHD] [nchar](10) NOT NULL,
	[MaKH] [nchar](10) NOT NULL,
	[TenDN] [nchar](50) NOT NULL,
	[NgayLap] [date] NULL,
	[HinhThucTT] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[SoHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khachhang]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khachhang](
	[MaKH] [nchar](10) NOT NULL,
	[TenKH] [nvarchar](50) NOT NULL,
	[GioiTinh] [nchar](10) NULL,
	[SDT] [nchar](15) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[Email] [nchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSach]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSach](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](max) NOT NULL,
	[SDT] [nchar](15) NULL,
	[Diachi] [nvarchar](max) NULL,
	[Email] [nchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[TenDN] [nchar](50) NOT NULL,
	[MatKhau] [nchar](20) NOT NULL,
	[TenNV] [nvarchar](100) NOT NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SoDienThoai] [nchar](15) NULL,
	[Email] [nchar](50) NULL,
 CONSTRAINT [PK__NhanVien__4CF965592DF36ADC] PRIMARY KEY CLUSTERED 
(
	[TenDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NXB]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NXB](
	[MaNXB] [int] IDENTITY(1,1) NOT NULL,
	[TenNXB] [nvarchar](max) NOT NULL,
	[SDT] [nchar](15) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[email] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[SoPN] [nchar](10) NOT NULL,
	[NhanVienNhap] [nvarchar](100) NOT NULL,
	[MaNCC] [int] NULL,
	[NgayNhap] [date] NULL,
 CONSTRAINT [PK__PhieuNha__BC3C6A7352AA5687] PRIMARY KEY CLUSTERED 
(
	[SoPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nchar](10) NOT NULL,
	[TenSach] [nvarchar](max) NOT NULL,
	[MaLoai] [int] NOT NULL,
	[MaTG] [int] NOT NULL,
	[MaNXB] [int] NOT NULL,
	[DonViTinh] [nvarchar](20) NULL,
	[Soluong] [int] NULL,
	[DonGia] [int] NULL,
 CONSTRAINT [PK__Sach__B235742D72CDF0A3] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 1/6/2021 3:58:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[MaTG] [int] IDENTITY(1,1) NOT NULL,
	[TenTG] [nvarchar](50) NOT NULL,
	[SDT] [nchar](15) NULL,
	[Email] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaSach], [SLMua], [DonGia], [GiamGia]) VALUES (N'HD01      ', N'MS01      ', 1, 15000, 0)
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaSach], [SLMua], [DonGia], [GiamGia]) VALUES (N'HD03      ', N'MS01      ', 1, 15000, 5)
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaSach], [SLMua], [DonGia], [GiamGia]) VALUES (N'HD03      ', N'MS02      ', 1, 15000, 5)
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaSach], [SLMua], [DonGia], [GiamGia]) VALUES (N'HD04      ', N'MS01      ', 1, 15000, 5)
INSERT [dbo].[ChiTietHoaDon] ([SoHD], [MaSach], [SLMua], [DonGia], [GiamGia]) VALUES (N'HD04      ', N'MS02      ', 1, 15000, 5)
GO
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaSach], [SoLuongN], [DongiaN]) VALUES (N'pn02      ', N'ms01      ', 1, 1)
INSERT [dbo].[ChiTietPhieuNhap] ([SoPN], [MaSach], [SoLuongN], [DongiaN]) VALUES (N'pn03      ', N'ms02      ', 1, 1)
GO
INSERT [dbo].[HoaDon] ([SoHD], [MaKH], [TenDN], [NgayLap], [HinhThucTT]) VALUES (N'HD01      ', N'KH002     ', N'Admin                                             ', CAST(N'2021-01-06' AS Date), N'Tiền mặt')
INSERT [dbo].[HoaDon] ([SoHD], [MaKH], [TenDN], [NgayLap], [HinhThucTT]) VALUES (N'HD03      ', N'KH001     ', N'Admin                                             ', CAST(N'2021-01-06' AS Date), N'Tiền mặt')
INSERT [dbo].[HoaDon] ([SoHD], [MaKH], [TenDN], [NgayLap], [HinhThucTT]) VALUES (N'HD04      ', N'KH001     ', N'Admin                                             ', CAST(N'2021-01-06' AS Date), N'Tiền mặt')
GO
INSERT [dbo].[Khachhang] ([MaKH], [TenKH], [GioiTinh], [SDT], [DiaChi], [Email]) VALUES (N'KH001     ', N'Lê Văn Thành', N'Nam       ', N'32324232       ', N'Bắc Ninh1', NULL)
INSERT [dbo].[Khachhang] ([MaKH], [TenKH], [GioiTinh], [SDT], [DiaChi], [Email]) VALUES (N'KH002     ', N'Lê Văn An', N'Nam       ', N'32322336       ', N'Bắc Ninh', NULL)
INSERT [dbo].[Khachhang] ([MaKH], [TenKH], [GioiTinh], [SDT], [DiaChi], [Email]) VALUES (N'KH003     ', N'Ngô Thị Quỳnh', N'Nữ        ', N'323243422      ', N'Bắc Ninh', NULL)
INSERT [dbo].[Khachhang] ([MaKH], [TenKH], [GioiTinh], [SDT], [DiaChi], [Email]) VALUES (N'KH004     ', N'e123123', N'nam       ', N'312            ', N'32132', N'd2eqe1232                                                                                           ')
GO
SET IDENTITY_INSERT [dbo].[LoaiSach] ON 

INSERT [dbo].[LoaiSach] ([MaLoai], [TenLoai]) VALUES (1, N'Truyện tranh')
INSERT [dbo].[LoaiSach] ([MaLoai], [TenLoai]) VALUES (2, N'Tiểu Thuyết')
INSERT [dbo].[LoaiSach] ([MaLoai], [TenLoai]) VALUES (3, N'Sách giáo khoa')
SET IDENTITY_INSERT [dbo].[LoaiSach] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [Diachi], [Email]) VALUES (1, N'Giao thông vận tải', N'011111112      ', N'Hà noi', NULL)
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [SDT], [Diachi], [Email]) VALUES (2, N'Giáo dục', N'0156543        ', N'Hà Nam', NULL)
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
INSERT [dbo].[NhanVien] ([TenDN], [MatKhau], [TenNV], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email]) VALUES (N'Admin                                             ', N'123456              ', N'Lê Văn Tâm', CAST(N'1999-01-04' AS Date), N'Nam', N'Thanh Hóa', N'19999997       ', N'tam@gmail.com                                     ')
INSERT [dbo].[NhanVien] ([TenDN], [MatKhau], [TenNV], [NgaySinh], [GioiTinh], [DiaChi], [SoDienThoai], [Email]) VALUES (N'huynq                                             ', N'123456              ', N'Ngô Quang Huy', CAST(N'2021-01-05' AS Date), N'nam', N'hà Nam', N'0167777        ', N'123@abc                                           ')
GO
SET IDENTITY_INSERT [dbo].[NXB] ON 

INSERT [dbo].[NXB] ([MaNXB], [TenNXB], [SDT], [DiaChi], [email]) VALUES (1, N'Kim đồng', N'0111111        ', N'hà nội', N'123@gmail.com                                     ')
SET IDENTITY_INSERT [dbo].[NXB] OFF
GO
INSERT [dbo].[PhieuNhap] ([SoPN], [NhanVienNhap], [MaNCC], [NgayNhap]) VALUES (N'PN002     ', N'Lê Văn Tâm', NULL, CAST(N'2020-12-26' AS Date))
INSERT [dbo].[PhieuNhap] ([SoPN], [NhanVienNhap], [MaNCC], [NgayNhap]) VALUES (N'PN01      ', N'Lê Văn Tâm', NULL, CAST(N'2020-12-26' AS Date))
INSERT [dbo].[PhieuNhap] ([SoPN], [NhanVienNhap], [MaNCC], [NgayNhap]) VALUES (N'pn02      ', N'huynq                                             ', 2, CAST(N'2021-01-06' AS Date))
INSERT [dbo].[PhieuNhap] ([SoPN], [NhanVienNhap], [MaNCC], [NgayNhap]) VALUES (N'pn03      ', N'huynq                                             ', 1, CAST(N'2021-01-06' AS Date))
GO
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [MaTG], [MaNXB], [DonViTinh], [Soluong], [DonGia]) VALUES (N'ms01      ', N'Doraemon', 1, 2, 1, N'Quyển', 10, 15000)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [MaTG], [MaNXB], [DonViTinh], [Soluong], [DonGia]) VALUES (N'ms02      ', N'HarryPorter', 2, 1, 1, N'Quyển', 10, 200000)
INSERT [dbo].[Sach] ([MaSach], [TenSach], [MaLoai], [MaTG], [MaNXB], [DonViTinh], [Soluong], [DonGia]) VALUES (N'ms03      ', N'HarryPorter 2', 2, 1, 1, N'Quyển', 5, 200000)
GO
SET IDENTITY_INSERT [dbo].[TacGia] ON 

INSERT [dbo].[TacGia] ([MaTG], [TenTG], [SDT], [Email]) VALUES (1, N'Tô hoài', N'022222222      ', N'tg1@gmail.com                                     ')
INSERT [dbo].[TacGia] ([MaTG], [TenTG], [SDT], [Email]) VALUES (2, N'Thế Lữ', N'03333333344    ', N'tg2@gmail.com                                     ')
SET IDENTITY_INSERT [dbo].[TacGia] OFF
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([SoHD])
REFERENCES [dbo].[HoaDon] ([SoHD])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_Sach]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap] FOREIGN KEY([SoPN])
REFERENCES [dbo].[PhieuNhap] ([SoPN])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_Sach]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[Khachhang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([TenDN])
REFERENCES [dbo].[NhanVien] ([TenDN])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NCC] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NCC]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_LoaiSach] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSach] ([MaLoai])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_LoaiSach]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NXB] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NXB] ([MaNXB])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NXB]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TacGia] FOREIGN KEY([MaTG])
REFERENCES [dbo].[TacGia] ([MaTG])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TacGia]
GO
