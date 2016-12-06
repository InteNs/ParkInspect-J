CREATE TABLE [dbo].[Workday]
(
	[Id] INT NOT NULL, 
    [EmployeeId] INT NOT NULL,
	[EmployeeGuid] uniqueidentifier NOT NULL,
	[Guid] UniqueIdentifier NOT NULL,
	[StartTime] TIME NULL,
	[StopTime] TIME NULL

	CONSTRAINT [PK_Workday] PRIMARY KEY CLUSTERED
	(
		Id,
		EmployeeId,
		Guid
	)

	CONSTRAINT [FK_Workday_Employee] FOREIGN KEY (EmployeeId, EmployeeGuid) REFERENCES Employee (Id, Guid)
)