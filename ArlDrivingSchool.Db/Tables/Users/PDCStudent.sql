﻿CREATE TABLE [users].[PDCStudent]
(
	[PDCStudentId]		INT				NOT NULL IDENTITY(1,1),
	[DateRegistered]	DATETIME2		NOT NULL,
	[FullName]			NVARCHAR(255)	NOT NULL,
	[FBContact]			NVARCHAR(255)	NULL,
	[Mobile]			NVARCHAR(64)	NULL,
	[AgentName]			NVARCHAR(64)	NULL,
	[Location]			NVARCHAR(255)	NULL,
	[DateOfBirth]		DATETIME2		NULL,
	[ACESStatusId]		INT				NOT NULL,
	[RestrictionId]		NVARCHAR(128)	NOT NULL,
	[ATransmissionId]	INT				NOT NULL,
	[A1TransmissionId]	INT				NOT NULL DEFAULT 1,
	[BTransmissionId]	INT				NOT NULL DEFAULT 1,
	[B1TransmissionId]	INT				NOT NULL DEFAULT 1,
	[B2TransmissionId]	INT				NOT NULL DEFAULT 1,

	[ACourseId]	INT				NOT NULL DEFAULT 1,
	[A1CourseId]	INT				NOT NULL DEFAULT 1,
	[BCourseId]	INT				NOT NULL DEFAULT 1,
	[B1CourseId]	INT				NOT NULL DEFAULT 1,
	[B2CourseId]	INT				NOT NULL DEFAULT 1,

	[Remarks]			NVARCHAR(255)	NULL,
	[StudentPermit]		NVARCHAR(MAX)	NULL,
	[Certified]			BIT				NOT NULL DEFAULT 0,
	[DateCertified]		DATETIME2		NULL,
	[CreatedBy]         NVARCHAR(257)   NOT NULL DEFAULT 'admin', 
	[UpdatedBy]         NVARCHAR(257)   NULL,
	[AuthenticatedBy]	NVARCHAR(255)	NULL, 
	[EnrollmentModeId]		INT				NOT NULL DEFAULT 1,
	[OtherEnrollmentMode]	NVARCHAR(255)	NULL,
	[OfficeId]				INT				NULL,
	[UserId]				INT				NULL,
	[StudentId]				INT				NULL,
	[TransactionId]			INT				NULL,
	[GenderId]				INT				NULL,

	CONSTRAINT [PK_PDCStudent] PRIMARY KEY CLUSTERED ([PDCStudentId] ASC),
	CONSTRAINT FK_PDCStudent_ACESStatus_ACESStatusId FOREIGN KEY (ACESStatusId) REFERENCES [lookups].[ACESStatus] (ACESStatusId),
	CONSTRAINT FK_PDCStudent_EnrollmentMode_EnrollmentModeId FOREIGN KEY (EnrollmentModeId) REFERENCES [lookups].[EnrollmentMode] (EnrollmentModeId),
	CONSTRAINT FK_PDCStudent_Office_OfficeId FOREIGN KEY (OfficeId) REFERENCES [lookups].[Office] (OfficeId),
	CONSTRAINT FK_PDCStudent_Transaction_TransactionId FOREIGN KEY (TransactionId) REFERENCES [lookups].[Transaction] (TransactionId),
	CONSTRAINT FK_PDCStudent_User_UserId FOREIGN KEY (UserId) REFERENCES [users].[User] (UserId),
	CONSTRAINT FK_PDCStudent_Student_StudentId FOREIGN KEY (StudentId) REFERENCES [users].[Student] (StudentId),
	CONSTRAINT FK_PDCStudent_Gender_GenderId FOREIGN KEY (GenderId) REFERENCES [lookups].[Gender] (GenderId),
	--CONSTRAINT FK_PDCStudent_Restriction_RestrictionId FOREIGN KEY (RestrictionId) REFERENCES [lookups].[Restriction] (RestrictionId),
	--CONSTRAINT FK_PDCStudent_Transmission_ATransmissionId FOREIGN KEY ([ATransmissionId]) REFERENCES [lookups].[Transmission] (TransmissionId),
	--CONSTRAINT FK_PDCStudent_Transmission_A1TransmissionId FOREIGN KEY ([A1TransmissionId]) REFERENCES [lookups].[Transmission] (TransmissionId),
	--CONSTRAINT FK_PDCStudent_Transmission_BTransmissionId FOREIGN KEY ([BTransmissionId]) REFERENCES [lookups].[Transmission] (TransmissionId),


)
