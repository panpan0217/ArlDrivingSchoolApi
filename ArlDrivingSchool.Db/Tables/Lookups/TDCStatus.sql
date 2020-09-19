﻿CREATE TABLE [lookups].[TDCStatus]
(
	[TDCStatusId]		INT				NOT NULL PRIMARY KEY IDENTITY(1,1),
	[StatusName]		NVARCHAR(64)	NOT NULL,
	CONSTRAINT [PK_TDCStatus] PRIMARY KEY CLUSTERED ([TDCStatusId] ASC)
)
