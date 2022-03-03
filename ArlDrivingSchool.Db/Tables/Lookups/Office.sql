CREATE TABLE [lookups].[Office]
(
	[OfficeId]			INT				NOT NULL IDENTITY(1,1),
	[OfficeName]		NVARCHAR(64)	NOT NULL,
	CONSTRAINT [PK_Office] PRIMARY KEY CLUSTERED ([OfficeId] ASC)
)
