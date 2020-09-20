CREATE TABLE [sessions].[SessionOne]
(
	[SessionOneId] INT NOT NULL IDENTITY(1,1), 
    [StudentId] INT NOT NULL, 
    [SessionDate] DATETIME2 NULL, 
    [Schedule] NCHAR(10) NULL, 
    [Shuttle] NVARCHAR(50) NULL, 
    [SessionLocation] NVARCHAR(50) NULL,
    CONSTRAINT [PK_SessionOne] PRIMARY KEY CLUSTERED ([SessionOneId] ASC),
    CONSTRAINT FK_SessionOne_Student_StudentId FOREIGN KEY (StudentId) REFERENCES [users].[Student] (StudentId)
)
