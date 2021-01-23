CREATE PROCEDURE [users].[uspGetPDCStudentById]
	@Id int
AS
	SELECT	[PDCStudentId],
			[DateRegistered],
			FullName,
			[FBContact],
			[Mobile],
			[ACESStatusId],
			[RestrictionId],
			[TransmissionId],
			Remarks
	FROM [users].PDCStudent
	WHERE PDCStudentId = @Id
GO