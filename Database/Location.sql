CREATE TABLE [dbo].[Location]
(
	[StreetNumber] INT NOT NULL,
	[ZipCode] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Region] int

	CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED
	(
		StreetNumber,
		ZipCode,
		Guid
	)
)
