SET IDENTITY_INSERT [lookups].[Branch] ON;
GO

DECLARE @Branch TABLE
(
	 [BranchId] INT
	,[BranchName]	NVARCHAR(64)
);

INSERT INTO @Branch
(
	 [BranchId]
	,[BranchName]
)
VALUES
 (1, 'AC')
,(2, 'SF')
,(3, 'MX')

MERGE INTO [lookups].[Branch] AS target
USING @Branch AS source
	ON target.[BranchId] = source.[BranchId]
WHEN MATCHED THEN
	UPDATE 
	SET	target.[BranchName] = source.[BranchName]

WHEN NOT MATCHED THEN
	INSERT 
	(
		[BranchId]
	   ,[BranchName]
	)
	VALUES
	(
		source.[BranchId]
	   ,source.[BranchName]
	)

WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO


SET IDENTITY_INSERT [lookups].[Branch] OFF;
GO