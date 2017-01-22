CREATE TABLE [dbo].[Region]
(
	[Id] INT IDENTITY NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[RegionName] varchar(MAX) NOT NULL

	CONSTRAINT [PK_Region] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)
)
