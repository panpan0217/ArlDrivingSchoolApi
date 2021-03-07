CREATE PROCEDURE [users].[uspInsertPDCStudent]
(
	@FullName NVARCHAR(255),
	@FBContact NVARCHAR(255),
	@Mobile NVARCHAR(64),
	@ACESStatusId INT,
	@RestrictionId NVARCHAR(128),
	@TransmissionId INT,
	@Remarks NVARCHAR(255)
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
		TransmissionId,
		Remarks
	)
	VALUES 
	(
		GETUTCDATE(),
		@FullName,
		@FBContact,
		@Mobile,
		@ACESStatusId,
		@RestrictionId,
		@TransmissionId,
		@Remarks
	);

	SELECT SCOPE_IDENTITY();
END 