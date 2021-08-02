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
	@AuthenticatedBy NVARCHAR(255)
)
AS
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
		AuthenticatedBy
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
		@AuthenticatedBy
	);

	SELECT SCOPE_IDENTITY();
END 