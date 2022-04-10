CREATE OR ALTER PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4))
AS
BEGIN TRANSACTION 

	IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Money can not be negative value.', 1;
	END

	IF (@AccountId <= 0 AND @AccountId NOT IN (SELECT Id FROM Accounts))
	BEGIN	
		ROLLBACK;
		THROW 50002, 'Account not found.', 1
	END

	UPDATE Accounts SET Balance -= @MoneyAmount WHERE Id = @AccountId


COMMIT

EXEC usp_WithdrawMoney 5, 25