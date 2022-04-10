CREATE OR ALTER PROC usp_EmployeesBySalaryLevel(@LevelOfSalary NVARCHAR(20))
AS

	SELECT FirstName, LastName
		FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary

GO

EXEC usp_EmployeesBySalaryLevel 'High'


