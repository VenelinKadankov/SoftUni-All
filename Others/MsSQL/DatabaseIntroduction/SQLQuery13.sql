CREATE DATABASE Movies
 

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName VARCHAR(200) NOT NULL,
	Notes VARCHAR(MAX)
)

--DROP TABLE Directors

INSERT INTO Directors(DirectorName, Notes) VALUES 
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi')


CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName VARCHAR(200) NOT NULL,
	Notes VARCHAR(MAX)
)

--DROP TABLE Genres

INSERT INTO Genres(GenreName, Notes)
VALUES 
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi')


CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(200) NOT NULL,
	Notes VARCHAR(MAX)
)

--DROP TABLE Categories

INSERT INTO Categories(CategoryName, Notes)
VALUES 
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi'),
('Pesho', 'pfiowjfi')



CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	Title VARCHAR(200) NOT NULL, 
	DirectorId INT, 
	CopyrightYear INT, 
	[Length] REAL, 
	GenreId INT, 
	CategoryId INT, 
	Rating REAL NOT NULL, 
	Notes VARCHAR(MAX)
)

--DROP TABLE Movies

ALTER TABLE Movies
ADD FOREIGN KEY (DirectorId) REFERENCES Directors(Id)

ALTER TABLE Movies
ADD FOREIGN KEY (GenreId) REFERENCES Genres(Id)

ALTER TABLE Movies
ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id)

INSERT INTO Movies(Title, CopyrightYear, [Length], Rating, Notes)
VALUES 
('Pesho', 2019, 135.4, 7.4, 'pfiowjfi'),
('Pesho', 2019, 135.4, 7.4, 'pfiowjfi'),
('Pesho', 2019, 135.4, 7.4, 'pfiowjfi'),
('Pesho', 2019, 135.4, 7.4, 'pfiowjfi'),
('Pesho', 2019, 135.4, 7.4, 'pfiowjfi')


