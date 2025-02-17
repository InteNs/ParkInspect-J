﻿CREATE TABLE [dbo].[Commission]
(
	[Id] INT IDENTITY NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[EmployeeId] int NOT NULL,
	[EmployeeGuid] uniqueidentifier NOT NULL,
	[CustomerId] int NOT NULL,
	[CustomerGuid] uniqueidentifier NOT NULL,
	[LocationId] INT NOT NULL,
	[LocationGuid] uniqueidentifier,
	[DateCreated] date NOT NULL,
	[DateCompleted] date,
	[Description] varchar(MAX),
	[Status] varchar(MAX) DEFAULT 'Nieuw'

	CONSTRAINT [PK_Commission] PRIMARY KEY CLUSTERED 
	(
		Id,
		Guid
	)

	CONSTRAINT [FK_Commission_Customer] FOREIGN KEY (CustomerId, CustomerGuid) REFERENCES Customer (Id, Guid)
	CONSTRAINT [FK_Commission_Employee] FOREIGN KEY (EmployeeId, EmployeeGuid) REFERENCES Employee (Id, Guid)
	CONSTRAINT [FK_Commission_Location] FOREIGN KEY (LocationId, LocationGuid) REFERENCES "Location" (Id, Guid)
)
