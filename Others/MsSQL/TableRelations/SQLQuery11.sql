--SELECT * 
--	FROM Items

--SELECT * 
--	FROM [Statistics]


--SELECT * 
--	FROM ItemTypes


--SELECT i.[Name], StatisticId, it.[Name], s.Id
--	FROM [Statistics] AS s
--	JOIN Items AS i 
--	ON s.Id = i.StatisticId
--	JOIN ItemTypes AS it
--	ON it.Id = i.ItemTypeId

SELECT c.[Name], c.Id, [Level], UserGameId, i.[Name]
	FROM Characters c
	JOIN [Statistics] s ON s.Id = c.StatisticId
	JOIN UsersGames ug ON c.Id = ug.CharacterId
	JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
	JOIN Items i ON ugi.ItemId = i.Id
	WHERE LEFT(i.[Name], 1) = 'B'
	ORDER BY Level DESC
