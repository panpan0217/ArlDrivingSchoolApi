CREATE PROCEDURE [users].[uspGetAllPDCStudentWithDetailsByFullName]
(
	 @FullName NVARCHAR(164)
)
AS
BEGIN
	SELECT	ups.PDCStudentId
		   ,ups.FullName
		   ,ups.FBContact
		   ,ups.Mobile
		   ,la.StatusName [ACESStatus]
		   ,o.OfficeId
		   ,o.OfficeName
		   ,em.EnrollmentModeId
		   ,em.EnrollmentModeName
		   ,u.UserId
		   ,CONCAT(u.FirstName, ' ', u.LastName) [Staff] 
		   ,pm.PaymentModeName
		   ,t.TransactionId
		   ,t.TransactionName
		   ,ups.RestrictionId [RestrictionCode]
		   ,ups.ATransmissionId
		   ,ups.A1TransmissionId
		   ,ups.BTransmissionId
		   ,ups.B1TransmissionId
		   ,ups.B2TransmissionId
		   ,ups.ACourseId
		   ,ups.A1CourseId
		   ,ups.BCourseId
		   ,ups.B1CourseId
		   ,ups.B2CourseId
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
		   ,pp.PaymentModeId
		   ,pm.PaymentModeName

	FROM users.PDCStudent AS ups
			INNER JOIN lookups.ACESStatus AS la ON la.ACESStatusId = ups.ACESStatusId
			INNER JOIN lookups.EnrollmentMode AS em ON em.EnrollmentModeId = ups.EnrollmentModeId
			LEFT JOIN lookups.Office AS o ON o.OfficeId = ups.OfficeId
			LEFT JOIN users.[User] AS u ON u.UserId = ups.UserId
			--INNER JOIN lookups.Restriction AS r ON r.RestrictionId = ups.RestrictionId
			LEFT JOIN payments.PDCPayment AS pp ON pp.PDCStudentId = ups.PDCStudentId
			LEFT JOIN lookups.PaymentMode AS pm ON pm.PaymentModeId = pp.PaymentModeId
			LEFT JOIN lookups.[Transaction] AS t ON ups.TransactionId = t.TransactionId
	WHERE ups.FullName LIKE '%'+@FullName+'%'
END
