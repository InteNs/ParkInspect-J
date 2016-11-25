CREATE TABLE [dbo].[QuestionList]
(
	[Id] INT NOT NULL IDENTITY , 
	[Guid] uniqueidentifier NOT NULL PRIMARY KEY,
    [Description] VARCHAR(MAX) NOT NULL, 
    [Assignment_Id] int NULL , 
    CONSTRAINT [PK_QuestionList] PRIMARY KEY ([Id])
)