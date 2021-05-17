CREATE PROCEDURE [sessions].[uspUpdateSessionTwoByStudentId]
	@StudentId			INT,
	@SessionDate		Date,
	@Schedule			NVARCHAR(55),
	@Shuttle			BIT,
	@SessionLocation	NVARCHAR(55),
	@SessionBranchId	INT
AS
BEGIN
	
	UPDATE [sessions].SessionTwo
	SET
	 SessionDate = @SessionDate
	,Schedule = @Schedule
	,Shuttle = @Shuttle
	,SessionLocation =@SessionLocation
	,BranchId = @SessionBranchId
	WHERE StudentId = @StudentId
END
GO;