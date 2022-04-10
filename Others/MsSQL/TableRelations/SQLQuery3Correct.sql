CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50)
)

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101,1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50)
)



--DROP TABLE StudentsExams

INSERT INTO Students([Name])
	VALUES
	('Mila'),                                      
	('Toni'),
	('Ron')


INSERT INTO Exams([Name])
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')
	

CREATE TABLE StudentsExams
(
	StudentID INT REFERENCES Students(StudentID),
	ExamID	INT REFERENCES Exams(ExamID),
	CONSTRAINT PK_StudentsExams
	PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO StudentsExams(StudentID,ExamID)
	VALUES
	(1,	101),
	(1,	102),
	(2,	101),
	(3,	103),
	(2,	102),
	(2,	103)


--DROP TABLE StudentsExams

SELECT *
	FROM StudentsExams