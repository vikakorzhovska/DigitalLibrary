USE [DigitalLibraryDb]
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_Reviews_Users_UserId]
GO
ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_Reviews_Books_BookId]
GO
ALTER TABLE [dbo].[BorrowRecords] DROP CONSTRAINT [FK_BorrowRecords_Users_UserId]
GO
ALTER TABLE [dbo].[BorrowRecords] DROP CONSTRAINT [FK_BorrowRecords_Books_BookId]
GO
ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_Books_Genres_GenreId]
GO
ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_Books_Authors_AuthorId]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.05.2025 18:42:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 25.05.2025 18:42:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reviews]') AND type in (N'U'))
DROP TABLE [dbo].[Reviews]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 25.05.2025 18:42:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genres]') AND type in (N'U'))
DROP TABLE [dbo].[Genres]
GO
/****** Object:  Table [dbo].[BorrowRecords]    Script Date: 25.05.2025 18:42:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BorrowRecords]') AND type in (N'U'))
DROP TABLE [dbo].[BorrowRecords]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 25.05.2025 18:42:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Books]') AND type in (N'U'))
DROP TABLE [dbo].[Books]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 25.05.2025 18:42:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Authors]') AND type in (N'U'))
DROP TABLE [dbo].[Authors]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25.05.2025 18:42:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25.05.2025 18:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 25.05.2025 18:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 25.05.2025 18:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Year] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowRecords]    Script Date: 25.05.2025 18:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowRecords](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[BorrowedAt] [datetime2](7) NOT NULL,
	[ReturnedAt] [datetime2](7) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_BorrowRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 25.05.2025 18:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 25.05.2025 18:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Rating] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[BookId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.05.2025 18:42:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PasswordHash] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[Role] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250522160844_InitialCreate', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250523135354_AddRoleToUser', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250525124527_AddReviewsTable', N'8.0.11')
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [FullName], [CreatedAt]) VALUES (1, N'Джоан Роулінг', CAST(N'2025-05-23T11:56:00.0000000' AS DateTime2))
INSERT [dbo].[Authors] ([Id], [FullName], [CreatedAt]) VALUES (2, N'Дженніфер Арментраут', CAST(N'2025-05-23T11:57:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Title], [Description], [Year], [AuthorId], [GenreId], [CreatedAt]) VALUES (1, N'Гаррі Поттер і Філософський камінь', N'Що трапиться на шляху у Гаррі? Які пригоди його чекають?', 1997, 1, 1, CAST(N'2025-05-25T13:41:42.7508675' AS DateTime2))
INSERT [dbo].[Books] ([Id], [Title], [Description], [Year], [AuthorId], [GenreId], [CreatedAt]) VALUES (2, N'Гаррі Поттер і Таємна кімната ', N'Де знаходиться таємна кімната', 1998, 1, 1, CAST(N'2025-05-25T10:15:35.9186083' AS DateTime2))
INSERT [dbo].[Books] ([Id], [Title], [Description], [Year], [AuthorId], [GenreId], [CreatedAt]) VALUES (3, N'Із крові й попелу', N'Перша книга із серії "Крові і попіл"', 2020, 2, 3, CAST(N'2025-05-25T10:17:26.0934023' AS DateTime2))
INSERT [dbo].[Books] ([Id], [Title], [Description], [Year], [AuthorId], [GenreId], [CreatedAt]) VALUES (4, N'Королівство плоті і вогню', N'Книга 2', 2022, 2, 3, CAST(N'2025-05-25T11:13:15.7629254' AS DateTime2))
INSERT [dbo].[Books] ([Id], [Title], [Description], [Year], [AuthorId], [GenreId], [CreatedAt]) VALUES (5, N'Корона з позолочених кісток', N'Книга 3', 2022, 2, 3, CAST(N'2025-05-25T11:13:56.2182319' AS DateTime2))
INSERT [dbo].[Books] ([Id], [Title], [Description], [Year], [AuthorId], [GenreId], [CreatedAt]) VALUES (6, N'Війна двох королев', N'Книга 4', 2023, 2, 3, CAST(N'2025-05-25T11:14:29.9448915' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[BorrowRecords] ON 

INSERT [dbo].[BorrowRecords] ([Id], [BookId], [UserId], [BorrowedAt], [ReturnedAt], [CreatedAt]) VALUES (4, 1, 5, CAST(N'2025-05-25T00:00:00.0000000' AS DateTime2), CAST(N'2025-05-30T00:00:00.0000000' AS DateTime2), CAST(N'2025-05-25T13:34:50.2847813' AS DateTime2))
SET IDENTITY_INSERT [dbo].[BorrowRecords] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt]) VALUES (1, N'Фантастика', CAST(N'2025-05-23T11:55:00.0000000' AS DateTime2))
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt]) VALUES (2, N'Трилер', CAST(N'2025-05-23T11:56:00.0000000' AS DateTime2))
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt]) VALUES (3, N'Романтика', CAST(N'2025-05-25T13:15:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Reviews] ON 

INSERT [dbo].[Reviews] ([Id], [Comment], [Rating], [CreatedAt], [BookId], [UserId]) VALUES (2, N'Дуже сподобалось!!', 5, CAST(N'2025-05-25T15:55:17.4572898' AS DateTime2), 1, 3)
SET IDENTITY_INSERT [dbo].[Reviews] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash], [CreatedAt], [Role]) VALUES (3, N'liza', N'liza@liza', N'AQAAAAIAAYagAAAAEMtbjyHpcWJmo9Es3VGnqAEqfqS0XoGnK1Pcz88MXbbaTzwkh4fCJRarnq7HV1aHdQ==', CAST(N'2025-05-25T09:05:05.2882852' AS DateTime2), N'Reader')
INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash], [CreatedAt], [Role]) VALUES (4, N'Admin', N'admin@admin', N'AQAAAAIAAYagAAAAEBgEzVjSO7Gh7XxuEULuGDq+F/XAwhOeqUAq2xRX6O8HJoQYCaI3WZ+8TG9MyGUmuQ==', CAST(N'2025-05-25T09:39:18.2448709' AS DateTime2), N'Admin')
INSERT [dbo].[Users] ([Id], [Username], [Email], [PasswordHash], [CreatedAt], [Role]) VALUES (5, N'kveatrix', N'vika@vika', N'AQAAAAIAAYagAAAAEAH0cX4agnQFlUGIc2OXOE8GvXRTCfR9yecgOBZQkH3lqDvcJW4NqJMoOwYBE4lQLA==', CAST(N'2025-05-25T09:55:42.7776275' AS DateTime2), N'User')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors_AuthorId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Genres_GenreId]
GO
ALTER TABLE [dbo].[BorrowRecords]  WITH CHECK ADD  CONSTRAINT [FK_BorrowRecords_Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[BorrowRecords] CHECK CONSTRAINT [FK_BorrowRecords_Books_BookId]
GO
ALTER TABLE [dbo].[BorrowRecords]  WITH CHECK ADD  CONSTRAINT [FK_BorrowRecords_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BorrowRecords] CHECK CONSTRAINT [FK_BorrowRecords_Users_UserId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Books_BookId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users_UserId]
GO
