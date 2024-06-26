﻿CREATE PROCEDURE [sessions].[uspUpdatePDCSession]
(
	@PDCSessionId INT,
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
	UPDATE [sessions].[PDCSession]
	
	SET 
		[Date] = @Date,
		StartTime = @StartTime,
		EndTime = @EndTime,
		PDCStudentId = @PDCStudentId,
		InstructorId = @InstructorId,
		Attended = @Attended,
		Remarks = @Remarks

	WHERE PDCSessionId = @PDCSessionId
END
GO


