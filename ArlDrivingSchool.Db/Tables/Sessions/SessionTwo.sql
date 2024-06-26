﻿CREATE TABLE [sessions].[SessionTwo]
(
	[SessionTwoId]      INT             NOT NULL IDENTITY(1,1), 
    [StudentId]         INT             NOT NULL, 
    [SessionDate]       DATETIME2       NULL, 
    [Schedule]          NCHAR(10)       NULL, 
    [Shuttle]           BIT             NOT NULL DEFAULT 0, 
    [SessionLocation]   NVARCHAR(50)    NULL,
    [Attended]          BIT             NOT NULL DEFAULT 0, 
    [BranchId]          INT             NULL DEFAULT 2,

    CONSTRAINT [PK_SessionTwo] PRIMARY KEY CLUSTERED ([SessionTwoId] ASC),
    CONSTRAINT FK_SessionTwo_Student_StudentId FOREIGN KEY (StudentId) REFERENCES [users].[Student] (StudentId),
    CONSTRAINT FK_SessionTwo_lookups_BranchId FOREIGN KEY (BranchId) REFERENCES [lookups].[Branch] (BranchId)
)
