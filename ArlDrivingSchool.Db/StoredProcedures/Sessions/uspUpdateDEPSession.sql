CREATE PROCEDURE [sessions].[uspUpdateDEPSession]
(
	@DEPSessionId INT,
	@Date DATETIME2,
	@DEPStudentId NVARCHAR(128),
	@SessionLocation  NVARCHAR(128),
	@BranchId INT,
	@InstructorId INT,
	@Attended BIT
)
AS
BEGIN 
	UPDATE [sessions].[DEPSession]
	
	SET 
		[Date] = @Date,
		DEPStudentId = @DEPStudentId,
		SessionLocation = @SessionLocation,
		BranchId = @BranchId,
		InstructorId = @InstructorId,
		Attended = @Attended
	WHERE DEPSessionId = @DEPSessionId
END
GO


