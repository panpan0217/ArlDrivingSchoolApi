﻿CREATE PROCEDURE [users].[uspGetAllPDCStudentWithDetails]

AS
BEGIN
	SELECT	ups.PDCStudentId
		   ,ups.FullName
		   ,ups.FBContact
		   ,ups.Mobile
		   ,la.StatusName [ACESStatus]
		   ,r.RestrictionCode [RestrictionCode]
		   ,t.TransmissionName [TransmissionName]
		   ,ups.Remarks
		   ,ups.DateRegistered

		   ,pp.PDCPaymentId
		   ,pp.PDCStudentId
		   ,pp.TotalAmount
		   ,pp.Payment [PaymentAmount]
		   ,pp.Balance


	FROM users.PDCStudent AS ups
			INNER JOIN lookups.ACESStatus AS la ON la.ACESStatusId = ups.ACESStatusId
			INNER JOIN lookups.Restriction AS r ON r.RestrictionId = ups.RestrictionId
			INNER JOIN lookups.Transmission AS t ON t.TransmissionId = ups.TransmissionId
			LEFT JOIN payments.PDCPayment AS pp ON pp.PDCStudentId = ups.PDCStudentId

END
GO;