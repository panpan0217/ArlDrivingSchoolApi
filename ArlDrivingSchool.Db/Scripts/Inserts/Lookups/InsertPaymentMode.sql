SET IDENTITY_INSERT [lookups].[PaymentMode] ON;
GO

DECLARE @PaymentMode TABLE
(
	 [PaymentModeId] INT
	,[PaymentModeName]	NVARCHAR(64)
);

INSERT INTO @PaymentMode
(
	 [PaymentModeId]
	,[PaymentModeName]
)
VALUES
 (1, 'Cash')
,(2, 'G-Cash')
,(3, 'Bank Transfer')
,(4, 'Remittance')

MERGE INTO [lookups].[PaymentMode] AS target
USING @PaymentMode AS source
	ON target.[PaymentModeId] = source.[PaymentModeId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[PaymentModeName] = source.[PaymentModeName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[PaymentModeId]
	   ,[PaymentModeName]
	)
	VALUES
	(
		source.[PaymentModeId]
	   ,source.[PaymentModeName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[PaymentMode] OFF;
GO