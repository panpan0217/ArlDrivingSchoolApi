CREATE PROCEDURE [sessions].[uspUpdateDEPSession]
(
	@Date DATETIME2,
	@StudentId NVARCHAR(128),
	@SessionLocation  NVARCHAR(128),
	@BranchId INT,
	@Schedule NVARCHAR(55)
)
AS
BEGIN 
	UPDATE [sessions].[DEPSession]
	
	SET 
		[Date] = @Date,
		SessionLocation = @SessionLocation,
		BranchId = @BranchId,
		[Schedule] = @Schedule
	WHERE DEPStudentId = @StudentId
END
GO


