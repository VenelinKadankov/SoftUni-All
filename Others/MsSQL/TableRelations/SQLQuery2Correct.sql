CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(10),
	EstablishedOn DATE
)

CREATE TABLE Models
(
	ModelID INT IDENTITY(101,1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(10),
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerID)
)


INSERT INTO Manufacturers([Name], EstablishedOn) 
	VALUES
	('BMW', '07/03/1916'),
	('Tesla',	'01/01/2003'),
	('Lada',	'01/05/1966')

INSERT INTO Models([Name]) 
	VALUES
	('X1'),
	('i6'),
	('Model S'),
	('Model X'),
	('Model 3'),
	('Nova')

