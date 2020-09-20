SET IDENTITY_INSERT [lookups].[ACESStatus] ON;
GO

DECLARE @ACESSTatus TABLE
(
	 [ACESStatusId] INT
	,[StatusName]	NVARCHAR(64)
);

INSERT INTO @ACESSTatus
(
	 [ACESStatusId]
	,[StatusName]
)
VALUES
 (1, 'No Record')
,(2, 'Registered')
,(3, 'Authenticated')
,(4, 'Printed')
,(5, 'Ceriticated');

MERGE INTO [lookups].[ACESStatus] AS target
USING @ACESSTatus AS source
	ON target.[ACESStatusId] = source.[ACESStatusId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[StatusName] = source.[StatusName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[ACESStatusId]
	   ,[StatusName]
	)
	VALUES
	(
		source.[ACESStatusId]
	   ,source.[StatusName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[ACESStatus] OFF;
GO