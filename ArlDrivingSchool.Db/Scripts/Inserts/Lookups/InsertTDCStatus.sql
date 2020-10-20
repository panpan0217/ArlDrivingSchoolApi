SET IDENTITY_INSERT [lookups].[TDCStatus] ON;
GO

DECLARE @TDCStatus TABLE
(
	 [TDCStatusId]	INT
	,[StatusName]	NVARCHAR(64)
);

INSERT INTO @TDCStatus
(
	 [TDCStatusId]
	,[StatusName]
)
VALUES
 (1, 'Not Started')
,(2, 'S1 Attended')
,(3, 'S2 Attended')
,(4, 'S3 Attended')
,(5, 'Completed');

MERGE INTO [lookups].[TDCStatus] AS target
USING @TDCStatus AS source
	ON target.[TDCStatusId] = source.[TDCStatusId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[StatusName] = source.[StatusName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[TDCStatusId]
	   ,[StatusName]
	)
	VALUES
	(
		source.[TDCStatusId]
	   ,source.[StatusName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO

SET IDENTITY_INSERT [lookups].[TDCStatus] OFF;
GO