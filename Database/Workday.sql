CREATE TABLE [dbo].[Workday]
(
	[Id] INT NOT NULL, 
    [Employee_id] INT NOT NULL,
	[Guid] UniqueIdentifier NOT NULL,
	[StartTime] TIME NULL,
	[StopTime] TIME NULL

	CONSTRAINT [PK_Workday] PRIMARY KEY CLUSTERED
	(
		Id,
		Employee_id,
		Guid
	)
)