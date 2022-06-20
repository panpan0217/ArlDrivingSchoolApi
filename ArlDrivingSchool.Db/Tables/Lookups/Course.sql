﻿CREATE TABLE [lookups].[Course]
(
	[CourseId]		INT				NOT NULL IDENTITY(1,1),
	[CourseName]	NVARCHAR(255)	NOT NULL,
	CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([CourseId] ASC)
)
