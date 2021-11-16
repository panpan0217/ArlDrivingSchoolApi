CREATE PROCEDURE [sessions].[uspInsertDEPSession]
(
	@Date DATETIME2,
	@StudentId NVARCHAR(128),
	@SessionLocation  NVARCHAR(128),
	@BranchId INT,
	@Schedule NVARCHAR(55)
)
AS
BEGIN 
	INSERT INTO [sessions].[DEPSession]
	(
		[Date],
		[DEPStudentId],
		[SessionLocation],
		[BranchId],
		Schedule
	)
	VALUES 
	(
		@Date,
		@StudentId,
		@SessionLocation,
		@BranchId,
		@Schedule
	);

	SELECT SCOPE_IDENTITY();
END 

