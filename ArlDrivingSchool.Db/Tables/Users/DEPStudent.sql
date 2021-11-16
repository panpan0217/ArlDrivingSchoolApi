CREATE TABLE [users].[DEPStudent]
(
	[DEPStudentId]			INT				NOT NULL IDENTITY(1,1),
	[FullName]				NVARCHAR(255)	NOT NULL,
	[Email]					NVARCHAR(255)	NULL,
	[Location]				NVARCHAR(255)	NULL,
	[FBContact]				NVARCHAR(255)	NULL,
	[Mobile]				NVARCHAR(64)	NULL,
	[LicenseNumber]			NVARCHAR(64)	NULL,
	[ExpirationDate]		DATETIME2		NOT NULL,
	[Remarks]				NVARCHAR(255)	NULL,
	[DateRegistered]		DATETIME2		NOT NULL,
	[CreatedBy]             NVARCHAR(257)   NOT NULL DEFAULT 'admin', 
	[UpdatedBy]             NVARCHAR(257)   NULL,
	[ClassType]				NVARCHAR(50)	NULL, 
    [DriveSafeStatusId]		INT				NULL, 
    [SessionEmail]			NVARCHAR(MAX)	NULL,
    [TextForm]				NVARCHAR(MAX)	NULL,

	CONSTRAINT [PK_DEPStudent] PRIMARY KEY CLUSTERED ([DEPStudentId] ASC),
	CONSTRAINT FK_DEPStudent_DriveSafeStatus_DriveSafeStatusId FOREIGN KEY (DriveSafeStatusId) REFERENCES [lookups].[DriveSafeStatus] (DriveSafeStatusId)
)
