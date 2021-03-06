USE [demo]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/22/2019 10:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](500) NULL,
	[Password] [nvarchar](500) NULL,
	[fkUserContactId] [int] NOT NULL,
	[fkUserDetailId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserContact]    Script Date: 2/22/2019 10:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserContact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](500) NULL,
	[Pincode] [nvarchar](500) NULL,
	[State] [nvarchar](500) NULL,
	[Area] [nvarchar](500) NULL,
 CONSTRAINT [PK_UserContact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 2/22/2019 10:17:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](500) NULL,
	[LastName] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [Password], [fkUserContactId], [fkUserDetailId]) VALUES (3, N'spatil', N'test', 1, 1)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [fkUserContactId], [fkUserDetailId]) VALUES (4, N'yogeshp', N'test', 2, 2)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [fkUserContactId], [fkUserDetailId]) VALUES (6, N'mandarn', N'test', 3, 3)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [fkUserContactId], [fkUserDetailId]) VALUES (9, N'testn', N'test', 1, 1)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [fkUserContactId], [fkUserDetailId]) VALUES (12, N't1', N't2', 3, 3)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [fkUserContactId], [fkUserDetailId]) VALUES (13, N't1', N'test123', 3, 3)
INSERT [dbo].[User] ([UserId], [UserName], [Password], [fkUserContactId], [fkUserDetailId]) VALUES (14, N't3', N't3', 3, 3)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserContact] ON 

INSERT [dbo].[UserContact] ([Id], [City], [Pincode], [State], [Area]) VALUES (1, N'Pune', N'411027', N'Maharashtra', N'Sangvi')
INSERT [dbo].[UserContact] ([Id], [City], [Pincode], [State], [Area]) VALUES (2, N'Pune', N'400124', N'Maharashtra', N'Aundh')
INSERT [dbo].[UserContact] ([Id], [City], [Pincode], [State], [Area]) VALUES (3, N'Mumbai', N'400014', N'Maharashtra', N'Bandra')
SET IDENTITY_INSERT [dbo].[UserContact] OFF
SET IDENTITY_INSERT [dbo].[UserDetails] ON 

INSERT [dbo].[UserDetails] ([Id], [FirstName], [LastName], [Email]) VALUES (1, N'Shailendra', N'Patil', N'spatil@test.com')
INSERT [dbo].[UserDetails] ([Id], [FirstName], [LastName], [Email]) VALUES (2, N'Mandar', N'Nagarkar', N'mandar@test.com')
INSERT [dbo].[UserDetails] ([Id], [FirstName], [LastName], [Email]) VALUES (3, N'Yogesh', N'Pangam', N'yogesh@test.com')
INSERT [dbo].[UserDetails] ([Id], [FirstName], [LastName], [Email]) VALUES (4, NULL, NULL, NULL)
INSERT [dbo].[UserDetails] ([Id], [FirstName], [LastName], [Email]) VALUES (5, NULL, NULL, NULL)
INSERT [dbo].[UserDetails] ([Id], [FirstName], [LastName], [Email]) VALUES (6, NULL, NULL, NULL)
INSERT [dbo].[UserDetails] ([Id], [FirstName], [LastName], [Email]) VALUES (7, NULL, NULL, NULL)
INSERT [dbo].[UserDetails] ([Id], [FirstName], [LastName], [Email]) VALUES (8, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[UserDetails] OFF
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([fkUserContactId])
REFERENCES [dbo].[UserContact] ([Id])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserDetails] FOREIGN KEY([fkUserDetailId])
REFERENCES [dbo].[UserDetails] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserDetails]
GO
