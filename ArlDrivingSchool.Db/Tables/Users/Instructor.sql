CREATE TABLE [users].[Instructor]
(
	[InstructorId]	INT				NOT NULL    IDENTITY (1, 1),
	[FullName]		NVARCHAR(255)	NOT NULL,
	[Status]		NVARCHAR(255)	NOT NULL,

	CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED ([InstructorId] ASC),
)
