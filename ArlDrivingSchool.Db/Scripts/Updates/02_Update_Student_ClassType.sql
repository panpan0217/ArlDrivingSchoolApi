	DECLARE @StudentSessionOne TABLE
	(
		 StudentId     INT,
		 SessionLocation NVARCHAR(50)
	);

	    INSERT INTO @StudentSessionOne
    (
         StudentId,
		 SessionLocation
    )
    SELECT	StudentId, SessionLocation	
	FROM [sessions].SessionOne;

	SELECT * FROM @StudentSessionOne;

	MERGE INTO [users].[Student] AS target
	USING @StudentSessionOne AS source
		ON target.StudentId = source.StudentId
	WHEN MATCHED THEN
		UPDATE SET target.SessionLocation = source.SessionLocation;