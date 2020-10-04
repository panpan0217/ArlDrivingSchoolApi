CREATE PROCEDURE [sessions].[uspInsertSessionOne]
(
	@StudentId INT,
	@SessionDate Date,
	@Schedule NVARCHAR(55),
	@Shuttle BIT,
	@SessionLocation NVARCHAR(55)
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
		@SessionDate,
		@Schedule,
		@Shuttle,
		@SessionLocation
	);

	SELECT SCOPE_IDENTITY();
END 
