CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Name] varchar(MAX),
	[ZipCode] varchar(6),
	[StreetNumber] varchar(5),
	[PhoneNumber] int,
	[Email] varchar(20)

	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)
)
