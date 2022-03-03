CREATE PROCEDURE [users].[uspInsertStudent]
(
	@FirstName NVARCHAR(255),
	@LastName NVARCHAR(255),
	@Email NVARCHAR(255),
	@Location NVARCHAR(255),
	@FBContact NVARCHAR(255),
	@Mobile NVARCHAR(64),
	@StudentStatusId INT,
	@TDCStatusId INT,
	@ACESStatusId INT,
	@Remarks NVARCHAR(255),
	@CreatedBy NVARCHAR(255),
	@AuthenticatedBy NVARCHAR(255),
	@ClassType NVARCHAR(55),
	@SessionEmail NVARCHAR(255),
	@DriveSafeStatusId INT,
	@Certified BIT,
	@TextForm NVARCHAR(MAX),
	@OfficeId INT,
	@PaymentModeId INT
)
AS
BEGIN 
	IF (@DriveSafeStatusId = 0)
	BEGIN
		SET @DriveSafeStatusId = NULL;
	END
	IF(@Certified = 1)
	BEGIN
		INSERT INTO [users].[Student]
		(
			FirstName,
			LastName,
			Email,
			[Location],
			FBContact,
			Mobile,
			StudentStatusId,
			TDCStatusId,
			ACESStatusId,
			Remarks,
			DateRegistered,
			CreatedBy,
			AuthenticatedBy,
			ClassType,
			SessionEmail,
			DriveSafeStatusId,
			Certified,
			TextForm,
			DateCertified,
			OfficeId,
			PaymentModeId
		)
		VALUES 
		(
			@FirstName,
			@LastName,
			@Email,
			@Location,
			@FBContact,
			@Mobile,
			@StudentStatusId,
			@TDCStatusId,
			@ACESStatusId,
			@Remarks,
			GETUTCDATE(),
			@CreatedBy,
			@AuthenticatedBy,
			@ClassType,
			@SessionEmail,
			@DriveSafeStatusId,
			@Certified,
			@TextForm,
			GETDATE(),
			@OfficeId,
			@PaymentModeId
		);

		SELECT SCOPE_IDENTITY();
	END
	ELSE
	BEGIN
		INSERT INTO [users].[Student]
		(
			FirstName,
			LastName,
			Email,
			[Location],
			FBContact,
			Mobile,
			StudentStatusId,
			TDCStatusId,
			ACESStatusId,
			Remarks,
			DateRegistered,
			CreatedBy,
			AuthenticatedBy,
			ClassType,
			SessionEmail,
			DriveSafeStatusId,
			TextForm,
			OfficeId,
			PaymentModeId
		)
		VALUES 
		(
			@FirstName,
			@LastName,
			@Email,
			@Location,
			@FBContact,
			@Mobile,
			@StudentStatusId,
			@TDCStatusId,
			@ACESStatusId,
			@Remarks,
			GETUTCDATE(),
			@CreatedBy,
			@AuthenticatedBy,
			@ClassType,
			@SessionEmail,
			@DriveSafeStatusId,
			@TextForm,
			@OfficeId,
			@PaymentModeId
		);

		SELECT SCOPE_IDENTITY();
	END
END 