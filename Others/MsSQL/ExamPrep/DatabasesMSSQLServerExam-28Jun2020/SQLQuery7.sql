SELECT COUNT(C.Id)
	FROM Colonists C
	JOIN TravelCards TC ON TC.ColonistId = C.Id
	JOIN Journeys J ON J.Id = TC.JourneyId
	WHERE Purpose = 'Technical'