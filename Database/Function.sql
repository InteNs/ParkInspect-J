CREATE TABLE [dbo].[Function]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Name] varchar(MAX) NOT NULL

	CONSTRAINT [PK_Function] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)
)
