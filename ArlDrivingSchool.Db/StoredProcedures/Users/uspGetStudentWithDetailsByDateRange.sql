CREATE PROCEDURE [users].[uspGetStudentWithDetailsByDateRange]
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
		   ,ls.StatusName [StudentStatus]
		   ,la.StatusName [ACESStatus]
		   ,lt.StatusName [TDCStatus]
		   ,o.OfficeId
		   ,o.OfficeName
		   ,em.EnrollmentModeId
		   ,em.EnrollmentModeName
		   ,us.OtherEnrollmentMode
		   ,u.UserId
		   ,ps.PDCStudentId
		   ,CONCAT(u.FirstName, ' ', u.LastName) [Staff] 

		   ,us.Remarks
		   ,us.DateRegistered
		   ,us.Certified
		   ,us.DateCertified
		   ,us.AuthenticatedBy
		   ,us.CreatedBy
		   ,us.UpdatedBy
			,us.ClassType
		   ,us.SessionEmail
		   ,dss.StatusName [DriveSafeStatus]
		   ,us.TextForm

		   ,pp.PaymentId
		   ,pp.StudentId
		   ,pp.TotalAmount
		   ,pp.Payment [PaymentAmount]
		   ,pp.Balance
		   ,pp.PaymentModeId
		   ,pm.PaymentModeName

		   ,sso.SessionOneId
		   ,sso.StudentId
		   ,sso.SessionDate
		   ,sso.Schedule
		   ,sso.Shuttle
		   ,sso.SessionLocation
		   ,sso.Attended
		   ,sso.BranchId
		   ,(SELECT BranchName FROM [lookups].Branch WHERE BranchId = sso.BranchId) AS BranchName

		   ,sstw.SessionTwoId
		   ,sstw.StudentId
		   ,sstw.SessionDate
		   ,sstw.Schedule
		   ,sstw.Shuttle
		   ,sstw.SessionLocation
		   ,sstw.Attended
		   ,sstw.BranchId
		   ,(SELECT BranchName FROM [lookups].Branch WHERE BranchId = sstw.BranchId) AS BranchName

		   ,ssth.SessionThreeId
		   ,ssth.StudentId
		   ,ssth.SessionDate
		   ,ssth.Schedule
		   ,ssth.Shuttle
		   ,ssth.SessionLocation
		   ,ssth.Attended
		   ,ssth.BranchId
		   ,(SELECT BranchName FROM [lookups].Branch WHERE BranchId = ssth.BranchId) AS BranchName

	FROM users.Student AS us
			INNER JOIN lookups.StudentStatus AS ls ON ls.StudentStatusId = us.StudentStatusId
			INNER JOIN lookups.ACESStatus AS la ON la.ACESStatusId = us.ACESStatusId
			INNER JOIN lookups.TDCStatus AS lt ON lt.TDCStatusId = us.TDCStatusId
			INNER JOIN lookups.EnrollmentMode AS em ON em.EnrollmentModeId = us.EnrollmentModeId
			LEFT JOIN lookups.Office AS o ON o.OfficeId = us.OfficeId
			LEFT JOIN users.[User] AS u ON u.UserId = us.UserId
			LEFT JOIN lookups.DriveSafeStatus AS dss ON dss.DriveSafeStatusId = us.DriveSafeStatusId
			LEFT JOIN payments.Payment AS pp ON pp.StudentId = us.StudentId
			LEFT JOIN lookups.PaymentMode AS pm ON pm.PaymentModeId = pp.PaymentModeId
			LEFT JOIN [sessions].SessionOne AS sso ON sso.StudentId = us.StudentId
			LEFT JOIN [sessions].SessionTwo AS sstw ON sstw.StudentId = us.StudentId
			LEFT JOIN [sessions].SessionThree AS ssth ON ssth.StudentId = us.StudentId
			LEFT JOIN [users].PDCStudent AS ps ON ps.StudentId = us.StudentId
	WHERE  CAST(us.DateRegistered as date) BETWEEN @StartDate AND @EndDate
END
GO;
