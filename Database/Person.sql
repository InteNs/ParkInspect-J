CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Guid] uniqueidentifier NOT NULL PRIMARY KEY,
	[Name] varchar(MAX),
	[ZipCode] varchar(6),
	[StreetNumber] varchar(5),
	[PhoneNumber] int,
	[Email] varchar(20)
)
