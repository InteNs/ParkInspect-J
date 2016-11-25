CREATE TABLE [dbo].[Location]
(
	[StreetNumber] INT NOT NULL PRIMARY KEY,
	[ZipCode] INT NOT NULL PRIMARY KEY,
	[Guid] uniqueidentifier NOT NULL PRIMARY KEY,
	[Region] int
)
