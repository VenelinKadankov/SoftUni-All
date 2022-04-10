SELECT E.FirstName + ' ' + E.LastName, COUNT(U.Id) AS [Count]
	FROM Employees E
	LEFT JOIN Reports R ON R.EmployeeId = E.Id
	LEFT JOIN USERS U ON U.Id = R.UserId
	GROUP BY (E.FirstName + ' ' + E.LastName)
	ORDER BY [Count] DESC, (E.FirstName + ' ' + E.LastName)