CREATE PROCEDURE [users].[uspInsertInstructor]
(
	@FullName NVARCHAR(255),
	@Status NVARCHAR(255)
)
AS
BEGIN 
	INSERT INTO [users].[Instructor]
	(
		FullName,
		[Status]
	)
	VALUES 
	(
		@FullName,
		@Status
	);

	
	SELECT SCOPE_IDENTITY();
END 
