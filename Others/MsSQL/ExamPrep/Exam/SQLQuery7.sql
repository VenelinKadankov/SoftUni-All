SELECT TOP(5) C.Name, COUNT(C.Id) AS [Count]
	FROM Categories C
	JOIN Reports R ON R.CategoryId = C.Id
	GROUP BY C.Name
	ORDER BY [Count] DESC, C.Name