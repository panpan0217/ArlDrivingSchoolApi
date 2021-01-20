SET IDENTITY_INSERT [lookups].[Transmission] ON;
GO

DECLARE @Transmission TABLE
(
	 [TransmissionId] INT
	,[TransmissionName]	NVARCHAR(255)
);

INSERT INTO @Transmission
(
	 [TransmissionId]
	,[TransmissionName]
)
VALUES
 (1, 'Automatic')
,(2, 'Manual')
,(3, 'Combination')

MERGE INTO [lookups].[Transmission] AS target
USING @Transmission AS source
	ON target.[TransmissionId] = source.[TransmissionId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[TransmissionName] = source.[TransmissionName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[TransmissionId]
	   ,[TransmissionName]
	)
	VALUES
	(
		source.[TransmissionId]
	   ,source.[TransmissionName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[Transmission] OFF;
GO