CREATE PROCEDURE [users].[uspGetAllDEPStudentWithDetailsByFullName]
	@FullName NVARCHAR(164)
AS
BEGIN
	SELECT	us.DEPStudentId
		   ,us.FullName
		   ,us.Email
		   ,us.[Location]
		   ,us.FBContact
		   ,us.Mobile
		   ,us.Remarks
		   ,us.DateRegistered
		   ,us.DateCertified
		   ,us.CreatedBy
		   ,us.UpdatedBy
		   ,us.LicenseNumber
		   ,us.ExpirationDate
		   ,us.ClassType
		   ,us.SessionEmail
		   ,dss.StatusName [DriveSafeStatus]
		   ,us.TextForm
		   ,o.OfficeId
		   ,o.OfficeName
		   ,em.EnrollmentModeId
		   ,em.EnrollmentModeName
		   ,u.UserId
		   ,CONCAT(u.FirstName, ' ', u.LastName) [Staff] 

		   ,pp.DEPPaymentId
		   ,pp.DEPStudentId
		   ,pp.TotalAmount
		   ,pp.Payment [PaymentAmount]
		   ,pp.Balance
		   ,pp.PaymentModeId
		   ,pm.PaymentModeName

		   ,sso.DEPSessionId
		   ,sso.DEPStudentId
		   ,sso.[Date]
		   ,sso.Schedule
		   ,sso.SessionLocation
		   ,sso.Attended

	FROM users.DEPStudent AS us
			LEFT JOIN payments.DEPPayment AS pp ON pp.DEPStudentId = us.DEPStudentId
			LEFT JOIN [sessions].DEPSession AS sso ON sso.DEPStudentId = us.DEPStudentId
			INNER JOIN lookups.EnrollmentMode AS em ON em.EnrollmentModeId = us.EnrollmentModeId
			LEFT JOIN lookups.Office AS o ON o.OfficeId = us.OfficeId
			LEFT JOIN users.[User] AS u ON u.UserId = us.UserId
			LEFT JOIN lookups.PaymentMode AS pm ON pm.PaymentModeId = pp.PaymentModeId
			INNER JOIN lookups.DriveSafeStatus AS dss ON dss.DriveSafeStatusId = us.DriveSafeStatusId
	WHERE  us.FullName LIKE '%'+@FullName+'%';
END
GO;
