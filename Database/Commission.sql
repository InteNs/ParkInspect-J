CREATE TABLE [dbo].[Commission]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[EmployeeId] int NOT NULL,
	[EmployeeGuid] uniqueidentifier NOT NULL,
	[CustomerId] int NOT NULL,
	[CustomerGuid] uniqueidentifier NOT NULL,
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

	CONSTRAINT [FK_Commission_Customer] FOREIGN KEY (CustomerId, CustomerGuid) REFERENCES Customer (Id, Guid)
	CONSTRAINT [FK_Commission_Employee] FOREIGN KEY (EmployeeId, EmployeeGuid) REFERENCES Employee (Id, Guid)
)
