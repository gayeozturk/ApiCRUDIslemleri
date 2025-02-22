USE [DBEFCRUD]
GO
/****** Object:  Table [dbo].[Iller]    Script Date: 8.03.2024 09:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iller](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sehir] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Iller] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 8.03.2024 09:46:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](max) NOT NULL,
	[Soyad] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Sifre] [nvarchar](max) NOT NULL,
	[IlId] [int] NOT NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Iller] ON 

INSERT [dbo].[Iller] ([Id], [Sehir]) VALUES (1, N'Ankara')
INSERT [dbo].[Iller] ([Id], [Sehir]) VALUES (2, N'İzmir')
INSERT [dbo].[Iller] ([Id], [Sehir]) VALUES (3, N'Bolu')
INSERT [dbo].[Iller] ([Id], [Sehir]) VALUES (4, N'Düzce')
INSERT [dbo].[Iller] ([Id], [Sehir]) VALUES (5, N'Sakarya')
INSERT [dbo].[Iller] ([Id], [Sehir]) VALUES (6, N'Adana')
SET IDENTITY_INSERT [dbo].[Iller] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([Id], [Ad], [Soyad], [Email], [Sifre], [IlId]) VALUES (4, N'serkan', N'can', N'a@a.com', N'123', 1)
INSERT [dbo].[Kullanici] ([Id], [Ad], [Soyad], [Email], [Sifre], [IlId]) VALUES (5, N'Mehmet', N'sss', N'fff', N'sss', 2)
INSERT [dbo].[Kullanici] ([Id], [Ad], [Soyad], [Email], [Sifre], [IlId]) VALUES (6, N'Hüsrev', N'YILDIZ', N'ba@a.com', N'wwwww', 6)
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Iller] FOREIGN KEY([IlId])
REFERENCES [dbo].[Iller] ([Id])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_Iller]
GO
