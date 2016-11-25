CREATE TABLE [dbo].[Workday]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Employee_id] INT NOT NULL PRIMARY KEY,
	[Guid] UniqueIdentifier NOT NULL PRIMARY KEY,
	[StartTime] TIMESTAMP NULL,
	[StopTime] TIMESTAMP NULL
)