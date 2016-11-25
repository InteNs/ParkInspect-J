CREATE TABLE [dbo].[Region]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Guid] uniqueidentifier NOT NULL PRIMARY KEY,
	[RegionName] varchar(MAX) NOT NULL
)
