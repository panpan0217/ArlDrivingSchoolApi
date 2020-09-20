CREATE TABLE [sessions].[SessionThree]
(
	[SessionThreeId] INT NOT NULL IDENTITY(1,1), 
    [StudentId] INT NOT NULL, 
    [SessionDate] DATETIME2 NULL, 
    [Time] TIME NULL, 
    [Branch] NVARCHAR(50) NULL,
    CONSTRAINT [PK_SessionThree] PRIMARY KEY CLUSTERED ([SessionThreeId] ASC),
    CONSTRAINT FK_SessionThree_Student_StudentId FOREIGN KEY (StudentId) REFERENCES [users].[Student] (StudentId)
)
