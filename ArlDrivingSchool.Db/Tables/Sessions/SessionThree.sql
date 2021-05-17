CREATE TABLE [sessions].[SessionThree]
(
	[SessionThreeId]    INT             NOT NULL IDENTITY(1,1), 
    [StudentId]         INT             NOT NULL, 
    [SessionDate]       DATETIME2       NULL,
    [Schedule]          NCHAR(10)       NULL,
    [Shuttle]           BIT             NOT NULL DEFAULT 0, 
    [SessionLocation]   NVARCHAR(50)    NULL, 
    [Attended]          BIT             NOT NULL DEFAULT 0, 
    [BranchId]          INT             NULL,

    CONSTRAINT [PK_SessionThree] PRIMARY KEY CLUSTERED ([SessionThreeId] ASC),
    CONSTRAINT FK_SessionThree_Student_StudentId FOREIGN KEY (StudentId) REFERENCES [users].[Student] (StudentId),
    CONSTRAINT FK_SessionThree_lookups_BranchId FOREIGN KEY (BranchId) REFERENCES [lookups].[Branch] (BranchId)
)
