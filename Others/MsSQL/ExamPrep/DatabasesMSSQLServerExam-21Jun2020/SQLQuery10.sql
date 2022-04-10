SELECT T.Id,
	REPLACE(CONCAT(A.FirstName,' ', A.MiddleName, ' ',A.LastName), '  ', ' ') AS FullName,
	AC.Name,
	HC.Name,
	IIF(T.CancelDate IS NOT NULL, 'Canceled', CONCAT(DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate), ' days')) AS Duration
	FROM AccountsTrips ATR
	JOIN Accounts A ON A.Id = ATR.AccountId
	JOIN Cities AC ON AC.Id = A.CityId
	JOIN Trips T ON T.Id = ATR.TripId
	JOIN Rooms R ON R.Id = T.RoomId
	JOIN Hotels H ON H.Id = R.HotelId
	JOIN Cities HC ON HC.Id = H.CityId
	ORDER BY FullName, T.Id