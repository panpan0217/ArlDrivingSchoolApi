SET IDENTITY_INSERT [lookups].[Office] ON;
GO

DECLARE @Office TABLE
(
	 [OfficeId] INT
	,[OfficeName]	NVARCHAR(64)
);

INSERT INTO @Office
(
	 [OfficeId]
	,[OfficeName]
)
VALUES
 (1, 'Angeles')
,(2, 'Angeles-kiosk1')
,(3, 'San Fernando')
,(4, 'Mexico')

MERGE INTO [lookups].[Office] AS target
USING @Office AS source
	ON target.[OfficeId] = source.[OfficeId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[OfficeName] = source.[OfficeName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[OfficeId]
	   ,[OfficeName]
	)
	VALUES
	(
		source.[OfficeId]
	   ,source.[OfficeName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[Office] OFF;
GO