CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(50))
RETURNS DECIMAL
AS
BEGIN
	
	DECLARE @Result DECIMAL(36,2);

	SET @Result = (SELECT SUM(Cash) 
					FROM
						(SELECT Cash, ug.Id, g.[Name] AS [TheName],
						ROW_NUMBER() OVER (ORDER BY Cash DESC) AS Ranking
						FROM UsersGames ug
						JOIN Games g ON g.Id = ug.GameId
						WHERE g.Name = @GameName) AS k
					WHERE Ranking % 2 = 1)

	RETURN @Result

END

GO

SELECT dbo.ufn_CashInUsersGames ('Eucalyptus seeded') AS [SumCash]


--SELECT SUM(Cash) 
--	FROM
--	(SELECT Cash AS Cash,
--	ROW_NUMBER() OVER (ORDER BY Cash DESC) AS Ranking
--	FROM UsersGames) AS k
--	WHERE Ranking % 2 = 1


--SELECT *
--	FROM UsersGames ug
--	JOIN Games g ON g.Id = ug.GameId
	--WHERE g.Name  = 'Love in a mist'

--SELECT *
--	FROM GameTypes

--SELECT Cash, ug.Id, g.[Name] AS [TheName],
--						ROW_NUMBER() OVER (ORDER BY Cash DESC) AS Ranking
--						FROM UsersGames ug
--						JOIN Games g ON g.Id = ug.GameId
--						WHERE g.Name = 'Eucalyptus seeded'