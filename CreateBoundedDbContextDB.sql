USE [master]
GO
/****** Object:  Database [ef_bounded_dbcontext_after]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE DATABASE [bounded_dbcontext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bounded_dbcontext', FILENAME = N'D:\bSeamless\Training\DotNet Programming\bSeamless.DotNetProg\data\bounded_dbcontext.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bounded_dbcontext_log', FILENAME = N'D:\bSeamless\Training\DotNet Programming\bSeamless.DotNetProg\data\bounded_dbcontext.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ef_bounded_dbcontext_after].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET ARITHABORT OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET  MULTI_USER 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ef_bounded_dbcontext_after]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(7,1) NOT NULL,
	[Name] [nvarchar](25) NULL,
	[Promotion_PromotionId] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(7,1) NOT NULL,
	[SalesPersonId] [nvarchar](4000) NULL,
	[Title] [nvarchar](10) NULL,
	[FirstName] [nvarchar](40) NULL,
	[LastName] [nvarchar](40) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Phone] [nvarchar](25) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalesPerson] [bit] NOT NULL,
	[HireDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
	[Title] [nvarchar](10) NULL,
	[FirstName] [nvarchar](40) NULL,
	[LastName] [nvarchar](40) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[EmailAddress] [nvarchar](50) NULL,
	[Phone] [nvarchar](25) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LineItems]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineItems](
	[LineItemId] [int] IDENTITY(20,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderQty] [int] NOT NULL,
	[UnitPrice] [numeric](18, 2) NULL,
	[UnitPriceDiscount] [numeric](18, 2) NULL,
	[ShipmentId] [int] NULL,
 CONSTRAINT [PK_LineItems] PRIMARY KEY CLUSTERED 
(
	[LineItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(20,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[DueDate] [datetime] NULL,
	[OnlineOrder] [bit] NOT NULL,
	[SalesOrderNumber] [nvarchar](4000) NULL,
	[PurchaseOrderNumber] [nvarchar](4000) NULL,
	[CustomerId] [int] NOT NULL,
	[SubTotal] [numeric](18, 2) NOT NULL,
	[Comment] [nvarchar](4000) NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[PromotionId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payments]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[Amount] [numeric](18, 2) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(7,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ProductNumber] [nvarchar](10) NOT NULL,
	[StandardCost] [numeric](18, 2) NOT NULL,
	[ListPrice] [numeric](18, 2) NOT NULL,
	[Size] [nvarchar](4000) NULL,
	[CategoryId] [int] NOT NULL,
	[SellStartDate] [datetime] NOT NULL,
	[ShippingWeight] [numeric](18, 2) NULL,
	[SellEndDate] [datetime] NULL,
	[DiscontinuedDate] [datetime] NULL,
	[Photo] [varbinary](4000) NULL,
	[Promotion_PromotionId] [int] NULL,
	[Color] [int] NOT NULL CONSTRAINT [DF_Products_Color]  DEFAULT ((0)),
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotions](
	[PromotionId] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Description] [nvarchar](4000) NULL,
	[AllProducts] [bit] NOT NULL,
 CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED 
(
	[PromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Returns]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Returns](
	[ReturnId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [datetime] NOT NULL,
	[Reason] [nvarchar](4000) NULL,
	[OrderId] [int] NOT NULL,
 CONSTRAINT [PK_Returns] PRIMARY KEY CLUSTERED 
(
	[ReturnId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalaryHistories]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryHistories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Salary] [int] NOT NULL,
 CONSTRAINT [PK_SalaryHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shipments]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipments](
	[ShipmentId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[EntireOrder] [bit] NOT NULL,
	[DateShipped] [datetime] NOT NULL,
	[ShipperId] [int] NOT NULL,
 CONSTRAINT [PK_Shipments] PRIMARY KEY CLUSTERED 
(
	[ShipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shippers]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippers](
	[ShipperId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[ShipperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShippingAddresses]    Script Date: 1/31/2015 1:27:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingAddresses](
	[Id] [int] NOT NULL,
	[Street1] [nvarchar](50) NULL,
	[Street2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Region] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_ShippingAddresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Promotion_PromotionId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_Promotion_PromotionId] ON [dbo].[Categories]
(
	[Promotion_PromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[LineItems]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[LineItems]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShipmentId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_ShipmentId] ON [dbo].[LineItems]
(
	[ShipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CustomerId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_CustomerId] ON [dbo].[Orders]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[Payments]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Promotion_PromotionId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_Promotion_PromotionId] ON [dbo].[Products]
(
	[Promotion_PromotionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[Returns]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeId] ON [dbo].[SalaryHistories]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShipperId]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_ShipperId] ON [dbo].[Shipments]
(
	[ShipperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Id]    Script Date: 1/31/2015 1:27:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_Id] ON [dbo].[ShippingAddresses]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Promotions_Promotion_PromotionId] FOREIGN KEY([Promotion_PromotionId])
REFERENCES [dbo].[Promotions] ([PromotionId])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Promotions_Promotion_PromotionId]
GO
ALTER TABLE [dbo].[LineItems]  WITH CHECK ADD  CONSTRAINT [FK_LineItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LineItems] CHECK CONSTRAINT [FK_LineItems_Orders_OrderId]
GO
ALTER TABLE [dbo].[LineItems]  WITH CHECK ADD  CONSTRAINT [FK_LineItems_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LineItems] CHECK CONSTRAINT [FK_LineItems_Products_ProductId]
GO
ALTER TABLE [dbo].[LineItems]  WITH CHECK ADD  CONSTRAINT [FK_LineItems_Shipments_ShipmentId] FOREIGN KEY([ShipmentId])
REFERENCES [dbo].[Shipments] ([ShipmentId])
GO
ALTER TABLE [dbo].[LineItems] CHECK CONSTRAINT [FK_LineItems_Shipments_ShipmentId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Orders_OrderId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Promotions_Promotion_PromotionId] FOREIGN KEY([Promotion_PromotionId])
REFERENCES [dbo].[Promotions] ([PromotionId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Promotions_Promotion_PromotionId]
GO
ALTER TABLE [dbo].[Returns]  WITH CHECK ADD  CONSTRAINT [FK_Returns_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Returns] CHECK CONSTRAINT [FK_Returns_Orders_OrderId]
GO
ALTER TABLE [dbo].[SalaryHistories]  WITH CHECK ADD  CONSTRAINT [FK_SalaryHistories_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalaryHistories] CHECK CONSTRAINT [FK_SalaryHistories_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Shipments]  WITH CHECK ADD  CONSTRAINT [FK_Shipments_Shippers_ShipperId] FOREIGN KEY([ShipperId])
REFERENCES [dbo].[Shippers] ([ShipperId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shipments] CHECK CONSTRAINT [FK_Shipments_Shippers_ShipperId]
GO
ALTER TABLE [dbo].[ShippingAddresses]  WITH CHECK ADD  CONSTRAINT [FK_ShippingAddresses_Customers_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[ShippingAddresses] CHECK CONSTRAINT [FK_ShippingAddresses_Customers_Id]
GO
USE [master]
GO
ALTER DATABASE [ef_bounded_dbcontext_after] SET  READ_WRITE 
GO
