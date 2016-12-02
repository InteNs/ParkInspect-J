CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Region] int NOT NULL,
	[Function] int NOT NULL,
	[Person_Id] int NOT NULL,
	[DateHired] date NOT NULL,
	[DateFired] date

	CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)
)
