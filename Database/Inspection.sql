CREATE TABLE [dbo].[Inspection]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Guid] uniqueidentifier NOT NULL PRIMARY KEY,
	[Assignment_Id] int NOT NULL,
	[DateTimeStart] datetime NOT NULL,
	[DateTimeEnd] datetime,
	[DateCancelled] date
)
