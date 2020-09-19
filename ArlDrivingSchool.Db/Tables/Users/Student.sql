CREATE TABLE [users].[Student]
(
	[StudentId]				INT				NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName]				NVARCHAR(255)	NOT NULL,
	[LastName]				NVARCHAR(255)	NOT NULL,
	[Email]					NVARCHAR(255)	NOT NULL,
	[Location]				NVARCHAR(255)	NULL,
	[FBContact]				NVARCHAR(255)	NULL,
	[Mobile]				NVARCHAR(64)	NULL,
	[StudentStatusId]		INT				NOT NULL,
	[TDCStatusId]			INT				NOT NULL,
	[ACESStatusId]			INT				NOT NULL,
	[Remarks]				NVARCHAR(255)	NULL,
	[Package]				NVARCHAR(255)	NOT NULL,
	[DateRegistered]		DATETIME2		NOT NULL
	
	CONSTRAINT FK_Lookups_StudentStatusId FOREIGN KEY (StudentStatusId) REFERENCES [lookups].[StudentStatus] (StudentStatusId),
	CONSTRAINT FK_Lookups_TDCStatusId FOREIGN KEY (TDCStatusId) REFERENCES [lookups].[TDCStatus] (TDCStatusId),
	CONSTRAINT FK_Lookups_ACESStatusId FOREIGN KEY (ACESStatusId) REFERENCES [lookups].[ACESStatus] (ACESStatusId),
)
