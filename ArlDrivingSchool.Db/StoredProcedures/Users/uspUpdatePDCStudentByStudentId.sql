CREATE PROCEDURE [users].[uspUpdatePDCStudentByStudentId]
	@PDCStudentId			INT,
	@DateRegistered		DATETIME2,
	@DateOfBirth		DATETIME2,
	@FullName			NVARCHAR(255),
	@Location			NVARCHAR(255),
	@FBContact			NVARCHAR(255),
	@Mobile				NVARCHAR(64),
	@ACESStatusId		INT,
	@RestrictionId		NVARCHAR(128),
	@ATransmissionId		INT,
	@A1TransmissionId		INT,
	@BTransmissionId		INT,
	@B1TransmissionId		INT,
	@B2TransmissionId		INT,
	@ACourseId INT,
	@A1CourseId INT,
	@BCourseId INT,
	@B1CourseId INT,
	@B2CourseId INT,
	@Remarks			NVARCHAR(255),
	@StudentPermit		NVARCHAR(MAX),
	@UpdatedBy			NVARCHAR(255),
	@AuthenticatedBy	NVARCHAR(255),
	@OfficeId INT,
	@EnrollmentModeId INT,
	@UserId INT,
	@TransactionId INT,
	@StudentId INT,
	@OtherEnrollmentMode NVARCHAR(255)
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

	UPDATE users.PDCStudent
	SET
	 FullName = @FullName
	,FBContact = @FBContact
	,Location = @Location
	,DateOfBirth = @DateOfBirth
	,Mobile = @Mobile
	,ACESStatusId = @ACESStatusId
	,RestrictionId = @RestrictionId
	,ATransmissionId = @ATransmissionId
	,A1TransmissionId = @A1TransmissionId
	,BTransmissionId = @BTransmissionId
	,B1TransmissionId = @B1TransmissionId
	,B2TransmissionId = @B2TransmissionId
	,ACourseId = @ACourseId
	,A1CourseId = @A1CourseId
	,BCourseId = @BCourseId
	,B1CourseId = @B1CourseId
	,B2CourseId = @B2CourseId
	,Remarks = @Remarks
	,DateRegistered = @DateRegistered
	,StudentPermit = @StudentPermit
	,UpdatedBy = @UpdatedBy
	,AuthenticatedBy = @AuthenticatedBy
	,EnrollmentModeId = @EnrollmentModeId
	,OfficeId = @OfficeId
	,UserId = @UserId
	,TransactionId = @TransactionId
	,StudentId = @StudentId
	,OtherEnrollmentMode = @OtherEnrollmentMode
	WHERE PDCStudentId = @PDCStudentId

END
GO;
