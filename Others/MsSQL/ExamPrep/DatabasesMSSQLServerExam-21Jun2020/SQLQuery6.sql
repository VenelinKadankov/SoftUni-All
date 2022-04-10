SELECT C.Name, COUNT(H.Name) AS [Count]
	FROM Cities C
	JOIN Hotels H ON H.CityId = C.Id
	GROUP BY CityId, C.Name
	ORDER BY [Count] DESC, C.Name