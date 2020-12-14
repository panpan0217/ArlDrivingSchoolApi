CREATE TABLE [lookups].[UserType]
(
	[UserTypeId]    INT             NOT NULL    IDENTITY (1, 1),
    [Name]          NVARCHAR(128)   NOT NULL,
    [CreatedBy]		NVARCHAR(255)	NOT NULL,
	[CreatedAt]		DATETIME2		NOT NULL,
	[UpdatedBy]		NVARCHAR(255)	NOT NULL,
	[UpdatedAt]		DATETIME2		NOT NULL, 

	CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([UserTypeId] ASC)
)
