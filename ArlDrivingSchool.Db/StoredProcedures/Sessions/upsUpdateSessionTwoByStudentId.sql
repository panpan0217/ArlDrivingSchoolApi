CREATE PROCEDURE [sessions].[uspUpdateSessionTwoByStudentId]
	@StudentId			INT,
	@SessionDate		Date,
	@Schedule			NVARCHAR(55),
	@Shuttle			BIT,
	@SessionLocation	NVARCHAR(55)
AS
BEGIN
	
	UPDATE [sessions].SessionTwo
	SET
	 SessionDate = @SessionDate
	,Schedule = @Schedule
	,Shuttle = @Shuttle
	,SessionLocation =@SessionLocation

	WHERE StudentId = @StudentId
END
GO;