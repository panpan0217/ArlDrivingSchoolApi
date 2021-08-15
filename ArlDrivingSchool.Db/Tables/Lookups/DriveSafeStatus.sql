CREATE TABLE [lookups].[DriveSafeStatus]
(
	[DriveSafeStatusId]	INT				NOT NULL IDENTITY(1,1),
	[StatusName]		NVARCHAR(64)	NOT NULL,
	CONSTRAINT [PK_DriveSafeStatus] PRIMARY KEY CLUSTERED ([DriveSafeStatusId] ASC)
)
