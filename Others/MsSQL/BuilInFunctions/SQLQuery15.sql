SELECT Username, RIGHT(Email, LEN(Email) - CHARINDEX('@',Email)) AS EmailProvider
	FROM [Users]
	ORDER BY EmailProvider, UserName