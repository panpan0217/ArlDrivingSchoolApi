﻿CREATE TABLE [lookups].[Gender]
(
	[GenderId]		INT				NOT NULL IDENTITY(1,1),
	[GenderName]	NVARCHAR(255)	NOT NULL,
	CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED ([GenderId] ASC)
)
