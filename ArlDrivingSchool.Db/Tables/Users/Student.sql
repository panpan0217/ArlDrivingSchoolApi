﻿CREATE TABLE [users].[Student]
(
	[StudentId]				INT				NOT NULL IDENTITY(1,1),
	[FirstName]				NVARCHAR(255)	NOT NULL,
	[LastName]				NVARCHAR(255)	NULL,
	[Email]					NVARCHAR(255)	NULL,
	[Location]				NVARCHAR(255)	NULL,
	[FBContact]				NVARCHAR(255)	NULL,
	[Mobile]				NVARCHAR(64)	NULL,
	[StudentStatusId]		INT				NOT NULL,
	[TDCStatusId]			INT				NOT NULL,
	[ACESStatusId]			INT				NOT NULL,
	[Remarks]				NVARCHAR(255)	NULL,
	[DateRegistered]		DATETIME2		NOT NULL,
	[Certified]				BIT				NOT NULL DEFAULT 0,
	[DateCertified]			DATETIME2		NULL,
	[CreatedBy]             NVARCHAR(257)   NOT NULL DEFAULT 'admin', 
	[UpdatedBy]             NVARCHAR(257)   NULL,
	[AuthenticatedBy]		NVARCHAR(255)	NULL, 
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([StudentId] ASC),
	CONSTRAINT FK_Student_StudentStatus_StudentStatusId FOREIGN KEY (StudentStatusId) REFERENCES [lookups].[StudentStatus] (StudentStatusId),
	CONSTRAINT FK_Student_TDCStatus_TDCStatusId FOREIGN KEY (TDCStatusId) REFERENCES [lookups].[TDCStatus] (TDCStatusId),
	CONSTRAINT FK_Student_ACESStatus_ACESStatusId FOREIGN KEY (ACESStatusId) REFERENCES [lookups].[ACESStatus] (ACESStatusId),
)
