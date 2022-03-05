CREATE TABLE [payments].[PDCPayment]
(
	[PDCPaymentId]  INT         NOT NULL IDENTITY(1,1), 
    [PDCStudentId]  INT         NOT NULL, 
    [PaymentDate]   DATETIME2   NOT NULL, 
    [TotalAmount]   INT         NOT NULL, 
    [Payment]       INT         NOT NULL,
    [Balance]       INT         NOT NULL,
    [PaymentModeId]	INT			NOT NULL DEFAULT 1,
    CONSTRAINT [PK_PDCPayment] PRIMARY KEY CLUSTERED ([PDCPaymentId] ASC),
    CONSTRAINT FK_PDCPayment_PDCStudent_PDCStudentId FOREIGN KEY (PDCStudentId) REFERENCES [users].[PDCStudent] (PDCStudentId) ON DELETE CASCADE,
    CONSTRAINT FK_PDCPayment_PaymentMode_PaymentModeId FOREIGN KEY (PaymentModeId) REFERENCES [lookups].[PaymentMode] (PaymentModeId),
)
