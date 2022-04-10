SELECT MountainRange, PeakName, Elevation
	FROM Peaks AS p
	JOIN Mountains m 
	ON
	m.Id = p.MountainId
	WHERE MountainRange = 'Rila'
	ORDER BY Elevation DESC

SELECT * 
	FROM Mountains