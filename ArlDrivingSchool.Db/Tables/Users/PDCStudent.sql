﻿CREATE TABLE [users].[PDCStudent]
(
	[PDCStudentId]		INT				NOT NULL IDENTITY(1,1),
	[DateRegistered]	DATETIME2		NOT NULL,
	[FullName]			NVARCHAR(255)	NOT NULL,
	[FBContact]			NVARCHAR(255)	NULL,
	[Mobile]			NVARCHAR(64)	NULL,
	[ACESStatusId]		INT				NOT NULL,
	[RestrictionId]		NVARCHAR(128)	NOT NULL,
	[ATransmissionId]	INT				NOT NULL,
	[A1TransmissionId]	INT				NOT NULL DEFAULT 1,
	[BTransmissionId]	INT				NOT NULL DEFAULT 1,
	[Remarks]			NVARCHAR(255)	NULL,
	[StudentPermit]		NVARCHAR(MAX)	NULL,
	[Certified]			BIT				NOT NULL DEFAULT 0,
	[DateCertified]		DATETIME2		NULL,
	[CreatedBy]         NVARCHAR(257)   NOT NULL DEFAULT 'admin', 
	[UpdatedBy]         NVARCHAR(257)   NULL,

	CONSTRAINT [PK_PDCStudent] PRIMARY KEY CLUSTERED ([PDCStudentId] ASC),
	CONSTRAINT FK_PDCStudent_ACESStatus_ACESStatusId FOREIGN KEY (ACESStatusId) REFERENCES [lookups].[ACESStatus] (ACESStatusId),
	--CONSTRAINT FK_PDCStudent_Restriction_RestrictionId FOREIGN KEY (RestrictionId) REFERENCES [lookups].[Restriction] (RestrictionId),
	--CONSTRAINT FK_PDCStudent_Transmission_ATransmissionId FOREIGN KEY ([ATransmissionId]) REFERENCES [lookups].[Transmission] (TransmissionId),
	--CONSTRAINT FK_PDCStudent_Transmission_A1TransmissionId FOREIGN KEY ([A1TransmissionId]) REFERENCES [lookups].[Transmission] (TransmissionId),
	--CONSTRAINT FK_PDCStudent_Transmission_BTransmissionId FOREIGN KEY ([BTransmissionId]) REFERENCES [lookups].[Transmission] (TransmissionId),


)
