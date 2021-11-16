CREATE PROCEDURE [users].[uspInsertDEPStudent]
(
	@FullName NVARCHAR(255),
	@Email NVARCHAR(255),
	@Location NVARCHAR(255),
	@FBContact NVARCHAR(255),
	@Mobile NVARCHAR(64),
	@Remarks NVARCHAR(255),
	@CreatedBy NVARCHAR(255),
	@ClassType NVARCHAR(55),
	@SessionEmail NVARCHAR(255),
	@LicenseNumber NVARCHAR(255),
	@ExpirationDate DATETIME2,
	@DriveSafeStatusId INT,
	@TextForm NVARCHAR(MAX)
)
AS
BEGIN 
	IF (@DriveSafeStatusId = 0)
	BEGIN
		SET @DriveSafeStatusId = NULL;
	END

	INSERT INTO [users].[DEPStudent]
	(
		FullName,
		Email,
		[Location],
		FBContact,
		Mobile,
		Remarks,
		LicenseNumber,
		ExpirationDate,
		DateRegistered,
		CreatedBy,
		ClassType,
		SessionEmail,
		DriveSafeStatusId,
		TextForm
	)
	VALUES 
	(
		@FullName,
		@Email,
		@Location,
		@FBContact,
		@Mobile,
		@Remarks,
		@LicenseNumber,
		@ExpirationDate,
		GETUTCDATE(),
		@CreatedBy,
		@ClassType,
		@SessionEmail,
		@DriveSafeStatusId,
		@TextForm
	);

	SELECT SCOPE_IDENTITY();

END 