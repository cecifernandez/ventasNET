USE [VentasNet]
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwUsuario'
GO
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwUsuario'
GO
/****** Object:  StoredProcedure [dbo].[spAddUsuario]    Script Date: 6/10/2023 11:01:11 ******/
DROP PROCEDURE [dbo].[spAddUsuario]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 6/10/2023 11:01:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Proveedor]') AND type in (N'U'))
DROP TABLE [dbo].[Proveedor]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 6/10/2023 11:01:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Producto]') AND type in (N'U'))
DROP TABLE [dbo].[Producto]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 6/10/2023 11:01:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cliente]') AND type in (N'U'))
DROP TABLE [dbo].[Cliente]
GO
/****** Object:  View [dbo].[vwUsuario]    Script Date: 6/10/2023 11:01:11 ******/
DROP VIEW [dbo].[vwUsuario]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/10/2023 11:01:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuario]') AND type in (N'U'))
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/10/2023 11:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[IdTipoUsuario] [int] NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwUsuario]    Script Date: 6/10/2023 11:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwUsuario]
AS
SELECT        IdUsuario, UserName, Password, Email, Estado, IdTipoUsuario, FechaAlta, FechaBaja
FROM            dbo.Usuario
WHERE        (Estado = '1')
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 6/10/2023 11:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](100) NOT NULL,
	[CUIT] [varchar](11) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NULL,
	[Domicilio] [varchar](100) NOT NULL,
	[Localidad] [varchar](50) NULL,
	[Provincia] [varchar](50) NOT NULL,
	[Telefeno] [varchar](15) NULL,
	[Estado] [bit] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaBaja] [datetime] NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 6/10/2023 11:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[NombreProducto] [varchar](50) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[ImporteProducto] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 6/10/2023 11:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](100) NULL,
	[CUIT] [varchar](11) NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Domicilio] [varchar](100) NOT NULL,
	[Localidad] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
	[Telefeno] [varchar](15) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaBaja] [datetime] NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([IdCliente], [RazonSocial], [CUIT], [Nombre], [Apellido], [Domicilio], [Localidad], [Provincia], [Telefeno], [Estado], [FechaAlta], [FechaBaja], [IdUsuario]) VALUES (2, N'CFernandez', N'123456', N'Cecilia', N'Fernandez', N'asd', N'Lanus', N'BuenosAires', N'45789', 0, CAST(N'2023-10-01T17:24:36.047' AS DateTime), CAST(N'2023-10-02T21:01:37.763' AS DateTime), 0)
