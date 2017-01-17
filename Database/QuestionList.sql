CREATE TABLE [dbo].[QuestionList]
(
	[Id] INT IDENTITY NOT NULL , 
	[Guid] uniqueidentifier NOT NULL,
    [Description] VARCHAR(MAX) NOT NULL, 
    [InspectionId] int NULL , 
    [InspectionGuid] uniqueidentifier NULL,

	CONSTRAINT [PK_QuestionList] PRIMARY KEY ([Id]),
	
	CONSTRAINT [FK_QuestionList_Inspection] FOREIGN KEY (InspectionId, InspectionGuid) REFERENCES Inspection (Id, Guid)
)