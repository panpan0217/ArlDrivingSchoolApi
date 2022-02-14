CREATE PROCEDURE [users].[uspInsertActivityLog]
(
	@UserId INT,
	@ActivityLogTypeId INT
)
AS
BEGIN
	INSERT INTO [users].[ActivityLog]
	(UserId,
	ActivityLogTypeId,
	LogDate
	)
	VALUES
	(@UserId,
	@ActivityLogTypeId,
	GETDATE()
	);
END
GO