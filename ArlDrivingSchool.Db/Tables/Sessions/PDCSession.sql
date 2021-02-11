CREATE TABLE [sessions].[PDCSession]
(
	[PDCSessionId]		INT				NOT NULL IDENTITY(1,1),
	[Date]				DATETIME2		NOT NULL,
	[StartTime]			DATETIME2		NULL,
	[EndTime]			DATETIME2		NULL,
	[PDCStudentId]		NVARCHAR(128)	NOT NULL,
	[InstructorId]		INT				NOT NULL,
	[Attended]          BIT				NOT NULL DEFAULT 0, 

	CONSTRAINT [PK_PDCSession] PRIMARY KEY CLUSTERED ([PDCSessionId] ASC),
	--CONSTRAINT [FK_PDCSessionId_PDCStudent_PDCStudentId] FOREIGN KEY (PDCStudentId) REFERENCES [users].[PDCStudent] (PDCStudentId) ON DELETE CASCADE,
	CONSTRAINT [FK_PDCSessionId_Instructor_InstructorId] FOREIGN KEY (InstructorId) REFERENCES [users].[Instructor] (InstructorId)


)
