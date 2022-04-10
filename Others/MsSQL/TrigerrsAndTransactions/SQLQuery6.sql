CREATE OR ALTER TRIGGER tr_BuyItemHigherLevelRestricted
ON UserGameItems INSTEAD OF INSERT
AS
	DECLARE @ItemId INT = (SELECT ItemId FROM inserted)
	DECLARE @UserGameId INT = (SELECT UserGameId FROM inserted)

	DECLARE @ItemMinLevel INT = (SELECT MinLevel FROM Items WHERE Id = @ItemId)
	DECLARE @PlayerLevel INT = (SELECT Level FROM UsersGames WHERE Id = @UserGameId)


	IF(@ItemMinLevel <= @PlayerLevel)
	BEGIN 
		INSERT UserGameItems(UserGameId) VALUES (@ItemId)
	END

GO

INSERT INTO UserGameItems (ItemId, UserGameId) VALUES (1, 20)


GO

CREATE OR ALTER PROC udp_AddBonusCashToSomeUsers
AS
BEGIN TRANSACTION
	DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = 'Bali')

	UPDATE UsersGames SET Cash += 50000 WHERE GameId = @GameId and  
		UserId IN (SELECT Id FROM Users
		WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos' ))

COMMIT

EXEC udp_AddBonusCashToSomeUsers

GO

--CREATE OR ALTER PROC up_BuyAndAddIems
--AS
--BEGIN TRANSACTION

--	DECLARE @Counter INT = 251;

--	WHILE(@Counter <= 539)
--	BEGIN

--	IF ((@Counter BETWEEN 251 AND 299) OR (@Counter BETWEEN 501 AND 539))
--	BEGIN
--	INSERT INTO UserGameItems(ItemId, UserGameId) VALUES 
--	(@Counter, 
--	(SELECT Id FROM Users 
--	WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos' )))

--	UPDATE UsersGames SET Cash -= (
--		SELECT Price 
--		FROM Items i
--		JOIN UserGameItems ugi ON ugi.ItemId = i.Id
--		JOIN Users u ON u.Id = ugi.UserGameId
--		WHERE Id = @Counter AND )

--	END

--	SET @Counter += 1;
--	END


--COMMIT


--SELECT * FROM UserGameItems

--SELECT * FROM UsersGames

--SELECT * FROM Items

----SELECT * FROM Games

--SELECT * FROM Users