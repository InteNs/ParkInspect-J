CREATE TABLE [dbo].[QuestionList]
(
	[Id] INT NOT NULL IDENTITY , 
	[Guid] uniqueidentifier NOT NULL,
    [Description] VARCHAR(MAX) NOT NULL, 
    [Assignment_Id] int NULL , 
    CONSTRAINT [PK_QuestionList] PRIMARY KEY ([Id])
)