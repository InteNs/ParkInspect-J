CREATE TABLE [dbo].[Commission]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Guid] uniqueidentifier NOT NULL PRIMARY KEY,
	[Employee_Id] int NOT NULL,
	[Customer_Id] int NOT NULL,
	[ZipCode] varchar(6),
	[StreetNumber] varchar(5),
	[DateCreated] date NOT NULL,
	[DateCompleted] date,
	[Description] varchar(MAX)
)
