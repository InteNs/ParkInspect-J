CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Name] varchar(MAX),
	[LocationId] int NOT NULL,
	[LocationGuid] uniqueidentifier NOT NULL,
	[PhoneNumber] int,
	[Email] varchar(20)

	CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)

	CONSTRAINT [FK_Person_Location] FOREIGN KEY (LocationId, LocationGuid) REFERENCES "Location" (Id, Guid)
)
