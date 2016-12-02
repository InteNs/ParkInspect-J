CREATE TABLE [dbo].[Commission]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[EmployeeId] int NOT NULL,
	[CustomerId] int NOT NULL,
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

	CONSTRAINT [FK_CustPerson] FOREIGN KEY (CustomerId) REFERENCES Person (Id)
	CONSTRAINT [FK_EmplPerson] FOREIGN KEY (EmployeeId) REFERENCES Person (Id)
)
