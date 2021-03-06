USE [master]
GO

USE [PurchasesOrder]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCompany]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[DeleteItemName]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[DeletePackagingDetails]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DeletePackagingDetails]
(
	@Packaging_Id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [M_Packaging_Detail] WHERE (([Packaging_Id] = @Packaging_Id))


GO
/****** Object:  StoredProcedure [dbo].[DeletePackagingDetails_By_PurchasesDetailId ]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePackagingDetails_By_PurchasesDetailId ]
(
	@Purchase_Order_Detail_Id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [M_Packaging_Detail] WHERE ((Purchase_Order_Detail_Id = @Purchase_Order_Detail_Id))


GO
/****** Object:  StoredProcedure [dbo].[DeletePurchasesOrder]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[DeletePurchasesOrderDetail]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[DeletePurchasesOrderDetail_ById]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetBalanceSheet]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetCompletePurchasesOrder]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[GetPurchasesOrderByBillId]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPurchasesOrderByBillId]
(
	@Bill_Id int
)
AS
	SET NOCOUNT ON;
	SELECT M_PURCHASES_ORDER.Purchases_Order_Id
		  ,M_PURCHASES_ORDER.Company_id
		  ,M_PURCHASES_ORDER.Date
		  ,M_PURCHASES_ORDER.Purchases_Order_No		
		  ,M_PURCHASES_ORDER.Tax_Percentage	
			,M_PURCHASES_ORDER.Other_Amount 
			,M_PURCHASES_ORDER.Requisitioner 
			,M_PURCHASES_ORDER.Credit_Term 
			,M_PURCHASES_ORDER.Shipping_Term 
			,M_PURCHASES_ORDER.Comments	
      FROM M_PURCHASES_ORDER INNER JOIN 
		   M_PURCHASES_ORDER_DETAIL ON M_PURCHASES_ORDER.Purchases_Order_Id = M_PURCHASES_ORDER_DETAIL.Purchases_Order_Id INNER JOIN
		   B_BILL_ITEM ON M_PURCHASES_ORDER_DETAIL.Purchase_Order_Detail_Id = B_BILL_ITEM.Purchase_Order_Detail_Id		   
	 Where Bill_Id = @Bill_Id
   ORDER BY Purchases_Order_No





GO
/****** Object:  StoredProcedure [dbo].[GetPurchasesOrderByCompId]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPurchasesOrderByCompId]
(
	@Company_id int
)
AS
	SET NOCOUNT ON;
	SELECT   Purchases_Order_Id
		, Company_id
		, Date
		,Tax_Percentage
		,Other_Amount 
		,Requisitioner 
		,Credit_Term 
		,Shipping_Term 
		, Purchases_Order_No
		,Comments
	 FROM M_PURCHASES_ORDER
	Where Company_id = @Company_id
   ORDER BY Date desc


GO
/****** Object:  StoredProcedure [dbo].[GetPurchasesOrderDetailByOrderId]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPurchasesOrderDetailByOrderId]
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
	, Item_UNit
	, Total_Amount
 FROM M_PURCHASES_ORDER_DETAIL Inner join
 Item I on M_PURCHASES_ORDER_DETAIL.Item_Id = I.Item_Id 
WHERE Purchases_Order_Id = @Purchases_Order_Id
ORDER BY I.Item_Name






GO
/****** Object:  StoredProcedure [dbo].[GetReportBody]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetReportBody]
(
	@Company_id int,
	@Purchases_Order_Id int
)
AS
	SET NOCOUNT ON;
SELECT POD.Purchase_Order_Detail_Id
	, Purchases_Order_Id
	, I.Item_Name
	, I.Item_Id
	, Item_Quantity
	, Item_Rate
	, Item_Unit
	, Total_Amount
	, Packaging_Description
 FROM M_PURCHASES_ORDER_DETAIL POD Inner join
 Item I on POD.Item_Id = I.Item_Id left join 
 M_PACKAGING_DETAIL PD on PD.Purchase_Order_Detail_Id = POD.Purchase_Order_Detail_Id
WHERE Purchases_Order_Id = @Purchases_Order_Id
ORDER BY I.Item_Name






GO
/****** Object:  StoredProcedure [dbo].[GetReportHeader]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetReportHeader]
(
    @Company_id int,
	@Purchases_Order_Id int
)
AS
	SET NOCOUNT ON;
SELECT [tin_no]
      ,[company_name]
	  ,Purchases_Order_No
	  ,CONVERT(VARCHAR(10), PO.Date, 103)  as [Purchases_Order_date]
	  ,Tax_Percentage
	  ,Other_Amount 
	  ,Requisitioner 
	  ,Credit_Term 
	  ,Shipping_Term
      ,[address1]
      ,[pan_no]
      ,[city]
      ,[state]
      ,[pincode]
      ,[email]
      ,[phone]
      ,[Fax_No]      
      ,[delivery_at]
	  ,Comments
  FROM M_COMPANY C Inner join 
       M_PURCHASES_ORDER  PO on c.Company_id = PO.Company_id
	   and Purchases_Order_Id = @Purchases_Order_Id
  where C.Company_id = @Company_id




GO
/****** Object:  StoredProcedure [dbo].[InsertCompany]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[InsertItemName]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[InsertPackagingDetail]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[InsertPackagingDetail]
(
	@Purchase_Order_Detail_Id int,
	@Packaging_Description nvarchar(500)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [M_Packaging_Detail](  
						 [Purchase_Order_Detail_Id]
						, [Packaging_Description]
																					
					  )
			 VALUES 
					( @Purchase_Order_Detail_Id
					, @Packaging_Description
					
					 );
						
Declare @Packaging_Id int
set @Packaging_Id = SCOPE_IDENTITY()
select  @Packaging_Id


GO
/****** Object:  StoredProcedure [dbo].[InsertPurchasesOrder]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPurchasesOrder]
(
	@Company_id int,
	@Date datetime,
	@Purchases_Order_No VARCHAR(100),
	@Tax_Percentage decimal(10,2),
	@Other_Amount  decimal (10,2) ,
	@Requisitioner  VARCHAR(500), 
	@Credit_Term   VARCHAR(500),
	@Shipping_Term   VARCHAR(500),
	@comments VARCHAR(500)
)
AS
	SET NOCOUNT OFF;

	declare @PurchasesNo_Count int

	select @PurchasesNo_Count = isnull( max(PurchasesNo_Count),0) +1 
	from M_PURCHASES_ORDER

INSERT INTO [M_PURCHASES_ORDER] 
			( [Company_id]
			, [Date]
			, [Purchases_Order_No]
			, PurchasesNo_Count
			, Tax_Percentage
			, Other_Amount 
			, Requisitioner 
			, Credit_Term 
			, Shipping_Term 
			, comments
			) 
	VALUES (  @Company_id
			, @Date
			, @PurchasesNo_Count
			, @PurchasesNo_Count
			, @Tax_Percentage
			, @Other_Amount 
			, @Requisitioner 
			, @Credit_Term 
			, @Shipping_Term 
			, @comments
			);
	
SELECT (SCOPE_IDENTITY())



SET ANSI_NULLS ON





GO
/****** Object:  StoredProcedure [dbo].[InsertPurchasesOrderDetail]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertPurchasesOrderDetail]
(
	@Purchases_Order_Id int,
	@Item_Name nvarchar(100),
	@Item_Id int,
	@Item_Quantity float,
	@Item_Rate float,
	@Item_Unit	nvarchar(100)
)
AS
	SET NOCOUNT OFF;
   INSERT INTO [M_PURCHASES_ORDER_DETAIL]
			 ( [Purchases_Order_Id]
			 , [Item_Name]
			 , Item_Id
			 , [Item_Quantity]
			 , [Item_Rate]
			 , [Item_Unit]
			 , [Total_Amount]
			 )
	  VALUES 
			 ( @Purchases_Order_Id
			 , @Item_Name
			 , @Item_Id 
			 , @Item_Quantity
			 , @Item_Rate
			 , @Item_Unit
			 , @Item_Quantity * @Item_Rate
			 );
	
SELECT ( SCOPE_IDENTITY())






GO
/****** Object:  StoredProcedure [dbo].[PurchasesReport]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SelectCompanyAll]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SelectCompanyById]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SelectItemNameAll]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SelectItemNameById]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SelectPackagingDetail_By_PurchasesDetailId]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SelectPackagingDetail_By_PurchasesDetailId]
(
	@Purchase_Order_Detail_Id int
)

AS
	SET NOCOUNT ON;
SELECT        Packaging_Id 
            , Purchase_Order_Detail_Id 
			, Packaging_Description
FROM M_PACKAGING_DETAIL
where ( Purchase_Order_Detail_Id  = @Purchase_Order_Detail_Id  )
ORDER BY Packaging_Description


GO
/****** Object:  StoredProcedure [dbo].[SelectPurchasesOrderById]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPurchasesOrderById]
(
	@Purchases_Order_Id int
)
AS
	SET NOCOUNT ON;
	SELECT Purchases_Order_Id
		   , Company_id
		   , Date
		   , Purchases_Order_No
		   ,Tax_Percentage
		    ,Other_Amount 
		 ,Requisitioner 
		 ,Credit_Term 
		 ,Shipping_Term 
		 ,comments
		FROM M_PURCHASES_ORDER
	Where Purchases_Order_Id = @Purchases_Order_Id


GO
/****** Object:  StoredProcedure [dbo].[SelectPurchasesOrderDetailAll]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPurchasesOrderDetailAll]
AS
	SET NOCOUNT ON;
SELECT Purchase_Order_Detail_Id
	, Purchases_Order_Id
	, I.Item_Name
	,I.Item_Id
	, Item_Quantity
	, Item_Rate
	,Item_Unit
	, Total_Amount
FROM M_PURCHASES_ORDER_DETAIL inner join
     Item I on M_PURCHASES_ORDER_DETAIL.Item_Id = I.Item_Id 
oRDER BY I.Item_Name






GO
/****** Object:  StoredProcedure [dbo].[UpdateCompany]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateItemName]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  StoredProcedure [dbo].[UpdatePackagingDetails]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[UpdatePackagingDetails]
(
	@Packaging_Description nvarchar(500),
    @Packaging_id int

	)
AS
	SET NOCOUNT OFF;
UPDATE [M_PACKAGING_DETAIL] 
  SET  [Packaging_Description] = @Packaging_Description
			 			
 WHERE [Packaging_id] = @Packaging_id ;


GO
/****** Object:  StoredProcedure [dbo].[UpdatePurchasesOrder]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePurchasesOrder]
(
	@Date datetime,
	@Purchases_Order_No VARCHAR(100),
	@Purchases_Order_Id int,
	@Tax_Percentage decimal (10,2),
	@Other_Amount  decimal (10,2) ,
	@Requisitioner  VARCHAR(500), 
	@Credit_Term   VARCHAR(500),
	@Shipping_Term   VARCHAR(500),
	@Comments VARCHAR(500)
)
AS
	SET NOCOUNT OFF;
UPDATE [M_PURCHASES_ORDER]
   SET [Date] = @Date
     , [Purchases_Order_No] = @Purchases_Order_No
		 ,Tax_Percentage = @Tax_Percentage 
		 ,Other_Amount = @Other_Amount 
		 ,Requisitioner = @Requisitioner 
		 ,Credit_Term = @Credit_Term 
		 ,Shipping_Term = @Shipping_Term 
		 ,Comments = @Comments
 WHERE ([Purchases_Order_Id] = @Purchases_Order_Id)



GO
/****** Object:  StoredProcedure [dbo].[UpdatePurchasesOrderDetail]    Script Date: 10/4/2016 12:41:45 AM ******/
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
	@Item_Unit nvarchar(100),
	@Purchase_Order_Detail_Id int
)
AS
	SET NOCOUNT OFF;
