CREATE TABLE [sessions].[PDCSessionFour]
(
	[PDCSessionFourId]	INT			NOT NULL IDENTITY(1,1),
	[Date]				DATETIME2	NOT NULL,
	[StartTime]			DATETIME2	NULL,
	[EndTime]			DATETIME2	NULL,
	[PDCStudentId]		INT			NOT NULL,
	[Attended]          BIT         NOT NULL DEFAULT 0, 
	CONSTRAINT [PK_PDCSessionFour] PRIMARY KEY CLUSTERED ([PDCSessionFourId] ASC),
	CONSTRAINT [FK_PDCSessionFour_PDCStudent_PDCStudentId] FOREIGN KEY (PDCStudentId) REFERENCES [users].[PDCStudent] (PDCStudentId) ON DELETE CASCADE
)
