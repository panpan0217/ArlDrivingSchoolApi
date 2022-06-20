CREATE PROCEDURE [users].[uspUpdatePDCStudentByStudentId]
	@PDCStudentId			INT,
	@DateRegistered		DATETIME2,
	@FullName			NVARCHAR(255),
	@FBContact			NVARCHAR(255),
	@Mobile				NVARCHAR(64),
	@ACESStatusId		INT,
	@RestrictionId		NVARCHAR(128),
	@ATransmissionId		INT,
	@A1TransmissionId		INT,
	@BTransmissionId		INT,
	@ACourseId INT,
	@A1CourseId INT,
	@BCourseId INT,
	@Remarks			NVARCHAR(255),
	@StudentPermit		NVARCHAR(MAX),
	@UpdatedBy			NVARCHAR(255),
	@AuthenticatedBy	NVARCHAR(255),
	@OfficeId INT,
	@EnrollmentModeId INT,
	@UserId INT,
	@TransactionId INT,
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
	,Mobile = @Mobile
	,ACESStatusId = @ACESStatusId
	,RestrictionId = @RestrictionId
	,ATransmissionId = @ATransmissionId
	,A1TransmissionId = @A1TransmissionId
	,BTransmissionId = @BTransmissionId
	,ACourseId = @ACourseId
	,A1CourseId = @A1CourseId
	,BCourseId = @BCourseId
	,Remarks = @Remarks
	,DateRegistered = @DateRegistered
	,StudentPermit = @StudentPermit
	,UpdatedBy = @UpdatedBy
	,AuthenticatedBy = @AuthenticatedBy
	,EnrollmentModeId = @EnrollmentModeId
	,OfficeId = @OfficeId
	,UserId = @UserId
	,TransactionId = @TransactionId,
	OtherEnrollmentMode = @OtherEnrollmentMode
	WHERE PDCStudentId = @PDCStudentId

END
GO;
