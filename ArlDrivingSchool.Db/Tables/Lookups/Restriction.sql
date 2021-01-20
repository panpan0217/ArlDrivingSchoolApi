CREATE TABLE [lookups].[Restriction]
(
	[RestrictionId]		INT				NOT NULL IDENTITY(1,1),
	[RestrictionCode]	NVARCHAR(255)	NOT NULL,
	CONSTRAINT [PK_Restriction] PRIMARY KEY CLUSTERED ([RestrictionId] ASC)
)
