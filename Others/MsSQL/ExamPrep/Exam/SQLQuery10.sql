SELECT	IIF(CONCAT(E.FirstName, ' ', E.LastName) = ' ', 'None',  CONCAT(E.FirstName, ' ', E.LastName))  AS EmployeeName,
	IIF(D.Name IS NULL, 'None', D.Name) AS Department,
	IIF(C.Name IS NULL, 'None', C.Name) AS Category,
	IIF(Description IS NULL, 'None', Description) AS Description,
	IIF(R.OpenDate IS NULL, 'None', FORMAT(R.OpenDate, 'dd.MM.yyyy')) AS OpenDate,
	IIF(S.Label IS NULL, 'None', S.Label) AS Label,
	IIF(U.Name IS NULL, 'None', U.Name) AS [User]
	FROM Reports r
	left JOIN Users u ON u.Id = R.UserId
	left JOIN Status S ON s.Id = r.StatusId
	left JOIN Employees e ON e.Id = r.EmployeeId
	left JOIN Categories c ON c.Id = r.CategoryId
	left JOIN Departments d ON d.Id = e.DepartmentId
	ORDER BY E.FirstName + ' ' + E.LastName DESC, D.Name , C.Name , Description, R.OpenDate, S.Label, U.Name