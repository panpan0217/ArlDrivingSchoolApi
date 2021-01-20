CREATE PROCEDURE [users].[uspUpdatePDCStudentByStudentId]
	@PDCStudentId			INT,
	@DateRegistered		DATETIME2,
	@FullName			NVARCHAR(255),
	@FBContact			NVARCHAR(255),
	@Mobile				NVARCHAR(64),
	@ACESStatusId		INT,
	@RestrictionId		INT,
	@TransmissionId		INT,
	@Remarks			NVARCHAR(255)
AS
BEGIN
	
	UPDATE users.PDCStudent
	SET
	 FullName = @FullName
	,FBContact = @FBContact
	,Mobile = @Mobile
	,ACESStatusId = @ACESStatusId
	,RestrictionId = @RestrictionId
	,TransmissionId = @TransmissionId
	,Remarks = @Remarks
	,DateRegistered = @DateRegistered


	WHERE PDCStudentId = @PDCStudentId

END
GO;
