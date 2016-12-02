CREATE TABLE [dbo].[Commission]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Employee_Id] int NOT NULL,
	[Customer_Id] int NOT NULL,
	[ZipCode] varchar(6),
	[StreetNumber] varchar(5),
	[DateCreated] date NOT NULL,
	[DateCompleted] date,
	[Description] varchar(MAX)

	CONSTRAINT [PK_Commission] PRIMARY KEY CLUSTERED 
	(
		Id,
		Guid
	)
)
