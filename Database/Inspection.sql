CREATE TABLE [dbo].[Inspection]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[CommissionId] int NOT NULL,
	[DateTimeStart] datetime NOT NULL,
	[DateTimeEnd] datetime,
	[DateCancelled] date

	CONSTRAINT [PK_Inspection] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)
)
