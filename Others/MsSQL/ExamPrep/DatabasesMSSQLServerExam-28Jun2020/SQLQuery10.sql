SELECT Ranking.JobDuringJourney,
	Ranking.FullName,
	[Ranking].[Rank]
	FROM (SELECT TC.JobDuringJourney
				,(C.FirstName + ' ' + C.LastName) AS FullName,
				DENSE_RANK() OVER (PARTITION BY TC.JobDuringJourney ORDER BY C.BirthDate) AS [Rank]
				FROM Colonists C
				JOIN TravelCards TC ON TC.ColonistId = C.Id) AS [Ranking]
	WHERE [Ranking].[Rank] = 2
