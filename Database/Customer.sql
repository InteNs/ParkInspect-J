CREATE TABLE [dbo].[Customer]
(
	[Id] INT IDENTITY NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[PersonId] int NOT NULL,
	[PersonGuid] uniqueidentifier NOT NULL

	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)

	CONSTRAINT [FK_Customer_Person] FOREIGN KEY (PersonId, PersonGuid) REFERENCES Person (Id, Guid)
)
