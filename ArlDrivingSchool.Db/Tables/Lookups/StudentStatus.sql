CREATE TABLE [lookups].[StudentStatus]
(
	[StudentStatusId]	INT				NOT NULL PRIMARY KEY IDENTITY(1,1),
	[StatusName]		NVARCHAR(64)	NOT NULL,
	CONSTRAINT [PK_StudentStatus] PRIMARY KEY CLUSTERED ([StudentStatusId] ASC)
)
