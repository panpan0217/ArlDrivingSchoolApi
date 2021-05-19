
UPDATE sessions.SessionOne
	SET BranchId = 2
	WHERE BranchId IS NULL

UPDATE sessions.SessionTwo
	SET BranchId = 2
	WHERE BranchId IS NULL

UPDATE sessions.SessionThree
	SET BranchId = 2
	WHERE BranchId IS NULL