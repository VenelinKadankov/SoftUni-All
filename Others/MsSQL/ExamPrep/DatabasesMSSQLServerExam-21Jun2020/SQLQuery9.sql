SELECT  A.Id, A.Email, AC.Name, COUNT(T.Id) AS Trips
	FROM AccountsTrips ATR
	JOIN Accounts A ON A.Id = ATR.AccountId
	JOIN Cities AC ON AC.Id = A.CityId
	JOIN Trips T ON T.Id = ATR.TripId
	JOIN Rooms R ON R.Id = T.RoomId
	JOIN Hotels H ON H.Id = R.HotelId
	JOIN Cities HC ON HC.Id = H.CityId
	WHERE HC.Id = AC.Id
	GROUP BY A.Id, A.Email, AC.Name
	ORDER BY Trips DESC, A.Id