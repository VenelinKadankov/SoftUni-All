SELECT TOP(50) 
	e.EmployeeID,
	e.[FirstName] + ' ' + e.[LastName] AS EmployeeName,
	m.[FirstName] + ' ' + m.[LastName] AS ManagerName,
	d.[Name] AS DepartmentName,
	m.DepartmentID
	FROM Employees e
	LEFT JOIN Employees m ON m.EmployeeID = e.ManagerID
	LEFT JOIN Departments d ON d.DepartmentID = e.DepartmentID	
	ORDER BY e.EmployeeID



SELECT *
	FROM Departments