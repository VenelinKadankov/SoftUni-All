SELECT TOP(5)
	EmployeeId,
	JobTitle,
	a.AddressId,
	AddressText
	FROM Employees e
	LEFT JOIN Addresses a ON a.AddressID = e.AddressID
	ORDER BY e.AddressID ASC


SELECT TOP(50)
	e.FirstName,
	e.LastName,
	t.Name AS [Town],
	a.AddressText
	FROM Employees e
	LEFT JOIN Addresses a ON e.AddressID = a.AddressID
	LEFT JOIN Towns t ON a.TownID = t.TownID
	ORDER BY e.FirstName ASC, e.LastName ASC


SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] AS DepartmentName
	FROM Employees e
	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY e.EmployeeID



SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS DepartmentName
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY e.DepartmentID ASC



SELECT TOP(3)
	e.EmployeeID,
	e.FirstName
	FROM Employees e
	LEFT JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	WHERE ep.ProjectID IS NULL
	ORDER BY e.EmployeeID ASC
