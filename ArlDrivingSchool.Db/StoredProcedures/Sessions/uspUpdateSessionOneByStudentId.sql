CREATE PROCEDURE [sessions].[uspUpdateSessionOneByStudentId]

	@StudentId			INT,
	@SessionDate		Date,
	@Schedule			NVARCHAR(55),
	@Shuttle			BIT,
	@SessionLocation	NVARCHAR(55)
AS
BEGIN
	
	UPDATE [sessions].SessionOne
	SET
	 SessionDate = @SessionDate
	,Schedule = @Schedule
	,Shuttle = @Shuttle
	,SessionLocation =@SessionLocation

	WHERE StudentId = @StudentId
END
GO;
