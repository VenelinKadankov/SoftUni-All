CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
BEGIN
	DECLARE @employeeDepartmentId INT;
		SET @employeeDepartmentId = (SELECT TOP(1) DepartmentId 
	FROM Employees
	WHERE Id = @EmployeeId)

	DECLARE @reportDepartmentId INT;
		SET @reportDepartmentId = (SELECT TOP(1) DepartmentId 
	FROM Reports R
	JOIN Categories C ON C.Id = R.CategoryId
	JOIN Departments D ON D.Id = C.DepartmentId
	WHERE R.Id = @ReportId)

IF(@employeeDepartmentId != @reportDepartmentId)
	THROW 50011, 'Employee doesn''t belong to the appropriate department!', 1;

UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId

END

GO

EXEC usp_AssignEmployeeToReport 17, 2
EXEC usp_AssignEmployeeToReport 30, 1

--DECLARE @EmployeeId INT = 30 
--DECLARE @ReportId INT = 1

--SELECT TOP(1) DepartmentId 
--	FROM Employees
--	WHERE Id = @EmployeeId

--SELECT TOP(1) DepartmentId 
--	FROM Reports R
--	JOIN Categories C ON C.Id = R.CategoryId
--	JOIN Departments D ON D.Id = C.DepartmentId
--	WHERE R.Id = @ReportId