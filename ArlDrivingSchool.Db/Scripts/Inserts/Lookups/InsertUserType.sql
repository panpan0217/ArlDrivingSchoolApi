SET IDENTITY_INSERT [lookups].[UserType] ON;
GO

DECLARE @Today DATETIME2(7) = GETDATE();

DECLARE @UserType TABLE
(
	UserTypeId	INT,	
	[Name]		NVARCHAR(128)
);

INSERT INTO @UserType
(
	 UserTypeId
	,[Name]
)
VALUES
 (1, 'Admin')
,(2, 'Manager')
,(3, 'Instructor')
,(4, 'Student');

MERGE INTO [lookups].[UserType] AS target
USING @UserType AS source
	ON target.UserTypeId = source.UserTypeId
WHEN MATCHED THEN
	UPDATE
	SET  target.[Name] = source.[Name]
		,target.CreatedBy = 'System'
		,target.CreatedAt = @Today
		,target.UpdatedBy = 'System'
		,target.UpdatedAt = @Today
WHEN NOT MATCHED THEN
	INSERT
	(
		 UserTypeId
		,[Name]
		,CreatedBy
		,CreatedAt
		,UpdatedBy
		,UpdatedAt
	)
	VALUES
	(
		 source.UserTypeId
		,source.[Name]
		,'System'
		,@Today
		,'System'
		,@Today
	)
WHEN NOT MATCHED BY SOURCE THEN DELETE;
GO

SET IDENTITY_INSERT [lookups].[UserType] OFF;
GO