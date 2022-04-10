CREATE TABLE Majors 
(
	MajorID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50)

)

CREATE TABLE Subjects 
(
	SubjectID INT IDENTITY PRIMARY KEY,
	SubjectName VARCHAR(50)

)


CREATE TABLE Students 
(
	StudentID INT IDENTITY PRIMARY KEY,
	StudentNumber NVARCHAR(10),
	StudentName VARCHAR(50),
	MajorID INT REFERENCES Majors(MajorID)

)


CREATE TABLE Payments 
(
	PaymentID INT IDENTITY PRIMARY KEY,
	PaymentDate DATE,
	PaymentAmount DECIMAL(15,2),
	StudentID INT REFERENCES Students(StudentID)

)


CREATE TABLE Agenda 
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID),
	CONSTRAINT PK_Agenda
	PRIMARY KEY (StudentID, SubjectID)

)