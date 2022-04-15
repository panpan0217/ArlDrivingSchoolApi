CREATE TABLE [lookups].[Transaction]
(
	[TransactionId]		INT				NOT NULL IDENTITY(1,1),
	[TransactionName]	NVARCHAR(255)	NOT NULL,
	CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([TransactionId] ASC)
)
