SELECT m.FirstName + ' ' + m.LastName 
	FROM Mechanics m
	LEFT JOIN Jobs j ON j.MechanicId = j.MechanicId
	WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
						FROM Jobs
						WHERE Status != 'Finished' AND MechanicId = m.MechanicId
						GROUP BY MechanicId, Status) IS NULL
	GROUP BY m.MechanicId, (m.FirstName + ' ' + m.LastName )
						 

