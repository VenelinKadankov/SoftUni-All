--SELECT DepartmentID, MAX(Salary) AS MaxSalary 
--	FROM Employees
--	WHERE Salary < 30000 OR Salary > 70000
--	GROUP BY DepartmentID

--SELECT COUNT(*) AS [Count]
--	FROM Employees
--	WHERE ManagerID IS NULL