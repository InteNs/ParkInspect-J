CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Guid] uniqueidentifier NOT NULL PRIMARY KEY,
	[Person_Id] int NOT NULL
)
