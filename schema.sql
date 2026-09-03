-- Sales — a small SQL Server 2022 schema to scaffold from.
-- Run this against a database named Sales before scaffolding.

CREATE TABLE dbo.Customers
(
    CustomerId  INT IDENTITY(1,1) NOT NULL,
    Name        NVARCHAR(120)     NOT NULL,
    Email       NVARCHAR(200)     NULL,
    CreatedAt   DATETIME2         NOT NULL CONSTRAINT DF_Customers_CreatedAt DEFAULT SYSUTCDATETIME(),
    CONSTRAINT PK_Customers PRIMARY KEY (CustomerId)
);
GO

CREATE TABLE dbo.Orders
(
    OrderId     INT IDENTITY(1,1) NOT NULL,
    CustomerId  INT               NOT NULL,
    OrderDate   DATETIME2         NOT NULL CONSTRAINT DF_Orders_OrderDate DEFAULT SYSUTCDATETIME(),
    Total       DECIMAL(10,2)     NOT NULL,
    CONSTRAINT PK_Orders PRIMARY KEY (OrderId),
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerId)
        REFERENCES dbo.Customers (CustomerId)
);
GO

INSERT dbo.Customers (Name, Email) VALUES
    (N'Ada Lovelace',  N'ada@example.com'),
    (N'Alan Turing',   N'alan@example.com');
GO

INSERT dbo.Orders (CustomerId, Total) VALUES
    (1, 150.00),
    (1,  42.50),
    (2, 320.75);
GO
