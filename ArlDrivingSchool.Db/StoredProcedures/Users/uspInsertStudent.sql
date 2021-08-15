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
	@DriveSafeStatusId INT
)
AS
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
		DriveSafeStatusId
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
		@DriveSafeStatusId
	);

	SELECT SCOPE_IDENTITY();
END 