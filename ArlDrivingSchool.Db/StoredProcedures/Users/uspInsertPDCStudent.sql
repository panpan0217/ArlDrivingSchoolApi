﻿CREATE PROCEDURE [users].[uspInsertPDCStudent]
(
	@FullName NVARCHAR(255),
	@FBContact NVARCHAR(255),
	@Location NVARCHAR(255),
	@Mobile NVARCHAR(64),
	@AgentName NVARCHAR(64),
	@ACESStatusId INT,
	@RestrictionId NVARCHAR(128),
	@ATransmissionId INT,
	@A1TransmissionId INT,
	@BTransmissionId INT,
	@B1TransmissionId INT,
	@B2TransmissionId INT,
	@ACourseId INT,
	@A1CourseId INT,
	@BCourseId INT,
	@B1CourseId INT,
	@B2CourseId INT,
	@Remarks NVARCHAR(255),
	@StudentPermit NVARCHAR(255),
	@CreatedBy NVARCHAR(255),
	@AuthenticatedBy NVARCHAR(255),
	@Certified BIT,
	@EnrollmentModeId INT,
	@UserId INT,
	@OfficeId INT,
	@TdcStudentId INT,
	@TransactionId INT,
	@GenderId INT,
	@OtherEnrollmentMode NVARCHAR(255),
	@DateRegistered DATETIME2,
	@DateOfBirth DATETIME2
)
AS
BEGIN 
	IF(@EnrollmentModeId = 1)
	BEGIN
		SET @UserId = NULL;
		SET @OfficeId = NULL;
	END
	IF(@EnrollmentModeId = 2)
	BEGIN
		SET @OfficeId = NULL
	END
	IF(@EnrollmentModeId = 3)
	BEGIN
		SET @UserId = NULL
	END

	IF(@Certified = 1)
	BEGIN
		INSERT INTO [users].[PDCStudent]
		(
			DateRegistered,
			FullName,
			Location,
			DateOfBirth,
			FBContact,
			Mobile,
			AgentName,
			GenderId,
			ACESStatusId,
			RestrictionId,
			ATransmissionId,
			A1TransmissionId,
			BTransmissionId,
			B1TransmissionId,
			B2TransmissionId,
			ACourseId,
			A1CourseId,
			BCourseId,
			B1CourseId,
			B2CourseId,
			Remarks,
			StudentPermit,
			CreatedBy,
			AuthenticatedBy,
			Certified,
			DateCertified,
			EnrollmentModeId,
			UserId,
			OfficeId,
			StudentId,
			TransactionId,
			OtherEnrollmentMode
		)
		VALUES 
		(
			@DateRegistered,
			@FullName,
			@Location,
			@DateOfBirth,
			@FBContact,
			@Mobile,
			@AgentName,
			@GenderId,
			@ACESStatusId,
			@RestrictionId,
			@ATransmissionId,
			@A1TransmissionId,
			@BTransmissionId,
			@B1TransmissionId,
			@B2TransmissionId,
			@ACourseId,
			@A1CourseId,
			@BCourseId,
			@B1CourseId,
			@B2CourseId,
			@Remarks,	
			@StudentPermit,
			@CreatedBy,
			@AuthenticatedBy,
			@Certified,
			GETDATE(),
			@EnrollmentModeId,
			@UserId,
			@OfficeId,
			@TdcStudentId,
			@TransactionId,
			@OtherEnrollmentMode
		);

		SELECT SCOPE_IDENTITY();
	END
	ELSE
		BEGIN
		INSERT INTO [users].[PDCStudent]
		(
			DateRegistered,
			FullName,
			Location,
			DateOfBirth,
			FBContact,
			Mobile,
			AgentName,
			GenderId,
			ACESStatusId,
			RestrictionId,
			ATransmissionId,
			A1TransmissionId,
			BTransmissionId,
			ACourseId,
			A1CourseId,
			BCourseId,
			Remarks,
			StudentPermit,
			CreatedBy,
			AuthenticatedBy,
			EnrollmentModeId,
			UserId,
			OfficeId,
			StudentId,
			TransactionId,
			OtherEnrollmentMode
		)
		VALUES 
		(
			@DateRegistered,
			@FullName,
			@Location,
			@DateOfBirth,
			@FBContact,
			@Mobile,
			@AgentName,
			@GenderId,
			@ACESStatusId,
			@RestrictionId,
			@ATransmissionId,
			@A1TransmissionId,
			@BTransmissionId,
			@ACourseId,
			@A1CourseId,
			@BCourseId,
			@Remarks,	
			@StudentPermit,
			@CreatedBy,
			@AuthenticatedBy,
			@EnrollmentModeId,
			@UserId,
			@OfficeId,
			@TdcStudentId,
			@TransactionId,
			@OtherEnrollmentMode
		);

		SELECT SCOPE_IDENTITY();
	END
END 