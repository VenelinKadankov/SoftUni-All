SELECT COUNT(*) 
	FROM Countries c
	FULL JOIN MountainsCountries ms ON ms.CountryCode = c.CountryCode
	FULL JOIN Mountains m ON m.Id = ms.MountainId
	WHERE m.Id IS NULL
