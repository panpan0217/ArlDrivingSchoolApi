CREATE PROCEDURE [sessions].[uspInsertSessionOne]
(
	@StudentId INT,
	@Schedule INT,
	@Shuttle INT,
	@SessionLocation INT
)
AS
BEGIN 
	INSERT INTO [sessions].[SessionOne]
	(
		StudentId,
		SessionDate,
		Schedule,
		Shuttle,
		SessionLocation
	)
	VALUES 
	(
		@StudentId,
		GETUTCDATE(),
		@Schedule,
		@Shuttle,
		@SessionLocation
	);

	SELECT SCOPE_IDENTITY();
END 
