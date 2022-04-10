SELECT S.Name, S.Manufacturer
	FROM Journeys J
	JOIN TravelCards TC ON TC.JourneyId = J.Id
	JOIN Colonists C ON C.Id = TC.ColonistId
	JOIN Spaceships S ON S.Id = J.SpaceshipId
	WHERE TC.JobDuringJourney = 'Pilot' AND DATEDIFF(YEAR, C.BirthDate, '01/01/2019') <= 30
	ORDER BY S.Name