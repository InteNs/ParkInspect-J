CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Person_Id] int NOT NULL

	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)
)
