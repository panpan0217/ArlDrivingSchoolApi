﻿CREATE PROCEDURE [sessions].[uspInsertPDCSessionOne]
(
	@PDCStudentId INT,
	@Date DateTime2,
	@StartTime DateTime2,
	@EndTime DateTime2,
	@Attended BIT
)
AS
BEGIN 
	INSERT INTO [sessions].[PDCSessionOne]
	(
		PDCStudentId,
		[Date],
		StartTime,
		EndTime,
		Attended
	)
	VALUES 
	(
		@PDCStudentId,
		@Date,
		@StartTime,
		@EndTime,
		@Attended
	);

	SELECT SCOPE_IDENTITY();
END 