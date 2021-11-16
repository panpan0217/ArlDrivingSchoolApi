﻿CREATE PROCEDURE [users].[uspUpdateDEPStudentByStudentId]
	@DEPStundent INT,
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
	@TextForm NVARCHAR(MAX),
	@UpdatedBy NVARCHAR(255)
AS
BEGIN
	IF (@DriveSafeStatusId = 0)
	BEGIN
		SET @DriveSafeStatusId = NULL;
	END
	UPDATE users.DEPStudent
	SET
	 FullName = @FullName
	,Email = @Email
	,[Location] =@Location
	,FBContact = @FBContact
	,Mobile = @Mobile
	,Remarks = @Remarks
	,LicenseNumber = @LicenseNumber
	,ExpirationDate = @ExpirationDate
	,UpdatedBy = @UpdatedBy
	,ClassType = @ClassType
	,SessionEmail = @SessionEmail
	,DriveSafeStatusId = @DriveSafeStatusId
	,TextForm = @TextForm
	WHERE DEPStudentId = @DEPStundent

END
GO;
