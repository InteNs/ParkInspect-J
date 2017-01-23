CREATE TABLE [dbo].[Inspection]
(
	[Id] INT IDENTITY NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[CommissionId] int NOT NULL,
	[CommissionGuid] uniqueidentifier NOT NULL,
	[DateTimeStart] datetime NOT NULL,
	[DateTimeEnd] datetime,
	[DateCancelled] date

	CONSTRAINT [PK_Inspection] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)

	CONSTRAINT [FK_Inspection_Commission] FOREIGN KEY (CommissionId, CommissionGuid) REFERENCES Commission (Id, Guid)
)
