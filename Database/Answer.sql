CREATE TABLE [dbo].[Answer]
(
	[Id] INT NOT NULL IDENTITY, 
	[Guid] uniqueidentifier NOT NULL,
    [Value] VARCHAR(MAX) NOT NULL,

	CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
	(
		Id
	)
)