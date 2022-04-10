CREATE TABLE Passports
(
	PassportID INT IDENTITY(101,1) PRIMARY KEY,
	PassportNumber CHAR(8)
)

CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50),
	Salary DECIMAL(15,2),
	PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

--DROP TABLE Persons
--DROP TABLE Passports

INSERT INTO Passports(PassportNumber) VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')


INSERT INTO Persons VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)

SELECT * 
	FROM Persons