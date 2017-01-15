CREATE TABLE [dbo].[Person]
(
	[Id] INT IDENTITY NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Name] varchar(MAX),
	[LocationId] int NOT NULL,
	[LocationGuid] uniqueidentifier NOT NULL,
	[PhoneNumber] VARCHAR(20),
	[Email] varchar(MAX)

	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)

	CONSTRAINT [FK_Person_Location] FOREIGN KEY (LocationId, LocationGuid) REFERENCES "Location" (Id, Guid)
)
