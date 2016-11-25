CREATE TABLE [dbo].[Answer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[Guid] uniqueidentifier NOT NULL PRIMARY KEY,
    [Value] VARCHAR(MAX) NOT NULL
)