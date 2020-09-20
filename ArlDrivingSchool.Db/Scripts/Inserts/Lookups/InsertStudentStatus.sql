SET IDENTITY_INSERT [lookups].[StudentStatus] ON;
GO

INSERT INTO [lookups].[StudentStatus]
(
	 [StudentStatusId]
	,[StatusName]
)
VALUES
 (1, 'PENDING')
,(2, 'In Progress')
,(3, 'WAITING')
,(4, 'NEEDS ATN')
,(5, 'R 4 CERT')
,(6, 'Finished')

SET IDENTITY_INSERT [lookups].[StudentStatus] OFF;
GO