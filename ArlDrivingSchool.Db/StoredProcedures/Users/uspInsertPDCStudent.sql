CREATE PROCEDURE [users].[uspInsertPDCStudent]
(
	@FullName NVARCHAR(255),
	@FBContact NVARCHAR(255),
	@Mobile NVARCHAR(64),
	@ACESStatusId INT,
	@Remarks NVARCHAR(255)
)
AS
BEGIN 
	INSERT INTO [users].[PDCStudent]
	(
		DateRegistered,
		FullName,
		FBContact,
		Mobile,
		ACESStatusId,
		Remarks
	)
	VALUES 
	(
		GETUTCDATE(),
		@FullName,
		@FBContact,
		@Mobile,
		@ACESStatusId,
		@Remarks
	);

	SELECT SCOPE_IDENTITY();
END 