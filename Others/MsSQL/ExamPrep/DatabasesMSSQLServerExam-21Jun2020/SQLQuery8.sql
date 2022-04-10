SELECT TOP (10) 
	C.Id,
	C.Name,
	C.CountryCode,
	COUNT(BirthDate) AS [Accounts]
	FROM Cities C
	JOIN Accounts A ON A.CityId = C.Id
	GROUP BY C.Id, C.Name, C.CountryCode
	ORDER BY [Accounts] DESC