CREATE PROCEDURE [users].[uspGetAllPDCStudentWithDetails]

AS
BEGIN
	SELECT	ups.PDCStudentId
		   ,ups.FullName
		   ,ups.FBContact
		   ,ups.Location
		   ,ups.DateOfBirth
		   ,ups.Mobile
		   ,la.StatusName [ACESStatus]
		   ,ups.RestrictionId [RestrictionCode]
		   ,ups.ATransmissionId
		   ,ups.A1TransmissionId
		   ,ups.BTransmissionId
		   ,ups.B1TransmissionId
		   ,ups.B2TransmissionId
		   ,ups.Remarks
		   ,ups.StudentPermit
		   ,ups.DateRegistered
		   ,ups.Certified
		   ,ups.DateCertified
		   ,ups.CreatedBy
		   ,ups.UpdatedBy
		   ,ups.AuthenticatedBy

		   ,pp.PDCPaymentId
		   ,pp.PDCStudentId
		   ,pp.TotalAmount
		   ,pp.Payment [PaymentAmount]
		   ,pp.Balance


	FROM users.PDCStudent AS ups
			INNER JOIN lookups.ACESStatus AS la ON la.ACESStatusId = ups.ACESStatusId
			--INNER JOIN lookups.Restriction AS r ON r.RestrictionId = ups.RestrictionId
			LEFT JOIN payments.PDCPayment AS pp ON pp.PDCStudentId = ups.PDCStudentId

END
GO;