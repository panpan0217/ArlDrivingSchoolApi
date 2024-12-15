SET IDENTITY_INSERT [lookups].[Gender] ON;
GO

DECLARE @Gender TABLE
(
	 [GenderId] INT
	,[GenderName]	NVARCHAR(255)
);

INSERT INTO @Gender
(
	 [GenderId]
	,[GenderName]
)
VALUES
 (1, 'Male')
,(2, ' Female')

MERGE INTO [lookups].[Gender] AS target
USING @Gender AS source
	ON target.[GenderId] = source.[GenderId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[GenderName] = source.[GenderName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[GenderId]
	   ,[GenderName]
	)
	VALUES
	(
		source.[GenderId]
	   ,source.[GenderName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[Gender] OFF;
GO