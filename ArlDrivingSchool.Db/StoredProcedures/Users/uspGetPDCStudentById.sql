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
			[ATransmissionId],
			[A1TransmissionId],
			[BTransmissionId],
			[B1TransmissionId],
			[B2TransmissionId],
			Remarks
	FROM [users].PDCStudent
	WHERE PDCStudentId = @Id
GO