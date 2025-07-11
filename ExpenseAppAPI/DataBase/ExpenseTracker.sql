CREATE DATABASE [Expense_DB]

USE [Expense_DB]
GO
/****** Object:  Table [dbo].[ManageUser]    Script Date: 12-07-2025 12:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManageUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Password] [varchar](50) NULL,
	[UserType] [int] NULL,
	[RoomOwnerId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK__ManageUs__3214EC07B733AFF3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room_Mst]    Script Date: 12-07-2025 12:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room_Mst](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomOwnerId] [int] NULL,
	[Name] [varchar](100) NULL,
	[Image] [varchar](max) NULL,
	[Address] [varchar](max) NULL,
	[RentDate] [datetime] NULL,
	[Ammount] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK__Room_Mst__3214EC075E0F08A5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 12-07-2025 12:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkType_Mst]    Script Date: 12-07-2025 12:49:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkType_Mst](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkType] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ManageUser] ON 
GO
INSERT [dbo].[ManageUser] ([Id], [Name], [Email], [PhoneNumber], [Password], [UserType], [RoomOwnerId], [IsActive], [CreatedDate]) VALUES (1, N'Santosh Dash', N'santosh@example.com', N'9876543210', N'Pass@123', 1, NULL, 1, CAST(N'2025-06-30T23:28:52.820' AS DateTime))
GO
INSERT [dbo].[ManageUser] ([Id], [Name], [Email], [PhoneNumber], [Password], [UserType], [RoomOwnerId], [IsActive], [CreatedDate]) VALUES (2, N'Priya Sharma', N'priya.sharma@example.com', N'9123456780', N'Priya#2025', 2, NULL, 1, CAST(N'2025-06-30T23:28:52.820' AS DateTime))
GO
INSERT [dbo].[ManageUser] ([Id], [Name], [Email], [PhoneNumber], [Password], [UserType], [RoomOwnerId], [IsActive], [CreatedDate]) VALUES (3, N'Rahul Verma', N'rahulv@example.com', N'9012345678', N'Rahul@2025', 2, NULL, 1, CAST(N'2025-06-30T23:28:52.820' AS DateTime))
GO
INSERT [dbo].[ManageUser] ([Id], [Name], [Email], [PhoneNumber], [Password], [UserType], [RoomOwnerId], [IsActive], [CreatedDate]) VALUES (4, N'Admin User', N'admin@example.com', N'9001122334', N'Admin@123', 1, NULL, 1, CAST(N'2025-06-30T23:28:52.820' AS DateTime))
GO
INSERT [dbo].[ManageUser] ([Id], [Name], [Email], [PhoneNumber], [Password], [UserType], [RoomOwnerId], [IsActive], [CreatedDate]) VALUES (5, N'Employee One', N'employee1@example.com', N'8888877777', N'Emp@456', 2, NULL, 1, CAST(N'2025-06-30T23:28:52.820' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[ManageUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Room_Mst] ON 
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (1, NULL, N'Sai Residency', N'room1.jpg', N'Plot-22, Saheed Nagar, Bhubaneswar', CAST(N'2025-06-01T00:00:00.000' AS DateTime), CAST(8500.00 AS Decimal(18, 2)), 0, CAST(N'2025-06-30T11:58:19.940' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (2, NULL, N'Sunrise Lodge', N'room2.jpg', N'Patia Main Road, Bhubaneswar', CAST(N'2025-06-15T00:00:00.000' AS DateTime), CAST(7500.00 AS Decimal(18, 2)), 0, CAST(N'2025-06-30T11:58:19.940' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (3, NULL, N'Blue Horizon', N'room3.jpg', N'Near KIIT Campus, Bhubaneswar', CAST(N'2025-06-10T00:00:00.000' AS DateTime), CAST(9200.00 AS Decimal(18, 2)), 0, CAST(N'2025-06-30T11:58:19.940' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (4, NULL, N'Green Villa', N'room4.jpg', N'Chandrasekharpur, Bhubaneswar', CAST(N'2025-06-20T00:00:00.000' AS DateTime), CAST(8800.00 AS Decimal(18, 2)), 0, CAST(N'2025-06-30T11:58:19.940' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (5, NULL, N'Elite Rooms', N'room5.jpg', N'Master Canteen, Bhubaneswar', CAST(N'2025-06-25T00:00:00.000' AS DateTime), CAST(9900.00 AS Decimal(18, 2)), 1, CAST(N'2025-06-30T11:58:19.940' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (6, NULL, N'Niladri Vihar', N'room1.jpg', N'Niladri Vihar, Housing Board Colony', CAST(N'2025-07-30T09:05:11.327' AS DateTime), CAST(8700.00 AS Decimal(18, 2)), 0, CAST(N'2025-06-30T14:37:15.217' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (8, NULL, N'1234', N'assets/images/abc.jpg', N'sasa', CAST(N'2025-07-09T00:00:00.000' AS DateTime), CAST(1221.00 AS Decimal(18, 2)), 0, CAST(N'2025-07-10T16:49:43.017' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (9, NULL, N'HOUSING BOARD COLONY 1', N'assets/images/abc.jpg', N'NILADRI VIHAR1', CAST(N'2025-07-11T00:00:00.000' AS DateTime), CAST(50000.00 AS Decimal(18, 2)), 0, CAST(N'2025-07-10T17:24:29.060' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (10, 1, N'ABC ROOM', N'assets/images/2066c5c3-60d6-44fd-8faf-e96aef4f40c1.jpg', N'ABC , BBSR', CAST(N'2025-07-01T00:00:00.000' AS DateTime), CAST(5000.00 AS Decimal(18, 2)), 1, CAST(N'2025-07-11T15:11:13.680' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (11, 1, N'Niladri Vihar', N'assets/images/59e82364-bbfb-4b41-baa0-6730e2faf1ed.jpg', N'Niladari Vihar , Patia Square , BBSR', CAST(N'2025-07-01T00:00:00.000' AS DateTime), CAST(1200.00 AS Decimal(18, 2)), 1, CAST(N'2025-07-11T16:20:39.270' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (12, 1, N'sasaas', N'assets/images/b37319e3-2bf3-4b98-a90c-fd576f790ec3.jpg', N'saas', CAST(N'2025-07-04T00:00:00.000' AS DateTime), CAST(2221.00 AS Decimal(18, 2)), 1, CAST(N'2025-07-11T16:39:20.893' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (13, 2, N'Santosh Dash', N'assets/images/26376b28-f081-4de6-b6d0-297fe00a3d03.jpg', N'NV Vihar', CAST(N'2025-05-25T00:00:00.000' AS DateTime), CAST(4500.00 AS Decimal(18, 2)), 1, CAST(N'2025-07-12T12:40:08.587' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (14, 2, N'Santosh Dash', N'assets/images/f3cebb64-c3e8-4228-a1b2-9d8b1d286f03.jpg', N'NV Vihar', CAST(N'2025-05-25T00:00:00.000' AS DateTime), CAST(4500.00 AS Decimal(18, 2)), 1, CAST(N'2025-07-12T12:40:45.807' AS DateTime))
GO
INSERT [dbo].[Room_Mst] ([Id], [RoomOwnerId], [Name], [Image], [Address], [RentDate], [Ammount], [IsActive], [CreatedDate]) VALUES (15, 3, N'Dinesh Mohanty', N'assets/images/469048dc-c352-44cc-a72c-59e6bf002860.jpg', N'BBSR, NILADRI VIHAR', CAST(N'2025-02-07T00:00:00.000' AS DateTime), CAST(5000.00 AS Decimal(18, 2)), 1, CAST(N'2025-07-12T12:45:56.533' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Room_Mst] OFF
GO
SET IDENTITY_INSERT [dbo].[UserType] ON 
GO
INSERT [dbo].[UserType] ([Id], [Role], [IsActive], [CreatedDate]) VALUES (1, N'Admin', 1, CAST(N'2025-06-30T11:51:20.587' AS DateTime))
GO
INSERT [dbo].[UserType] ([Id], [Role], [IsActive], [CreatedDate]) VALUES (2, N'Employee', 1, CAST(N'2025-06-30T11:51:20.590' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserType] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkType_Mst] ON 
GO
INSERT [dbo].[WorkType_Mst] ([Id], [WorkType], [IsActive], [CreatedDate]) VALUES (1, N'Student', 1, CAST(N'2025-07-12T12:08:46.413' AS DateTime))
GO
INSERT [dbo].[WorkType_Mst] ([Id], [WorkType], [IsActive], [CreatedDate]) VALUES (2, N'Job Holder', 1, CAST(N'2025-07-12T12:08:46.413' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[WorkType_Mst] OFF
GO
ALTER TABLE [dbo].[ManageUser] ADD  CONSTRAINT [DF__ManageUse__IsAct__71D1E811]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[ManageUser] ADD  CONSTRAINT [DF__ManageUse__Creat__72C60C4A]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Room_Mst] ADD  CONSTRAINT [DF__Room_Mst__IsActi__619B8048]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Room_Mst] ADD  CONSTRAINT [DF__Room_Mst__Create__628FA481]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UserType] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserType] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[WorkType_Mst] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[WorkType_Mst] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Room_Mst]  WITH CHECK ADD  CONSTRAINT [FK_Room_Mst_ManageUser] FOREIGN KEY([RoomOwnerId])
REFERENCES [dbo].[ManageUser] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Room_Mst] CHECK CONSTRAINT [FK_Room_Mst_ManageUser]
GO
