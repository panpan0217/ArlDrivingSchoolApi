CREATE PROCEDURE [users].[uspGetStudentWithPaymentByDateRange]
	@StartDate DATETIME2,
	@EndDate DATETIME2
AS
BEGIN
	SELECT	us.StudentId
		   ,us.FirstName
		   ,us.LastName
		   ,us.Email
		   ,us.[Location]
		   ,us.GenderId
		   ,us.DateOfBirth
		   ,us.FBContact
		   ,us.Mobile
		   ,us.AgentName
		   ,us.AcesSaveDate
		   ,us.OfficeId
		   ,us.EnrollmentModeId
		   ,us.OtherEnrollmentMode

		   ,us.CreatedBy
		   ,us.UpdatedBy
			,us.ClassType
		   ,us.SessionEmail

		   ,pp.PaymentId
		   ,pp.StudentId
		   ,pp.TotalAmount
		   ,pp.Payment [PaymentAmount]
		   ,pp.Balance
		   ,pp.PaymentModeId

	FROM users.Student AS us
			LEFT JOIN payments.Payment AS pp ON pp.StudentId = us.StudentId
	WHERE  CAST(us.DateRegistered as date) BETWEEN @StartDate AND @EndDate
END
GO;
