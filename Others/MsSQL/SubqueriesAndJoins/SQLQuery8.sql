SELECT 
	e.EmployeeID,
	e.FirstName,
	--p.[Name] AS ProjectName,
	--p.StartDate AS [StartDate],
	CASE
		WHEN DATEPART(YEAR, p.StartDate) < 2005
			THEN p.StartDate
		  ELSE NULL
		END AS ProjectName
	FROM Employees e
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE ep.EmployeeID = 24