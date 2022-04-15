CREATE PROCEDURE [lookups].[uspGetTransaction]
AS
BEGIN
	SELECT	TransactionId
		   ,TransactionName

	FROM lookups.[Transaction]

END
GO;