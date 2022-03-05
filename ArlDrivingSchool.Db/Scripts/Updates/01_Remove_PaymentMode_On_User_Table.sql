IF COL_LENGTH('users.Student', '[PaymentModeId]') IS NOT NULL
BEGIN


	ALTER TABLE [users].[Student] 
	DROP CONSTRAINT FK_Student_PaymentMode_PaymentModeId

	ALTER TABLE [users].[Student] 
	DROP COLUMN PaymentModeId

END
GO

IF COL_LENGTH('users.DEPStudent', '[PaymentModeId]') IS NOT NULL
BEGIN


	ALTER TABLE [users].[DEPStudent] 
	DROP CONSTRAINT FK_DEPStudent_PaymentMode_PaymentModeId

	ALTER TABLE [users].[DEPStudent] 
	DROP COLUMN PaymentModeId

END
GO

IF COL_LENGTH('users.PDCStudent', '[PaymentModeId]') IS NOT NULL
BEGIN


	ALTER TABLE [users].[PDCStudent] 
	DROP CONSTRAINT FK_PDCStudent_PaymentMode_PaymentModeId

	ALTER TABLE [users].[PDCStudent] 
	DROP COLUMN PaymentModeId

END
GO