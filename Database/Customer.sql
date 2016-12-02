CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[PersonId] int NOT NULL

	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)

	CONSTRAINT [FK_CustomerPerson] FOREIGN KEY (PersonId) REFERENCES Person (Id)
)
