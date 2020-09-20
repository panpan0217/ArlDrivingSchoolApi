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
,(2, 'CR S1 Attended')
,(3, 'OL S1 Attended')
,(4, 'CR S2 Attended')
,(5, 'OL S2 Attended')
,(6, 'Completed');

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