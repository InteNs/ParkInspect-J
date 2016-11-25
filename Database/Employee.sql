CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Guid] uniqueidentifier NOT NULL PRIMARY KEY,
	[Region] int NOT NULL,
	[Function] int NOT NULL,
	[Person_Id] int NOT NULL,
	[DateHired] date NOT NULL,
	[DateFired] date
)
