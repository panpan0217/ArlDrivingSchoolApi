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
	@DateRegistered		DATETIME2
AS
BEGIN
	
	UPDATE users.Student
	SET
	 FirstName = @FirstName
	,LastName = @LastName
	,Email = @Email
	,[Location] =@Location
	,FBContact = @FBContact
	,Mobile = @Mobile
	,StudentStatusId = @StudentStatusId
	,TDCStatusId = @TDCStatusId
	,ACESStatusId = @ACESStatusId
	,Remarks = @Remarks
	,DateRegistered = @DateRegistered


	WHERE StudentId = @StudentId

END
GO;
