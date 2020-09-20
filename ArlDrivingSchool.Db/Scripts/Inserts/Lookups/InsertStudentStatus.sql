SET IDENTITY_INSERT [lookups].[StudentStatus] ON;
GO

DECLARE @StudentStatus TABLE
(
	 [StudentStatusId]	INT
	,[StatusName]		NVARCHAR(64)
);

INSERT INTO @StudentStatus
(
	 [StudentStatusId]
	,[StatusName]
)
VALUES
 (1, 'PENDING')
,(2, 'In Progress')
,(3, 'WAITING')
,(4, 'NEEDS ATN')
,(5, 'R 4 CERT')
,(6, 'Finished');

MERGE INTO [lookups].[StudentStatus] AS target
USING @StudentStatus AS source
	ON target.[StudentStatusId] = source.[StudentStatusId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[StatusName] = source.[StatusName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[StudentStatusId]
	   ,[StatusName]
	)
	VALUES
	(
		source.[StudentStatusId]
	   ,source.[StatusName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[StudentStatus] OFF;
GO