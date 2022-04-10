SELECT FirstName, LastName
	FROM Employees
	WHERE FirstName LIKE 'SA%'


SELECT FirstName, LastName
	FROM Employees
	WHERE LastName LIKE '%ei%'


SELECT FirstName
	FROM Employees
	WHERE DepartmentID IN(3, 10) AND HireDate BETWEEN '1995' AND '2005-12-31' -------UPR


SELECT FirstName, LastName
	FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'


SELECT [Name]
	FROM Towns
	WHERE LEN([Name]) IN(5, 6)
	ORDER BY [Name]



SELECT *
	FROM Towns
	WHERE [Name] LIKE '[M,K,B,E]%'
	ORDER BY [Name]


SELECT *
	FROM Towns
	WHERE [Name] LIKE '[^R,B,D]%'
	ORDER BY [Name]



CREATE VIEW V_EmployeesHiredAfter2000 
	AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE HireDate > '2001'

SELECT *
	FROM V_EmployeesHiredAfter2000 

SELECT * 
	FROM Employees
	WHERE FirstName LIKE 'ST%'


SELECT FirstName, LastName 
	FROM Employees
	WHERE LEN(LastName) = 5

SELECT EmployeeID,
	FirstName,
	LastName,
	Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
	ORDER BY Salary DESC