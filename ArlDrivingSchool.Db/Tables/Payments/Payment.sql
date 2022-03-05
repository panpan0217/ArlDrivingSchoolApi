CREATE TABLE [payments].[Payment]
(
	[PaymentId] INT NOT NULL IDENTITY(1,1), 
    [StudentId] INT NOT NULL, 
    [PaymentDate] DATETIME2 NOT NULL, 
    [TotalAmount] INT NOT NULL, 
    [Payment] INT NOT NULL,
    [Balance] INT NOT NULL,
    [PaymentModeId]			INT				NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED ([PaymentId] ASC),
    CONSTRAINT FK_Payment_Student_StudentId FOREIGN KEY (StudentId) REFERENCES [users].[Student] (StudentId),
	CONSTRAINT FK_Payment_PaymentMode_PaymentModeId FOREIGN KEY (PaymentModeId) REFERENCES [lookups].[PaymentMode] (PaymentModeId),
)
