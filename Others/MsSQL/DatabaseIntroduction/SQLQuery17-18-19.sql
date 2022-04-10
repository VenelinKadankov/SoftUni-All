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

INSERT INTO Towns (Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

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

INSERT INTO	Departments([Name]) VALUES
('Engineering'), 
('Sales'), 
('Marketing'), 
('Software Development'), 
('Quality Assurance')


CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50),
	MiddleName VARCHAR(50),
	LastName VARCHAR(50),
	JobTitle VARCHAR(50),
	DepartmentId VARCHAR(100),
	HireDate DATE,
	Salary DECIMAL(15,2),
	AddressId INT
)

--DROP TABLE Employees

ALTER TABLE Employees
ADD FOREIGN KEY (AddressId) REFERENCES Addresses(Id)

ALTER TABLE Departments
ADD FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES -- 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 'Software Development', '01/02/2013', 3500.00), --
('Petar','Petrov', 'Petrov', 'Senior Engineer', 'Engineering', '02/03/2004',4000.00),  --
('Maria', 'Petrova', 'Ivanova', 'Intern', 'Quality Assurance', '8/08/2016', 525.25), -- 
('Georgi', 'Teziev', 'Ivanov', 'CEO', 'Sales', '09/12/2007', 3000.00), -- 
('Peter', 'Pan', 'Pan', 'Intern', 'Marketing', '1/08/2016', 599.88) -- 

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees


SELECT *
  FROM Towns
  ORDER BY [Name] DESC

  SELECT *
  FROM Departments
  ORDER BY [Name] DESC

  SELECT *
  FROM Employees
  ORDER BY Salary DESC


SELECT [Name]
  FROM Towns
  --ORDER BY [Name] DESC

SELECT [Name]
  FROM Departments
  --ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary
  FROM Employees
  --ORDER BY Salary DESC


  SELECT *
  FROM Employees

  UPDATE Employees
  SET Salary = Salary * 1.1

  SELECT Salary
  FROM Employees