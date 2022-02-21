SET IDENTITY_INSERT [lookups].[ActivityLogType] ON;
GO

DECLARE @ActivityLogType TABLE
(
	 [ActivityLogTypeId] INT
	,[Name]	NVARCHAR(64)
);

INSERT INTO @ActivityLogType
(
	 [ActivityLogTypeId]
	,[Name]
)
VALUES
 (1, 'Create')
,(2, 'Update')
,(3, 'Delete')
,(4, 'Certified')
,(5, 'Uncertified')

MERGE INTO [lookups].[ActivityLogType] AS target
USING @ActivityLogType AS source
	ON target.[ActivityLogTypeId] = source.[ActivityLogTypeId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[Name] = source.[Name]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[ActivityLogTypeId]
	   ,[Name]
	)
	VALUES
	(
		source.[ActivityLogTypeId]
	   ,source.[Name]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[ActivityLogType] OFF;
GO