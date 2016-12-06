CREATE TABLE [dbo].[Location]
(
	[StreetNumber] INT NOT NULL,
	[ZipCode] varchar(6) NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[RegionId] int NOT NULL,
	[RegionGuid] uniqueidentifier NOT NULL

	CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED
	(
		ZipCode,
		StreetNumber,
		Guid
	)

	CONSTRAINT [FK_Location_Region] FOREIGN KEY (RegionId, RegionGuid) REFERENCES Region (Id, Guid)
)
