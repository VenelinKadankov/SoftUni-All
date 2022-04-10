SELECT m.MountainRange, p.PeakName, p.Elevation 
	FROM Peaks p
	JOIN Mountains m ON p.MountainId = m.Id
	WHERE M.MountainRange = 'Rila'
	ORDER BY P.Elevation DESC