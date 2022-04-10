CREATE DATABASE CarRental

--•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
--•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
--•	Employees (Id, FirstName, LastName, Title, Notes)
--•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
--•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, 
--					KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)


CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50),
	DailyRate DECIMAL(10,2),
	WeeklyRate DECIMAL(10,2),
	MonthlyRate DECIMAL(10,2),
	WeekendRate DECIMAL(10,2)
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('samll cars', 10, 60, 200, 25),
('suv', 10, 60, 200, 25),
('limos', 10, 60, 200, 25)


CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(50),
	Model VARCHAR(20),
	CarYear DATE,
	CategoryId INT,
	Doors TINYINT,
	Picture NVARCHAR(MAX),
	Condition VARCHAR(20),
	Available BIT NOT NULL
)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('somePlate', 'audi', 'someAudi', '12/3/2020', 3, 4, 'jsfiejfgkengjk', 'new', 0),
('somePlate', 'audi', 'someAudi', '12/3/2020', 3, 4, 'jsfiejfgkengjk', 'new', 0),
('somePlate', 'audi', 'someAudi', '12/3/2020', 3, 4, 'jsfiejfgkengjk', 'new', 0)


CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50),
	Title VARCHAR(50) NOT NULL, 
	Notes VARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Tosho', 'Toshev', 'seller', 'affd'),
('Tosho', 'Toshev', 'seller', 'affd'),
('Tosho', 'Toshev', 'seller', 'affd')


CREATE TABLE Customers 
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber BIGINT NOT NULL,
	FullName VARCHAR(100) NOT NULL, 
	[Address] VARCHAR(500),
	City VARCHAR(50) NOT NULL,
	ZIPCode INT,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
(19473587394820, 'Tosho Toshev', 'khf', 'Toshovica', 1000, 'svdgxfd'),
(19473587394820, 'Tosho Toshev', 'sjcbfjn', 'Toshovica', 1000, 'svdgxfd'),
(19473587394820, 'Tosho Toshev', 'sfscs', 'Toshovica', 1000, 'svdgxfd')


CREATE TABLE RentalOrders 
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT,
	CustomerId INT,
	CarId INT,
	TankLevel DECIMAL(10,2),
	KilometrageStart DECIMAL(10,1),
	KilometrageEnd DECIMAL(10,1),
	TotalKilometrage DECIMAL(10,1),
	StartDate DATE,
	EndDate DATE,
	TotalDays INT,
	RateApplied DECIMAL(10,2), 
	TaxRate DECIMAL(4,2),
	OrderStatus VARCHAR(100),
	Notes VARCHAR(MAX)
 )

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, 
KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES 
(2, 23, 2455, 40, 20000, 30000, 35000, '10/4/2020', '9/6/2021', 60, 12, 5, 'FINISHED', 'kehgjhbdb'),
(2, 23, 2455, 40, 20000, 30000, 35000, '10/4/2020', '9/6/2021', 70, 12, 5, 'FINISHED', 'kehgjhbdb'),
(2, 23, 2455, 40, 20000, 30000, 35000, '10/4/2020', '9/6/2021', 80, 12, 5, 'FINISHED', 'kehgjhbdb')