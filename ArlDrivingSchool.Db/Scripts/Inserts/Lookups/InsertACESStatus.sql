SET IDENTITY_INSERT [lookups].[ACESStatus] ON;
GO

INSERT INTO [lookups].[ACESStatus]
(
	 [ACESStatusId]
	,[StatusName]
)
VALUES
 (1, 'No Record')
,(2, 'Registered')
,(3, 'Authenticated')
,(4, 'Printed')
,(5, 'Ceriticated')

SET IDENTITY_INSERT [lookups].[ACESStatus] OFF;
GO