USE [master]
GO
/****** Object:  Database [PurchasesOrder]    Script Date: 4/29/2016 11:23:36 PM ******/
CREATE DATABASE [PurchasesOrder]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PurchasesOrder', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PurchasesOrder.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PurchasesOrder_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PurchasesOrder_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PurchasesOrder] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PurchasesOrder].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PurchasesOrder] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PurchasesOrder] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PurchasesOrder] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PurchasesOrder] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PurchasesOrder] SET ARITHABORT OFF 
GO
ALTER DATABASE [PurchasesOrder] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PurchasesOrder] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PurchasesOrder] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PurchasesOrder] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PurchasesOrder] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PurchasesOrder] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PurchasesOrder] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PurchasesOrder] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PurchasesOrder] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PurchasesOrder] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PurchasesOrder] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PurchasesOrder] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PurchasesOrder] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PurchasesOrder] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PurchasesOrder] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PurchasesOrder] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PurchasesOrder] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PurchasesOrder] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PurchasesOrder] SET RECOVERY FULL 
GO
ALTER DATABASE [PurchasesOrder] SET  MULTI_USER 
GO
ALTER DATABASE [PurchasesOrder] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PurchasesOrder] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PurchasesOrder] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PurchasesOrder] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PurchasesOrder', N'ON'
GO
USE [PurchasesOrder]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCompany]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteCompany]
(
	@Company_Id int
)
AS
	SET NOCOUNT OFF;
	update [M_COMPANY]
	set is_active = 0
 WHERE (([Company_Id] = @Company_Id))


