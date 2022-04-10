CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS

	ALTER TABLE Departments ALTER COLUMN ManagerID INT NULL
	DELETE FROM Employees WHERE DepartmentID = @departmentId 
	DELETE FROM Departments WHERE DepartmentID = @departmentId


	SELECT COUNT(*)
		FROM Employees
		WHERE DepartmentID = @departmentId


GO

EXEC usp_DeleteEmployeesFromDepartment 3
	