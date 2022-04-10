--SELECT 
--	c.CountryCode,
--	m.MountainRange,
--	p.PeakName,
--	p.Elevation
--	FROM Peaks p
--	JOIN Mountains m ON m.Id = p.MountainId
--	JOIN MountainsCountries mc ON mc.MountainId = m.Id
--	JOIN Countries c ON c.CountryCode = mc.CountryCode
--	WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
--	ORDER BY p.Elevation DESC



SELECT 
	c.CountryCode,
	COUNT(m.MountainRange) AS [MountainRanges]
	FROM Mountains m 
	JOIN MountainsCountries mc ON mc.MountainId = m.Id
	JOIN Countries c ON c.CountryCode = mc.CountryCode
	WHERE c.CountryCode IN ('BG', 'RU', 'US')
	GROUP BY(c.CountryCode)


