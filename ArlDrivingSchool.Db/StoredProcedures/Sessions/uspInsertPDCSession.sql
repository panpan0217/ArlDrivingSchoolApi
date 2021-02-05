CREATE PROCEDURE [sessions].[uspInsertPDCSession]
(
	@Date DATETIME2,
	@StartTime DATETIME2,
	@EndTime DATETIME2,
	@PDCStudentId INT,
	@InstructorId INT,
	@Attended BIT
)
AS
BEGIN 
	INSERT INTO [sessions].[PDCSession]
	(
		[Date],
		StartTime,
		EndTime,
		PDCStudentId,
		InstructorId,
		Attended
	)
	VALUES 
	(
		@Date,
		@StartTime,
		@EndTime,
		@PDCStudentId,
		@InstructorId,
		@Attended
	);

	SELECT SCOPE_IDENTITY();
END 