UPDATE [M_PURCHASES_ORDER_DETAIL]
   SET [Item_Name] = @Item_Name
     , Item_Id = @Item_Id
	 , [Item_Quantity] = @Item_Quantity
	 , [Item_Rate] = @Item_Rate
	 , Item_Unit = @Item_Unit
	 , [Total_Amount] = @Item_Quantity*@Item_Rate
WHERE ([Purchase_Order_Detail_Id] = @Purchase_Order_Detail_Id);







GO
/****** Object:  Table [dbo].[Item]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  Table [dbo].[M_COMPANY]    Script Date: 10/4/2016 12:41:45 AM ******/
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
/****** Object:  Table [dbo].[M_PACKAGING_DETAIL]    Script Date: 10/4/2016 12:41:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_PACKAGING_DETAIL](
	[Packaging_Id] [int] IDENTITY(1,1) NOT NULL,
	[Purchase_Order_Detail_Id] [int] NULL,
	[Packaging_Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_M_PACKAGING_DETAIL] PRIMARY KEY CLUSTERED 
(
	[Packaging_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[M_PURCHASES_ORDER]    Script Date: 10/4/2016 12:41:45 AM ******/
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
	[Tax_Percentage] [decimal](10, 2) NULL,
	[PurchasesNo_Count] [int] NOT NULL,
	[Other_Amount] [decimal](10, 2) NULL,
	[Requisitioner] [varchar](500) NULL,
	[Credit_Term] [varchar](500) NULL,
	[Shipping_Term] [varchar](500) NULL,
	[Comments] [varchar](500) NULL,
 CONSTRAINT [PK_M_PURCHASES_ORDER] PRIMARY KEY CLUSTERED 
