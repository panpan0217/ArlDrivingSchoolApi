CREATE PROCEDURE [sessions].[uspUpdateSessionThreeByStudentId]
	@StudentId			INT,
	@SessionDate		Date,
	@Schedule			NVARCHAR(55),
	@Shuttle			BIT,
	@SessionLocation	NVARCHAR(55),
	@SessionBranchId	INT
AS
BEGIN
	
	UPDATE [sessions].SessionThree
	SET
	 SessionDate = @SessionDate
	,Schedule = @Schedule
	,Shuttle = @Shuttle
	,SessionLocation =@SessionLocation
	,BranchId = @SessionBranchId
	WHERE StudentId = @StudentId
END
GO;