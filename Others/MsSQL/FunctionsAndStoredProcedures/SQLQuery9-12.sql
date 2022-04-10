--CREATE OR ALTER PROC usp_GetHoldersFullName
--AS
--	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name] 
--	FROM AccountHolders

--GO

--EXEC usp_GetHoldersFullName


--CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan(@Amount DECIMAL(36))
--AS 

--	SELECT ah.FirstName, ah.LastName 
--		FROM (SELECT AccountHolderId, SUM(Balance) AS Balance
--				FROM Accounts
--				GROUP BY AccountHolderId) AS k
--		JOIN AccountHolders ah ON k.AccountHolderId = ah.Id
--		WHERE Balance > @Amount
--		ORDER BY ah.FirstName, ah.LastName

--GO

--EXEC usp_GetHoldersWithBalanceHigherThan 240000


--CREATE OR ALTER FUNCTION ufn_CalculateFutureValue
--(@Sum DECIMAL(36,6), @YearlyInterestRate FLOAT, @NumberOfYears INT)
--RETURNS DECIMAL(36,4)
--AS
--BEGIN

--	SET @YearlyInterestRate = @YearlyInterestRate + 1;
--	DECLARE @Result DECIMAL(36,4) = @Sum;

--	WHILE (@NumberOfYears > 0)
--	BEGIN
--		SET @Result = @Result * @YearlyInterestRate;
--		SET @NumberOfYears -= 1;
--	END

--	RETURN @Result
--END


--GO

--SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)


CREATE OR ALTER PROC usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate FLOAT)
AS
	DECLARE @Period INT = 5;
	SELECT 
		ah.Id AS [Account Id], 
		FirstName AS [First Name], 
		LastName AS [Last Name], 
		Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue (Balance, @InterestRate, @Period) AS [Balance in 5 years] 
	FROM AccountHolders ah
	JOIN Accounts a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId


GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1