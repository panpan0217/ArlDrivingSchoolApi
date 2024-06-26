﻿CREATE PROCEDURE [users].[uspUpdateDEPStudentByStudentId]
	@DEPStudentId INT,
	@FullName NVARCHAR(255),
	@Email NVARCHAR(255),
	@Location NVARCHAR(255),
	@FBContact NVARCHAR(255),
	@Mobile NVARCHAR(64),
	@Remarks NVARCHAR(255),
	@DateRegistered		DATETIME2,
	@ClassType NVARCHAR(55),
	@SessionEmail NVARCHAR(255),
	@LicenseNumber NVARCHAR(255),
	@ExpirationDate NVARCHAR(65),
	@DriveSafeStatusId INT,
	@TextForm NVARCHAR(MAX),
	@UpdatedBy NVARCHAR(255),
	@OfficeId INT,
	@EnrollmentModeId INT,
	@UserId INT,
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

	UPDATE users.DEPStudent
	SET
	 FullName = @FullName
	,Email = @Email
	,[Location] =@Location
	,FBContact = @FBContact
	,Mobile = @Mobile
	,Remarks = @Remarks
	,DateRegistered = @DateRegistered
	,LicenseNumber = @LicenseNumber
	,ExpirationDate = @ExpirationDate
	,UpdatedBy = @UpdatedBy
	,ClassType = @ClassType
	,SessionEmail = @SessionEmail
	,DriveSafeStatusId = @DriveSafeStatusId
	,TextForm = @TextForm
	,EnrollmentModeId = @EnrollmentModeId
	,OfficeId = @OfficeId
	,UserId = @UserId
	,OtherEnrollmentMode = @OtherEnrollmentMode
	WHERE DEPStudentId = @DEPStudentId

END
GO;
