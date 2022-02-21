CREATE TABLE [users].[ActivityLog]
(
	[ActivityLogId]		INT				NOT NULL    IDENTITY (1, 1),
	[LogDate]			NVARCHAR (128)  NOT NULL,
	[ActivityLogTypeId] INT             NOT NULL,
	[UserId]			INT				NOT NULL,
	[StudentFullName]	NVARCHAR(128)	NULL,
	[PageName]			NVARCHAR(128)	NULL,


	CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED ([ActivityLogId] ASC),
	CONSTRAINT [FK_ActivityLog_ActivityLogType_ActivityLogTypeId] FOREIGN KEY ([ActivityLogTypeId]) REFERENCES [lookups].[ActivityLogType] ([ActivityLogTypeId]),
	CONSTRAINT [FK_ActivityLog_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [users].[User] ([UserId]) ON DELETE CASCADE
)
