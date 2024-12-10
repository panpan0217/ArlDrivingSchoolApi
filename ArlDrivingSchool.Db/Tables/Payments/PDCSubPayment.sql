CREATE TABLE [payments].[PDCSubPayment]
(
	[PDCSubPaymentId]  INT     NOT NULL IDENTITY(1,1), 
    [PDCPaymentId]     INT     NOT NULL, 
    [PaymentDate]   DATETIME2 NOT NULL, 
    [Payment]       INT     NOT NULL,
    [PaymentModeId]	INT		NOT NULL DEFAULT 1,
    CONSTRAINT [PK_PDCSubPayment] PRIMARY KEY CLUSTERED ([PDCSubPaymentId] ASC),
	CONSTRAINT FK_PDCSubPayment_PDCPayment_PDCPaymentId FOREIGN KEY (PDCPaymentId) REFERENCES [payments].[PDCPayment] (PDCPaymentId),
	CONSTRAINT FK_PDCSubPayment_PaymentMode_PaymentModeId FOREIGN KEY (PaymentModeId) REFERENCES [lookups].[PaymentMode] (PaymentModeId),
)
