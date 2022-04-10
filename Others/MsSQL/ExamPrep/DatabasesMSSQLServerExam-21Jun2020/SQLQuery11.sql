CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	--•	“Room {Room Id}: {Room Type} ({Beds} beds) - ${Total Price}”
	DECLARE @result NVARCHAR(MAX) = (SELECT TOP(1) 
	'Room ' + CONVERT(VARCHAR, R.Id) + ': ' + R.Type + ' (' + CONVERT(VARCHAR, R.Beds) + ' beds) - $' 
	+ CONVERT(VARCHAR, (H.BaseRate + R.Price) * @People)
										FROM Rooms R
										JOIN Hotels H ON H.Id = R.HotelId
										WHERE HotelId = @HotelId AND Beds >= @People
										AND NOT EXISTS (SELECT * FROM Trips T WHERE T.RoomId = R.Id AND
										CancelDate IS NULL AND 
										@Date BETWEEN ArrivalDate AND ReturnDate)
										ORDER BY (H.BaseRate + R.Price) * @People DESC)

	IF(@result IS NULL)
		RETURN 'No rooms available'
	RETURN @result
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)