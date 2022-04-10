--SELECT DepartmentID,
--	MIN(Salary)
--	FROM (SELECT DepartmentID, Salary,
--				DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranking]
--				FROM Employees) AS k
--				WHERE Ranking = 3 OR Ranking IS NULL	
--	GROUP BY DepartmentID


--SELECT DISTINCT DepartmentID, Salary
--	FROM (SELECT DepartmentID, Salary,
--				DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranking]
--				FROM Employees) AS k
--				WHERE Ranking = 3 OR Ranking IS NULL	


SELECT TOP (10) FirstName, LastName, e.DepartmentID 
	FROM Employees e
	JOIN (SELECT DepartmentID, AVG(Salary) AS AverageSalary
		FROM Employees
		GROUP BY DepartmentID) AS k ON k.DepartmentID = e.DepartmentID
	WHERE e.Salary > k.AverageSalary
	ORDER BY e.DepartmentID


SELECT TOP (10) FirstName, LastName, DepartmentID, Salary
	FROM Employees e
	WHERE Salary > (SELECT AVG(Salary) 
					FROM Employees
					WHERE DepartmentID = e.DepartmentID
					GROUP BY DepartmentID)
ORDER BY DepartmentID