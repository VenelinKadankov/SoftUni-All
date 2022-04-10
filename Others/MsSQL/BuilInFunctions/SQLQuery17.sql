SELECT [Name] as [Game] , CASE
            WHEN DATEPART(HOUR, [Start]) < 12
               THEN 'Morning'
			WHEN DATEPART(HOUR, [Start]) < 18
				THEN 'Afternoon'
               ELSE 'Evening'
       END as [Part of the Day],
	   CASE
            WHEN Duration <= 3
               THEN 'Extra Short'
			WHEN Duration <= 6
				THEN 'Short'
			WHEN Duration > 6
				THEN 'Long'
               ELSE 'Extra Long'
       END as [Duration]
	FROM Games
	ORDER BY [Name], [Duration], [Part of the Day]
