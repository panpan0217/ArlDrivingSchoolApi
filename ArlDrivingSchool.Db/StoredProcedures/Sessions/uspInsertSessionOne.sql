CREATE PROCEDURE [sessions].[uspInsertSessionOne]
(
	@StudentId INT,
	@SessionDate Date,
	@Schedule NVARCHAR(55),
	@Shuttle BIT,
	@SessionLocation NVARCHAR(55),
	@BranchId INT 
)
AS
BEGIN 
	INSERT INTO [sessions].[SessionOne]
	(
		StudentId,
		SessionDate,
		Schedule,
		Shuttle,
		SessionLocation,
		BranchId
	)
	VALUES 
	(
		@StudentId,
		@SessionDate,
		@Schedule,
		@Shuttle,
		@SessionLocation,
		@BranchId
	);

	SELECT SCOPE_IDENTITY();
END 
