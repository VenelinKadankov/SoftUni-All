SELECT M.FirstName + ' ' + M.LastName, Status, IssueDate 
	FROM Mechanics M
	JOIN Jobs J ON J.MechanicId = M.MechanicId
	ORDER BY M.MechanicId, J.IssueDate, J.JobId