CREATE PROCEDURE [users].[uspInsertPDCStudent]
(
	@FullName NVARCHAR(255),
	@FBContact NVARCHAR(255),
	@Mobile NVARCHAR(64),
	@ACESStatusId INT,
	@RestrictionId NVARCHAR(128),
	@ATransmissionId INT,
	@A1TransmissionId INT,
	@BTransmissionId INT,
	@Remarks NVARCHAR(255),
	@StudentPermit NVARCHAR(255),
	@CreatedBy NVARCHAR(255),
	@AuthenticatedBy NVARCHAR(255),
	@Certified BIT,
	@EnrollmentModeId INT,
	@UserId INT,
	@OfficeId INT,
	@TdcStudentId INT
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
			FBContact,
			Mobile,
			ACESStatusId,
			RestrictionId,
			ATransmissionId,
			A1TransmissionId,
			BTransmissionId,
			Remarks,
			StudentPermit,
			CreatedBy,
			AuthenticatedBy,
			Certified,
			DateCertified,
			EnrollmentModeId,
			UserId,
			OfficeId,
			StudentId
		)
		VALUES 
		(
			GETUTCDATE(),
			@FullName,
			@FBContact,
			@Mobile,
			@ACESStatusId,
			@RestrictionId,
			@ATransmissionId,
			@A1TransmissionId,
			@BTransmissionId,
			@Remarks,	
			@StudentPermit,
			@CreatedBy,
			@AuthenticatedBy,
			@Certified,
			GETDATE(),
			@EnrollmentModeId,
			@UserId,
			@OfficeId,
			@TdcStudentId
		);

		SELECT SCOPE_IDENTITY();
	END
	ELSE
		BEGIN
		INSERT INTO [users].[PDCStudent]
		(
			DateRegistered,
			FullName,
			FBContact,
			Mobile,
			ACESStatusId,
			RestrictionId,
			ATransmissionId,
			A1TransmissionId,
			BTransmissionId,
			Remarks,
			StudentPermit,
			CreatedBy,
			AuthenticatedBy,
			EnrollmentModeId,
			UserId,
			OfficeId,
			StudentId
		)
		VALUES 
		(
			GETUTCDATE(),
			@FullName,
			@FBContact,
			@Mobile,
			@ACESStatusId,
			@RestrictionId,
			@ATransmissionId,
			@A1TransmissionId,
			@BTransmissionId,
			@Remarks,	
			@StudentPermit,
			@CreatedBy,
			@AuthenticatedBy,
			@EnrollmentModeId,
			@UserId,
			@OfficeId,
			@TdcStudentId
		);

		SELECT SCOPE_IDENTITY();
	END
END 