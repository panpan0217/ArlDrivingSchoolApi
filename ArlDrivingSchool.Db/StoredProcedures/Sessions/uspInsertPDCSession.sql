CREATE PROCEDURE [sessions].[uspInsertPDCSession]
(
	@Date DATETIME2,
	@StartTime DATETIME2,
	@EndTime DATETIME2,
	@PDCStudentId NVARCHAR(128),
	@InstructorId INT,
	@Attended BIT,
	@Remarks NVARCHAR(128)
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
		Attended,
		Remarks
	)
	VALUES 
	(
		@Date,
		@StartTime,
		@EndTime,
		@PDCStudentId,
		@InstructorId,
		@Attended,
		@Remarks
	);

	SELECT SCOPE_IDENTITY();
END 