GO
/****** Object:  StoredProcedure [dbo].[DeleteItemName]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DeleteItemName]
(
	@Item_id int
)
AS
	SET NOCOUNT OFF;
delete [Item]
 WHERE Item_id = @Item_id

GO
/****** Object:  StoredProcedure [dbo].[DeletePurchasesOrder]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DeletePurchasesOrder]
(
	@Purchases_Order_Id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [M_PURCHASES_ORDER] 
WHERE ([Purchases_Order_Id] = @Purchases_Order_Id)

GO
/****** Object:  StoredProcedure [dbo].[DeletePurchasesOrderDetail]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DeletePurchasesOrderDetail]
(
	@Purchases_Order_Id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [M_PURCHASES_ORDER_DETAIL]
 WHERE ((Purchases_Order_Id = @Purchases_Order_Id))

GO
/****** Object:  StoredProcedure [dbo].[DeletePurchasesOrderDetail_ById]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create  PROCEDURE [dbo].[DeletePurchasesOrderDetail_ById]
(
	@Purchase_Order_Detail_Id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [M_PURCHASES_ORDER_DETAIL]
 WHERE ((Purchase_Order_Detail_Id = @Purchase_Order_Detail_Id))

GO
/****** Object:  StoredProcedure [dbo].[GetBalanceSheet]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetBalanceSheet]
(
	@Purchases_Order_Id int
)
AS
	SET NOCOUNT ON;
SELECT M_PURCHASES_ORDER_DETAIL.Purchase_Order_Detail_Id
	, I.Item_Name
	, Item_Quantity
	, Item_Rate
	, Total_Amount
	, SUM(M_DELIVERY_DETAIL.Deliver_Quantity) AS Total_Deliver_Quantity 
	, Item_Quantity - SUM(M_DELIVERY_DETAIL.Deliver_Quantity) AS Total_Balance
 FROM M_PURCHASES_ORDER_DETAIL inner join 
      Item I on M_PURCHASES_ORDER_DETAIL.Item_Id = I.Item_Id  LEFT JOIN
	  M_DELIVERY_DETAIL ON M_PURCHASES_ORDER_DETAIL.Purchase_Order_Detail_Id = M_DELIVERY_DETAIL.Purchase_Order_Detail_Id
WHERE Purchases_Order_Id = @Purchases_Order_Id
GROUP BY M_PURCHASES_ORDER_DETAIL.Purchase_Order_Detail_Id
		,I.Item_Name
		,Item_Quantity
		,Item_Rate
		,Total_Amount
ORDER BY I.Item_Name

GO
/****** Object:  StoredProcedure [dbo].[GetCompletePurchasesOrder]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetCompletePurchasesOrder]
(
	@Company_id int
)
AS
	SET NOCOUNT ON;
	
	Select M_PURCHASES_ORDER.Purchases_Order_Id 	         
	  FROM M_COMPANY INNER JOIN
	       M_PURCHASES_ORDER ON M_COMPANY.Company_id = M_PURCHASES_ORDER.Company_id       
      WHERE  M_PURCHASES_ORDER.Purchases_Order_Id  NOT IN (
															Select DISTINCT Purchases_Order_Id 
															 from(
																   SELECT M_PURCHASES_ORDER.Purchases_Order_Id					
																		 ,Item_Quantity
																		 ,ISNULL(SUM(M_DELIVERY_DETAIL.Deliver_Quantity),0) AS Total_Deliver_Quantity 
																		 ,Item_Quantity - ISNULL(SUM(M_DELIVERY_DETAIL.Deliver_Quantity),0) AS Total_Balance																		
																	 FROM M_COMPANY INNER JOIN 
																		  M_PURCHASES_ORDER ON M_COMPANY.Company_id = M_PURCHASES_ORDER.Company_id INNER JOIN
																		  M_PURCHASES_ORDER_DETAIL ON  M_PURCHASES_ORDER.Purchases_Order_Id = M_PURCHASES_ORDER_DETAIL.Purchases_Order_Id LEFT JOIN
																		  M_DELIVERY_DETAIL ON M_PURCHASES_ORDER_DETAIL.Purchase_Order_Detail_Id = M_DELIVERY_DETAIL.Purchase_Order_Detail_Id
																	Where M_COMPANY.Company_id = @Company_id	  
																	GROUP BY M_PURCHASES_ORDER.Purchases_Order_Id					
																			,Item_Quantity
																			,Item_Rate
																			,Total_Amount
																	
																  ) AS TAb1
															WHERE Total_Balance >0
															
														 )AND
           
		M_COMPANY.Company_id = @Company_id

GO
/****** Object:  StoredProcedure [dbo].[GetPurchasesOrderByBillId]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetPurchasesOrderByBillId]
(
	@Bill_Id int
)
AS
	SET NOCOUNT ON;
	SELECT M_PURCHASES_ORDER.Purchases_Order_Id
		  ,M_PURCHASES_ORDER.Company_id
		  ,M_PURCHASES_ORDER.Date
		  ,M_PURCHASES_ORDER.Purchases_Order_No		
      FROM M_PURCHASES_ORDER INNER JOIN 
		   M_PURCHASES_ORDER_DETAIL ON M_PURCHASES_ORDER.Purchases_Order_Id = M_PURCHASES_ORDER_DETAIL.Purchases_Order_Id INNER JOIN
		   B_BILL_ITEM ON M_PURCHASES_ORDER_DETAIL.Purchase_Order_Detail_Id = B_BILL_ITEM.Purchase_Order_Detail_Id		   
	 Where Bill_Id = @Bill_Id
   ORDER BY Purchases_Order_No

GO
/****** Object:  StoredProcedure [dbo].[GetPurchasesOrderByCompId]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetPurchasesOrderByCompId]
(
	@Company_id int
)
AS
	SET NOCOUNT ON;
	SELECT   Purchases_Order_Id
		   , Company_id
		   , Date
		   , Purchases_Order_No
	 FROM M_PURCHASES_ORDER
	Where Company_id = @Company_id
   ORDER BY Date desc


GO
/****** Object:  StoredProcedure [dbo].[GetPurchasesOrderDetailByOrderId]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetPurchasesOrderDetailByOrderId]
(
	@Purchases_Order_Id int
)
AS
	SET NOCOUNT ON;
SELECT Purchase_Order_Detail_Id
	, Purchases_Order_Id
	, I.Item_Name
	, I.Item_Id
	, Item_Quantity
	, Item_Rate
	, Total_Amount
 FROM M_PURCHASES_ORDER_DETAIL Inner join
 Item I on M_PURCHASES_ORDER_DETAIL.Item_Id = I.Item_Id 
WHERE Purchases_Order_Id = @Purchases_Order_Id
ORDER BY I.Item_Name

GO
/****** Object:  StoredProcedure [dbo].[InsertCompany]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[InsertCompany]
(
	@tin_no nvarchar(50),
	@company_name nvarchar(50),
	@address1 nvarchar(150),
	@pan_no nvarchar(150),
	@city nvarchar(50),
	@state nvarchar(50),
	@pincode nvarchar(50),
	@email nvarchar(150),
	@phone nvarchar(50),
	@Fax_No  nvarchar(50),
	@delivery_at nvarchar(2000)
	
)
AS
	SET NOCOUNT OFF;
INSERT INTO [M_COMPANY](  is_active
						, [tin_no]
						, [company_name]
						, [address1]
						, [pan_no]
						, [city]
						, [state]
						, [pincode]
						, [email]
						, [phone]
						, Fax_No
					    ,delivery_at
					  )
			 VALUES 
					( 1
					, @tin_no
					, @company_name
					, @address1
					, @pan_no
					, @city
					, @state
					, @pincode
					, @email
					, @phone
					, @Fax_No
					,@delivery_at
				   );
						
Declare @CompanyId int
set @CompanyId = SCOPE_IDENTITY()
select @CompanyId


GO
/****** Object:  StoredProcedure [dbo].[InsertItemName]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertItemName]
(
	@Item_Name nvarchar(max)
)
AS
	SET NOCOUNT OFF;

	if exists(select 1 from Item where Item_Name = @Item_Name)
	begin
		select -1 -- -1 is code for dulicate item
	end
	else
	begin


INSERT INTO [dbo].[Item]
           ([Item_Name])
     VALUES
           (@Item_Name)	
           				
Declare @Item_Id int
set @Item_Id = SCOPE_IDENTITY()
select @Item_Id
end


GO
/****** Object:  StoredProcedure [dbo].[InsertPurchasesOrder]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[InsertPurchasesOrder]
(
	@Company_id int,
	@Date datetime,
	@Purchases_Order_No VARCHAR(100)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [M_PURCHASES_ORDER] 
			( [Company_id]
			, [Date]
			, [Purchases_Order_No]
			) 
	VALUES (  @Company_id
			, @Date
			, @Purchases_Order_No
			);
	
SELECT (SCOPE_IDENTITY())



SET ANSI_NULLS ON

GO
/****** Object:  StoredProcedure [dbo].[InsertPurchasesOrderDetail]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[InsertPurchasesOrderDetail]
(
	@Purchases_Order_Id int,
	@Item_Name nvarchar(100),
	@Item_Id int,
	@Item_Quantity float,
	@Item_Rate float	
)
AS
	SET NOCOUNT OFF;
   INSERT INTO [M_PURCHASES_ORDER_DETAIL]
			 ( [Purchases_Order_Id]
			 , [Item_Name]
			 , Item_Id
			 , [Item_Quantity]
			 , [Item_Rate]
			 , [Total_Amount]
			 )
	  VALUES 
			 ( @Purchases_Order_Id
			 , @Item_Name
			 , @Item_Id 
			 , @Item_Quantity
			 , @Item_Rate
			 , @Item_Quantity * @Item_Rate
			 );
	
SELECT ( SCOPE_IDENTITY())

GO
/****** Object:  StoredProcedure [dbo].[PurchasesReport]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchasesReport]
(
	@Start_Date datetime,
	@End_date datetime,
	@Company_id  int,
	@item_id int

)


AS
	
;with cte as
	(
		select POD.[Item_Id]
		, PO.Company_id
		,sum(POD.Item_Quantity) as total_quantity
		,sum(Total_Amount) as  total_amount
		from [dbo].[M_PURCHASES_ORDER] PO  
		inner join [dbo].[M_PURCHASES_ORDER_DETAIL] POD on PO.Purchases_Order_Id = POD.Purchases_Order_Id		
		where [Date] >= @Start_Date
		and @End_date <= @End_date
		and ( (@Company_id is not null and [Company_id] = @Company_id) or @Company_id is null)
		and ( (@item_id is not null and POD.item_id = @item_id) or @item_id is null) 
		group by PO.Company_id, POD.[Item_Id]
	)
	select c.Company_id
	 ,c.company_name as [Company Name]
	 ,I.Item_Name as [Item Name]
	 ,total_quantity as [total Quantity]
	 ,total_amount as [Total Amount]
	from cte
	inner join [dbo].[Item] I on I.[Item_Id] = cte.[Item_Id]
	inner join dbo.M_COMPANY C on c.Company_id = cte.Company_id
	where total_quantity > 0
	order by company_name, Item_Name






GO
/****** Object:  StoredProcedure [dbo].[SelectCompanyAll]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SelectCompanyAll]


AS
	SET NOCOUNT ON;
      SELECT  company_Id
            , company_name 
			, tin_no 
			, pan_no
			, phone
			, address1
			, city
			, state
			, pincode
			, email
			, phone
			, Fax_No
			, delivery_at
       FROM M_COMPANY
	   where is_active = 1
     
order by company_name










GO
/****** Object:  StoredProcedure [dbo].[SelectCompanyById]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SelectCompanyById]
(
	@Company_Id int
)
AS
	SET NOCOUNT ON;
SELECT        company_id			
			, tin_no
			, company_name
			, address1
			, pan_no
			, city
			, state
			, pincode
			, email
			, phone
			, Fax_No
			,delivery_at
			
FROM M_COMPANY
WHERE (Company_Id = @Company_Id)


GO
/****** Object:  StoredProcedure [dbo].[SelectItemNameAll]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[SelectItemNameAll]

AS
	SET NOCOUNT OFF;
SELECT [Item_Id]
      ,[Item_Name]
  FROM [Item]
  order by Item_Name


GO
/****** Object:  StoredProcedure [dbo].[SelectItemNameById]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SelectItemNameById]
(
	@Item_id int
)
AS
	SET NOCOUNT OFF;
SELECT [Item_Id]
      ,[Item_Name]
  FROM [Item]
  where Item_id = @Item_id


GO
/****** Object:  StoredProcedure [dbo].[SelectPurchasesOrderById]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SelectPurchasesOrderById]
(
	@Purchases_Order_Id int
)
AS
	SET NOCOUNT ON;
	SELECT Purchases_Order_Id
		   , Company_id
		   , Date
		   , Purchases_Order_No
		FROM M_PURCHASES_ORDER
	Where Purchases_Order_Id = @Purchases_Order_Id

GO
/****** Object:  StoredProcedure [dbo].[SelectPurchasesOrderDetailAll]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SelectPurchasesOrderDetailAll]
AS
	SET NOCOUNT ON;
SELECT Purchase_Order_Detail_Id
	, Purchases_Order_Id
	, I.Item_Name
	,I.Item_Id
	, Item_Quantity
	, Item_Rate
	, Total_Amount
FROM M_PURCHASES_ORDER_DETAIL inner join
     Item I on M_PURCHASES_ORDER_DETAIL.Item_Id = I.Item_Id 
oRDER BY I.Item_Name

GO
/****** Object:  StoredProcedure [dbo].[UpdateCompany]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[UpdateCompany]
(
	@tin_no nvarchar(50),
	@company_name nvarchar(50),
	@address1 nvarchar(150),
	@pan_no nvarchar(150),
	@city nvarchar(50),
	@state nvarchar(50),
	@pincode nvarchar(50),
	@email nvarchar(150),
	@phone nvarchar(50),
	@Fax_No  nvarchar(50),
	@company_id BIGINT,
	@delivery_at nvarchar(2000)	
)
AS
	SET NOCOUNT OFF;
UPDATE [M_COMPANY] 
  SET  [tin_no] = @tin_no
	 , [company_name] = @company_name
	 , [address1] = @address1
	 , [pan_no] = @pan_no
	 , [city] = @city
	 , [state] = @state
	 , [pincode] = @pincode
	 , [email] = @email
	 , [phone] = @phone	
	 , Fax_No = @Fax_No	
	 , delivery_at = @delivery_at	
 WHERE [company_id] = @company_id;



GO
/****** Object:  StoredProcedure [dbo].[UpdateItemName]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateItemName]
(
	@Item_Name nvarchar(max)
	,@Item_id int
)
AS
	SET NOCOUNT OFF;

if exists(select 1 from Item where Item_Name = @Item_Name)
	begin
		select -1 -- -1 is code for dulicate item
	end
	else
	begin


	UPDATE [Item]
	   SET [Item_Name] = @Item_Name
	 WHERE Item_id = @Item_id
end
GO
/****** Object:  StoredProcedure [dbo].[UpdatePurchasesOrder]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[UpdatePurchasesOrder]
(
	@Date datetime,
	@Purchases_Order_No VARCHAR(100),
	@Purchases_Order_Id int
)
AS
	SET NOCOUNT OFF;
UPDATE [M_PURCHASES_ORDER]
   SET [Date] = @Date
     , [Purchases_Order_No] = @Purchases_Order_No 
 WHERE ([Purchases_Order_Id] = @Purchases_Order_Id)





GO
/****** Object:  StoredProcedure [dbo].[UpdatePurchasesOrderDetail]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdatePurchasesOrderDetail]
(
	@Item_Name nvarchar(100),
	@Item_Id int,
	@Item_Quantity float,
	@Item_Rate float,
	@Purchase_Order_Detail_Id int
)
AS
	SET NOCOUNT OFF;
UPDATE [M_PURCHASES_ORDER_DETAIL]
   SET [Item_Name] = @Item_Name
     , Item_Id = @Item_Id
	 , [Item_Quantity] = @Item_Quantity
	 , [Item_Rate] = @Item_Rate
	 , [Total_Amount] = @Item_Quantity*@Item_Rate
WHERE ([Purchase_Order_Detail_Id] = @Purchase_Order_Detail_Id);


GO
/****** Object:  Table [dbo].[Item]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[Item_Id] [int] IDENTITY(1,1) NOT NULL,
	[Item_Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Item_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_COMPANY]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_COMPANY](
	[Company_id] [int] IDENTITY(1,1) NOT NULL,
	[tin_no] [nvarchar](50) NULL,
	[company_name] [nvarchar](150) NULL,
	[address1] [nvarchar](450) NULL,
	[pan_no] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
	[state] [nvarchar](50) NULL,
	[pincode] [nvarchar](50) NULL,
	[email] [nvarchar](150) NULL,
	[phone] [nvarchar](50) NULL,
	[Fax_No] [nvarchar](50) NULL,
	[is_active] [int] NULL,
	[future1] [nvarchar](100) NULL,
	[future2] [nvarchar](100) NULL,
	[delivery_at] [nvarchar](2000) NULL,
 CONSTRAINT [PK_M_COMPANY] PRIMARY KEY CLUSTERED 
(
	[Company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_PURCHASES_ORDER]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[M_PURCHASES_ORDER](
	[Purchases_Order_Id] [int] IDENTITY(1,1) NOT NULL,
	[Company_id] [int] NULL,
	[Date] [datetime] NULL,
	[Purchases_Order_No] [varchar](100) NOT NULL,
	[Future1] [nchar](10) NULL,
	[Future2] [nchar](10) NULL,
 CONSTRAINT [PK_M_PURCHASES_ORDER] PRIMARY KEY CLUSTERED 
(
	[Purchases_Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[M_PURCHASES_ORDER_DETAIL]    Script Date: 4/29/2016 11:23:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_PURCHASES_ORDER_DETAIL](
	[Purchase_Order_Detail_Id] [int] IDENTITY(1,1) NOT NULL,
	[Purchases_Order_Id] [int] NULL,
	[Item_Name] [nvarchar](100) NULL,
	[Item_Quantity] [float] NULL,
	[Item_Rate] [float] NULL,
	[Total_Amount] [decimal](10, 2) NULL,
	[future1] [nchar](10) NULL,
	[future2] [nchar](10) NULL,
	[Item_Id] [int] NULL,
 CONSTRAINT [PK_M_PURCHASES_ORDER_DETAIL] PRIMARY KEY CLUSTERED 
(
	[Purchase_Order_Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[M_PURCHASES_ORDER]  WITH CHECK ADD  CONSTRAINT [FK_M_PURCHASES_ORDER_M_COMPANY] FOREIGN KEY([Company_id])
REFERENCES [dbo].[M_COMPANY] ([Company_id])
GO
ALTER TABLE [dbo].[M_PURCHASES_ORDER] CHECK CONSTRAINT [FK_M_PURCHASES_ORDER_M_COMPANY]
GO
ALTER TABLE [dbo].[M_PURCHASES_ORDER_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_M_PURCHASES_ORDER_DETAIL_M_PURCHASES_ORDER] FOREIGN KEY([Purchases_Order_Id])
REFERENCES [dbo].[M_PURCHASES_ORDER] ([Purchases_Order_Id])
GO
ALTER TABLE [dbo].[M_PURCHASES_ORDER_DETAIL] CHECK CONSTRAINT [FK_M_PURCHASES_ORDER_DETAIL_M_PURCHASES_ORDER]
GO
USE [master]
GO
ALTER DATABASE [PurchasesOrder] SET  READ_WRITE 
GO
