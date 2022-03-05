SET IDENTITY_INSERT [lookups].[EnrollmentMode] ON;
GO

DECLARE @EnrollmentMode TABLE
(
	 [EnrollmentModeId] INT
	,[EnrollmentModeName]	NVARCHAR(64)
);

INSERT INTO @EnrollmentMode
(
	 [EnrollmentModeId]
	,[EnrollmentModeName]
)
VALUES
 (1, 'FB Enrollee')
,(2, 'Staff Enrollee')
,(3, 'Office Enrollee')

MERGE INTO [lookups].[EnrollmentMode] AS target
USING @EnrollmentMode AS source
	ON target.[EnrollmentModeId] = source.[EnrollmentModeId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[EnrollmentModeName] = source.[EnrollmentModeName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[EnrollmentModeId]
	   ,[EnrollmentModeName]
	)
	VALUES
	(
		source.[EnrollmentModeId]
	   ,source.[EnrollmentModeName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[EnrollmentMode] OFF;
GO