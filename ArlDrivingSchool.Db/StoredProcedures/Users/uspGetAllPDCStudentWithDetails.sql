CREATE PROCEDURE [users].[uspGetAllPDCStudentWithDetails]

AS
BEGIN
	SELECT	ups.PDCStudentId
		   ,ups.FullName
		   ,ups.FBContact
		   ,ups.Mobile
		   ,la.StatusName [ACESStatus]
		   ,ups.Remarks
		   ,ups.DateRegistered

		   ,pp.PDCPaymentId
		   ,pp.PDCStudentId
		   ,pp.TotalAmount
		   ,pp.Payment [PaymentAmount]
		   ,pp.Balance

		   ,sso.PDCSessionOneId
		   ,sso.PDCStudentId
		   ,sso.[Date]
		   ,sso.StartTime
		   ,sso.EndTime
		   ,sso.Attended

		   ,sstw.PDCSessionTwoId
		   ,sstw.PDCStudentId
		   ,sstw.[Date]
		   ,sstw.StartTime
		   ,sstw.EndTime
		   ,sstw.Attended

		   ,ssth.PDCSessionThreeId
		   ,ssth.PDCStudentId
		   ,ssth.[Date]
		   ,ssth.StartTime
		   ,ssth.EndTime
		   ,ssth.Attended

		   ,ssf.PDCSessionFourId
		   ,ssf.PDCStudentId
		   ,ssf.[Date]
		   ,ssf.StartTime
		   ,ssf.EndTime
		   ,ssf.Attended

	FROM users.PDCStudent AS ups
			INNER JOIN lookups.ACESStatus AS la ON la.ACESStatusId = ups.ACESStatusId
			LEFT JOIN payments.PDCPayment AS pp ON pp.PDCStudentId = ups.PDCStudentId
			LEFT JOIN [sessions].PDCSessionOne AS sso ON sso.PDCStudentId = ups.PDCStudentId
			LEFT JOIN [sessions].PDCSessionTwo AS sstw ON sstw.PDCStudentId = ups.PDCStudentId
			LEFT JOIN [sessions].PDCSessionThree AS ssth ON ssth.PDCStudentId = ups.PDCStudentId
			LEFT JOIN [sessions].PDCSessionFour AS ssf ON ssf.PDCStudentId = ups.PDCStudentId
END
GO;