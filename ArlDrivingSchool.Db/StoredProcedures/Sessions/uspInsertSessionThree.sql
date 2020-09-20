CREATE PROCEDURE [sessions].[uspInsertSessionThree]
(
	@StudentId INT,
	@Time TIME,
	@Branch NVARCHAR(50)
)
AS
BEGIN 
	INSERT INTO [sessions].[SessionThree]
	(
		StudentId,
		SessionDate,
		[Time],
		Branch
	)
	VALUES 
	(
		@StudentId,
		GETUTCDATE(),
		@Time,
		@Branch
	);

	SELECT SCOPE_IDENTITY();
END 
