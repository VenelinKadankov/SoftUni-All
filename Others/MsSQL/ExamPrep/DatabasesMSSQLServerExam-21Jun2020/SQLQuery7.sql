SELECT A.Id,
	A.FirstName + ' ' + A.LastName,
	MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS [LongestTrip],
	MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS [ShortestTrip]
	FROM Accounts A
	JOIN AccountsTrips ATR ON A.Id = ATR.AccountId
	JOIN Trips T ON T.Id = ATR.TripId
	WHERE A.MiddleName IS NULL AND T.CancelDate IS NULL
	GROUP BY A.Id, (A.FirstName + ' ' + A.LastName)
	ORDER BY [LongestTrip] DESC, [ShortestTrip]