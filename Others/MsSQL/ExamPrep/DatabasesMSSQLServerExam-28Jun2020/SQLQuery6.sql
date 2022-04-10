SELECT C.Id, CONCAT(C.FirstName, ' ', C.LastName)
	FROM Colonists C
	JOIN TravelCards TC ON TC.ColonistId = C.Id
	WHERE JobDuringJourney = 'Pilot'
	ORDER BY C.Id