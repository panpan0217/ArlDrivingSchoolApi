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
	@ExpirationDate NVARCHAR(65),
	@DriveSafeStatusId INT,
	@TextForm NVARCHAR(MAX),
	@EnrollmentModeId INT,
	@UserId INT,
	@OfficeId INT
)
AS
BEGIN 
	IF (@DriveSafeStatusId = 0)
	BEGIN
		SET @DriveSafeStatusId = NULL;
	END

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
		TextForm,
		EnrollmentModeId,
		UserId,
		OfficeId
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
		@TextForm,
		@EnrollmentModeId,
		@UserId,
		@OfficeId
	);

	SELECT SCOPE_IDENTITY();

END 