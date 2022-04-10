SELECT top (5) q.CountryName, q.[Highest Peak Name], q.[Highest Peak Elevation], q.Mountain
	FROM (SELECT
	c.CountryName,
	ISNULL(p.PeakName,'(no highest peak)') AS [Highest Peak Name],
	ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation],
	ISNULL(m.MountainRange, '(no mountain)') AS Mountain,
	DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranking
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	GROUP BY CountryName, p.PeakName, m.MountainRange, p.Elevation) AS Q
	WHERE Ranking = 1
	ORDER BY CountryName, [Highest Peak Name]
