CREATE TABLE [users].[Access]
(
	[AccessId]          INT             NOT NULL    IDENTITY (1, 1),
    [UserId]            INT             NOT NULL,
    [Auth]              NVARCHAR (128)  NOT NULL,
    [Salt]              NVARCHAR (128)  NOT NULL,
    [ExpirationDate]    DATETIME2 (7)   NOT NULL,
    [IsTempAuthActive]  BIT             NOT NULL,
    [Active]		    BIT             NOT NULL	DEFAULT 1,
    [Deleted]		    BIT             NOT NULL	DEFAULT 0,
    [CreatedAt]         DATETIME2 (7)   NOT NULL,
    [UpdatedAt]         DATETIME2 (7)   NOT NULL,

	CONSTRAINT [PK_Access] PRIMARY KEY CLUSTERED ([AccessId] ASC),
	CONSTRAINT [FK_Access_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [users].[User] ([UserId]) ON DELETE CASCADE
)
