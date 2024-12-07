SET IDENTITY_INSERT [lookups].[EnrollmentMode] ON;
GO

DECLARE @EnrollmentMode TABLE
(
	 [EnrollmentModeId] INT
	,[EnrollmentModeName]	NVARCHAR(64)
	,[Order]	INT
);

INSERT INTO @EnrollmentMode
(
	 [EnrollmentModeId]
	,[EnrollmentModeName]
	,[Order]
)
VALUES
 (1, 'Online', 1)
,(2, 'Staff', 2)
,(3, 'Office', 3)
,(4, 'Others', 5)
,(5, 'Agent', 6)

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
	   ,[Order]
	)
	VALUES
	(
		source.[EnrollmentModeId]
	   ,source.[EnrollmentModeName]
	   ,source.[Order]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[EnrollmentMode] OFF;
GO