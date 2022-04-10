CREATE TABLE Teachers
(
	TeacherID INT IDENTITY(101, 1) PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50),
	ManagerID INT REFERENCES Teachers(TeacherID) NULL

)

INSERT INTO Teachers([Name], ManagerID)
	VALUES
	('John',NULL),
	('Maya',106 ),
	('Silvia',106 ),
	('Ted',105 ),
	('Mark',101 ),
	('Greta',101 )
			  