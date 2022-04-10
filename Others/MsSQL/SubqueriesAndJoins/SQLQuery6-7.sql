SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DeptName
	FROM Employees e
	LEFT JOIN Departments d ON d.DepartmentID = e.DepartmentID
	WHERE d.[Name] IN ('Sales', 'Finance') AND 
		e.HireDate > '1999-01-01'
	ORDER BY e.HireDate


SELECT TOP(5) 
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS ProjectName
	FROM Employees e
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID = ep.ProjectID
	WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID