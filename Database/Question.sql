CREATE TABLE [dbo].[Question]
(
	[Id] INT NOT NULL, 
    [Version] INT NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[QuestionTypeId] int NOT NULL,
	[QuestionTypeGuid] uniqueidentifier NOT NULL,
    [Description] VARCHAR(MAX) NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1

    CONSTRAINT [PK_Question]  PRIMARY KEY CLUSTERED ([Id], [Version])
	CONSTRAINT [FK_Question_QuestionType] FOREIGN KEY (QuestionTypeId, [QuestionTypeGuid]) REFERENCES "QuestionType" (Id, Guid)
)
