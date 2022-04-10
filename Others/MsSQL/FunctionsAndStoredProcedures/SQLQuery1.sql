--CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000
--AS
--	(SELECT FirstName AS [First Name], LastName AS [Last Name]
--		FROM Employees
--		WHERE Salary > 35000)
--GO

----EXEC usp_GetEmployeesSalaryAbove35000


--CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber (@Amount DECIMAL(18,4))
--AS
--	SELECT FirstName AS [First Name], LastName AS [Last Name]
--		FROM Employees
--		WHERE Salary > @Amount

--GO

--EXEC usp_GetEmployeesSalaryAboveNumber 48100


--CREATE OR ALTER PROC usp_GetTownsStartingWith (@Text NVARCHAR(20))
--AS
--	SELECT [Name] AS [Town]
--		FROM Towns
--		WHERE [Name] LIKE (@Text + '%')
--		--WHERE LEFT(Name, 1) = @Text 

--GO


--EXEC usp_GetTownsStartingWith 'B'


--CREATE OR ALTER PROC usp_GetEmployeesFromTown(@TownName NVARCHAR(20))
--AS
--	SELECT e.FirstName AS [First Name], e.LastName AS [Last Name]
--		FROM Employees e
--		JOIN Addresses a ON a.AddressID = e.AddressID
--		JOIN Towns t ON t.TownID = a.TownID
--		WHERE t.Name = @TownName
--GO


--EXEC usp_GetEmployeesFromTown 'Sofia'


CREATE OR ALTER FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS VARCHAR(100)
AS
BEGIN
	IF @salary IS NULL OR @salary < 0
		RETURN NULL

	IF @salary < 30000
		RETURN 'Low'
	ELSE IF @salary <= 50000
		RETURN 'Average'
	
	RETURN 'High'

END

GO

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
	FROM Employees