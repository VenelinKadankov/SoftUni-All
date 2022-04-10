CREATE DATABASE Hotel

--•	Employees (Id, FirstName, LastName, Title, Notes)
--•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
--•	RoomStatus (RoomStatus, Notes)
--•	RoomTypes (RoomType, Notes)
--•	BedTypes (BedType, Notes)
--•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
--•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
--•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)


CREATE TABLE Employees 
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Title VARCHAR(50),
	Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
(10, 'R', 'T', 'SGGE', 'sggfd'),
(11, 'R', 'T', 'SGGE', 'sggfd'),
(12, 'R', 'T', 'SGGE', 'sggfd')

CREATE TABLE Customers 
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	PhoneNumber BIGINT,
	EmergencyName VARCHAR(100),
	EmergencyNumber BIGINT,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
(241, 'D', 'F', 1234567899, 'SF', 12345567899, 'SFDGC'),
(242, 'D', 'F', 1234567899, 'SF', 12345567899, 'SFDGC'),
(243, 'D', 'F', 1234567899, 'SF', 12345567899, 'SFDGC')

CREATE TABLE RoomStatus 
(
	RoomStatus BIT,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
(0, 'SJFGYS'),
(1, 'SJFGYS'),
(2, 'SJFGYS')

CREATE TABLE RoomTypes 
(
	RoomType VARCHAR(50),
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
('SGFBD', 'SFGDGS'),
('SGFBD', 'SFGDGS'),
('SGFBD', 'SFGDGS')

CREATE TABLE BedTypes 
(
	BedType VARCHAR(50),
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
('SGFBD', 'SFGDGS'),
('SGFBD', 'SFGDGS'),
('SGFBD', 'SFGDGS')

CREATE TABLE Rooms 
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(50), 
	BedType VARCHAR(50), 
	Rate DECIMAL(10,2),
	RoomStatus BIT,
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms VALUES
(21, 'SJFDNF', 'WSFEDF', 20, 1, 'KVSHDGKSDJNV'),
(20, 'SJFDNF', 'WSFEDF', 20, 1, 'KVSHDGKSDJNV'),
(22, 'SJFDNF', 'WSFEDF', 20, 1, 'KVSHDGKSDJNV')


CREATE TABLE Payments 
(
	Id INT PRIMARY KEY,
	EmployeeId INT,
	PaymentDate DATE,
	AccountNumber VARCHAR(50),
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged DECIMAL(10,2),
	TaxRate DECIMAL(10,2),
	TaxAmount DECIMAL(10,2),
	PaymentTotal DECIMAL(10,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments VALUES
(1, 21, '2/5/1900', 'AFSGSGH', '2/5/1900', '2/5/1900', 34, 32, 2, 5, 50, 'SJVBDHBV'),
(2, 23, '2/5/1900', 'AFSGSGH', '2/5/1900', '2/5/1900', 34, 32, 2, 5, 50, 'SJVBDHBV'),
(3, 22, '2/5/1900', 'AFSGSGH', '2/5/1900', '2/5/1900', 34, 32, 2, 5, 50, 'SJVBDHBV')

CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY,
	EmployeeId INT,
	DateOccupied DATE,
	AccountNumber VARCHAR(100),
	RoomNumber INT,
	RateApplied DECIMAL(10,2),
	PhoneCharge DECIMAL(10,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1, 4, '6/8/1900', 'FDGDFD', 5, 6, 7, 'FSYGBS'),
(2, 4, '6/8/1900', 'FDGDFD', 5, 6, 7, 'FSYGBS'),
(3, 4, '6/8/1900', 'FDGDFD', 5, 6, 7, 'FSYGBS')