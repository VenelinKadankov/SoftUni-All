CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN

DECLARE @tripHotelName NVARCHAR(100) = (SELECT TOP(1) Name
	FROM Trips T
	JOIN Rooms R ON R.Id = T.RoomId
	JOIN Hotels H ON H.Id = R.HotelId
	WHERE T.Id = @TripId)

DECLARE @roomHotelName NVARCHAR(100) = (SELECT TOP(1) H.Name 
	FROM Rooms R
	JOIN Hotels H ON H.Id = R.HotelId
	WHERE R.Id = @TargetRoomId)

DECLARE @bedsTargetRoom INT = (SELECT TOP(1) Beds 
	FROM Rooms
	WHERE Id = @TargetRoomId)

DECLARE @bedsNeeded INT = (SELECT COUNT(AccountId) 
	FROM AccountsTrips
	WHERE TripId = @TripId
	GROUP BY TripId)

IF(@tripHotelName != @roomHotelName)
	THROW 50011, 'Target room is in another hotel!', 1;
ELSE IF(@bedsTargetRoom < @bedsNeeded)
	THROW 50012, 'Not enough beds in target room!', 1;

UPDATE Trips
	SET	RoomId = @TargetRoomId
	WHERE Id = @TripId

END
