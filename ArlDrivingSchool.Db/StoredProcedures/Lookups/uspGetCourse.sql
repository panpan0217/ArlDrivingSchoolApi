CREATE PROCEDURE [lookups].[uspGetCourse]
AS
BEGIN
	SELECT	CourseId
		   ,CourseName

	FROM lookups.[Course]

END
GO;