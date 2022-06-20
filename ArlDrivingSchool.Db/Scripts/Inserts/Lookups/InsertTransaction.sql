SET IDENTITY_INSERT [lookups].[Transaction] ON;
GO

DECLARE @Transaction TABLE
(
	 [TransactionId] INT
	,[TransactionName]	NVARCHAR(255)
);

INSERT INTO @Transaction
(
	 [TransactionId]
	,[TransactionName]
)
VALUES
 (1, 'New Driver''s License')
,(2, 'Additional Code')
,(3, 'Certification')

MERGE INTO [lookups].[Transaction] AS target
USING @Transaction AS source
	ON target.[TransactionId] = source.[TransactionId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[TransactionName] = source.[TransactionName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[TransactionId]
	   ,[TransactionName]
	)
	VALUES
	(
		source.[TransactionId]
	   ,source.[TransactionName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[Transaction] OFF;
GO