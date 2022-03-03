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
	@OfficeId INT,
	@PaymentModeId INT
)
AS
BEGIN 
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
			OfficeId,
			PaymentModeId
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
			@OfficeId,
			@PaymentModeId
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
			OfficeId,
			PaymentModeId
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
			@OfficeId,
			@PaymentModeId
		);

		SELECT SCOPE_IDENTITY();
	END
END 