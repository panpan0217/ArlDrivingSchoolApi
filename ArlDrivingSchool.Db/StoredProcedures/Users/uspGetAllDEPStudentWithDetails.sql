CREATE PROCEDURE [users].[uspGetAllDEPStudentWithDetails]
	@StartDate DATETIME2,
	@EndDate DATETIME2
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
		   ,us.CreatedBy
		   ,us.UpdatedBy
		   ,us.LicenseNumber
		   ,us.ExpirationDate
		   ,us.ClassType
		   ,us.SessionEmail
		   ,dss.StatusName [DriveSafeStatus]

		   ,pp.DEPPaymentId
		   ,pp.DEPStudentId
		   ,pp.TotalAmount
		   ,pp.Payment [PaymentAmount]
		   ,pp.Balance

		   ,sso.DEPSessionId
		   ,sso.DEPStudentId
		   ,sso.[Date]
		   ,sso.Schedule
		   ,sso.SessionLocation
		   ,sso.Attended

	FROM users.DEPStudent AS us
			LEFT JOIN payments.DEPPayment AS pp ON pp.DEPStudentId = us.DEPStudentId
			LEFT JOIN [sessions].DEPSession AS sso ON sso.DEPStudentId = us.DEPStudentId
			INNER JOIN lookups.DriveSafeStatus AS dss ON dss.DriveSafeStatusId = us.DriveSafeStatusId
	WHERE  CAST(us.DateRegistered as date) BETWEEN @StartDate AND @EndDate
END
GO;
