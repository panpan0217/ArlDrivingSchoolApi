CREATE PROCEDURE [users].[uspInsertActivityLog]
(
	@UserId INT,
	@ActivityLogTypeId INT,
	@StudentFullName NVARCHAR(128),
	@PageName NVARCHAR(128)
)
AS
BEGIN
	INSERT INTO [users].[ActivityLog]
	(UserId,
	ActivityLogTypeId,
	LogDate,
	StudentFullName,
	PageName
	)
	VALUES
	(@UserId,
	@ActivityLogTypeId,
	GETDATE(),
	@StudentFullName,
	@PageName
	);
END
GO