CREATE DATABASE DB_DW;
GO
USE DB_DW;
GO
CREATE TABLE CLIENT (
	id_client int IDENTITY(1,1) PRIMARY KEY,
	first_name nvarchar(50),
	last_name nvarchar(50),
	[address] nvarchar(50),
	dob datetime,  
	phone nvarchar(50),
);
CREATE TABLE SALLER (
	id_saller int IDENTITY(1,1) PRIMARY KEY,
	first_name nvarchar(50),
	last_name nvarchar(50),
	phone nvarchar(50)
);

CREATE TABLE CATEGORY(
	id_category int IDENTITY(1,1) PRIMARY KEY,
	[name] nvarchar(50),
	[description] nvarchar(50)
);

CREATE TABLE PRODUCT (
	id_product int IDENTITY(1,1) PRIMARY KEY,
	[name] nvarchar(50),
	price decimal,
	stock int,
	id_category int FOREIGN KEY REFERENCES CATEGORY(id_category)
);

CREATE TABLE INVOICE (
	id_invoice int IDENTITY(1,1) PRIMARY KEY,
	id_client int FOREIGN KEY REFERENCES CLIENT(id_client),
	id_saller int FOREIGN KEY REFERENCES SALLER(id_saller),
	[date] DateTime
);

CREATE TABLE DETAIL_INVOICE (
	id_detail int,
	id_invoice int FOREIGN KEY REFERENCES INVOICE(id_invoice),
	amount int,
	id_product int FOREIGN KEY REFERENCES PRODUCT(id_product),
	CONSTRAINT id_detail PRIMARY KEY (id_detail, id_invoice));

