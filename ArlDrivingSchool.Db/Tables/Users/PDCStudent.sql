﻿CREATE TABLE [users].[PDCStudent]
(
	[PDCStudentId]		INT				NOT NULL IDENTITY(1,1),
	[DateRegistered]	DATETIME2		NOT NULL,
	[FullName]			NVARCHAR(255)	NOT NULL,
	[FBContact]			NVARCHAR(255)	NULL,
	[Mobile]			NVARCHAR(64)	NULL,
	[ACESStatusId]		INT				NOT NULL,
	[RestrictionId]		NVARCHAR(128)	NOT NULL,
	[TransmissionId]	INT				NOT NULL,
	[Remarks]			NVARCHAR(255)	NULL,

	CONSTRAINT [PK_PDCStudent] PRIMARY KEY CLUSTERED ([PDCStudentId] ASC),
	CONSTRAINT FK_PDCStudent_ACESStatus_ACESStatusId FOREIGN KEY (ACESStatusId) REFERENCES [lookups].[ACESStatus] (ACESStatusId),
	--CONSTRAINT FK_PDCStudent_Restriction_RestrictionId FOREIGN KEY (RestrictionId) REFERENCES [lookups].[Restriction] (RestrictionId),
	CONSTRAINT FK_PDCStudent_Transmission_TransmissionId FOREIGN KEY (TransmissionId) REFERENCES [lookups].[Transmission] (TransmissionId),


)
