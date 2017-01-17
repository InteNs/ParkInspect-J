CREATE TABLE [dbo].[Employee]
(
	[Id] INT IDENTITY NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Password] VARCHAR(MAX),
	[FunctionId] int NOT NULL,
	[FunctionGuid] uniqueidentifier NOT NULL,
	[PersonId] int NOT NULL,
	[PersonGuid] uniqueidentifier NOT NULL,
	[DateHired] date NOT NULL,
	[DateFired] date

	CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)
	CONSTRAINT [FK_Employee_Person] FOREIGN KEY (PersonId, PersonGuid) REFERENCES Person (Id, Guid)
	CONSTRAINT [FK_Employee_Function] FOREIGN KEY (FunctionId, FunctionGuid) REFERENCES "Function" (Id, Guid) 
)
