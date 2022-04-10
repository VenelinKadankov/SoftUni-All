SELECT p.ProjectID, p.[Name], p.[Description], FirstName, LastName, JobTitle, d.[Name]
	FROM Projects p
	JOIN EmployeesProjects ep ON p.ProjectID = ep.ProjectID
	JOIN Employees e ON ep.EmployeeID = e.EmployeeID
	JOIN Departments d ON d.ManagerID = e.ManagerID
	JOIN Addresses a ON a.AddressID = e.AddressID
	WHERE LEFT(d.[Name], 1) = 'E'
	ORDER BY ProjectID