GO
INSERT [dbo].[Cliente] ([IdCliente], [RazonSocial], [CUIT], [Nombre], [Apellido], [Domicilio], [Localidad], [Provincia], [Telefeno], [Estado], [FechaAlta], [FechaBaja], [IdUsuario]) VALUES (4, N'Fushimoto', N'456789', N'Gojo', N'Satoru', N'Japon', N'Shibuya', N'Tokyo', N'123456', 0, CAST(N'2023-10-01T18:54:52.470' AS DateTime), CAST(N'2023-10-05T19:56:45.723' AS DateTime), 0)
GO
INSERT [dbo].[Cliente] ([IdCliente], [RazonSocial], [CUIT], [Nombre], [Apellido], [Domicilio], [Localidad], [Provincia], [Telefeno], [Estado], [FechaAlta], [FechaBaja], [IdUsuario]) VALUES (12, N'asd', N'123', N'', N'', N'asd', N'', N'asd', N'', 0, CAST(N'2023-10-02T21:39:45.907' AS DateTime), CAST(N'2023-10-02T21:40:03.350' AS DateTime), 0)
GO
INSERT [dbo].[Cliente] ([IdCliente], [RazonSocial], [CUIT], [Nombre], [Apellido], [Domicilio], [Localidad], [Provincia], [Telefeno], [Estado], [FechaAlta], [FechaBaja], [IdUsuario]) VALUES (13, N'ElektraComics', N'20425675438', N'', N'', N'Defensa 200', N'', N'Buenos Aires', N'', 1, CAST(N'2023-10-05T19:57:13.603' AS DateTime), CAST(N'2023-10-05T19:57:13.603' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 
GO
INSERT [dbo].[Producto] ([Id], [IdProveedor], [NombreProducto], [Descripcion], [ImporteProducto], [Estado], [Codigo]) VALUES (1, 1, N'Vagabond', N'A5', N'3200', 1, N'AA1')
GO
INSERT [dbo].[Producto] ([Id], [IdProveedor], [NombreProducto], [Descripcion], [ImporteProducto], [Estado], [Codigo]) VALUES (2, 1, N'ChainsawMan', N'Tankobon', N'2800', 1, N'AA2')
GO
INSERT [dbo].[Producto] ([Id], [IdProveedor], [NombreProducto], [Descripcion], [ImporteProducto], [Estado], [Codigo]) VALUES (3, 0, N'A', N'A', N'A', 0, N'AA3')
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedor] ON 
GO
INSERT [dbo].[Proveedor] ([IdProveedor], [RazonSocial], [CUIT], [Nombre], [Apellido], [Domicilio], [Localidad], [Provincia], [Telefeno], [Estado], [FechaAlta], [FechaBaja], [IdUsuario]) VALUES (1, N'Ivrea', N'123', N'', N'', N'asd', N'', N'asd', N'', 0, CAST(N'2023-10-04T19:32:50.787' AS DateTime), CAST(N'2023-10-04T19:32:52.857' AS DateTime), 0)
GO
INSERT [dbo].[Proveedor] ([IdProveedor], [RazonSocial], [CUIT], [Nombre], [Apellido], [Domicilio], [Localidad], [Provincia], [Telefeno], [Estado], [FechaAlta], [FechaBaja], [IdUsuario]) VALUES (2, N'asd', N'56', N'', N'', N'sdf', N'', N'a', N'', 1, CAST(N'2023-10-04T19:34:44.237' AS DateTime), CAST(N'2023-10-04T19:34:44.237' AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([IdUsuario], [UserName], [Password], [Email], [Estado], [IdTipoUsuario], [FechaAlta], [FechaBaja]) VALUES (1, N'ceci', N'admin', N'mceciliafernandezst@gmail.com', 0, NULL, CAST(N'2023-08-30T19:37:20.180' AS DateTime), CAST(N'2023-08-30T21:13:24.697' AS DateTime))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [UserName], [Password], [Email], [Estado], [IdTipoUsuario], [FechaAlta], [FechaBaja]) VALUES (3, N'CFernandez', N'admin', N'mceciliafernandezst@gmail.com', 0, NULL, CAST(N'2023-08-30T20:08:15.680' AS DateTime), CAST(N'2023-08-30T21:13:24.697' AS DateTime))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [UserName], [Password], [Email], [Estado], [IdTipoUsuario], [FechaAlta], [FechaBaja]) VALUES (4, N'CFernandez', N'admin', N'mceciliafernandezst@gmail.com', 0, NULL, CAST(N'2023-08-30T20:08:28.653' AS DateTime), CAST(N'2023-08-30T21:13:24.697' AS DateTime))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [UserName], [Password], [Email], [Estado], [IdTipoUsuario], [FechaAlta], [FechaBaja]) VALUES (5, N'CFernandez', N'admin', N'mceciliafernandezst@gmail.com', 0, NULL, CAST(N'2023-08-30T20:11:24.967' AS DateTime), CAST(N'2023-08-30T21:13:24.697' AS DateTime))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [UserName], [Password], [Email], [Estado], [IdTipoUsuario], [FechaAlta], [FechaBaja]) VALUES (6, N'CFernandez', N'admin', N'mceciliafernandezst@gmail.com', 0, NULL, CAST(N'2023-08-30T20:16:47.343' AS DateTime), CAST(N'2023-08-30T21:13:24.697' AS DateTime))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [UserName], [Password], [Email], [Estado], [IdTipoUsuario], [FechaAlta], [FechaBaja]) VALUES (7, N'CFernandez', N'admin', N'mceciliafernandezst@gmail.com', 0, NULL, CAST(N'2023-08-30T21:13:24.697' AS DateTime), CAST(N'2023-08-30T21:13:24.697' AS DateTime))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [UserName], [Password], [Email], [Estado], [IdTipoUsuario], [FechaAlta], [FechaBaja]) VALUES (8, N'MCFernandez', N'admin', N'mceciliafernandezst@gmail.com', 1, NULL, CAST(N'2023-08-30T21:35:33.010' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  StoredProcedure [dbo].[spAddUsuario]    Script Date: 6/10/2023 11:01:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spAddUsuario]
	@UserName varchar(50),
	@Password varchar(50),
	@Email varchar(50),
	@Estado bit,
	@IdTipoUsuario int,
	@FechaAlta Datetime,
	@FechaBaja datetime
AS
BEGIN

	set @Estado = 1
	set @FechaAlta = GETDATE()
	set @FechaBaja = null

	insert into Usuario(UserName, Password, Email, Estado, IdTipoUsuario, FechaAlta, FechaBaja) 
	values (@UserName, @Password, @Email, @Estado, @IdTipoUsuario, @FechaAlta, @FechaBaja)

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Usuario"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwUsuario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwUsuario'
GO
