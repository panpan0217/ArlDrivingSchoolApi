﻿CREATE TABLE [lookups].[EnrollmentMode]
(
	[EnrollmentModeId]			INT				NOT NULL IDENTITY(1,1),
	[EnrollmentModeName]		NVARCHAR(64)	NOT NULL,
	[Order]		INT				NOT NULL		 DEFAULT 1, 
	CONSTRAINT [PK_EnrollmentMode] PRIMARY KEY CLUSTERED ([EnrollmentModeId] ASC)
)
