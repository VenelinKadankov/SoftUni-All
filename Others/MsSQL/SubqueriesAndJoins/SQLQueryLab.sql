SELECT TOP(1)
	DepartmentID,
	[Name],
	(SELECT 
		AVG(Salary)
		FROM Employees
		WHERE DepartmentID = d.DepartmentID) AS Average
	FROM Departments d
	ORDER BY Average
