CREATE TABLE [sessions].[DEPSession]
(
	[DEPSessionId]		INT				NOT NULL IDENTITY(1,1),
	[Date]				DATETIME2		NOT NULL,
	[DEPStudentId]		INT				NOT NULL,
	[SessionLocation]   NVARCHAR(50)    NULL,
	[Schedule]			NVARCHAR(50)    NULL,
	[InstructorId]		INT				NULL,
	[Attended]          BIT				NOT NULL DEFAULT 0, 
	[BranchId]          INT             NULL DEFAULT 2,
	
	CONSTRAINT [PK_DEPSession] PRIMARY KEY CLUSTERED ([DEPSessionId] ASC),
    CONSTRAINT FK_DEPSession_DEPStudent_DEPStudentId FOREIGN KEY (DEPStudentId) REFERENCES [users].[DEPStudent] (DEPStudentId),
    CONSTRAINT FK_DEPSession_lookups_BranchId FOREIGN KEY (BranchId) REFERENCES [lookups].[Branch] (BranchId)
)
