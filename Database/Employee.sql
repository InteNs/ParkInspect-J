CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Region] int NOT NULL,
	[Function] int NOT NULL,
	[PersonId] int NOT NULL,
	[DateHired] date NOT NULL,
	[DateFired] date

	CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED
	(
		Id,
		Guid
	)

	CONSTRAINT [FK_EmployeePerson] FOREIGN KEY (PersonId) REFERENCES Person (Id)
)
