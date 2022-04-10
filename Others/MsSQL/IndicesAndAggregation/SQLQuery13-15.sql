--SELECT SUM(Salary)
--	FROM Employees
--	GROUP BY DepartmentID
--	ORDER BY DepartmentID



SELECT DepartmentID, MIN(Salary) AS MinimumSalary
	FROM Employees
	WHERE DepartmentID IN (2,5,7) AND HireDate > '2000-01-01'
	GROUP BY DepartmentID



SELECT DepartmentID, AVG(Salary) AS AverageSalary
	FROM
	(SELECT DepartmentID,
		CASE 
			WHEN DepartmentID = 1
				THEN Salary + 5000
			ELSE Salary
		END AS [Salary]
		FROM
			(SELECT *
				FROM Employees
				WHERE Salary > 30000 AND ManagerID != 42) AS k) AS q
	GROUP BY DepartmentID

