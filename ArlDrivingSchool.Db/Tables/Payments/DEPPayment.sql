CREATE TABLE [payments].[DEPPayment]
(
	[DEPPaymentId]  INT         NOT NULL IDENTITY(1,1), 
    [DEPStudentId]  INT         NOT NULL, 
    [PaymentDate]   DATETIME2   NOT NULL, 
    [TotalAmount]   INT         NOT NULL, 
    [Payment]       INT         NOT NULL,
    [Balance]       INT         NOT NULL,
    [PaymentModeId]	INT			NOT NULL DEFAULT 1,
    CONSTRAINT [PK_DEPPayment] PRIMARY KEY CLUSTERED ([DEPPaymentId] ASC),
    CONSTRAINT FK_DEPPayment_DEPStudent_DEPStudentId FOREIGN KEY (DEPStudentId) REFERENCES [users].[DEPStudent] (DEPStudentId),
    CONSTRAINT FK_DEPPayment_PaymentMode_PaymentModeId FOREIGN KEY (PaymentModeId) REFERENCES [lookups].[PaymentMode] (PaymentModeId),
)
