--CREATE DATABASE SoftUni

--•	Towns (Id, Name)
--•	Addresses (Id, AddressText, TownId)
--•	Departments (Id, Name)
--•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)


CREATE TABLE Towns 
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50)
)

CREATE TABLE Addresses 
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(100),
	TownId INT
)

CREATE TABLE Departments 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100)
)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50),
	MiddleName VARCHAR(50),
	LastName VARCHAR(50),
	JobTitle VARCHAR(50),
	DepartmentId INT,
	HireDate DATE,
	Salary DECIMAL(15,2),
	AddressId INT
)

