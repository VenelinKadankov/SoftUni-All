SELECT P.Name, COUNT(J.DestinationSpaceportId) AS JourneyCount
	FROM Planets P
	JOIN Spaceports SP ON SP.PlanetId = P.Id
	JOIN Journeys J ON J.DestinationSpaceportId = SP.Id
	GROUP BY P.Name
	ORDER BY JourneyCount DESC, P.Name