﻿CREATE TABLE [lookups].[ACESStatus]
(
	[ACESStatusId]		INT				NOT NULL PRIMARY KEY IDENTITY(1,1),
	[StatusName]		NVARCHAR(64)	NOT NULL,
	CONSTRAINT [PK_ACESStatus] PRIMARY KEY CLUSTERED ([ACESStatusId] ASC)
)
