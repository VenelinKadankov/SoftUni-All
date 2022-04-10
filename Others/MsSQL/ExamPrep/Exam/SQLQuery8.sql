SELECT U.Username, C.Name
	FROM Users U
	JOIN Reports R ON R.UserId = U.Id
	JOIN Categories C ON C.Id = R.CategoryId
	WHERE DATEPART(MONTH,Birthdate) = DATEPART(MONTH,R.OpenDate) AND DATEPART(DAY,Birthdate) = DATEPART(DAY,R.OpenDate)
	ORDER BY U.Username, C.Name