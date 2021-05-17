CREATE TABLE [lookups].[Branch]
(
	[BranchId]			INT				NOT NULL IDENTITY(1,1),
	[BranchName]		NVARCHAR(64)	NOT NULL,
	CONSTRAINT [PK_Branch] PRIMARY KEY CLUSTERED ([BranchId] ASC)
)
