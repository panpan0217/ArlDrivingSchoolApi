CREATE PROCEDURE [users].[uspUpdateStudentByStudentId]
	@StudentId			INT,
	@FirstName			NVARCHAR(255),
	@LastName			NVARCHAR(255),
	@Email				NVARCHAR(255),
	@Location			NVARCHAR(255),
	@FBContact			NVARCHAR(255),
	@Mobile				NVARCHAR(64),
	@StudentStatusId	INT,
	@TDCStatusId		INT,
	@ACESStatusId		INT,
	@Remarks			NVARCHAR(255),
	@DateRegistered		DATETIME2,
	@UpdatedBy			NVARCHAR(255),
	@AuthenticatedBy	NVARCHAR(255),
	@ClassType			NVARCHAR(55),
	@SessionEmail		NVARCHAR(255),
	@DriveSafeStatusId	INT,
	@TextForm			NVARCHAR(MAX),
	@OfficeId INT,
	@EnrollmentModeId INT,
	@UserId INT,
	@AcesSaveDate DATETIME2,
	@DateOfBirth DATETIME2,
	@OtherEnrollmentMode NVARCHAR(255)
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
	UPDATE users.Student
	SET
	 FirstName = @FirstName
	,LastName = @LastName
	,Email = @Email
	,[Location] =@Location
	,DateOfBirth = @DateOfBirth
	,FBContact = @FBContact
	,Mobile = @Mobile
	,StudentStatusId = @StudentStatusId
	,TDCStatusId = @TDCStatusId
	,ACESStatusId = @ACESStatusId
	,Remarks = @Remarks
	,DateRegistered = @DateRegistered
	,UpdatedBy = @UpdatedBy
	,AuthenticatedBy = @AuthenticatedBy
	,ClassType = @ClassType
	,SessionEmail = @SessionEmail
	,DriveSafeStatusId = @DriveSafeStatusId
	,TextForm = @TextForm
	,EnrollmentModeId = @EnrollmentModeId
	,OfficeId = @OfficeId
	,UserId = @UserId
	,AcesSaveDate = @AcesSaveDate,
	OtherEnrollmentMode = @OtherEnrollmentMode
	WHERE StudentId = @StudentId

END
GO;
