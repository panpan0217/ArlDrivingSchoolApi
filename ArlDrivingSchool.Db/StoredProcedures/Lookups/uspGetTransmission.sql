CREATE PROCEDURE [lookups].[uspGetTransmission]
AS
BEGIN
	SELECT	TransmissionId
		   ,TransmissionName

	FROM lookups.Transmission

END
GO;