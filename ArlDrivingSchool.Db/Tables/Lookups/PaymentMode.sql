CREATE TABLE [lookups].[PaymentMode]
(
	[PaymentModeId]			INT				NOT NULL IDENTITY(1,1),
	[PaymentModeName]		NVARCHAR(64)	NOT NULL,
	CONSTRAINT [PK_PaymentMode] PRIMARY KEY CLUSTERED ([PaymentModeId] ASC)
)
