SET IDENTITY_INSERT [lookups].[Course] ON;
GO

DECLARE @Course TABLE
(
	 [CourseId] INT
	,[CourseName]	NVARCHAR(255)
);

INSERT INTO @Course
(
	 [CourseId]
	,[CourseName]
)
VALUES
 (1, 'Driving Lesson')
,(2, ' Assessment')

MERGE INTO [lookups].[Course] AS target
USING @Course AS source
	ON target.[CourseId] = source.[CourseId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[CourseName] = source.[CourseName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[CourseId]
	   ,[CourseName]
	)
	VALUES
	(
		source.[CourseId]
	   ,source.[CourseName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[Course] OFF;
GO