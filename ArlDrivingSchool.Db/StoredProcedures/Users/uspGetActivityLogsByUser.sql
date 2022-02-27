CREATE PROCEDURE [users].[uspGetActivityLogsByUser]
	@UserId			INT,
	@StartDate		DATETIME2,
	@EndDate		DATETIME2
AS
BEGIN
	SELECT	 ActivityLogId
			,al.UserId
			,CONCAT(u.FirstName, ' ', u.LastName) AS FullName
			,LogDate
			,StudentFullName
			,PageName
			,al.ActivityLogTypeId
			,alt.[Name] as ActivityLogName
	FROM users.[ActivityLog] AS al
	INNER JOIN users.[User] as u ON al.UserId = u.UserId
	INNER JOIN lookups.[ActivityLogType] as alt ON al.ActivityLogTypeId = alt.ActivityLogTypeId
	WHERE al.UserId = @UserId AND (CAST(LogDate as DATE) BETWEEN @StartDate AND @EndDate)
END
GO;