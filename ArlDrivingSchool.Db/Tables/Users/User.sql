CREATE TABLE [users].[User]
(
	[UserId]		INT				NOT NULL    IDENTITY (1, 1),
	[FirstName]     NVARCHAR (128)  NOT NULL,
    [LastName]      NVARCHAR (128)  NOT NULL,
    [Username]      NVARCHAR (128)  NOT NULL,
    [Email]         NVARCHAR (128)  NOT NULL,
	[UserTypeId]    INT             NOT NULL,
	[ProfileLink]	NVARCHAR(MAX)	NULL,
	[Address]		NVARCHAR(MAX)	NULL,
	[birthday]		NVARCHAR(MAX)	NULL,
	[Active]		BIT             NOT NULL	DEFAULT 1,
    [Deleted]		BIT             NOT NULL	DEFAULT 0,
    [CreatedAt]     DATETIME2 (7)   NOT NULL,
    [UpdatedAt]     DATETIME2 (7)   NULL,

	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
	CONSTRAINT [FK_User_UserType_UserTypeId] FOREIGN KEY ([UserTypeId]) REFERENCES [lookups].[UserType] ([UserTypeId])
)
