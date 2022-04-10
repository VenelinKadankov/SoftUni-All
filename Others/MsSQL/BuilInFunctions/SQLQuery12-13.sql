SELECT CountryName, IsoCode
	FROM Countries
	WHERE CountryName LIKE '%A%A%A%'
	ORDER BY IsoCode


--SELECT PeakName, RiverName , LOWER(PeakName) + LOWER(RiverName) AS [Mix]
--	FROM Peaks
--	JOIN Mountains ON Mountains.Id = Peaks.MountainId
--	JOIN MountainsCountries ON MountainsCountries.MountainId = Mountains.Id
--	JOIN Countries ON Countries.CountryCode = MountainsCountries.CountryCode
--	JOIN CountriesRivers ON CountriesRivers.CountryCode = Countries.CountryCode
--	JOIN Rivers ON Rivers.Id = CountriesRivers.RiverId
--	--WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
--	ORDER BY Mix


SELECT PeakName, RiverName, LOWER(LEFT(PeakName, LEN(PeakName) - 1)) + LOWER(RiverName) AS Mix
	FROM Peaks, Rivers
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix








