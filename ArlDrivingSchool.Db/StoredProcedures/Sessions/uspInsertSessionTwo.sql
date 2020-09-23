CREATE PROCEDURE [sessions].[uspInsertSessionTwo]
(
	@StudentId INT,
	@Schedule NVARCHAR(55),
	@Shuttle BIT,
	@SessionLocation NVARCHAR(55)
)
AS
BEGIN 
	INSERT INTO [sessions].[SessionTwo]
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
