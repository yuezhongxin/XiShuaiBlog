USE [cmsExpress]
GO

/****** Object:  Table [dbo].[app_Permissions]    Script Date: 12/14/2012 14:20:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[app_Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Code] [varchar](50) NULL,
	[PermissionName] [varchar](50) NULL,
	[Url] [varchar](200) NULL,
	[Type] [varchar](50) NULL,
	[IsAuthorized] [bit] NULL,
	[Status] [int] NULL,
	[SortOrder] [int] NULL,
	[LastModifier] [varchar](50) NULL,
	[LastUpdateDate] [datetime] NULL,
 CONSTRAINT [PK_app_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


