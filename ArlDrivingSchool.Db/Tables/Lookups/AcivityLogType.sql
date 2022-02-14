CREATE TABLE [lookups].[ActivityLogType]
(
	[ActivityLogTypeId]	INT             NOT NULL    IDENTITY (1, 1),
    [Name]				NVARCHAR(128)   NOT NULL,
    [CreatedBy]			NVARCHAR(255)		NULL,	
	[CreatedAt]			DATETIME2			NULL,

	CONSTRAINT [PK_AcivityLogType] PRIMARY KEY CLUSTERED ([ActivityLogTypeId] ASC)
)
