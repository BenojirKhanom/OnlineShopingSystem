use master ;
go
create database MVC_project;
go
use MVC_project;
go
CREATE TABLE Category (	  CategoryId			INT				IDENTITY		PRIMARY KEY,
						  CategoryName			VARCHAR(50)		NOT NULL);

go
INSERT INTO Category		VALUES ('Saree'), ('Three Pices'), ('Lehenga'),('Gawn'), ('Showl'), ('Gharara');

go
CREATE TABLE Product (	  ProductId			INT				IDENTITY		PRIMARY KEY,
						  ProductName		VARCHAR(50)		NOT NULL,
						  CategoryId			int             REFERENCES Category(CategoryId) ON DELETE NO ACTION,
						  price				VARCHAR(MAX),
						  ImageFile			VARCHAR(100));

go
INSERT INTO Product		VALUES		('Katan', 1,  '10,000', '~/Images/Saree.jpg'),
									('Lone', 2, '2,000', '~/Images/Pices.jpg'),
									('Zardosi', 3, '40,000', '~/Images/Lehenga.Jpg'),
									('Tail Cut', 4, '30,000', '~/Images/Gawn.Jpg'),
									('Kashmeeri', 5,'2,000', '~/Images/Showl.jpg'),
									('Sharara', 6, '5,000', '~/Images/Gharara.jpg');


	 go
 CREATE TABLE Customer (  CustomerId			INT				IDENTITY		PRIMARY KEY,
						  CustomerName			VARCHAR(50)			NOT NULL,
						  
						  Address				VARCHAR(MAX),
						  Number				VARCHAR(50)	);

go
INSERT INTO Customer		VALUES		('Nipa',   'Baridhara', '01628969664'),
									('Nilay',  'Keranigonj', '01628969665'),
									('Kakon',  'Laxmibazar', '01628969666'),
									('Anni',  'Uttora', '01628969667'),
									('Faria', 'Wari', '01628969668'),
									('Mim',  'PanGawn', '01628969669');


	 go
CREATE TABLE DeliveryBoy (	      DeliveryBoyId			INT				IDENTITY		PRIMARY KEY,
						          DeliveryBoyName			VARCHAR(50)		NOT NULL);

go
INSERT INTO DeliveryBoy		VALUES ('Robiul'), ('Kawsar'), ('Akram'),('Alauddin'), ('Jafor'), ('Zulhas');

go
CREATE TABLE ShippingInfo (	   ShippingId			INT				IDENTITY		PRIMARY KEY,
							   DeliveryBoyId	    int             REFERENCES   DeliveryBoy(DeliveryBoyId) ON DELETE cascade ON update cascade ,
							   ShippingCost  	    VARCHAR(50)		NOT NULL,
						       ShippingDate		    VARCHAR(50)		NOT NULL
						      
						       
						  );

go
INSERT INTO ShippingInfo		VALUES		( 1, '120', '2020-02-03'),
											(2,  '150', '2020-02-04'),
											( 3, '60', '2020-02-05'),
											( 4, '80', '2020-02-06'),
											( 5, '80', '2020-02-07'),
											( 6, '120', '2020-02-08');


	 go
 CREATE TABLE Orders (    OrderId			INT				IDENTITY		PRIMARY KEY,
						  Orderdate			VARCHAR(50)			NOT NULL,
						  CustomerId		        int             REFERENCES Customer( CustomerId	)ON DELETE NO ACTION,
						  ShippingId		        int             REFERENCES ShippingInfo( ShippingId	)ON DELETE NO ACTION,	);

go
INSERT INTO Orders		VALUES	('2020-02-01', 1,  1),
									('2020-02-02', 2, 2),
									('2020-02-03', 3, 3),
									('2020-02-04', 4, 4),
									('2020-02-05', 5, 5),
									('2020-02-06', 6, 6);

go
Create Table Employee
(
	EmpID int Identity Not Null,
	[Name] Nvarchar(50),
	Age int,
	Country Nvarchar(30),
	Salary Decimal,
	Constraint PK_Employee Primary Key (EmpID)
)

GO
Insert Into Employee Values('Mohammod Akash',28,'Bangladesh',25000)
Insert Into Employee Values('Nibir Hossin',27,'England',30000)
Insert Into Employee Values('zabir Hossain',28,'Bangladesh',20000)
GO
CREATE TABLE OrderDtls (  OrderDtlsId			INT				IDENTITY		PRIMARY KEY,
						  
						  OrderId		        int             REFERENCES Orders( OrderId	)ON DELETE NO ACTION,
						  ProductId		        int             REFERENCES Product( ProductId	)ON DELETE NO ACTION ,	
						  EmpID		        int             REFERENCES Employee( EmpID	)ON DELETE NO ACTION ,	

						  Quentity					VARCHAR(50)				NOT NULL,
						  TotalCost					VARCHAR(50)					NOT NULL);

go
INSERT INTO OrderDtls		VALUES	( 1, 1,1,'2','20,000'),
									( 2, 2,1,'2','4,000'),
									( 3, 3,2,'2','80,000'),
									( 4, 4,2,'2','60,000'),
									( 5, 5,3,'2','4,000'),
									( 6, 6,3,'2','10,000');
	 go
CREATE TABLE CustomerReview (  ReviewId			INT				IDENTITY		PRIMARY KEY,
						       CustomerId	    int             REFERENCES Customer( CustomerId	)ON DELETE NO ACTION,
						       Opinion		    VARCHAR(50)			NOT NULL,
						       ImageFile		VARCHAR(100)	);

go
INSERT INTO CustomerReview		VALUES	(1,  'Good', '~/Images/1.jpg'),
									(2,  'Good', '~/Images/2.jpg'),
									(3,  'Excellent', '~/Images/3.Jpg'),
									(4,  'Excellent', '~/Images/4.Jpg'),
									(5,'satisfied', '~/Images/5.jpg'),
									(6,  'satisfied', '~/Images/6.jpg');
go





	 go

	 select * from Category;
	 select * from Product;
	 select * from Customer;
	 select * from DeliveryBoy;
	 select * from ShippingInfo;
	 select * from Orders;
	 select * from OrderDtls;
	 select * from CustomerReview;
	 Select * from Employee
	 go
