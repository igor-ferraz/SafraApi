-- CREATE DATABASE Safra;
-- DROP DATABASE Safra;

USE Safra;

-- Account tables
CREATE TABLE Users (
	[ClientId]     CHAR(32) PRIMARY KEY,
	[Secret]       CHAR(36) NOT NULL,
	[Email]        VARCHAR(150) NOT NULL,
	[Password]     VARCHAR(200) NOT NULL,
	[Phone]        VARCHAR(11),
	[Name]         VARCHAR(200),
	[Active]       BIT NOT NULL DEFAULT 1,
	[CreationDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[AccountId]    CHAR(11) NOT NULL,
	[CurrentToken] VARCHAR(2000)
);

CREATE TABLE PaymentMethods (
	[Id]               SMALLINT PRIMARY KEY IDENTITY,
	[Name]             VARCHAR(100) NOT NULL,
	[Active]           BIT NOT NULL DEFAULT 1,
	[CreationDate]     DATETIME NOT NULL DEFAULT GETDATE(),
	[ChangeDate]       DATETIME,
	[AllowInstallment] BIT NOT NULL
);

CREATE TABLE Payments (
	[Id]                   INT PRIMARY KEY IDENTITY,
	[AccountId]            CHAR(11) NOT NULL,
	[PaymentMethodId]      SMALLINT NOT NULL,
	[NumberOfInstallments] SMALLINT NOT NULL,
	[Value]                DECIMAL(7,2) NOT NULL,
	[Processed]            BIT NOT NULL DEFAULT 0,
	[CreationDate]         DATETIME NOT NULL DEFAULT GETDATE(),
	[ProcessedDate]        DATETIME,
	FOREIGN KEY(PaymentMethodId) REFERENCES PaymentMethods(Id)
);

-- Store tables
CREATE TABLE Products (
	[Id]           INT PRIMARY KEY IDENTITY,
	[Name]         VARCHAR(100) NOT NULL,
	[Description]  VARCHAR(1000) NOT NULL,
	[Active]       BIT NOT NULL DEFAULT 1,
	[Price]        DECIMAL(7,2) NOT NULL,
	[CreationDate] DATETIME NOT NULL DEFAULT GETDATE(),
	[ChangeDate]   DATETIME,
	[AccountId]    CHAR(11) NOT NULL
);

CREATE TABLE Buyers (
	[Id]           INT PRIMARY KEY IDENTITY,
	[Name]         VARCHAR(200),
	[CPF]          VARCHAR(11),
	[Email]        VARCHAR(150),
	[Phone]        VARCHAR(11),
	[CreationDate] DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Sales (
	[Id]              UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	[PaymentMethodId] SMALLINT,
	[AccountId]       CHAR(11) NOT NULL,
	[AlreadyPaid]     BIT NOT NULL DEFAULT 0,
	[PaymentDate]     DATETIME,
	[CreationDate]    DATETIME NOT NULL DEFAULT GETDATE(),
	[BuyerId]         INT,
	FOREIGN KEY(PaymentMethodId) REFERENCES PaymentMethods(Id),
	FOREIGN KEY(BuyerId)         REFERENCES Buyers(Id)
);

CREATE TABLE SalesProducts (
	[ProductId] INT NOT NULL,
	[SaleId]    UNIQUEIDENTIFIER NOT NULL,
	[Quantity]  INT NOT NULL,
	[UnitPrice] DECIMAL(7,2) NOT NULL,
	PRIMARY KEY(ProductId, SaleId),
	FOREIGN KEY(ProductId) REFERENCES Products(Id),
	FOREIGN KEY(SaleId)    REFERENCES Sales(Id)
);