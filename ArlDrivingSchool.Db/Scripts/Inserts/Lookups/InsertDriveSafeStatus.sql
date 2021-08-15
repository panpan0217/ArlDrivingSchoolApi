SET IDENTITY_INSERT [lookups].[DriveSafeStatus] ON;
GO

DECLARE @DriveSafeStatus TABLE
(
	 [DriveSafeStatusId]	INT
	,[StatusName]			NVARCHAR(64)
);

INSERT INTO @DriveSafeStatus
(
	 [DriveSafeStatusId]
	,[StatusName]
)
VALUES
 (1, 'No Record')
,(2, 'Registered');

MERGE INTO [lookups].[DriveSafeStatus] AS target
USING @DriveSafeStatus AS source
	ON target.[DriveSafeStatusId] = source.[DriveSafeStatusId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[StatusName] = source.[StatusName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[DriveSafeStatusId]
	   ,[StatusName]
	)
	VALUES
	(
		source.[DriveSafeStatusId]
	   ,source.[StatusName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO

SET IDENTITY_INSERT [lookups].[DriveSafeStatus] OFF;
GO