(
	[Purchases_Order_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[M_PURCHASES_ORDER_DETAIL]    Script Date: 10/4/2016 12:41:45 AM ******/
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
	[Item_Unit] [nvarchar](100) NULL,
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
SET IDENTITY_INSERT [dbo].[Item] ON 

GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (5, N'Huber Web Export Magenta  Ink')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (6, N'Huber Web Export Cyan  Ink')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (7, N'Huber Web Export Yellow  Ink')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (8, N'Huber Web Export Black  Ink')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (9, N'Fevicol  SA423')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (10, N'Wire Local 23 No')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (11, N'Wire Local 24 No')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (12, N'Bott. In Blue Wash ( 30Ltr )')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (13, N'Insta Kleen HD')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (14, N'Rubber Blanket  ( 1030mm X 920mm ) ')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (15, N'Fevicol CPW')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (16, N'Cello Tape Panfix')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (17, N'Fount C-407')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (18, N'Linto Fix')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (19, N'Micro Express Wash 209')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (20, N'Fount + Alcon HS 21')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (21, N'I Tack Adhesive Book Binding HB-44 Plus')
GO
INSERT [dbo].[Item] ([Item_Id], [Item_Name]) VALUES (22, N'Strapping Roll')
GO
SET IDENTITY_INSERT [dbo].[Item] OFF
GO
SET IDENTITY_INSERT [dbo].[M_COMPANY] ON 

GO
INSERT [dbo].[M_COMPANY] ([Company_id], [tin_no], [company_name], [address1], [pan_no], [city], [state], [pincode], [email], [phone], [Fax_No], [is_active], [future1], [future2], [delivery_at]) VALUES (1, N'', N'R.P. printer', N'', N'', N'', N'', N'', N'', N'', N'', 0, NULL, NULL, N'')
GO
INSERT [dbo].[M_COMPANY] ([Company_id], [tin_no], [company_name], [address1], [pan_no], [city], [state], [pincode], [email], [phone], [Fax_No], [is_active], [future1], [future2], [delivery_at]) VALUES (2, N'', N'Rp printer', N'', N'', N'', N'', N'', N'', N'', N'', 1, NULL, NULL, N'')
GO
SET IDENTITY_INSERT [dbo].[M_COMPANY] OFF
GO
SET IDENTITY_INSERT [dbo].[M_PACKAGING_DETAIL] ON 

GO
INSERT [dbo].[M_PACKAGING_DETAIL] ([Packaging_Id], [Purchase_Order_Detail_Id], [Packaging_Description]) VALUES (2, 1, N'bb')
GO
INSERT [dbo].[M_PACKAGING_DETAIL] ([Packaging_Id], [Purchase_Order_Detail_Id], [Packaging_Description]) VALUES (4, 1, N'dddd')
GO
INSERT [dbo].[M_PACKAGING_DETAIL] ([Packaging_Id], [Purchase_Order_Detail_Id], [Packaging_Description]) VALUES (5, 1, N'eeeee')
GO
INSERT [dbo].[M_PACKAGING_DETAIL] ([Packaging_Id], [Purchase_Order_Detail_Id], [Packaging_Description]) VALUES (9, 3, N'd fgdfgdfgrgdf')
GO
SET IDENTITY_INSERT [dbo].[M_PACKAGING_DETAIL] OFF
GO
SET IDENTITY_INSERT [dbo].[M_PURCHASES_ORDER] ON 

GO
INSERT [dbo].[M_PURCHASES_ORDER] ([Purchases_Order_Id], [Company_id], [Date], [Purchases_Order_No], [Tax_Percentage], [PurchasesNo_Count], [Other_Amount], [Requisitioner], [Credit_Term], [Shipping_Term], [Comments]) VALUES (1, 2, CAST(0x0000A69301229EEC AS DateTime), N'1', CAST(2.00 AS Decimal(10, 2)), 1, CAST(25.00 AS Decimal(10, 2)), N'rrrrrrr', N'ce', N'shi', N'tttttttttttttttt')
GO
SET IDENTITY_INSERT [dbo].[M_PURCHASES_ORDER] OFF
GO
SET IDENTITY_INSERT [dbo].[M_PURCHASES_ORDER_DETAIL] ON 

GO
INSERT [dbo].[M_PURCHASES_ORDER_DETAIL] ([Purchase_Order_Detail_Id], [Purchases_Order_Id], [Item_Name], [Item_Quantity], [Item_Rate], [Item_Unit], [Total_Amount], [future1], [future2], [Item_Id]) VALUES (1, 1, NULL, 45, 34, N'kg', CAST(1530.00 AS Decimal(10, 2)), NULL, NULL, 17)
GO
INSERT [dbo].[M_PURCHASES_ORDER_DETAIL] ([Purchase_Order_Detail_Id], [Purchases_Order_Id], [Item_Name], [Item_Quantity], [Item_Rate], [Item_Unit], [Total_Amount], [future1], [future2], [Item_Id]) VALUES (3, 1, NULL, 4, 56, N'sdklfnkd jkadjn', CAST(224.00 AS Decimal(10, 2)), NULL, NULL, 6)
GO
INSERT [dbo].[M_PURCHASES_ORDER_DETAIL] ([Purchase_Order_Detail_Id], [Purchases_Order_Id], [Item_Name], [Item_Quantity], [Item_Rate], [Item_Unit], [Total_Amount], [future1], [future2], [Item_Id]) VALUES (4, 1, NULL, 6, 87, N'bhtyhyh', CAST(522.00 AS Decimal(10, 2)), NULL, NULL, 6)
GO
SET IDENTITY_INSERT [dbo].[M_PURCHASES_ORDER_DETAIL] OFF
GO
ALTER TABLE [dbo].[M_PURCHASES_ORDER] ADD  CONSTRAINT [DF_M_PURCHASES_ORDER_Other_Amount]  DEFAULT ((0.00)) FOR [Other_Amount]
GO
ALTER TABLE [dbo].[M_PACKAGING_DETAIL]  WITH CHECK ADD  CONSTRAINT [FK_M_PACKAGING_DETAIL_M_PURCHASES_ORDER_DETAIL] FOREIGN KEY([Purchase_Order_Detail_Id])
REFERENCES [dbo].[M_PURCHASES_ORDER_DETAIL] ([Purchase_Order_Detail_Id])
GO
ALTER TABLE [dbo].[M_PACKAGING_DETAIL] CHECK CONSTRAINT [FK_M_PACKAGING_DETAIL_M_PURCHASES_ORDER_DETAIL]
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
