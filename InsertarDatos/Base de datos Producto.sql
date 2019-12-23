/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [Producto]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 19/12/2019 21:44:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[Id] [int] NULL,
	[Precio] [money] NULL,
	[Descripcion] [varchar](100) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[productos] ([Id], [Precio], [Descripcion]) VALUES (1, 180.0000, N'Laptop-Hp-ProBook 4440s')
