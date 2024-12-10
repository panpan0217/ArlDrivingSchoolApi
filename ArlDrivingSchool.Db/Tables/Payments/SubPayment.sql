CREATE TABLE [payments].[SubPayment]
(
	[SubPaymentId]  INT     NOT NULL IDENTITY(1,1), 
    [PaymentId]     INT     NOT NULL, 
    [PaymentDate]   DATETIME2 NOT NULL, 
    [Payment]       INT     NOT NULL,
    [PaymentModeId]	INT		NOT NULL DEFAULT 1,
    CONSTRAINT [PK_SubPayment] PRIMARY KEY CLUSTERED ([SubPaymentId] ASC),
	CONSTRAINT FK_SubPayment_Payment_PaymentId FOREIGN KEY (PaymentId) REFERENCES [payments].[Payment] (PaymentId),
	CONSTRAINT FK_SubPayment_PaymentMode_PaymentModeId FOREIGN KEY (PaymentModeId) REFERENCES [lookups].[PaymentMode] (PaymentModeId),
)
