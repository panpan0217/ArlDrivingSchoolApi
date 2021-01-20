SET IDENTITY_INSERT [lookups].[Restriction] ON;
GO

DECLARE @Restriction TABLE
(
	 [RestrictionId] INT
	,[RestrictionCode]	NVARCHAR(255)
);

INSERT INTO @Restriction
(
	 [RestrictionId]
	,[RestrictionCode]
)
VALUES
 (1, 'A - Motorcycle L3')
,(2, 'A1 - Tricycle L4')
,(3, 'B - Light Passenger Car M1')

MERGE INTO [lookups].[Restriction] AS target
USING @Restriction AS source
	ON target.[RestrictionId] = source.[RestrictionId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[RestrictionCode] = source.[RestrictionCode]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[RestrictionId]
	   ,[RestrictionCode]
	)
	VALUES
	(
		source.[RestrictionId]
	   ,source.[RestrictionCode]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[Restriction] OFF;
GO