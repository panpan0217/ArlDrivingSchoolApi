CREATE PROCEDURE [sessions].[uspInsertSessionThree]
(
	@StudentId INT,
	@Branch NVARCHAR(50)
)
AS
BEGIN 
	INSERT INTO [sessions].[SessionThree]
	(
		StudentId,
		SessionDate,
		Branch
	)
	VALUES 
	(
		@StudentId,
		GETUTCDATE(),
		@Branch
	);

	SELECT SCOPE_IDENTITY();
END 
