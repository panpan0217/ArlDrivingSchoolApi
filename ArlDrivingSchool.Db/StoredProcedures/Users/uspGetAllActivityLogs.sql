CREATE PROCEDURE [users].[uspGetAllActivityLogs]
AS
BEGIN
	SELECT	 ActivityLogId
			,al.UserId
			,CONCAT(u.FirstName, ' ', u.LastName) AS FullName
			,LogDate
			,al.ActivityLogTypeId
			,alt.[Name] as ActivityLogName
	FROM users.[ActivityLog] AS al
	INNER JOIN users.[User] as u ON al.UserId = u.UserId
	INNER JOIN lookups.[ActivityLogType] as alt ON al.ActivityLogTypeId = alt.ActivityLogTypeId 
END
GO;